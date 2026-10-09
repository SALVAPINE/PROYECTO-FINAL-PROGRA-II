using System;

namespace Entidad
{
    public class Factura
    {
        public string Codigo { get; set; }
        public string Cliente { get; set; }
        public string Sucursal { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }
    }
}
