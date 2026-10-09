using System.Collections.Generic;
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

        public string SiguienteCodigo()
        {
            return datos.SiguienteCodigo();
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

        public int Eliminar(string codigo)
        {
            // TODO: validar reglas antes de eliminar.
            return datos.Eliminar(codigo);
        }
    }
}
