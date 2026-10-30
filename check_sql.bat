@echo off
setlocal
set "SERVIDOR=localhost,1433"
set "BASE_DATOS=Db_PublicidadMultisucursal"
set "USUARIO=sa"

if not defined PUBLICIDAD_SQL_PASSWORD (
    echo [ERROR] Define PUBLICIDAD_SQL_PASSWORD antes de ejecutar esta revision.
    exit /b 1
)

where sqlcmd >nul 2>&1
if errorlevel 1 (
    echo [ERROR] sqlcmd no esta instalado o no esta disponible en PATH.
    exit /b 1
)

echo Consultando el catalogo de SQL Server en modo de solo lectura...
sqlcmd -S "%SERVIDOR%" -d "%BASE_DATOS%" -U "%USUARIO%" -P "%PUBLICIDAD_SQL_PASSWORD%" -C -b -W -Q "SET NOCOUNT ON; IF OBJECT_ID('dbo.Tbl_Usuarios','U') IS NULL OR OBJECT_ID('dbo.Tbl_RolAccesos','U') IS NULL BEGIN RAISERROR('Faltan tablas base de Login y Roles.',16,1); RETURN; END; SELECT 'Base=' + DB_NAME(); SELECT 'Tablas=' + CONVERT(varchar(10),COUNT(*)) FROM sys.tables WHERE schema_id=SCHEMA_ID('dbo') AND name LIKE 'Tbl[_]%%'; SELECT 'Columnas=' + CONVERT(varchar(10),COUNT(*)) FROM sys.columns c INNER JOIN sys.tables t ON t.object_id=c.object_id WHERE t.schema_id=SCHEMA_ID('dbo') AND t.name LIKE 'Tbl[_]%%'; SELECT 'PK=' + CONVERT(varchar(10),COUNT(*)) FROM sys.key_constraints WHERE type='PK' AND parent_object_id IN (SELECT object_id FROM sys.tables WHERE schema_id=SCHEMA_ID('dbo') AND name LIKE 'Tbl[_]%%'); SELECT 'FK=' + CONVERT(varchar(10),COUNT(*)) FROM sys.foreign_keys WHERE is_disabled=0; DECLARE @tablas int, @columnas int, @pk int, @fk int; SELECT @tablas=COUNT(*) FROM sys.tables WHERE schema_id=SCHEMA_ID('dbo') AND name LIKE 'Tbl[_]%%'; SELECT @columnas=COUNT(*) FROM sys.columns c INNER JOIN sys.tables t ON t.object_id=c.object_id WHERE t.schema_id=SCHEMA_ID('dbo') AND t.name LIKE 'Tbl[_]%%'; SELECT @pk=COUNT(*) FROM sys.key_constraints WHERE type='PK' AND parent_object_id IN (SELECT object_id FROM sys.tables WHERE schema_id=SCHEMA_ID('dbo') AND name LIKE 'Tbl[_]%%'); SELECT @fk=COUNT(*) FROM sys.foreign_keys WHERE is_disabled=0; IF @tablas=16 AND @columnas=130 AND @pk=16 AND @fk=18 SELECT 'Esquema coincide con 16 tablas, 130 columnas, 16 PK y 18 FK.'; ELSE BEGIN RAISERROR('El catalogo no coincide con el esquema documentado.',16,1); RETURN; END;"
if errorlevel 1 (
    echo [ERROR] No se pudo verificar SQL Server. Revisa el servicio, la base y PUBLICIDAD_SQL_PASSWORD.
    exit /b 1
)

echo [OK] Conexion y catalogo consultados; no se modificaron datos.
exit /b 0
