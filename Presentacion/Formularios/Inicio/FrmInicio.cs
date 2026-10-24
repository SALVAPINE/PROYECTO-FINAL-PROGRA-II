using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace SistemaPublicidad.Formularios
{
    public class FrmInicio : Form
    {
        public TarjetaStat StUsuarios, StClientes, StCotizaciones, StMonto;
        public Dona DonaCotizaciones, DonaClientes;
        public GraficaMes Grafica; public ListaActividad Actividad;

        public FrmInicio()
        {
            TopLevel = false; FormBorderStyle = FormBorderStyle.None; Dock = DockStyle.Fill; BackColor = Tema.Fondo; DoubleBuffered = true; SetStyle(ControlStyles.ResizeRedraw, true);
            var t = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 20, RowCount = 4, BackColor = Color.Transparent };
            t.SuspendLayout();
            for (int i = 0; i < 20; i++) t.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5));
            t.RowStyles.Add(new RowStyle(SizeType.Absolute, 120)); t.RowStyles.Add(new RowStyle(SizeType.Absolute, 128));
            t.RowStyles.Add(new RowStyle(SizeType.Percent, 46)); t.RowStyles.Add(new RowStyle(SizeType.Percent, 54));

            Add(t, new Bienvenida(), 0, 0, 20, 0);

            StUsuarios = Stat("Usuarios", "👤", Color.FromArgb(25, 75, 250), Color.FromArgb(0, 145, 255));
            StClientes = Stat("Clientes", "👥", Color.FromArgb(255, 45, 170), Color.FromArgb(190, 40, 225));
            StCotizaciones = Stat("Cotizaciones", "📄", Color.FromArgb(0, 215, 170), Color.FromArgb(0, 150, 205));
            StMonto = Stat("Monto cotizado", "🪙", Color.FromArgb(255, 175, 30), Color.FromArgb(245, 90, 60));
            Add(t, StUsuarios, 0, 1, 5, 6); Add(t, StClientes, 5, 1, 5, 6); Add(t, StCotizaciones, 10, 1, 5, 6); Add(t, StMonto, 15, 1, 5, 6);

            DonaCotizaciones = new Dona { Titulo = "Cotizaciones por estado", Icono = "📊", Ilustracion = "clip", Opacidad = 225, C1 = Color.FromArgb(10, 26, 100), C2 = Color.FromArgb(10, 40, 120), Brillo = Color.FromArgb(55, 0, 230, 200), Brillo2 = Color.FromArgb(35, 60, 110, 255) };
            DonaClientes = new Dona { Titulo = "Clientes por estado", Icono = "👥", Ilustracion = "gente", Opacidad = 225, C1 = Color.FromArgb(18, 24, 105), C2 = Color.FromArgb(44, 24, 125), Brillo = Color.FromArgb(70, 255, 60, 190), Brillo2 = Color.FromArgb(35, 120, 80, 255) };
            Add(t, DonaCotizaciones, 0, 2, 10, 6); Add(t, DonaClientes, 10, 2, 10, 6);

            Grafica = new GraficaMes { Opacidad = 225, C1 = Color.FromArgb(10, 24, 96), C2 = Color.FromArgb(30, 22, 120), Brillo = Color.FromArgb(70, 150, 60, 255), Brillo2 = Color.FromArgb(30, 0, 200, 255) };
            Actividad = new ListaActividad { Opacidad = 225, C1 = Color.FromArgb(10, 24, 96), C2 = Color.FromArgb(14, 30, 116), Brillo = Color.FromArgb(50, 60, 110, 255), Brillo2 = Color.FromArgb(25, 0, 230, 200) };
            Add(t, Grafica, 0, 3, 12, 6); Add(t, Actividad, 12, 3, 8, 6);
            Controls.Add(t);
            t.ResumeLayout(true);

            // ---- DATOS DE EJEMPLO (solo para ver el diseño). Reemplácelos con sus datos reales. ----
            StUsuarios.Valor = "7"; StUsuarios.Sub = "Activos: 7"; StUsuarios.Delta = "▲ +2";
            StClientes.Valor = "6"; StClientes.Sub = "Registrados"; StClientes.Delta = "▲ +1";
            StCotizaciones.Valor = "6"; StCotizaciones.Sub = "Totales"; StCotizaciones.Delta = "▲ +3";
            StMonto.Valor = "Q10,900.00"; StMonto.Sub = "Total cotizado"; StMonto.Delta = "▲ +8%";
            DonaCotizaciones.Activos = 6; DonaClientes.Activos = 6;
            var es = new CultureInfo("es-ES"); Grafica.Meses = new string[6]; Grafica.Valores = new decimal[] { 600, 1900, 1100, 2200, 1800, 3900 };
            for (int i = 0; i < 6; i++) Grafica.Meses[i] = DateTime.Now.AddMonths(i - 5).ToString("MMM yy", es).Replace(".", "");
            Actividad.Items.Add(new[] { "Nueva cotización", "Q10,900.00 · Cliente: Cliente Demo", "Hoy 10:24" });
            Actividad.Items.Add(new[] { "Nuevo usuario", "Se registró el usuario: juanperez", "Hoy 09:15" });
            Actividad.Items.Add(new[] { "Factura generada", "#FAC-0008 · Q3,450.00", "Ayer 16:30" });
            Actividad.Items.Add(new[] { "Material actualizado", "Se agregó nuevo material: Vinil adhesivo", "Ayer 14:12" });
        }

        protected override void OnPaintBackground(PaintEventArgs e) { Tema.PintarFondo(e.Graphics, this); }

        static TarjetaStat Stat(string titulo, string icono, Color a, Color b)
        { return new TarjetaStat { Titulo = titulo, Icono = icono, Circulo = true, Glifo = Recursos.Img("st_" + (titulo == "Monto cotizado" ? "monto" : titulo.ToLower())), C1 = a, C2 = b, ColorBorde = Color.FromArgb(110, 255, 255, 255), Radio = 18, Opacidad = 255 }; }

        static void Add(TableLayoutPanel t, Control c, int col, int row, int span, int margen)
        { c.Dock = DockStyle.Fill; c.Margin = new Padding(margen); t.Controls.Add(c, col, row); t.SetColumnSpan(c, span); }
    }
}
