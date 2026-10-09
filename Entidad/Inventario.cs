using System;

namespace Entidad
{
    public class Inventario
    {
        public string Codigo { get; set; }
        public string Material { get; set; }
        public string Sucursal { get; set; }
        public decimal Cantidad { get; set; }
        public decimal StockMinimo { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
