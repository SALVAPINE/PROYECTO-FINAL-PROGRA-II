using System;

namespace Entidad
{
    public class Diseno
    {
        public int CodigoDiseño { get; set; }
        public int CodigoCliente { get; set; }
        public int CodigoDiseñador { get; set; }
        public string NombreDiseño { get; set; }
        public string TipoDiseño { get; set; }
        public string Descripcion { get; set; }
        public string RangoDiseño { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }
    }
}
