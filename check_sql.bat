@echo off
setlocal
cd /d "%~dp0"
if not defined PUBLICIDAD_SQL_PASSWORD (
    echo [ERROR] Define PUBLICIDAD_SQL_PASSWORD antes de ejecutar esta revision.
    exit /b 1
)
where sqlcmd >nul 2>&1
if errorlevel 1 (
    echo [ERROR] No se encontro sqlcmd en PATH.
    exit /b 1
)
set "SQLCMDPASSWORD=%PUBLICIDAD_SQL_PASSWORD%"
sqlcmd -S "localhost,1433" -d "Db_PublicidadMultisucursal" -U "sa" -C -b -l 10 -f 65001 -W -i "database\Verificar.sql"
if errorlevel 1 (
    echo [ERROR] Revisa la conexion y database\CONEXION_DATABASE.md.
    exit /b 1
)
echo [OK] Conexion, esquema y contrasenas verificados.
exit /b 0
