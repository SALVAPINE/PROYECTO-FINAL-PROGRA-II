using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Capa de negocio de facturas: validaciones y reglas; llama a la capa de datos.
    /// </summary>
    public class FacturaNegocio
    {
        private readonly FacturaDatos datos = new FacturaDatos();

        public List<Factura> Listar()
        {
            return datos.Listar();
        }

        public List<Factura> Buscar(string texto, string estado)
        {
            return datos.Buscar(texto, estado);
        }

        public int Insertar(Factura factura)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Insertar(factura);
        }

        public int Actualizar(Factura factura)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Actualizar(factura);
        }

        public int Eliminar(int codigo)
        {
            // TODO: validar reglas antes de eliminar.
            return datos.Eliminar(codigo);
        }

        /// <summary>Resumen del módulo (se muestra en la pestaña Resumen).</summary>
        public ResumenModulo ObtenerResumen()
        {
            List<Factura> lista = datos.Listar() ?? new List<Factura>();
            ResumenModulo r = new ResumenModulo();
            r.Total = lista.Count;
            r.TituloEstado = "Registros por estado";
            r.PorEstado = ResumenHelper.Contar(lista.Select(x => x.Estado ? "Activo" : "Inactivo"), new string[] { "Activo", "Inactivo" }, 0);
            r.TituloCategoria = r.TituloEstado;
            r.PorCategoria = r.PorEstado;
            r.TieneMonto = true;
            r.EtiquetaMonto = "Total facturado";
            r.MontoEsMoneda = true;
            r.MontoTotal = lista.Sum(x => x.TotalPagar);
            return r;
        }
    }
}
