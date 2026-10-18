using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace CAPAZ.Presentacion.Controles
{
    /// <summary>
    /// Composición artística de fondo: cinta de color, constelación de ideas conectadas que
    /// palpitan suavemente, figuras geométricas flotantes y tres círculos superpuestos.
    /// Todo se dibuja por código (no usa imágenes ni fuentes de iconos).
    /// </summary>
    public class LienzoCreativo : Control
    {
        private static readonly Color Rosa = Color.FromArgb(244, 114, 182);
        private static readonly Color Violeta = Color.FromArgb(167, 139, 250);
        private static readonly Color Indigo = Color.FromArgb(129, 140, 248);
        private static readonly Color Ambar = Color.FromArgb(251, 191, 36);
        private static readonly Color Cian = Color.FromArgb(34, 211, 238);

        private static readonly Color[] Paleta = { Rosa, Violeta, Indigo, Ambar, Cian };

        // Posición de los nodos (fracción del ancho y del alto) y su tamaño.
        private static readonly float[,] Nodos =
        {
            { 0.14f, 0.07f }, { 0.60f, 0.05f }, { 0.88f, 0.20f }, { 0.38f, 0.24f }, { 0.12f, 0.40f },
            { 0.74f, 0.45f }, { 0.34f, 0.56f }, { 0.90f, 0.62f }, { 0.20f, 0.76f }, { 0.84f, 0.93f }
        };
        private static readonly float[] Tamanos = { 3f, 4f, 3.5f, 5f, 3f, 5f, 3.5f, 3f, 4f, 3f };

        // Pares de nodos que se unen con una línea.
        private static readonly int[,] Aristas =
        {
            { 0, 3 }, { 3, 1 }, { 1, 2 }, { 3, 4 }, { 3, 5 }, { 2, 5 }, { 5, 6 }, { 4, 6 }, { 5, 7 }, { 6, 8 }, { 7, 9 }
        };

        private readonly System.Windows.Forms.Timer _reloj = new System.Windows.Forms.Timer();
        private float _fase;
        private bool _animar = true;
        private string _textoVertical = "DISEÑO • COLOR • FORMA • IMPACTO";
        private Font _fuenteVertical = new Font("Segoe UI", 7.5f);

        public LienzoCreativo()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            TabStop = false;
            Size = new Size(300, 700);
            _reloj.Interval = 66;
            _reloj.Tick += delegate
            {
                if (!Visible || !IsHandleCreated) { return; }
                _fase += 0.06f;
                Invalidate();
            };
        }

        [Category("CAPAZ"), Description("Movimiento suave de los nodos y las figuras.")]
        public bool Animar
        {
            get { return _animar; }
            set { _animar = value; ActualizarReloj(); Invalidate(); }
        }

        [Category("CAPAZ"), Description("Texto vertical del borde derecho (vacío = sin texto).")]
        public string TextoVertical
        {
            get { return _textoVertical; }
            set { _textoVertical = value ?? string.Empty; Invalidate(); }
        }

        private void ActualizarReloj()
        {
            bool enDiseno = LicenseManager.UsageMode == LicenseUsageMode.Designtime;
            _reloj.Enabled = _animar && !enDiseno && IsHandleCreated;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            ActualizarReloj();
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            _reloj.Stop();
            base.OnHandleDestroyed(e);
        }

        private static PointF Nodo(int i, float w, float h)
        {
            return new PointF(Nodos[i, 0] * w, Nodos[i, 1] * h);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (Width < 60 || Height < 60) { return; }
            g.SmoothingMode = SmoothingMode.AntiAlias;
            float w = Width;
            float h = Height;

            DibujarOrbe(g, w, h);
            DibujarCinta(g, w, h);
            DibujarConexiones(g, w, h);
            DibujarNodos(g, w, h);
            DibujarFiguras(g, w, h);
            DibujarCirculos(g, w, h);
            DibujarPuntos(g, w, h);
            DibujarTextoVertical(g, w, h);
        }

        private void DibujarOrbe(Graphics g, float w, float h)
        {
            float cx = w * 0.60f;
            float cy = h * 0.17f;
            float r = Math.Min(w, h) * 0.34f;
            using (var ruta = new GraphicsPath())
            {
                ruta.AddEllipse(cx - r, cy - r, r * 2f, r * 2f);
                using (var pincel = new PathGradientBrush(ruta))
                {
                    pincel.CenterColor = Color.FromArgb(115, Rosa);
                    pincel.SurroundColors = new[] { Color.FromArgb(0, Violeta) };
                    pincel.CenterPoint = new PointF(cx - r * 0.22f, cy - r * 0.22f);
                    g.FillPath(pincel, ruta);
                }
            }
            using (var lapiz = new Pen(Color.FromArgb(34, 255, 255, 255), 1f))
            {
                g.DrawEllipse(lapiz, cx - r * 0.78f, cy - r * 0.78f, r * 1.56f, r * 1.56f);
                lapiz.Color = Color.FromArgb(16, 255, 255, 255);
                g.DrawEllipse(lapiz, cx - r * 1.12f, cy - r * 1.12f, r * 2.24f, r * 2.24f);
            }
        }

        private void DibujarCinta(Graphics g, float w, float h)
        {
            var a = new PointF(-12f, h * 0.30f);
            var c1 = new PointF(w * 0.30f, h * 0.10f);
            var c2 = new PointF(w * 0.62f, h * 0.46f);
            var b = new PointF(w + 12f, h * 0.26f);
            const float grosor = 30f;

            using (var ruta = new GraphicsPath())
            {
                ruta.AddBezier(a, c1, c2, b);
                ruta.AddBezier(b, new PointF(c2.X, c2.Y + grosor), new PointF(c1.X, c1.Y + grosor), a);
                ruta.CloseFigure();
                using (var pincel = new LinearGradientBrush(new RectangleF(0f, 0f, w, h),
                    Color.FromArgb(0, Indigo), Color.FromArgb(60, Violeta), LinearGradientMode.Horizontal))
                {
                    var mezcla = new ColorBlend(3);
                    mezcla.Colors = new[] { Color.FromArgb(0, Indigo), Color.FromArgb(120, Rosa), Color.FromArgb(40, Violeta) };
                    mezcla.Positions = new[] { 0f, 0.55f, 1f };
                    pincel.InterpolationColors = mezcla;
                    g.FillPath(pincel, ruta);
                }
            }

            // Trazo fino que acompaña a la cinta
            using (var lapiz = new Pen(Color.FromArgb(70, Cian), 1.2f))
            {
                g.DrawBezier(lapiz,
                    new PointF(a.X, a.Y + 52f), new PointF(c1.X, c1.Y + 60f),
                    new PointF(c2.X, c2.Y + 52f), new PointF(b.X, b.Y + 44f));
            }
        }

        private void DibujarConexiones(Graphics g, float w, float h)
        {
            using (var lapiz = new Pen(Color.FromArgb(58, 200, 206, 255), 1f))
            {
                int n = Aristas.GetLength(0);
                for (int k = 0; k < n; k++)
                {
                    lapiz.DashStyle = (k % 3 == 2) ? DashStyle.Dot : DashStyle.Solid;
                    g.DrawLine(lapiz, Nodo(Aristas[k, 0], w, h), Nodo(Aristas[k, 1], w, h));
                }
            }
        }

        private void DibujarNodos(Graphics g, float w, float h)
        {
            int n = Nodos.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                PointF p = Nodo(i, w, h);
                Color c = Paleta[i % Paleta.Length];
                float pulso = 1f + 0.22f * (float)Math.Sin(_fase * 1.3f + i * 1.7f);
                float radio = Tamanos[i];
                float brillo = radio * 4.4f * pulso;

                using (var ruta = new GraphicsPath())
                {
                    ruta.AddEllipse(p.X - brillo, p.Y - brillo, brillo * 2f, brillo * 2f);
                    using (var pincel = new PathGradientBrush(ruta))
                    {
                        pincel.CenterColor = Color.FromArgb(105, c);
                        pincel.SurroundColors = new[] { Color.FromArgb(0, c) };
                        g.FillPath(pincel, ruta);
                    }
                }
                using (var relleno = new SolidBrush(c))
                {
                    g.FillEllipse(relleno, p.X - radio, p.Y - radio, radio * 2f, radio * 2f);
                }
                using (var centro = new SolidBrush(Color.FromArgb(230, 255, 255, 255)))
                {
                    g.FillEllipse(centro, p.X - radio * 0.4f, p.Y - radio * 0.4f, radio * 0.8f, radio * 0.8f);
                }
            }
        }

        private void DibujarFiguras(Graphics g, float w, float h)
        {
            // Triángulo
            Flotar(g, w * 0.80f, h * 0.35f, 15f, 0, 3.0f);
            using (var lapiz = new Pen(Color.FromArgb(170, Ambar), 1.4f))
            {
                lapiz.LineJoin = LineJoin.Round;
                g.DrawPolygon(lapiz, new[] { new PointF(0f, -11f), new PointF(10f, 7f), new PointF(-10f, 7f) });
            }
            g.ResetTransform();

            // Cuadrado girado
            Flotar(g, w * 0.14f, h * 0.52f, 25f, 1, 3.0f);
            using (var lapiz = new Pen(Color.FromArgb(150, Cian), 1.4f))
            {
                g.DrawRectangle(lapiz, -8f, -8f, 16f, 16f);
            }
            g.ResetTransform();

            // Anillo
            Flotar(g, w * 0.88f, h * 0.72f, 0f, 2, 3.5f);
            using (var lapiz = new Pen(Color.FromArgb(150, Rosa), 1.4f))
            {
                g.DrawEllipse(lapiz, -9f, -9f, 18f, 18f);
            }
            g.ResetTransform();

            // Signos más
            using (var lapiz = new Pen(Color.FromArgb(100, 255, 255, 255), 1.2f))
            {
                Flotar(g, w * 0.50f, h * 0.43f, 0f, 3, 2.0f);
                g.DrawLine(lapiz, -5f, 0f, 5f, 0f);
                g.DrawLine(lapiz, 0f, -5f, 0f, 5f);
                g.ResetTransform();

                Flotar(g, w * 0.26f, h * 0.17f, 0f, 4, 2.0f);
                g.DrawLine(lapiz, -4f, 0f, 4f, 0f);
                g.DrawLine(lapiz, 0f, -4f, 0f, 4f);
                g.ResetTransform();
            }

            // Arco punteado
            using (var lapiz = new Pen(Color.FromArgb(70, Violeta), 1.2f))
            {
                lapiz.DashStyle = DashStyle.Dot;
                g.DrawArc(lapiz, w * 0.28f, h * 0.60f, w * 0.52f, w * 0.52f, 200f, 120f);
            }
        }

        /// <summary>Coloca el origen en (x, y) con un pequeño vaivén y un giro; se restablece con ResetTransform.</summary>
        private void Flotar(Graphics g, float x, float y, float angulo, int semilla, float amplitud)
        {
            float dx = (float)Math.Sin(_fase * 0.9f + semilla * 1.9f) * amplitud;
            float dy = (float)Math.Cos(_fase * 0.7f + semilla * 1.3f) * amplitud;
            g.ResetTransform();
            g.TranslateTransform(x + dx, y + dy);
            g.RotateTransform(angulo + (float)Math.Sin(_fase * 0.5f + semilla) * 6f);
        }

        private void DibujarCirculos(Graphics g, float w, float h)
        {
            float cx = w * 0.56f;
            float cy = h * 0.81f;
            float r = Math.Min(w, h) * 0.17f;
            float d = r * 0.58f;
            PointF[] centros =
            {
                new PointF(cx, cy - d),
                new PointF(cx - d * 0.95f, cy + d * 0.62f),
                new PointF(cx + d * 0.95f, cy + d * 0.62f)
            };
            Color[] colores = { Indigo, Rosa, Ambar };

            for (int i = 0; i < 3; i++)
            {
                using (var relleno = new SolidBrush(Color.FromArgb(40, colores[i])))
                using (var lapiz = new Pen(Color.FromArgb(110, colores[i]), 1f))
                {
                    g.FillEllipse(relleno, centros[i].X - r, centros[i].Y - r, r * 2f, r * 2f);
                    g.DrawEllipse(lapiz, centros[i].X - r, centros[i].Y - r, r * 2f, r * 2f);
                }
            }
        }

        private void DibujarPuntos(Graphics g, float w, float h)
        {
            using (var pincel = new SolidBrush(Color.FromArgb(70, 255, 255, 255)))
            {
                for (int fila = 0; fila < 3; fila++)
                {
                    for (int col = 0; col < 6; col++)
                    {
                        g.FillEllipse(pincel, w * 0.54f + col * 11f, 14f + fila * 11f, 2.4f, 2.4f);
                    }
                }
            }
        }

        private void DibujarTextoVertical(Graphics g, float w, float h)
        {
            if (string.IsNullOrEmpty(_textoVertical)) { return; }
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            GraphicsState estado = g.Save();
            g.TranslateTransform(w - 12f, h * 0.5f);
            g.RotateTransform(-90f);
            using (var pincel = new SolidBrush(Color.FromArgb(105, 200, 206, 240)))
            using (var formato = new StringFormat(StringFormat.GenericTypographic))
            {
                formato.Alignment = StringAlignment.Center;
                formato.LineAlignment = StringAlignment.Center;
                g.DrawString(GraficosUi.Espaciar(_textoVertical), _fuenteVertical, pincel, new PointF(0f, 0f), formato);
            }
            g.Restore(estado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _reloj.Dispose();
                _fuenteVertical.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
