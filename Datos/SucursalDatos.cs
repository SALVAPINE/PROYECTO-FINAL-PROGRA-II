using System.Collections.Generic;
using Entidad;

namespace Datos
{
    /// <summary>
    /// Capa de datos de sucursales.
    /// Pendiente: aquí va el acceso a la base de datos (conexión, comandos SQL, etc.).
    /// Mientras no se implemente, los métodos devuelven valores vacíos para que la aplicación abra sin errores.
    /// </summary>
    public class SucursalDatos
    {
        public List<Sucursal> Listar()
        {
            // TODO: consultar la base de datos y devolver los registros.
            return new List<Sucursal>();
        }

        public List<Sucursal> Buscar(string texto, string estado)
        {
            // TODO: consultar la base de datos aplicando los filtros.
            return new List<Sucursal>();
        }

        public string SiguienteCodigo()
        {
            // TODO: generar el siguiente código (por ejemplo SUC001).
            return string.Empty;
        }

        public int Insertar(Sucursal sucursal)
        {
            // TODO: insertar el registro. Devolver las filas afectadas.
            return 0;
        }

        public int Actualizar(Sucursal sucursal)
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
