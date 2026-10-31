-- Migración idempotente. Ejecutar sobre Db_PublicidadMultisucursal tras un respaldo.
SET NOCOUNT ON;
SET XACT_ABORT ON;
IF DB_NAME() <> N'Db_PublicidadMultisucursal'
    THROW 50001, 'Selecciona Db_PublicidadMultisucursal antes de migrar.', 1;
IF EXISTS (SELECT NombreUsuario FROM dbo.Tbl_Usuarios GROUP BY NombreUsuario HAVING COUNT(*) > 1)
    THROW 50002, 'Hay usuarios duplicados. Resolverlos antes de migrar; no se eliminaron cuentas.', 1;

BEGIN TRANSACTION;
IF OBJECT_ID(N'dbo.Tbl_RolAccesos', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Tbl_RolAccesos
    (
        CodigoRolAcceso int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Tbl_RolAccesos PRIMARY KEY,
        TipoUsuario varchar(45) NOT NULL,
        NombreModulo varchar(60) NOT NULL,
        Estado bit NOT NULL CONSTRAINT DF_Tbl_RolAccesos_Estado DEFAULT(0),
        CONSTRAINT UQ_Tbl_RolAccesos_RolModulo UNIQUE(TipoUsuario, NombreModulo)
    );
END;
IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'dbo.Tbl_Clientes') AND name = N'DPI' AND system_type_id = 56)
    ALTER TABLE dbo.Tbl_Clientes ALTER COLUMN DPI bigint NOT NULL;

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE object_id=OBJECT_ID(N'dbo.Tbl_Usuarios') AND name=N'UX_Tbl_Usuarios_NombreUsuario')
    CREATE UNIQUE INDEX UX_Tbl_Usuarios_NombreUsuario ON dbo.Tbl_Usuarios(NombreUsuario);

DECLARE @roles TABLE (Rol varchar(45));
INSERT INTO @roles VALUES (N'Diseñador'), ('Operador'), ('Gerente'), ('Vendedor');
DECLARE @modulos TABLE (Modulo varchar(60));
INSERT INTO @modulos VALUES ('Inicio'), ('Usuarios'), ('Clientes'), ('Cotizaciones'), ('Tipo de Servicio'),
    ('Materiales'), (N'Diseños'), (N'Diseñadores'), (N'Órdenes de Trabajo'), ('Facturaciones'),
    ('Sucursales'), ('Proveedores'), ('Inventarios'), ('Compras');

-- Los permisos ya configurados se conservan, incluidos los desactivados.
INSERT INTO dbo.Tbl_RolAccesos(TipoUsuario, NombreModulo, Estado)
SELECT r.Rol, m.Modulo,
    CASE WHEN m.Modulo = 'Inicio' THEN 1
         WHEN r.Rol = N'Diseñador' AND m.Modulo IN ('Clientes','Cotizaciones','Materiales',N'Diseños',N'Órdenes de Trabajo','Sucursales') THEN 1
         WHEN r.Rol = 'Operador' AND m.Modulo IN ('Clientes','Cotizaciones','Tipo de Servicio','Materiales',N'Diseños',N'Órdenes de Trabajo','Facturaciones','Inventarios','Compras') THEN 1
         WHEN r.Rol = 'Gerente' AND m.Modulo NOT IN ('Usuarios') THEN 1
         WHEN r.Rol = 'Vendedor' AND m.Modulo IN ('Clientes','Cotizaciones','Tipo de Servicio','Facturaciones') THEN 1
         ELSE 0 END
FROM @roles r CROSS JOIN @modulos m
WHERE NOT EXISTS (SELECT 1 FROM dbo.Tbl_RolAccesos a WHERE a.TipoUsuario=r.Rol AND a.NombreModulo=m.Modulo);
COMMIT;
SELECT 'Migracion 09 aplicada: roles, DPI bigint y usuarios unicos.' AS Resultado;
