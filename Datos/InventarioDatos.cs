using System.Collections.Generic;
using Entidad;

namespace Datos
{
    /// <summary>
    /// Capa de datos de inventarios.
    /// Pendiente: aquí va el acceso a la base de datos (conexión, comandos SQL, etc.).
    /// Mientras no se implemente, los métodos devuelven valores vacíos para que la aplicación abra sin errores.
    /// </summary>
    public class InventarioDatos
    {
        public List<Inventario> Listar()
        {
            // TODO: consultar la base de datos y devolver los registros.
            return new List<Inventario>();
        }

        public List<Inventario> Buscar(string texto, string sucursal)
        {
            // TODO: consultar la base de datos aplicando los filtros.
            return new List<Inventario>();
        }

        public string SiguienteCodigo()
        {
            // TODO: generar el siguiente código (por ejemplo INV001).
            return string.Empty;
        }

        public int Insertar(Inventario inventario)
        {
            // TODO: insertar el registro. Devolver las filas afectadas.
            return 0;
        }

        public int Actualizar(Inventario inventario)
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
