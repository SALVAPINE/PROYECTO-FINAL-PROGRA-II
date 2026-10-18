using System.Collections.Generic;

namespace Entidad
{
    /// <summary>Datos que muestra el dashboard de la pantalla Inicio.</summary>
    public class ResumenDashboard
    {
        public int TotalUsuarios { get; set; }
        public int UsuariosActivos { get; set; }
        public int TotalClientes { get; set; }
        public int TotalCotizaciones { get; set; }
        public decimal MontoTotalCotizado { get; set; }

        public List<ItemGrafico> CotizacionesPorEstado { get; set; }
        public List<ItemGrafico> MontoPorMes { get; set; }
        public List<ItemGrafico> UsuariosPorRol { get; set; }
        public List<ItemGrafico> ClientesPorEstado { get; set; }

        public ResumenDashboard()
        {
            CotizacionesPorEstado = new List<ItemGrafico>();
            MontoPorMes = new List<ItemGrafico>();
            UsuariosPorRol = new List<ItemGrafico>();
            ClientesPorEstado = new List<ItemGrafico>();
        }
    }
}
