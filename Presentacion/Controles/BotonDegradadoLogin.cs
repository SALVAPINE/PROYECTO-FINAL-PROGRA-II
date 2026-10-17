using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace CAPAZ.Presentacion.Controles
{
    /// <summary>Botón grande con relleno degradado, esquinas redondeadas e icono opcional (Segoe MDL2 Assets).</summary>
    public class BotonDegradado : Button
    {
        private bool _encima;
        private bool _presionado;
        private string _codigoIcono = string.Empty;
        private string _glifo = string.Empty;
        private Font _fuenteIcono = new Font("Segoe MDL2 Assets", 13f);
        private Color _colorInicio = Color.FromArgb(92, 98, 236);
        private Color _colorFin = Color.FromArgb(160, 84, 236);
        private int _radio = 12;

        public BotonDegradado()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = Color.Transparent;
            ForeColor = Color.White;
            Cursor = Cursors.Hand;
            Font = new Font("Segoe UI Semibold", 11f);
            Size = new Size(300, 50);
        }

        [Category("CAPAZ"), Description("Código hexadecimal del icono (ej.: E72A = flecha). Vacío = sin icono.")]
        public string CodigoIcono
        {
            get { return _codigoIcono; }
            set { _codigoIcono = value ?? string.Empty; _glifo = GraficosUi.GlifoDesdeCodigo(_codigoIcono); Invalidate(); }
        }

        [Category("CAPAZ")] public Font FuenteIcono { get { return _fuenteIcono; } set { _fuenteIcono = value ?? _fuenteIcono; Invalidate(); } }
        [Category("CAPAZ")] public Color ColorInicio { get { return _colorInicio; } set { _colorInicio = value; Invalidate(); } }
        [Category("CAPAZ")] public Color ColorFin { get { return _colorFin; } set { _colorFin = value; Invalidate(); } }
        [Category("CAPAZ")] public int RadioEsquinas { get { return _radio; } set { _radio = Math.Max(0, value); Invalidate(); } }

        protected override void OnMouseEnter(EventArgs e) { _encima = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _encima = false; _presionado = false; Invalidate(); base.OnMouseLeave(e); }
        protected override void OnMouseDown(MouseEventArgs m) { _presionado = true; Invalidate(); base.OnMouseDown(m); }
        protected override void OnMouseUp(MouseEventArgs m) { _presionado = false; Invalidate(); base.OnMouseUp(m); }
        protected override void OnEnabledChanged(EventArgs e) { Invalidate(); base.OnEnabledChanged(e); }

        private static Color Ajustar(Color c, int delta)
        {
            return Color.FromArgb(c.A,
                Math.Max(0, Math.Min(255, c.R + delta)),
                Math.Max(0, Math.Min(255, c.G + delta)),
                Math.Max(0, Math.Min(255, c.B + delta)));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            // Un Button no admite transparencia real: se pinta primero el color del contenedor para evitar esquinas negras.
            g.Clear(Parent != null ? Parent.BackColor : Color.Black);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            if (Width < 4 || Height < 4) { return; }

            int delta = !Enabled ? -40 : _presionado ? -25 : _encima ? 22 : 0;
            Color c1 = Ajustar(_colorInicio, delta);
            Color c2 = Ajustar(_colorFin, delta);
            if (!Enabled) { c1 = Color.FromArgb(150, c1); c2 = Color.FromArgb(150, c2); }

            var rect = new RectangleF(0.5f, 0.5f, Width - 2f, Height - 2f);
            using (GraphicsPath ruta = GraficosUi.RectanguloRedondeado(rect, _radio))
            using (var pincel = new LinearGradientBrush(new RectangleF(0, 0, Width, Height), c1, c2, 0f))
            {
                g.FillPath(pincel, ruta);
            }

            var infinito = new Size(int.MaxValue, int.MaxValue);
            const TextFormatFlags f = TextFormatFlags.NoPadding | TextFormatFlags.SingleLine;
            bool hayIcono = _glifo.Length > 0;
            bool hayTexto = !string.IsNullOrEmpty(Text);
            Size ti = hayIcono ? TextRenderer.MeasureText(g, _glifo, _fuenteIcono, infinito, f) : Size.Empty;
            Size tt = hayTexto ? TextRenderer.MeasureText(g, Text, Font, infinito, f) : Size.Empty;
            int sep = (hayIcono && hayTexto) ? 12 : 0;
            int x = (Width - (tt.Width + sep + ti.Width)) / 2;
            if (hayTexto)
            {
                TextRenderer.DrawText(g, Text, Font, new Point(x, (Height - tt.Height) / 2), ForeColor, f);
                x += tt.Width + sep;
            }
            if (hayIcono)
            {
                TextRenderer.DrawText(g, _glifo, _fuenteIcono, new Point(x, (Height - ti.Height) / 2), ForeColor, f);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) { _fuenteIcono.Dispose(); }
            base.Dispose(disposing);
        }
    }
}
