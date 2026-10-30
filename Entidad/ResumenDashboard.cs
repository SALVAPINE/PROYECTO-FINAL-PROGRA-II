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
        public int TotalDisenos { get; set; }
        public int DisenosActivos { get; set; }
        public int TotalOrdenesTrabajo { get; set; }
        public int OrdenesTrabajoActivas { get; set; }
        public int TotalFacturas { get; set; }
        public int FacturasActivas { get; set; }
        public decimal MontoTotalFacturado { get; set; }
        public int TotalCompras { get; set; }
        public int TotalInventarios { get; set; }
        public int InventariosActivos { get; set; }

        public List<ItemGrafico> CotizacionesPorEstado { get; set; }
        public List<ItemGrafico> MontoPorMes { get; set; }
        public List<ItemGrafico> UsuariosPorRol { get; set; }
        public List<ItemGrafico> ClientesPorEstado { get; set; }
        public List<ItemGrafico> DisenosPorMes { get; set; }
        public List<ItemGrafico> FacturadoPorMes { get; set; }
        public List<ItemActividad> ActividadReciente { get; set; }

        public ResumenDashboard()
        {
            CotizacionesPorEstado = new List<ItemGrafico>();
            MontoPorMes = new List<ItemGrafico>();
            UsuariosPorRol = new List<ItemGrafico>();
            ClientesPorEstado = new List<ItemGrafico>();
            DisenosPorMes = new List<ItemGrafico>();
            FacturadoPorMes = new List<ItemGrafico>();
            ActividadReciente = new List<ItemActividad>();
        }
    }

    public class ItemActividad
    {
        public string Tipo { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime Fecha { get; set; }
    }
}
