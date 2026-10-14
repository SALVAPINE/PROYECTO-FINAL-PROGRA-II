using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Capa de negocio de cotizaciones: validaciones y reglas; llama a la capa de datos.
    /// </summary>
    public class CotizacionNegocio
    {
        private readonly CotizacionDatos datos = new CotizacionDatos();

        public List<Cotizacion> Listar()
        {
            return datos.Listar();
        }

        public List<Cotizacion> Buscar(string texto, string estado)
        {
            return datos.Buscar(texto, estado);
        }

        public int Insertar(Cotizacion cotizacion)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Insertar(cotizacion);
        }

        public int Actualizar(Cotizacion cotizacion)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Actualizar(cotizacion);
        }

        public int Eliminar(int codigo)
        {
            // TODO: validar reglas antes de eliminar.
            return datos.Eliminar(codigo);
        }

        /// <summary>Resumen del módulo (se muestra en la pestaña Resumen).</summary>
        public ResumenModulo ObtenerResumen()
        {
            List<Cotizacion> lista = datos.Listar() ?? new List<Cotizacion>();
            ResumenModulo r = new ResumenModulo();
            r.Total = lista.Count;
            r.TituloEstado = "Registros por estado";
            r.PorEstado = ResumenHelper.Contar(lista.Select(x => x.Estado ? "Activo" : "Inactivo"), new string[] { "Activo", "Inactivo" }, 0);
            r.TituloCategoria = "Cotizaciones por cotizador";
            r.PorCategoria = ResumenHelper.Contar(lista.Select(x => x.NombreCotizador), new string[] {  }, 6);
            r.TieneMonto = true;
            r.EtiquetaMonto = "Monto cotizado";
            r.MontoEsMoneda = true;
            r.MontoTotal = lista.Sum(x => x.Total);
            return r;
        }
    }
}
