using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Entidad;
using Negocio;

namespace SistemaPublicidad.Formularios
{
    public class FrmInicio : Form
    {
        public TarjetaStat StUsuarios, StClientes, StCotizaciones, StMonto;
        public Dona DonaCotizaciones, DonaClientes;
        public GraficaMes Grafica; public ListaActividad Actividad;

        public FrmInicio() : this("Administrador") { }

        public FrmInicio(string rol)
        {
            AutoScaleMode = AutoScaleMode.None;
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

            CargarResumen(rol);
        }

        void CargarResumen(string rol)
        {
            ResumenDashboard resumen;
            try
            {
                resumen = new DashboardNegocio().ObtenerResumen();
            }
            catch
            {
                MarcarNoDisponible();
                return;
            }

            bool esDisenador = string.Equals(rol, "Diseñador", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(rol, "Disenador", StringComparison.OrdinalIgnoreCase);
            bool esOperador = string.Equals(rol, "Operador", StringComparison.OrdinalIgnoreCase);
            if (esDisenador)
            {
                EstablecerTarjeta(StUsuarios, "Diseños", "🎨", resumen.TotalDisenos, resumen.DisenosActivos, "Activos");
                EstablecerTarjeta(StClientes, "Órdenes de trabajo", "🛠", resumen.TotalOrdenesTrabajo, resumen.OrdenesTrabajoActivas, "Activas");
                EstablecerTarjeta(StCotizaciones, "Cotizaciones", "📄", resumen.TotalCotizaciones, resumen.TotalCotizaciones, "Registradas");
                EstablecerMonto("Monto cotizado", resumen.MontoTotalCotizado);
                DonaCotizaciones.Titulo = "Diseños por estado";
                DonaClientes.Titulo = "Órdenes de trabajo";
                AsignarDona(DonaCotizaciones, resumen.TotalDisenos, resumen.DisenosActivos);
                AsignarDona(DonaClientes, resumen.TotalOrdenesTrabajo, resumen.OrdenesTrabajoActivas);
                AsignarGrafica(resumen.DisenosPorMes, "Diseños creados por mes", false);
                CargarActividad(resumen.ActividadReciente, "Diseno", "Orden", "Cotizacion");
            }
            else if (esOperador)
            {
                EstablecerTarjeta(StUsuarios, "Facturaciones", "🧾", resumen.TotalFacturas, resumen.FacturasActivas, "Activas");
                EstablecerTarjeta(StClientes, "Compras", "🛒", resumen.TotalCompras, resumen.TotalCompras, "Registradas");
                EstablecerTarjeta(StCotizaciones, "Inventarios", "📦", resumen.TotalInventarios, resumen.InventariosActivos, "Activos");
                EstablecerMonto("Monto facturado", resumen.MontoTotalFacturado);
                DonaCotizaciones.Titulo = "Facturaciones por estado";
                DonaClientes.Titulo = "Inventarios por estado";
                AsignarDona(DonaCotizaciones, resumen.TotalFacturas, resumen.FacturasActivas);
                AsignarDona(DonaClientes, resumen.TotalInventarios, resumen.InventariosActivos);
                AsignarGrafica(resumen.FacturadoPorMes, "Monto facturado por mes");
                CargarActividad(resumen.ActividadReciente, "Factura", "Compra", "Orden");
            }
            else
            {
                EstablecerTarjeta(StUsuarios, "Usuarios", "👤", resumen.TotalUsuarios, resumen.UsuariosActivos, "Activos");
                EstablecerTarjeta(StClientes, "Clientes", "👥", resumen.TotalClientes, resumen.TotalClientes, "Registrados");
                EstablecerTarjeta(StCotizaciones, "Cotizaciones", "📄", resumen.TotalCotizaciones, resumen.TotalCotizaciones, "Registradas");
                EstablecerMonto("Monto cotizado", resumen.MontoTotalCotizado);
                AsignarDona(DonaCotizaciones, resumen.TotalCotizaciones,
                    (int)resumen.CotizacionesPorEstado.Where(x => x.Etiqueta == "Activo").Sum(x => x.Valor));
                AsignarDona(DonaClientes, resumen.TotalClientes,
                    (int)resumen.ClientesPorEstado.Where(x => x.Etiqueta == "Activo").Sum(x => x.Valor));
                CargarActividad(resumen.ActividadReciente, "Cotizacion", "Usuario", "Factura");
            }

            if (!esDisenador && !esOperador)
                AsignarGrafica(resumen.MontoPorMes, "Monto cotizado por mes");
        }

        void EstablecerTarjeta(TarjetaStat tarjeta, string titulo, string icono, int total, int activos, string etiqueta)
        {
            tarjeta.Titulo = titulo;
            tarjeta.Icono = icono;
            tarjeta.Glifo = null;
            tarjeta.Valor = total.ToString("N0", CultureInfo.CurrentCulture);
            tarjeta.Sub = etiqueta + ": " + activos.ToString("N0", CultureInfo.CurrentCulture);
            tarjeta.Delta = "";
        }

        void EstablecerMonto(string titulo, decimal monto)
        {
            StMonto.Titulo = titulo;
            StMonto.Valor = "Q" + monto.ToString("N2", CultureInfo.CurrentCulture);
            StMonto.Sub = "Total registrado";
            StMonto.Delta = "";
        }

        static void AsignarDona(Dona dona, int total, int activos)
        {
            dona.Activos = activos;
            dona.Inactivos = Math.Max(0, total - activos);
        }

        void AsignarGrafica(System.Collections.Generic.List<ItemGrafico> datos, string titulo, bool esMoneda = true)
        {
            Grafica.Titulo = titulo;
            Grafica.EsMoneda = esMoneda;
            Grafica.Meses = datos.Select(x => x.Etiqueta).ToArray();
            Grafica.Valores = datos.Select(x => x.Valor).ToArray();
        }

        void CargarActividad(System.Collections.Generic.List<ItemActividad> actividades, params string[] tipos)
        {
            Actividad.Items.Clear();
            var filtradas = actividades.Where(a => tipos.Contains(a.Tipo)).Take(4).ToList();
            foreach (ItemActividad actividad in filtradas)
                Actividad.Items.Add(new[] { actividad.Titulo, actividad.Descripcion, TextoFecha(actividad.Fecha) });
            if (filtradas.Count == 0)
                Actividad.Items.Add(new[] { "Sin actividad reciente", "No hay registros para mostrar", "" });
        }

        static string TextoFecha(DateTime fecha)
        {
            if (fecha.Date == DateTime.Today) return "Hoy " + fecha.ToString("HH:mm");
            if (fecha.Date == DateTime.Today.AddDays(-1)) return "Ayer " + fecha.ToString("HH:mm");
            return fecha.ToString("dd/MM/yyyy");
        }

        void MarcarNoDisponible()
        {
            foreach (TarjetaStat tarjeta in new[] { StUsuarios, StClientes, StCotizaciones, StMonto })
            {
                tarjeta.Valor = "—";
                tarjeta.Sub = "No disponible";
                tarjeta.Delta = "";
            }
            DonaCotizaciones.Activos = DonaCotizaciones.Inactivos = 0;
            DonaClientes.Activos = DonaClientes.Inactivos = 0;
            Grafica.Meses = new string[0];
            Grafica.Valores = new decimal[0];
            Grafica.EsMoneda = true;
            Actividad.Items.Clear();
            Actividad.Items.Add(new[] { "Dashboard no disponible", "No se pudieron cargar los datos", "" });
        }

        protected override void OnPaintBackground(PaintEventArgs e) { Tema.PintarFondo(e.Graphics, this); }

        static TarjetaStat Stat(string titulo, string icono, Color a, Color b)
        { return new TarjetaStat { Titulo = titulo, Icono = icono, Circulo = true, Glifo = Recursos.Img("st_" + (titulo == "Monto cotizado" ? "monto" : titulo.ToLower())), C1 = a, C2 = b, ColorBorde = Color.FromArgb(110, 255, 255, 255), Radio = 18, Opacidad = 255 }; }

        static void Add(TableLayoutPanel t, Control c, int col, int row, int span, int margen)
        { c.Dock = DockStyle.Fill; c.Margin = new Padding(margen); t.Controls.Add(c, col, row); t.SetColumnSpan(c, span); }
    }
}
