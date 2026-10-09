using System.Collections.Generic;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Capa de negocio de inventarios: validaciones y reglas; llama a la capa de datos.
    /// </summary>
    public class InventarioNegocio
    {
        private readonly InventarioDatos datos = new InventarioDatos();

        public List<Inventario> Listar()
        {
            return datos.Listar();
        }

        public List<Inventario> Buscar(string texto, string sucursal)
        {
            return datos.Buscar(texto, sucursal);
        }

        public string SiguienteCodigo()
        {
            return datos.SiguienteCodigo();
        }

        public int Insertar(Inventario inventario)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Insertar(inventario);
        }

        public int Actualizar(Inventario inventario)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Actualizar(inventario);
        }

        public int Eliminar(string codigo)
        {
            // TODO: validar reglas antes de eliminar.
            return datos.Eliminar(codigo);
        }
    }
}
