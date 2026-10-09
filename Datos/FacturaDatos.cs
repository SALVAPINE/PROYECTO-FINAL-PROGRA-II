using System.Collections.Generic;
using Entidad;

namespace Datos
{
    /// <summary>
    /// Capa de datos de facturas.
    /// Pendiente: aquí va el acceso a la base de datos (conexión, comandos SQL, etc.).
    /// Mientras no se implemente, los métodos devuelven valores vacíos para que la aplicación abra sin errores.
    /// </summary>
    public class FacturaDatos
    {
        public List<Factura> Listar()
        {
            // TODO: consultar la base de datos y devolver los registros.
            return new List<Factura>();
        }

        public List<Factura> Buscar(string texto, string estado)
        {
            // TODO: consultar la base de datos aplicando los filtros.
            return new List<Factura>();
        }

        public string SiguienteCodigo()
        {
            // TODO: generar el siguiente código (por ejemplo FAC001).
            return string.Empty;
        }

        public int Insertar(Factura factura)
        {
            // TODO: insertar el registro. Devolver las filas afectadas.
            return 0;
        }

        public int Actualizar(Factura factura)
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
