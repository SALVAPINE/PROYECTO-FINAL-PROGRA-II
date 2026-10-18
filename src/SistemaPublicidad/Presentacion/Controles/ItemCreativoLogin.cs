using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace CAPAZ.Presentacion.Controles
{
    public enum IconoCreativo { Lapiz, Cubo, Grafica }

    /// <summary>
    /// Elemento de lista con icono dibujado dentro de un círculo degradado, título, descripción y una
    /// línea punteada que lo une con el elemento siguiente (efecto de recorrido / línea de tiempo).
    /// </summary>
    public class ItemCreativo : Control
    {
        private string _titulo = "Título";
        private string _descripcion = "Descripción";
        private IconoCreativo _icono = IconoCreativo.Lapiz;
        private Color _colorInicio = Color.FromArgb(244, 114, 182);
        private Color _colorFin = Color.FromArgb(167, 139, 250);
        private Color _colorTitulo = Color.FromArgb(244, 245, 255);
        private Color _colorDescripcion = Color.FromArgb(160, 170, 222);
        private bool _conectarAbajo = true;
        private bool _encima;
        private Font _fuenteTitulo = new Font("Segoe UI Semibold", 12f);
        private Font _fuenteDescripcion = new Font("Segoe UI", 9.5f);

        public ItemCreativo()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            TabStop = false;
            Size = new Size(380, 72);
        }

        [Category("CAPAZ")] public string Titulo { get { return _titulo; } set { _titulo = value ?? string.Empty; Invalidate(); } }
        [Category("CAPAZ")] public string Descripcion { get { return _descripcion; } set { _descripcion = value ?? string.Empty; Invalidate(); } }
        [Category("CAPAZ")] public IconoCreativo Icono { get { return _icono; } set { _icono = value; Invalidate(); } }
        [Category("CAPAZ")] public Color ColorInicio { get { return _colorInicio; } set { _colorInicio = value; Invalidate(); } }
        [Category("CAPAZ")] public Color ColorFin { get { return _colorFin; } set { _colorFin = value; Invalidate(); } }
        [Category("CAPAZ")] public Color ColorTitulo { get { return _colorTitulo; } set { _colorTitulo = value; Invalidate(); } }
        [Category("CAPAZ")] public Color ColorDescripcion { get { return _colorDescripcion; } set { _colorDescripcion = value; Invalidate(); } }
        [Category("CAPAZ"), Description("Dibuja una línea punteada hacia abajo para unir con el elemento siguiente.")]
        public bool ConectarAbajo { get { return _conectarAbajo; } set { _conectarAbajo = value; Invalidate(); } }
        [Category("CAPAZ")] public Font FuenteTitulo { get { return _fuenteTitulo; } set { _fuenteTitulo = value ?? _fuenteTitulo; Invalidate(); } }
        [Category("CAPAZ")] public Font FuenteDescripcion { get { return _fuenteDescripcion; } set { _fuenteDescripcion = value ?? _fuenteDescripcion; Invalidate(); } }

        protected override void OnMouseEnter(EventArgs e) { _encima = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _encima = false; Invalidate(); base.OnMouseLeave(e); }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            if (Width < 80 || Height < 50) { return; }

            const float d = 46f;
            var circulo = new RectangleF(2f, 3f, d, d);
            float cx = circulo.X + d / 2f;
            float cy = circulo.Y + d / 2f;

            if (_conectarAbajo)
            {
                using (var lapiz = new Pen(Color.FromArgb(95, _colorFin), 1.2f))
                {
                    lapiz.DashStyle = DashStyle.Dot;
                    g.DrawLine(lapiz, cx, circulo.Bottom + 5f, cx, Height);
                }
            }

            if (_encima)
            {
                using (var lapiz = new Pen(Color.FromArgb(45, _colorInicio), 5f))
                {
                    g.DrawEllipse(lapiz, circulo);
                }
            }

            int alfa = _encima ? 80 : 42;
            using (var relleno = new LinearGradientBrush(circulo, Color.FromArgb(alfa, _colorInicio), Color.FromArgb(alfa, _colorFin), 45f))
            {
                g.FillEllipse(relleno, circulo);
            }
            using (var degradadoAnillo = new LinearGradientBrush(circulo, _colorInicio, _colorFin, 45f))
            using (var anillo = new Pen(degradadoAnillo, 1.5f))
            {
                g.DrawEllipse(anillo, circulo);
            }

            DibujarIcono(g, cx, cy);

            const TextFormatFlags linea = TextFormatFlags.NoPadding | TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis;
            int desplazamiento = _encima ? 4 : 0;
            TextRenderer.DrawText(g, _titulo, _fuenteTitulo,
                new Rectangle(68 + desplazamiento, 6, Math.Max(1, Width - 68 - desplazamiento), _fuenteTitulo.Height + 2),
                _colorTitulo, linea);
            TextRenderer.DrawText(g, _descripcion, _fuenteDescripcion,
                new Rectangle(68 + desplazamiento, 32, Math.Max(1, Width - 68 - desplazamiento), Math.Max(1, Height - 32)),
                _colorDescripcion, TextFormatFlags.NoPadding | TextFormatFlags.WordBreak | TextFormatFlags.EndEllipsis);
        }

        private void DibujarIcono(Graphics g, float cx, float cy)
        {
            GraphicsState estado = g.Save();
            g.TranslateTransform(cx, cy);
            using (var lapiz = new Pen(Color.FromArgb(240, 255, 255, 255), 1.6f))
            using (var relleno = new SolidBrush(Color.FromArgb(70, 255, 255, 255)))
            {
                lapiz.LineJoin = LineJoin.Round;
                lapiz.StartCap = LineCap.Round;
                lapiz.EndCap = LineCap.Round;

                switch (_icono)
                {
                    case IconoCreativo.Lapiz:
                        g.RotateTransform(45f);
                        g.FillRectangle(relleno, -3.5f, -11f, 7f, 17f);
                        g.DrawRectangle(lapiz, -3.5f, -11f, 7f, 17f);
                        g.DrawLine(lapiz, -3.5f, -7f, 3.5f, -7f);
                        g.DrawPolygon(lapiz, new[] { new PointF(-3.5f, 6f), new PointF(3.5f, 6f), new PointF(0f, 12.5f) });
                        break;

                    case IconoCreativo.Cubo:
                        var hex = new PointF[6];
                        for (int i = 0; i < 6; i++)
                        {
                            double a = Math.PI / 180.0 * (60 * i - 90);
                            hex[i] = new PointF((float)(12.0 * Math.Cos(a)), (float)(12.0 * Math.Sin(a)));
                        }
                        g.FillPolygon(relleno, hex);
                        g.DrawPolygon(lapiz, hex);
                        g.DrawLine(lapiz, 0f, 0f, hex[1].X, hex[1].Y);
                        g.DrawLine(lapiz, 0f, 0f, hex[3].X, hex[3].Y);
                        g.DrawLine(lapiz, 0f, 0f, hex[5].X, hex[5].Y);
                        break;

                    default:
                        float[] alturas = { 8f, 13f, 19f };
                        for (int i = 0; i < alturas.Length; i++)
                        {
                            float x = -10f + i * 7.5f;
                            g.FillRectangle(relleno, x, 10f - alturas[i], 5f, alturas[i]);
                            g.DrawRectangle(lapiz, x, 10f - alturas[i], 5f, alturas[i]);
                        }
                        break;
                }
            }
            g.Restore(estado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _fuenteTitulo.Dispose();
                _fuenteDescripcion.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
