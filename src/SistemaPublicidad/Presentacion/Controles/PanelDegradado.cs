using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Presentacion
{
    /// <summary>Panel con fondo en degradado vertical y ondas decorativas (menú lateral).</summary>
    public class PanelDegradado : Panel
    {
        private Color colorInicio = Color.FromArgb(14, 18, 64);
        private Color colorFin = Color.FromArgb(40, 22, 96);

        public PanelDegradado()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            BackColor = colorInicio;
        }

        [Category("Apariencia")]
        public Color ColorInicio { get { return colorInicio; } set { colorInicio = value; Invalidate(); } }
        private bool ShouldSerializeColorInicio() { return colorInicio != Color.FromArgb(14, 18, 64); }
        private void ResetColorInicio() { ColorInicio = Color.FromArgb(14, 18, 64); }

        [Category("Apariencia")]
        public Color ColorFin { get { return colorFin; } set { colorFin = value; Invalidate(); } }
        private bool ShouldSerializeColorFin() { return colorFin != Color.FromArgb(40, 22, 96); }
        private void ResetColorFin() { ColorFin = Color.FromArgb(40, 22, 96); }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            DibujarFondo(e.Graphics);
        }

        /// <summary>Dibuja el degradado y las ondas. Los controles hijos lo usan para pintar su propio fondo sin transparencias.</summary>
        public void DibujarFondo(Graphics g)
        {
            Rectangle r = ClientRectangle;
            if (r.Width <= 0 || r.Height <= 0) return;

            using (LinearGradientBrush lg = new LinearGradientBrush(r, colorInicio, colorFin, 90f))
                g.FillRectangle(lg, r);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            float w = r.Width, b = r.Bottom;
            using (GraphicsPath onda1 = new GraphicsPath())
            {
                onda1.AddBezier(0f, b - 120f, w * 0.35f, b - 190f, w * 0.65f, b - 40f, w, b - 110f);
                onda1.AddLine(w, b - 110f, w, b);
                onda1.AddLine(w, b, 0f, b);
                onda1.CloseFigure();
                using (SolidBrush br = new SolidBrush(Color.FromArgb(70, 168, 85, 247)))
                    g.FillPath(br, onda1);
            }
            using (GraphicsPath onda2 = new GraphicsPath())
            {
                onda2.AddBezier(0f, b - 60f, w * 0.4f, b - 120f, w * 0.7f, b - 10f, w, b - 70f);
                onda2.AddLine(w, b - 70f, w, b);
                onda2.AddLine(w, b, 0f, b);
                onda2.CloseFigure();
                using (SolidBrush br = new SolidBrush(Color.FromArgb(60, 236, 72, 153)))
                    g.FillPath(br, onda2);
            }
        }
    }
}
