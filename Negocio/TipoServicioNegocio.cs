using System.Collections.Generic;
using System.Linq;
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

        public int Eliminar(int codigo)
        {
            // TODO: validar reglas antes de eliminar.
            return datos.Eliminar(codigo);
        }

        /// <summary>Resumen del módulo (se muestra en la pestaña Resumen).</summary>
        public ResumenModulo ObtenerResumen()
        {
            List<TipoServicio> lista = datos.Listar() ?? new List<TipoServicio>();
            ResumenModulo r = new ResumenModulo();
            r.Total = lista.Count;
            r.TituloEstado = "Registros por estado";
            r.PorEstado = ResumenHelper.Contar(lista.Select(x => x.Estado ? "Activo" : "Inactivo"), new string[] { "Activo", "Inactivo" }, 0);
            r.TituloCategoria = r.TituloEstado;
            r.PorCategoria = r.PorEstado;
            return r;
        }
    }
}
