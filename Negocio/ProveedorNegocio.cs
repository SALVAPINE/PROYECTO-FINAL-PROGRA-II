using System.Collections.Generic;
using System.Linq;
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

        public int Eliminar(int codigo)
        {
            // TODO: validar reglas antes de eliminar.
            return datos.Eliminar(codigo);
        }

        /// <summary>Resumen del módulo (se muestra en la pestaña Resumen).</summary>
        public ResumenModulo ObtenerResumen()
        {
            List<Proveedor> lista = datos.Listar() ?? new List<Proveedor>();
            ResumenModulo r = new ResumenModulo();
            r.Total = lista.Count;
            r.TituloEstado = "Registros por estado";
            r.PorEstado = ResumenHelper.Contar(lista.Select(x => x.Estado ? "Activo" : "Inactivo"), new string[] { "Activo", "Inactivo" }, 0);
            r.TituloCategoria = "Proveedores por tipo";
            r.PorCategoria = ResumenHelper.Contar(lista.Select(x => x.TipoProveedor), new string[] {  }, 6);
            return r;
        }
    }
}
