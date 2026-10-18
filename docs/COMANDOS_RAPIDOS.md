# Comandos rápidos — CMD

Regla: preferir `cmd.exe` en Windows. No usar PowerShell mientras CMD esté disponible. Estos ejemplos son instrucciones; no certifican su ejecución.

Desde la raíz del repositorio:

```bat
cd
dir /a
tree skills /f /a
tree docs /f /a
tree database /f /a
dir /a src
type ESTADO_DOCUMENTOS.md
type MEMORY.md
```

Para entrar desde otra ubicación, usar `cd /d "RUTA_REAL_DEL_REPOSITORIO"`, sustituyendo la ruta.

La carpeta skills contiene los 11 archivos .md solicitados y no debe tener subcarpetas; docs y database también son planas. La solución actual está en src/SistemaPublicidad/SistemaPublicidad.sln con sus cuatro capas; src ya no está vacío.

## Compilación y consulta de archivos existentes

```bat
dotnet build src\SistemaPublicidad\SistemaPublicidad.sln --no-restore --verbosity quiet
type src\SistemaPublicidad\Entidad\Disenador.cs
type src\SistemaPublicidad\Datos\DisenadorDatos.cs
type src\SistemaPublicidad\Negocio\DisenadorNegocio.cs
type src\SistemaPublicidad\Presentacion\Formularios\FrmDisenadores.cs
```

La compilación anterior se ejecutó con resultado de 0 errores y 0 advertencias en las pruebas registradas. No se volvió a ejecutar durante la revisión documental actual. Leer o compilar no acredita las pruebas manuales del formulario.

Git/GitHub corresponde al Documento 05 según instrucción actual del estudiante: no ejecutar comandos de Git/GitHub en esta etapa. No iniciar otro módulo ni ejecutar escrituras SQL por cuenta propia. Conservar el nivel de Programación II y las autorizaciones por paso.
