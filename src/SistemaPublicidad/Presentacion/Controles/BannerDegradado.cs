using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Presentacion
{
    /// <summary>Fondo decorativo con degradado oscuro, círculos suaves y un icono translúcido (sin texto ni animación).</summary>
    public class BannerDegradado : RoundedPanel
    {
        private Color colorInicio = Color.FromArgb(24, 30, 84);
        private Color colorFin = Color.FromArgb(58, 40, 120);
        private string glyph = "\uE8A5";

        public BannerDegradado()
        {
            Radio = 14;
            Size = new Size(600, 150);
        }

        [Category("Banner")]
        public Color ColorInicio { get { return colorInicio; } set { colorInicio = value; Invalidate(); } }
        private bool ShouldSerializeColorInicio() { return colorInicio != Color.FromArgb(24, 30, 84); }
        private void ResetColorInicio() { ColorInicio = Color.FromArgb(24, 30, 84); }

        [Category("Banner")]
        public Color ColorFin { get { return colorFin; } set { colorFin = value; Invalidate(); } }
        private bool ShouldSerializeColorFin() { return colorFin != Color.FromArgb(58, 40, 120); }
        private void ResetColorFin() { ColorFin = Color.FromArgb(58, 40, 120); }

        [Category("Banner"), DefaultValue("\uE8A5"), Description("Icono grande y translúcido de fondo (fuente Segoe MDL2 Assets).")]
        public string Glyph { get { return glyph; } set { glyph = value ?? ""; Invalidate(); } }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Dibujo.FondoPadre(this));
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            if (rect.Width < 40 || rect.Height < 40) return;

            using (GraphicsPath path = Dibujo.Redondeado(rect, Radio))
            {
                using (LinearGradientBrush lg = new LinearGradientBrush(rect, colorInicio, colorFin, 20f))
                    g.FillPath(lg, path);

                g.SetClip(path);
                Circulo(g, Width * 0.88f, Height * 0.30f, 100f, Color.FromArgb(14, 255, 255, 255));
                Circulo(g, Width * 0.66f, Height * 1.00f, 80f, Color.FromArgb(16, 236, 72, 153));
                Circulo(g, Width * 0.98f, Height * 1.02f, 120f, Color.FromArgb(12, 34, 211, 238));
                Circulo(g, Width * 0.08f, Height * 0.10f, 70f, Color.FromArgb(10, 255, 255, 255));
                using (Font f = new Font("Segoe MDL2 Assets", 90F))
                using (SolidBrush b = new SolidBrush(Color.FromArgb(22, 255, 255, 255)))
                    g.DrawString(glyph, f, b, Width - 160f, Height / 2f - 75f);
                g.ResetClip();

                using (Pen pen = new Pen(Color.FromArgb(50, 255, 255, 255)))
                    g.DrawPath(pen, path);
            }
        }

        private static void Circulo(Graphics g, float cx, float cy, float r, Color color)
        {
            using (SolidBrush b = new SolidBrush(color))
                g.FillEllipse(b, cx - r, cy - r, r * 2f, r * 2f);
        }
    }
}
