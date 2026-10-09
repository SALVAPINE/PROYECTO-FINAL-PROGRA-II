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

        public ResumenDashboard ObtenerResumen()
        {
            List<Usuario> listaUsuarios = usuarios.Listar() ?? new List<Usuario>();
            List<Cliente> listaClientes = clientes.Listar() ?? new List<Cliente>();
            List<Cotizacion> listaCotizaciones = cotizaciones.Listar() ?? new List<Cotizacion>();

            ResumenDashboard r = new ResumenDashboard();
            r.TotalUsuarios = listaUsuarios.Count;
            r.UsuariosActivos = listaUsuarios.Count(u => u.Estado == "Activo");
            r.TotalClientes = listaClientes.Count;
            r.TotalCotizaciones = listaCotizaciones.Count;
            r.MontoTotalCotizado = listaCotizaciones.Sum(c => c.Monto);

            r.CotizacionesPorEstado = Contar(listaCotizaciones.Select(c => c.Estado), new[] { "Pendiente", "Aprobada", "Rechazada" });
            r.ClientesPorEstado = Contar(listaClientes.Select(c => c.Estado), new[] { "Activo", "Inactivo" });
            r.UsuariosPorRol = Contar(listaUsuarios.Select(u => u.Rol), new[] { "Administrador", "Supervisor", "Usuario" });
            r.MontoPorMes = MontoUltimosMeses(listaCotizaciones, 6);
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
            List<ItemGrafico> resultado = new List<ItemGrafico>();
            DateTime inicio = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            for (int i = meses - 1; i >= 0; i--)
            {
                DateTime mes = inicio.AddMonths(-i);
                decimal total = lista.Where(c => c.Fecha.Year == mes.Year && c.Fecha.Month == mes.Month).Sum(c => c.Monto);
                resultado.Add(new ItemGrafico { Etiqueta = mes.ToString("MMM yy", CultureInfo.CurrentCulture), Valor = total });
            }
            return resultado;
        }
    }
}
