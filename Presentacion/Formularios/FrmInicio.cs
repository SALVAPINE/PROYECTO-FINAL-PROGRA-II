using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Entidad;
using Negocio;

namespace Presentacion
{
    public partial class FrmInicio : Form
    {
        private readonly DashboardNegocio dashboard = new DashboardNegocio();

        public FrmInicio()
        {
            InitializeComponent();
            lblFecha.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy");
        }

        /// <summary>
        /// Vuelve a leer los datos desde la capa de negocio y actualiza las tarjetas y gráficos.
        /// FrmMain lo llama cada vez que se muestra Inicio, así refleja lo que se haya ingresado.
        /// </summary>
        public void ActualizarDashboard()
        {
            ResumenDashboard r;
            try
            {
                r = dashboard.ObtenerResumen();
            }
            catch (Exception ex)
            {
                Tema.Aviso("No se pudo cargar el dashboard: " + ex.Message);
                return;
            }

            statUsuarios.Valor = r.TotalUsuarios.ToString();
            statUsuarios.Subtitulo = "Activos: " + r.UsuariosActivos;
            statClientes.Valor = r.TotalClientes.ToString();
            statCotizaciones.Valor = r.TotalCotizaciones.ToString();
            statMonto.Valor = r.MontoTotalCotizado.ToString("C2");

            CargarDona(chtCotizaciones, r.CotizacionesPorEstado);
            CargarDona(chtClientes, r.ClientesPorEstado);
            CargarBarras(chtMonto, r.MontoPorMes);
            CargarBarras(chtUsuarios, r.UsuariosPorRol);
        }

        private static void CargarDona(Chart grafico, List<ItemGrafico> datos)
        {
            Series serie = grafico.Series[0];
            serie.Points.Clear();

            decimal total = datos == null ? 0 : datos.Sum(d => d.Valor);
            if (total == 0)
            {
                int vacio = serie.Points.AddY(1);
                serie.Points[vacio].Color = Color.FromArgb(60, 70, 140);
                serie.Points[vacio].LegendText = "Sin datos";
                return;
            }

            foreach (ItemGrafico item in datos)
            {
                if (item.Valor == 0) continue;
                int i = serie.Points.AddY((double)item.Valor);
                serie.Points[i].Color = Tema.ColorEstado(item.Etiqueta);
                serie.Points[i].LegendText = item.Etiqueta + " (" + item.Valor.ToString("0") + ")";
            }
        }

        private static void CargarBarras(Chart grafico, List<ItemGrafico> datos)
        {
            Series serie = grafico.Series[0];
            serie.Points.Clear();
            if (datos == null) return;

            foreach (ItemGrafico item in datos)
            {
                int i = serie.Points.AddY((double)item.Valor);
                serie.Points[i].AxisLabel = item.Etiqueta;
            }
        }
    }
}
