using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Capa de negocio de clientes: validaciones y reglas; llama a la capa de datos.
    /// </summary>
    public class ClienteNegocio
    {
        private readonly ClienteDatos datos = new ClienteDatos();

        public List<Cliente> Listar()
        {
            return datos.Listar();
        }

        public List<Cliente> Buscar(string texto, string estado)
        {
            return datos.Buscar(texto, estado);
        }

        public int Insertar(Cliente cliente)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Insertar(cliente);
        }

        public int Actualizar(Cliente cliente)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Actualizar(cliente);
        }

        public int Eliminar(int codigo)
        {
            // TODO: validar reglas antes de eliminar.
            return datos.Eliminar(codigo);
        }

        /// <summary>Resumen del módulo (se muestra en la pestaña Resumen).</summary>
        public ResumenModulo ObtenerResumen()
        {
            List<Cliente> lista = datos.Listar() ?? new List<Cliente>();
            ResumenModulo r = new ResumenModulo();
            r.Total = lista.Count;
            r.TituloEstado = "Registros por estado";
            r.PorEstado = ResumenHelper.Contar(lista.Select(x => x.Estado ? "Activo" : "Inactivo"), new string[] { "Activo", "Inactivo" }, 0);
            r.TituloCategoria = r.TituloEstado;
            r.PorCategoria = r.PorEstado;
            return r;
        }
    }
}
