using System.Collections.Generic;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Capa de negocio de usuarios: validaciones y reglas; llama a la capa de datos.
    /// </summary>
    public class UsuarioNegocio
    {
        private readonly UsuarioDatos datos = new UsuarioDatos();

        public List<Usuario> Listar()
        {
            return datos.Listar();
        }

        public List<Usuario> Buscar(string texto, string rol, string estado)
        {
            return datos.Buscar(texto, rol, estado);
        }

        public string SiguienteCodigo()
        {
            return datos.SiguienteCodigo();
        }

        public int Insertar(Usuario usuario)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Insertar(usuario);
        }

        public int Actualizar(Usuario usuario)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Actualizar(usuario);
        }

        public int Eliminar(string codigo)
        {
            // TODO: validar reglas antes de eliminar.
            return datos.Eliminar(codigo);
        }
    }
}
