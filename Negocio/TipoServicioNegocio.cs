using System.Collections.Generic;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Capa de negocio de tipos de servicio: validaciones y reglas; llama a la capa de datos.
    /// </summary>
    public class TipoServicioNegocio
    {
        private readonly TipoServicioDatos datos = new TipoServicioDatos();

        public List<TipoServicio> Listar()
        {
            return datos.Listar();
        }

        public List<TipoServicio> Buscar(string texto, string estado)
        {
            return datos.Buscar(texto, estado);
        }

        public string SiguienteCodigo()
        {
            return datos.SiguienteCodigo();
        }

        public int Insertar(TipoServicio tipoServicio)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Insertar(tipoServicio);
        }

        public int Actualizar(TipoServicio tipoServicio)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Actualizar(tipoServicio);
        }

        public int Eliminar(string codigo)
        {
            // TODO: validar reglas antes de eliminar.
            return datos.Eliminar(codigo);
        }
    }
}
