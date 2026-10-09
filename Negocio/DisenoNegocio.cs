using System.Collections.Generic;
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

        public string SiguienteCodigo()
        {
            return datos.SiguienteCodigo();
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

        public int Eliminar(string codigo)
        {
            // TODO: validar reglas antes de eliminar.
            return datos.Eliminar(codigo);
        }
    }
}
