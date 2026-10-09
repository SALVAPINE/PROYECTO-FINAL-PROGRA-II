using System.Collections.Generic;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Capa de negocio de proveedores: validaciones y reglas; llama a la capa de datos.
    /// </summary>
    public class ProveedorNegocio
    {
        private readonly ProveedorDatos datos = new ProveedorDatos();

        public List<Proveedor> Listar()
        {
            return datos.Listar();
        }

        public List<Proveedor> Buscar(string texto, string estado)
        {
            return datos.Buscar(texto, estado);
        }

        public string SiguienteCodigo()
        {
            return datos.SiguienteCodigo();
        }

        public int Insertar(Proveedor proveedor)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Insertar(proveedor);
        }

        public int Actualizar(Proveedor proveedor)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Actualizar(proveedor);
        }

        public int Eliminar(string codigo)
        {
            // TODO: validar reglas antes de eliminar.
            return datos.Eliminar(codigo);
        }
    }
}
