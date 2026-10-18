using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Capa de negocio de compras: validaciones y reglas; llama a la capa de datos.
    /// </summary>
    public class CompraNegocio
    {
        private readonly CompraDatos datos = new CompraDatos();

        public List<Compra> Listar()
        {
            return datos.Listar();
        }

        public List<Compra> Buscar(string texto, string estado)
        {
            return datos.Buscar(texto, estado);
        }

        public int Insertar(Compra compra)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Insertar(compra);
        }

        public int Actualizar(Compra compra)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Actualizar(compra);
        }

        public int Eliminar(int codigo)
        {
            // TODO: validar reglas antes de eliminar.
            return datos.Eliminar(codigo);
        }

        /// <summary>Resumen del módulo (se muestra en la pestaña Resumen).</summary>
        public ResumenModulo ObtenerResumen()
        {
            List<Compra> lista = datos.Listar() ?? new List<Compra>();
            ResumenModulo r = new ResumenModulo();
            r.Total = lista.Count;
            r.TituloEstado = "Registros por estado";
            r.PorEstado = ResumenHelper.Contar(lista.Select(x => x.Estado ? "Activo" : "Inactivo"), new string[] { "Activo", "Inactivo" }, 0);
            r.TituloCategoria = r.TituloEstado;
            r.PorCategoria = r.PorEstado;
            r.TieneMonto = true;
            r.EtiquetaMonto = "Total comprado";
            r.MontoEsMoneda = true;
            r.MontoTotal = lista.Sum(x => x.TotalCompra);
            return r;
        }
    }
}
