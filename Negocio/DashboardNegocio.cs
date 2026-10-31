using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Calcula los datos del dashboard de Inicio a partir de lo que devuelve la capa de datos.
    /// Mientras la capa de datos no devuelva registros, todos los valores quedan en cero.
    /// </summary>
    public class DashboardNegocio
    {
        private readonly UsuarioDatos usuarios = new UsuarioDatos();
        private readonly ClienteDatos clientes = new ClienteDatos();
        private readonly CotizacionDatos cotizaciones = new CotizacionDatos();
        private readonly DisenoDatos disenos = new DisenoDatos();
        private readonly OrdenTrabajoDatos ordenes = new OrdenTrabajoDatos();
        private readonly FacturaDatos facturas = new FacturaDatos();
        private readonly CompraDatos compras = new CompraDatos();
        private readonly InventarioDatos inventarios = new InventarioDatos();

        public ResumenDashboard ObtenerResumen()
        {
            var permisos = new HashSet<string>(new RolNegocio().ListarModulosPermitidos(SesionActual.Rol), StringComparer.OrdinalIgnoreCase);
            List<Usuario> listaUsuarios = permisos.Contains("Usuarios") ? usuarios.Listar() : new List<Usuario>();
            List<Cliente> listaClientes = permisos.Contains("Clientes") ? clientes.Listar() : new List<Cliente>();
            List<Cotizacion> listaCotizaciones = permisos.Contains("Cotizaciones") ? cotizaciones.Listar() : new List<Cotizacion>();
            List<Diseno> listaDisenos = permisos.Contains("Diseños") ? disenos.Listar() : new List<Diseno>();
            List<OrdenTrabajo> listaOrdenes = permisos.Contains("Órdenes de Trabajo") ? ordenes.Listar() : new List<OrdenTrabajo>();
            List<Factura> listaFacturas = permisos.Contains("Facturaciones") ? facturas.Listar() : new List<Factura>();
            List<Compra> listaCompras = permisos.Contains("Compras") ? compras.Listar() : new List<Compra>();
            List<Inventario> listaInventarios = permisos.Contains("Inventarios") ? inventarios.Listar() : new List<Inventario>();

            ResumenDashboard r = new ResumenDashboard();
            r.TotalUsuarios = listaUsuarios.Count;
            r.UsuariosActivos = listaUsuarios.Count(u => u.Estado);
            r.TotalClientes = listaClientes.Count;
            r.TotalCotizaciones = listaCotizaciones.Count;
            r.MontoTotalCotizado = listaCotizaciones.Sum(c => c.Total);
            r.TotalDisenos = listaDisenos.Count;
            r.DisenosActivos = listaDisenos.Count(d => d.Estado);
            r.TotalOrdenesTrabajo = listaOrdenes.Count;
            r.OrdenesTrabajoActivas = listaOrdenes.Count(o => o.Estado);
            r.TotalFacturas = listaFacturas.Count;
            r.FacturasActivas = listaFacturas.Count(f => f.Estado);
            r.MontoTotalFacturado = listaFacturas.Sum(f => f.TotalPagar);
            r.TotalCompras = listaCompras.Count;
            r.TotalInventarios = listaInventarios.Count;
            r.InventariosActivos = listaInventarios.Count(i => i.Estado);

            r.CotizacionesPorEstado = Contar(listaCotizaciones.Select(c => c.Estado ? "Activo" : "Inactivo"), new[] { "Activo", "Inactivo" });
            r.ClientesPorEstado = Contar(listaClientes.Select(c => c.Estado ? "Activo" : "Inactivo"), new[] { "Activo", "Inactivo" });
            r.UsuariosPorRol = Contar(listaUsuarios.Select(u => u.TipoUsuario), new[] { "Administrador", "Diseñador", "Operador" });
            r.MontoPorMes = MontoUltimosMeses(listaCotizaciones, 6);
            r.DisenosPorMes = ContarPorMes(listaDisenos, 6, d => d.FechaCreacion);
            r.FacturadoPorMes = MontoPorMes(listaFacturas, 6, f => f.FechaDeEntrega, f => f.TotalPagar);
            r.ActividadReciente = listaCotizaciones
                .Select(c => new ItemActividad
                {
                    Tipo = "Cotizacion",
                    Titulo = "Nueva cotización",
                    Descripcion = "COT-" + c.CodigoCotizacion + " · Q" + c.Total.ToString("N2"),
                    Fecha = c.FechaEmision
                })
                .Concat(listaUsuarios.Select(u => new ItemActividad
                {
                    Tipo = "Usuario",
                    Titulo = "Nuevo usuario",
                    Descripcion = "Se registró el usuario: " + u.NombreUsuario,
                    Fecha = u.FechaCreacion
                }))
                .Concat(listaDisenos.Select(d => new ItemActividad
                {
                    Tipo = "Diseno",
                    Titulo = "Diseño registrado",
                    Descripcion = d.NombreDiseño,
                    Fecha = d.FechaCreacion
                }))
                .Concat(listaOrdenes.Select(o => new ItemActividad
                {
                    Tipo = "Orden",
                    Titulo = "Orden de trabajo",
                    Descripcion = o.NombreOrdenTrabajo,
                    Fecha = o.FechaInicio
                }))
                .Concat(listaFacturas.Select(f => new ItemActividad
                {
                    Tipo = "Factura",
                    Titulo = "Factura registrada",
                    Descripcion = "No. " + f.NoFactura + " · Q" + f.TotalPagar.ToString("N2"),
                    Fecha = f.FechaDeEntrega
                }))
                .Concat(listaCompras.Select(c => new ItemActividad
                {
                    Tipo = "Compra",
                    Titulo = "Compra registrada",
                    Descripcion = "Compra " + c.CodigoCompra + " · Q" + c.TotalCompra.ToString("N2"),
                    Fecha = c.FechaCompra
                }))
                .OrderByDescending(a => a.Fecha)
                .ToList();
            return r;
        }

        private static List<ItemGrafico> Contar(IEnumerable<string> valores, string[] categorias)
        {
            List<string> orden = new List<string>(categorias);
            Dictionary<string, int> conteo = new Dictionary<string, int>();
            foreach (string c in categorias) conteo[c] = 0;

            foreach (string v in valores)
            {
                if (string.IsNullOrWhiteSpace(v)) continue;
                if (!conteo.ContainsKey(v))
                {
                    conteo[v] = 0;
                    orden.Add(v);
                }
                conteo[v]++;
            }
            return orden.Select(k => new ItemGrafico { Etiqueta = k, Valor = conteo[k] }).ToList();
        }

        private static List<ItemGrafico> MontoUltimosMeses(List<Cotizacion> lista, int meses)
        {
            return MontoPorMes(lista, meses, c => c.FechaEmision, c => c.Total);
        }

        private static List<ItemGrafico> MontoPorMes<T>(IEnumerable<T> lista, int meses, Func<T, DateTime> fecha, Func<T, decimal> monto)
        {
            List<ItemGrafico> resultado = new List<ItemGrafico>();
            DateTime inicio = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            for (int i = meses - 1; i >= 0; i--)
            {
                DateTime mes = inicio.AddMonths(-i);
                decimal total = lista.Where(item => fecha(item).Year == mes.Year && fecha(item).Month == mes.Month).Sum(monto);
                resultado.Add(new ItemGrafico { Etiqueta = mes.ToString("MMM yy", CultureInfo.CurrentCulture), Valor = total });
            }
            return resultado;
        }

        private static List<ItemGrafico> ContarPorMes<T>(IEnumerable<T> lista, int meses, Func<T, DateTime> fecha)
        {
            List<ItemGrafico> resultado = new List<ItemGrafico>();
            DateTime inicio = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            for (int i = meses - 1; i >= 0; i--)
            {
                DateTime mes = inicio.AddMonths(-i);
                decimal total = lista.Count(item => fecha(item).Year == mes.Year && fecha(item).Month == mes.Month);
                resultado.Add(new ItemGrafico { Etiqueta = mes.ToString("MMM yy", CultureInfo.CurrentCulture), Valor = total });
            }
            return resultado;
        }
    }
}
