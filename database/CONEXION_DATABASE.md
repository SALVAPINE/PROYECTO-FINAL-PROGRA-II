# Conexión y migración de SQL Server

`Presentacion/App.config` define servidor `localhost,1433`, base `Db_PublicidadMultisucursal`, usuario `sa` y el nombre de la variable `PUBLICIDAD_SQL_PASSWORD`. Nunca guardar su valor en Git.

La solución real está en las carpetas de la raíz. Para compilar:

```powershell
dotnet build src/SistemaPublicidad/SistemaPublicidad.sln --verbosity quiet
```

El contenedor local de SQL Server es Linux (`sql_prog2a`). Para aplicar el Documento 09:

```powershell
powershell.exe -NoProfile -ExecutionPolicy Bypass -File database/Actualizar-BaseDatos.ps1
```

La excepción de ejecución solo afecta ese proceso. El script lee App.config y la variable de entorno; crea un respaldo nuevo con CHECKSUM en `/var/opt/mssql/data/`, verifica el respaldo, aplica `09_Integracion.sql` y convierte las contraseñas usando la DLL recién compilada de Datos. La ruta de respaldo corresponde a este servidor Linux; debe adaptarse antes de usar otro servidor. No usar `-OmitirRespaldo` sin contar con un respaldo externo verificado.

La migración conserva usuarios, claves de acceso y datos existentes. Amplía DPI a bigint, crea Tbl_RolAccesos y un índice único de NombreUsuario. Si existen nombres duplicados, se detiene sin eliminar cuentas. Los permisos ya configurados no se sobrescriben al repetir la migración.

Se esperan **16 tablas, 130 campos, 16 PK y 18 FK habilitadas y confiables**. Ejecutar `check_sql.bat` para verificar. `CodgioProveedor` es el nombre real de la PK de Tbl_Proveedores y se conserva tal cual.

Permisos iniciales:

| Perfil | Módulos habilitados además de Inicio |
|---|---|
| Administrador | Todos, incluida la gestión de Roles; acceso completo definido en Negocio |
| Diseñador | Clientes, Cotizaciones, Materiales, Diseños, Órdenes de Trabajo, Sucursales |
| Operador | Clientes, Cotizaciones, Tipo de Servicio, Materiales, Diseños, Órdenes de Trabajo, Facturaciones, Inventarios, Compras |
| Gerente | Todos los módulos operativos; sin Usuarios ni Roles |
| Vendedor | Clientes, Cotizaciones, Tipo de Servicio, Facturaciones |

El administrador puede modificar permisos de los otros cuatro perfiles desde Roles. Estos permisos dan acceso al CRUD completo del módulo; no existen permisos por operación. El menú se reconstruye al iniciar sesión. Si no se pueden consultar permisos, los perfiles configurables conservan únicamente Inicio, sin datos de módulos no autorizados en el Dashboard.

Las contraseñas se almacenan con PBKDF2-SHA256, sal aleatoria y 600000 iteraciones. No hay claves predeterminadas para cuentas nuevas. Al editar un usuario, dejar Clave vacía conserva la contraseña anterior. Las cuentas antiguas de otra restauración también se convierten al autenticar correctamente.

Para restaurar se necesita un respaldo completo obtenido del servidor o de su responsable. Los respaldos no están versionados. No se presupone que existan carpetas DATABASE fuera del repositorio. Tras restaurar una copia anterior, ejecutar nuevamente la migración y las verificaciones.
