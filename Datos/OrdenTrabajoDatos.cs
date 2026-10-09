using System.Collections.Generic;
using Entidad;

namespace Datos
{
    /// <summary>
    /// Capa de datos de órdenes de trabajo.
    /// Pendiente: aquí va el acceso a la base de datos (conexión, comandos SQL, etc.).
    /// Mientras no se implemente, los métodos devuelven valores vacíos para que la aplicación abra sin errores.
    /// </summary>
    public class OrdenTrabajoDatos
    {
        public List<OrdenTrabajo> Listar()
        {
            // TODO: consultar la base de datos y devolver los registros.
            return new List<OrdenTrabajo>();
        }

        public List<OrdenTrabajo> Buscar(string texto, string estado)
        {
            // TODO: consultar la base de datos aplicando los filtros.
            return new List<OrdenTrabajo>();
        }

        public string SiguienteCodigo()
        {
            // TODO: generar el siguiente código (por ejemplo ORD001).
            return string.Empty;
        }

        public int Insertar(OrdenTrabajo ordenTrabajo)
        {
            // TODO: insertar el registro. Devolver las filas afectadas.
            return 0;
        }

        public int Actualizar(OrdenTrabajo ordenTrabajo)
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
