using System.Collections.Generic;
using Entidad;

namespace Datos
{
    /// <summary>
    /// Capa de datos de detalles de compra.
    /// Pendiente: aquí va el acceso a la base de datos (conexión, comandos SQL, etc.).
    /// Mientras no se implemente, los métodos devuelven valores vacíos para que la aplicación abra sin errores.
    /// </summary>
    public class DetalleCompraDatos
    {
        public List<DetalleCompra> Listar()
        {
            // TODO: consultar la base de datos y devolver los registros.
            return new List<DetalleCompra>();
        }

        public List<DetalleCompra> Buscar(string texto, string compra)
        {
            // TODO: consultar la base de datos aplicando los filtros.
            return new List<DetalleCompra>();
        }

        public string SiguienteCodigo()
        {
            // TODO: generar el siguiente código (por ejemplo DCO001).
            return string.Empty;
        }

        public int Insertar(DetalleCompra detalleCompra)
        {
            // TODO: insertar el registro. Devolver las filas afectadas.
            return 0;
        }

        public int Actualizar(DetalleCompra detalleCompra)
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
