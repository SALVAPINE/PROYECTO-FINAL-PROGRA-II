using System;

namespace Entidad
{
    public class Cotizacion
    {
        public int CodigoCotizacion { get; set; }
        public int CodigoTipoServicio { get; set; }
        public int CodigoSucursal { get; set; }
        public int CodigoCliente { get; set; }
        public string NombreCotizador { get; set; }
        public int? NIT { get; set; }
        public string DireccionCotizador { get; set; }
        public DateTime FechaEmision { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public bool Estado { get; set; }
    }
}
