using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion
{
    /// <summary>Gráfico de columnas con degradado, líneas guía y valores en el eje vertical.</summary>
    public class GraficoColumnas : Control
    {
        private List<PuntoGrafico> datos = new List<PuntoGrafico>();
        private string prefijoValor = "Q";

        public GraficoColumnas()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            BackColor = Color.FromArgb(26, 32, 84);
            ForeColor = Color.White;
            Size = new Size(380, 180);
        }

        [Category("Gráfico"), DefaultValue("Q"), Description("Texto que antecede a los valores del eje (por ejemplo Q).")]
        public string PrefijoValor { get { return prefijoValor; } set { prefijoValor = value ?? ""; Invalidate(); } }

        public void SetDatos(IEnumerable<PuntoGrafico> nuevos)
        {
            datos = nuevos == null ? new List<PuntoGrafico>() : nuevos.ToList();
            Invalidate();
        }

        private static decimal EscalaMaxima(decimal max)
        {
            if (max <= 0) return 1000m;
            double m = (double)max;
            double magnitud = Math.Pow(10, Math.Floor(Math.Log10(m)));
            double n = m / magnitud;
            double[] pasos = { 1, 1.2, 1.6, 2, 2.4, 3, 4, 5, 6, 8, 10 };
            double elegido = 10;
            foreach (double p in pasos)
            {
                if (n <= p) { elegido = p; break; }
            }
            return (decimal)(elegido * magnitud);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(BackColor);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            const int izquierda = 70, arriba = 10, abajo = 28, derecha = 10;
            Rectangle area = new Rectangle(izquierda, arriba, Width - izquierda - derecha, Height - arriba - abajo);
            if (area.Width < 40 || area.Height < 40) return;

            decimal max = datos.Count == 0 ? 0 : datos.Max(d => d.Valor);
            decimal tope = EscalaMaxima(max);

            using (Font fuente = new Font("Segoe UI", 8.5F))
            using (SolidBrush suave = new SolidBrush(Color.FromArgb(160, 170, 220)))
            using (Pen guia = new Pen(Color.FromArgb(40, 48, 110)))
            using (StringFormat derechaAlineado = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center })
            using (StringFormat centrado = new StringFormat { Alignment = StringAlignment.Center })
            {
                for (int i = 0; i <= 4; i++)
                {
                    int y = area.Bottom - area.Height * i / 4;
                    g.DrawLine(guia, area.Left, y, area.Right, y);
                    string etiqueta = prefijoValor + (tope * i / 4m).ToString("N0");
                    g.DrawString(etiqueta, fuente, suave, new RectangleF(0, y - 10, izquierda - 8, 20), derechaAlineado);
                }

                if (datos.Count == 0) return;

                float ranura = area.Width / (float)datos.Count;
                float ancho = Math.Min(48f, ranura * 0.55f);
                for (int i = 0; i < datos.Count; i++)
                {
                    PuntoGrafico d = datos[i];
                    float x = area.Left + ranura * i + (ranura - ancho) / 2f;
                    float alto = tope > 0 ? (float)(d.Valor / tope) * area.Height : 0f;
                    if (alto > 0f && alto < 2f) alto = 2f;

                    if (alto >= 2f)
                    {
                        Rectangle col = new Rectangle((int)x, (int)(area.Bottom - alto), (int)ancho, (int)alto);
                        bool maximo = d.Valor == max && max > 0;
                        Color arribaColor = maximo ? Color.FromArgb(217, 70, 239) : Color.FromArgb(96, 165, 250);
                        Color abajoColor = maximo ? Color.FromArgb(147, 51, 234) : Color.FromArgb(99, 102, 241);
                        using (GraphicsPath gp = Dibujo.Redondeado(col, Math.Min(5, Math.Min(col.Width, col.Height) / 2)))
                        using (LinearGradientBrush lg = new LinearGradientBrush(new Rectangle(col.X, col.Y, col.Width, col.Height + 1), arribaColor, abajoColor, 90f))
                            g.FillPath(lg, gp);
                    }

                    g.DrawString(d.Etiqueta, fuente, suave, new RectangleF(area.Left + ranura * i, area.Bottom + 6, ranura, 18), centrado);
                }
            }
        }
    }
}
