using System;

namespace Entidad
{
    public class Compra
    {
        public string Codigo { get; set; }
        public string Proveedor { get; set; }
        public string Sucursal { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }
    }
}
