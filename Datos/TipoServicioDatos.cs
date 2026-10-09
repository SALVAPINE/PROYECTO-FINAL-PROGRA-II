using System.Collections.Generic;
using Entidad;

namespace Datos
{
    /// <summary>
    /// Capa de datos de tipos de servicio.
    /// Pendiente: aquí va el acceso a la base de datos (conexión, comandos SQL, etc.).
    /// Mientras no se implemente, los métodos devuelven valores vacíos para que la aplicación abra sin errores.
    /// </summary>
    public class TipoServicioDatos
    {
        public List<TipoServicio> Listar()
        {
            // TODO: consultar la base de datos y devolver los registros.
            return new List<TipoServicio>();
        }

        public List<TipoServicio> Buscar(string texto, string estado)
        {
            // TODO: consultar la base de datos aplicando los filtros.
            return new List<TipoServicio>();
        }

        public string SiguienteCodigo()
        {
            // TODO: generar el siguiente código (por ejemplo TSV001).
            return string.Empty;
        }

        public int Insertar(TipoServicio tipoServicio)
        {
            // TODO: insertar el registro. Devolver las filas afectadas.
            return 0;
        }

        public int Actualizar(TipoServicio tipoServicio)
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
