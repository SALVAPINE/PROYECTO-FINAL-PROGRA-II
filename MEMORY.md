# Resultados verificados

## Documento 09 - Integración general (2026-10-30)

Correcciones autorizadas después de la revisión inicial. La solución de `src` referencia las cuatro capas en la raíz; no hay una segunda implementación en `src`.

### Aplicado

- Migración local con respaldo nuevo y RESTORE VERIFYONLY WITH CHECKSUM antes de modificar SQL Server. Respaldo del servidor: `/var/opt/mssql/data/Db_PublicidadMultisucursal_pre09_20261030_234649_744.bak`.
- Tbl_RolAccesos creada: 56 permisos iniciales para los cuatro perfiles configurables. Administrador conserva acceso completo y gestiona Roles.
- Catálogo real comprobado: 16 tablas, 130 campos, 16 PK y 18 FK habilitadas y confiables. DPI es bigint en SQL Server y long en Entidad.
- Las seis cuentas existentes conservaron sus datos de acceso y sus claves se convirtieron a hashes PBKDF2-SHA256 con sal. No quedan contraseñas antiguas en texto plano en Tbl_Usuarios.
- La migración se repitió con el respaldo previo ya verificado: convirtió 0 claves y conservó los permisos configurados.
- Login admite los cinco perfiles existentes en la aplicación; Recordar usuario guarda solo nombre y perfil. No se generan contraseñas predeterminadas.
- Usuarios oculta claves en consultas y permite conservarlas dejando vacío el campo al editar. Se probó el restablecimiento de contraseña.
- Si faltan permisos o falla su consulta no se conceden módulos predeterminados. El Dashboard limita sus datos a los módulos permitidos.
- Búsqueda superior conectada al CRUD abierto. Dashboard refrescado al regresar a Inicio. La actividad reciente se filtra por tipo antes de limitar lo mostrado.
- Documentos del proyecto incorporados y LEEME.txt corregido para describir los formularios reales construidos en C#.

### Pruebas realizadas

- Compilación Debug y Release de la solución: 0 errores, 0 advertencias.
- Compilación del proyecto Login independiente: 0 errores, 0 advertencias; su configuración ahora se copia desde Presentacion/App.config.
- check_refs.bat: correcto; Presentación no accede directamente a Datos ni a SQL Server.
- check_sql.bat: correcto después de repetir la migración.
- tests/Integracion09: **86 comprobaciones correctas**. Incluyen esquema, hashes, perfiles, cuentas inactivas, conservación/restablecimiento de clave, autorización y CRUD de permisos, reversión de permisos de prueba, DPI de 13 dígitos, preferencias, construcción de todas las pantallas, lectura de los 13 CRUD y Roles, búsqueda y refresco del Dashboard.
- Consulta posterior: 0 usuarios temporales y 0 clientes temporales; la cuenta JuanDaniel sigue activa como Administrador.
- Imagen de Login generada mediante DrawToBitmap e inspeccionada: cinco perfiles visibles y pie sin solapamiento. Artefacto local: artifacts/revision09-login.png. No es una prueba manual interactiva.
- git diff --check: sin errores de espacios; Git avisa de normalización LF/CRLF en archivos de texto.

### Límites y pendientes

- La compilación del proyecto de pruebas mostró NU1900: no pudo consultar la información de vulnerabilidades de NuGet, incluso al reintentar fuera del entorno restringido. La compilación completó sin errores; no se afirma que la auditoría de dependencias esté completada.
- Faltan pruebas manuales de navegación, altas/ediciones/eliminaciones de todos los módulos, detalles, impresión/PDF y ejecución en otro Windows. Las pruebas automáticas de escritura se concentraron en Usuarios, Clientes y Roles.
- La matriz de permisos inicial de Gerente y Vendedor está descrita en database/CONEXION_DATABASE.md; el grupo debe confirmar su política final. Los permisos son por módulo completo, sin distinguir operaciones.
- No se considera cerrado el Documento 09 hasta la validación integrada del grupo. No hay asignación individual confirmada de los módulos.
- La publicación de estas correcciones se solicitó el 2026-10-31 para master y JuanDaniel. Verificar su sincronización con las referencias remotas de Git; este documento no sustituye esa comprobación.
