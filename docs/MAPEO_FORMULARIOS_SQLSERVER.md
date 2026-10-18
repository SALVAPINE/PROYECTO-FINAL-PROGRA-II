# Mapeo de formularios y SQL Server

Inspección autorizada. Solución real: `src/SistemaPublicidad/SistemaPublicidad.sln`; proyectos dentro de src/SistemaPublicidad. La solución y las capas se trasladaron por autorización del estudiante, sin alterar su contenido. Se inspeccionaron los archivos Frm*.cs, sus Designer y los 17 .resx existentes; estos .resx no contienen entradas data o metadata adicionales. FrmLogin no tiene .resx ni referencia a él en el proyecto.

El esquema proviene de los metadatos verificados en database/CONEXION_DATABASE.md. Este mapeo es estructural: un control existente o una asignación en código no demuestra funcionamiento. No se ejecutó la aplicación ni CRUD. Todas las tablas usan dbo. Los detalles se mapean primero a los controles integrados en Compras y Facturaciones.

| Tabla | Columna | Tipo | Control | Observación |
|---|---|---|---|---|
| dbo.Tbl_Clientes | CodigoCliente | int | FrmClientes.txtCodigoCliente | TextBox; validar conversión y rango; PK IDENTITY |
| dbo.Tbl_Clientes | NombreCliente | varchar(45) | FrmClientes.txtNombreCliente | TextBox; respetar longitud SQL |
| dbo.Tbl_Clientes | Direccion | varchar(150) | FrmClientes.txtDireccion | TextBox; respetar longitud SQL |
| dbo.Tbl_Clientes | DPI | int | FrmClientes.txtDPI | TextBox; validar conversión y rango |
| dbo.Tbl_Clientes | Edad | int | FrmClientes.txtEdad | TextBox; validar conversión y rango |
| dbo.Tbl_Clientes | NIT | int | FrmClientes.txtNIT | TextBox; validar conversión y rango; admite NULL |
| dbo.Tbl_Clientes | Telefono | int | FrmClientes.txtTelefono | TextBox; validar conversión y rango |
| dbo.Tbl_Clientes | Estado | bit | FrmClientes.rdoActivo / rdoInactivo | RadioButton → bit |
| dbo.Tbl_Compras | CodigoCompra | int | FrmCompras.txtCodigoCompra | TextBox; validar conversión y rango; PK IDENTITY |
| dbo.Tbl_Compras | CodigoProveedor | int | FrmCompras.cmbCodigoProveedor | ComboBox; FK → dbo.Tbl_Proveedores.CodgioProveedor |
| dbo.Tbl_Compras | CodigoMaterial | int | FrmCompras.cmbCodigoMaterial | ComboBox; FK → dbo.Tbl_Materiales.CodigoMaterial |
| dbo.Tbl_Compras | CantidadComprada | int | FrmCompras.txtCantidadComprada | TextBox; validar conversión y rango |
| dbo.Tbl_Compras | TotalCompra | decimal(10,2) | FrmCompras.txtTotalCompra | TextBox; validar conversión y rango |
| dbo.Tbl_Compras | FechaCompra | datetime | FrmCompras.dtpFechaCompra | DateTimePicker |
| dbo.Tbl_Compras | FechaEntrega | datetime | FrmCompras.dtpFechaEntrega | DateTimePicker |
| dbo.Tbl_Compras | Estado | bit | FrmCompras.rdoActivo / rdoInactivo | RadioButton → bit |
| dbo.Tbl_Cotizaciones | CodigoCotizacion | int | FrmCotizaciones.txtCodigoCotizacion | TextBox; validar conversión y rango; PK IDENTITY |
| dbo.Tbl_Cotizaciones | CodigoTipoServicio | int | FrmCotizaciones.cmbCodigoTipoServicio | ComboBox; FK → dbo.Tbl_TipoDeServicio.CodigoTipoServicio |
| dbo.Tbl_Cotizaciones | CodigoSucursal | int | FrmCotizaciones.cmbCodigoSucursal | ComboBox; FK → dbo.Tbl_Sucursales.CodigoSucursal |
| dbo.Tbl_Cotizaciones | CodigoCliente | int | FrmCotizaciones.cmbCodigoCliente | ComboBox; FK → dbo.Tbl_Clientes.CodigoCliente |
| dbo.Tbl_Cotizaciones | NombreCotizador | varchar(45) | FrmCotizaciones.txtNombreCotizador | TextBox; respetar longitud SQL |
| dbo.Tbl_Cotizaciones | NIT | int | FrmCotizaciones.txtNIT | TextBox; validar conversión y rango; admite NULL |
| dbo.Tbl_Cotizaciones | DireccionCotizador | varchar(150) | FrmCotizaciones.txtDireccionCotizador | TextBox; respetar longitud SQL |
| dbo.Tbl_Cotizaciones | FechaEmision | datetime | FrmCotizaciones.dtpFechaEmision | DateTimePicker |
| dbo.Tbl_Cotizaciones | Descripcion | varchar(150) | FrmCotizaciones.txtDescripcion | TextBox; respetar longitud SQL |
| dbo.Tbl_Cotizaciones | Cantidad | int | FrmCotizaciones.txtCantidad | NumericUpDown; validar rango/precisión SQL |
| dbo.Tbl_Cotizaciones | Precio | decimal(10,2) | FrmCotizaciones.txtPrecio | NumericUpDown; validar rango/precisión SQL |
| dbo.Tbl_Cotizaciones | Subtotal | decimal(10,2) | FrmCotizaciones.txtSubtotal | NumericUpDown; validar rango/precisión SQL |
| dbo.Tbl_Cotizaciones | Total | decimal(10,2) | FrmCotizaciones.txtTotal | NumericUpDown; validar rango/precisión SQL |
| dbo.Tbl_Cotizaciones | Estado | bit | FrmCotizaciones.rdoActivo / rdoInactivo | RadioButton → bit |
| dbo.Tbl_DetalleCompra | CodigoDetalleCompra | int | FrmCompras.txtCodigoDetalleCompra | TextBox; validar conversión y rango; PK IDENTITY |
| dbo.Tbl_DetalleCompra | CodigoCompra | int | FrmCompras.txtCodigoCompra | TextBox; validar conversión y rango; FK → dbo.Tbl_Compras.CodigoCompra; contexto del encabezado |
| dbo.Tbl_DetalleCompra | PrecioUnitario | decimal(10,2) | FrmCompras.txtPrecioUnitario | TextBox; validar conversión y rango |
| dbo.Tbl_DetalleCompra | TipoDeCompra | varchar(45) | FrmCompras.txtTipoDeCompra | TextBox; respetar longitud SQL |
| dbo.Tbl_DetalleCompra | Subtotal | decimal(10,2) | FrmCompras.txtSubtotal | TextBox; validar conversión y rango |
| dbo.Tbl_DetalleCompra | DescuentoCompra | decimal(10,2) | FrmCompras.txtDescuentoCompra | TextBox; validar conversión y rango |
| dbo.Tbl_DetalleCompra | Descripcion | varchar(150) | FrmCompras.txtDescripcion | TextBox; respetar longitud SQL |
| dbo.Tbl_DetalleCompra | Estado | bit | FrmCompras.rdoActivoDetalle / rdoInactivoDetalle | RadioButton → bit |
| dbo.Tbl_DetalleFactura | CodigoDetalleFactura | int | FrmFacturaciones.txtCodigoDetalleFactura | TextBox; validar conversión y rango; PK IDENTITY |
| dbo.Tbl_DetalleFactura | CodigoFacturacion | int | FrmFacturaciones.txtCodigoFacturacion | TextBox; validar conversión y rango; FK → dbo.Tbl_Facturacion.CodigoFacturacion; contexto del encabezado |
| dbo.Tbl_DetalleFactura | DescuentoAplicado | decimal(10,2) | FrmFacturaciones.txtDescuentoAplicado | TextBox; validar conversión y rango |
| dbo.Tbl_DetalleFactura | Cantidad | int | FrmFacturaciones.txtCantidad | TextBox; validar conversión y rango |
| dbo.Tbl_DetalleFactura | Precio | decimal(10,2) | FrmFacturaciones.txtPrecio | TextBox; validar conversión y rango |
| dbo.Tbl_DetalleFactura | Descripcion | varchar(150) | FrmFacturaciones.txtDescripcion | TextBox; respetar longitud SQL |
| dbo.Tbl_DetalleFactura | Estado | bit | FrmFacturaciones.rdoActivoDetalle / rdoInactivoDetalle | RadioButton → bit |
| dbo.Tbl_Diseñadores | CodigoDiseñador | int | FrmDisenadores.txtCodigoDisenador | TextBox; validar conversión y rango; PK IDENTITY |
| dbo.Tbl_Diseñadores | NombreDiseñador | varchar(45) | FrmDisenadores.txtNombreDisenador | TextBox; respetar longitud SQL |
| dbo.Tbl_Diseñadores | Edad | int | FrmDisenadores.txtEdad | TextBox; validar conversión y rango |
| dbo.Tbl_Diseñadores | Especialidad | varchar(45) | FrmDisenadores.txtEspecialidad | TextBox; respetar longitud SQL |
| dbo.Tbl_Diseñadores | Telefono | int | FrmDisenadores.txtTelefono | TextBox; validar conversión y rango |
| dbo.Tbl_Diseñadores | Correo | varchar(150) | FrmDisenadores.txtCorreo | TextBox; respetar longitud SQL |
| dbo.Tbl_Diseñadores | Estado | bit | FrmDisenadores.rdoActivo / rdoInactivo | RadioButton → bit |
| dbo.Tbl_Diseños | CodigoDiseño | int | FrmDisenos.txtCodigoDiseno | TextBox; validar conversión y rango; PK IDENTITY |
| dbo.Tbl_Diseños | CodigoCliente | int | FrmDisenos.cmbCodigoCliente | ComboBox; FK → dbo.Tbl_Clientes.CodigoCliente |
| dbo.Tbl_Diseños | CodigoDiseñador | int | FrmDisenos.cmbCodigoDisenador | ComboBox; FK → dbo.Tbl_Diseñadores.CodigoDiseñador |
| dbo.Tbl_Diseños | NombreDiseño | varchar(45) | FrmDisenos.txtNombreDiseno | TextBox; respetar longitud SQL |
| dbo.Tbl_Diseños | TipoDiseño | varchar(45) | FrmDisenos.txtTipoDiseno | TextBox; respetar longitud SQL |
| dbo.Tbl_Diseños | Descripcion | varchar(150) | FrmDisenos.txtDescripcion | TextBox; respetar longitud SQL |
| dbo.Tbl_Diseños | RangoDiseño | varchar(45) | FrmDisenos.txtRangoDiseno | TextBox; respetar longitud SQL |
| dbo.Tbl_Diseños | FechaCreacion | datetime | FrmDisenos.dtpFechaCreacion | DateTimePicker |
| dbo.Tbl_Diseños | Estado | bit | FrmDisenos.rdoActivo / rdoInactivo | RadioButton → bit |
| dbo.Tbl_Facturacion | CodigoFacturacion | int | FrmFacturaciones.txtCodigoFacturacion | TextBox; validar conversión y rango; PK IDENTITY |
| dbo.Tbl_Facturacion | CodigoOrdenTrabajo | int | FrmFacturaciones.cmbCodigoOrdenTrabajo | ComboBox; FK → dbo.Tbl_OrdenesDeTrabajo.CodigoOrdenTrabajo |
| dbo.Tbl_Facturacion | NoFactura | int | FrmFacturaciones.txtNoFactura | TextBox; validar conversión y rango |
| dbo.Tbl_Facturacion | FechaDeEntrega | datetime | FrmFacturaciones.dtpFechaDeEntrega | DateTimePicker |
| dbo.Tbl_Facturacion | Subtotal | decimal(10,2) | FrmFacturaciones.txtSubtotal | TextBox; validar conversión y rango |
| dbo.Tbl_Facturacion | Impuesto | decimal(10,2) | FrmFacturaciones.txtImpuesto | TextBox; validar conversión y rango |
| dbo.Tbl_Facturacion | TotalPagar | decimal(10,2) | FrmFacturaciones.txtTotalPagar | TextBox; validar conversión y rango |
| dbo.Tbl_Facturacion | Estado | bit | FrmFacturaciones.rdoActivo / rdoInactivo | RadioButton → bit |
| dbo.Tbl_Inventarios | CodigoInventario | int | FrmInventarios.txtCodigoInventario | TextBox; validar conversión y rango; PK IDENTITY |
| dbo.Tbl_Inventarios | CodigoSucursal | int | FrmInventarios.cmbCodigoSucursal | ComboBox; FK → dbo.Tbl_Sucursales.CodigoSucursal |
| dbo.Tbl_Inventarios | CodigoMaterial | int | FrmInventarios.cmbCodigoMaterial | ComboBox; FK → dbo.Tbl_Materiales.CodigoMaterial |
| dbo.Tbl_Inventarios | NombreProducto | varchar(45) | FrmInventarios.txtNombreProducto | TextBox; respetar longitud SQL |
| dbo.Tbl_Inventarios | TipoProducto | varchar(45) | FrmInventarios.txtTipoProducto | TextBox; respetar longitud SQL |
| dbo.Tbl_Inventarios | Stock | int | FrmInventarios.txtStock | TextBox; validar conversión y rango |
| dbo.Tbl_Inventarios | PrecioCompra | decimal(10,2) | FrmInventarios.txtPrecioCompra | TextBox; validar conversión y rango |
| dbo.Tbl_Inventarios | FechaAlmacenamiento | datetime | FrmInventarios.dtpFechaAlmacenamiento | DateTimePicker |
| dbo.Tbl_Inventarios | Estado | bit | FrmInventarios.rdoActivo / rdoInactivo | RadioButton → bit |
| dbo.Tbl_Materiales | CodigoMaterial | int | FrmMateriales.txtCodigoMaterial | TextBox; validar conversión y rango; PK IDENTITY |
| dbo.Tbl_Materiales | CodigoOrdenTrabajo | int | FrmMateriales.cmbCodigoOrdenTrabajo | ComboBox; FK → dbo.Tbl_OrdenesDeTrabajo.CodigoOrdenTrabajo |
| dbo.Tbl_Materiales | NombreMaterial | varchar(45) | FrmMateriales.txtNombreMaterial | TextBox; respetar longitud SQL |
| dbo.Tbl_Materiales | TipoDeMaterial | varchar(45) | FrmMateriales.txtTipoDeMaterial | TextBox; respetar longitud SQL |
| dbo.Tbl_Materiales | UnidadMedida | varchar(45) | FrmMateriales.txtUnidadMedida | TextBox; respetar longitud SQL |
| dbo.Tbl_Materiales | CategoriaMaterial | varchar(45) | FrmMateriales.txtCategoriaMaterial | TextBox; respetar longitud SQL |
| dbo.Tbl_Materiales | CostoMaterial | decimal(10,2) | FrmMateriales.txtCostoMaterial | TextBox; validar conversión y rango |
| dbo.Tbl_Materiales | Estado | bit | FrmMateriales.rdoActivo / rdoInactivo | RadioButton → bit |
| dbo.Tbl_OrdenesDeTrabajo | CodigoOrdenTrabajo | int | FrmOrdenesTrabajo.txtCodigoOrdenTrabajo | TextBox; validar conversión y rango; PK IDENTITY |
| dbo.Tbl_OrdenesDeTrabajo | CodigoSucursal | int | FrmOrdenesTrabajo.cmbCodigoSucursal | ComboBox; FK → dbo.Tbl_Sucursales.CodigoSucursal |
| dbo.Tbl_OrdenesDeTrabajo | CodigoTipoServicio | int | FrmOrdenesTrabajo.cmbCodigoTipoServicio | ComboBox; FK → dbo.Tbl_TipoDeServicio.CodigoTipoServicio |
| dbo.Tbl_OrdenesDeTrabajo | CodigoCotizacion | int | FrmOrdenesTrabajo.cmbCodigoCotizacion | ComboBox; FK → dbo.Tbl_Cotizaciones.CodigoCotizacion |
| dbo.Tbl_OrdenesDeTrabajo | CodigoDiseñador | int | FrmOrdenesTrabajo.cmbCodigoDisenador | ComboBox; FK → dbo.Tbl_Diseñadores.CodigoDiseñador |
| dbo.Tbl_OrdenesDeTrabajo | NombreOrdenTrabajo | varchar(100) | FrmOrdenesTrabajo.txtNombreOrdenTrabajo | TextBox; respetar longitud SQL |
| dbo.Tbl_OrdenesDeTrabajo | TipoDeOrden | varchar(100) | FrmOrdenesTrabajo.txtTipoDeOrden | TextBox; respetar longitud SQL |
| dbo.Tbl_OrdenesDeTrabajo | FechaInicio | datetime | FrmOrdenesTrabajo.dtpFechaInicio | DateTimePicker |
| dbo.Tbl_OrdenesDeTrabajo | FechaFinalizacion | datetime | FrmOrdenesTrabajo.dtpFechaFinalizacion | DateTimePicker |
| dbo.Tbl_OrdenesDeTrabajo | Descripcion | varchar(150) | FrmOrdenesTrabajo.txtDescripcion | TextBox; respetar longitud SQL |
| dbo.Tbl_OrdenesDeTrabajo | Estado | bit | FrmOrdenesTrabajo.rdoActivo / rdoInactivo | RadioButton → bit |
| dbo.Tbl_Proveedores | CodgioProveedor | int | FrmProveedores.txtCodgioProveedor | TextBox; validar conversión y rango; PK IDENTITY; nombre real; no renombrar por suposición |
| dbo.Tbl_Proveedores | NombreProveedor | varchar(45) | FrmProveedores.txtNombreProveedor | TextBox; respetar longitud SQL |
| dbo.Tbl_Proveedores | Telefono | int | FrmProveedores.txtTelefono | TextBox; validar conversión y rango |
| dbo.Tbl_Proveedores | Correo | varchar(150) | FrmProveedores.txtCorreo | TextBox; respetar longitud SQL |
| dbo.Tbl_Proveedores | TipoProveedor | varchar(45) | FrmProveedores.txtTipoProveedor | TextBox; respetar longitud SQL |
| dbo.Tbl_Proveedores | Direccion | varchar(150) | FrmProveedores.txtDireccion | TextBox; respetar longitud SQL |
| dbo.Tbl_Proveedores | Estado | bit | FrmProveedores.rdoActivo / rdoInactivo | RadioButton → bit |
| dbo.Tbl_Sucursales | CodigoSucursal | int | FrmSucursales.txtCodigoSucursal | TextBox; validar conversión y rango; PK IDENTITY |
| dbo.Tbl_Sucursales | NombreSucursal | varchar(45) | FrmSucursales.txtNombreSucursal | TextBox; respetar longitud SQL |
| dbo.Tbl_Sucursales | Direccion | varchar(150) | FrmSucursales.txtDireccion | TextBox; respetar longitud SQL |
| dbo.Tbl_Sucursales | Municipio | varchar(100) | FrmSucursales.txtMunicipio | TextBox; respetar longitud SQL |
| dbo.Tbl_Sucursales | Departamento | varchar(100) | FrmSucursales.txtDepartamento | TextBox; respetar longitud SQL |
| dbo.Tbl_Sucursales | Telefono | int | FrmSucursales.txtTelefono | TextBox; validar conversión y rango |
| dbo.Tbl_Sucursales | HorarioDeAtencion | time(7) | FrmSucursales.dtpHorarioDeAtencion | DateTimePicker; usar TimeOfDay |
| dbo.Tbl_Sucursales | Estado | bit | FrmSucursales.rdoActivo / rdoInactivo | RadioButton → bit |
| dbo.Tbl_TipoDeServicio | CodigoTipoServicio | int | FrmTipoServicio.txtCodigoTipoServicio | TextBox; validar conversión y rango; PK IDENTITY |
| dbo.Tbl_TipoDeServicio | NombreServicio | varchar(45) | FrmTipoServicio.txtNombreServicio | TextBox; respetar longitud SQL |
| dbo.Tbl_TipoDeServicio | CostoServicio | decimal(10,2) | FrmTipoServicio.txtCostoServicio | TextBox; validar conversión y rango |
| dbo.Tbl_TipoDeServicio | RecargoServicio | decimal(10,2) | FrmTipoServicio.txtRecargoServicio | TextBox; validar conversión y rango |
| dbo.Tbl_TipoDeServicio | TotalServicio | decimal(10,2) | FrmTipoServicio.txtTotalServicio | TextBox; validar conversión y rango |
| dbo.Tbl_TipoDeServicio | Descripcion | varchar(150) | FrmTipoServicio.txtDescripcion | TextBox; respetar longitud SQL |
| dbo.Tbl_TipoDeServicio | Estado | bit | FrmTipoServicio.rdoActivo / rdoInactivo | RadioButton → bit |
| dbo.Tbl_Usuarios | CodigoUsuario | int | FrmUsuarios.txtCodigoUsuario | TextBox; validar conversión y rango; PK IDENTITY |
| dbo.Tbl_Usuarios | CodigoSucursal | int | FrmUsuarios.cmbCodigoSucursal | ComboBox; FK → dbo.Tbl_Sucursales.CodigoSucursal |
| dbo.Tbl_Usuarios | NombreUsuario | varchar(45) | FrmUsuarios.txtNombreUsuario | TextBox; respetar longitud SQL |
| dbo.Tbl_Usuarios | Clave | varchar(255) | FrmUsuarios.txtClave | TextBox; respetar longitud SQL |
| dbo.Tbl_Usuarios | FechaCreacion | datetime | FrmUsuarios.dtpFechaCreacion | DateTimePicker |
| dbo.Tbl_Usuarios | TipoUsuario | varchar(45) | FrmUsuarios.cmbTipoUsuario | ComboBox; respetar longitud SQL |
| dbo.Tbl_Usuarios | Estado | bit | FrmUsuarios.rdoActivo / rdoInactivo | RadioButton → bit |

## Formularios independientes de detalle: diferencias
Estas correspondencias se basan en etiquetas y posición de controles; sus eventos contienen TODO. No se consideran enlaces funcionales comprobados.

| Tabla | Columna | Tipo | Control | Observación |
|---|---|---|---|---|
| Tbl_DetalleCompra | CodigoDetalleCompra | int | FrmDetalleCompra.txtCodigo | Etiqueta coincidente; PK |
| Tbl_DetalleCompra | CodigoCompra | int | FrmDetalleCompra.textBox1 | Según etiqueta y posición; ReadOnly; enlace funcional sin confirmar |
| Tbl_DetalleCompra | PrecioUnitario | decimal(10,2) | FrmDetalleCompra.numericUpDown3 | Según etiqueta y posición |
| Tbl_DetalleCompra | TipoDeCompra | varchar(45) | FrmDetalleCompra.comboBox1 | Según etiqueta y posición |
| Tbl_DetalleCompra | Subtotal | decimal(10,2) | FrmDetalleCompra.numericUpDown2 | Según etiqueta y posición |
| Tbl_DetalleCompra | DescuentoCompra | decimal(10,2) | FrmDetalleCompra.numericUpDown1 | Según etiqueta y posición |
| Tbl_DetalleCompra | Descripcion | varchar(150) | FrmDetalleCompra.txtSubtotal | Nombre contradice etiqueta |
| Tbl_DetalleCompra | Estado | bit | FrmDetalleCompra.radioButton1 / radioButton3 | Activo/Inactivo |
| Tbl_DetalleFactura | CodigoDetalleFactura | int | FrmDetalleFactura.txtCodigo | Etiqueta coincidente; PK |
| Tbl_DetalleFactura | CodigoFacturacion | int | FrmDetalleFactura.cmbTipoServicio | Según etiqueta y posición; nombre contradictorio; enlace funcional sin confirmar |
| Tbl_DetalleFactura | DescuentoAplicado | decimal(10,2) | FrmDetalleFactura.txtPrecioUnitario | Nombre contradice etiqueta |
| Tbl_DetalleFactura | Cantidad | int | FrmDetalleFactura.numericUpDown1 | Según etiqueta y posición |
| Tbl_DetalleFactura | Precio | decimal(10,2) | FrmDetalleFactura.numericUpDown2 | Según etiqueta y posición |
| Tbl_DetalleFactura | Descripcion | varchar(150) | FrmDetalleFactura.txtCantidad | Nombre contradice etiqueta |
| Tbl_DetalleFactura | Estado | bit | FrmDetalleFactura.radioButton1 / radioButton2 | Activo/Inactivo |

## Correcciones mínimas propuestas, sin aplicar
La revisión posterior al traslado confirmó cuatro capas .NET Framework 4.8, referencias sin ciclos, 144 archivos/referencias existentes y 18 pares cs/Designer más 17 resx. Las correspondencias de las 126 columnas se comprobaron contra los controles existentes y el esquema SQL previamente verificado, sin nueva consulta SQL ni ejecución de formularios.

- FrmDetalleCompra.txtSubtotal corresponde por etiqueta a Descripcion, pero tiene MaxLength=15 frente a varchar(150). FrmDetalleFactura.txtCantidad corresponde por etiqueta a Descripcion, pero tiene MaxLength=10. Diferencias documentadas, sin modificar el diseñador.
- Revisar rangos y precisión SQL de los NumericUpDown independientes de detalle antes de implementar su uso; no se ajustaron sus propiedades.

- Confirmar el destino de las FK en los formularios independientes de detalle antes de enlazar controles. Registrar nombres ambiguos; no renombrar ni modificar el diseñador en esta etapa.
- La cuadrícula FrmDetalleCompra incluye Material y Cantidad, que no son columnas de Tbl_DetalleCompra. FrmDetalleFactura incluye Tipo de servicio y Subtotal, ausentes de Tbl_DetalleFactura. Confirmar si serán proyecciones relacionadas o cálculos; no inventar columnas ni relaciones.
- Conservar CodgioProveedor y los nombres SQL con ñ.
- Mantener NIT nullable en Clientes y Cotizaciones; validar límites enteros y decimal(10,2), y longitudes varchar durante una futura etapa autorizada.
- Existen eventos con TODO y también código de operaciones ya presente en otros formularios. Esta inspección no implementó, ejecutó ni validó esas operaciones.
- Login/roles se conserva y su desarrollo permanece pendiente.
