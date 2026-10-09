using System.Collections.Generic;
using Entidad;

namespace Datos
{
    /// <summary>
    /// Capa de datos de detalles de factura.
    /// Pendiente: aquí va el acceso a la base de datos (conexión, comandos SQL, etc.).
    /// Mientras no se implemente, los métodos devuelven valores vacíos para que la aplicación abra sin errores.
    /// </summary>
    public class DetalleFacturaDatos
    {
        public List<DetalleFactura> Listar()
        {
            // TODO: consultar la base de datos y devolver los registros.
            return new List<DetalleFactura>();
        }

        public List<DetalleFactura> Buscar(string texto, string factura)
        {
            // TODO: consultar la base de datos aplicando los filtros.
            return new List<DetalleFactura>();
        }

        public string SiguienteCodigo()
        {
            // TODO: generar el siguiente código (por ejemplo DFA001).
            return string.Empty;
        }

        public int Insertar(DetalleFactura detalleFactura)
        {
            // TODO: insertar el registro. Devolver las filas afectadas.
            return 0;
        }

        public int Actualizar(DetalleFactura detalleFactura)
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
