namespace Entidad
{
    public class DetalleFactura
    {
        public string Codigo { get; set; }
        public string Factura { get; set; }
        public string TipoServicio { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}
