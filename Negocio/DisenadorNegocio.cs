using System.Collections.Generic;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Capa de negocio de diseñadores: validaciones y reglas; llama a la capa de datos.
    /// </summary>
    public class DisenadorNegocio
    {
        private readonly DisenadorDatos datos = new DisenadorDatos();

        public List<Disenador> Listar()
        {
            return datos.Listar();
        }

        public List<Disenador> Buscar(string texto, string estado)
        {
            return datos.Buscar(texto, estado);
        }

        public string SiguienteCodigo()
        {
            return datos.SiguienteCodigo();
        }

        public int Insertar(Disenador disenador)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Insertar(disenador);
        }

        public int Actualizar(Disenador disenador)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Actualizar(disenador);
        }

        public int Eliminar(string codigo)
        {
            // TODO: validar reglas antes de eliminar.
            return datos.Eliminar(codigo);
        }
    }
}
