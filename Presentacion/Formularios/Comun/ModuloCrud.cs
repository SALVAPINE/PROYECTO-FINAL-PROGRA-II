using System;
using System.Collections.Generic;
using System.Linq;
using Entidad;
using Negocio;

namespace SistemaPublicidad.Formularios
{
    /// <summary>
    /// Enruta las operaciones del formulario genérico a la capa de Negocio.
    /// La Presentación no abre conexiones ni ejecuta SQL.
    /// </summary>
    internal static class ModuloCrud
    {
        internal sealed class Opcion
        {
            public int Codigo;
            public string Texto;
            public Opcion(int codigo, string texto) { Codigo = codigo; Texto = texto; }
        }

        public static bool EsRelacion(string propiedad)
        {
            return new[] { "CodigoSucursal", "CodigoCliente", "CodigoTipoServicio", "CodigoDiseñador",
                "CodigoOrdenTrabajo", "CodigoCotizacion", "CodigoMaterial", "CodigoProveedor" }.Contains(propiedad);
        }

        public static List<Opcion> Opciones(string propiedad)
        {
            switch (propiedad)
            {
                case "CodigoSucursal": return new SucursalNegocio().Listar().Select(x => new Opcion(x.CodigoSucursal, x.NombreSucursal)).ToList();
                case "CodigoCliente": return new ClienteNegocio().Buscar(string.Empty, "Todos").Select(x => new Opcion(x.CodigoCliente, x.NombreCliente)).ToList();
                case "CodigoTipoServicio": return new TipoServicioNegocio().Listar().Select(x => new Opcion(x.CodigoTipoServicio, x.NombreServicio)).ToList();
                case "CodigoDiseñador": return new DisenadorNegocio().Listar().Select(x => new Opcion(x.CodigoDiseñador, x.NombreDiseñador)).ToList();
                case "CodigoOrdenTrabajo": return new OrdenTrabajoNegocio().Listar().Select(x => new Opcion(x.CodigoOrdenTrabajo, x.NombreOrdenTrabajo)).ToList();
                case "CodigoCotizacion": return new CotizacionNegocio().Listar().Select(x => new Opcion(x.CodigoCotizacion, "Cotización " + x.CodigoCotizacion)).ToList();
                case "CodigoMaterial": return new MaterialNegocio().Listar().Select(x => new Opcion(x.CodigoMaterial, x.NombreMaterial)).ToList();
                case "CodigoProveedor": return new ProveedorNegocio().Listar().Select(x => new Opcion(x.CodgioProveedor, x.NombreProveedor)).ToList();
                default: return new List<Opcion>();
            }
        }

        public static List<object> Listar(string modulo)
        {
            switch (modulo)
            {
                case "Usuarios": return new UsuarioNegocio().Listar().Cast<object>().ToList();
                case "Clientes": return new ClienteNegocio().Buscar(string.Empty, "Todos").Cast<object>().ToList();
                case "Cotizaciones": return new CotizacionNegocio().Listar().Cast<object>().ToList();
                case "Tipo de Servicio": return new TipoServicioNegocio().Listar().Cast<object>().ToList();
                case "Materiales": return new MaterialNegocio().Listar().Cast<object>().ToList();
                case "Diseños": return new DisenoNegocio().Listar().Cast<object>().ToList();
                case "Diseñadores": return new DisenadorNegocio().Listar().Cast<object>().ToList();
                case "Órdenes de Trabajo": return new OrdenTrabajoNegocio().Listar().Cast<object>().ToList();
                case "Facturaciones": return new FacturaNegocio().Listar().Cast<object>().ToList();
                case "Compras": return new CompraNegocio().Listar().Cast<object>().ToList();
                case "Sucursales": return new SucursalNegocio().Listar().Cast<object>().ToList();
                case "Proveedores": return new ProveedorNegocio().Listar().Cast<object>().ToList();
                case "Inventarios": return new InventarioNegocio().Listar().Cast<object>().ToList();
                default: return new List<object>();
            }
        }

        public static List<object> ListarDetalles(string modulo)
        {
            switch (modulo)
            {
                case "Compras": return new DetalleCompraNegocio().Listar().Cast<object>().ToList();
                case "Facturaciones": return new DetalleFacturaNegocio().Listar().Cast<object>().ToList();
                default: return new List<object>();
            }
        }

        /// <summary>Obtiene los nombres de columnas de la tabla real sin abrir conexiones en Presentación.</summary>
        public static List<string> ListarColumnasBaseDatos(string modulo, bool detalle)
        {
            string tabla;
            if (detalle)
            {
                switch (modulo)
                {
                    case "Compras": tabla = "Tbl_DetalleCompra"; break;
                    case "Facturaciones": tabla = "Tbl_DetalleFactura"; break;
                    default: throw new ArgumentException("El módulo no tiene una tabla de detalle.", "modulo");
                }
            }
            else
            {
                switch (modulo)
                {
                    case "Usuarios": tabla = "Tbl_Usuarios"; break;
                    case "Clientes": tabla = "Tbl_Clientes"; break;
                    case "Cotizaciones": tabla = "Tbl_Cotizaciones"; break;
                    case "Tipo de Servicio": tabla = "Tbl_TipoDeServicio"; break;
                    case "Materiales": tabla = "Tbl_Materiales"; break;
                    case "Diseños": tabla = "Tbl_Diseños"; break;
                    case "Diseñadores": tabla = "Tbl_Diseñadores"; break;
                    case "Órdenes de Trabajo": tabla = "Tbl_OrdenesDeTrabajo"; break;
                    case "Facturaciones": tabla = "Tbl_Facturacion"; break;
                    case "Compras": tabla = "Tbl_Compras"; break;
                    case "Sucursales": tabla = "Tbl_Sucursales"; break;
                    case "Proveedores": tabla = "Tbl_Proveedores"; break;
                    case "Inventarios": tabla = "Tbl_Inventarios"; break;
                    default: throw new ArgumentException("El módulo no tiene una tabla asignada.", "modulo");
                }
            }

            return new EsquemaNegocio().ListarColumnas(tabla);
        }

        public static Type TipoEntidad(string modulo)
        {
            switch (modulo)
            {
                case "Usuarios": return typeof(Usuario);
                case "Clientes": return typeof(Cliente);
                case "Cotizaciones": return typeof(Cotizacion);
                case "Tipo de Servicio": return typeof(TipoServicio);
                case "Materiales": return typeof(Material);
                case "Diseños": return typeof(Diseno);
                case "Diseñadores": return typeof(Disenador);
                case "Órdenes de Trabajo": return typeof(OrdenTrabajo);
                case "Facturaciones": return typeof(Factura);
                case "Compras": return typeof(Compra);
                case "Sucursales": return typeof(Sucursal);
                case "Proveedores": return typeof(Proveedor);
                case "Inventarios": return typeof(Inventario);
                default: throw new ArgumentException("El módulo no tiene una tabla asignada.", "modulo");
            }
        }

        public static void Guardar(string modulo, object entidad, bool editar)
        {
            switch (modulo)
            {
                case "Usuarios": if (editar) new UsuarioNegocio().Actualizar((Usuario)entidad); else new UsuarioNegocio().Insertar((Usuario)entidad); break;
                case "Clientes": if (editar) new ClienteNegocio().Editar((Cliente)entidad); else new ClienteNegocio().Agregar((Cliente)entidad); break;
                case "Cotizaciones": if (editar) new CotizacionNegocio().Actualizar((Cotizacion)entidad); else new CotizacionNegocio().Insertar((Cotizacion)entidad); break;
                case "Tipo de Servicio": if (editar) new TipoServicioNegocio().Actualizar((TipoServicio)entidad); else new TipoServicioNegocio().Insertar((TipoServicio)entidad); break;
                case "Materiales": if (editar) new MaterialNegocio().Actualizar((Material)entidad); else new MaterialNegocio().Insertar((Material)entidad); break;
                case "Diseños": if (editar) new DisenoNegocio().Actualizar((Diseno)entidad); else new DisenoNegocio().Insertar((Diseno)entidad); break;
                case "Diseñadores": if (editar) new DisenadorNegocio().Actualizar((Disenador)entidad); else new DisenadorNegocio().Insertar((Disenador)entidad); break;
                case "Órdenes de Trabajo": if (editar) new OrdenTrabajoNegocio().Actualizar((OrdenTrabajo)entidad); else new OrdenTrabajoNegocio().Insertar((OrdenTrabajo)entidad); break;
                case "Facturaciones": if (editar) new FacturaNegocio().Actualizar((Factura)entidad); else new FacturaNegocio().Insertar((Factura)entidad); break;
                case "Compras": if (editar) new CompraNegocio().Actualizar((Compra)entidad); else new CompraNegocio().Insertar((Compra)entidad); break;
                case "Sucursales": if (editar) new SucursalNegocio().Actualizar((Sucursal)entidad); else new SucursalNegocio().Insertar((Sucursal)entidad); break;
                case "Proveedores": if (editar) new ProveedorNegocio().Actualizar((Proveedor)entidad); else new ProveedorNegocio().Insertar((Proveedor)entidad); break;
                case "Inventarios": if (editar) new InventarioNegocio().Actualizar((Inventario)entidad); else new InventarioNegocio().Insertar((Inventario)entidad); break;
                default: throw new ArgumentException("El módulo no tiene una operación CRUD asignada.", "modulo");
            }
        }

        /// <summary>Guarda la factura y devuelve su código para enlazar el detalle.</summary>
        public static int GuardarFactura(Factura factura, bool editar)
        {
            var negocio = new FacturaNegocio();
            if (editar)
            {
                negocio.Actualizar(factura);
                return factura.CodigoFacturacion;
            }
            return negocio.InsertarYObtenerCodigo(factura);
        }

        public static int GuardarFacturaConDetalle(Factura factura, DetalleFactura detalle)
        {
            return new FacturaNegocio().InsertarConDetalle(factura, detalle);
        }

        public static int ActualizarFacturaConDetalle(Factura factura, DetalleFactura detalle)
        {
            return new FacturaNegocio().ActualizarConDetalle(factura, detalle);
        }

        public static int ActualizarFacturaConNuevoDetalle(Factura factura, DetalleFactura detalle)
        {
            return new FacturaNegocio().ActualizarConNuevoDetalle(factura, detalle);
        }

        /// <summary>Guarda el detalle asociado mediante la capa de Negocio.</summary>
        public static void GuardarDetalleFactura(DetalleFactura detalle, bool editar)
        {
            var negocio = new DetalleFacturaNegocio();
            if (editar) negocio.Actualizar(detalle);
            else negocio.Insertar(detalle);
        }

        /// <summary>Guarda la compra y devuelve su código para enlazar el detalle.</summary>
        public static int GuardarCompra(Compra compra, bool editar)
        {
            var negocio = new CompraNegocio();
            if (editar)
            {
                negocio.Actualizar(compra);
                return compra.CodigoCompra;
            }
            return negocio.InsertarYObtenerCodigo(compra);
        }

        /// <summary>Guarda un encabezado nuevo junto con su detalle en una transacción.</summary>
        public static int GuardarCompraConDetalle(Compra compra, DetalleCompra detalle)
        {
            return new CompraNegocio().InsertarConDetalle(compra, detalle);
        }

        public static int ActualizarCompraConDetalle(Compra compra, DetalleCompra detalle)
        {
            return new DetalleCompraNegocio().ActualizarCompraConDetalle(compra, detalle);
        }

        public static List<DetalleCompra> BuscarDetallesCompra(string texto)
        {
            return new DetalleCompraNegocio().Buscar(texto, "Todos");
        }

        public static List<DetalleCompra> BuscarDetallesCompra(int codigoCompra, string texto)
        {
            return new DetalleCompraNegocio().BuscarPorCompra(codigoCompra, texto);
        }

        public static void EliminarDetalleCompra(int codigoDetalle, int codigoCompra)
        {
            new DetalleCompraNegocio().Eliminar(codigoDetalle, codigoCompra);
        }

        public static List<DetalleFactura> BuscarDetallesFactura(string texto)
        {
            return new DetalleFacturaNegocio().Buscar(texto, "Todos");
        }

        public static List<DetalleFactura> BuscarDetallesFactura(int codigoFacturacion, string texto)
        {
            return new DetalleFacturaNegocio().BuscarPorFactura(codigoFacturacion, texto);
        }

        public static void EliminarDetalleFactura(int codigoDetalle, int codigoFacturacion)
        {
            new DetalleFacturaNegocio().Eliminar(codigoDetalle, codigoFacturacion);
        }

        /// <summary>Guarda el detalle asociado mediante la capa de Negocio.</summary>
        public static void GuardarDetalleCompra(DetalleCompra detalle, bool editar)
        {
            var negocio = new DetalleCompraNegocio();
            if (editar) negocio.Actualizar(detalle);
            else negocio.Insertar(detalle);
        }

        public static void Eliminar(string modulo, int codigo)
        {
            switch (modulo)
            {
                case "Usuarios": new UsuarioNegocio().Eliminar(codigo); break;
                case "Clientes": new ClienteNegocio().Eliminar(codigo); break;
                case "Cotizaciones": new CotizacionNegocio().Eliminar(codigo); break;
                case "Tipo de Servicio": new TipoServicioNegocio().Eliminar(codigo); break;
                case "Materiales": new MaterialNegocio().Eliminar(codigo); break;
                case "Diseños": new DisenoNegocio().Eliminar(codigo); break;
                case "Diseñadores": new DisenadorNegocio().Eliminar(codigo); break;
                case "Órdenes de Trabajo": new OrdenTrabajoNegocio().Eliminar(codigo); break;
                case "Facturaciones": new FacturaNegocio().Eliminar(codigo); break;
                case "Compras": new CompraNegocio().Eliminar(codigo); break;
                case "Sucursales": new SucursalNegocio().Eliminar(codigo); break;
                case "Proveedores": new ProveedorNegocio().Eliminar(codigo); break;
                case "Inventarios": new InventarioNegocio().Eliminar(codigo); break;
                default: throw new ArgumentException("El módulo no tiene una operación CRUD asignada.", "modulo");
            }
        }
    }
}
