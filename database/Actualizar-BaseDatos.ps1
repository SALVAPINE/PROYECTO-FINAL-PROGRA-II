param([switch]$OmitirRespaldo)
$ErrorActionPreference = 'Stop'
Add-Type -AssemblyName System.Data
$repo = Split-Path $PSScriptRoot -Parent
[xml]$configuracion = Get-Content -LiteralPath (Join-Path $repo 'Presentacion/App.config')
$ajustes = @{}
foreach ($entrada in $configuracion.configuration.appSettings.add) { $ajustes[$entrada.key] = $entrada.value }
$secreto = [Environment]::GetEnvironmentVariable($ajustes['VariableEntornoPasswordSql'])
if ([string]::IsNullOrWhiteSpace($secreto)) { throw 'Falta la variable de entorno de SQL Server.' }
$constructor = New-Object System.Data.SqlClient.SqlConnectionStringBuilder
$constructor['Data Source'] = $ajustes['ServidorSql']
$constructor['Initial Catalog'] = $ajustes['BaseDatosSql']
$constructor['User ID'] = $ajustes['UsuarioSql']
$constructor['Password'] = $secreto
$constructor['Encrypt'] = $true
$constructor['TrustServerCertificate'] = $true
$dll = Join-Path $repo 'Datos/bin/Debug/Datos.dll'
if (!(Test-Path -LiteralPath $dll)) { throw 'Compila la solución en Debug antes de migrar las contraseñas.' }
$conexion = New-Object System.Data.SqlClient.SqlConnection($constructor.ConnectionString)
try {
    $conexion.Open()
    if (!$OmitirRespaldo) {
        # SQL Server en Docker Linux: archivo nuevo, sin sobrescribir respaldos anteriores.
        $respaldo = '/var/opt/mssql/data/Db_PublicidadMultisucursal_pre09_' + (Get-Date -Format 'yyyyMMdd_HHmmss_fff') + '.bak'
        $comando = $conexion.CreateCommand()
        $comando.CommandTimeout = 120
        $comando.CommandText = 'BACKUP DATABASE [Db_PublicidadMultisucursal] TO DISK = @ruta WITH CHECKSUM;'
        [void]$comando.Parameters.Add('@ruta', [System.Data.SqlDbType]::NVarChar, 4000)
        $comando.Parameters['@ruta'].Value = $respaldo
        [void]$comando.ExecuteNonQuery()
        $comando.CommandText = 'RESTORE VERIFYONLY FROM DISK = @ruta WITH CHECKSUM;'
        [void]$comando.ExecuteNonQuery()
        $comando.Dispose()
        Write-Output "Respaldo previo: $respaldo"
    }
    $comando = $conexion.CreateCommand()
    $comando.CommandText = Get-Content -LiteralPath (Join-Path $PSScriptRoot '09_Integracion.sql') -Raw -Encoding UTF8
    [void]$comando.ExecuteNonQuery()
    $comando.Dispose()

    # Hashes con sal, usando exactamente el mismo algoritmo que la aplicación.
    [void][Reflection.Assembly]::LoadFrom((Join-Path $repo 'Entidad/bin/Debug/Entidad.dll'))
    $ensamblado = [Reflection.Assembly]::LoadFrom($dll)
    $seguridad = $ensamblado.GetType('Datos.SeguridadClaves', $true)
    $crear = $seguridad.GetMethod('Crear', [Reflection.BindingFlags]'Static,NonPublic')
    $esHash = $seguridad.GetMethod('EsHash', [Reflection.BindingFlags]'Static,NonPublic')
    $comando = $conexion.CreateCommand()
    $comando.CommandText = 'SELECT CodigoUsuario, Clave FROM dbo.Tbl_Usuarios;'
    $tabla = New-Object System.Data.DataTable
    $lector = $comando.ExecuteReader()
    $tabla.Load($lector)
    $lector.Dispose()
    $comando.Dispose()
    $cantidad = 0
    foreach ($fila in $tabla.Rows) {
        if ($esHash.Invoke($null, @([string]$fila.Clave))) { continue }
        $hash = $crear.Invoke($null, @([string]$fila.Clave))
        $comando = $conexion.CreateCommand()
        $comando.CommandText = 'UPDATE dbo.Tbl_Usuarios SET Clave=@hash WHERE CodigoUsuario=@codigo AND Clave=@anterior; SELECT @@ROWCOUNT;'
        [void]$comando.Parameters.Add('@hash', [System.Data.SqlDbType]::VarChar, 255)
        $comando.Parameters['@hash'].Value = $hash
        [void]$comando.Parameters.Add('@codigo', [System.Data.SqlDbType]::Int)
        $comando.Parameters['@codigo'].Value = $fila.CodigoUsuario
        [void]$comando.Parameters.Add('@anterior', [System.Data.SqlDbType]::VarChar, 255)
        $comando.Parameters['@anterior'].Value = $fila.Clave
        $cantidad += [int]$comando.ExecuteScalar()
        $comando.Dispose()
    }
    Write-Output "Migracion aplicada. Contrasenas convertidas: $cantidad. Las claves de acceso se conservan."
}
finally { $conexion.Dispose() }
