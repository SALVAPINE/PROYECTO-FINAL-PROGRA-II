# Conexión — propuesta y corrección autorizada

## Solución inspeccionada
Solución: src/SistemaPublicidad/SistemaPublicidad.sln. Datos y Presentacion declaran .NET Framework 4.8. Datos ya referencia System.Data y System.Configuration, e incluye ConexionDatos.cs. src/SistemaPublicidad/Presentacion/App.config contiene la configuración del servidor, base, usuario y nombre de variable de entorno.

## Clase propuesta
Reutilizar la clase estática Datos.ConexionDatos existente con System.Data.SqlClient. No crear una segunda clase ni instalar otro proveedor.
- CrearConexion(): leer configuración, validar valores y devolver una SqlConnection nueva mediante SqlConnectionStringBuilder.
- ProbarConexion(out string mensaje): abrir y cerrar con using, con manejo SqlException y Exception mediante try-catch.
- Mantener acceso SQL en Datos; conservar Entidad/Negocio/Presentacion y comentarios didácticos.
- Mantener consultas futuras parametrizadas; no agregar CRUD en esta etapa.

## Corrección mínima aplicada
Se validó VariableEntornoPasswordSql antes de invocar Environment.GetEnvironmentVariable, con autorización del estudiante:

```csharp
string nombreVariable = ConfigurationManager.AppSettings["VariableEntornoPasswordSql"];
if (string.IsNullOrWhiteSpace(nombreVariable))
    throw new InvalidOperationException("Falta configurar el nombre de la variable de entorno SQL en App.config.");
string contrasena = Environment.GetEnvironmentVariable(nombreVariable);
```

La configuración existente espera PUBLICIDAD_SQL_PASSWORD. El archivo .env local no se carga automáticamente y usa otro nombre de clave; guardar ese archivo no configura la variable del proceso. Posteriormente, por autorización expresa, se configuró y verificó PUBLICIDAD_SQL_PASSWORD en el entorno del usuario de Windows, leyendo el secreto desde .env sin imprimirlo. Visual Studio ya abierto debe cerrarse y abrirse de nuevo para heredar el cambio.

El código existente usa Encrypt=true y TrustServerCertificate=true para su conexión. No se cambió esa configuración. La clase corregida compiló aisladamente con csc de .NET Framework y referencia a System.Configuration, con código de salida 0; se eliminó la DLL temporal. No se compiló la solución completa ni se abrieron formularios. Posteriormente se compiló y ejecutó un programa temporal de .NET Framework con el código real de ConexionDatos y copia del App.config de Presentacion: ProbarConexion devolvió true, abrió y cerró correctamente la conexión y la ejecución terminó con código 0. Se eliminaron fuente, ejecutable y configuración temporales.

Estado: validación aplicada; variable del usuario configurada y verificada; prueba de la clase real y configuración de la aplicación correcta. La interfaz Windows Forms y la solución completa no fueron ejecutadas ni verificadas en esta prueba. No se modificaron diseñadores ni se agregó CRUD.
