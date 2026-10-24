using System;
using System.Collections.Generic;

namespace Entidad
{
    public class FacturaDocumento
    {
        public int CodigoFacturacion { get; set; }
        public int NoFactura { get; set; }
        public DateTime FechaDeEntrega { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Impuesto { get; set; }
        public decimal TotalPagar { get; set; }
        public string NombreOrdenTrabajo { get; set; }
        public string NombreCliente { get; set; }
        public string IdentificacionCliente { get; set; }
        public string DireccionCliente { get; set; }
        public List<DetalleFacturaDocumento> Detalles { get; set; }
    }

    public class DetalleFacturaDocumento
    {
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Descuento { get; set; }
    }
}
