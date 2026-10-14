using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Capa de negocio de sucursales: validaciones y reglas; llama a la capa de datos.
    /// </summary>
    public class SucursalNegocio
    {
        private readonly SucursalDatos datos = new SucursalDatos();

        public List<Sucursal> Listar()
        {
            return datos.Listar();
        }

        public List<Sucursal> Buscar(string texto, string estado)
        {
            return datos.Buscar(texto, estado);
        }

        public int Insertar(Sucursal sucursal)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Insertar(sucursal);
        }

        public int Actualizar(Sucursal sucursal)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Actualizar(sucursal);
        }

        public int Eliminar(int codigo)
        {
            // TODO: validar reglas antes de eliminar.
            return datos.Eliminar(codigo);
        }

        /// <summary>Resumen del módulo (se muestra en la pestaña Resumen).</summary>
        public ResumenModulo ObtenerResumen()
        {
            List<Sucursal> lista = datos.Listar() ?? new List<Sucursal>();
            ResumenModulo r = new ResumenModulo();
            r.Total = lista.Count;
            r.TituloEstado = "Registros por estado";
            r.PorEstado = ResumenHelper.Contar(lista.Select(x => x.Estado ? "Activo" : "Inactivo"), new string[] { "Activo", "Inactivo" }, 0);
            r.TituloCategoria = "Sucursales por departamento";
            r.PorCategoria = ResumenHelper.Contar(lista.Select(x => x.Departamento), new string[] {  }, 6);
            return r;
        }
    }
}
