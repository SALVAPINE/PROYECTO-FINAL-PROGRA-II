using System.Collections.Generic;
using Entidad;

namespace Datos
{
    /// <summary>
    /// Capa de datos de usuarios.
    /// Pendiente: aquí va el acceso a la base de datos (conexión, comandos SQL, etc.).
    /// Mientras no se implemente, los métodos devuelven valores vacíos para que la aplicación abra sin errores.
    /// </summary>
    public class UsuarioDatos
    {
        public List<Usuario> Listar()
        {
            // TODO: consultar la base de datos y devolver los registros.
            return new List<Usuario>();
        }

        public List<Usuario> Buscar(string texto, string tipo, string estado)
        {
            // TODO: consultar la base de datos aplicando los filtros.
            return new List<Usuario>();
        }

        public int Insertar(Usuario usuario)
        {
            // TODO: insertar el registro. Devolver las filas afectadas.
            return 0;
        }

        public int Actualizar(Usuario usuario)
        {
            // TODO: actualizar el registro. Devolver las filas afectadas.
            return 0;
        }

        public int Eliminar(int codigo)
        {
            // TODO: eliminar el registro. Devolver las filas afectadas.
            return 0;
        }
    }
}
