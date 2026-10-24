using System;

namespace Entidad
{
    public class FichaInventario
    {
        public int CodigoInventario { get; set; }
        public string NombreProducto { get; set; }
        public string TipoProducto { get; set; }
        public string NombreMaterial { get; set; }
        public string UnidadMedida { get; set; }
        public int Stock { get; set; }
        public decimal PrecioCompra { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string NombreSucursal { get; set; }
        public bool Estado { get; set; }
    }
}
