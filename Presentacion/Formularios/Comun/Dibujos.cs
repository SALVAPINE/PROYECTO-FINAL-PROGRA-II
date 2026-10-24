using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SistemaPublicidad.Formularios
{
    public static class Dibujos
    {
        public static void Megafono(Graphics g, Rectangle r)
        {
            if (r.Width < 60 || r.Height < 40) return;
            float s = Math.Min(r.Width / 230f, r.Height / 140f) * 0.8f;
            // esferas flotantes
            using (var p = new GraphicsPath()) { var c = new RectangleF(r.Right - 44, r.Y + 26, 26, 26); p.AddEllipse(c);
                using (var b = new LinearGradientBrush(c, Color.FromArgb(255, 90, 200), Color.FromArgb(120, 60, 220), 45f)) g.FillPath(b, p); }
            using (var b = new SolidBrush(Color.FromArgb(160, 60, 120, 255))) g.FillEllipse(b, r.X + 6, r.Bottom - 30, 18, 18);
            var st = g.Save();
            g.TranslateTransform(r.X + r.Width * 0.42f, r.Y + r.Height * 0.6f); g.RotateTransform(-18); g.ScaleTransform(s, s);
            using (var b = new SolidBrush(Color.FromArgb(40, 255, 255, 255))) g.FillEllipse(b, -100, -70, 240, 140);
            var rc = new RectangleF(-84, -24, 28, 48);
            using (var b = new SolidBrush(Color.FromArgb(90, 40, 200))) g.FillEllipse(b, rc);
            using (var p = Tema.Ruta(new RectangleF(-42, 18, 24, 46), 8)) using (var b = new LinearGradientBrush(new RectangleF(-42, 18, 24, 46), Tema.Morado, Tema.Azul, 90f)) g.FillPath(b, p);
            var cono = new[] { new PointF(-66, -24), new PointF(50, -60), new PointF(50, 60), new PointF(-66, 24) };
            using (var b = new LinearGradientBrush(new RectangleF(-70, -60, 124, 120), Color.FromArgb(70, 130, 255), Color.FromArgb(160, 60, 255), 0f)) g.FillPolygon(b, cono);
            using (var b = new LinearGradientBrush(new RectangleF(-70, -60, 124, 40), Color.FromArgb(70, 255, 255, 255), Color.FromArgb(0, 255, 255, 255), 90f)) g.FillPolygon(b, cono);
            var boca = new RectangleF(36, -62, 36, 124);
            using (var b = new LinearGradientBrush(boca, Tema.Cian, Tema.Azul, 90f)) g.FillEllipse(b, boca);
            using (var b = new SolidBrush(Color.FromArgb(235, 20, 20, 90))) g.FillEllipse(b, 47, -48, 16, 96);
            Color[] lc = { Tema.Naranja, Tema.Rosa, Color.FromArgb(255, 200, 60) };
            float[][] ln = { new[] { 92f, -34f, 114f, -48f }, new[] { 98f, 0f, 128f, 0f }, new[] { 92f, 34f, 114f, 48f } };
            for (int k = 0; k < 3; k++) using (var p = new Pen(lc[k], 7) { StartCap = LineCap.Round, EndCap = LineCap.Round }) g.DrawLine(p, ln[k][0], ln[k][1], ln[k][2], ln[k][3]);
            g.Restore(st);
        }

        public static void Portapapeles(Graphics g, Rectangle r)
        {
            var st = g.Save(); g.TranslateTransform(r.X + r.Width / 2f, r.Y + r.Height / 2f); g.RotateTransform(8);
            float w = r.Width * 0.8f, h = r.Height * 0.95f; var rr = new RectangleF(-w / 2, -h / 2, w, h);
            using (var p = Tema.Ruta(rr, 10)) { using (var b = new LinearGradientBrush(rr, Color.FromArgb(70, 110, 255), Color.FromArgb(110, 50, 220), 60f)) g.FillPath(b, p);
                using (var pen = new Pen(Color.FromArgb(120, 255, 255, 255), 1.5f)) g.DrawPath(pen, p); }
            using (var p = Tema.Ruta(new RectangleF(-w * 0.22f, -h / 2 - 6, w * 0.44f, 16), 5)) using (var b = new SolidBrush(Color.FromArgb(40, 60, 170))) g.FillPath(b, p);
            for (int k = 0; k < 4; k++)
                using (var p = Tema.Ruta(new RectangleF(-w * 0.32f, -h * 0.22f + k * h * 0.17f, w * (k == 3 ? 0.35f : 0.64f), 6), 3)) using (var b = new SolidBrush(Color.FromArgb(170, 255, 255, 255))) g.FillPath(b, p);
            var ck = new RectangleF(w * 0.12f, h * 0.2f, 34, 34);
            using (var b = new LinearGradientBrush(ck, Tema.Cian, Color.FromArgb(0, 180, 120), 45f)) g.FillEllipse(b, ck);
            using (var f = Tema.F(12, true)) using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center }) g.DrawString("✓", f, Brushes.White, ck, sf);
            g.Restore(st);
        }

        static void Persona(Graphics g, float cx, float baseY, float s, int alfa)
        {
            var cuerpo = new RectangleF(cx - s * 0.4f, baseY - s * 0.5f, s * 0.8f, s * 0.5f);
            var cab = new RectangleF(cx - s * 0.2f, baseY - s * 0.95f, s * 0.4f, s * 0.4f);
            using (var b = new LinearGradientBrush(new RectangleF(cx - s * 0.4f, baseY - s, s * 0.8f, s), Color.FromArgb(alfa, Tema.Rosa), Color.FromArgb(alfa, Tema.Morado), 90f))
            { g.FillEllipse(b, cab); using (var p = Tema.Ruta(cuerpo, s * 0.25f)) g.FillPath(b, p); }
        }
        public static void Gente(Graphics g, Rectangle r)
        {
            Persona(g, r.X + r.Width * 0.18f, r.Bottom, r.Height * 0.7f, 110);
            Persona(g, r.X + r.Width * 0.82f, r.Bottom, r.Height * 0.7f, 110);
            Persona(g, r.X + r.Width * 0.5f, r.Bottom, r.Height * 0.95f, 190);
        }
    }

    // Logo de la marca: cuadro redondeado rosa-naranja con megáfono blanco
    public class LogoBox : Control
    {
        public LogoBox() { SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true); BackColor = Color.Transparent; }
        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias; g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            float W = Width - 1, H = Height - 1; if (W < 8 || H < 8) return;
            var lg = Recursos.Img("logo"); if (lg != null) { Recursos.Dibujar(g, lg, new RectangleF(0, 0, Width, Height)); return; }
            var rr = new RectangleF(0, 0, W, H);
            using (var sh = new SolidBrush(Color.FromArgb(50, 255, 80, 140))) using (var ps = Tema.Ruta(new RectangleF(2, 4, W - 3, H - 3), W * 0.30f)) g.FillPath(sh, ps);
            using (var p = Tema.Ruta(rr, W * 0.30f))
            {
                using (var b = new LinearGradientBrush(rr, Color.FromArgb(255, 70, 185), Color.FromArgb(150, 75, 255), 45f)) g.FillPath(b, p);
                using (var b = new LinearGradientBrush(rr, Color.FromArgb(55, 255, 255, 255), Color.FromArgb(0, 255, 255, 255), 90f)) g.FillPath(b, p);
            }
            using (var pen = new Pen(Color.White, Math.Max(1.6f, W / 16f)) { StartCap = LineCap.Round, EndCap = LineCap.Round })
                g.DrawArc(pen, W * .34f, H * .16f, W * .32f, H * .36f, 180, 180);
            using (var br = new SolidBrush(Color.White)) using (var pb = Tema.Ruta(new RectangleF(W * .22f, H * .34f, W * .56f, H * .48f), W * .09f)) g.FillPath(br, pb);
            using (var br = new SolidBrush(Color.FromArgb(255, 80, 150))) g.FillEllipse(br, W * .45f, H * .52f, W * .10f, H * .10f);
        }
    }

    // Menú lateral con ola decorativa inferior
    public class Lateral : Tarjeta
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var clip = Tema.Ruta(new RectangleF(0.5f, 0.5f, Width - 2, Height - 2), Radio))
            {
                GraphicsState estadoClip = g.Save();
                g.SetClip(clip, CombineMode.Intersect);
                Ola(g, new[] { new PointF(0, Height * .93f), new PointF(Width * .35f, Height * .86f), new PointF(Width * .7f, Height * .90f), new PointF(Width, Height * .80f) }, Color.FromArgb(215, Tema.Naranja), Color.FromArgb(215, Tema.Morado));
                Ola(g, new[] { new PointF(0, Height * .98f), new PointF(Width * .4f, Height * .93f), new PointF(Width * .75f, Height * .96f), new PointF(Width, Height * .88f) }, Color.FromArgb(225, Tema.Rosa), Color.FromArgb(190, Tema.Azul));
                g.Restore(estadoClip);
            }
        }
        void Ola(Graphics g, PointF[] pts, Color a, Color b)
        {
            using (var p = new GraphicsPath())
            {
                p.AddCurve(pts, 0.4f); p.AddLine(pts[pts.Length - 1], new PointF(Width, Height)); p.AddLine(new PointF(Width, Height), new PointF(0, Height)); p.CloseFigure();
                using (var br = new LinearGradientBrush(ClientRectangle, a, b, 0f)) g.FillPath(br, p);
            }
        }
    }

    // Encabezado de Inicio: título e ilustración tomados de la referencia
    public class Bienvenida : Control
    {
        public Bienvenida() { SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true); BackColor = Color.Transparent; }
        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias; g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            var sb = new System.Text.StringBuilder(); foreach (char ch in "SISTEMA DE GESTIÓN") { sb.Append(ch); sb.Append('\u200A'); }
            using (var f = Tema.F(9.5f, true)) using (var b = new SolidBrush(Tema.Cian)) g.DrawString(sb.ToString(), f, b, 2, 0);
            var tit = Recursos.Img("titulo");
            if (tit != null) Recursos.Dibujar(g, tit, new RectangleF(-4, 12, tit.Width * .84f, tit.Height * .84f));
            using (var f = Tema.F(12.5f)) using (var b = new SolidBrush(Color.FromArgb(205, 218, 255))) g.DrawString("Aquí tienes un resumen general de tu sistema.", f, b, 2, 82);
            using (var b = new LinearGradientBrush(new PointF(2, 0), new PointF(92, 0), Color.FromArgb(255, 175, 30), Tema.Rosa)) using (var pn = new Pen(b, 4) { StartCap = LineCap.Round, EndCap = LineCap.Round }) g.DrawLine(pn, 5, 113, 90, 113);
            var lema = Recursos.Img("lema");
            if (lema != null && Width > 760)
            {
                float s = .95f, lx = Width - lema.Width * s - 24;
                Recursos.Dibujar(g, lema, new RectangleF(lx, 4, lema.Width * s, lema.Height * s));
                using (var gb = new LinearGradientBrush(new PointF(lx + 60, 0), new PointF(lx + 270, 0), Tema.Rosa, Tema.Cian)) using (var pn = new Pen(gb, 3.5f) { StartCap = LineCap.Round, EndCap = LineCap.Round })
                    g.DrawCurve(pn, new[] { new PointF(lx + 70 * s, 4 + 91 * s), new PointF(lx + 170 * s, 4 + 76 * s), new PointF(lx + 272 * s, 4 + 54 * s) });
            }
        }
    }
}
