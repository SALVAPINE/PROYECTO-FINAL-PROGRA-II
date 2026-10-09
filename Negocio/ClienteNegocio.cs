using System.Collections.Generic;
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

        public string SiguienteCodigo()
        {
            return datos.SiguienteCodigo();
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

        public int Eliminar(string codigo)
        {
            // TODO: validar reglas antes de eliminar.
            return datos.Eliminar(codigo);
        }
    }
}
