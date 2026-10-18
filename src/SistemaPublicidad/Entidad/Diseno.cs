using System;

namespace Entidad
{
    public class Diseno
    {
        public int CodigoDiseño { get; set; }
        public int CodigoCliente { get; set; }
        public int CodigoDiseñador { get; set; }
        // Descripciones de las tablas padre para presentar resultados obtenidos con JOIN.
        public string NombreCliente { get; set; }
        public string NombreDiseñador { get; set; }
        public string NombreDiseño { get; set; }
        public string TipoDiseño { get; set; }
        public string Descripcion { get; set; }
        public string RangoDiseño { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }
    }
}
