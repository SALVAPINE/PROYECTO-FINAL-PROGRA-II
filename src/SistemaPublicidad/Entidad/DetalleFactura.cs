namespace Entidad
{
    public class DetalleFactura
    {
        public int CodigoDetalleFactura { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal DescuentoAplicado { get; set; }
        public bool Estado { get; set; }
        public int CodigoFacturacion { get; set; }
    }
}
