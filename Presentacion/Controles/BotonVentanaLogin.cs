using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CAPAZ.Presentacion.Controles
{
    public enum TipoBotonVentana { Minimizar, Cerrar }

    /// <summary>Botón de minimizar / cerrar dibujado con líneas finas (no usa fuentes de iconos).</summary>
    public class BotonVentana : Control
    {
        private bool _encima;
        private TipoBotonVentana _tipo = TipoBotonVentana.Cerrar;
        private Color _colorLinea = Color.FromArgb(170, 178, 220);

        public BotonVentana()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            Cursor = Cursors.Hand;
            Size = new Size(36, 30);
            TabStop = false;
        }

        [Category("CAPAZ")] public TipoBotonVentana Tipo { get { return _tipo; } set { _tipo = value; Invalidate(); } }
        [Category("CAPAZ")] public Color ColorLinea { get { return _colorLinea; } set { _colorLinea = value; Invalidate(); } }

        protected override void OnMouseEnter(EventArgs e) { _encima = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _encima = false; Invalidate(); base.OnMouseLeave(e); }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (_encima)
            {
                Color fondo = _tipo == TipoBotonVentana.Cerrar ? Color.FromArgb(200, 220, 38, 38) : Color.FromArgb(30, 255, 255, 255);
                using (GraphicsPath ruta = GraficosUi.RectanguloRedondeado(new RectangleF(0.5f, 0.5f, Width - 2f, Height - 2f), 6f))
                using (var pincel = new SolidBrush(fondo))
                {
                    g.FillPath(pincel, ruta);
                }
            }

            float cx = Width / 2f;
            float cy = Height / 2f;
            using (var lapiz = new Pen(_encima ? Color.White : _colorLinea, 1.4f))
            {
                lapiz.StartCap = LineCap.Round;
                lapiz.EndCap = LineCap.Round;
                if (_tipo == TipoBotonVentana.Minimizar)
                {
                    g.DrawLine(lapiz, cx - 5f, cy + 1f, cx + 5f, cy + 1f);
                }
                else
                {
                    g.DrawLine(lapiz, cx - 5f, cy - 5f, cx + 5f, cy + 5f);
                    g.DrawLine(lapiz, cx - 5f, cy + 5f, cx + 5f, cy - 5f);
                }
            }
        }
    }
}
