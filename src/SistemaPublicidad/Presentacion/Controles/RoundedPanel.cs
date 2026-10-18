using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Presentacion
{
    /// <summary>Panel con esquinas redondeadas y borde (tarjetas del diseño).</summary>
    public class RoundedPanel : Panel
    {
        private int radio = 12;
        private Color colorBorde = Color.FromArgb(40, 48, 115);

        public RoundedPanel()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.FromArgb(26, 32, 84);
        }

        [Category("Apariencia"), DefaultValue(12)]
        public int Radio
        {
            get { return radio; }
            set { radio = value; Invalidate(); }
        }

        [Category("Apariencia")]
        public Color ColorBorde
        {
            get { return colorBorde; }
            set { colorBorde = value; Invalidate(); }
        }

        private bool ShouldSerializeColorBorde()
        {
            return colorBorde != Color.FromArgb(40, 48, 115);
        }

        private void ResetColorBorde()
        {
            ColorBorde = Color.FromArgb(40, 48, 115);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Se pinta todo en OnPaint para evitar parpadeo.
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Dibujo.FondoPadre(this));
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            using (GraphicsPath path = Dibujo.Redondeado(rect, radio))
            using (SolidBrush br = new SolidBrush(BackColor))
            using (Pen pen = new Pen(colorBorde))
            {
                g.FillPath(br, path);
                g.DrawPath(pen, path);
            }
            base.OnPaint(e);
        }
    }
}
