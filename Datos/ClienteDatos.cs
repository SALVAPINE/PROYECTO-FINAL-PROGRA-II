using System.Collections.Generic;
using Entidad;

namespace Datos
{
    /// <summary>
    /// Capa de datos de clientes.
    /// Pendiente: aquí va el acceso a la base de datos (conexión, comandos SQL, etc.).
    /// Mientras no se implemente, los métodos devuelven valores vacíos para que la aplicación abra sin errores.
    /// </summary>
    public class ClienteDatos
    {
        public List<Cliente> Listar()
        {
            // TODO: consultar la base de datos y devolver los registros.
            return new List<Cliente>();
        }

        public List<Cliente> Buscar(string texto, string estado)
        {
            // TODO: consultar la base de datos aplicando los filtros.
            return new List<Cliente>();
        }

        public string SiguienteCodigo()
        {
            // TODO: generar el siguiente código (por ejemplo CLI001).
            return string.Empty;
        }

        public int Insertar(Cliente cliente)
        {
            // TODO: insertar el registro. Devolver las filas afectadas.
            return 0;
        }

        public int Actualizar(Cliente cliente)
        {
            // TODO: actualizar el registro. Devolver las filas afectadas.
            return 0;
        }

        public int Eliminar(string codigo)
        {
            // TODO: eliminar el registro. Devolver las filas afectadas.
            return 0;
        }
    }
}
