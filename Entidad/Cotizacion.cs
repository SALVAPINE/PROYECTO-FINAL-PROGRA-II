using System;

namespace Entidad
{
    public class Cotizacion
    {
        public string Codigo { get; set; }
        public string Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public string Estado { get; set; }
    }
}
