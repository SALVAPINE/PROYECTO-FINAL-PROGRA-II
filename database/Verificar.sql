SET NOCOUNT ON;
DECLARE @tablas int = (SELECT COUNT(*) FROM sys.tables WHERE schema_id=SCHEMA_ID('dbo') AND name LIKE 'Tbl[_]%');
DECLARE @campos int = (SELECT COUNT(*) FROM sys.columns WHERE object_id IN (SELECT object_id FROM sys.tables WHERE schema_id=SCHEMA_ID('dbo') AND name LIKE 'Tbl[_]%'));
DECLARE @pk int = (SELECT COUNT(*) FROM sys.key_constraints WHERE type='PK' AND parent_object_id IN (SELECT object_id FROM sys.tables WHERE schema_id=SCHEMA_ID('dbo') AND name LIKE 'Tbl[_]%'));
DECLARE @fk int = (SELECT COUNT(*) FROM sys.foreign_keys WHERE is_disabled=0 AND is_not_trusted=0 AND parent_object_id IN (SELECT object_id FROM sys.tables WHERE schema_id=SCHEMA_ID('dbo') AND name LIKE 'Tbl[_]%'));
SELECT DB_NAME() AS BaseDatos, @tablas AS Tablas, @campos AS Campos, @pk AS PK, @fk AS FK;
IF @tablas<>16 OR @campos<>130 OR @pk<>16 OR @fk<>18
    THROW 50001, 'El esquema no coincide con 16 tablas, 130 campos, 16 PK y 18 FK confiables.', 1;
IF OBJECT_ID('dbo.Tbl_RolAccesos','U') IS NULL
    THROW 50002, 'Falta Tbl_RolAccesos.', 1;
IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id=OBJECT_ID('dbo.Tbl_Clientes') AND name='DPI' AND system_type_id=127)
    THROW 50003, 'DPI debe ser bigint. Ejecuta la migracion 09.', 1;
IF EXISTS (SELECT 1 FROM dbo.Tbl_Usuarios WHERE Clave NOT LIKE 'PBKDF2-SHA256$%')
    THROW 50004, 'Hay contrasenas pendientes de convertir. Ejecuta Actualizar-BaseDatos.ps1.', 1;
SELECT 'Esquema y almacenamiento de contrasenas verificados.' AS Resultado;
