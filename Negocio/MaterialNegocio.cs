using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Capa de negocio de materiales: validaciones y reglas; llama a la capa de datos.
    /// </summary>
    public class MaterialNegocio
    {
        private readonly MaterialDatos datos = new MaterialDatos();

        public List<Material> Listar()
        {
            return datos.Listar();
        }

        public List<Material> Buscar(string texto, string estado)
        {
            return datos.Buscar(texto, estado);
        }

        public int Insertar(Material material)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Insertar(material);
        }

        public int Actualizar(Material material)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Actualizar(material);
        }

        public int Eliminar(int codigo)
        {
            // TODO: validar reglas antes de eliminar.
            return datos.Eliminar(codigo);
        }

        /// <summary>Resumen del módulo (se muestra en la pestaña Resumen).</summary>
        public ResumenModulo ObtenerResumen()
        {
            List<Material> lista = datos.Listar() ?? new List<Material>();
            ResumenModulo r = new ResumenModulo();
            r.Total = lista.Count;
            r.TituloEstado = "Registros por estado";
            r.PorEstado = ResumenHelper.Contar(lista.Select(x => x.Estado ? "Activo" : "Inactivo"), new string[] { "Activo", "Inactivo" }, 0);
            r.TituloCategoria = "Materiales por categoría";
            r.PorCategoria = ResumenHelper.Contar(lista.Select(x => x.CategoriaMaterial), new string[] {  }, 6);
            return r;
        }
    }
}
