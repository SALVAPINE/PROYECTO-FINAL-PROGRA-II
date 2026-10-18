using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Capa de negocio de órdenes de trabajo: validaciones y reglas; llama a la capa de datos.
    /// </summary>
    public class OrdenTrabajoNegocio
    {
        private readonly OrdenTrabajoDatos datos = new OrdenTrabajoDatos();

        public List<OrdenTrabajo> Listar()
        {
            return datos.Listar();
        }

        public List<OrdenTrabajo> Buscar(string texto, string estado)
        {
            return datos.Buscar(texto, estado);
        }

        public int Insertar(OrdenTrabajo ordenTrabajo)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Insertar(ordenTrabajo);
        }

        public int Actualizar(OrdenTrabajo ordenTrabajo)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Actualizar(ordenTrabajo);
        }

        public int Eliminar(int codigo)
        {
            // TODO: validar reglas antes de eliminar.
            return datos.Eliminar(codigo);
        }

        /// <summary>Resumen del módulo (se muestra en la pestaña Resumen).</summary>
        public ResumenModulo ObtenerResumen()
        {
            List<OrdenTrabajo> lista = datos.Listar() ?? new List<OrdenTrabajo>();
            ResumenModulo r = new ResumenModulo();
            r.Total = lista.Count;
            r.TituloEstado = "Registros por estado";
            r.PorEstado = ResumenHelper.Contar(lista.Select(x => x.Estado ? "Activo" : "Inactivo"), new string[] { "Activo", "Inactivo" }, 0);
            r.TituloCategoria = "Órdenes por tipo";
            r.PorCategoria = ResumenHelper.Contar(lista.Select(x => x.TipoDeOrden), new string[] {  }, 6);
            return r;
        }
    }
}
