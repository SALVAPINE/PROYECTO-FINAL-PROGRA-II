using System;

namespace Entidad
{
    public class Inventario
    {
        public int CodigoInventario { get; set; }
        public int CodigoSucursal { get; set; }
        public int CodigoMaterial { get; set; }
        public string NombreProducto { get; set; }
        public string TipoProducto { get; set; }
        public int Stock { get; set; }
        public decimal PrecioCompra { get; set; }
        public DateTime FechaAlmacenamiento { get; set; }
        public bool Estado { get; set; }
    }
}
