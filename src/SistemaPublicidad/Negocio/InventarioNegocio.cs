using System.Collections.Generic;
using System.Linq;
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

        public List<Inventario> Buscar(string texto, string estado)
        {
            return datos.Buscar(texto, estado);
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

        public int Eliminar(int codigo)
        {
            // TODO: validar reglas antes de eliminar.
            return datos.Eliminar(codigo);
        }

        /// <summary>Resumen del módulo (se muestra en la pestaña Resumen).</summary>
        public ResumenModulo ObtenerResumen()
        {
            List<Inventario> lista = datos.Listar() ?? new List<Inventario>();
            ResumenModulo r = new ResumenModulo();
            r.Total = lista.Count;
            r.TituloEstado = "Registros por estado";
            r.PorEstado = ResumenHelper.Contar(lista.Select(x => x.Estado ? "Activo" : "Inactivo"), new string[] { "Activo", "Inactivo" }, 0);
            r.TituloCategoria = "Inventario por tipo de producto";
            r.PorCategoria = ResumenHelper.Contar(lista.Select(x => x.TipoProducto), new string[] {  }, 6);
            r.TieneMonto = true;
            r.EtiquetaMonto = "Existencias";
            r.MontoEsMoneda = false;
            r.MontoTotal = lista.Sum(x => x.Stock);
            return r;
        }
    }
}
