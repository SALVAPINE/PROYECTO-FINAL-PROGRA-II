namespace Entidad
{
    public class DetalleCompra
    {
        public int CodigoDetalleCompra { get; set; }
        public string TipoDeCompra { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public decimal DescuentoCompra { get; set; }
        public bool Estado { get; set; }
        public int CodigoCompra { get; set; }
    }
}
