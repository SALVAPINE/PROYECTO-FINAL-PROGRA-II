using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SistemaPublicidad.Formularios
{
    // Tabla dibujada a medida (avatar, insignias, botones de acción). Llene Columnas y Filas desde su capa de datos.
    public class Tabla : Control
    {
        public class Col
        {
            public string Titulo, Tipo; public float Peso; public bool Orden, Centrar;
            public Col(string t, float p, string tipo, bool o = false) { Titulo = t; Peso = p; Tipo = tipo; Orden = o; }
        }
        public List<Col> Columnas = new List<Col>(); public List<string[]> Filas = new List<string[]>();
        public string TituloVacio = "Aún no hay registros", TextoVacio = "Presiona \"Añadir\" para agregar el primero.";
        public bool MensajeVacioEnCuerpo;
        public HashSet<int> Marcadas = new HashSet<int>();
        public event Action<int> EditarClick, EliminarClick;
        int hover = -1, scroll, scrollHorizontal, seleccion = -1; const int Enc = 46;
        float[] anchosColumnasCache;
        readonly BarraDeslizamiento barraHorizontal;
        readonly BarraDeslizamiento barraVertical;
        public event Action<int> SeleccionCambio;
        public int Seleccion
        {
            get { return seleccion; }
            set
            {
                int nueva = value >= 0 && value < Filas.Count ? value : -1;
                bool cambio = seleccion != nueva;
                seleccion = nueva;
                Marcadas.Clear();
                if (nueva >= 0 && TieneCasilla()) Marcadas.Add(nueva);
                Invalidate();
                if (cambio && SeleccionCambio != null) SeleccionCambio(nueva);
            }
        }

        public Tabla()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.AllPaintingInWmPaint, true);
            BackColor = Color.Transparent;
            barraHorizontal = new BarraDeslizamiento(true) { Visible = false, Height = 12 };
            barraVertical = new BarraDeslizamiento(false) { Visible = false, Width = 12 };
            barraHorizontal.ValueChanged += (s, e) => { scrollHorizontal = barraHorizontal.Value; Invalidate(); };
            barraVertical.ValueChanged += (s, e) => { scroll = barraVertical.Value; Invalidate(); };
            Controls.Add(barraHorizontal); Controls.Add(barraVertical);
        }
        int Alto { get { return 42; } }
        static StringFormat Fmt() { return new StringFormat { LineAlignment = StringAlignment.Center, Trimming = StringTrimming.EllipsisCharacter, FormatFlags = StringFormatFlags.NoWrap }; }

        bool TieneCasilla() { return Columnas.Count > 0 && Columnas[0].Tipo == "chk"; }

        float[] AnchosColumnas()
        {
            if (anchosColumnasCache != null && anchosColumnasCache.Length == Columnas.Count)
                return anchosColumnasCache;

            var anchos = new float[Columnas.Count];
            using (var f = Tema.F(9.5f, true))
            using (var fc = Tema.F(9f))
            {
                for (int i = 0; i < Columnas.Count; i++)
                {
                    var c = Columnas[i];
                    if (c.Tipo == "chk") { anchos[i] = 46; continue; }
                    if (c.Tipo == "acc") { anchos[i] = 96; continue; }
                    int max = TextRenderer.MeasureText(c.Titulo ?? "", f).Width + 24;
                    // Mide una muestra acotada; la tabla usa elipsis para texto más largo.
                    int filasAMedir = Math.Min(Filas.Count, 100);
                    for (int r = 0; r < filasAMedir; r++)
                    {
                        if (i >= Filas[r].Length) continue;
                        string texto = Filas[r][i] ?? "";
                        if (c.Tipo == "nombre") texto = texto.Split('~')[0];
                        max = Math.Max(max, TextRenderer.MeasureText(texto, fc).Width + 24);
                    }
                    anchos[i] = Math.Max(92, Math.Min(270, max));
                }
            }
            anchosColumnasCache = anchos;
            return anchosColumnasCache;
        }

        // Cambia los anchos calculados cuando se reemplazan filas o columnas.
        public void InvalidarAnchosColumnas() { anchosColumnasCache = null; }

        void ActualizarBarras()
        {
            int hBar = barraHorizontal.Height, vBar = barraVertical.Width;
            float totalX = 0; foreach (float ancho in AnchosColumnas()) totalX += ancho;
            bool muestraH = totalX > Width - (barraVertical.Visible ? vBar : 0);
            bool muestraV = Filas.Count * Alto > Height - Enc - (muestraH ? hBar : 0);
            muestraH = totalX > Width - (muestraV ? vBar : 0);
            barraHorizontal.Visible = muestraH;
            barraVertical.Visible = muestraV;
            int anchoVista = Math.Max(1, Width - (muestraV ? vBar : 0));
            int altoVista = Math.Max(1, Height - (muestraH ? hBar : 0));
            barraHorizontal.Bounds = new Rectangle(0, Math.Max(0, Height - hBar), anchoVista, hBar);
            barraVertical.Bounds = new Rectangle(Math.Max(0, Width - vBar), 0, vBar, altoVista);
            ConfigurarBarra(barraHorizontal, Math.Max(0, (int)Math.Ceiling(totalX) - anchoVista), anchoVista);
            ConfigurarBarra(barraVertical, Math.Max(0, Filas.Count * Alto - (altoVista - Enc)), Math.Max(1, altoVista - Enc));
            scrollHorizontal = Math.Min(scrollHorizontal, Math.Max(0, (int)Math.Ceiling(totalX) - anchoVista));
            scroll = Math.Min(scroll, Math.Max(0, Filas.Count * Alto - (altoVista - Enc)));
        }

        static void ConfigurarBarra(BarraDeslizamiento barra, int maximo, int visible)
        {
            barra.Minimum = 0;
            barra.LargeChange = Math.Max(1, visible);
            barra.SmallChange = 32;
            barra.Maximum = Math.Max(0, maximo) + barra.LargeChange - 1;
            int valorMaximo = Math.Max(0, barra.Maximum - barra.LargeChange + 1);
            if (barra.Value > valorMaximo) barra.Value = valorMaximo;
        }

        float[] Xs()
        {
            var anchos = AnchosColumnas(); float x = -scrollHorizontal; var xs = new float[Columnas.Count + 1];
            for (int i = 0; i < Columnas.Count; i++) { xs[i] = x; x += anchos[i]; }
            xs[Columnas.Count] = x; return xs;
        }

        static Color[] P2(int a, int b, int c, int d, int e, int f) { return new[] { Color.FromArgb(a, b, c), Color.FromArgb(d, e, f) }; }
        internal static Color[] ColBadge(string t)
        {
            switch (t)
            {
                case "Administrador": case "Empresa": case "Transferencia": return P2(130, 60, 255, 70, 60, 220);
                case "Diseñador": case "Alta": case "Impresión": return P2(255, 60, 170, 225, 40, 150);
                case "Cliente": case "Individual": case "Tarjeta": case "Cotizada": case "Insumos": return P2(40, 140, 255, 20, 100, 230);
                case "Vendedor": case "Media": case "Pendiente": case "En revisión": case "En proceso": case "Stock bajo": return P2(255, 205, 40, 255, 170, 20);
                case "Activo": case "Pagada": case "Aprobada": case "Aprobado": case "Recibida": case "Completada": case "Disponible": case "Baja": case "Efectivo": return P2(0, 205, 150, 0, 170, 125);
                case "Inactivo": case "Anulada": case "Rechazada": case "Cancelada": case "Agotado": return P2(255, 50, 90, 220, 30, 70);
                case "Estructuras": return P2(255, 150, 40, 240, 100, 30);
                default: return P2(100, 110, 180, 70, 80, 150);
            }
        }

        static void Check(Graphics g, float x, float y, bool on)
        {
            using (var p = Tema.Ruta(new RectangleF(x, y, 18, 18), 4))
            {
                if (on) using (var b = new LinearGradientBrush(new RectangleF(x, y, 18, 18), Tema.Azul, Tema.Morado, 45f)) g.FillPath(b, p);
                using (var pn = new Pen(Color.FromArgb(on ? 255 : 190, 175, 195, 255), 1.6f)) g.DrawPath(pn, p);
            }
            if (on) using (var pn = new Pen(Color.White, 2f) { StartCap = LineCap.Round, EndCap = LineCap.Round }) g.DrawLines(pn, new[] { new PointF(x + 4, y + 9), new PointF(x + 8, y + 13), new PointF(x + 14, y + 5) });
        }

        static void Pill(Graphics g, string t, float x, float y, int h, float w)
        {
            var rc = new RectangleF(x, y + (h - 24) / 2f, w, 24); var c = ColBadge(t);
            using (var p = Tema.Ruta(rc, 7)) using (var b = new LinearGradientBrush(rc, c[0], c[1], 0f)) g.FillPath(b, p);
            using (var f = Tema.F(8f, true)) using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoWrap })
                g.DrawString(t, f, t == "Vendedor" ? new SolidBrush(Color.FromArgb(50, 35, 0)) : Brushes.White, rc, sf);
        }

        static readonly Color[][] Pal = { new[] { Color.FromArgb(150, 70, 255), Color.FromArgb(110, 60, 230) }, new[] { Color.FromArgb(40, 140, 255), Color.FromArgb(30, 100, 230) }, new[] { Color.FromArgb(255, 160, 50), Color.FromArgb(240, 120, 40) } };

        void Celda(Graphics g, Col c, string v, float x0, float x1, float y, int h, int r)
        {
            var rc = new RectangleF(x0 + 6, y, Math.Max(10, x1 - x0 - 8), h); v = v ?? "";
            switch (c.Tipo)
            {
                case "chk": Check(g, x0 + 14, y + (h - 18) / 2f, Marcadas.Contains(r)); break;
                case "nombre":
                    {
                        string[] p = v.Split('~'); int d = Math.Min(34, h - 6);
                        var cc = Pal[(p[0].Length + r) % Pal.Length];
                        Tema.Icono(g, new Rectangle((int)x0 + 4, (int)(y + (h - d) / 2f), d, d), cc[0], cc[1], "\U0001F464", true);
                        float tx = x0 + 4 + d + 8; var tr = new RectangleF(tx, y + (h - 31) / 2f, Math.Max(10, x1 - tx - 4), 16);
                        using (var f = Tema.F(9f)) using (var sf = Fmt()) g.DrawString(p[0], f, Brushes.White, tr, sf);
                        if (p.Length > 1) using (var f = Tema.F(8)) using (var b = new SolidBrush(Color.FromArgb(120, 200, 255))) using (var sf = Fmt()) g.DrawString(p[1], f, b, new RectangleF(tx, tr.Y + 15, tr.Width, 14), sf);
                        break;
                    }
                case "link":
                    using (var f = new Font("Segoe UI", 9f, FontStyle.Underline)) using (var b = new SolidBrush(Color.FromArgb(110, 190, 255))) using (var sf = Fmt()) g.DrawString(v, f, b, rc, sf); break;
                case "badge":
                    {
                        float w = Math.Min(108, x1 - x0 - 12);
                        Pill(g, v, c.Centrar ? x0 + (x1 - x0 - w) / 2f : x0 + 6, y, h, w);
                        break;
                    }
                case "estado":
                    {
                        float w = Math.Min(92, x1 - x0 - 12);
                        Pill(g, v, c.Centrar ? x0 + (x1 - x0 - w) / 2f : x0 + 6, y, h, w);
                        break;
                    }
                case "num":
                    using (var f = Tema.F(9f)) using (var b = new SolidBrush(Color.FromArgb(215, 225, 255))) using (var sf = Fmt()) { sf.Alignment = c.Centrar ? StringAlignment.Center : StringAlignment.Far; g.DrawString(v, f, b, new RectangleF(x0, y, x1 - x0 - 12, h), sf); }
                    break;
                case "acc":
                    {
                        float by = y + (h - 30) / 2f;
                        var r1 = new RectangleF(x0 + 6, by, 30, 30); var r2 = new RectangleF(x0 + 44, by, 30, 30);
                        using (var p = Tema.Ruta(r1, 8)) using (var b = new LinearGradientBrush(r1, Color.FromArgb(70, 100, 255), Color.FromArgb(140, 70, 255), 45f)) g.FillPath(b, p);
                        using (var p = Tema.Ruta(r2, 8)) using (var b = new LinearGradientBrush(r2, Color.FromArgb(255, 70, 160), Color.FromArgb(230, 40, 120), 45f)) g.FillPath(b, p);
                        Iconos.Dibujar(g, "\u270F", new RectangleF(r1.X + 7, r1.Y + 7, 16, 16), Color.White, 1.6f);
                        Iconos.Dibujar(g, "\U0001F5D1", new RectangleF(r2.X + 7, r2.Y + 7, 16, 16), Color.White, 1.6f);
                        break;
                    }
                default:
                    using (var f = Tema.F(9f)) using (var b = new SolidBrush(Color.FromArgb(205, 215, 250))) using (var sf = Fmt()) { if (c.Centrar) sf.Alignment = StringAlignment.Center; g.DrawString(v, f, b, rc, sf); } break;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias; g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            if (Width < 50 || Height < 60) return;
            ActualizarBarras();
            int anchoVista = Math.Max(1, Width - (barraVertical.Visible ? barraVertical.Width : 0));
            int altoVista = Math.Max(1, Height - (barraHorizontal.Visible ? barraHorizontal.Height : 0));
            var xs = Xs(); int h = Alto;
            using (var p = Tema.Ruta(new RectangleF(0.5f, 0.5f, Width - 2, Enc - 8), 12))
            {
                using (var b = new SolidBrush(Color.FromArgb(75, 20, 40, 135))) g.FillPath(b, p);
                using (var pn = new Pen(Color.FromArgb(80, 90, 130, 255))) g.DrawPath(pn, p);
            }
            GraphicsState estadoClipEncabezado = g.Save();
            g.SetClip(new Rectangle(0, 0, anchoVista, Enc - 2), CombineMode.Intersect);
            for (int i = 0; i < Columnas.Count; i++)
            {
                var c = Columnas[i]; float x = xs[i];
                if (c.Tipo == "chk") { Check(g, x + 14, (Enc - 8 - 18) / 2f, Filas.Count > 0 && Marcadas.Count == Filas.Count); continue; }
                using (var f = Tema.F(9.5f, true))
                {
                    var rc = new RectangleF(x + 6, 0, Math.Max(10, xs[i + 1] - x - 6 - (c.Orden ? 14 : 0)), Enc - 8);
                    using (var sf = Fmt()) { if (c.Centrar) sf.Alignment = StringAlignment.Center; else if (c.Tipo == "num") sf.Alignment = StringAlignment.Far; g.DrawString(c.Titulo, f, Brushes.White, c.Tipo == "num" ? new RectangleF(rc.X, rc.Y, rc.Width - 4, rc.Height) : rc, sf); }
                    if (c.Orden && c.Tipo != "num")
                    {
                        float cx = Math.Min(x + 6 + g.MeasureString(c.Titulo, f).Width, xs[i + 1] - 16), cy = (Enc - 8) / 2f;
                        using (var pn = new Pen(Color.White, 1.6f)) g.DrawLines(pn, new[] { new PointF(cx, cy - 2), new PointF(cx + 4, cy + 2), new PointF(cx + 8, cy - 2) });
                    }
                }
            }
            g.Restore(estadoClipEncabezado);
            if (Filas.Count == 0)
            {
                if (MensajeVacioEnCuerpo)
                {
                    float centroCuerpo = Enc + Math.Max(0, altoVista - Enc) / 2f;
                    using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                    {
                        using (var f = Tema.F(13, true)) g.DrawString(TituloVacio, f, Brushes.White,
                            new RectangleF(12, centroCuerpo - 22, anchoVista - 24, 26), sf);
                        using (var f = Tema.F(10)) using (var b = new SolidBrush(Tema.Sub)) g.DrawString(TextoVacio, f, b,
                            new RectangleF(12, centroCuerpo + 5, anchoVista - 24, 24), sf);
                    }
                    return;
                }
                Tema.Icono(g, new Rectangle(anchoVista / 2 - 34, altoVista / 2 - 60, 68, 68), Tema.Azul, Tema.Morado, "\U0001F464");
                using (var sf = new StringFormat { Alignment = StringAlignment.Center })
                {
                    using (var f = Tema.F(13, true)) g.DrawString(TituloVacio, f, Brushes.White, anchoVista / 2f, altoVista / 2f + 16, sf);
                    using (var f = Tema.F(10)) using (var b = new SolidBrush(Tema.Sub)) g.DrawString(TextoVacio, f, b, anchoVista / 2f, altoVista / 2f + 44, sf);
                }
                return;
            }
            GraphicsState estadoClipFilas = g.Save();
            g.SetClip(new Rectangle(0, Enc - 2, anchoVista, Math.Max(1, altoVista - Enc + 2)), CombineMode.Intersect);
            int primeraFila = Math.Max(0, scroll / h);
            int ultimaFila = Math.Min(Filas.Count - 1,
                (scroll + Math.Max(0, altoVista - Enc) + h - 1) / h);
            for (int r = primeraFila; r <= ultimaFila; r++)
            {
                float y = Enc + r * h - scroll;
                if (r == hover) using (var b = new SolidBrush(Color.FromArgb(26, 255, 255, 255))) g.FillRectangle(b, 0, y, anchoVista, h);
                if (r == seleccion)
                {
                    var filaSeleccionada = new RectangleF(4, y, anchoVista - 8, h - 1);
                    using (var b = new LinearGradientBrush(filaSeleccionada, Color.FromArgb(115, 120, 70, 255), Color.FromArgb(115, 255, 70, 200), 0f))
                        g.FillRectangle(b, filaSeleccionada);
                    using (var pn = new Pen(Color.FromArgb(115, 180, 165, 255)))
                        g.DrawRectangle(pn, filaSeleccionada.X, filaSeleccionada.Y, filaSeleccionada.Width, filaSeleccionada.Height);
                }
                using (var pn = new Pen(Color.FromArgb(28, 255, 255, 255))) g.DrawLine(pn, 8, y + h - 1, anchoVista - 8, y + h - 1);
                var fila = Filas[r];
                for (int i = 0; i < Columnas.Count && i < fila.Length; i++) Celda(g, Columnas[i], fila[i], xs[i], xs[i + 1], y, h, r);
            }
            g.Restore(estadoClipFilas);
        }

        int Fila(int y) { if (y < Enc || (barraHorizontal.Visible && y >= Height - barraHorizontal.Height)) return -1; int r = (y - Enc + scroll) / Alto; return r >= 0 && r < Filas.Count ? r : -1; }
        protected override void OnMouseEnter(EventArgs e) { base.OnMouseEnter(e); Focus(); }
        protected override void OnMouseLeave(EventArgs e) { base.OnMouseLeave(e); hover = -1; Invalidate(); }
        protected override void OnMouseMove(MouseEventArgs e) { base.OnMouseMove(e); int r = Fila(e.Y); if (r != hover) { hover = r; Invalidate(); } }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if ((ModifierKeys & Keys.Shift) == Keys.Shift && barraHorizontal.Visible)
                barraHorizontal.Value = Math.Max(barraHorizontal.Minimum, Math.Min(barraHorizontal.Maximum - barraHorizontal.LargeChange + 1, barraHorizontal.Value - e.Delta / 3));
            else if (barraVertical.Visible)
                barraVertical.Value = Math.Max(barraVertical.Minimum, Math.Min(barraVertical.Maximum - barraVertical.LargeChange + 1, barraVertical.Value - e.Delta / 3));
            else { scroll = Math.Max(0, Math.Min(Math.Max(0, Filas.Count * Alto - (Height - Enc)), scroll - e.Delta / 3)); Invalidate(); }
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e); var xs = Xs();
            if (e.Y < Enc)
            {
                if (TieneCasilla() && e.X >= xs[0] && e.X < xs[1]) Seleccion = -1;
                return;
            }
            int r = Fila(e.Y); if (r < 0) return;
            for (int i = 0; i < Columnas.Count; i++)
                if (e.X >= xs[i] && e.X < xs[i + 1])
                {
                    if (Columnas[i].Tipo == "chk") { Seleccion = seleccion == r ? -1 : r; }
                    else if (Columnas[i].Tipo == "acc")
                    {
                        if (r != seleccion) Seleccion = r;
                        float o = e.X - xs[i];
                        if (o >= 6 && o <= 36) { if (EditarClick != null) EditarClick(r); }
                        else if (o >= 44 && o <= 74) { if (EliminarClick != null) EliminarClick(r); }
                    }
                    else if (r != seleccion) Seleccion = r;
                }
        }

        protected override void OnResize(EventArgs e) { base.OnResize(e); ActualizarBarras(); Invalidate(); }
    }

    /// <summary>Barra de desplazamiento tenue que conserva el arrastre y el salto por clic.</summary>
    sealed class BarraDeslizamiento : Control
    {
        readonly bool horizontal;
        int minimo, maximo, valor, cambioGrande = 1, cambioPequeno = 1, posicionArrastre;
        bool sobreBarra, arrastrando;

        public event EventHandler ValueChanged;
        public int Minimum { get { return minimo; } set { minimo = value; ValorSeguro(); Invalidate(); } }
        public int Maximum { get { return maximo; } set { maximo = Math.Max(minimo, value); ValorSeguro(); Invalidate(); } }
        public int LargeChange { get { return cambioGrande; } set { cambioGrande = Math.Max(1, value); ValorSeguro(); Invalidate(); } }
        public int SmallChange { get { return cambioPequeno; } set { cambioPequeno = Math.Max(1, value); } }
        public int Value
        {
            get { return valor; }
            set
            {
                int nuevo = Math.Max(minimo, Math.Min(MaximoDesplazamiento, value));
                if (nuevo == valor) return;
                valor = nuevo;
                Invalidate();
                if (ValueChanged != null) ValueChanged(this, EventArgs.Empty);
            }
        }

        int MaximoDesplazamiento { get { return Math.Max(minimo, maximo - cambioGrande + 1); } }

        public BarraDeslizamiento(bool horizontal)
        {
            this.horizontal = horizontal;
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
            BackColor = Color.Transparent;
            Cursor = Cursors.Hand;
        }

        RectangleF RectanguloControlDeslizante()
        {
            float largo = horizontal ? Width : Height;
            float inicio = 2f;
            float recorrido = Math.Max(1f, largo - 4f);
            float rango = Math.Max(1f, maximo - minimo + 1f);
            float largoControl = Math.Max(22f, recorrido * cambioGrande / rango);
            largoControl = Math.Min(recorrido, largoControl);
            float espacio = Math.Max(0f, recorrido - largoControl);
            float posicion = espacio * (valor - minimo) / Math.Max(1f, MaximoDesplazamiento - minimo);

            if (horizontal)
                return new RectangleF(inicio + posicion, (Height - (sobreBarra || arrastrando ? 6f : 4f)) / 2f,
                    largoControl, sobreBarra || arrastrando ? 6f : 4f);
            return new RectangleF((Width - (sobreBarra || arrastrando ? 6f : 4f)) / 2f, inicio + posicion,
                sobreBarra || arrastrando ? 6f : 4f, largoControl);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Width < 4 || Height < 4 || maximo <= minimo) return;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            float centro = horizontal ? Height / 2f : Width / 2f;
            using (var pista = new Pen(Color.FromArgb(24, 195, 205, 245), 2f))
            {
                if (horizontal) g.DrawLine(pista, 3, centro, Width - 3, centro);
                else g.DrawLine(pista, centro, 3, centro, Height - 3);
            }

            RectangleF thumb = RectanguloControlDeslizante();
            int alpha = arrastrando ? 175 : sobreBarra ? 125 : 72;
            using (GraphicsPath ruta = Tema.Ruta(thumb, Math.Min(thumb.Width, thumb.Height) / 2f))
            using (var relleno = new LinearGradientBrush(thumb,
                Color.FromArgb(alpha, 185, 195, 255), Color.FromArgb(alpha, 165, 120, 255),
                horizontal ? 0f : 90f))
                g.FillPath(relleno, ruta);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            sobreBarra = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (!arrastrando)
            {
                sobreBarra = false;
                Invalidate();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button != MouseButtons.Left || maximo <= minimo) return;
            Focus();
            RectangleF thumb = RectanguloControlDeslizante();
            float punto = horizontal ? e.X : e.Y;
            float inicio = horizontal ? thumb.Left : thumb.Top;
            float fin = horizontal ? thumb.Right : thumb.Bottom;
            if (punto >= inicio && punto <= fin)
            {
                arrastrando = true;
                posicionArrastre = (int)(punto - inicio);
            }
            else
            {
                int direccion = punto < inicio ? -1 : 1;
                Value = valor + direccion * cambioGrande;
            }
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (!arrastrando) return;
            float largo = horizontal ? Width : Height;
            float recorrido = Math.Max(1f, largo - 4f);
            float largoControl = horizontal ? RectanguloControlDeslizante().Width : RectanguloControlDeslizante().Height;
            float espacio = Math.Max(1f, recorrido - largoControl);
            float punto = (horizontal ? e.X : e.Y) - posicionArrastre - 2f;
            float proporcion = Math.Max(0f, Math.Min(1f, punto / espacio));
            Value = minimo + (int)Math.Round(proporcion * (MaximoDesplazamiento - minimo));
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left)
            {
                arrastrando = false;
                sobreBarra = ClientRectangle.Contains(e.Location);
                Invalidate();
            }
        }

        void ValorSeguro()
        {
            valor = Math.Max(minimo, Math.Min(MaximoDesplazamiento, valor));
        }
    }

    // Pestañas segmentadas: Consultar / Gestionar / Resumen
    public class Pestanas : Control
    {
        public string[] Textos = { "Consultar", "Gestionar", "Resumen" }; public string[] Claves = { "\U0001F50D", "\u2699", "\U0001F4CA" };
        int sel; public event EventHandler Cambio;
        public int Seleccion { get { return sel; } set { sel = value; Invalidate(); if (Cambio != null) Cambio(this, EventArgs.Empty); } }
        public Pestanas() { SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true); BackColor = Color.Transparent; Cursor = Cursors.Hand; }
        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias; g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            if (Width < 30 || Height < 20) return;
            using (var p = Tema.Ruta(new RectangleF(0.5f, 0.5f, Width - 2, Height - 2), 14))
            { using (var b = new SolidBrush(Color.FromArgb(90, 14, 28, 100))) g.FillPath(b, p); using (var pn = new Pen(Color.FromArgb(110, 70, 100, 230))) g.DrawPath(pn, p); }
            int n = Textos.Length; float w = Width / (float)n;
            for (int i = 0; i < n; i++)
            {
                var rc = new RectangleF(i * w + 2, 2, w - 4, Height - 5);
                if (i == sel)
                    using (var p = Tema.Ruta(rc, 12)) { using (var b = new LinearGradientBrush(rc, Color.FromArgb(150, 70, 255), Color.FromArgb(255, 70, 210), 0f)) g.FillPath(b, p); using (var pn = new Pen(Color.FromArgb(150, 255, 255, 255), 1.4f)) g.DrawPath(pn, p); }
                using (var f = Tema.F(11.5f, i == sel)) using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    float tw = g.MeasureString(Textos[i], f).Width, x = rc.X + (rc.Width - tw - 34) / 2f;
                    Iconos.Dibujar(g, Claves[i], new RectangleF(x, rc.Y + (rc.Height - 22) / 2f, 22, 22), Color.White, 1.9f);
                    g.DrawString(Textos[i], f, Brushes.White, new RectangleF(x + 32, rc.Y, tw + 10, rc.Height), sf);
                }
            }
        }
        protected override void OnMouseDown(MouseEventArgs e) { base.OnMouseDown(e); int i = Math.Min(Textos.Length - 1, e.X * Textos.Length / Math.Max(1, Width)); if (i != sel) Seleccion = i; }
    }
}
