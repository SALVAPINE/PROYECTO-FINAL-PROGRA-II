using System;

namespace Entidad
{
    public class OrdenTrabajo
    {
        public int CodigoOrdenTrabajo { get; set; }
        public int CodigoSucursal { get; set; }
        public int CodigoTipoServicio { get; set; }
        public int CodigoCotizacion { get; set; }
        public int CodigoDiseñador { get; set; }
        public string NombreOrdenTrabajo { get; set; }
        public string TipoDeOrden { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}
