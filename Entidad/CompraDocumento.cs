using System.Collections.Generic;

namespace Entidad
{
    public class CompraDocumento
    {
        public int CodigoCompra { get; set; }
        public string NombreProveedor { get; set; }
        public string TelefonoProveedor { get; set; }
        public string DireccionProveedor { get; set; }
        public string CondicionPago { get; set; }
        public System.DateTime FechaCompra { get; set; }
        public System.DateTime FechaEntrega { get; set; }
        public decimal TotalCompra { get; set; }
        public List<DetalleCompraDocumento> Detalles { get; set; }

        public CompraDocumento()
        {
            Detalles = new List<DetalleCompraDocumento>();
        }
    }

    public class DetalleCompraDocumento
    {
        public string NombreMaterial { get; set; }
        public int Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        public string Observaciones { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Descuento { get; set; }
        public decimal Subtotal { get; set; }
    }
}
