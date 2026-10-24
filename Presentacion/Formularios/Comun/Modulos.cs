using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SistemaPublicidad.Formularios
{
    // Definición de cada apartado: columnas, resúmenes, filtros, formulario y propiedades de Entidad.
    public static partial class Modulos
    {
        const string SUC = "Sucursal Central,Sucursal Norte,Sucursal Sur,Sucursal Occidente";
        static readonly string[] Tend = { "+ 12 %", "+ 08 %", "+ 00 %", "+ 05 %" };

        static Tabla.Col[] Cols(string spec, bool extra = true)
        {
            var l = new List<Tabla.Col>(); if (extra) l.Add(new Tabla.Col("", 0, "chk"));
            foreach (var p in spec.Split(';')) { var a = p.Split(':'); l.Add(new Tabla.Col(a[0], float.Parse(a[1], CultureInfo.InvariantCulture), a[2], a.Length > 3)); }
            return l.ToArray();
        }
        static IEnumerable<string> Lineas(string d) { return d.Split('\n').Select(x => x.Trim()).Where(x => x != ""); }
        static string[][] Filas(string d) { return Lineas(d).Select(x => new[] { "" }.Concat(x.Split('|')).Concat(new[] { "" }).ToArray()).ToArray(); }
        static string[][] FilasDet(string d) { return Lineas(d).Select(x => x.Split('|')).ToArray(); }

        static ModuloCfg Def(string nombre, string icono, string[] st, string[] sv, string[] si, string cols, string filas, string[] filtros, string campos)
        {
            var c = new ModuloCfg { Nombre = nombre, Plural = nombre.ToLower(), Icono = icono, StatTit = st, StatVal = sv, StatIco = si, StatTend = Tend, Filtros = filtros, Campos = campos.Split(';') };
            c.Cols = Cols(cols); c.Filas = Filas(filas); c.Total = c.Filas.Length; return c;
        }
        static readonly string[] Ic = { "\U0001F465", "\U0001F464", "\U0001F552", "\U0001F4CA" };

        public static ModuloCfg Obtener(string nombre, string icono, int tab)
        {
            var c = new ModuloCfg { Nombre = nombre, Plural = nombre.ToLower(), Icono = icono, StatIco = Ic };
            ConfigurarTablaReal(c);
            c.Tab = tab; return c;
        }

        // Los rótulos y controles se definen a partir de las columnas del esquema aprobado.
        static void ConfigurarTablaReal(ModuloCfg c)
        {
            string columnas = "", propiedades = "", campos = "", columnasDetalle = "", propiedadesDetalle = "";
            switch (c.Nombre)
            {
                case "Usuarios":
                    c.Clave = "CodigoUsuario";
                    columnas = "Código:55:id:o;Sucursal:70:num;Usuario:130:texto:o;Fecha de creación:105:fecha:o;Tipo:100:badge:o;Estado:80:estado:o";
                    propiedades = "CodigoUsuario;CodigoSucursal;NombreUsuario;FechaCreacion;TipoUsuario;Estado";
                    campos = "Código sucursal|CodigoSucursal:n;Nombre de usuario|NombreUsuario:t;Clave|Clave:t;Fecha de creación|FechaCreacion:f;Tipo de usuario|TipoUsuario:c=Administrador,Diseñador,Operador;Estado|Estado:b";
                    break;
                case "Clientes":
                    c.Clave = "CodigoCliente";
                    columnas = "Código:55:id:o;Nombre:135:texto:o;Dirección:170:texto;DPI:85:texto:o;Edad:55:num:o;NIT:85:texto;Teléfono:90:texto:o;Estado:80:estado:o";
                    propiedades = "CodigoCliente;NombreCliente;Direccion;DPI;Edad;NIT;Telefono;Estado";
                    campos = "Nombre del cliente|NombreCliente:t;Dirección|Direccion:t;DPI|DPI:n;Edad|Edad:n;NIT (opcional)|NIT:ni;Teléfono|Telefono:n;Estado|Estado:b";
                    break;
                case "Cotizaciones":
                    c.Clave = "CodigoCotizacion";
                    columnas = "Código:48:id:o;Tipo servicio:70:num;Sucursal:65:num;Cliente:65:num;Cotizador:105:texto;NIT:70:texto;Dirección:115:texto;Emisión:82:texto:o;Descripción:115:texto;Cantidad:60:num:o;Precio:70:num:o;Subtotal:75:num:o;Total:75:num:o;Estado:70:estado:o";
                    propiedades = "CodigoCotizacion;CodigoTipoServicio;CodigoSucursal;CodigoCliente;NombreCotizador;NIT;DireccionCotizador;FechaEmision;Descripcion;Cantidad;Precio;Subtotal;Total;Estado";
                    campos = "Código tipo de servicio|CodigoTipoServicio:n;Código sucursal|CodigoSucursal:n;Código cliente|CodigoCliente:n;Nombre del cotizador|NombreCotizador:t;NIT (opcional)|NIT:ni;Dirección del cotizador|DireccionCotizador:t;Fecha de emisión|FechaEmision:f;Descripción|Descripcion:t;Cantidad|Cantidad:n;Precio|Precio:m;Subtotal|Subtotal:m;Total|Total:m;Estado|Estado:b";
                    break;
                case "Tipo de Servicio":
                    c.Clave = "CodigoTipoServicio";
                    columnas = "Código:60:id:o;Servicio:150:texto:o;Costo:90:num:o;Recargo:90:num:o;Total:90:num:o;Descripción:220:texto;Estado:80:estado:o";
                    propiedades = "CodigoTipoServicio;NombreServicio;CostoServicio;RecargoServicio;TotalServicio;Descripcion;Estado";
                    campos = "Nombre del servicio|NombreServicio:t;Costo|CostoServicio:m;Recargo|RecargoServicio:m;Total|TotalServicio:m;Descripción|Descripcion:t;Estado|Estado:b";
                    break;
                case "Materiales":
                    c.Clave = "CodigoMaterial";
                    columnas = "Código:60:id:o;Orden de trabajo:80:num;Material:125:texto:o;Tipo:95:texto:o;Unidad:90:texto;Categoría:110:texto:o;Costo:90:num:o;Estado:80:estado:o";
                    propiedades = "CodigoMaterial;CodigoOrdenTrabajo;NombreMaterial;TipoDeMaterial;UnidadMedida;CategoriaMaterial;CostoMaterial;Estado";
                    campos = "Código de orden de trabajo|CodigoOrdenTrabajo:n;Nombre del material|NombreMaterial:t;Tipo de material|TipoDeMaterial:t;Unidad de medida|UnidadMedida:t;Categoría|CategoriaMaterial:t;Costo|CostoMaterial:m;Estado|Estado:b";
                    break;
                case "Diseños":
                    c.Clave = "CodigoDiseño";
                    columnas = "Código:60:id:o;Cliente:65:num;Diseñador:70:num;Nombre:120:texto:o;Tipo:90:texto:o;Descripción:125:texto;Rango:95:texto;Fecha de creación:95:texto:o;Estado:80:estado:o";
                    propiedades = "CodigoDiseño;CodigoCliente;CodigoDiseñador;NombreDiseño;TipoDiseño;Descripcion;RangoDiseño;FechaCreacion;Estado";
                    campos = "Código de cliente|CodigoCliente:n;Código de diseñador|CodigoDiseñador:n;Nombre del diseño|NombreDiseño:t;Tipo de diseño|TipoDiseño:t;Descripción|Descripcion:t;Rango|RangoDiseño:t;Fecha de creación|FechaCreacion:f;Estado|Estado:b";
                    break;
                case "Diseñadores":
                    c.Clave = "CodigoDiseñador";
                    columnas = "Código:60:id:o;Nombre:130:texto:o;Edad:55:num:o;Especialidad:115:texto:o;Teléfono:90:texto;Correo:170:texto;Estado:80:estado:o";
                    propiedades = "CodigoDiseñador;NombreDiseñador;Edad;Especialidad;Telefono;Correo;Estado";
                    campos = "Nombre del diseñador|NombreDiseñador:t;Edad|Edad:n;Especialidad|Especialidad:t;Teléfono|Telefono:n;Correo|Correo:t;Estado|Estado:b";
                    break;
                case "Órdenes de Trabajo":
                    c.Clave = "CodigoOrdenTrabajo";
                    columnas = "Código:55:id:o;Sucursal:65:num;Servicio:65:num;Cotización:70:num;Diseñador:70:num;Nombre:120:texto:o;Tipo:100:texto:o;Inicio:82:texto:o;Finalización:82:texto:o;Descripción:135:texto;Estado:80:estado:o";
                    propiedades = "CodigoOrdenTrabajo;CodigoSucursal;CodigoTipoServicio;CodigoCotizacion;CodigoDiseñador;NombreOrdenTrabajo;TipoDeOrden;FechaInicio;FechaFinalizacion;Descripcion;Estado";
                    campos = "Código de sucursal|CodigoSucursal:n;Código tipo de servicio|CodigoTipoServicio:n;Código de cotización|CodigoCotizacion:n;Código de diseñador|CodigoDiseñador:n;Nombre de la orden|NombreOrdenTrabajo:t;Tipo de orden|TipoDeOrden:t;Fecha de inicio|FechaInicio:f;Fecha de finalización|FechaFinalizacion:f;Descripción|Descripcion:t;Estado|Estado:b";
                    break;
                case "Facturaciones":
                    c.Clave = "CodigoFacturacion";
                    columnas = "Código:60:id:o;Orden de trabajo:85:num;No. factura:85:num:o;Fecha de entrega:100:texto:o;Subtotal:100:num:o;Impuesto:90:num:o;Total a pagar:110:num:o;Estado:80:estado:o";
                    propiedades = "CodigoFacturacion;CodigoOrdenTrabajo;NoFactura;FechaDeEntrega;Subtotal;Impuesto;TotalPagar;Estado";
                    campos = "Código de orden de trabajo|CodigoOrdenTrabajo:n;Número de factura|NoFactura:n;Fecha de entrega|FechaDeEntrega:f;Subtotal|Subtotal:m;Impuesto|Impuesto:m;Total a pagar|TotalPagar:m;Estado|Estado:b";
                    c.TituloDet = "Detalle de la factura";
                    columnasDetalle = "Código detalle:65:id:o;Código factura:75:num:o;Cantidad:70:num:o;Precio:90:num:o;Descripción:175:texto;Descuento:90:num:o;Estado:80:estado:o";
                    propiedadesDetalle = "CodigoDetalleFactura;CodigoFacturacion;Cantidad;Precio;Descripcion;DescuentoAplicado;Estado";
                    break;
                case "Compras":
                    c.Clave = "CodigoCompra";
                    columnas = "Código:60:id:o;Proveedor:75:num;Material:75:num;Cantidad:75:num:o;Total:95:num:o;Fecha de compra:100:texto:o;Fecha de entrega:100:texto:o;Estado:80:estado:o";
                    propiedades = "CodigoCompra;CodigoProveedor;CodigoMaterial;CantidadComprada;TotalCompra;FechaCompra;FechaEntrega;Estado";
                    campos = "Código de proveedor|CodigoProveedor:n;Código de material|CodigoMaterial:n;Cantidad comprada|CantidadComprada:n;Total de compra|TotalCompra:m;Fecha de compra|FechaCompra:f;Fecha de entrega|FechaEntrega:f;Estado|Estado:b";
                    c.TituloDet = "Detalle de la compra";
                    columnasDetalle = "Código detalle:65:id:o;Código compra:75:num:o;Tipo:90:texto:o;Descripción:165:texto;Precio unitario:95:num:o;Subtotal:95:num:o;Descuento:90:num:o;Estado:80:estado:o";
                    propiedadesDetalle = "CodigoDetalleCompra;CodigoCompra;TipoDeCompra;Descripcion;PrecioUnitario;Subtotal;DescuentoCompra;Estado";
                    break;
                case "Sucursales":
                    c.Clave = "CodigoSucursal";
                    columnas = "Código:60:id:o;Sucursal:135:texto:o;Dirección:155:texto;Municipio:100:texto:o;Departamento:100:texto:o;Teléfono:90:texto;Horario:90:texto;Estado:80:estado:o";
                    propiedades = "CodigoSucursal;NombreSucursal;Direccion;Municipio;Departamento;Telefono;HorarioDeAtencion;Estado";
                    campos = "Nombre de sucursal|NombreSucursal:t;Dirección|Direccion:t;Municipio|Municipio:t;Departamento|Departamento:t;Teléfono|Telefono:n;Horario de atención|HorarioDeAtencion:h;Estado|Estado:b";
                    break;
                case "Proveedores":
                    c.Clave = "CodgioProveedor";
                    columnas = "Código:60:id:o;Proveedor:145:texto:o;Teléfono:95:texto;Correo:170:texto;Tipo:110:texto:o;Dirección:175:texto;Estado:80:estado:o";
                    propiedades = "CodgioProveedor;NombreProveedor;Telefono;Correo;TipoProveedor;Direccion;Estado";
                    campos = "Nombre del proveedor|NombreProveedor:t;Teléfono|Telefono:n;Correo|Correo:t;Tipo de proveedor|TipoProveedor:t;Dirección|Direccion:t;Estado|Estado:b";
                    break;
                case "Inventarios":
                    c.Clave = "CodigoInventario";
                    columnas = "Código:60:id:o;Sucursal:70:num;Material:70:num;Producto:135:texto:o;Tipo:100:texto:o;Stock:70:num:o;Precio compra:100:num:o;Almacenamiento:105:texto:o;Estado:80:estado:o";
                    propiedades = "CodigoInventario;CodigoSucursal;CodigoMaterial;NombreProducto;TipoProducto;Stock;PrecioCompra;FechaAlmacenamiento;Estado";
                    campos = "Código de sucursal|CodigoSucursal:n;Código de material|CodigoMaterial:n;Nombre del producto|NombreProducto:t;Tipo de producto|TipoProducto:t;Stock|Stock:n;Precio de compra|PrecioCompra:m;Fecha de almacenamiento|FechaAlmacenamiento:f;Estado|Estado:b";
                    break;
                default: return;
            }

            c.ColumnasPropiedades = propiedades.Split(';');
            c.Campos = campos.Split(';');
            c.Cols = Cols(columnas);
            c.Filas = new string[0][];
            c.Total = 0;
            c.Tabs = new[] { "Consultar", "Gestionar", "Resumen" };
            if (columnasDetalle != "")
            {
                c.ColsDet = Cols(columnasDetalle, false);
                c.ColumnasDetallePropiedades = propiedadesDetalle.Split(';');
                c.Detalle = new Dictionary<string, string[][]>();
                c.DetalleSoloLectura = true;
            }
            c.Filtros = new string[0];
            c.StatTit = new[] { "Total", "Activos", "Inactivos", "Registros" };
            c.StatVal = new[] { "0", "0", "0", "0" };
            c.StatTend = new[] { "", "", "", "" };
            c.StatIco = Ic;
        }
    }
}
