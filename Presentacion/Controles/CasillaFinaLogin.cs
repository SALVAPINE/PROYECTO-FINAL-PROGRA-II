using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace CAPAZ.Presentacion.Controles
{
    /// <summary>Casilla de verificación fina y oscura (reemplaza al CheckBox estándar).</summary>
    [DefaultEvent("CheckedChanged")]
    public class CasillaFina : Control
    {
        private bool _marcada;
        private bool _encima;
        private Color _colorMarca = Color.FromArgb(99, 102, 241);
        private Color _colorBorde = Color.FromArgb(70, 82, 160);

        public event EventHandler CheckedChanged;

        public CasillaFina()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor | ControlStyles.Selectable, true);
            BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(180, 188, 225);
            Font = new Font("Segoe UI", 9.5f);
            Cursor = Cursors.Hand;
            Size = new Size(170, 24);
        }

        [Category("CAPAZ")]
        public bool Checked
        {
            get { return _marcada; }
            set
            {
                if (_marcada == value) { return; }
                _marcada = value;
                Invalidate();
                EventHandler h = CheckedChanged;
                if (h != null) { h(this, EventArgs.Empty); }
            }
        }

        [Category("CAPAZ")] public Color ColorMarca { get { return _colorMarca; } set { _colorMarca = value; Invalidate(); } }
        [Category("CAPAZ")] public Color ColorBorde { get { return _colorBorde; } set { _colorBorde = value; Invalidate(); } }

        protected override void OnClick(EventArgs e) { Checked = !Checked; base.OnClick(e); }
        protected override void OnMouseEnter(EventArgs e) { _encima = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _encima = false; Invalidate(); base.OnMouseLeave(e); }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space) { Checked = !Checked; e.Handled = true; }
            base.OnKeyDown(e);
        }
        protected override void OnGotFocus(EventArgs e) { Invalidate(); base.OnGotFocus(e); }
        protected override void OnLostFocus(EventArgs e) { Invalidate(); base.OnLostFocus(e); }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            var caja = new RectangleF(0.5f, (Height - 16) / 2f + 0.5f, 15f, 15f);
            using (GraphicsPath ruta = GraficosUi.RectanguloRedondeado(caja, 4f))
            {
                if (_marcada)
                {
                    using (var pincel = new SolidBrush(_colorMarca)) { g.FillPath(pincel, ruta); }
                }
                else
                {
                    using (var lapiz = new Pen(_encima || Focused ? _colorMarca : _colorBorde, 1.2f)) { g.DrawPath(lapiz, ruta); }
                }
            }

            if (_marcada)
            {
                using (var lapiz = new Pen(Color.White, 1.8f))
                {
                    lapiz.StartCap = LineCap.Round;
                    lapiz.EndCap = LineCap.Round;
                    lapiz.LineJoin = LineJoin.Round;
                    float y = caja.Y;
                    g.DrawLines(lapiz, new[]
                    {
                        new PointF(caja.X + 3.6f, y + 8f), new PointF(caja.X + 6.4f, y + 10.8f), new PointF(caja.X + 11.4f, y + 4.8f)
                    });
                }
            }

            TextRenderer.DrawText(g, Text, Font, new Rectangle(24, 0, Math.Max(1, Width - 24), Height), ForeColor,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding | TextFormatFlags.EndEllipsis);
        }
    }
}
