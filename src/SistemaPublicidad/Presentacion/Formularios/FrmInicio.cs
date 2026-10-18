using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
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
            string fecha = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy");
            lblFecha.Text = char.ToUpper(fecha[0]) + fecha.Substring(1);
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

            graCotizaciones.SetDatos(Resumenes.PuntosEstado(r.CotizacionesPorEstado));
            graficoDona1.SetDatos(Resumenes.PuntosEstado(r.ClientesPorEstado));
            graficoColumnas1.SetDatos(r.MontoPorMes.Select(i => new PuntoGrafico(i.Etiqueta, i.Valor, Color.Empty)).ToList());
        }

        private void roundedPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
