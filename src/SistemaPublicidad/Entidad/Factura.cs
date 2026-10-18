using System;

namespace Entidad
{
    public class Factura
    {
        public int CodigoFacturacion { get; set; }
        public int CodigoOrdenTrabajo { get; set; }
        public int NoFactura { get; set; }
        public DateTime FechaDeEntrega { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Impuesto { get; set; }
        public decimal TotalPagar { get; set; }
        public bool Estado { get; set; }
    }
}
