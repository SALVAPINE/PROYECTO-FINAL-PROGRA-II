using System.Collections.Generic;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Capa de negocio de detalles de factura: validaciones y reglas; llama a la capa de datos.
    /// </summary>
    public class DetalleFacturaNegocio
    {
        private readonly DetalleFacturaDatos datos = new DetalleFacturaDatos();

        public List<DetalleFactura> Listar()
        {
            return datos.Listar();
        }

        public List<DetalleFactura> Buscar(string texto, string factura)
        {
            return datos.Buscar(texto, factura);
        }

        public string SiguienteCodigo()
        {
            return datos.SiguienteCodigo();
        }

        public int Insertar(DetalleFactura detalleFactura)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Insertar(detalleFactura);
        }

        public int Actualizar(DetalleFactura detalleFactura)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Actualizar(detalleFactura);
        }

        public int Eliminar(string codigo)
        {
            // TODO: validar reglas antes de eliminar.
            return datos.Eliminar(codigo);
        }
    }
}
