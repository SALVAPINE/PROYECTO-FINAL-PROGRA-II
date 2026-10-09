using System.Collections.Generic;
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

        public string SiguienteCodigo()
        {
            return datos.SiguienteCodigo();
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

        public int Eliminar(string codigo)
        {
            // TODO: validar reglas antes de eliminar.
            return datos.Eliminar(codigo);
        }
    }
}
