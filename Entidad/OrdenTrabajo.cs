using System;

namespace Entidad
{
    public class OrdenTrabajo
    {
        public string Codigo { get; set; }
        public string Cliente { get; set; }
        public string TipoServicio { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }
}
