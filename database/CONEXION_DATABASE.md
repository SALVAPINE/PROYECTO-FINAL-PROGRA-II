# Conexión y esquema verificados — SQL Server

## Alcance y estado

Documento 02: metadatos, respaldo e inspección de formularios autorizados por el estudiante. Aplicado `skills/02_Conexion_SQLServer.md`. No se autorizaron CRUD ni cambios de esquema o diseñadores. La interfaz Windows Forms continúa sin verificar; la clase real de conexión y su configuración ya pasaron la prueba descrita al final.

Servidor consultado: `localhost,1433`; puerto: `1433`; autenticación SQL Server; usuario: `sa`. `DB_NAME()` devolvió `Db_PublicidadMultisucursal`.

Credenciales en `.env` local excluido de Git. No se incluyen contraseñas en este documento. La aplicación existente no carga automáticamente ese archivo.

## Método y resultados

Se consultaron únicamente catálogos de SQL Server con CMD y sqlcmd: sys.tables, sys.schemas, sys.columns, sys.types, sys.key_constraints, sys.index_columns, sys.foreign_keys y sys.foreign_key_columns. Se excluyeron tablas de sistema. No se consultaron registros de usuarios ni se modificaron datos o estructuras.

La conexión dentro del entorno restringido falló por SSL/acceso local. Fuera del entorno restringido, con autorización, la consulta terminó con código 0. Se resolvió un conflicto de intercalación solo en las expresiones SELECT. Para conservar exactamente la ñ, se transportó como marcador Unicode U+00F1 y se reconstruyó al documentar.

- 15 tablas de usuario, todas en dbo.
- 126 columnas; 2 permiten NULL.
- 15 PK, todas de una columna int con IDENTITY.
- 18 FK, todas de una columna, habilitadas y confiables (is_disabled=0; is_not_trusted=0).
- Todas las FK tienen ON UPDATE NO_ACTION y ON DELETE NO_ACTION.
- Nombre real de la PK de proveedores: `CodgioProveedor`; no corregirlo por suposición.

## Columnas y claves primarias

Nullable indica si se admite NULL. IDENTITY indica generación automática registrada en el catálogo. Se conserva el orden real de columnas.

### dbo.Tbl_Clientes

PK: `CodigoCliente`; restricción: `PK__Tbl_Clie__E0DD7E71FDAFE139`; posición: 1.

| Orden | Columna | Tipo SQL | Nullable | IDENTITY | PK |
|---|---|---|---|---|---|
| 1 | CodigoCliente | int | NO | SI | SI |
| 2 | NombreCliente | varchar(45) | NO | NO | NO |
| 3 | Direccion | varchar(150) | NO | NO | NO |
| 4 | DPI | int | NO | NO | NO |
| 5 | Edad | int | NO | NO | NO |
| 6 | NIT | int | SI | NO | NO |
| 7 | Telefono | int | NO | NO | NO |
| 8 | Estado | bit | NO | NO | NO |

### dbo.Tbl_Compras

PK: `CodigoCompra`; restricción: `PK__Tbl_Comp__39DDA18FEEA9B4B9`; posición: 1.

| Orden | Columna | Tipo SQL | Nullable | IDENTITY | PK |
|---|---|---|---|---|---|
| 1 | CodigoCompra | int | NO | SI | SI |
| 2 | CodigoProveedor | int | NO | NO | NO |
| 3 | CodigoMaterial | int | NO | NO | NO |
| 4 | CantidadComprada | int | NO | NO | NO |
| 5 | TotalCompra | decimal(10,2) | NO | NO | NO |
| 6 | FechaCompra | datetime | NO | NO | NO |
| 7 | FechaEntrega | datetime | NO | NO | NO |
| 8 | Estado | bit | NO | NO | NO |

### dbo.Tbl_Cotizaciones

PK: `CodigoCotizacion`; restricción: `PK__Tbl_Coti__9DC346CC58BD64EB`; posición: 1.

| Orden | Columna | Tipo SQL | Nullable | IDENTITY | PK |
|---|---|---|---|---|---|
| 1 | CodigoCotizacion | int | NO | SI | SI |
| 2 | CodigoTipoServicio | int | NO | NO | NO |
| 3 | CodigoSucursal | int | NO | NO | NO |
| 4 | CodigoCliente | int | NO | NO | NO |
| 5 | NombreCotizador | varchar(45) | NO | NO | NO |
| 6 | NIT | int | SI | NO | NO |
| 7 | DireccionCotizador | varchar(150) | NO | NO | NO |
| 8 | FechaEmision | datetime | NO | NO | NO |
| 9 | Descripcion | varchar(150) | NO | NO | NO |
| 10 | Cantidad | int | NO | NO | NO |
| 11 | Precio | decimal(10,2) | NO | NO | NO |
| 12 | Subtotal | decimal(10,2) | NO | NO | NO |
| 13 | Total | decimal(10,2) | NO | NO | NO |
| 14 | Estado | bit | NO | NO | NO |

### dbo.Tbl_DetalleCompra

PK: `CodigoDetalleCompra`; restricción: `PK__Tbl_Deta__2DC9DDE49E603C64`; posición: 1.

| Orden | Columna | Tipo SQL | Nullable | IDENTITY | PK |
|---|---|---|---|---|---|
| 1 | CodigoDetalleCompra | int | NO | SI | SI |
| 2 | CodigoCompra | int | NO | NO | NO |
| 3 | PrecioUnitario | decimal(10,2) | NO | NO | NO |
| 4 | TipoDeCompra | varchar(45) | NO | NO | NO |
| 5 | Subtotal | decimal(10,2) | NO | NO | NO |
| 6 | DescuentoCompra | decimal(10,2) | NO | NO | NO |
| 7 | Descripcion | varchar(150) | NO | NO | NO |
| 8 | Estado | bit | NO | NO | NO |

### dbo.Tbl_DetalleFactura

PK: `CodigoDetalleFactura`; restricción: `PK__Tbl_Deta__922DCCDDCD65C3EC`; posición: 1.

| Orden | Columna | Tipo SQL | Nullable | IDENTITY | PK |
|---|---|---|---|---|---|
| 1 | CodigoDetalleFactura | int | NO | SI | SI |
| 2 | CodigoFacturacion | int | NO | NO | NO |
| 3 | DescuentoAplicado | decimal(10,2) | NO | NO | NO |
| 4 | Cantidad | int | NO | NO | NO |
| 5 | Precio | decimal(10,2) | NO | NO | NO |
| 6 | Descripcion | varchar(150) | NO | NO | NO |
| 7 | Estado | bit | NO | NO | NO |

### dbo.Tbl_Diseñadores

PK: `CodigoDiseñador`; restricción: `PK__Tbl_Dise__68587B565557789E`; posición: 1.

| Orden | Columna | Tipo SQL | Nullable | IDENTITY | PK |
|---|---|---|---|---|---|
| 1 | CodigoDiseñador | int | NO | SI | SI |
| 2 | NombreDiseñador | varchar(45) | NO | NO | NO |
| 3 | Edad | int | NO | NO | NO |
| 4 | Especialidad | varchar(45) | NO | NO | NO |
| 5 | Telefono | int | NO | NO | NO |
| 6 | Correo | varchar(150) | NO | NO | NO |
| 7 | Estado | bit | NO | NO | NO |

### dbo.Tbl_Diseños

PK: `CodigoDiseño`; restricción: `PK__Tbl_Dise__6B705D8B894F15AA`; posición: 1.

| Orden | Columna | Tipo SQL | Nullable | IDENTITY | PK |
|---|---|---|---|---|---|
| 1 | CodigoDiseño | int | NO | SI | SI |
| 2 | CodigoCliente | int | NO | NO | NO |
| 3 | CodigoDiseñador | int | NO | NO | NO |
| 4 | NombreDiseño | varchar(45) | NO | NO | NO |
| 5 | TipoDiseño | varchar(45) | NO | NO | NO |
| 6 | Descripcion | varchar(150) | NO | NO | NO |
| 7 | RangoDiseño | varchar(45) | NO | NO | NO |
| 8 | FechaCreacion | datetime | NO | NO | NO |
| 9 | Estado | bit | NO | NO | NO |

### dbo.Tbl_Facturacion

PK: `CodigoFacturacion`; restricción: `PK__Tbl_Fact__FA0839EC0EE485B0`; posición: 1.

| Orden | Columna | Tipo SQL | Nullable | IDENTITY | PK |
|---|---|---|---|---|---|
| 1 | CodigoFacturacion | int | NO | SI | SI |
| 2 | CodigoOrdenTrabajo | int | NO | NO | NO |
| 3 | NoFactura | int | NO | NO | NO |
| 4 | FechaDeEntrega | datetime | NO | NO | NO |
| 5 | Subtotal | decimal(10,2) | NO | NO | NO |
| 6 | Impuesto | decimal(10,2) | NO | NO | NO |
| 7 | TotalPagar | decimal(10,2) | NO | NO | NO |
| 8 | Estado | bit | NO | NO | NO |

### dbo.Tbl_Inventarios

PK: `CodigoInventario`; restricción: `PK__Tbl_Inve__D5EC1A76C3576A37`; posición: 1.

| Orden | Columna | Tipo SQL | Nullable | IDENTITY | PK |
|---|---|---|---|---|---|
| 1 | CodigoInventario | int | NO | SI | SI |
| 2 | CodigoSucursal | int | NO | NO | NO |
| 3 | CodigoMaterial | int | NO | NO | NO |
| 4 | NombreProducto | varchar(45) | NO | NO | NO |
| 5 | TipoProducto | varchar(45) | NO | NO | NO |
| 6 | Stock | int | NO | NO | NO |
| 7 | PrecioCompra | decimal(10,2) | NO | NO | NO |
| 8 | FechaAlmacenamiento | datetime | NO | NO | NO |
| 9 | Estado | bit | NO | NO | NO |

### dbo.Tbl_Materiales

PK: `CodigoMaterial`; restricción: `PK__Tbl_Mate__012334FEF132289F`; posición: 1.

| Orden | Columna | Tipo SQL | Nullable | IDENTITY | PK |
|---|---|---|---|---|---|
| 1 | CodigoMaterial | int | NO | SI | SI |
| 2 | CodigoOrdenTrabajo | int | NO | NO | NO |
| 3 | NombreMaterial | varchar(45) | NO | NO | NO |
| 4 | TipoDeMaterial | varchar(45) | NO | NO | NO |
| 5 | UnidadMedida | varchar(45) | NO | NO | NO |
| 6 | CategoriaMaterial | varchar(45) | NO | NO | NO |
| 7 | CostoMaterial | decimal(10,2) | NO | NO | NO |
| 8 | Estado | bit | NO | NO | NO |

### dbo.Tbl_OrdenesDeTrabajo

PK: `CodigoOrdenTrabajo`; restricción: `PK__Tbl_Orde__8B728BF999FE355A`; posición: 1.

| Orden | Columna | Tipo SQL | Nullable | IDENTITY | PK |
|---|---|---|---|---|---|
| 1 | CodigoOrdenTrabajo | int | NO | SI | SI |
| 2 | CodigoSucursal | int | NO | NO | NO |
| 3 | CodigoTipoServicio | int | NO | NO | NO |
| 4 | CodigoCotizacion | int | NO | NO | NO |
| 5 | CodigoDiseñador | int | NO | NO | NO |
| 6 | NombreOrdenTrabajo | varchar(100) | NO | NO | NO |
| 7 | TipoDeOrden | varchar(100) | NO | NO | NO |
| 8 | FechaInicio | datetime | NO | NO | NO |
| 9 | FechaFinalizacion | datetime | NO | NO | NO |
| 10 | Descripcion | varchar(150) | NO | NO | NO |
| 11 | Estado | bit | NO | NO | NO |

### dbo.Tbl_Proveedores

PK: `CodgioProveedor`; restricción: `PK__Tbl_Prov__E6D8B8D49E123189`; posición: 1.

| Orden | Columna | Tipo SQL | Nullable | IDENTITY | PK |
|---|---|---|---|---|---|
| 1 | CodgioProveedor | int | NO | SI | SI |
| 2 | NombreProveedor | varchar(45) | NO | NO | NO |
| 3 | Telefono | int | NO | NO | NO |
| 4 | Correo | varchar(150) | NO | NO | NO |
| 5 | TipoProveedor | varchar(45) | NO | NO | NO |
| 6 | Direccion | varchar(150) | NO | NO | NO |
| 7 | Estado | bit | NO | NO | NO |

### dbo.Tbl_Sucursales

PK: `CodigoSucursal`; restricción: `PK__Tbl_Sucu__E9A9A103F7E7FC07`; posición: 1.

| Orden | Columna | Tipo SQL | Nullable | IDENTITY | PK |
|---|---|---|---|---|---|
| 1 | CodigoSucursal | int | NO | SI | SI |
| 2 | NombreSucursal | varchar(45) | NO | NO | NO |
| 3 | Direccion | varchar(150) | NO | NO | NO |
| 4 | Municipio | varchar(100) | NO | NO | NO |
| 5 | Departamento | varchar(100) | NO | NO | NO |
| 6 | Telefono | int | NO | NO | NO |
| 7 | HorarioDeAtencion | time(7) | NO | NO | NO |
| 8 | Estado | bit | NO | NO | NO |

### dbo.Tbl_TipoDeServicio

PK: `CodigoTipoServicio`; restricción: `PK__Tbl_Tipo__21B02616AFC8D9F2`; posición: 1.

| Orden | Columna | Tipo SQL | Nullable | IDENTITY | PK |
|---|---|---|---|---|---|
| 1 | CodigoTipoServicio | int | NO | SI | SI |
| 2 | NombreServicio | varchar(45) | NO | NO | NO |
| 3 | CostoServicio | decimal(10,2) | NO | NO | NO |
| 4 | RecargoServicio | decimal(10,2) | NO | NO | NO |
| 5 | TotalServicio | decimal(10,2) | NO | NO | NO |
| 6 | Descripcion | varchar(150) | NO | NO | NO |
| 7 | Estado | bit | NO | NO | NO |

### dbo.Tbl_Usuarios

PK: `CodigoUsuario`; restricción: `PK__Tbl_Usua__F0C18F580D74ECD4`; posición: 1.

| Orden | Columna | Tipo SQL | Nullable | IDENTITY | PK |
|---|---|---|---|---|---|
| 1 | CodigoUsuario | int | NO | SI | SI |
| 2 | CodigoSucursal | int | NO | NO | NO |
| 3 | NombreUsuario | varchar(45) | NO | NO | NO |
| 4 | Clave | varchar(255) | NO | NO | NO |
| 5 | FechaCreacion | datetime | NO | NO | NO |
| 6 | TipoUsuario | varchar(45) | NO | NO | NO |
| 7 | Estado | bit | NO | NO | NO |

## Claves foráneas verificadas

Cada fila corresponde a una restricción real. Todas tienen posición de columna 1. No se infieren relaciones a partir de nombres coincidentes.

| Restricción FK | Tabla origen | Columna origen | Tabla referenciada | Columna referenciada |
|---|---|---|---|---|
| FK__Tbl_Compr__Codig__5BE2A6F2 | dbo.Tbl_Compras | CodigoProveedor | dbo.Tbl_Proveedores | CodgioProveedor |
| FK__Tbl_Compr__Codig__5CD6CB2B | dbo.Tbl_Compras | CodigoMaterial | dbo.Tbl_Materiales | CodigoMaterial |
| FK__Tbl_Cotiz__Codig__403A8C7D | dbo.Tbl_Cotizaciones | CodigoTipoServicio | dbo.Tbl_TipoDeServicio | CodigoTipoServicio |
| FK__Tbl_Cotiz__Codig__412EB0B6 | dbo.Tbl_Cotizaciones | CodigoSucursal | dbo.Tbl_Sucursales | CodigoSucursal |
| FK__Tbl_Cotiz__Codig__4222D4EF | dbo.Tbl_Cotizaciones | CodigoCliente | dbo.Tbl_Clientes | CodigoCliente |
| FK__Tbl_Detal__Codig__5FB337D6 | dbo.Tbl_DetalleCompra | CodigoCompra | dbo.Tbl_Compras | CodigoCompra |
| FK__Tbl_Detal__Codig__628FA481 | dbo.Tbl_DetalleFactura | CodigoFacturacion | dbo.Tbl_Facturacion | CodigoFacturacion |
| FK__Tbl_Diseñ__Codig__52593CB8 | dbo.Tbl_Diseños | CodigoCliente | dbo.Tbl_Clientes | CodigoCliente |
| FK__Tbl_Diseñ__Codig__534D60F1 | dbo.Tbl_Diseños | CodigoDiseñador | dbo.Tbl_Diseñadores | CodigoDiseñador |
| FK__Tbl_Factu__Codig__4CA06362 | dbo.Tbl_Facturacion | CodigoOrdenTrabajo | dbo.Tbl_OrdenesDeTrabajo | CodigoOrdenTrabajo |
| FK__Tbl_Inven__Codig__5629CD9C | dbo.Tbl_Inventarios | CodigoMaterial | dbo.Tbl_Materiales | CodigoMaterial |
| FK__Tbl_Inven__Codig__571DF1D5 | dbo.Tbl_Inventarios | CodigoSucursal | dbo.Tbl_Sucursales | CodigoSucursal |
| FK__Tbl_Mater__Codig__4F7CD00D | dbo.Tbl_Materiales | CodigoOrdenTrabajo | dbo.Tbl_OrdenesDeTrabajo | CodigoOrdenTrabajo |
| FK__Tbl_Orden__Codig__46E78A0C | dbo.Tbl_OrdenesDeTrabajo | CodigoSucursal | dbo.Tbl_Sucursales | CodigoSucursal |
| FK__Tbl_Orden__Codig__47DBAE45 | dbo.Tbl_OrdenesDeTrabajo | CodigoTipoServicio | dbo.Tbl_TipoDeServicio | CodigoTipoServicio |
| FK__Tbl_Orden__Codig__48CFD27E | dbo.Tbl_OrdenesDeTrabajo | CodigoCotizacion | dbo.Tbl_Cotizaciones | CodigoCotizacion |
| FK__Tbl_Orden__Codig__49C3F6B7 | dbo.Tbl_OrdenesDeTrabajo | CodigoDiseñador | dbo.Tbl_Diseñadores | CodigoDiseñador |
| FK__Tbl_Usuar__Codig__398D8EEE | dbo.Tbl_Usuarios | CodigoSucursal | dbo.Tbl_Sucursales | CodigoSucursal |

## Límites y pendientes

- Las únicas columnas nullable son NIT en dbo.Tbl_Clientes y dbo.Tbl_Cotizaciones.
- No se verificaron datos de negocio, valores predeterminados, restricciones CHECK, índices adicionales ni funcionamiento CRUD.
- En la inspección inicial se leyó Datos/ConexionDatos.cs con System.Data.SqlClient y contraseña desde variable de entorno; no se volvió a verificar su ubicación en esta consulta. Esta consulta con sqlcmd no acredita la conexión desde la aplicación.
- 01_Backup_Base_Datos.sql fue completado y ejecutado tras autorización y comprobación de permisos. Resultado detallado a continuación.
- Solicitar al estudiante el siguiente paso antes de continuar. Los documentos 03–10 permanecen bloqueados; las demás acciones del documento 02 requieren autorización.

## Respaldo ejecutado y verificado — 17/10/2026

- Contenedor: sql_prog2a, SQL Server 2022. Cuenta de ejecución comprobada: mssql, UID 10001.
- /var/opt/mssql/backup no existe. Se comprobó existencia y permisos de lectura, escritura y acceso de /var/opt/mssql/data mediante docker exec, antes de generar el archivo. Espacio disponible observado: aproximadamente 952 GB.
- Destinos interno y local comprobados libres antes de ejecutar. No se sobrescribió un respaldo existente.
- Script: database/01_Backup_Base_Datos.sql, con BACKUP DATABASE de Db_PublicidadMultisucursal, COPY_ONLY, CHECKSUM y STOP_ON_ERROR.
- Primera ejecución: se detuvo antes de BACKUP porque xp_fileexist no confirmó el directorio padre. Se retiró esa condición; los permisos ya se habían comprobado directamente como mssql. La comprobación de archivo existente se conserva.
- Ejecución final: código 0; BACKUP procesó 666 páginas. RESTORE VERIFYONLY WITH CHECKSUM, STOP_ON_ERROR informó que el conjunto de respaldo es válido.
- Archivo interno: /var/opt/mssql/data/Db_PublicidadMultisucursal_previo_20261017_01.bak.
- Copia externa conservada: database/Db_PublicidadMultisucursal_previo_20261017_01.bak, copiada con docker cp.
- Tamaño en ambos destinos: 5,558,272 bytes.
- SHA-256 idéntico en ambas copias: `5dbd78379db19af50cb42a0ed7b5e9130bf2198b9baee78c83c37191dda75dad`.
- La copia .bak está excluida de Git. No se realizó restauración de prueba; VERIFYONLY no demuestra una recuperación completa.
- No volver a ejecutar el script con el mismo destino; elegir un nombre nuevo y comprobar permisos y ausencia del archivo antes de cada ejecución.

## Inspección y propuesta preparadas

Actualización autorizada: src/SistemaPublicidad/Datos/ConexionDatos.cs valida que VariableEntornoPasswordSql no sea nulo, vacío o espacios antes de consultar Environment.GetEnvironmentVariable. Si falta, lanza InvalidOperationException con mensaje de configuración, capturado por el manejo existente de ProbarConexion. Compilación aislada de la clase con csc de .NET Framework: código 0; DLL temporal eliminada. No se configuró PUBLICIDAD_SQL_PASSWORD ni se ejecutó conexión desde la aplicación. Diseñadores, tablas y lógica CRUD sin cambios en este paso.

- Mapeo de las 126 columnas, controles y diferencias de formularios independientes: docs/MAPEO_FORMULARIOS_SQLSERVER.md.
- Propuesta para reutilizar System.Data.SqlClient y la clase existente, sin cambios de código: database/PROPUESTA_CONEXION.md.
- Ubicación actual tras traslado autorizado: src/SistemaPublicidad/SistemaPublicidad.sln. No se modificaron clases, diseñadores, recursos ni tablas. La conexión de la aplicación sigue pendiente de prueba autorizada.

## Prueba de conexión autorizada — 17/10/2026

Se configuró PUBLICIDAD_SQL_PASSWORD para el usuario de Windows y se verificó su valor sin imprimir el secreto. Se compiló un programa temporal de .NET Framework con el código real de src/SistemaPublicidad/Datos/ConexionDatos.cs y una copia del App.config de Presentacion. ProbarConexion devolvió true: apertura y cierre correctos; código de salida 0. Se eliminaron todos los archivos temporales. No se ejecutó la interfaz Windows Forms ni se compiló la solución completa. No se ejecutaron CRUD ni se modificaron tablas o diseñadores. Reiniciar Visual Studio para que herede la variable. Las menciones previas a prueba pendiente describen estados históricos; los documentos 03–10 siguen bloqueados y el siguiente paso requiere autorización.
