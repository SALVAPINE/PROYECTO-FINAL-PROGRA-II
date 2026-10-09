using System.Collections.Generic;
using Entidad;

namespace Datos
{
    /// <summary>
    /// Capa de datos de proveedores.
    /// Pendiente: aquí va el acceso a la base de datos (conexión, comandos SQL, etc.).
    /// Mientras no se implemente, los métodos devuelven valores vacíos para que la aplicación abra sin errores.
    /// </summary>
    public class ProveedorDatos
    {
        public List<Proveedor> Listar()
        {
            // TODO: consultar la base de datos y devolver los registros.
            return new List<Proveedor>();
        }

        public List<Proveedor> Buscar(string texto, string estado)
        {
            // TODO: consultar la base de datos aplicando los filtros.
            return new List<Proveedor>();
        }

        public string SiguienteCodigo()
        {
            // TODO: generar el siguiente código (por ejemplo PRV001).
            return string.Empty;
        }

        public int Insertar(Proveedor proveedor)
        {
            // TODO: insertar el registro. Devolver las filas afectadas.
            return 0;
        }

        public int Actualizar(Proveedor proveedor)
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
