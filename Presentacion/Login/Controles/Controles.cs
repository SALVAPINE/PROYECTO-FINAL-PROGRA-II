using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Login.Controles
{
    /// <summary>Utilidades de dibujo. Todas las coordenadas se expresan en unidades del mockup (1640x960) y se escalan con K.</summary>
    public static class U
    {
        public const float K = 0.75f;
        static readonly Dictionary<string, Font> cache = new Dictionary<string, Font>();

        public static int P(float v) { return (int)Math.Round(v * K); }
        public static Rectangle R(float x, float y, float w, float h) { return new Rectangle(P(x), P(y), P(w), P(h)); }

        public static PointF[] Pt(params float[] v)
        {
            var p = new PointF[v.Length / 2];
            for (int i = 0; i < p.Length; i++) p[i] = new PointF(v[2 * i] * K, v[2 * i + 1] * K);
            return p;
        }

        public static Font F(float px, FontStyle st, string fam)
        {
            string key = fam + "|" + px + "|" + (int)st;
            Font f;
            if (!cache.TryGetValue(key, out f))
            {
                f = new Font(fam, px * K, st, GraphicsUnit.Pixel);
                cache[key] = f;
            }
            return f;
        }
        public static Font F(float px) { return F(px, FontStyle.Regular, "Segoe UI"); }
        public static Font F(float px, FontStyle st) { return F(px, st, "Segoe UI"); }
        public static Font Ico(float px) { return F(px, FontStyle.Regular, "Segoe MDL2 Assets"); }

        public static GraphicsPath Round(RectangleF r, float rad)
        {
            var p = new GraphicsPath();
            float d = Math.Min(rad * 2, Math.Min(r.Width, r.Height));
            if (d <= 0) { p.AddRectangle(r); return p; }
            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure();
            return p;
        }

        public static void T(Graphics g, string t, Font f, Color c, float x, float y)
        {
            using (var b = new SolidBrush(c)) g.DrawString(t, f, b, x * K, y * K);
        }

        public static void TC(Graphics g, string t, Font f, Color c, RectangleF r, StringAlignment h, StringAlignment v)
        {
            using (var b = new SolidBrush(c))
            using (var sf = new StringFormat { Alignment = h, LineAlignment = v })
                g.DrawString(t, f, b, new RectangleF(r.X * K, r.Y * K, r.Width * K, r.Height * K), sf);
        }

        public static void Spaced(Graphics g, string t, Font f, Color c, float x, float y, float sp)
        {
            float cx = x * K;
            using (var b = new SolidBrush(c))
            using (var sf = StringFormat.GenericTypographic)
            {
                foreach (char ch in t)
                {
                    if (ch == ' ') { cx += f.Size * 0.35f + sp * K; continue; }
                    string s = ch.ToString();
                    g.DrawString(s, f, b, cx, y * K, sf);
                    cx += g.MeasureString(s, f, 1000, sf).Width + sp * K;
                }
            }
        }

        public static void Glow(Graphics g, float cx, float cy, float rad, Color c)
        {
            using (var gp = new GraphicsPath())
            {
                gp.AddEllipse((cx - rad) * K, (cy - rad) * K, rad * 2 * K, rad * 2 * K);
                using (var pg = new PathGradientBrush(gp))
                {
                    pg.CenterColor = c;
                    pg.SurroundColors = new[] { Color.FromArgb(0, c) };
                    g.FillPath(pg, gp);
                }
            }
        }

        static PointF[] HexPts(float cx, float cy, float r)
        {
            var p = new PointF[6];
            for (int i = 0; i < 6; i++)
            {
                double a = (-90 + 60 * i) * Math.PI / 180;
                p[i] = new PointF((float)(cx + r * Math.Cos(a)) * K, (float)(cy + r * Math.Sin(a)) * K);
            }
            return p;
        }

        /// <summary>Logo hexagonal degradado.</summary>
        public static void Hex(Graphics g, float cx, float cy, float r)
        {
            Glow(g, cx, cy, r * 2.1f, Color.FromArgb(90, 90, 100, 255));
            using (var gp = new GraphicsPath())
            {
                gp.AddPolygon(HexPts(cx, cy, r));
                using (var b = new LinearGradientBrush(gp.GetBounds(), Color.FromArgb(70, 110, 255), Color.FromArgb(175, 60, 255), 60f))
                    g.FillPath(b, gp);
                using (var p = new Pen(Color.FromArgb(120, 160, 255), 2) { LineJoin = LineJoin.Round })
                    g.DrawPath(p, gp);
            }
            using (var p = new Pen(Color.White, 3 * K + 0.5f) { LineJoin = LineJoin.Round })
                g.DrawPolygon(p, HexPts(cx, cy, r * 0.5f));
        }

        public static GraphicsPath TextPath(string t, Font f, float x, float y)
        {
            var gp = new GraphicsPath();
            gp.AddString(t, f.FontFamily, (int)f.Style, f.Size, new PointF(x * K, y * K), StringFormat.GenericDefault);
            return gp;
        }

        /// <summary>Resplandor de neón: trazos anchos y translúcidos (anchos en unidades del mockup, de mayor a menor).</summary>
        public static void GlowPath(Graphics g, GraphicsPath gp, Color c, float boost, params float[] widths)
        {
            for (int i = 0; i < widths.Length; i++)
            {
                int a = (int)Math.Min(255, (10 + 14 * i) * boost);
                using (var p = new Pen(Color.FromArgb(a, c), widths[i] * K) { LineJoin = LineJoin.Round })
                    g.DrawPath(p, gp);
            }
        }

        public static void Poly(Graphics g, PointF[] pts, Color c1, Color c2, float angle)
        {
            using (var gp = new GraphicsPath())
            {
                gp.AddPolygon(pts);
                using (var b = new LinearGradientBrush(gp.GetBounds(), c1, c2, angle))
                    g.FillPath(b, gp);
            }
        }
    }

    public class GradientButton : Control
    {
        bool hover, down;
        public double T;
        public int Pad = U.P(12);
        public GradientButton()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            Cursor = Cursors.Hand;
            Font = U.F(21, FontStyle.Bold);
        }
        protected override void OnMouseEnter(EventArgs e) { hover = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { hover = false; down = false; Invalidate(); base.OnMouseLeave(e); }
        protected override void OnMouseDown(MouseEventArgs e) { down = true; Invalidate(); base.OnMouseDown(e); }
        protected override void OnMouseUp(MouseEventArgs e) { down = false; Invalidate(); base.OnMouseUp(e); }
        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            var rc = new RectangleF(Pad, Pad, Width - 2 * Pad - 1, Height - 2 * Pad - 1);
            float pul = (float)(0.5 + 0.5 * Math.Sin(T * 2.2));
            using (var path = U.Round(rc, rc.Height / 2f))
            {
                for (int i = 5; i >= 1; i--)
                    using (var p = new Pen(Color.FromArgb((int)((14 + 22 * pul + (hover ? 14 : 0)) * (6 - i) / 5f), 160, 80, 255), Pad * 2f * i / 5f))
                        g.DrawPath(p, path);
                using (var br = new LinearGradientBrush(rc, Color.Blue, Color.Yellow, 0f))
                {
                    var cb = new ColorBlend(4);
                    cb.Colors = new[] { Color.FromArgb(45, 95, 255), Color.FromArgb(150, 70, 255), Color.FromArgb(255, 80, 170), Color.FromArgb(255, 205, 30) };
                    cb.Positions = new[] { 0f, 0.35f, 0.7f, 1f };
                    br.InterpolationColors = cb;
                    g.FillPath(br, path);
                }
                using (var hb = new LinearGradientBrush(rc, Color.FromArgb(70, 255, 255, 255), Color.FromArgb(0, 255, 255, 255), 90f))
                    g.FillPath(hb, path);
                var st = g.Save();
                g.SetClip(path);
                float sx = (float)(((T * 0.45) % 2.2) - 0.6) * rc.Width;
                var band = new RectangleF(rc.X + sx, rc.Y, rc.Width * 0.22f, rc.Height);
                using (var bb = new LinearGradientBrush(band, Color.White, Color.White, 0f))
                {
                    var cb2 = new ColorBlend(3);
                    cb2.Colors = new[] { Color.FromArgb(0, 255, 255, 255), Color.FromArgb(85, 255, 255, 255), Color.FromArgb(0, 255, 255, 255) };
                    cb2.Positions = new[] { 0f, 0.5f, 1f };
                    bb.InterpolationColors = cb2;
                    g.FillRectangle(bb, band);
                }
                g.Restore(st);
                if (down) using (var o = new SolidBrush(Color.FromArgb(55, 0, 0, 0))) g.FillPath(o, path);
                else if (hover) using (var o = new SolidBrush(Color.FromArgb(35, 255, 255, 255))) g.FillPath(o, path);
                using (var p = new Pen(Color.FromArgb(120, 255, 255, 255), 1f)) g.DrawPath(p, path);
            }
            using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                g.DrawString(Text, Font, Brushes.White, rc, sf);
                g.DrawString("\uE72A", U.Ico(22), Brushes.White, new RectangleF(rc.X + U.P(18), rc.Y, U.P(40), rc.Height), sf);
            }
        }
    }

    public class RoleCard : Control
    {
        bool hover, sel;
        float ht;
        public Color Accent = Color.DodgerBlue;
        public string Glyph = "\uE77B", Title = "", Sub = "";
        public double T;
        public int Pad = U.P(10);
        public bool Selected { get { return sel; } set { sel = value; Invalidate(); } }
        public RoleCard()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            Cursor = Cursors.Hand;
        }
        protected override void OnMouseEnter(EventArgs e) { hover = true; base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { hover = false; base.OnMouseLeave(e); }
        /// <summary>Transición suave del hover (se llama desde el timer del formulario).</summary>
        public void Step()
        {
            float tg = hover ? 1f : 0f;
            if (Math.Abs(ht - tg) > 0.01f) { ht += (tg - ht) * 0.28f; Invalidate(); }
        }
        static Color Light(Color c, int k) { return Color.FromArgb(Math.Min(255, c.R + k), Math.Min(255, c.G + k), Math.Min(255, c.B + k)); }
        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            int w = Width - 2 * Pad, h = Height - 2 * Pad;
            g.TranslateTransform(Pad, Pad - ht * U.P(3));
            var rc = new RectangleF(1, 1, w - 3, h - 3);
            float pul = (float)(0.5 + 0.5 * Math.Sin(T * 2.4));
            float fuerza = sel ? 0.6f + 0.4f * pul : 0.22f + 0.65f * ht;
            Color lt = Light(Accent, 70);
            using (var path = U.Round(rc, U.P(20)))
            {
                for (int i = 5; i >= 1; i--)
                    using (var p = new Pen(Color.FromArgb((int)(fuerza * 36 * (6 - i) / 5f), Accent), Pad * 2f * i / 5f))
                        g.DrawPath(p, path);
                using (var b = new SolidBrush(Color.FromArgb(7, 12, 46))) g.FillPath(b, path);
                int a1 = sel ? 220 : (int)(14 + 14 * ht), a2 = sel ? 75 : (int)(80 + 50 * ht);
                using (var b = new LinearGradientBrush(rc, Color.FromArgb(a1, Accent), Color.FromArgb(a2, Accent), 40f)) g.FillPath(b, path);
                var st = g.Save();
                g.SetClip(path);
                if (sel)
                    using (var gp = new GraphicsPath())
                    {
                        gp.AddEllipse(rc.Right - rc.Width * 0.75f, rc.Bottom - rc.Height * 0.9f, rc.Width * 1.1f, rc.Height * 1.3f);
                        using (var pg = new PathGradientBrush(gp)) { pg.CenterColor = Color.FromArgb(120, lt); pg.SurroundColors = new[] { Color.FromArgb(0, Accent) }; g.FillPath(pg, gp); }
                    }
                var sh = new RectangleF(rc.X, rc.Y, rc.Width, rc.Height * 0.55f);
                using (var b = new LinearGradientBrush(sh, Color.FromArgb(sel ? 60 : (int)(24 + 22 * ht), 255, 255, 255), Color.FromArgb(0, 255, 255, 255), 90f)) g.FillRectangle(b, sh);
                g.Restore(st);
                using (var lb = new LinearGradientBrush(rc, Color.FromArgb(255, lt), Color.FromArgb(sel || hover ? 255 : 170, Accent), 50f))
                using (var p = new Pen(lb, 2f)) g.DrawPath(p, path);
                var ir = RectangleF.Inflate(rc, -3, -3);
                using (var ip = U.Round(ir, U.P(17)))
                using (var p = new Pen(Color.FromArgb(sel ? 45 : 22, 255, 255, 255), 1f)) g.DrawPath(p, ip);
            }
            // Icono con aura
            Color ic = sel ? Color.White : lt;
            using (var b = new SolidBrush(Color.FromArgb(45, Accent)))
                for (int dx = -1; dx <= 1; dx += 2) for (int dy = -1; dy <= 1; dy += 2)
                    g.DrawString(Glyph, U.Ico(40), b, U.P(16) + dx, U.P(11) + dy);
            using (var b = new SolidBrush(ic)) g.DrawString(Glyph, U.Ico(40), b, U.P(16), U.P(11));
            // Flecha
            if (sel)
            {
                int d = U.P(26), x = w - U.P(41), y = U.P(12);
                var cr = new Rectangle(x, y, d, d);
                using (var b = new LinearGradientBrush(cr, Color.FromArgb(140, 200, 255), Color.FromArgb(40, 120, 255), 60f)) g.FillEllipse(b, cr);
                using (var p = new Pen(Color.FromArgb(150, 255, 255, 255), 1f)) g.DrawEllipse(p, cr);
                using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                    g.DrawString("\uE76C", U.Ico(13), Brushes.White, new RectangleF(x, y, d, d), sf);
            }
            else
                using (var b = new SolidBrush(Color.FromArgb(200 + (int)(55 * ht), 255, 255, 255)))
                    g.DrawString("\uE76C", U.Ico(16), b, w - U.P(34) + ht * 3, U.P(17));
            g.DrawString(Title, U.F(19, FontStyle.Bold), Brushes.White, U.P(16), U.P(52));
            using (var b = new SolidBrush(Color.FromArgb(sel ? 235 : 205, 222, 232, 250)))
                g.DrawString(Sub, U.F(13.5f), b, U.P(16), U.P(77));
            g.ResetTransform();
        }
    }

    public class NeonCheck : Control
    {
        public bool Checked = true;
        public NeonCheck()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            Cursor = Cursors.Hand;
        }
        protected override void OnClick(EventArgs e) { Checked = !Checked; Invalidate(); base.OnClick(e); }
        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            int s = U.P(24), y = (Height - s) / 2;
            var rc = new RectangleF(1, y, s, s);
            using (var path = U.Round(rc, U.P(6)))
            {
                if (Checked)
                    using (var b = new LinearGradientBrush(rc, Color.FromArgb(60, 140, 255), Color.FromArgb(40, 80, 230), 90f)) g.FillPath(b, path);
                using (var p = new Pen(Color.FromArgb(90, 150, 255), 1.5f)) g.DrawPath(p, path);
            }
            if (Checked)
                using (var p = new Pen(Color.White, 2.2f) { StartCap = LineCap.Round, EndCap = LineCap.Round, LineJoin = LineJoin.Round })
                    g.DrawLines(p, new[] { new PointF(1 + s * 0.24f, y + s * 0.52f), new PointF(1 + s * 0.43f, y + s * 0.70f), new PointF(1 + s * 0.77f, y + s * 0.30f) });
            using (var sf = new StringFormat { LineAlignment = StringAlignment.Center })
            using (var b = new SolidBrush(Color.FromArgb(225, 235, 255)))
                g.DrawString(Text, U.F(18), b, new RectangleF(U.P(41), 0, Width - U.P(41), Height), sf);
        }
    }

    public class WinBtn : Control
    {
        public int Kind; // 0 minimizar, 1 maximizar, 2 cerrar
        bool hover;
        public WinBtn()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            Cursor = Cursors.Hand;
        }
        protected override void OnMouseEnter(EventArgs e) { hover = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { hover = false; Invalidate(); base.OnMouseLeave(e); }
        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            if (hover)
                using (var b = new SolidBrush(Kind == 2 ? Color.FromArgb(200, 220, 40, 70) : Color.FromArgb(40, 255, 255, 255)))
                using (var p = U.Round(new RectangleF(0, 0, Width - 1, Height - 1), U.P(8))) g.FillPath(b, p);
            float cx = Width / 2f, cy = Height / 2f, h = U.P(9);
            using (var p = new Pen(Color.White, 2f))
            {
                if (Kind == 0) g.DrawLine(p, cx - h, cy, cx + h, cy);
                else if (Kind == 1) g.DrawRectangle(p, cx - h + 1, cy - h + 1, h * 2 - 2, h * 2 - 2);
                else { g.DrawLine(p, cx - h, cy - h, cx + h, cy + h); g.DrawLine(p, cx - h, cy + h, cx + h, cy - h); }
            }
        }
    }
}
