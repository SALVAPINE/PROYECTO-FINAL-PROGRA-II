using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Capa de negocio de diseños: validaciones y reglas; llama a la capa de datos.
    /// </summary>
    public class DisenoNegocio
    {
        private readonly DisenoDatos datos = new DisenoDatos();

        public List<Diseno> Listar()
        {
            return datos.Listar();
        }

        public List<Diseno> Buscar(string texto, string estado)
        {
            return datos.Buscar(texto, estado);
        }

        public int Insertar(Diseno diseno)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Insertar(diseno);
        }

        public int Actualizar(Diseno diseno)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Actualizar(diseno);
        }

        public int Eliminar(int codigo)
        {
            // TODO: validar reglas antes de eliminar.
            return datos.Eliminar(codigo);
        }

        /// <summary>Resumen del módulo (se muestra en la pestaña Resumen).</summary>
        public ResumenModulo ObtenerResumen()
        {
            List<Diseno> lista = datos.Listar() ?? new List<Diseno>();
            ResumenModulo r = new ResumenModulo();
            r.Total = lista.Count;
            r.TituloEstado = "Registros por estado";
            r.PorEstado = ResumenHelper.Contar(lista.Select(x => x.Estado ? "Activo" : "Inactivo"), new string[] { "Activo", "Inactivo" }, 0);
            r.TituloCategoria = "Diseños por tipo";
            r.PorCategoria = ResumenHelper.Contar(lista.Select(x => x.TipoDiseño), new string[] {  }, 6);
            return r;
        }
    }
}
