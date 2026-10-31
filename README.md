# Publicidad Multisucursal — Programación II 2026

Aplicación Windows Forms en C# y .NET Framework 4.8, con SQL Server local en Docker.

## Solución y arquitectura

Abrir `src/SistemaPublicidad/SistemaPublicidad.sln` o `SistemaPublicidad.sln`. Ambas soluciones referencian los mismos cuatro proyectos de la raíz:

- `Presentacion`: Login, Panel (`FrmPrincipal`), Dashboard (`FrmInicio`) y formularios.
- `Negocio`: reglas, permisos y resúmenes.
- `Datos`: consultas parametrizadas y conexión SQL Server.
- `Entidad`: entidades y documentos de intercambio.

Dependencias: Presentación -> Negocio -> Datos -> SQL Server; las tres capas utilizan Entidad. Los formularios y controles se construyen por código C#, sin archivos `.Designer.cs`.

## Ejecutar

1. Instalar Windows con .NET Framework 4.8 y las herramientas de compilación .NET.
2. Disponer de SQL Server con la base `Db_PublicidadMultisucursal`. La configuración de `Presentacion/App.config` espera `localhost,1433` y el usuario `sa`.
3. Definir la variable de entorno `PUBLICIDAD_SQL_PASSWORD` con la contraseña SQL del equipo. No publicarla en Git ni en documentos.
4. Compilar y, para una base anterior, aplicar la migración del Documento 09 siguiendo [CONEXION_DATABASE.md](database/CONEXION_DATABASE.md).

```powershell
dotnet build src/SistemaPublicidad/SistemaPublicidad.sln --verbosity quiet
powershell.exe -NoProfile -ExecutionPolicy Bypass -File database/Actualizar-BaseDatos.ps1
.\check_refs.bat
.\check_sql.bat
```

Ejecutable Debug: `Presentacion/bin/Debug/net48/SistemaPublicidad.exe`. Para Release, compilar con `-c Release` y ejecutar desde `Presentacion/bin/Release/net48/`, conservando sus DLL y configuración. Los binarios, ZIP y respaldos locales no están en GitHub.

## Pantallas y acceso

Login admite Administrador, Diseñador, Operador, Gerente y Vendedor. Hay que seleccionar el perfil de la cuenta. Recordar usuario conserva solo el nombre y perfil en el equipo; nunca la contraseña. La recuperación de acceso se solicita al administrador, quien puede restablecer la clave en Usuarios.

El Panel filtra el menú por permisos. La búsqueda superior filtra el CRUD abierto. Inicio refresca el Dashboard al regresar y limita los datos a los módulos permitidos. Roles permite al administrador crear, editar, desactivar y eliminar permisos de los otros perfiles; el menú refleja esos cambios en el siguiente inicio de sesión.

CRUD: Usuarios, Clientes, Cotizaciones, Tipo de Servicio, Materiales, Diseños, Diseñadores, Órdenes de Trabajo, Facturaciones, Sucursales, Proveedores, Inventarios y Compras. Facturaciones y Compras incluyen sus detalles. Roles es un módulo adicional de configuración.

Las cuentas nuevas requieren una contraseña propia de 8 a 255 caracteres. Al editar, Clave vacía conserva la anterior. Se almacenan hashes con sal; no hay contraseñas predeterminadas en código. DPI admite hasta 13 dígitos; los registros cortos existentes se conservan.

## Base y verificaciones

El esquema actualizado tiene 16 tablas, 130 campos, 16 PK y 18 FK habilitadas y confiables. Los scripts versionados están en `database/`; no se depende de scripts externos en carpetas DATABASE. Un respaldo completo debe obtenerse del servidor o su responsable. La migración local crea y verifica un respaldo antes de modificar el esquema.

Pruebas automáticas sobre la base local de desarrollo:

```powershell
dotnet build tests/Integracion09/Integracion09.csproj --verbosity quiet
.\tests\Integracion09\bin\Debug\net48\Integracion09.exe
```

Estas pruebas crean cuentas y un cliente temporales y los eliminan al terminar. No ejecutarlas sobre producción. Incluyen esquema, hashes, cinco perfiles, permisos, DPI, construcción de formularios, búsqueda y actualización del Dashboard. No reemplazan la revisión visual ni las pruebas manuales de todos los CRUD y PDF.

## Estado documental

Documento activo: **09 - Integración general**. Consultar [ESTADO_DOCUMENTOS.md](ESTADO_DOCUMENTOS.md), [MEMORY.md](MEMORY.md) y [lista de revisión](skills/10_Revision_Proyecto.md). La asignación individual de módulos de los integrantes no está confirmada en el repositorio; no se inventan responsables.
