using System.Collections.Generic;
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

        public string SiguienteCodigo()
        {
            return datos.SiguienteCodigo();
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

        public int Eliminar(string codigo)
        {
            // TODO: validar reglas antes de eliminar.
            return datos.Eliminar(codigo);
        }
    }
}
