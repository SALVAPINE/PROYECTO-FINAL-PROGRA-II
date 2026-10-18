using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CAPAZ.Presentacion.Controles
{
    /// <summary>Trazo de pincel con degradado y puntas afinadas, para subrayar un título.</summary>
    public class TrazoPincel : Control
    {
        private Color _colorInicio = Color.FromArgb(244, 114, 182);
        private Color _colorMedio = Color.FromArgb(167, 139, 250);
        private Color _colorFin = Color.FromArgb(99, 102, 241);

        public TrazoPincel()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            TabStop = false;
            Size = new Size(330, 22);
        }

        [Category("CAPAZ")] public Color ColorInicio { get { return _colorInicio; } set { _colorInicio = value; Invalidate(); } }
        [Category("CAPAZ")] public Color ColorMedio { get { return _colorMedio; } set { _colorMedio = value; Invalidate(); } }
        [Category("CAPAZ")] public Color ColorFin { get { return _colorFin; } set { _colorFin = value; Invalidate(); } }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            float w = Width;
            float h = Height;
            if (w < 30f || h < 8f) { return; }
            g.SmoothingMode = SmoothingMode.AntiAlias;

            var a = new PointF(2f, h * 0.72f);
            var c1 = new PointF(w * 0.28f, h * 0.10f);
            var c2 = new PointF(w * 0.62f, h * 0.62f);
            var b = new PointF(w - 2f, h * 0.28f);
            float esp = h * 0.34f;

            using (var ruta = new GraphicsPath())
            {
                ruta.AddBezier(a, c1, c2, b);
                ruta.AddBezier(b, new PointF(c2.X, c2.Y + esp), new PointF(c1.X, c1.Y + esp), a);
                ruta.CloseFigure();
                using (var pincel = new LinearGradientBrush(new RectangleF(0f, 0f, w, h),
                    _colorInicio, _colorFin, LinearGradientMode.Horizontal))
                {
                    var mezcla = new ColorBlend(3);
                    mezcla.Colors = new[] { Color.FromArgb(235, _colorInicio), Color.FromArgb(235, _colorMedio), Color.FromArgb(70, _colorFin) };
                    mezcla.Positions = new[] { 0f, 0.5f, 1f };
                    pincel.InterpolationColors = mezcla;
                    g.FillPath(pincel, ruta);
                }
            }

            // Vetas de pincel seco
            using (var lapiz = new Pen(Color.FromArgb(55, 255, 255, 255), 0.8f))
            {
                float[] niveles = { 0.25f, 0.50f, 0.75f };
                for (int i = 0; i < niveles.Length; i++)
                {
                    float d = esp * niveles[i];
                    g.DrawBezier(lapiz,
                        new PointF(a.X + 14f, a.Y), new PointF(c1.X, c1.Y + d),
                        new PointF(c2.X, c2.Y + d), new PointF(b.X - 18f, b.Y));
                }
            }
        }
    }
}
