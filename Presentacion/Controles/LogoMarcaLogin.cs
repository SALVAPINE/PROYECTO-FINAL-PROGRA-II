using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CAPAZ.Presentacion.Controles
{
    /// <summary>Marca gráfica: hexágono con degradado y un hexágono interior de líneas finas.</summary>
    public class LogoMarca : Control
    {
        private Color _color1 = Color.FromArgb(99, 102, 241);
        private Color _color2 = Color.FromArgb(217, 70, 239);

        public LogoMarca()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            Size = new Size(48, 52);
            TabStop = false;
        }

        [Category("CAPAZ")] public Color Color1 { get { return _color1; } set { _color1 = value; Invalidate(); } }
        [Category("CAPAZ")] public Color Color2 { get { return _color2; } set { _color2 = value; Invalidate(); } }

        private static PointF[] Hexagono(float cx, float cy, float r)
        {
            var p = new PointF[6];
            for (int i = 0; i < 6; i++)
            {
                double a = System.Math.PI / 180.0 * (60 * i - 90);
                p[i] = new PointF(cx + (float)(r * System.Math.Cos(a)), cy + (float)(r * System.Math.Sin(a)));
            }
            return p;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            if (Width < 8 || Height < 8) { return; }
            float cx = Width / 2f;
            float cy = Height / 2f;
            float r = System.Math.Min(Width, Height) / 2f - 2f;

            using (var pincel = new LinearGradientBrush(new RectangleF(0, 0, Width, Height), _color1, _color2, 55f))
            using (var lapizBorde = new Pen(Color.FromArgb(70, 255, 255, 255), 1f))
            {
                lapizBorde.LineJoin = LineJoin.Round;
                PointF[] ext = Hexagono(cx, cy, r);
                g.FillPolygon(pincel, ext);
                g.DrawPolygon(lapizBorde, ext);
            }

            using (var lapiz = new Pen(Color.FromArgb(200, 255, 255, 255), 1.6f))
            {
                lapiz.LineJoin = LineJoin.Round;
                g.DrawPolygon(lapiz, Hexagono(cx, cy, r * 0.52f));
            }
        }
    }
}
