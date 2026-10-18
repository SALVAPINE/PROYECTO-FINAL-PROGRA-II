using System.Collections.Generic;

namespace Entidad
{
    /// <summary>Datos de la pestaña Resumen de cada módulo.</summary>
    public class ResumenModulo
    {
        public int Total { get; set; }
        public string TituloEstado { get; set; }
        public List<ItemGrafico> PorEstado { get; set; }
        public string TituloCategoria { get; set; }
        public List<ItemGrafico> PorCategoria { get; set; }
        public bool TieneMonto { get; set; }
        public string EtiquetaMonto { get; set; }
        public bool MontoEsMoneda { get; set; }
        public decimal MontoTotal { get; set; }

        public ResumenModulo()
        {
            TituloEstado = "Registros por estado";
            TituloCategoria = "Registros por categoría";
            PorEstado = new List<ItemGrafico>();
            PorCategoria = new List<ItemGrafico>();
        }
    }
}
