@echo off
setlocal
cd /d "%~dp0"
set "FALLOS=0"

echo Revisando referencias de la solucion y las capas...
call :comprobar "SistemaPublicidad.sln" "Presentacion\SistemaPublicidad.csproj"
call :comprobar "SistemaPublicidad.sln" "Entidad\Entidad.csproj"
call :comprobar "SistemaPublicidad.sln" "Datos\Datos.csproj"
call :comprobar "SistemaPublicidad.sln" "Negocio\Negocio.csproj"
call :comprobar "Datos\Datos.csproj" "..\Entidad\Entidad.csproj"
call :comprobar "Negocio\Negocio.csproj" "..\Datos\Datos.csproj"
call :comprobar "Negocio\Negocio.csproj" "..\Entidad\Entidad.csproj"
call :comprobar "Presentacion\SistemaPublicidad.csproj" "..\Negocio\Negocio.csproj"
call :comprobar "Presentacion\SistemaPublicidad.csproj" "..\Entidad\Entidad.csproj"

findstr /s /i /n /c:"SqlConnection" /c:"SqlCommand" /c:"System.Data.SqlClient" /c:"using Datos;" Presentacion\Formularios\*.cs Presentacion\Login\Formularios\*.cs >nul 2>&1
if not errorlevel 1 (
    echo [ERROR] Presentacion contiene acceso directo a Datos o SQL Server.
    set "FALLOS=1"
) else (
    echo [OK] Presentacion no contiene referencias directas a Datos o SQL Server.
)

if "%FALLOS%"=="0" (
    echo Resultado: referencias correctas.
    exit /b 0
)

echo Resultado: hay referencias que requieren revision.
exit /b 1

:comprobar
findstr /i /c:"%~2" "%~1" >nul 2>&1
if errorlevel 1 (
    echo [ERROR] Falta "%~2" en "%~1".
    set "FALLOS=1"
) else (
    echo [OK] "%~2" en "%~1".
)
exit /b 0
