using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace SistemaPublicidad.Formularios
{
    // Tarjeta con dona (Activo / Inactivo). Asigne Activos e Inactivos desde sus datos.
    public class Dona : Tarjeta
    {
        int a, i; public string Ilustracion = "";
        public string Titulo { get; set; } = ""; public string Icono { get; set; } = "";
        public int Activos { get { return a; } set { a = value; Invalidate(); } }
        public int Inactivos { get { return i; } set { i = value; Invalidate(); } }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); var g = e.Graphics;
            if (!Recursos.Tile(g, Icono == "👥" ? "t_gente" : "t_barras", new Rectangle(14, 10, 42, 42))) Tema.Icono(g, new Rectangle(16, 14, 34, 34), Tema.Azul, Tema.Morado, Icono);
            using (var f = Tema.F(12, true)) g.DrawString(Titulo, f, Brushes.White, 60, 19);
            int tot = a + i, s = Math.Min(Height - 80, Width / 3); if (s < 50) return;
            var rc = new Rectangle(34, 62, s, s); int w = Math.Max(8, s / 9);
            rc.Inflate(-w / 2, -w / 2);
            using (var p = new Pen(Color.FromArgb(40, 255, 255, 255), w)) g.DrawEllipse(p, rc);
            if (tot > 0)
            {
                float sa = 360f * a / tot;
                bool dos = a > 0 && i > 0;
                Action<Color, float, float> arco = (c, ini, bar) =>
                {
                    using (var p = new Pen(Color.FromArgb(45, c), w + 10)) g.DrawArc(p, rc, ini, bar);
                    Brush brs = c == Tema.Cian ? (Brush)new LinearGradientBrush(rc, Tema.Cian, Color.FromArgb(150, 80, 255), 135f) { InterpolationColors = new ColorBlend { Colors = new[] { Tema.Cian, Color.FromArgb(0, 235, 150), Color.FromArgb(150, 80, 255) }, Positions = new[] { 0f, .6f, 1f } } } : new SolidBrush(c);
                    using (brs) using (var p = new Pen(brs, w)) { if (dos) { p.StartCap = LineCap.Round; p.EndCap = LineCap.Round; } g.DrawArc(p, rc, ini, bar); }
                };
                if (a > 0) arco(Tema.Cian, -90, a == tot ? 359.9f : sa);
                if (i > 0) arco(Tema.Rosa, -90 + sa, i == tot ? 359.9f : 360 - sa);
            }
            var all = new RectangleF(34, 62, s, s);
            using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                using (var f = Tema.F(s / 6f, true)) g.DrawString(tot.ToString(), f, Brushes.White, new RectangleF(all.X, all.Y + s * 0.18f, s, s * 0.35f), sf);
                using (var f = Tema.F(9)) using (var b = new SolidBrush(Tema.Sub)) g.DrawString("Total", f, b, new RectangleF(all.X, all.Y + s * 0.5f, s, s * 0.2f), sf);
            }
            int x = 34 + s + 40, y = 62 + s / 2 - 50, ancho = Math.Max(160, Math.Min(300, Width - x - 140));
            string[] nom = { "Activo", "Inactivo" }; int[] val = { a, i }; Color[] col = { Tema.Cian, Tema.Rosa };
            for (int k = 0; k < 2; k++)
            {
                int yy = y + k * 42;
                using (var b = new SolidBrush(col[k])) g.FillEllipse(b, x, yy + 5, 16, 16);
                using (var f = Tema.F(11)) { g.DrawString(nom[k], f, Brushes.White, x + 28, yy);
                    g.DrawString(val[k] + " (" + (tot == 0 ? 0 : val[k] * 100 / tot) + "%)", f, Brushes.White, x + ancho - 70, yy); }
                using (var p = new Pen(Color.FromArgb(40, 255, 255, 255))) g.DrawLine(p, x, yy + 32, x + ancho, yy + 32);
            }
            var pill = new RectangleF(x, Math.Min(y + 92, Height - 46), Math.Min(ancho, 210), 30);
            using (var pa = Tema.Ruta(pill, 15)) using (var b = new LinearGradientBrush(pill, Color.FromArgb(0, 200, 170), Color.FromArgb(0, 130, 160), 0f)) g.FillPath(b, pa);
            using (var f = Tema.F(10, true)) g.DrawString((tot == 0 ? 0 : a * 100 / tot) + "% activas", f, Brushes.White, pill.X + 14, pill.Y + 5);
            var dc = Recursos.Img(Ilustracion == "clip" ? "deco_clip" : "deco_gente");
            if (dc != null && Ilustracion != "")
                using (var cp = Tema.Ruta(new RectangleF(1, 1, Width - 3, Height - 3), Radio))
                {
                    GraphicsState estadoClip = g.Save();
                    g.SetClip(cp, CombineMode.Intersect);
                    float sc = Math.Min(1f, (Height - 10) / (float)dc.Height), w2 = dc.Width * sc, h2 = dc.Height * sc;
                    Recursos.Dibujar(g, dc, new RectangleF(Width - w2 - 3, Height - h2 - 3, w2, h2));
                    g.Restore(estadoClip);
                }
            else if (Ilustracion == "clip") Dibujos.Portapapeles(g, new Rectangle(Width - 128, Height - 150, 100, 124));
            else if (Ilustracion == "gente") Dibujos.Gente(g, new Rectangle(Width - 170, Height - 125, 140, 100));
        }
    }

    // Línea de monto por mes. Asigne Meses y Valores desde sus datos.
    public class GraficaMes : Tarjeta
    {
        public string[] Meses = new string[0]; public decimal[] Valores = new decimal[0];
        public string Titulo { get; set; } = "Monto cotizado por mes";
        public bool EsMoneda { get; set; } = true;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); var g = e.Graphics;
            if (!Recursos.Tile(g, "t_grafica", new Rectangle(14, 10, 42, 42))) Tema.Icono(g, new Rectangle(16, 14, 34, 34), Tema.Azul, Tema.Morado, "📊");
            using (var f = Tema.F(12, true)) g.DrawString(Titulo, f, Brushes.White, 60, 19);
            int n = Meses.Length; if (n < 2 || Valores.Length != n) return;
            decimal max = Valores.Max(); decimal salto = EsMoneda ? 4000m : 5m;
            decimal top = Math.Max(salto, Math.Ceiling(max / salto) * salto);
            var pl = new RectangleF(86, 70, Width - 86 - 30, Height - 70 - 44);
            if (pl.Width < 50 || pl.Height < 30) return;
            for (int k = 0; k <= 4; k++)
            {
                float y = pl.Bottom - pl.Height * k / 4f;
                using (var p = new Pen(Color.FromArgb(35, 255, 255, 255))) g.DrawLine(p, pl.X, y, pl.Right, y);
                using (var f = Tema.F(9)) using (var b = new SolidBrush(Tema.Sub)) g.DrawString((EsMoneda ? "Q" : "") + (top * k / 4).ToString("N0"), f, b, 16, y - 10);
            }
            var pts = new PointF[n];
            for (int k = 0; k < n; k++)
            {
                pts[k] = new PointF(pl.X + pl.Width * k / (n - 1), pl.Bottom - (float)(Valores[k] / top) * pl.Height);
                using (var p = new Pen(Color.FromArgb(22, 255, 255, 255)) { DashStyle = DashStyle.Dash }) g.DrawLine(p, pts[k].X, pl.Y, pts[k].X, pl.Bottom);
                using (var f = Tema.F(9)) using (var b = new SolidBrush(Tema.Sub)) g.DrawString(Meses[k], f, b, pts[k].X - 22, pl.Bottom + 12);
            }
            using (var area = new GraphicsPath())
            {
                area.AddCurve(pts, 0.3f); area.AddLine(pts[n - 1], new PointF(pl.Right, pl.Bottom)); area.AddLine(new PointF(pl.Right, pl.Bottom), new PointF(pl.X, pl.Bottom)); area.CloseFigure();
                using (var b = new LinearGradientBrush(new RectangleF(pl.X, pl.Y, pl.Width, pl.Height), Color.FromArgb(140, Tema.Morado), Color.FromArgb(10, Tema.Azul), 90f)) g.FillPath(b, area);
            }
            using (var p = new Pen(Color.FromArgb(55, Tema.Rosa), 10)) g.DrawCurve(p, pts, 0.3f);
            using (var gb = new LinearGradientBrush(new PointF(pl.X, 0), new PointF(pl.Right, 0), Tema.Rosa, Tema.Cian)) using (var p = new Pen(gb, 3.5f)) g.DrawCurve(p, pts, 0.3f);
            foreach (var pt in pts) { g.FillEllipse(Brushes.White, pt.X - 5, pt.Y - 5, 10, 10); using (var p = new Pen(Tema.Morado, 2)) g.DrawEllipse(p, pt.X - 5, pt.Y - 5, 10, 10); }
            string t = (EsMoneda ? "Q" : "") + Valores[n - 1].ToString("N0"); var l = pts[n - 1];
            using (var f = Tema.F(9, true)) { var m = g.MeasureString(t, f); var r = new RectangleF(l.X - m.Width - 6, l.Y - 34, m.Width + 12, 24);
                using (var p = Tema.Ruta(r, 12)) using (var b = new SolidBrush(Tema.Rosa)) g.FillPath(b, p); g.DrawString(t, f, Brushes.White, r.X + 6, r.Y + 3); }
        }
    }

    // Lista de actividad reciente. Items: { titulo, detalle, hora }
    public class ListaActividad : Tarjeta
    {
        public List<string[]> Items = new List<string[]>();
        static readonly Color[][] Cols = { new[] { Tema.Azul, Tema.Morado }, new[] { Color.FromArgb(0, 200, 150), Tema.Cian }, new[] { Tema.Azul, Tema.Cian }, new[] { Tema.Naranja, Color.FromArgb(255, 190, 40) } };
        static readonly string[] Ic = { "📄", "👤", "🧾", "📝" }; static readonly string[] Tl = { "a_doc", "a_user", "a_fact", "a_caja" };
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); var g = e.Graphics;
            if (!Recursos.Tile(g, "t_reloj", new Rectangle(14, 10, 42, 42))) Tema.Icono(g, new Rectangle(16, 14, 34, 34), Tema.Azul, Tema.Morado, "🕒");
            using (var f = Tema.F(12, true)) g.DrawString("Actividad reciente", f, Brushes.White, 60, 19);
            int n = Items.Count; if (n == 0) return;
            int h = Math.Min(64, (Height - 64) / n);
            for (int k = 0; k < n; k++)
            {
                int y = 58 + k * h; var c = Cols[k % 4];
                if (!Recursos.Tile(g, Tl[k % 4], new Rectangle(14, y + (h - 38) / 2, 38, 38))) Tema.Icono(g, new Rectangle(16, y + (h - 34) / 2, 34, 34), c[0], c[1], Ic[k % 4]);
                using (var f = Tema.F(10.5f, true)) g.DrawString(Items[k][0], f, Brushes.White, 66, y + h / 2 - 20);
                using (var f = Tema.F(8.5f)) using (var b = new SolidBrush(Tema.Sub)) { g.DrawString(Items[k][1], f, b, 66, y + h / 2 + 1);
                    var m = g.MeasureString(Items[k][2], f); g.DrawString(Items[k][2], f, b, Width - m.Width - 18, y + h / 2 - 20); }
                if (k < n - 1) using (var p = new Pen(Color.FromArgb(30, 255, 255, 255))) g.DrawLine(p, 16, y + h, Width - 16, y + h);
            }
        }
    }
}
