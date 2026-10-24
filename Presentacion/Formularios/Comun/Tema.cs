using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SistemaPublicidad.Formularios
{
    public static class Tema
    {
        public static readonly Color Fondo = Color.FromArgb(7, 12, 45);
        public static readonly Color Panel = Color.FromArgb(14, 27, 88);
        public static readonly Color Panel2 = Color.FromArgb(10, 20, 70);
        public static readonly Color Campo = Color.FromArgb(20, 38, 125);
        public static readonly Color Borde = Color.FromArgb(70, 105, 255);
        public static readonly Color Sub = Color.FromArgb(175, 190, 235);
        public static readonly Color Cian = Color.FromArgb(0, 230, 200);
        public static readonly Color Morado = Color.FromArgb(150, 60, 255);
        public static readonly Color Rosa = Color.FromArgb(255, 60, 190);
        public static readonly Color Azul = Color.FromArgb(40, 110, 255);
        public static readonly Color Naranja = Color.FromArgb(255, 140, 30);

        static readonly bool semi = TieneFuente("Segoe UI Semibold");
        static bool TieneFuente(string n) { foreach (var f in FontFamily.Families) if (f.Name == n) return true; return false; }
        public static Font F(float s, bool b = false)
        {
            if (!b) return new Font("Segoe UI", s, FontStyle.Regular, GraphicsUnit.Point);
            return semi ? new Font("Segoe UI Semibold", s, FontStyle.Regular, GraphicsUnit.Point) : new Font("Segoe UI", s, FontStyle.Bold, GraphicsUnit.Point);
        }

        public static GraphicsPath Ruta(RectangleF r, float rad)
        {
            var p = new GraphicsPath(); float d = Math.Max(1, rad * 2);
            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure(); return p;
        }

        public static void Icono(Graphics g, Rectangle r, Color a, Color b, string emoji, bool circulo = false)
        {
            if (r.Width < 4 || r.Height < 4) return;
            using (var p = Ruta(r, circulo ? r.Width / 2f : r.Width / 4f))
            using (var br = new LinearGradientBrush(r, a, b, 45f)) g.FillPath(br, p);
            Iconos.Dibujar(g, emoji, new RectangleF(r.X + r.Width * 0.23f, r.Y + r.Height * 0.23f, r.Width * 0.54f, r.Height * 0.54f), Color.White);
        }

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern IntPtr SendMessage(IntPtr h, int m, IntPtr w, string l);
        public static void Cue(TextBox t, string s)
        { t.HandleCreated += (a, b) => { try { SendMessage(t.Handle, 0x1501, (IntPtr)1, s); } catch (Exception) { } }; }

        public static void PintarFondo(Graphics g, Control c)
        {
            Control root = c; int ox = 0, oy = 0;
            while (root.Parent != null) { ox += root.Left; oy += root.Top; root = root.Parent; }
            var sz = root.ClientSize; if (sz.Width < 10 || sz.Height < 10) return;
            if (fondoCache == null)
            {
                CrearFondo(sz);
            }
            else if (fondoCache.Width != sz.Width || fondoCache.Height != sz.Height)
                ProgramarFondo(root, sz);

            var st = g.Save(); g.TranslateTransform(-ox, -oy);
            var cb = Rectangle.Intersect(Rectangle.Ceiling(g.ClipBounds), new Rectangle(0, 0, sz.Width, sz.Height));
            if (cb.Width > 0 && cb.Height > 0)
            {
                if (fondoCache.Width == sz.Width && fondoCache.Height == sz.Height)
                    g.DrawImage(fondoCache, cb, cb, GraphicsUnit.Pixel);
                else
                    g.DrawImage(fondoCache, new Rectangle(0, 0, sz.Width, sz.Height));
            }
            g.Restore(st);
        }
        static Bitmap fondoCache;
        static Timer temporizadorFondo;
        static Control raizFondo;
        static Size tamanoFondoSolicitado;

        // Mientras el usuario redimensiona se escala el fondo anterior y se calcula el nuevo al hacer una pausa.
        static void ProgramarFondo(Control root, Size sz)
        {
            raizFondo = root;
            tamanoFondoSolicitado = sz;
            if (temporizadorFondo == null)
            {
                temporizadorFondo = new Timer { Interval = 140 };
                temporizadorFondo.Tick += (s, e) =>
                {
                    temporizadorFondo.Stop();
                    if (raizFondo == null || raizFondo.IsDisposed) return;
                    CrearFondo(tamanoFondoSolicitado);
                    raizFondo.Invalidate(true);
                };
            }
            temporizadorFondo.Stop();
            temporizadorFondo.Start();
        }

        static void CrearFondo(Size sz)
        {
            var nuevo = new Bitmap(sz.Width, sz.Height);
            using (var gb = Graphics.FromImage(nuevo)) PintarFondoBase(gb, sz);
            var anterior = fondoCache;
            fondoCache = nuevo;
            if (anterior != null) anterior.Dispose();
        }

        static void PintarFondoBase(Graphics g, Size sz)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            float W = sz.Width, H = sz.Height; var rect = new Rectangle(0, 0, sz.Width, sz.Height);
            using (var b = new LinearGradientBrush(rect, Color.FromArgb(2, 10, 56), Color.FromArgb(8, 14, 80), 60f)) g.FillRectangle(b, rect);
            Glow(g, W * .70f, 0, W * .35f, H * .45f, Color.FromArgb(150, 90, 60, 255));
            Glow(g, W * .10f, H, W * .30f, H * .40f, Color.FromArgb(110, 30, 90, 255));
            Glow(g, W * .98f, H * .95f, W * .30f, H * .45f, Color.FromArgb(150, 255, 50, 190));
            using (var p = new GraphicsPath())
            {
                p.AddBezier(W * .46f, 0, W * .56f, H * .16f, W * .70f, H * .24f, W * .80f, H * .12f);
                p.AddBezier(W * .80f, H * .12f, W * .88f, H * .03f, W * .95f, H * .06f, W, H * .16f);
                p.AddLine(W, H * .16f, W, 0); p.CloseFigure();
                using (var b = new LinearGradientBrush(new RectangleF(W * .46f, 0, W * .54f, H * .26f), Color.FromArgb(215, 30, 110, 255), Color.FromArgb(215, 190, 60, 255), 20f)) g.FillPath(b, p);
            }
            using (var gl = new Pen(Color.FromArgb(50, 255, 70, 200), W * .018f) { StartCap = LineCap.Round, EndCap = LineCap.Round }) g.DrawBezier(gl, W * .62f, H * .17f, W * .75f, H * .20f, W * .86f, H * .06f, W * .97f, H * .02f);
            using (var gb = new LinearGradientBrush(new PointF(W * .62f, 0), new PointF(W * .97f, 0), Color.FromArgb(255, 70, 200), Color.FromArgb(80, 210, 255)))
            using (var pn = new Pen(gb, 3f) { StartCap = LineCap.Round, EndCap = LineCap.Round }) g.DrawBezier(pn, W * .62f, H * .17f, W * .75f, H * .20f, W * .86f, H * .06f, W * .97f, H * .02f);
            using (var p = new GraphicsPath())
            {
                p.AddBezier(W * .50f, H, W * .66f, H * .84f, W * .84f, H * .96f, W, H * .72f); p.AddLine(W, H * .72f, W, H); p.CloseFigure();
                using (var b = new LinearGradientBrush(new RectangleF(W * .5f, H * .7f, W * .5f, H * .3f), Color.FromArgb(210, 120, 60, 255), Color.FromArgb(220, 255, 60, 190), 0f)) g.FillPath(b, p);
            }
            using (var p = new GraphicsPath())
            {
                p.AddBezier(W * .72f, H, W * .82f, H * .90f, W * .92f, H * .97f, W, H * .84f); p.AddLine(W, H * .84f, W, H); p.CloseFigure();
                using (var b = new SolidBrush(Color.FromArgb(150, 255, 120, 220))) g.FillPath(b, p);
            }
        }
        public static void Glow(Graphics g, float cx, float cy, float rx, float ry, Color c)
        {
            using (var p = new GraphicsPath())
            {
                p.AddEllipse(cx - rx, cy - ry, rx * 2, ry * 2);
                using (var b = new PathGradientBrush(p) { CenterColor = c, SurroundColors = new[] { Color.FromArgb(0, c) } }) g.FillPath(b, p);
            }
        }

        public static Label L(string t, float size, Color c, int x, int y, bool bold = false)
        { return new Label { Text = t, AutoSize = true, Font = F(size, bold), ForeColor = c, BackColor = Color.Transparent, Left = x, Top = y }; }
    }

    public class Tarjeta : Panel
    {
        Color c1 = Tema.Panel, c2 = Tema.Panel2, borde = Tema.Borde; int radio = 16;
        public Color C1 { get { return c1; } set { c1 = value; Invalidate(); } }
        public Color C2 { get { return c2; } set { c2 = value; Invalidate(); } }
        public Color ColorBorde { get { return borde; } set { borde = value; Invalidate(); } }
        public int Radio { get { return radio; } set { radio = value; Invalidate(); } }

        public Tarjeta()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            BackColor = Color.Transparent;
        }

        int opacidad = 255; bool vidrio = true, hover; Color brillo = Color.Transparent, brillo2 = Color.Transparent;
        public bool Vidrio { get { return vidrio; } set { vidrio = value; Invalidate(); } }
        public int Opacidad { get { return opacidad; } set { opacidad = Math.Max(0, Math.Min(255, value)); Invalidate(); } }
        Color Op(Color x) { return Color.FromArgb(x.A * opacidad / 255, x); }
        public Color Brillo { get { return brillo; } set { brillo = value; Invalidate(); } }
        public Color Brillo2 { get { return brillo2; } set { brillo2 = value; Invalidate(); } }
        protected override void OnMouseEnter(EventArgs e) { base.OnMouseEnter(e); hover = true; Invalidate(); }
        protected override void OnMouseLeave(EventArgs e) { base.OnMouseLeave(e); hover = false; Invalidate(); }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Width < 4 || Height < 4) return;
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias; g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            var r = new RectangleF(0.5f, 0.5f, Width - 2, Height - 2);
            using (var p = Tema.Ruta(r, radio))
            {
                using (var b = new LinearGradientBrush(ClientRectangle, Op(c1), Op(c2), 35f)) g.FillPath(b, p);
                if (vidrio && c1.A > 0) using (var b = new LinearGradientBrush(ClientRectangle, Color.FromArgb(14, 255, 255, 255), Color.FromArgb(0, 255, 255, 255), 90f)) g.FillPath(b, p);
                if (brillo.A > 0 || brillo2.A > 0)
                {
                    GraphicsState estadoClip = g.Save();
                    g.SetClip(p);
                    if (brillo.A > 0) Tema.Glow(g, Width, Height, Width * 0.75f, Height * 0.9f, brillo);
                    if (brillo2.A > 0) Tema.Glow(g, 0, 0, Width * 0.6f, Height * 0.8f, brillo2);
                    g.Restore(estadoClip);
                }
                if (hover && Cursor == Cursors.Hand) using (var b = new SolidBrush(Color.FromArgb(30, 255, 255, 255))) g.FillPath(b, p);
                if (borde.A > 0)
                    using (var b = new LinearGradientBrush(ClientRectangle, Color.FromArgb(borde.A, Math.Min(255, borde.R + 60), Math.Min(255, borde.G + 60), Math.Min(255, borde.B + 60)), Color.FromArgb(Math.Max(40, borde.A / 2), borde), 60f))
                    using (var pen = new Pen(b, 1.4f)) g.DrawPath(pen, p);
            }
            base.OnPaint(e);
        }
    }

    public class IconoBox : Control
    {
        public string Emoji { get; set; } = ""; public Color A { get; set; } = Tema.Azul; public Color B { get; set; } = Tema.Morado;
        public IconoBox() { SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true); BackColor = Color.Transparent; }
        protected override void OnPaint(PaintEventArgs e)
        { e.Graphics.SmoothingMode = SmoothingMode.AntiAlias; Tema.Icono(e.Graphics, new Rectangle(0, 0, Width - 1, Height - 1), A, B, Emoji); }
    }

    public class Boton : Tarjeta
    {
        public string Texto { get; set; } = ""; public string Icono { get; set; } = "";
        public Boton() { Cursor = Cursors.Hand; Radio = 12; C1 = Tema.Azul; C2 = Tema.Morado; ColorBorde = Color.Transparent; }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); var g = e.Graphics;
            using (var f = Tema.F(10, true))
            {
                var m = g.MeasureString(Texto, f); float tot = (Icono == "" ? 0 : 28) + m.Width, x = (Width - tot) / 2f;
                if (Icono != "") Iconos.Dibujar(g, Icono, new RectangleF(x, (Height - 20) / 2f, 20, 20), Color.White, 1.9f);
                g.DrawString(Texto, f, Brushes.White, x + (Icono == "" ? 0 : 28), (Height - m.Height) / 2f);
            }
        }
    }

    public class ItemMenu : Tarjeta
    {
        bool activo, expandido; public Color ColorIcono = Color.White; public string Texto { get; set; } = ""; public string Icono { get; set; } = "";
        public int Nivel { get; set; } public bool Expandible { get; set; } public bool Caja { get; set; } public Bitmap Imagen { get; set; } public ItemMenu Padre { get; set; } public System.Collections.Generic.List<ItemMenu> Hijos { get; set; }
        public bool Expandido { get { return expandido; } set { expandido = value; Invalidate(); } }
        public bool Activo { get { return activo; } set { activo = value; C1 = value ? Color.FromArgb(105, 40, 255) : Color.Transparent; C2 = value ? Color.FromArgb(235, 75, 245) : Color.Transparent; } }
        public ItemMenu() { Cursor = Cursors.Hand; Radio = 12; ColorBorde = Color.Transparent; C1 = C2 = Color.Transparent; }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); var g = e.Graphics;
            int isz = Nivel == 0 ? 20 : 18, ix = Nivel == 0 ? 14 : 16, tx = ix + isz + 14;
            var ri = new RectangleF(ix, (Height - isz) / 2f, isz, isz);
            if (Caja)
            {
                using (var pc = Tema.Ruta(new RectangleF(ri.X - 1, ri.Y - 1, isz + 2, isz + 2), 5)) using (var pn = new Pen(Color.White, 1.7f)) g.DrawPath(pn, pc);
                ri = new RectangleF(ri.X + isz * .2f, ri.Y + isz * .2f, isz * .6f, isz * .6f);
            }
            if (Imagen != null) Recursos.Dibujar(g, Imagen, new RectangleF(ix - 3, (Height - 26) / 2f, 26, 26)); else Iconos.Dibujar(g, Icono, ri, activo ? Color.White : ColorIcono, 1.6f);
            using (var f = Tema.F(Nivel == 0 ? 11f : 10f, activo)) using (var sf = new StringFormat { LineAlignment = StringAlignment.Center, Trimming = StringTrimming.EllipsisCharacter })
                g.DrawString(Texto, f, Brushes.White, new RectangleF(tx, 0, Math.Max(10, Width - tx - 30), Height), sf);
            if (Expandible)
            {
                float cx = Width - 22, cy = Height / 2f;
                using (var pen = new Pen(Color.White, 2f) { StartCap = LineCap.Round, EndCap = LineCap.Round })
                    g.DrawLines(pen, expandido ? new[] { new PointF(cx - 5, cy - 2.5f), new PointF(cx, cy + 2.5f), new PointF(cx + 5, cy - 2.5f) }
                                               : new[] { new PointF(cx - 2.5f, cy - 5), new PointF(cx + 2.5f, cy), new PointF(cx - 2.5f, cy + 5) });
            }
        }
    }

    public class TarjetaStat : Tarjeta
    {
        string v = "0", d = "", s = "";
        public string Titulo { get; set; } = ""; public string Icono { get; set; } = "";
        public string Valor { get { return v; } set { v = value; Invalidate(); } }
        public bool DeltaLinea { get; set; } public bool Circulo { get; set; } public Bitmap Glifo { get; set; } public string Tendencia { get; set; } = "";
        public string Delta { get { return d; } set { d = value; Invalidate(); } }
        public string Sub { get { return s; } set { s = value; Invalidate(); } }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); var g = e.Graphics;
            using (var wp = Tema.Ruta(new RectangleF(0.5f, 0.5f, Width - 2, Height - 2), Radio))
            {
                GraphicsState estadoClip = g.Save();
                g.SetClip(wp);
                Tema.Glow(g, Width, Height, Width * 0.5f, Height, Color.FromArgb(35, 255, 255, 255));
                using (var bb = new SolidBrush(Color.FromArgb(16, 255, 255, 255))) { g.FillEllipse(bb, Width - Height * 0.9f, -Height * 0.35f, Height * 1.1f, Height * 1.1f); g.FillEllipse(bb, Width * 0.55f, Height * 0.55f, Height * 0.9f, Height * 0.9f); }
                Iconos.Dibujar(g, Icono, new RectangleF(Width - Height * 0.95f, Height * 0.2f, Height * 0.8f, Height * 0.8f), Color.FromArgb(34, 255, 255, 255), Height * 0.07f);
                g.Restore(estadoClip);
            }
            int sz = Math.Max(30, Math.Min(64, Height - 30));
            var ir = new Rectangle(16, (Height - sz) / 2, sz, sz);
            if (Glifo != null)
            {
                using (var bd = new SolidBrush(Color.FromArgb(55, 255, 255, 255))) g.FillEllipse(bd, ir);
                using (var pd = new Pen(Color.FromArgb(120, 255, 255, 255), 1.5f)) g.DrawEllipse(pd, ir.X, ir.Y, ir.Width - 1, ir.Height - 1);
                Recursos.Dibujar(g, Glifo, new RectangleF(ir.X + sz * .16f, ir.Y + sz * .16f, sz * .68f, sz * .68f));
            }
            else Tema.Icono(g, ir, Color.FromArgb(70, 255, 255, 255), Color.FromArgb(35, 255, 255, 255), Icono, Circulo);
            int x = 16 + sz + 16;
            using (var f = Tema.F(10)) g.DrawString(Titulo, f, Brushes.White, x, Height * (Tendencia != "" ? 0.08f : 0.12f));
            float vs = 28f;
            for (; vs > 12f; vs -= 1f) using (var fm = Tema.F(vs, true)) if (g.MeasureString(Valor, fm).Width <= Width - x - 14) break;
            using (var f = Tema.F(vs, true)) g.DrawString(Valor, f, Brushes.White, x, Height * (Tendencia != "" ? 0.24f : 0.32f));
            if (Tendencia != "")
            {
                float ay = Height * 0.62f;
                using (var pn = new Pen(Color.White, 2f) { StartCap = LineCap.Round, EndCap = LineCap.Round }) { g.DrawLines(pn, new[] { new PointF(x, ay + 8), new PointF(x + 4, ay + 3), new PointF(x + 8, ay + 8) }); g.DrawLine(pn, x + 4, ay + 3, x + 4, ay + 14); }
                using (var f = Tema.F(9, true)) g.DrawString(Tendencia, f, Brushes.White, x + 14, ay);
                using (var f = Tema.F(8.5f)) using (var b = new SolidBrush(Color.FromArgb(225, 255, 255, 255))) g.DrawString(Sub, f, b, x, Height * 0.79f);
            }
            else using (var f = Tema.F(9)) using (var b = new SolidBrush(Color.FromArgb(220, 255, 255, 255))) g.DrawString(Sub, f, b, x, Height * 0.74f);
            if (d != "" && DeltaLinea) using (var f = Tema.F(11, true)) { var m2 = g.MeasureString(d, f); g.DrawString(d, f, Brushes.White, Width - m2.Width - 18, Height * 0.5f); }
            else if (d != "")
                using (var f = Tema.F(9, true))
                {
                    var m = g.MeasureString(d, f); var r = new RectangleF(Width - m.Width - 28, 12, m.Width + 12, 24);
                    using (var p = Tema.Ruta(r, 12)) using (var b = new SolidBrush(Color.FromArgb(60, 255, 255, 255))) g.FillPath(b, p);
                    g.DrawString(d, f, Brushes.White, r.X + 6, r.Y + 2);
                }
        }
    }

    public class TarjetaAccion : Tarjeta
    {
        public string Titulo { get; set; } = ""; public string Sub { get; set; } = ""; public string Icono { get; set; } = "";
        public Color IA { get; set; } = Tema.Azul; public Color IB { get; set; } = Tema.Morado;
        public TarjetaAccion() { Cursor = Cursors.Hand; }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); var g = e.Graphics;
            Tema.Icono(g, new Rectangle(14, (Height - 48) / 2, 48, 48), IA, IB, Icono);
            using (var f = Tema.F(12, true)) g.DrawString(Titulo, f, Brushes.White, 74, Height / 2 - 24);
            using (var f = Tema.F(8)) using (var b = new SolidBrush(Tema.Sub)) g.DrawString(Sub, f, b, 76, Height / 2 + 4);
            using (var f = Tema.F(14)) using (var b = new SolidBrush(Tema.Sub)) g.DrawString("›", f, b, Width - 28, Height / 2 - 14);
        }
    }
}
