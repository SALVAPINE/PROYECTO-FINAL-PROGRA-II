-- Programación II 2026. Respaldo autorizado por el estudiante.
-- Contenedor comprobado: sql_prog2a; cuenta mssql (UID 10001).
-- Ruta existente con permisos comprobados antes de la ejecución.
-- No reutilizar el destino: este script falla si el archivo ya existe.
SET NOCOUNT ON;
IF DB_ID(N'Db_PublicidadMultisucursal') IS NULL
    THROW 50001, 'No existe la base de datos esperada.', 1;

DECLARE @Archivo TABLE (Existe int, EsDirectorio int, ExisteDirectorioPadre int);
INSERT INTO @Archivo
EXEC master.dbo.xp_fileexist
    N'/var/opt/mssql/data/Db_PublicidadMultisucursal_previo_20261017_01.bak';
IF EXISTS (SELECT 1 FROM @Archivo WHERE Existe = 1 OR EsDirectorio = 1)
    THROW 50002, 'El destino ya existe. Elegir otro nombre antes de ejecutar.', 1;
-- En este contenedor xp_fileexist no confirmó el directorio padre.
-- Sus permisos se verificaron directamente con docker exec como mssql.

-- COPY_ONLY conserva la base diferencial de los respaldos habituales.
BACKUP DATABASE [Db_PublicidadMultisucursal]
TO DISK = N'/var/opt/mssql/data/Db_PublicidadMultisucursal_previo_20261017_01.bak'
WITH COPY_ONLY, CHECKSUM, STOP_ON_ERROR, STATS = 10;

-- Valida legibilidad y checksums; no sustituye una restauración de prueba.
RESTORE VERIFYONLY
FROM DISK = N'/var/opt/mssql/data/Db_PublicidadMultisucursal_previo_20261017_01.bak'
WITH CHECKSUM, STOP_ON_ERROR;
