using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CAPAZ.Presentacion.Controles
{
    /// <summary>
    /// Panel con fondo degradado, resplandores de color y círculos decorativos.
    /// Los controles que se coloquen encima (Label, paneles) pueden tener fondo transparente.
    /// </summary>
    public class PanelDegradado : Panel
    {
        private Color _colorInicio = Color.FromArgb(8, 12, 40);
        private Color _colorFin = Color.FromArgb(40, 24, 112);
        private float _angulo = 60f;
        private bool _mostrarBrillos = true;
        private Color _brilloMorado = Color.FromArgb(124, 58, 237);
        private Color _brilloRosa = Color.FromArgb(236, 72, 153);
        private Color _brilloNaranja = Color.FromArgb(249, 115, 22);
        private Color _brilloAzul = Color.FromArgb(59, 130, 246);

        public PanelDegradado()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        }

        [Category("CAPAZ")] public Color ColorInicio { get { return _colorInicio; } set { _colorInicio = value; Invalidate(); } }
        [Category("CAPAZ")] public Color ColorFin { get { return _colorFin; } set { _colorFin = value; Invalidate(); } }
        [Category("CAPAZ")] public float Angulo { get { return _angulo; } set { _angulo = value; Invalidate(); } }
        [Category("CAPAZ"), Description("Dibuja los resplandores de colores y los círculos decorativos.")]
        public bool MostrarBrillos { get { return _mostrarBrillos; } set { _mostrarBrillos = value; Invalidate(); } }
        [Category("CAPAZ")] public Color BrilloMorado { get { return _brilloMorado; } set { _brilloMorado = value; Invalidate(); } }
        [Category("CAPAZ")] public Color BrilloRosa { get { return _brilloRosa; } set { _brilloRosa = value; Invalidate(); } }
        [Category("CAPAZ")] public Color BrilloNaranja { get { return _brilloNaranja; } set { _brilloNaranja = value; Invalidate(); } }
        [Category("CAPAZ")] public Color BrilloAzul { get { return _brilloAzul; } set { _brilloAzul = value; Invalidate(); } }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (Width < 2 || Height < 2) { return; }
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (var fondo = new LinearGradientBrush(ClientRectangle, _colorInicio, _colorFin, _angulo))
            {
                g.FillRectangle(fondo, ClientRectangle);
            }

            if (!_mostrarBrillos) { return; }

            float m = Math.Max(Width, Height);
            Brillo(g, Width * 1.00f, Height * 1.05f, m * 0.80f, _brilloMorado, 120);
            Brillo(g, Width * 0.10f, Height * 1.10f, m * 0.50f, _brilloRosa, 70);
            Brillo(g, Width * 0.95f, Height * 0.00f, m * 0.55f, _brilloAzul, 85);
            Brillo(g, Width * 0.80f, Height * 0.34f, m * 0.22f, _brilloNaranja, 22);

            // Círculos decorativos, solo contorno y muy tenues
            using (var lapiz = new Pen(Color.FromArgb(14, 255, 255, 255), 1f))
            {
                float c = Math.Min(Width, Height);
                g.DrawEllipse(lapiz, Width - c * 0.62f, -c * 0.28f, c * 0.90f, c * 0.90f);
                g.DrawEllipse(lapiz, Width - c * 0.46f, -c * 0.12f, c * 0.60f, c * 0.60f);
            }
        }

        private static void Brillo(Graphics g, float cx, float cy, float radio, Color color, int alfa)
        {
            using (var ruta = new GraphicsPath())
            {
                ruta.AddEllipse(cx - radio, cy - radio, radio * 2f, radio * 2f);
                using (var pincel = new PathGradientBrush(ruta))
                {
                    pincel.CenterColor = Color.FromArgb(alfa, color);
                    pincel.SurroundColors = new[] { Color.FromArgb(0, color) };
                    g.FillPath(pincel, ruta);
                }
            }
        }
    }
}
