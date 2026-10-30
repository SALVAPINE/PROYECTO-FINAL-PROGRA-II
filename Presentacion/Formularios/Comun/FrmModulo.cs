using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad;
using Negocio;

namespace SistemaPublicidad.Formularios
{
    public class ModuloCfg
    {
        public string Nombre = "", Plural = "", Icono = "", TituloDet = "Detalle", TileImg;
        public string[] StatTit, StatVal, StatTend, StatIco, StatImg, Campos, ColumnasPropiedades, ColumnasDetallePropiedades, Filtros = { "Estado=", "Tipo=", "Orden=" };
        public string Clave;
        public bool DetalleSoloLectura;
        public string[] Tabs = { "Consultar", "Gestionar", "Resumen" };
        public Tabla.Col[] Cols, ColsDet; public string[][] Filas; public Dictionary<string, string[][]> Detalle; public int Total; public int Tab;
    }

    public class CampoTexto : Tarjeta
    {
        public TextBox Caja;
        public CampoTexto(string rotulo, string valor)
        {
            Radio = 12; C1 = C2 = Tema.Campo; Vidrio = false; Height = 52;
            Caja = new TextBox { BorderStyle = BorderStyle.None, BackColor = Tema.Campo, ForeColor = Color.White, Font = Tema.F(10.5f), Left = 12, Top = 24, Width = Width - 24, Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top, Text = valor };
            Controls.Add(Caja); Controls.Add(Tema.L(rotulo, 8, Tema.Sub, 12, 4));
        }
    }

    // Campo numérico (NumericUpDown) con el estilo del sistema; puede ser calculado (solo lectura)
    public class CampoNumero : Tarjeta
    {
        public NumericUpDown Num;
        public event EventHandler EnVivo;
        bool disparandoEnVivo = false;

        public bool EstaVacio { get { return string.IsNullOrWhiteSpace(Num.Text); } }
public decimal Valor
        {
            get
            {
                string txt = (Num.Text ?? "").Replace("Q", "").Replace(",", "").Trim();
                if (string.IsNullOrWhiteSpace(txt)) return Num.Minimum;
                decimal val;
                if (decimal.TryParse(txt, NumberStyles.Any, CultureInfo.InvariantCulture, out val))
                    return Math.Max(Num.Minimum, Math.Min(Num.Maximum, val));
                if (decimal.TryParse(txt, NumberStyles.Any, CultureInfo.CurrentCulture, out val))
                    return Math.Max(Num.Minimum, Math.Min(Num.Maximum, val));
                return Num.Value;
            }
            set
            {
                decimal v = Math.Max(Num.Minimum, Math.Min(Num.Maximum, value));
                if (Num.Value != v)
                {
                    Num.Value = v;
                }
            }
        }
        public void Limpiar() { Num.Value = Num.Minimum; Num.Text = string.Empty; }

        public void NotificarEnVivo()
        {
            if (disparandoEnVivo) return;
            disparandoEnVivo = true;
            try
            {
                if (EnVivo != null) EnVivo(this, EventArgs.Empty);
            }
            finally
            {
                disparandoEnVivo = false;
            }
        }

        public CampoNumero(string rotulo, int decimales, bool moneda, bool soloLectura)
        {
            Radio = 12; C1 = C2 = Tema.Campo; Vidrio = false; Height = 52;
            Num = new NumericUpDown { BorderStyle = BorderStyle.None, BackColor = Tema.Campo, ForeColor = Color.White, Font = Tema.F(10.5f), DecimalPlaces = decimales, Minimum = 0, Maximum = decimales == 0 ? 2147483647m : 99999999.99m, ThousandsSeparator = true,
                Left = moneda ? 30 : 12, Top = 23, Width = Width - (moneda ? 42 : 24), Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top, ReadOnly = soloLectura };
            if (soloLectura) { try { Num.Controls[0].Visible = false; } catch (Exception) { } Num.TabStop = false; }
            Controls.Add(Num); Controls.Add(Tema.L(rotulo, 8, Tema.Sub, 12, 4)); if (moneda) Controls.Add(Tema.L("Q", 10.5f, Tema.Sub, 12, 24));

            // Respuesta en vivo inmediata al teclear sin clics ni demoras
            Num.ValueChanged += (s, e) => NotificarEnVivo();
            Num.KeyUp += (s, e) => NotificarEnVivo();
            foreach (Control c in Num.Controls)
            {
                c.TextChanged += (s, e) => NotificarEnVivo();
                c.KeyUp += (s, e) => NotificarEnVivo();
            }
            Num.ControlAdded += (s, e) =>
            {
                if (e.Control != null)
                {
                    e.Control.TextChanged += (s2, e2) => NotificarEnVivo();
                    e.Control.KeyUp += (s2, e2) => NotificarEnVivo();
                }
            };
            Num.Leave += (s, e) =>
            {
                try { Num.Value = Valor; } catch { }
            };
        }
        public void Color2(Color c) { C1 = C2 = c; Num.BackColor = c; }
    }

    // Campo de fecha con selector de calendario para evitar capturar fechas como texto.
    public class CampoFecha : Tarjeta
    {
        public DateTime Fecha { get; private set; }
        readonly TextBox textoFecha;
        readonly Button botonCalendario;

        public CampoFecha(string rotulo)
        {
            Radio = 12; C1 = C2 = Tema.Campo; Vidrio = false; Height = 52;
            ColorBorde = Color.FromArgb(100, 0, 210, 230);
            Fecha = DateTime.Today;
            textoFecha = new TextBox { BorderStyle = BorderStyle.None, BackColor = Tema.Campo, ForeColor = Color.White,
                Font = Tema.F(10.5f), ReadOnly = true, Cursor = Cursors.Hand, Left = 10, Top = 23,
                Width = Width - 58, Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
                TabStop = false };
            botonCalendario = new Button { Text = "▦", FlatStyle = FlatStyle.Flat, BackColor = Color.FromArgb(35, 55, 135),
                ForeColor = Tema.Cian, Font = Tema.F(11, true), Cursor = Cursors.Hand,
                Width = 30, Height = 25, Left = Width - 40, Top = 20,
                Anchor = AnchorStyles.Top | AnchorStyles.Right, TabStop = false };
            botonCalendario.FlatAppearance.BorderSize = 0;
            botonCalendario.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, 75, 165);
            textoFecha.Click += (s, e) => AbrirCalendario();
            botonCalendario.Click += (s, e) => AbrirCalendario();
            Controls.Add(textoFecha);
            Controls.Add(botonCalendario);
            Controls.Add(Tema.L("▦  " + rotulo.ToUpper(), 8, Tema.Cian, 12, 4, true));
            ActualizarTexto();
        }

        public void Limpiar()
        {
            Establecer(DateTime.Today);
        }

        public void Establecer(DateTime valor)
        {
            Fecha = valor.Date;
            ActualizarTexto();
        }

        void ActualizarTexto()
        {
            textoFecha.Text = Fecha.ToString("dd 'de' MMMM 'de' yyyy", CultureInfo.GetCultureInfo("es-GT"));
        }

        void AbrirCalendario()
        {
            using (var ventana = new Form())
            using (var calendario = new MonthCalendar())
            {
                ventana.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                ventana.StartPosition = FormStartPosition.Manual;
                ventana.ShowInTaskbar = false;
                ventana.AutoSize = true;
                ventana.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                calendario.MaxSelectionCount = 1;
                calendario.SelectionStart = Fecha;
                calendario.BackColor = Tema.Campo;
                calendario.ForeColor = Color.White;
                calendario.TitleBackColor = Tema.Morado;
                calendario.TitleForeColor = Color.White;
                calendario.TrailingForeColor = Tema.Sub;
                calendario.DateSelected += (s, e) =>
                {
                    Establecer(e.Start);
                    ventana.Close();
                };
                ventana.Controls.Add(calendario);
                Point ubicacion = PointToScreen(new Point(botonCalendario.Left, botonCalendario.Bottom));
                ventana.Location = ubicacion;
                ventana.ShowDialog(FindForm());
            }
        }
    }

    public class Totales : Tarjeta
    {
        public string Sub = "Q 0.00", Iva = "Q 0.00", Total = "Q 0.00";
        public string EtiquetaIva = "IVA (12 %)";
        public Totales() { Radio = 14; C1 = Color.FromArgb(14, 30, 108); C2 = Color.FromArgb(24, 24, 124); }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); var g = e.Graphics; if (Width < 120) return;
            if (Width > 420)
            {
                using (var far = new StringFormat { Alignment = StringAlignment.Far })
                {
                    using (var f = Tema.F(10)) using (var b = new SolidBrush(Tema.Sub)) { g.DrawString("Subtotal", f, b, 16, 12); g.DrawString(Sub, f, Brushes.White, 190, 12, far); g.DrawString(EtiquetaIva, f, b, 215, 12); g.DrawString(Iva, f, Brushes.White, 375, 12, far); }
                    var pl = new RectangleF(395, 3, Width - 405, Height - 7);
                    using (var p = Tema.Ruta(pl, 12)) using (var b = new LinearGradientBrush(pl, Color.FromArgb(150, 70, 255), Color.FromArgb(255, 70, 200), 0f)) g.FillPath(b, p);
                    using (var f = Tema.F(11, true)) { g.DrawString("Total", f, Brushes.White, pl.X + 12, pl.Y + 8); g.DrawString(Total, f, Brushes.White, pl.Right - 12, pl.Y + 8, far); }
                }
                return;
            }
            string[] n = { "Subtotal", EtiquetaIva }, v = { Sub, Iva };
            using (var far = new StringFormat { Alignment = StringAlignment.Far })
            {
                for (int i = 0; i < 2; i++)
                {
                    using (var f = Tema.F(10)) using (var b = new SolidBrush(Tema.Sub)) { g.DrawString(n[i], f, b, 16, 14 + i * 28); g.DrawString(v[i], f, Brushes.White, Width - 16, 14 + i * 28, far); }
                }
                var pill = new RectangleF(10, 74, Width - 20, Math.Min(44, Height - 84));
                if (pill.Height > 20)
                {
                    using (var p = Tema.Ruta(pill, 12)) using (var b = new LinearGradientBrush(pill, Color.FromArgb(150, 70, 255), Color.FromArgb(255, 70, 200), 0f)) g.FillPath(b, p);
                    using (var f = Tema.F(11, true)) { g.DrawString("Total", f, Brushes.White, pill.X + 10, pill.Y + pill.Height / 2 - 10); g.DrawString(Total, f, Brushes.White, pill.Right - 10, pill.Y + pill.Height / 2 - 10, far); }
                }
            }
        }
    }

    public class BarrasEstado : Tarjeta
    {
        public List<string[]> Filas = new List<string[]>(); public List<Tabla.Col> Cols = new List<Tabla.Col>();
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); var g = e.Graphics; int y = 18; bool algo = false;
            foreach (string tipo in new[] { "estado", "badge" })
            {
                int ci = Cols.FindIndex(c => c.Tipo == tipo); if (ci < 0) continue;
                var grupos = Filas.Where(f => ci < f.Length).GroupBy(f => f[ci]).OrderByDescending(x => x.Count()).ToList(); if (grupos.Count == 0) continue;
                algo = true;
                using (var f = Tema.F(12, true)) g.DrawString("Distribución por " + Cols[ci].Titulo.ToLower(), f, Brushes.White, 22, y); y += 40;
                int max = grupos.Max(x => x.Count()), tot = Filas.Count;
                foreach (var gr in grupos)
                {
                    if (y + 30 > Height) return;
                    var col = Tabla.ColBadge(gr.Key); int n = gr.Count();
                    using (var f = Tema.F(10)) g.DrawString(gr.Key, f, Brushes.White, 26, y + 3);
                    var track = new RectangleF(190, y + 5, Math.Max(40, Width - 190 - 160), 16);
                    using (var p = Tema.Ruta(track, 8)) using (var b = new SolidBrush(Color.FromArgb(40, 255, 255, 255))) g.FillPath(b, p);
                    var bar = new RectangleF(track.X, track.Y, Math.Max(16, track.Width * n / max), track.Height);
                    using (var p = Tema.Ruta(bar, 8)) using (var b = new LinearGradientBrush(bar, col[0], col[1], 0f)) g.FillPath(b, p);
                    using (var f = Tema.F(10)) using (var b = new SolidBrush(Tema.Sub)) g.DrawString(n + "  (" + (tot == 0 ? 0 : n * 100 / tot) + " %)", f, b, Width - 145, y + 3);
                    y += 34;
                }
                y += 16;
            }
            if (!algo) using (var f = Tema.F(11)) using (var b = new SolidBrush(Tema.Sub)) g.DrawString("Aún no hay datos para resumir.", f, b, 24, 24);
        }
    }

    // Pantalla de módulo: encabezado, pestañas, 4 resúmenes y tres vistas (Consultar / Gestionar / Resumen).
    public class FrmModulo : Form
    {
        // Pinta el fondo compartido antes que las vistas para evitar un destello negro.
        sealed class PanelVistas : Tarjeta
        {
            public PanelVistas()
            {
                SetStyle(ControlStyles.Opaque | ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            }

            protected override void OnPaintBackground(PaintEventArgs e)
            {
                Tema.PintarFondo(e.Graphics, this);
            }
        }

        sealed class CargaModulo
        {
            public List<object> Registros;
            public Dictionary<string, List<ModuloCrud.Opcion>> Opciones = new Dictionary<string, List<ModuloCrud.Opcion>>();
        }

        public static string UsuarioActual { get; set; }
        public static string RolActual { get; set; }
        public Tabla Tabla, TablaDet, TablaGes; public Pestanas Tabs; public TextBox Buscar; public List<Selector> Combos = new List<Selector>();
        public Boton Anadir, Editar, Eliminar; public TarjetaStat[] Stats = new TarjetaStat[4]; public Label Pie;
        Label lblTit, lblSub, lblDet; Totales totDet; BarrasEstado barraResumen; Panel panelVistas, vC, vG, vR, filaStats, vistaActual; readonly List<Control> inputs = new List<Control>(); readonly Dictionary<Selector, List<string>> opcionesFijas = new Dictionary<Selector, List<string>>(); CampoTexto eDesc; CampoNumero eCant, ePrecio, eSubLin, eSubt, eDescto, eTot; readonly ModuloCfg cfg;
        int codigoEnEdicion; bool datosCargados, datosCargando, nuevoRegistroSolicitado;
        int solicitudBusquedaDetalle;
        int solicitudFiltro;
        string terminoCoincidenciasDetalle = "";
        HashSet<int> coincidenciasDetalle = new HashSet<int>();
        List<object> registros = new List<object>();
        const int RegistrosPorPagina = 10;
        int paginaActual = 1;
        Boton botonPaginaAnterior, botonPaginaSiguiente;
        readonly List<Boton> botonesPagina = new List<Boton>();
        int paginaDetalleActual = 1;
        string[][] filasDetalleVista = new string[0][];
        Boton botonDetalleAnterior, botonDetalleSiguiente;
        Label textoPaginacionDetalle;
        FormularioDetalleCrud editorDetalle;
        bool cargandoCamposFormulario;
        bool calculandoCamposCalculados;
        bool gestionarConstruido, resumenConstruido;
        Dictionary<string, List<ModuloCrud.Opcion>> opcionesRelaciones = new Dictionary<string, List<ModuloCrud.Opcion>>();
        static readonly Color[][] Cs = {
            new[] { Color.FromArgb(40, 80, 255), Color.FromArgb(0, 200, 255) }, new[] { Color.FromArgb(255, 40, 190), Color.FromArgb(190, 40, 235) },
            new[] { Color.FromArgb(0, 190, 150), Color.FromArgb(0, 225, 200) }, new[] { Color.FromArgb(255, 165, 30), Color.FromArgb(240, 85, 45) } };

        static Panel P(DockStyle d, int tam, Padding pad)
        {
            var p = new Tarjeta { Dock = d, C1 = Color.Transparent, C2 = Color.Transparent, ColorBorde = Color.Transparent, Radio = 0, Padding = pad };
            if (d == DockStyle.Top || d == DockStyle.Bottom) p.Height = tam; else if (d != DockStyle.Fill) p.Width = tam;
            return p;
        }
        static Tarjeta Card() { return new Tarjeta { Dock = DockStyle.Fill, Radio = 18, Opacidad = 225, C1 = Color.FromArgb(10, 24, 98), C2 = Color.FromArgb(24, 22, 118), Brillo = Color.FromArgb(60, 150, 60, 255), Brillo2 = Color.FromArgb(30, 0, 200, 255) }; }

        public FrmModulo(ModuloCfg c)
        {
            AutoScaleMode = AutoScaleMode.None;
            SuspendLayout();
            cfg = c; cfg.Filas = new string[0][]; cfg.Total = 0;
            TopLevel = false; FormBorderStyle = FormBorderStyle.None; Dock = DockStyle.Fill; BackColor = Tema.Fondo; DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);

            var head = P(DockStyle.Top, 100, new Padding(0));
            var tl2 = c.TileImg == null ? null : Recursos.Img(c.TileImg);
            if (tl2 != null) head.Controls.Add(new ImgBox { Imagen = tl2, Left = 0, Top = 10, Width = 88, Height = 80 });
            else head.Controls.Add(new IconoBox { Emoji = c.Icono, Left = 0, Top = 10, Width = 80, Height = 80, A = Color.FromArgb(150, 70, 255), B = Color.FromArgb(255, 70, 210) });
            head.Controls.Add(Tema.L(c.Nombre.ToUpper(), 10, Tema.Cian, 98, 8, true));
            lblTit = Tema.L("", 24, Color.White, 98, 26, true); lblSub = Tema.L("", 11.5f, Tema.Cian, 98, 68);
            head.Controls.Add(lblTit); head.Controls.Add(lblSub);

            // Muestra el usuario y rol conectado en el panel superior de cada módulo CRUD
            if (!string.IsNullOrWhiteSpace(UsuarioActual))
            {
                var badgeUsr = new Tarjeta
                {
                    Width = 220,
                    Height = 44,
                    Radio = 14,
                    C1 = Color.FromArgb(16, 26, 80),
                    C2 = Color.FromArgb(28, 38, 105),
                    ColorBorde = Color.FromArgb(80, 110, 240),
                    Anchor = AnchorStyles.Top | AnchorStyles.Right,
                    Left = Math.Max(700, ClientSize.Width - 230),
                    Top = 16
                };
                badgeUsr.Controls.Add(new IconoLinea { Key = "\U0001F464", Left = 10, Top = 10, Width = 24, Height = 24, Color = Color.White });
                badgeUsr.Controls.Add(Tema.L(UsuarioActual, 10f, Color.White, 40, 5, true));
                badgeUsr.Controls.Add(Tema.L(RolActual, 8.5f, Tema.Cian, 40, 22));
                head.Controls.Add(badgeUsr);
            }

            var tabs = P(DockStyle.Top, 56, new Padding(0));
            Tabs = new Pestanas { Left = 0, Top = 4, Width = 214 * c.Tabs.Length, Height = 48, Textos = c.Tabs, Claves = new[] { "\U0001F50D", "\u2699", "\U0001F4CA" }.Take(c.Tabs.Length).ToArray() };
            Tabs.Seleccion = c.Tab; tabs.Controls.Add(Tabs);

            bool det = c.Detalle != null;
            var fila = P(DockStyle.Top, 128, new Padding(0)); filaStats = fila;
            var tl = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 4, RowCount = 1, BackColor = Color.Transparent };
            for (int i = 0; i < 4; i++) tl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            for (int i = 0; i < 4; i++)
            {
                Stats[i] = new TarjetaStat { Dock = DockStyle.Fill, Margin = new Padding(0, 4, i < 3 ? 12 : 0, 6), Titulo = c.StatTit[i], Icono = c.StatIco[i], Valor = c.StatVal[i], Tendencia = c.StatTend[i],
                    Glifo = c.StatImg == null ? null : Recursos.Img(c.StatImg[i]), Sub = "vs. mes anterior", Circulo = true, C1 = Cs[i][0], C2 = Cs[i][1], Radio = 18, Opacidad = 255, ColorBorde = Color.FromArgb(120, 255, 255, 255) };
                tl.Controls.Add(Stats[i], i, 0);
            }
            fila.Controls.Add(tl);

            var host = new PanelVistas { Dock = DockStyle.Fill, Padding = new Padding(0, 2, 0, 0), C1 = Color.Transparent, C2 = Color.Transparent, ColorBorde = Color.Transparent, Radio = 0 };
            panelVistas = host;
            host.Resize += (s, e) =>
            {
                if (vistaActual != null && vistaActual.Visible)
                    vistaActual.Bounds = host.DisplayRectangle;
            };
            vC = P(DockStyle.Fill, 0, new Padding(0)); vG = P(DockStyle.Fill, 0, new Padding(0)); vR = P(DockStyle.Fill, 0, new Padding(0));
            // La primera entrada solo necesita Consultar. Las demás vistas se crean
            // cuando se abren por primera vez para reducir el trabajo al navegar.
            ConstruirConsultar(vC);
            host.Controls.Add(vC); host.Controls.Add(vG); host.Controls.Add(vR);

            Controls.Add(host); Controls.Add(fila); Controls.Add(tabs); Controls.Add(head);
            Tabs.Cambio += (s, e) =>
            {
                Vistas();
                if (Tabs.Seleccion == 1 && !string.IsNullOrEmpty(cfg.Clave))
                {
                    EnsureLoaded();
                    if (datosCargando || !datosCargados) return;
                    if (editorDetalle != null)
                    {
                        int codigoPadre = 0;
                        object entidad = BuscarEntidadSeleccionada();
                        if (!nuevoRegistroSolicitado && entidad != null)
                            codigoPadre = Convert.ToInt32(entidad.GetType().GetProperty(cfg.Clave).GetValue(entidad, null));
                        if (editorDetalle.CodigoPadre != codigoPadre) editorDetalle.CambiarPadre(codigoPadre);
                        if (codigoEnEdicion <= 0) editorDetalle.LimpiarCampos();
                    }
                }
            };
            Vistas(); Aplicar();
            ResumeLayout(true);
        }

        void Vistas()
        {
            int t = Tabs.Seleccion;
            if (t == 1 && !gestionarConstruido)
            {
                ConstruirGestionar(vG);
                gestionarConstruido = true;
                Tema.DobleBuffer(vG);
                if (datosCargados) ActualizarRelaciones(opcionesRelaciones);
            }
            if (t == 2 && !resumenConstruido)
            {
                ConstruirResumen(vR);
                resumenConstruido = true;
                Tema.DobleBuffer(vR);
            }
            Panel activa = t == 0 ? vC : t == 1 ? vG : vR;
            if (cfg.Detalle != null && filaStats != null) filaStats.Visible = t != 1;

            // Prepara y muestra la vista nueva antes de ocultar la anterior.
            // Así el contenedor nunca queda vacío durante el cambio de pestaña.
            activa.Dock = DockStyle.None;
            activa.Bounds = panelVistas.DisplayRectangle;
            activa.Visible = true;
            activa.BringToFront();
            vistaActual = activa;

            foreach (Panel vista in new[] { vC, vG, vR })
            {
                if (vista == activa) continue;
                vista.Visible = false;
                vista.Dock = DockStyle.None;
            }

            string n = cfg.Nombre, p = cfg.Plural;
            switch (t)
            {
                case 0: lblTit.Text = "Consultar " + n; lblSub.Text = "Visualiza y administra la información de " + p + " del sistema."; break;
                case 1: lblTit.Text = "Gestionar " + n; lblSub.Text = "Agrega, edita y elimina " + p + " del sistema."; break;
                default: lblTit.Text = "Resumen de " + n; lblSub.Text = "Consulta estadísticas y actividad de " + p + "."; break;
            }
        }

        // ---------------- Consultar ----------------
        void ConstruirConsultar(Panel host)
        {
            bool det = false; // El detalle de compras se consulta y gestiona dentro de Gestionar.
            var card = Card();
            var wrap = P(DockStyle.Fill, 0, new Padding(12, 0, 12, 0));
            Tabla = new Tabla { Dock = DockStyle.Fill }; Tabla.Columnas.AddRange(cfg.Cols);
            if (cfg.Nombre == "Facturaciones" || cfg.Nombre == "Compras" || cfg.Nombre == "Inventarios")
                Tabla.ImprimirClick += ImprimirRegistro;
            wrap.Controls.Add(Tabla);

            var pie = P(DockStyle.Bottom, det ? 48 : 56, new Padding(18, 0, 14, 6));
            Pie = new Label { Dock = DockStyle.Fill, ForeColor = Tema.Sub, Font = Tema.F(9.5f), TextAlign = ContentAlignment.MiddleLeft, BackColor = Color.Transparent };
            var pag = new FlowLayoutPanel { Dock = DockStyle.Right, Width = 390, BackColor = Color.Transparent, Padding = new Padding(0, det ? 4 : 8, 0, 0) };
            botonPaginaAnterior = Pag("‹", false, 34);
            botonPaginaAnterior.Click += (s, e) => CambiarPagina(paginaActual - 1);
            pag.Controls.Add(botonPaginaAnterior);
            for (int i = 1; i <= 5; i++)
            {
                Boton boton = Pag(i.ToString(), i == 1, 34);
                boton.Click += (s, e) =>
                {
                    Boton seleccionado = s as Boton;
                    if (seleccionado != null && seleccionado.Tag is int)
                        CambiarPagina((int)seleccionado.Tag);
                };
                botonesPagina.Add(boton);
                pag.Controls.Add(boton);
            }
            botonPaginaSiguiente = Pag("›", false, 34);
            botonPaginaSiguiente.Click += (s, e) => CambiarPagina(paginaActual + 1);
            pag.Controls.Add(botonPaginaSiguiente);
            var tamPagina = Pag(RegistrosPorPagina + " / página", false, 96);
            pag.Controls.Add(tamPagina);
            ActualizarPaginador(0);
            pie.Controls.Add(Pie); pie.Controls.Add(pag);

            var fil = P(DockStyle.Top, 68, new Padding(14, 10, 14, 6));
            var ts = new Tarjeta { Dock = DockStyle.Fill, Radio = 12, C1 = Tema.Campo, C2 = Tema.Campo, Vidrio = false, Padding = new Padding(44, 12, 12, 4) };
            Buscar = new TextBox { Dock = DockStyle.Fill, BorderStyle = BorderStyle.None, BackColor = Tema.Campo, ForeColor = Color.White, Font = Tema.F(10.5f) };
            Tema.Cue(Buscar, "Buscar en " + cfg.Plural + "...");
            Buscar.TextChanged += (s, e) =>
            {
                AplicarFiltro();
                int solicitud = ++solicitudBusquedaDetalle;
                _ = BuscarCoincidenciasDetalleAsync(Buscar.Text.Trim(), solicitud);
            };
            ts.Controls.Add(Buscar); ts.Controls.Add(new IconoLinea { Key = "\U0001F50D", Color = Color.White, Left = 14, Top = 10, Width = 22, Height = 22 });
            fil.Controls.Add(ts);
            foreach (var spec in cfg.Filtros) fil.Controls.Add(Combo(spec));
            var bg = P(DockStyle.Right, 372, new Padding(12, 0, 0, 0));
            var bf = new FlowLayoutPanel { Dock = DockStyle.Fill, BackColor = Color.Transparent };
            Anadir = Acc(cfg.Detalle != null ? "Nueva" : "Añadir", "\u2795", Color.FromArgb(0, 190, 150), Color.FromArgb(0, 215, 125));
            Editar = Acc("Editar", "\u270F", Color.FromArgb(130, 60, 255), Color.FromArgb(60, 110, 255));
            Eliminar = Acc("Eliminar", "\U0001F5D1", Color.FromArgb(255, 50, 170), Color.FromArgb(225, 40, 130));
            Anadir.Click += (s, e) =>
            {
                nuevoRegistroSolicitado = true;
                Tabs.Seleccion = 1;
                LimpiarFormulario();
                if (cfg.Nombre == "Compras" && editorDetalle != null) editorDetalle.CambiarPadre(0);
            };
            Editar.Click += (s, e) => CargarSeleccionado();
            Eliminar.Click += (s, e) => EliminarSeleccionado();
            bf.Controls.AddRange(new Control[] { Anadir, Editar, Eliminar }); bg.Controls.Add(bf); fil.Controls.Add(bg);
            card.Controls.Add(wrap); card.Controls.Add(pie); card.Controls.Add(fil);

            if (!det) { host.Controls.Add(card); return; }
            var split = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 2, BackColor = Color.Transparent };
            split.RowStyles.Add(new RowStyle(SizeType.Percent, 60)); split.RowStyles.Add(new RowStyle(SizeType.Percent, 40));
            card.Dock = DockStyle.Fill; card.Margin = new Padding(0, 0, 0, 8);
            var dcard = Card(); dcard.Margin = new Padding(0);
            var dw = P(DockStyle.Fill, 0, new Padding(12, 46, 0, 8));
            TablaDet = new Tabla { Dock = DockStyle.Fill }; TablaDet.Columnas.AddRange(cfg.ColsDet);
            var pieDetalle = new Panel { Dock = DockStyle.Bottom, Height = 34, BackColor = Color.Transparent };
            textoPaginacionDetalle = new Label { Dock = DockStyle.Fill, ForeColor = Tema.Sub, Font = Tema.F(8.5f), TextAlign = ContentAlignment.MiddleLeft };
            var botonesDetalle = new FlowLayoutPanel { Dock = DockStyle.Right, Width = 142, BackColor = Color.Transparent, FlowDirection = FlowDirection.RightToLeft, WrapContents = false };
            botonDetalleSiguiente = Pag("Siguiente", false, 72); botonDetalleAnterior = Pag("Anterior", false, 64);
            botonDetalleSiguiente.Height = botonDetalleAnterior.Height = 28;
            botonDetalleSiguiente.Click += (s, e) => CambiarPaginaDetalle(paginaDetalleActual + 1);
            botonDetalleAnterior.Click += (s, e) => CambiarPaginaDetalle(paginaDetalleActual - 1);
            botonesDetalle.Controls.Add(botonDetalleSiguiente); botonesDetalle.Controls.Add(botonDetalleAnterior);
            pieDetalle.Controls.Add(textoPaginacionDetalle); pieDetalle.Controls.Add(botonesDetalle);
            pieDetalle.Visible = cfg.Nombre == "Compras";
            dw.Controls.Add(TablaDet); dw.Controls.Add(pieDetalle);
            var tp = P(DockStyle.Right, 262, new Padding(12, 46, 14, 10));
            totDet = new Totales { Dock = DockStyle.Fill };
            if (cfg.Nombre == "Compras") totDet.EtiquetaIva = "Descuento";
            tp.Controls.Add(totDet);
            lblDet = Tema.L(cfg.TituloDet, 12, Color.White, 18, 14, true);
            dcard.Controls.Add(lblDet); dcard.Controls.Add(dw); dcard.Controls.Add(tp);
            split.Controls.Add(card, 0, 0); split.Controls.Add(dcard, 0, 1); host.Controls.Add(split);
            Tabla.SeleccionCambio += i =>
            {
                MostrarDetalle();
            };
        }

        async void ImprimirRegistro(int indice)
        {
            if (Tabla == null || indice < 0 || indice >= Tabla.Filas.Count)
            {
                return;
            }

            string[] fila = (string[])Tabla.Filas[indice].Clone();
            var datos = new List<KeyValuePair<string, string>>();
            for (int columna = 1; columna < Tabla.Columnas.Count; columna++)
            {
                Tabla.Col columnaTabla = Tabla.Columnas[columna];
                if (columnaTabla.Tipo == "print") continue;
                datos.Add(new KeyValuePair<string, string>(columnaTabla.Titulo,
                    columna < fila.Length ? fila[columna] ?? string.Empty : string.Empty));
            }

            string codigoRegistro = fila.Length > 1 ? fila[1] : string.Empty;
            if (!int.TryParse(codigoRegistro, NumberStyles.Integer, CultureInfo.CurrentCulture, out int codigo))
            {
                AppDialog.Error(this, "No se pudo preparar la impresión",
                    "No fue posible identificar el registro. Actualiza la lista y vuelve a intentarlo.");
                return;
            }

            if (cfg.Nombre == "Inventarios")
            {
                await ImprimirFichaInventario(codigo);
                return;
            }
            if (cfg.Nombre == "Facturaciones")
            {
                await ImprimirFactura(codigo);
                return;
            }
            if (cfg.Nombre == "Compras")
            {
                await ImprimirCompra(codigo);
                return;
            }

            string tituloDocumento = cfg.Nombre == "Compras"
                ? "Comprobante de compra " + codigoRegistro
                : "Ficha de inventario " + codigoRegistro;
            string[] columnasDetalle = new string[0];
            List<string[]> filasDetalle = new List<string[]>();

            try
            {
                if (cfg.Nombre == "Compras")
                {
                    List<object> detalles = await Task.Run(() => ModuloCrud.ListarDetalles(cfg.Nombre));
                    if (IsDisposed || Disposing) return;
                    string propiedadPadre = "CodigoCompra";
                    List<object> detallesDelRegistro = detalles.Where(detalle =>
                        Convert.ToInt32(LeerPropiedad(detalle, propiedadPadre), CultureInfo.InvariantCulture) == codigo).ToList();
                    PrepararDetalleImpresion(detallesDelRegistro, out columnasDetalle, out filasDetalle);
                }

                using (var vistaPrevia = new VistaPreviaDocumento(tituloDocumento, datos, columnasDetalle, filasDetalle))
                {
                    if (vistaPrevia.ShowDialog(this) != DialogResult.OK) return;
                }

                string prefijoArchivo = "Compra";
                using (var dialogo = new SaveFileDialog())
                {
                    dialogo.Title = "Guardar documento PDF";
                    dialogo.Filter = "Documento PDF (*.pdf)|*.pdf";
                    dialogo.DefaultExt = "pdf";
                    dialogo.AddExtension = true;
                    dialogo.FileName = prefijoArchivo + "_" + codigoRegistro + "_" +
                        DateTime.Now.ToString("yyyyMMdd_HHmm", CultureInfo.InvariantCulture) + ".pdf";
                    if (dialogo.ShowDialog(this) != DialogResult.OK) return;

                    ExportadorPdf.GuardarDocumento(tituloDocumento, cfg.Nombre, datos,
                        columnasDetalle, filasDetalle, dialogo.FileName);
                    AppDialog.Success(this, "Documento guardado",
                        "El archivo PDF se guardó correctamente.");
                }
            }
            catch (Exception ex)
            {
                AppDialog.Error(this, "No se pudo guardar el PDF",
                    "No se pudo generar o guardar el documento. Revisa la ubicación e inténtalo nuevamente.", ex);
            }
        }

        async Task ImprimirFactura(int codigoFacturacion)
        {
            try
            {
                FacturaDocumento factura = await Task.Run(
                    () => ModuloCrud.ObtenerDocumentoFactura(codigoFacturacion));
                if (IsDisposed || Disposing) return;
                if (factura == null)
                    throw new InvalidOperationException("La factura seleccionada ya no existe.");

                using (var vistaPrevia = new VistaPreviaDocumento(factura))
                {
                    if (vistaPrevia.ShowDialog(this) != DialogResult.OK) return;
                }

                using (var dialogo = new SaveFileDialog())
                {
                    dialogo.Title = "Guardar factura";
                    dialogo.Filter = "Documento PDF (*.pdf)|*.pdf";
                    dialogo.DefaultExt = "pdf";
                    dialogo.AddExtension = true;
                    dialogo.FileName = "Factura_" +
                        factura.NoFactura.ToString(CultureInfo.InvariantCulture) + "_" +
                        DateTime.Now.ToString("yyyyMMdd_HHmm", CultureInfo.InvariantCulture) + ".pdf";
                    if (dialogo.ShowDialog(this) != DialogResult.OK) return;

                    ExportadorPdf.GuardarFactura(factura, dialogo.FileName);
                    AppDialog.Success(this, "Factura guardada",
                        "El archivo PDF se guardó correctamente.");
                }
            }
            catch (Exception ex)
            {
                if (!IsDisposed && !Disposing)
                    AppDialog.Error(this, "No se pudo guardar la factura",
                        "No se pudo generar o guardar el archivo. Revisa la ubicación e inténtalo nuevamente.", ex);
            }
        }

        async Task ImprimirCompra(int codigoCompra)
        {
            try
            {
                CompraDocumento compra = await Task.Run(
                    () => ModuloCrud.ObtenerDocumentoCompra(codigoCompra));
                if (IsDisposed || Disposing) return;
                if (compra == null)
                    throw new InvalidOperationException("La compra seleccionada ya no existe.");

                using (var vistaPrevia = new VistaPreviaDocumento(compra))
                {
                    if (vistaPrevia.ShowDialog(this) != DialogResult.OK) return;
                }

                string numeroCompra = "COM-" + compra.CodigoCompra.ToString("D6", CultureInfo.InvariantCulture);
                using (var dialogo = new SaveFileDialog())
                {
                    dialogo.Title = "Guardar comprobante de compra";
                    dialogo.Filter = "Documento PDF (*.pdf)|*.pdf";
                    dialogo.DefaultExt = "pdf";
                    dialogo.AddExtension = true;
                    dialogo.FileName = numeroCompra + ".pdf";
                    if (dialogo.ShowDialog(this) != DialogResult.OK) return;

                    ExportadorPdf.GuardarCompra(compra, dialogo.FileName);
                    AppDialog.Success(this, "Comprobante de compra guardado",
                        "El archivo PDF se guardó correctamente.");
                }
            }
            catch (Exception ex)
            {
                if (!IsDisposed && !Disposing)
                    AppDialog.Error(this, "No se pudo guardar el comprobante",
                        "No se pudo generar o guardar el archivo. Revisa la ubicación e inténtalo nuevamente.", ex);
            }
        }

        async Task ImprimirFichaInventario(int codigoInventario)
        {
            try
            {
                FichaInventario ficha = await Task.Run(() => ModuloCrud.ObtenerFichaInventario(codigoInventario));
                if (IsDisposed || Disposing) return;
                if (ficha == null)
                    throw new InvalidOperationException("El registro de inventario ya no existe.");

                using (var vistaPrevia = new VistaPreviaDocumento(ficha))
                {
                    if (vistaPrevia.ShowDialog(this) != DialogResult.OK) return;
                }

                string codigoVisible = "INV-" + ficha.CodigoInventario.ToString("D6", CultureInfo.InvariantCulture);
                using (var dialogo = new SaveFileDialog())
                {
                    dialogo.Title = "Guardar ficha de inventario";
                    dialogo.Filter = "Documento PDF (*.pdf)|*.pdf";
                    dialogo.DefaultExt = "pdf";
                    dialogo.AddExtension = true;
                    dialogo.FileName = codigoVisible + ".pdf";
                    if (dialogo.ShowDialog(this) != DialogResult.OK) return;

                    ExportadorPdf.GuardarFichaInventario(ficha, dialogo.FileName);
                    AppDialog.Success(this, "Ficha de inventario guardada",
                        "El archivo PDF se guardó correctamente.");
                }
            }
            catch (Exception ex)
            {
                if (!IsDisposed && !Disposing)
                    AppDialog.Error(this, "No se pudo guardar la ficha de inventario",
                        "No se pudo generar o guardar el archivo. Revisa la ubicación e inténtalo nuevamente.", ex);
            }
        }

        void PrepararDetalleImpresion(List<object> detalles, out string[] columnas, out List<string[]> filas)
        {
            filas = new List<string[]>();
            if (cfg.Nombre == "Facturaciones")
            {
                columnas = new[] { "Cantidad", "Descripción", "Precio unitario", "Descuento", "Importe" };
                foreach (object detalle in detalles)
                {
                    int cantidad = Convert.ToInt32(LeerPropiedad(detalle, "Cantidad"), CultureInfo.InvariantCulture);
                    decimal precio = Convert.ToDecimal(LeerPropiedad(detalle, "Precio"), CultureInfo.InvariantCulture);
                    decimal descuento = Convert.ToDecimal(LeerPropiedad(detalle, "DescuentoAplicado"), CultureInfo.InvariantCulture);
                    filas.Add(new[]
                    {
                        cantidad.ToString(CultureInfo.CurrentCulture),
                        Convert.ToString(LeerPropiedad(detalle, "Descripcion"), CultureInfo.CurrentCulture) ?? string.Empty,
                        FormatearMoneda(precio),
                        FormatearMoneda(descuento),
                        FormatearMoneda(cantidad * precio - descuento)
                    });
                }
                return;
            }

            columnas = new[] { "Tipo", "Descripción", "Precio unitario", "Subtotal", "Descuento" };
            foreach (object detalle in detalles)
            {
                filas.Add(new[]
                {
                    Convert.ToString(LeerPropiedad(detalle, "TipoDeCompra"), CultureInfo.CurrentCulture) ?? string.Empty,
                    Convert.ToString(LeerPropiedad(detalle, "Descripcion"), CultureInfo.CurrentCulture) ?? string.Empty,
                    FormatearMoneda(Convert.ToDecimal(LeerPropiedad(detalle, "PrecioUnitario"), CultureInfo.InvariantCulture)),
                    FormatearMoneda(Convert.ToDecimal(LeerPropiedad(detalle, "Subtotal"), CultureInfo.InvariantCulture)),
                    FormatearMoneda(Convert.ToDecimal(LeerPropiedad(detalle, "DescuentoCompra"), CultureInfo.InvariantCulture))
                });
            }
        }

        static object LeerPropiedad(object instancia, string nombre)
        {
            var propiedad = instancia.GetType().GetProperty(nombre);
            if (propiedad == null)
                throw new InvalidOperationException("No se encontró la propiedad " + nombre + " del detalle.");
            return propiedad.GetValue(instancia, null);
        }

        static string FormatearMoneda(decimal valor)
        {
            return "Q " + valor.ToString("N2", CultureInfo.GetCultureInfo("es-GT"));
        }

        async Task BuscarCoincidenciasDetalleAsync(string texto, int solicitud)
        {
            if (cfg.Nombre != "Compras" && cfg.Nombre != "Facturaciones") return;
            try
            {
                await Task.Delay(350);
                if (IsDisposed || Disposing || solicitud != solicitudBusquedaDetalle ||
                    !string.Equals(texto, Buscar.Text.Trim(), StringComparison.Ordinal)) return;

                HashSet<int> coincidencias = await Task.Run(() =>
                {
                    if (texto.Length == 0) return new HashSet<int>();
                    return cfg.Nombre == "Compras"
                        ? new HashSet<int>(ModuloCrud.BuscarDetallesCompra(texto).Select(x => x.CodigoCompra))
                        : new HashSet<int>(ModuloCrud.BuscarDetallesFactura(texto).Select(x => x.CodigoFacturacion));
                });

                if (IsDisposed || Disposing || solicitud != solicitudBusquedaDetalle ||
                    !string.Equals(texto, Buscar.Text.Trim(), StringComparison.Ordinal)) return;
                coincidenciasDetalle = coincidencias;
                terminoCoincidenciasDetalle = texto;
                Aplicar();
            }
            catch (Exception ex)
            {
                if (IsDisposed || Disposing || solicitud != solicitudBusquedaDetalle) return;
                AppDialog.Error(this, "No se pudo buscar en el detalle",
                    "Revisa la conexión e inténtalo nuevamente.", ex);
            }
        }

        void Aplicar()
        {
            _ = AplicarAsync(false, false);
        }

        sealed class ResultadoFiltro
        {
            public List<string[]> Filas;
            public int Total;
            public int Pagina;
        }

        async Task AplicarAsync(bool reiniciarPagina, bool esperar)
        {
            int solicitud = ++solicitudFiltro;
            string termino = (Buscar == null ? "" : Buscar.Text ?? "").Trim();
            string plural = cfg.Plural;
            string nombreModulo = cfg.Nombre;
            string terminoDetalle = terminoCoincidenciasDetalle;
            HashSet<int> detalle = terminoDetalle == termino
                ? new HashSet<int>(coincidenciasDetalle) : new HashSet<int>();
            List<string> filtros = Combos.Where(x => x.Seleccion > 0)
                .Select(x => x.Texto).ToList();
            string[][] origen = cfg.Filas ?? new string[0][];
            int paginaSolicitada = reiniciarPagina ? 1 : paginaActual;

            try
            {
                if (esperar) await Task.Delay(180);
                if (IsDisposed || Disposing || solicitud != solicitudFiltro) return;

                ResultadoFiltro resultado = await Task.Run(() =>
                {
                    IEnumerable<string[]> consulta = origen;
                    if (termino.Length > 0)
                    {
                        bool buscarEnDetalle = nombreModulo == "Compras" || nombreModulo == "Facturaciones";
                        consulta = consulta.Where(fila =>
                            fila.Any(valor => valor != null && valor.IndexOf(termino, StringComparison.OrdinalIgnoreCase) >= 0)
                            || (buscarEnDetalle && fila.Length > 1 &&
                                int.TryParse(fila[1], out int codigo) && detalle.Contains(codigo)));
                    }
                    foreach (string filtro in filtros)
                        consulta = consulta.Where(fila => fila.Any(valor =>
                            string.Equals(valor, filtro, StringComparison.OrdinalIgnoreCase)));

                    List<string[]> lista = consulta.ToList();
                    int total = lista.Count;
                    int totalPaginas = Math.Max(1, (int)Math.Ceiling(total / (double)RegistrosPorPagina));
                    int pagina = Math.Max(1, Math.Min(paginaSolicitada, totalPaginas));
                    List<string[]> visibles = lista.Skip((pagina - 1) * RegistrosPorPagina)
                        .Take(RegistrosPorPagina).ToList();
                    return new ResultadoFiltro { Filas = visibles, Total = total, Pagina = pagina };
                });

                if (IsDisposed || Disposing || solicitud != solicitudFiltro) return;
                paginaActual = resultado.Pagina;
                if (resultado.Total == 0 && (termino.Length > 0 || filtros.Count > 0))
                {
                    Tabla.TituloVacio = "Sin resultados";
                    Tabla.TextoVacio = "Prueba con otro texto o cambia los filtros.";
                }
                else
                {
                    Tabla.TituloVacio = "Aún no hay registros";
                    Tabla.TextoVacio = "Presiona \"Añadir\" para agregar el primero.";
                }
                int desde = resultado.Total == 0 ? 0 : (paginaActual - 1) * RegistrosPorPagina + 1;
                int hasta = resultado.Total == 0 ? 0 : desde + resultado.Filas.Count - 1;
                Pie.Text = string.Format("Mostrando {0} - {1} de {2} {3}", desde, hasta, resultado.Total, plural);
                ActualizarPaginador(resultado.Total);

                int seleccionAnterior = Tabla.Seleccion;
                Tabla.Filas.Clear(); Tabla.Filas.AddRange(resultado.Filas); Tabla.Marcadas.Clear();
                Tabla.InvalidarAnchosColumnas();
                // Al abrir o actualizar una consulta, el usuario elige explícitamente la fila.
                Tabla.Seleccion = -1; Tabla.Invalidate();
                if ((nombreModulo == "Compras" || nombreModulo == "Facturaciones") && seleccionAnterior == Tabla.Seleccion)
                    MostrarDetalle();
            }
            catch (Exception ex)
            {
                if (!IsDisposed && !Disposing && solicitud == solicitudFiltro)
                    AppDialog.Error(this, "No se pudo completar la búsqueda",
                        "Revisa los filtros y la conexión, y vuelve a intentarlo.", ex);
            }
        }

        void CambiarPagina(int pagina)
        {
            paginaActual = Math.Max(1, pagina);
            Aplicar();
        }

        void AplicarFiltro()
        {
            _ = AplicarAsync(true, true);
        }

        void ActualizarPaginador(int totalRegistros)
        {
            if (botonesPagina.Count == 0) return;

            int totalPaginas = Math.Max(1, (int)Math.Ceiling(totalRegistros / (double)RegistrosPorPagina));
            paginaActual = Math.Max(1, Math.Min(paginaActual, totalPaginas));
            botonPaginaAnterior.Enabled = paginaActual > 1;
            botonPaginaSiguiente.Enabled = paginaActual < totalPaginas;

            int primeraPagina = Math.Max(1, paginaActual - 2);
            if (primeraPagina + botonesPagina.Count - 1 > totalPaginas)
                primeraPagina = Math.Max(1, totalPaginas - botonesPagina.Count + 1);

            for (int i = 0; i < botonesPagina.Count; i++)
            {
                int numeroPagina = primeraPagina + i;
                Boton boton = botonesPagina[i];
                boton.Visible = numeroPagina <= totalPaginas;
                if (!boton.Visible) continue;

                boton.Texto = numeroPagina.ToString(CultureInfo.CurrentCulture);
                boton.Tag = numeroPagina;
                bool activa = numeroPagina == paginaActual;
                boton.C1 = activa ? Tema.Morado : Tema.Campo;
                boton.C2 = activa ? Tema.Rosa : Tema.Campo;
                boton.Invalidate();
            }
        }

        // Se consulta Negocio al abrir por primera vez el módulo, no al construir todos los menús.
        public async void EnsureLoaded()
        {
            if (datosCargados || datosCargando || string.IsNullOrEmpty(cfg.Clave)) return;
            datosCargando = true;
            Pie.Text = "Cargando " + cfg.Plural + "...";
            Tabla.TituloVacio = "Cargando datos...";
            Tabla.TextoVacio = "Preparando la consulta.";
            Tabla.Invalidate();
            try
            {
                // Ejecuta en paralelo las lecturas independientes del módulo. Así el
                // tiempo de espera no se suma por cada consulta a SQL Server.
                CargaModulo carga = await LeerDatosAsync();
                if (IsDisposed || Disposing) return;

                registros = carga.Registros;
                opcionesRelaciones = carga.Opciones;
                if (gestionarConstruido) ActualizarRelaciones(opcionesRelaciones);
                // Facturaciones carga el detalle al elegir una factura, de forma asíncrona.
                CargarDetalles(null);
                string[] columnasFila = cfg.ColumnasPropiedades;
                CultureInfo cultura = CultureInfo.CurrentCulture;
                cfg.Filas = await Task.Run(() =>
                {
                    string[][] filas = new string[registros.Count][];
                    for (int i = 0; i < registros.Count; i++)
                    {
                        string[] fila = new string[columnasFila.Length + 2];
                        fila[0] = string.Empty;
                        for (int j = 0; j < columnasFila.Length; j++)
                            fila[j + 1] = FormatearParaTabla(registros[i], columnasFila[j], cultura);
                        fila[fila.Length - 1] = string.Empty;
                        filas[i] = fila;
                    }
                    return filas;
                });
                if (IsDisposed || Disposing) return;
                cfg.Total = registros.Count;
                datosCargados = true;
                ActualizarIndicadores(registros);
                if (barraResumen != null)
                {
                    barraResumen.Filas.Clear();
                    barraResumen.Filas.AddRange(cfg.Filas);
                    barraResumen.Invalidate();
                }
                // Espera a que Consultar aplique las filas antes de cerrar el estado
                // de carga; así el pie y la tabla no quedan desincronizados.
                await AplicarAsync(false, false);

                // Si Gestionar esta abierto mientras termina la consulta inicial,
                // conserva el formulario nuevo vacio y sin seleccionar una fila.
                if (Tabs.Seleccion == 1 && !nuevoRegistroSolicitado && codigoEnEdicion <= 0)
                    LimpiarCamposEncabezado();
            }
            catch (Exception ex)
            {
                datosCargados = false;
                if (IsDisposed || Disposing) return;
                cfg.Filas = new string[0][];
                cfg.Total = 0;
                Tabla.TituloVacio = "No se pudieron cargar los datos";
                Tabla.TextoVacio = "Revisa la conexión y vuelve a intentarlo.";
                Aplicar();
                AppDialog.Error(this, "No se pudieron cargar los datos",
                    "Revisa la conexión e inténtalo nuevamente.", ex);
            }
            finally
            {
                datosCargando = false;
                // Evita dejar el mensaje inicial si la carga terminó antes de actualizar la tabla.
                if (!IsDisposed && !Disposing && datosCargados && Pie != null)
                {
                    int cantidad = Tabla == null ? 0 : Tabla.Filas.Count;
                    int total = cfg.Total;
                    int desde = cantidad == 0 ? 0 : (paginaActual - 1) * RegistrosPorPagina + 1;
                    int hasta = cantidad == 0 ? 0 : desde + cantidad - 1;
                    Pie.Text = string.Format("Mostrando {0} - {1} de {2} {3}", desde, hasta, total, cfg.Plural);
                    Pie.Invalidate();
                }
            }
        }

        async Task<CargaModulo> LeerDatosAsync()
        {
            // Una sola tarea de fondo consulta registros y catálogos en orden.
            // Reutiliza la conexión del pool y evita cambios de hilo por cada consulta.
            string modulo = cfg.Nombre;
            string[] campos = cfg.Campos;
            return await Task.Run(() =>
            {
                var carga = new CargaModulo();
                carga.Registros = ModuloCrud.Listar(modulo);
                foreach (string campo in campos)
                {
                    string propiedad = PropiedadCampo(campo);
                    if (ModuloCrud.EsRelacion(propiedad) && !carga.Opciones.ContainsKey(propiedad))
                        carga.Opciones.Add(propiedad, ModuloCrud.Opciones(propiedad));
                }
                return carga;
            });
        }

        static string Formatear(object entidad, string propiedad)
        {
            return Formatear(entidad, propiedad, CultureInfo.CurrentCulture);
        }

        static string Formatear(object entidad, string propiedad, CultureInfo cultura)
        {
            var p = entidad.GetType().GetProperty(propiedad);
            if (p == null) return string.Empty;
            object valor = p.GetValue(entidad, null);
            if (valor == null) return string.Empty;
            if (valor is bool) return (bool)valor ? "Activo" : "Inactivo";
            if (valor is DateTime) return ((DateTime)valor).ToString("dd/MM/yyyy", cultura);
            if (valor is TimeSpan) return ((TimeSpan)valor).ToString(@"hh\:mm");
            if (valor is decimal) return ((decimal)valor).ToString("N2", CultureInfo.GetCultureInfo("es-GT"));
            return Convert.ToString(valor, cultura);
        }

        string FormatearParaTabla(object entidad, string propiedad, CultureInfo cultura)
        {
            bool mostrarRelacion = (cfg.Nombre == "Compras" &&
                (propiedad == "CodigoProveedor" || propiedad == "CodigoMaterial")) ||
                (cfg.Nombre == "Facturaciones" && propiedad == "CodigoOrdenTrabajo");
            if (mostrarRelacion)
            {
                var propiedadInfo = entidad.GetType().GetProperty(propiedad);
                if (propiedadInfo != null)
                {
                    int codigo = Convert.ToInt32(propiedadInfo.GetValue(entidad, null), CultureInfo.InvariantCulture);
                    List<ModuloCrud.Opcion> opciones;
                    if (opcionesRelaciones.TryGetValue(propiedad, out opciones))
                    {
                        ModuloCrud.Opcion opcion = opciones.FirstOrDefault(x => x.Codigo == codigo);
                        if (opcion != null) return opcion.Texto;
                    }
                    return "Código " + codigo.ToString(cultura);
                }
            }
            return Formatear(entidad, propiedad, cultura);
        }

        void ActualizarRelaciones(Dictionary<string, List<ModuloCrud.Opcion>> opciones)
        {
            for (int i = 0; i < cfg.Campos.Length; i++)
            {
                var selector = inputs[i] as Selector;
                string propiedad = PropiedadCampo(cfg.Campos[i]);
                if (selector == null || !ModuloCrud.EsRelacion(propiedad)) continue;

                List<ModuloCrud.Opcion> lista;
                if (!opciones.TryGetValue(propiedad, out lista)) continue;
                selector.Items.Clear();
                selector.Codigos.Clear();
                foreach (var opcion in lista)
                {
                    selector.Items.Add(opcion.Codigo + " - " + opcion.Texto);
                    selector.Codigos.Add(opcion.Codigo);
                }
                opcionesFijas[selector] = selector.Items.ToList();
                // Las relaciones quedan sin seleccionar en un formulario nuevo.
                // CargarCampos elige la relacion cuando se pulsa Editar.
                selector.Seleccion = -1;
            }
        }

        static Dictionary<string, string[][]> PrepararDetalles(List<object> detalles, string nombreModulo,
            string[] columnasDetalle)
        {
            var agrupadas = new Dictionary<string, List<string[]>>();
            if (detalles == null || columnasDetalle == null || nombreModulo == "Compras")
                return new Dictionary<string, string[][]>();

            string propiedadPadre = nombreModulo == "Compras" ? "CodigoCompra" : "CodigoFacturacion";
            foreach (object detalle in detalles ?? new List<object>())
            {
                object valorPadre = detalle.GetType().GetProperty(propiedadPadre).GetValue(detalle, null);
                string llave = Convert.ToString(valorPadre, CultureInfo.InvariantCulture);
                string[] fila = new string[columnasDetalle.Length];
                for (int i = 0; i < columnasDetalle.Length; i++)
                    fila[i] = Formatear(detalle, columnasDetalle[i]);
                if (!agrupadas.ContainsKey(llave)) agrupadas.Add(llave, new List<string[]>());
                agrupadas[llave].Add(fila);
            }

            return agrupadas.ToDictionary(par => par.Key, par => par.Value.ToArray());
        }

        void CargarDetalles(Dictionary<string, string[][]> detalles)
        {
            // Compras carga sus detalles al seleccionar una compra, no al iniciar el módulo.
            if (cfg.Detalle == null) return;
            cfg.Detalle.Clear();
            if (detalles == null) return;
            foreach (var par in detalles)
                cfg.Detalle.Add(par.Key, par.Value);
        }

        async void CargarDetalles()
        {
            try
            {
                List<object> detalles = await Task.Run(() => ModuloCrud.ListarDetalles(cfg.Nombre));
                if (IsDisposed || Disposing) return;
                Dictionary<string, string[][]> preparados = await Task.Run(() =>
                    PrepararDetalles(detalles, cfg.Nombre, cfg.ColumnasDetallePropiedades));
                if (IsDisposed || Disposing) return;
                CargarDetalles(preparados);
                MostrarDetalle();
            }
            catch (Exception ex)
            {
                if (IsDisposed || Disposing) return;
                AppDialog.Error(this, "No se pudo actualizar el detalle",
                    "Revisa la conexión e inténtalo nuevamente.", ex);
            }
        }

        void ActualizarIndicadores(List<object> registros)
        {
            int activos = registros.Count(x => (bool)x.GetType().GetProperty("Estado").GetValue(x, null));
            Stats[0].Valor = registros.Count.ToString();
            Stats[1].Valor = activos.ToString();
            Stats[2].Valor = (registros.Count - activos).ToString();
            Stats[3].Valor = registros.Count.ToString();
            for (int i = 0; i < Stats.Length; i++) Stats[i].Invalidate();
        }

        string PropiedadCampo(string especificacion)
        {
            int dosPuntos = especificacion.IndexOf(':');
            string rotuloYPropiedad = dosPuntos < 0 ? especificacion : especificacion.Substring(0, dosPuntos);
            int separador = rotuloYPropiedad.IndexOf('|');
            return separador < 0 ? rotuloYPropiedad : rotuloYPropiedad.Substring(separador + 1);
        }

        object CrearEntidad()
        {
            object entidad = Activator.CreateInstance(ModuloCrud.TipoEntidad(cfg.Nombre));
            for (int i = 0; i < cfg.Campos.Length; i++)
            {
                string especificacion = cfg.Campos[i];
                int dosPuntos = especificacion.IndexOf(':');
                string tipo = especificacion.Substring(dosPuntos + 1);
                string propiedad = PropiedadCampo(especificacion);
                var p = entidad.GetType().GetProperty(propiedad);
                if (p == null) throw new InvalidOperationException("No existe el campo " + propiedad + " en la entidad.");

                Control control = inputs[i];
                string texto = control is CampoTexto ? ((CampoTexto)control).Caja.Text.Trim() :
                    control is Selector ? ((Selector)control).Texto : string.Empty;
                object valor;
                var numerico = control as CampoNumero;
                if (numerico != null)
                {
                    if (numerico.EstaVacio) throw new ArgumentException("Completa el campo " + especificacion.Substring(0, dosPuntos) + ".");
                    valor = Convert.ChangeType(numerico.Valor, Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType, CultureInfo.InvariantCulture);
                }
                else if (control is Selector && p.PropertyType == typeof(int))
                {
                    var seleccion = (Selector)control;
                    if (seleccion.Seleccion < 0 || seleccion.Seleccion >= seleccion.Codigos.Count)
                        throw new ArgumentException("Selecciona un valor para " + especificacion.Substring(0, dosPuntos) + ".");
                    valor = seleccion.Codigos[seleccion.Seleccion];
                }
                else if (control is Selector && p.PropertyType == typeof(string))
                {
                    var seleccion = (Selector)control;
                    if (seleccion.Seleccion < 0 || seleccion.Seleccion >= seleccion.Items.Count)
                        throw new ArgumentException("Selecciona un valor para " + especificacion.Substring(0, dosPuntos) + ".");
                    valor = seleccion.Texto;
                }
                else if (p.PropertyType == typeof(bool))
                {
                    var seleccion = control as Selector;
                    if (seleccion == null || seleccion.Seleccion < 0 || seleccion.Seleccion >= seleccion.Items.Count)
                        throw new ArgumentException("Selecciona un valor para " + especificacion.Substring(0, dosPuntos) + ".");
                    valor = texto == "Activo";
                }
                else if (p.PropertyType == typeof(int?)) valor = string.IsNullOrWhiteSpace(texto) ? null : (object)int.Parse(texto, CultureInfo.CurrentCulture);
                else if (p.PropertyType == typeof(int)) valor = int.Parse(texto, CultureInfo.CurrentCulture);
                else if (p.PropertyType == typeof(decimal)) valor = decimal.Parse(texto, CultureInfo.CurrentCulture);
                else if (control is CampoFecha)
                {
                    var fecha = (CampoFecha)control;
                    valor = fecha.Fecha.Date;
                }
                else if (p.PropertyType == typeof(DateTime)) valor = DateTime.Parse(texto, CultureInfo.CurrentCulture);
                else if (p.PropertyType == typeof(TimeSpan)) valor = TimeSpan.Parse(texto, CultureInfo.CurrentCulture);
                else valor = texto;
                p.SetValue(entidad, valor, null);
            }
            var clave = entidad.GetType().GetProperty(cfg.Clave);
            if (clave != null) clave.SetValue(entidad, codigoEnEdicion, null);
            return entidad;
        }

        object BuscarEntidadSeleccionada()
        {
            if (Tabla.Seleccion < 0 || Tabla.Seleccion >= Tabla.Filas.Count) return null;
            int codigo;
            if (!int.TryParse(Tabla.Filas[Tabla.Seleccion][1], out codigo)) return null;
            return registros.FirstOrDefault(x => Convert.ToInt32(x.GetType().GetProperty(cfg.Clave).GetValue(x, null)) == codigo);
        }

        void CargarSeleccionado()
        {
            try
            {
                if (!datosCargados) { EnsureLoaded(); return; }
                object entidad = BuscarEntidadSeleccionada();
                if (entidad == null)
                {
                    AppDialog.Warning(this, "Selecciona un registro",
                        "Elige una fila de la tabla antes de editar.");
                    return;
                }
                nuevoRegistroSolicitado = false;
                codigoEnEdicion = Convert.ToInt32(entidad.GetType().GetProperty(cfg.Clave).GetValue(entidad, null));
                Tabs.Seleccion = 1;
                CargarCampos(entidad);
                if (cfg.Nombre != "Compras") MostrarDetalle();
            }
            catch (Exception ex)
            {
                AppDialog.Error(this, "No se pudo abrir el registro",
                    "Actualiza la lista e inténtalo nuevamente.", ex);
            }
        }

        void CargarCampos(object entidad)
        {
            cargandoCamposFormulario = true;
            try
            {
                for (int i = 0; i < cfg.Campos.Length; i++)
            {
                string propiedad = PropiedadCampo(cfg.Campos[i]);
                var propiedadInfo = entidad.GetType().GetProperty(propiedad);
                if (propiedadInfo == null)
                    throw new InvalidOperationException("No existe el campo " + propiedad + " en el registro seleccionado.");
                object valor = propiedadInfo.GetValue(entidad, null);
                var texto = inputs[i] as CampoTexto;
                var numero = inputs[i] as CampoNumero;
                var fecha = inputs[i] as CampoFecha;
                var selector = inputs[i] as Selector;
                if (texto != null) texto.Caja.Text = valor == null ? string.Empty : Convert.ToString(valor, CultureInfo.CurrentCulture);
                if (numero != null) numero.Valor = valor == null ? 0 : Convert.ToDecimal(valor, CultureInfo.CurrentCulture);
                if (fecha != null)
                {
                    if (valor == null) fecha.Limpiar();
                    else fecha.Establecer(Convert.ToDateTime(valor, CultureInfo.CurrentCulture));
                }
                if (selector != null)
                {
                    if (valor == null)
                    {
                        selector.Seleccion = -1;
                    }
                    else if (propiedadInfo.PropertyType == typeof(bool))
                    {
                        selector.Seleccion = selector.Items.IndexOf((bool)valor ? "Activo" : "Inactivo");
                    }
                    else if (propiedadInfo.PropertyType == typeof(string))
                    {
                        string opcionActual = Convert.ToString(valor, CultureInfo.CurrentCulture);
                        int indice = selector.Items.FindIndex(x => string.Equals(x, opcionActual, StringComparison.CurrentCultureIgnoreCase));
                        // Conserva valores existentes que ya no aparecen en las opciones para crear registros.
                        if (indice < 0 && opcionActual.Length > 0)
                        {
                            selector.Items.Add(opcionActual);
                            indice = selector.Items.Count - 1;
                        }
                        selector.Seleccion = indice;
                    }
                    else
                    {
                        int codigo = Convert.ToInt32(valor, CultureInfo.CurrentCulture);
                        int indice = selector.Codigos.IndexOf(codigo);
                        // Permite ver y conservar una relación existente aunque su opción ya no esté disponible.
                        if (indice < 0)
                        {
                            selector.Items.Add(codigo.ToString(CultureInfo.CurrentCulture) + " - relación no disponible");
                            selector.Codigos.Add(codigo);
                            indice = selector.Codigos.Count - 1;
                        }
                        selector.Seleccion = indice;
                    }
                }
            }
            if (TablaGes != null) { TablaGes.Filas.Clear(); TablaGes.InvalidarAnchosColumnas(); TablaGes.Invalidate(); }
            // En Compras, MostrarCompraSeleccionada carga encabezado y detalle
            // juntos para evitar consultar dos veces el mismo detalle.
            if (editorDetalle != null && cfg.Nombre != "Compras") editorDetalle.CambiarPadre(codigoEnEdicion);
            }
            finally
            {
                cargandoCamposFormulario = false;
            }
            if (cfg.Nombre == "Facturaciones" && codigoEnEdicion <= 0)
            {
                for (int i = 0; i < cfg.Campos.Length; i++)
                {
                    if (PropiedadCampo(cfg.Campos[i]) == "NoFactura")
                    {
                        var numFac = inputs[i] as CampoNumero;
                        if (numFac != null && numFac.Valor == 0)
                        {
                            var numerosUsados = new HashSet<int>();
                            foreach (var obj in registros)
                            {
                                var f = obj as Factura;
                                if (f != null && f.NoFactura > 0) numerosUsados.Add(f.NoFactura);
                            }

                            // Reutiliza el primer número libre para no saltar a 1000 por el máximo histórico.
                            int siguiente = 1;
                            while (numerosUsados.Contains(siguiente)) siguiente++;
                            numFac.Valor = siguiente;
                        }
                        break;
                    }
                }
            }
            RecalcularCamposCalculados();
        }

        void GuardarFormulario()
        {
            try
            {
                if (!datosCargados) { EnsureLoaded(); return; }
                object entidad = CrearEntidad();
                if (cfg.Nombre == "Facturaciones")
                {
                    bool editar = codigoEnEdicion > 0;
                    // Valida y prepara el detalle antes de guardar la factura.
                    DetalleFactura detalle = editorDetalle.ObtenerDetalleParaGuardar(codigoEnEdicion, !editar);
                    int codigoFactura;
                    if (!editar)
                    {
                        codigoFactura = ModuloCrud.GuardarFacturaConDetalle((Factura)entidad, detalle);
                    }
                    else if (detalle != null)
                    {
                        detalle.CodigoFacturacion = codigoEnEdicion;
                        codigoFactura = detalle.CodigoDetalleFactura > 0
                            ? ModuloCrud.ActualizarFacturaConDetalle((Factura)entidad, detalle)
                            : ModuloCrud.ActualizarFacturaConNuevoDetalle((Factura)entidad, detalle);
                    }
                    else codigoFactura = ModuloCrud.GuardarFactura((Factura)entidad, true);
                    editorDetalle.Recargar(codigoFactura);
                }
                else if (cfg.Nombre == "Compras")
                {
                    bool editar = codigoEnEdicion > 0;
                    // Los controles existentes preparan el detalle antes de abrir la transacción.
                    DetalleCompra detalle = editorDetalle.ObtenerDetalleCompraParaGuardar(!editar);
                    int codigoCompra;
                    if (!editar)
                    {
                        codigoCompra = ModuloCrud.GuardarCompraConDetalle((Compra)entidad, detalle);
                    }
                    else if (detalle != null)
                    {
                        detalle.CodigoCompra = codigoEnEdicion;
                        codigoCompra = ModuloCrud.ActualizarCompraConDetalle((Compra)entidad, detalle);
                    }
                    else
                    {
                        codigoCompra = ModuloCrud.GuardarCompra((Compra)entidad, true);
                    }
                    editorDetalle.Recargar(codigoCompra);
                }
                else ModuloCrud.Guardar(cfg.Nombre, entidad, codigoEnEdicion > 0);
                datosCargados = false;
                nuevoRegistroSolicitado = false;
                EnsureLoaded();
                LimpiarFormulario();
                Tabs.Seleccion = 0;
                AppDialog.Success(this, "Cambios guardados",
                    "La información de " + cfg.Nombre + " se guardó correctamente.");
            }
            catch (Exception ex)
            {
                AppDialog.Error(this, "No se pudieron guardar los datos",
                    "Revisa los campos obligatorios y la conexión. Corrige los datos e inténtalo nuevamente.", ex);
            }
        }

        void EliminarSeleccionado()
        {
            try
            {
                if (!datosCargados) { EnsureLoaded(); return; }
                object entidad = BuscarEntidadSeleccionada();
                if (entidad == null)
                {
                    AppDialog.Warning(this, "Selecciona un registro",
                        "Elige una fila de la tabla antes de eliminar.");
                    return;
                }
                int codigo = Convert.ToInt32(entidad.GetType().GetProperty(cfg.Clave).GetValue(entidad, null));
                if (!AppDialog.Confirm(this, "Confirmar eliminación",
                    "¿Deseas eliminar el registro " + codigo + "? Esta acción no se puede deshacer.",
                    "Eliminar", true)) return;
                ModuloCrud.Eliminar(cfg.Nombre, codigo);
                datosCargados = false;
                EnsureLoaded();
            }
            catch (Exception ex)
            {
                AppDialog.Error(this, "No se pudo eliminar el registro",
                    "Verifica que el registro no esté relacionado con otros datos e inténtalo nuevamente.", ex);
            }
        }

        void LimpiarFormulario()
        {
            LimpiarCamposEncabezado();
            // En factura se limpia el detalle al iniciar un registro nuevo.
            if (editorDetalle != null && cfg.Nombre != "Compras") editorDetalle.CambiarPadre(codigoEnEdicion);
        }

        void LimpiarCamposEncabezado()
        {
            cargandoCamposFormulario = true;
            try
            {
                codigoEnEdicion = 0;
            foreach (var opcion in opcionesFijas)
            {
                opcion.Key.Items.Clear();
                opcion.Key.Items.AddRange(opcion.Value);
            }
            for (int i = 0; i < cfg.Campos.Length; i++)
            {
                var texto = inputs[i] as CampoTexto;
                var numero = inputs[i] as CampoNumero;
                var fecha = inputs[i] as CampoFecha;
                var selector = inputs[i] as Selector;
                if (texto != null) texto.Caja.Clear();
                if (numero != null) numero.Limpiar();
                if (fecha != null) fecha.Limpiar();
                if (selector != null)
                {
                    selector.Seleccion = PropiedadCampo(cfg.Campos[i]) == "Estado" ? 1 : -1;
                }
            }
            }
            finally
            {
                cargandoCamposFormulario = false;
            }
            RecalcularCamposCalculados();
        }

        CampoNumero ObtenerCampoNumero(string propiedad)
        {
            for (int i = 0; i < cfg.Campos.Length; i++)
            {
                if (PropiedadCampo(cfg.Campos[i]) == propiedad)
                    return inputs[i] as CampoNumero;
            }
            return null;
        }

        void ConfigurarCalculosAutomaticos()
        {
            string[] propiedadesOrigen;
            switch (cfg.Nombre)
            {
                case "Tipo de Servicio":
                    propiedadesOrigen = new[] { "CostoServicio", "RecargoServicio" };
                    break;
                case "Cotizaciones":
                    propiedadesOrigen = new[] { "Cantidad", "Precio" };
                    break;
                case "Facturaciones":
                    propiedadesOrigen = new[] { "Subtotal" };
                    break;
                case "Compras":
                    propiedadesOrigen = new string[0];
                    break;
                default:
                    return;
            }

            for (int i = 0; i < cfg.Campos.Length; i++)
            {
                if (!propiedadesOrigen.Contains(PropiedadCampo(cfg.Campos[i]))) continue;
                var numero = inputs[i] as CampoNumero;
                if (numero != null)
                    numero.Num.ValueChanged += (s, e) => RecalcularCamposCalculados();
            }
            RecalcularCamposCalculados();
        }

        void RecalcularCamposCalculados()
        {
            if (cargandoCamposFormulario || calculandoCamposCalculados) return;
            calculandoCamposCalculados = true;
            try
            {
                if (cfg.Nombre == "Tipo de Servicio")
                {
                    CampoNumero costo = ObtenerCampoNumero("CostoServicio");
                    CampoNumero recargo = ObtenerCampoNumero("RecargoServicio");
                    CampoNumero total = ObtenerCampoNumero("TotalServicio");
                    if (costo != null && recargo != null && total != null)
                        total.Valor = decimal.Round(costo.Valor + recargo.Valor, 2);
                }
                else if (cfg.Nombre == "Cotizaciones")
                {
                    CampoNumero cantidad = ObtenerCampoNumero("Cantidad");
                    CampoNumero precio = ObtenerCampoNumero("Precio");
                    CampoNumero subtotal = ObtenerCampoNumero("Subtotal");
                    CampoNumero total = ObtenerCampoNumero("Total");
                    if (cantidad != null && precio != null && subtotal != null && total != null)
                    {
                        subtotal.Valor = decimal.Round(cantidad.Valor * precio.Valor, 2);
                        total.Valor = subtotal.Valor;
                    }
                }
                else if (cfg.Nombre == "Facturaciones")
                {
                    CampoNumero subtotal = ObtenerCampoNumero("Subtotal");
                    CampoNumero impuesto = ObtenerCampoNumero("Impuesto");
                    CampoNumero total = ObtenerCampoNumero("TotalPagar");
                    if (subtotal != null && impuesto != null && total != null)
                    {
                        impuesto.Valor = decimal.Round(subtotal.Valor * 0.12m, 2);
                        total.Valor = subtotal.Valor + impuesto.Valor;
                    }
                }
                else if (cfg.Nombre == "Compras" && codigoEnEdicion <= 0)
                {
                    CampoNumero total = ObtenerCampoNumero("TotalCompra");
                    if (total != null) total.Valor = 0;
                }
            }
            finally
            {
                calculandoCamposCalculados = false;
            }
        }

        void ActualizarTotalesEnVivo(decimal totalVivo, int cantViva)
        {
            if (cargandoCamposFormulario) return;
            if (cfg.Nombre == "Facturaciones")
            {
                for (int i = 0; i < inputs.Count; i++)
                {
                    if (PropiedadCampo(cfg.Campos[i]) == "Subtotal")
                    {
                        var numSub = inputs[i] as CampoNumero;
                        if (numSub != null && numSub.Valor != totalVivo)
                        {
                            numSub.Valor = totalVivo;
                        }
                        break;
                    }
                }
            }
            else if (cfg.Nombre == "Compras")
            {
                for (int i = 0; i < inputs.Count; i++)
                {
                    string prop = PropiedadCampo(cfg.Campos[i]);
                    if (prop == "TotalCompra")
                    {
                        var numTot = inputs[i] as CampoNumero;
                        if (numTot != null && numTot.Valor != totalVivo)
                        {
                            numTot.Valor = totalVivo;
                        }
                        break;
                    }
                }
            }
        }

        void ActualizarTotalesDesdeDetalle()
        {
            if (editorDetalle == null || cargandoCamposFormulario) return;
            if (cfg.Nombre == "Facturaciones")
            {
                decimal totalDetalles = editorDetalle.ObtenerSumaSubtotales();
                for (int i = 0; i < inputs.Count; i++)
                {
                    if (PropiedadCampo(cfg.Campos[i]) == "Subtotal")
                    {
                        var numSub = inputs[i] as CampoNumero;
                        if (numSub != null && numSub.Valor != totalDetalles)
                            numSub.Valor = totalDetalles;
                        break;
                    }
                }
            }
            else if (cfg.Nombre == "Compras")
            {
                decimal totalDetalles = editorDetalle.ObtenerSumaSubtotales();
                for (int i = 0; i < inputs.Count; i++)
                {
                    if (PropiedadCampo(cfg.Campos[i]) == "TotalCompra")
                    {
                        var numTot = inputs[i] as CampoNumero;
                        if (numTot != null && numTot.Valor != totalDetalles)
                            numTot.Valor = totalDetalles;
                        break;
                    }
                }
            }
        }

        void MostrarDetalle()
        {
            if (cfg.Detalle == null) return;
            int i = Tabla.Seleccion; string id = ""; string[][] d = null;
            if (i >= 0 && i < Tabla.Filas.Count)
            {
                id = Tabla.Filas[i][1];
                if (cfg.Nombre != "Compras") cfg.Detalle.TryGetValue(id, out d);
            }
            int codigoCompraSeleccionada = 0;
            int.TryParse(id, out codigoCompraSeleccionada);
            string[][] detalleCompleto = d;
            if (cfg.Nombre == "Compras" && editorDetalle != null)
            {
                editorDetalle.CambiarPadre(codigoCompraSeleccionada);
                detalleCompleto = editorDetalle.ObtenerFilasDetalle();
                d = detalleCompleto;
                if (codigoCompraSeleccionada > 0) cfg.Detalle[id] = detalleCompleto;
            }
            else if (cfg.Nombre == "Facturaciones" && editorDetalle != null && id != "")
            {
                int codigoFacturaSeleccionada;
                if (int.TryParse(id, out codigoFacturaSeleccionada) && codigoFacturaSeleccionada > 0)
                {
                    editorDetalle.CambiarPadre(codigoFacturaSeleccionada);
                    detalleCompleto = editorDetalle.ObtenerFilasDetalle();
                    cfg.Detalle[id] = detalleCompleto;
                    d = detalleCompleto;
                }
            }
            string textoDetalle = Buscar == null ? "" : Buscar.Text.Trim();
            if (textoDetalle.Length > 0 && detalleCompleto != null)
                d = detalleCompleto.Where(fila => fila.Any(valor =>
                    valor != null && valor.IndexOf(textoDetalle, StringComparison.CurrentCultureIgnoreCase) >= 0)).ToArray();
            if (lblDet != null) lblDet.Text = id == "" ? cfg.TituloDet : cfg.TituloDet + " " + id;
            if (TablaDet != null)
            {
                filasDetalleVista = d ?? new string[0][];
                paginaDetalleActual = 1;
                MostrarPaginaDetalle();
                if (totDet != null)
                {
                    if (cfg.Nombre == "Compras") TotalizarCompra(codigoCompraSeleccionada, detalleCompleto);
                    else Totalizar(detalleCompleto, totDet);
                }
            }
            if (TablaGes != null)
            {
                TablaGes.Filas.Clear(); if (detalleCompleto != null) TablaGes.Filas.AddRange(detalleCompleto.Select(f => (string[])f.Clone()));
                TablaGes.InvalidarAnchosColumnas();
                TablaGes.Seleccion = TablaGes.Filas.Count > 0 ? 0 : -1;
            }
        }

        void CambiarPaginaDetalle(int pagina)
        {
            int tamanoPagina = cfg.Nombre == "Compras" ? RegistrosPorPagina : Math.Max(1, filasDetalleVista.Length);
            int totalPaginas = Math.Max(1, (int)Math.Ceiling(filasDetalleVista.Length / (double)tamanoPagina));
            paginaDetalleActual = Math.Max(1, Math.Min(pagina, totalPaginas));
            MostrarPaginaDetalle();
        }

        void MostrarPaginaDetalle()
        {
            if (TablaDet == null) return;
            int total = filasDetalleVista.Length;
            int tamanoPagina = cfg.Nombre == "Compras" ? RegistrosPorPagina : Math.Max(1, total);
            int paginas = Math.Max(1, (int)Math.Ceiling(total / (double)tamanoPagina));
            paginaDetalleActual = Math.Max(1, Math.Min(paginaDetalleActual, paginas));
            int desde = total == 0 ? 0 : (paginaDetalleActual - 1) * tamanoPagina;
            TablaDet.Filas.Clear();
            TablaDet.Filas.AddRange(filasDetalleVista.Skip(desde).Take(tamanoPagina));
            TablaDet.InvalidarAnchosColumnas();
            TablaDet.Invalidate();

            int primero = total == 0 ? 0 : desde + 1;
            int ultimo = total == 0 ? 0 : Math.Min(desde + tamanoPagina, total);
            textoPaginacionDetalle.Text = string.Format("Mostrando {0} - {1} de {2} detalles", primero, ultimo, total);
            botonDetalleAnterior.Enabled = paginaDetalleActual > 1;
            botonDetalleSiguiente.Enabled = paginaDetalleActual < paginas;
        }

        void TotalizarCompra(int codigoCompra, string[][] detalles)
        {
            int indiceSubtotal = Array.IndexOf(cfg.ColumnasDetallePropiedades, "Subtotal");
            int indiceDescuento = Array.IndexOf(cfg.ColumnasDetallePropiedades, "DescuentoCompra");
            decimal subtotal = 0;
            decimal descuento = 0;

            if (detalles != null)
            {
                foreach (string[] detalle in detalles)
                {
                    if (indiceSubtotal >= 0 && indiceSubtotal < detalle.Length)
                        subtotal += Monto(detalle[indiceSubtotal]);
                    if (indiceDescuento >= 0 && indiceDescuento < detalle.Length)
                        descuento += Monto(detalle[indiceDescuento]);
                }
            }

            object compra = registros.FirstOrDefault(x =>
                Convert.ToInt32(x.GetType().GetProperty(cfg.Clave).GetValue(x, null)) == codigoCompra);
            decimal totalCompra = compra == null
                ? 0
                : Convert.ToDecimal(compra.GetType().GetProperty("TotalCompra").GetValue(compra, null));

            totDet.Sub = M(subtotal);
            totDet.Iva = M(descuento);
            totDet.Total = M(totalCompra);
            totDet.Invalidate();
        }

        static decimal Monto(string s) { decimal d; return decimal.TryParse((s ?? "").Replace("Q", "").Replace(",", "").Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out d) ? d : 0; }
        static string M(decimal d) { return "Q " + d.ToString("N2", CultureInfo.InvariantCulture); }
        static void Totalizar(string[][] filas, Totales tt)
        {
            decimal sum = 0;
            if (filas != null)
                foreach (var f in filas) sum += Monto(f[f.Length - 1]);
            decimal iva = sum - Math.Round(sum / 1.12m, 2); tt.Sub = M(sum - iva); tt.Iva = M(iva); tt.Total = M(sum); tt.Invalidate();
        }

        // ---------------- Gestionar ----------------
        static Tarjeta Sec() { return new Tarjeta { Dock = DockStyle.Fill, Radio = 14, Opacidad = 200, C1 = Color.FromArgb(16, 34, 116), C2 = Color.FromArgb(26, 28, 132), ColorBorde = Color.FromArgb(120, 70, 105, 255), Vidrio = false }; }

        void ConstruirGestionar(Panel host)
        {
            var card = Card(); bool det = cfg.Detalle != null;
            var pie = P(DockStyle.Bottom, det ? 78 : 64, new Padding(18, 10, 18, 10));
            var fb = new FlowLayoutPanel { Dock = DockStyle.Right, Width = 390, BackColor = Color.Transparent, FlowDirection = FlowDirection.RightToLeft };
            var bc = new Boton { Texto = "Cancelar", C1 = Color.FromArgb(255, 50, 170), C2 = Color.FromArgb(225, 40, 130), Width = 112, Height = 40, Margin = new Padding(8, 0, 0, 0) };
            var bl = new Boton { Texto = det ? "Nueva" : "Limpiar", Icono = det ? "\u2795" : "\U0001F5D1", C1 = Color.FromArgb(130, 60, 255), C2 = Color.FromArgb(60, 110, 255), Width = 112, Height = 40, Margin = new Padding(8, 0, 0, 0) };
            var bs = new Boton { Texto = "Guardar", Icono = "\U0001F5C4", C1 = Color.FromArgb(0, 190, 150), C2 = Color.FromArgb(0, 215, 125), Width = 124, Height = 40, Margin = new Padding(8, 0, 0, 0) };
            bc.Click += (s, e) => { nuevoRegistroSolicitado = false; LimpiarFormulario(); Tabs.Seleccion = 0; };
            bl.Click += (s, e) =>
            {
                nuevoRegistroSolicitado = true;
                LimpiarFormulario();
                if (cfg.Nombre == "Compras" && editorDetalle != null) editorDetalle.CambiarPadre(0);
            };
            bs.Click += (s, e) => GuardarFormulario();
            fb.Controls.AddRange(new Control[] { bc, bl, bs }); pie.Controls.Add(fb);

            int cols = det ? 4 : 3, n = cfg.Campos.Length, filas = (n + cols - 1) / cols;
            var grid = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = cols, RowCount = filas, BackColor = Color.Transparent };
            for (int i = 0; i < cols; i++) grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / cols));
            for (int i = 0; i < filas; i++) grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 64));
            for (int i = 0; i < n; i++)
            {
                var ctl = Campo(cfg.Campos[i]);
                inputs.Add(ctl);
                var selector = ctl as Selector;
                if (selector != null && !ModuloCrud.EsRelacion(PropiedadCampo(cfg.Campos[i])))
                    opcionesFijas[selector] = selector.Items.ToList();
                grid.Controls.Add(ctl, i % cols, i / cols);
            }
            ConfigurarCalculosAutomaticos();

            if (cfg.Nombre == "Usuarios")
            {
                for (int i = 0; i < n; i++)
                {
                    if (PropiedadCampo(cfg.Campos[i]) == "TipoUsuario")
                    {
                        var selTipo = inputs[i] as Selector;
                        if (selTipo != null)
                        {
                            selTipo.Cambio += (s, e) =>
                            {
                                if (codigoEnEdicion <= 0)
                                {
                                    string tipo = selTipo.Texto;
                                    for (int j = 0; j < n; j++)
                                    {
                                        if (PropiedadCampo(cfg.Campos[j]) == "Clave")
                                        {
                                            var txtClave = inputs[j] as CampoTexto;
                                            if (txtClave != null)
                                            {
                                                txtClave.Caja.Text = UsuarioNegocio.ObtenerClavePorDefecto(tipo);
                                                break;
                                            }
                                        }
                                    }
                                }
                            };
                        }
                        break;
                    }
                }
            }
            else if (cfg.Nombre == "Cotizaciones")
            {
                CampoNumero numCantidad = null, numPrecio = null, numSubtotal = null, numTotal = null;
                Selector selEstado = null;
                for (int i = 0; i < n; i++)
                {
                    string prop = PropiedadCampo(cfg.Campos[i]);
                    if (prop == "Cantidad") numCantidad = inputs[i] as CampoNumero;
                    else if (prop == "Precio") numPrecio = inputs[i] as CampoNumero;
                    else if (prop == "Subtotal") numSubtotal = inputs[i] as CampoNumero;
                    else if (prop == "Total") numTotal = inputs[i] as CampoNumero;
                    else if (prop == "Estado") selEstado = inputs[i] as Selector;
                }

                if (selEstado != null && selEstado.Seleccion < 0)
                {
                    selEstado.Seleccion = 1; // Activo por defecto
                }

                if (numCantidad != null && numPrecio != null && numSubtotal != null && numTotal != null)
                {
                    bool calculandoCotizacion = false;

                    // Al cambiar Cantidad o Precio: Subtotal = Cantidad * Precio, Total = Subtotal
                    Action recalcularDesdeCantOPrecio = () =>
                    {
                        if (calculandoCotizacion || cargandoCamposFormulario) return;
                        calculandoCotizacion = true;
                        try
                        {
                            decimal cant = numCantidad.Valor;
                            decimal prec = numPrecio.Valor;
                            decimal sub = Math.Round(cant * prec, 2);
                            numSubtotal.Valor = sub;
                            numTotal.Valor = sub;
                        }
                        finally
                        {
                            calculandoCotizacion = false;
                        }
                    };

                    numCantidad.EnVivo += (s, e) => recalcularDesdeCantOPrecio();
                    numPrecio.EnVivo += (s, e) => recalcularDesdeCantOPrecio();

                    // Al cambiar Subtotal en vivo: Total = Subtotal; y si Cantidad > 0: Precio = Subtotal / Cantidad
                    numSubtotal.EnVivo += (s, e) =>
                    {
                        if (calculandoCotizacion || cargandoCamposFormulario) return;
                        calculandoCotizacion = true;
                        try
                        {
                            decimal sub = numSubtotal.Valor;
                            numTotal.Valor = sub;
                            decimal cant = numCantidad.Valor;
                            if (cant > 0)
                            {
                                numPrecio.Valor = Math.Round(sub / cant, 2);
                            }
                        }
                        finally
                        {
                            calculandoCotizacion = false;
                        }
                    };

                    // Al cambiar Total en vivo: Subtotal = Total; y si Cantidad > 0: Precio = Total / Cantidad
                    numTotal.EnVivo += (s, e) =>
                    {
                        if (calculandoCotizacion || cargandoCamposFormulario) return;
                        calculandoCotizacion = true;
                        try
                        {
                            decimal tot = numTotal.Valor;
                            numSubtotal.Valor = tot;
                            decimal cant = numCantidad.Valor;
                            if (cant > 0)
                            {
                                numPrecio.Valor = Math.Round(tot / cant, 2);
                            }
                        }
                        finally
                        {
                            calculandoCotizacion = false;
                        }
                    };
                }
            }
            else if (cfg.Nombre == "Tipo de Servicio")
            {
                CampoNumero numCosto = null, numRecargo = null, numTotal = null;
                Selector selEstado = null;
                for (int i = 0; i < n; i++)
                {
                    string prop = PropiedadCampo(cfg.Campos[i]);
                    if (prop == "CostoServicio") numCosto = inputs[i] as CampoNumero;
                    else if (prop == "RecargoServicio") numRecargo = inputs[i] as CampoNumero;
                    else if (prop == "TotalServicio") numTotal = inputs[i] as CampoNumero;
                    else if (prop == "Estado") selEstado = inputs[i] as Selector;
                }

                if (selEstado != null && selEstado.Seleccion < 0)
                {
                    selEstado.Seleccion = 1; // Activo por defecto
                }

                if (numCosto != null && numRecargo != null && numTotal != null)
                {
                    bool calculandoServicio = false;

                    // Al cambiar Costo o Recargo en vivo: Total = Costo + Recargo
                    Action recalcularTotal = () =>
                    {
                        if (calculandoServicio || cargandoCamposFormulario) return;
                        calculandoServicio = true;
                        try
                        {
                            numTotal.Valor = Math.Round(numCosto.Valor + numRecargo.Valor, 2);
                        }
                        finally
                        {
                            calculandoServicio = false;
                        }
                    };

                    numCosto.EnVivo += (s, e) => recalcularTotal();
                    numRecargo.EnVivo += (s, e) => recalcularTotal();

                    // Al cambiar Total en vivo: Recargo = Total - Costo
                    numTotal.EnVivo += (s, e) =>
                    {
                        if (calculandoServicio || cargandoCamposFormulario) return;
                        calculandoServicio = true;
                        try
                        {
                            decimal costo = numCosto.Valor;
                            decimal tot = numTotal.Valor;
                            if (tot >= costo)
                            {
                                numRecargo.Valor = Math.Round(tot - costo, 2);
                            }
                            else
                            {
                                numRecargo.Valor = 0;
                                numCosto.Valor = tot;
                            }
                        }
                        finally
                        {
                            calculandoServicio = false;
                        }
                    };
                }
            }
            else if (cfg.Nombre == "Facturaciones")
            {
                CampoNumero numSubtotal = null, numImpuesto = null, numTotalPagar = null, numFactura = null;
                Selector selOrden = null, selEstado = null;
                for (int i = 0; i < n; i++)
                {
                    string prop = PropiedadCampo(cfg.Campos[i]);
                    if (prop == "Subtotal") numSubtotal = inputs[i] as CampoNumero;
                    else if (prop == "Impuesto") numImpuesto = inputs[i] as CampoNumero;
                    else if (prop == "TotalPagar") numTotalPagar = inputs[i] as CampoNumero;
                    else if (prop == "CodigoOrdenTrabajo") selOrden = inputs[i] as Selector;
                    else if (prop == "Estado") selEstado = inputs[i] as Selector;
                    else if (prop == "NoFactura") numFactura = inputs[i] as CampoNumero;
                }

                if (selEstado != null && selEstado.Seleccion < 0)
                {
                    selEstado.Seleccion = 1; // Activo por defecto
                }
if (numSubtotal != null && numImpuesto != null && numTotalPagar != null)
                {
                    bool calculandoFactura = false;

                    // Al cambiar Subtotal en vivo: Impuesto = 12% IVA, Total = Subtotal + Impuesto
                    numSubtotal.EnVivo += (s, e) =>
                    {
                        if (calculandoFactura || cargandoCamposFormulario) return;
                        calculandoFactura = true;
                        try
                        {
                            decimal sub = numSubtotal.Valor;
                            decimal imp = Math.Round(sub * 0.12m, 2);
                            numImpuesto.Valor = imp;
                            numTotalPagar.Valor = sub + imp;
                        }
                        finally
                        {
                            calculandoFactura = false;
                        }
                    };

                    // Al cambiar Impuesto en vivo: Total = Subtotal + Impuesto
                    numImpuesto.EnVivo += (s, e) =>
                    {
                        if (calculandoFactura || cargandoCamposFormulario) return;
                        calculandoFactura = true;
                        try
                        {
                            numTotalPagar.Valor = numSubtotal.Valor + numImpuesto.Valor;
                        }
                        finally
                        {
                            calculandoFactura = false;
                        }
                    };

                    // Al cambiar Total a pagar en vivo: desglosa Subtotal (base sin IVA) y el Impuesto
                    numTotalPagar.EnVivo += (s, e) =>
                    {
                        if (calculandoFactura || cargandoCamposFormulario) return;
                        calculandoFactura = true;
                        try
                        {
                            decimal tot = numTotalPagar.Valor;
                            decimal sub = Math.Round(tot / 1.12m, 2);
                            numSubtotal.Valor = sub;
                            numImpuesto.Valor = tot - sub;
                        }
                        finally
                        {
                            calculandoFactura = false;
                        }
                    };
                }
            }
            else if (cfg.Nombre == "Compras")
            {
                Selector selEstado = null;
                CampoNumero numCantComprada = null;
                for (int i = 0; i < n; i++)
                {
                    string prop = PropiedadCampo(cfg.Campos[i]);
                    if (prop == "Estado") selEstado = inputs[i] as Selector;
                    else if (prop == "CantidadComprada") numCantComprada = inputs[i] as CampoNumero;
                }

                if (selEstado != null && selEstado.Seleccion < 0)
                {
                    selEstado.Seleccion = 1; // Activo por defecto
                }

                if (numCantComprada != null)
                {
                    if (numCantComprada.Valor <= 0) numCantComprada.Valor = 1;
                    numCantComprada.EnVivo += (s, e) =>
                    {
                        if (cargandoCamposFormulario) return;
                        if (editorDetalle != null)
                        {
                            editorDetalle.CantidadExterna = (int)Math.Max(1, numCantComprada.Valor);
                        }
                    };
                }
            }
            else if (cfg.Nombre == "Inventarios")
            {
                Selector selEstado = null;
                for (int i = 0; i < n; i++)
                {
                    string prop = PropiedadCampo(cfg.Campos[i]);
                    if (prop == "Estado") selEstado = inputs[i] as Selector;
                }
                if (selEstado != null && selEstado.Seleccion < 0)
                {
                    selEstado.Seleccion = 1; // Activo por defecto
                }
            }
            else if (cfg.Nombre == "Órdenes de Trabajo")
            {
                Selector selEstado = null;
                for (int i = 0; i < n; i++)
                {
                    string prop = PropiedadCampo(cfg.Campos[i]);
                    if (prop == "Estado") selEstado = inputs[i] as Selector;
                }
                if (selEstado != null && selEstado.Seleccion < 0)
                {
                    selEstado.Seleccion = 1; // Activo por defecto
                }
            }

            if (!det)
            {
                var gw = P(DockStyle.Top, filas * 64 + 6, new Padding(18, 0, 6, 0)); gw.Controls.Add(grid);
                var tit = P(DockStyle.Top, 52, new Padding(0)); tit.Controls.Add(Tema.L("Datos de " + cfg.Nombre.ToLower(), 13, Color.White, 20, 16, true));
                card.Controls.Add(pie); card.Controls.Add(gw); card.Controls.Add(tit);

                // Un formulario con muchos campos puede desplazarse sin cortar las filas inferiores.
                int alturaMinima = 52 + filas * 64 + 6 + pie.Height;
                card.Dock = DockStyle.Top;
                card.Width = Math.Max(1, host.ClientSize.Width);
                card.Height = Math.Max(alturaMinima, host.ClientSize.Height);
                host.AutoScroll = true;
                host.Resize += (s, e) =>
                {
                    card.Width = Math.Max(1, host.ClientSize.Width);
                    card.Height = Math.Max(alturaMinima, host.ClientSize.Height);
                };
                host.Controls.Add(card);
                // El formulario de alta inicia vacio; los datos se cargan solo al pulsar Editar.
                Nueva(false);
                return;
            }

            string sing = cfg.Nombre == "Compras" ? "compra" : cfg.Nombre == "Facturaciones" ? "factura" : "registro";
            bool compra = cfg.Nombre == "Compras";
            card.Padding = new Padding(14, 12, 14, 0);

            // Sección 1: datos de la factura / compra
            var s1 = Sec(); var s1b = P(DockStyle.Fill, 0, new Padding(14, 0, 6, 6)); s1b.Controls.Add(grid);
            var s1h = P(DockStyle.Top, 40, new Padding(0)); s1h.Controls.Add(Tema.L("Datos de la " + sing, 12.5f, Color.White, 16, 10, true));
            s1.Controls.Add(s1b); s1.Controls.Add(s1h);
            var s1w = P(DockStyle.Top, 40 + filas * 64 + 12 + 10, new Padding(0, 0, 0, 10)); s1w.Controls.Add(s1);

            // Sección 2: detalle (captura de líneas + tabla)
            var s2 = Sec();
            var tw = P(DockStyle.Fill, 0, new Padding(12, 0, 12, 10));
            TablaGes = new Tabla { Dock = DockStyle.Fill }; TablaGes.Columnas.AddRange(cfg.ColsDet);
            TablaGes.TituloVacio = "Aún no hay líneas en el detalle"; TablaGes.TextoVacio = "Escribe el ítem, la cantidad y el precio, y pulsa \"Agregar línea\".";
            if (!cfg.DetalleSoloLectura) tw.Controls.Add(TablaGes);
            var le = P(DockStyle.Top, 68, new Padding(14, 0, 14, 0));
            var lt = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 5, RowCount = 1, BackColor = Color.Transparent };
            lt.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            foreach (var pc in new float[] { 34, 12, 18, 20, 16 }) lt.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, pc));
            Padding mg = new Padding(0, 4, 10, 4);
            eDesc = new CampoTexto(compra ? "Material / producto" : "Descripción del servicio o producto", "") { Dock = DockStyle.Fill, Margin = mg };
            eCant = new CampoNumero("Cantidad", 0, false, false) { Dock = DockStyle.Fill, Margin = mg }; eCant.Num.Minimum = 1; eCant.Valor = 1;
            ePrecio = new CampoNumero(compra ? "Costo unitario" : "Precio unitario", 2, true, false) { Dock = DockStyle.Fill, Margin = mg };
            eSubLin = new CampoNumero("Subtotal (calculado)", 2, true, true) { Dock = DockStyle.Fill, Margin = mg };
            eCant.EnVivo += (s, e) => eSubLin.Valor = eCant.Valor * ePrecio.Valor; ePrecio.EnVivo += (s, e) => eSubLin.Valor = eCant.Valor * ePrecio.Valor;
            var ba = new Boton { Texto = "Agregar", Icono = "\u2795", C1 = Color.FromArgb(0, 190, 150), C2 = Color.FromArgb(0, 215, 125), Dock = DockStyle.Fill, Margin = new Padding(0, 10, 0, 10) };
            ba.Click += (s, e) => AgregarLinea();
            if (cfg.DetalleSoloLectura) { le.Visible = false; ba.Enabled = false; }
            lt.Controls.Add(eDesc, 0, 0); lt.Controls.Add(eCant, 1, 0); lt.Controls.Add(ePrecio, 2, 0); lt.Controls.Add(eSubLin, 3, 0); lt.Controls.Add(ba, 4, 0); le.Controls.Add(lt);
            var hd = P(DockStyle.Top, 42, new Padding(0)); hd.Controls.Add(Tema.L("Detalle de la " + sing, 12.5f, Color.White, 16, 10, true));
            var bq = new Boton { Texto = cfg.DetalleSoloLectura ? "Gestionar detalle" : "Quitar línea", Icono = "\U0001F5D1", C1 = Color.FromArgb(255, 50, 170), C2 = Color.FromArgb(225, 40, 130), Dock = DockStyle.Fill };
            var bw = P(DockStyle.Right, 176, new Padding(0, 3, 14, 3)); bw.Controls.Add(bq); hd.Controls.Add(bw);
            if (cfg.DetalleSoloLectura)
            {
                bw.Visible = false;
                editorDetalle = new FormularioDetalleCrud(cfg.Nombre, 0) { Dock = DockStyle.Fill };
                editorDetalle.DatosCambiados += (s, e) =>
                {
                    MostrarDetalle();
                    ActualizarTotalesDesdeDetalle();
                };
                editorDetalle.SubtotalEnVivoCambiado += (totalVivo, cantViva) =>
                {
                    ActualizarTotalesEnVivo(totalVivo, cantViva);
                };
                tw.Controls.Add(editorDetalle);
            }
            else bq.Click += (s, e) => { int k = TablaGes.Seleccion; if (k < 0 || k >= TablaGes.Filas.Count) k = TablaGes.Filas.Count - 1; if (k >= 0) { TablaGes.Filas.RemoveAt(k); for (int z = 0; z < TablaGes.Filas.Count; z++) TablaGes.Filas[z][0] = (z + 1).ToString(); TablaGes.InvalidarAnchosColumnas(); TablaGes.Seleccion = TablaGes.Filas.Count - 1; Recalcular(); } };
            s2.Controls.Add(tw); s2.Controls.Add(le); s2.Controls.Add(hd);
            var s2w = P(DockStyle.Fill, 0, new Padding(0)); s2w.Controls.Add(s2);

            var tt = new TableLayoutPanel { Dock = DockStyle.Left, Width = 560, ColumnCount = 3, RowCount = 1, BackColor = Color.Transparent };
            tt.RowStyles.Add(new RowStyle(SizeType.Percent, 100)); for (int z = 0; z < 3; z++) tt.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
            eSubt = new CampoNumero("Subtotal (calculado)", 2, true, true) { Dock = DockStyle.Fill, Margin = new Padding(0, 0, 10, 0) };
            eDescto = new CampoNumero("Descuento", 2, true, false) { Dock = DockStyle.Fill, Margin = new Padding(0, 0, 10, 0) }; eDescto.EnVivo += (s, e) => Recalcular();
            eTot = new CampoNumero("Total (calculado)", 2, true, true) { Dock = DockStyle.Fill, Margin = new Padding(0) }; eTot.Color2(Color.FromArgb(95, 60, 215)); eTot.Num.Font = Tema.F(10.5f, true);
            tt.Controls.Add(eSubt, 0, 0); tt.Controls.Add(eDescto, 1, 0); tt.Controls.Add(eTot, 2, 0); pie.Controls.Add(tt);
            if (cfg.DetalleSoloLectura) tt.Visible = false;
            card.Controls.Add(s2w); card.Controls.Add(pie); card.Controls.Add(s1w);
            host.Controls.Add(card);
            if (cfg.DetalleSoloLectura) le.Visible = false;
            Nueva(false);
        }

        void AgregarLinea()
        {
            decimal q = eCant.Valor, p = ePrecio.Valor; int n = TablaGes.Filas.Count;
            string d = eDesc.Caja.Text.Trim(); if (d == "") d = "Ítem " + (n + 1);
            TablaGes.Filas.Add(new[] { (n + 1).ToString(), d, q.ToString("0.##", CultureInfo.InvariantCulture), M(p), M(q * p) });
            TablaGes.InvalidarAnchosColumnas();
            TablaGes.Seleccion = n; eDesc.Caja.Text = ""; eCant.Valor = 1; ePrecio.Valor = 0; Recalcular(); eDesc.Caja.Focus();
        }

        void AbrirGestionDetalle()
        {
            try
            {
                if (codigoEnEdicion <= 0)
                {
                    AppDialog.Warning(this, "Selecciona un registro",
                        "Selecciona una fila y pulsa Editar antes de gestionar su detalle.");
                    return;
                }
                editorDetalle.CambiarPadre(codigoEnEdicion);
            }
            catch (Exception ex)
            {
                AppDialog.Error(this, "No se pudo abrir el detalle",
                    "Actualiza el registro e inténtalo nuevamente.", ex);
            }
        }

        // Campos calculados: Subtotal = suma de las líneas; Total = Subtotal - Descuento (sin IVA)
        void Recalcular()
        {
            if (TablaGes == null || eSubt == null) return;
            decimal sum = 0; foreach (var f in TablaGes.Filas) sum += Monto(f[f.Length - 1]);
            eSubt.Valor = sum; eTot.Valor = Math.Max(0, sum - eDescto.Valor);
        }

        string Siguiente()
        {
            string pre = "", w = ""; int max = 0;
            foreach (var f in cfg.Filas)
            {
                string id = f[1]; int k = id.IndexOf('-'); if (k < 0) continue;
                string num = id.Substring(k + 1); int v; if (int.TryParse(num, out v) && v > max) { max = v; w = num; pre = id.Substring(0, k + 1); }
            }
            return pre + (max + 1).ToString().PadLeft(w.Length, '0');
        }

        // Formulario en blanco: número siguiente, fecha de hoy y detalle vacío
        void Nueva(bool ir)
        {
            for (int i = 0; i < inputs.Count; i++)
            {
                string tp = cfg.Campos[i].Substring(cfg.Campos[i].IndexOf(':') + 1);
                var ct = inputs[i] as CampoTexto; var sl = inputs[i] as Selector;
                var cf = inputs[i] as CampoFecha; if (cf != null) cf.Limpiar();
                if (ct != null) ct.Caja.Clear();
                if (sl != null) sl.Seleccion = -1;
                var cn = inputs[i] as CampoNumero; if (cn != null) cn.Limpiar();
            }
            if (eDescto != null) eDescto.Valor = 0;
            if (TablaGes != null) { TablaGes.Filas.Clear(); TablaGes.InvalidarAnchosColumnas(); TablaGes.Seleccion = -1; Recalcular(); }
            RecalcularCamposCalculados();
            if (ir) Tabs.Seleccion = 1;
        }

        // Carga la fila elegida (con su detalle) en el formulario
        void Cargar()
        {
            int k = Tabla.Seleccion; if (k < 0 || k >= Tabla.Filas.Count) { Tabs.Seleccion = 1; return; }
            var row = Tabla.Filas[k]; string[][] dd; Nueva(false);
            var c0 = inputs[0] as CampoTexto; if (c0 != null) c0.Caja.Text = row[1];
            foreach (var ctl in inputs) { var sl = ctl as Selector; if (sl != null) { int ix = sl.Items.FindIndex(o => row.Contains(o)); if (ix >= 0) sl.Seleccion = ix; } }
            if (cfg.Detalle.TryGetValue(row[1], out dd)) { foreach (var ln in dd) TablaGes.Filas.Add((string[])ln.Clone()); TablaGes.InvalidarAnchosColumnas(); TablaGes.Seleccion = 0; Recalcular(); }
            Tabs.Seleccion = 1;
        }

        static Control Campo(string spec)
        {
            int i = spec.IndexOf(':'); string rot = spec.Substring(0, i), tp = spec.Substring(i + 1);
            int separador = rot.IndexOf('|');
            string propiedad = separador >= 0 ? rot.Substring(separador + 1) : rot;
            if (separador >= 0) rot = rot.Substring(0, separador);
            if (tp == "b")
            {
                var s = new Selector { Dock = DockStyle.Fill, Rotulo = rot, Margin = new Padding(0, 4, 12, 8) };
                s.Items.Add("Inactivo"); s.Items.Add("Activo"); return s;
            }
            if (tp.StartsWith("c="))
            {
                var s = new Selector { Dock = DockStyle.Fill, Rotulo = rot, Margin = new Padding(0, 4, 12, 8) };
                foreach (var o in tp.Substring(2).Split(',')) s.Items.Add(o); return s;
            }
            if (tp == "f") return new CampoFecha(rot) { Dock = DockStyle.Fill, Margin = new Padding(0, 4, 12, 8) };
            if (tp == "n" && ModuloCrud.EsRelacion(propiedad))
                return new Selector { Dock = DockStyle.Fill, Rotulo = rot, Margin = new Padding(0, 4, 12, 8) };
            if (tp == "n" || tp == "m")
            {
                bool calculado = new[] { "TotalServicio", "Subtotal", "Total", "Impuesto", "TotalPagar", "TotalCompra" }.Contains(propiedad);
                return new CampoNumero(rot, tp == "m" ? 2 : 0, tp == "m", calculado) { Dock = DockStyle.Fill, Margin = new Padding(0, 4, 12, 8) };
            }
            string v = tp == "f" ? DateTime.Today.ToString("dd/MM/yyyy") : tp == "h" ? "08:00" : "";
            var campoTexto = new CampoTexto(rot, v) { Dock = DockStyle.Fill, Margin = new Padding(0, 4, 12, 8) };
            if (propiedad == "Clave") campoTexto.Caja.UseSystemPasswordChar = true;
            return campoTexto;
        }

        // ---------------- Resumen ----------------
        void ConstruirResumen(Panel host)
        {
            var b = new BarrasEstado { Dock = DockStyle.Fill, Radio = 18, Opacidad = 225, C1 = Color.FromArgb(10, 24, 98), C2 = Color.FromArgb(24, 22, 118), Brillo = Color.FromArgb(60, 150, 60, 255), Brillo2 = Color.FromArgb(30, 0, 200, 255) };
            barraResumen = b;
            b.Cols.AddRange(cfg.Cols); if (cfg.Filas != null) b.Filas.AddRange(cfg.Filas);
            host.Controls.Add(b);
        }

        Control Combo(string spec)
        {
            int k = spec.IndexOf('='); string nombre = spec.Substring(0, k), ops = spec.Substring(k + 1);
            var host = P(DockStyle.Right, 168, new Padding(12, 0, 0, 0));
            var sel = new Selector { Dock = DockStyle.Fill, Rotulo = nombre }; sel.Items.Add(nombre == "Sucursal" ? "Todas" : "Todos");
            foreach (var o in ops.Split(',')) if (o != "") sel.Items.Add(o);
            sel.Cambio += (s, e) => AplicarFiltro(); Combos.Add(sel); host.Controls.Add(sel); return host;
        }

        static Boton Acc(string t, string ic, Color a, Color b) { return new Boton { Texto = t, Icono = ic, C1 = a, C2 = b, Width = 112, Height = 40, Margin = new Padding(0, 0, 8, 0), Radio = 12 }; }
        static Boton Pag(string t, bool act, int w)
        { return new Boton { Texto = t, C1 = act ? Tema.Morado : Tema.Campo, C2 = act ? Tema.Rosa : Tema.Campo, Width = w, Height = 34, Margin = new Padding(3, 0, 3, 0), Radio = 9, ColorBorde = Tema.Borde }; }

        protected override void OnPaintBackground(PaintEventArgs e) { Tema.PintarFondo(e.Graphics, this); }
    }
}
