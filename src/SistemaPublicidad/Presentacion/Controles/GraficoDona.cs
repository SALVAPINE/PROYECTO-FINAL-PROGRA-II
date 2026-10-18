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
    /// <summary>Gráfico de dona con el total al centro y una leyenda (color, nombre, valor y porcentaje).</summary>
    public class GraficoDona : Control
    {
        private List<PuntoGrafico> datos = new List<PuntoGrafico>();
        private string textoCentro = "Total";

        public GraficoDona()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            BackColor = Color.FromArgb(26, 32, 84);
            ForeColor = Color.White;
            Size = new Size(380, 180);
        }

        [Category("Gráfico"), DefaultValue("Total")]
        public string TextoCentro { get { return textoCentro; } set { textoCentro = value ?? ""; Invalidate(); } }

        /// <summary>Asigna los datos del gráfico (se llama desde el código, no desde el diseñador).</summary>
        public void SetDatos(IEnumerable<PuntoGrafico> nuevos)
        {
            datos = nuevos == null ? new List<PuntoGrafico>() : nuevos.ToList();
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(BackColor);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            decimal total = datos.Sum(d => d.Valor);
            int lado = Math.Min(Height - 12, (int)(Width * 0.46f));
            if (lado < 50) return;

            Rectangle caja = new Rectangle(8, (Height - lado) / 2, lado, lado);
            float grosor = lado * 0.19f;
            RectangleF arco = new RectangleF(caja.X + grosor / 2f, caja.Y + grosor / 2f, caja.Width - grosor, caja.Height - grosor);

            if (total <= 0)
            {
                using (Pen p = new Pen(Color.FromArgb(48, 56, 130), grosor))
                    g.DrawEllipse(p, arco);
            }
            else
            {
                float inicio = -90f;
                int visibles = datos.Count(d => d.Valor > 0);
                float hueco = visibles > 1 ? 2.5f : 0f;
                foreach (PuntoGrafico d in datos)
                {
                    if (d.Valor <= 0) continue;
                    float barrido = (float)(d.Valor / total) * 360f;
                    using (Pen p = new Pen(d.Color, grosor))
                    {
                        p.StartCap = LineCap.Flat;
                        p.EndCap = LineCap.Flat;
                        g.DrawArc(p, arco, inicio + hueco / 2f, Math.Max(barrido - hueco, 0.5f));
                    }
                    inicio += barrido;
                }
            }

            // total al centro
            using (StringFormat centro = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                using (Font f = new Font("Segoe UI", 17F, FontStyle.Bold))
                    g.DrawString(total.ToString("0.##"), f, Brushes.White, new RectangleF(caja.X, caja.Y + caja.Height / 2f - 24, caja.Width, 30), centro);
                using (Font f = new Font("Segoe UI", 8.5F))
                using (SolidBrush b = new SolidBrush(Color.FromArgb(160, 170, 220)))
                    g.DrawString(textoCentro, f, b, new RectangleF(caja.X, caja.Y + caja.Height / 2f + 4, caja.Width, 18), centro);
            }

            // leyenda
            int x0 = caja.Right + 26;
            using (Font fuente = new Font("Segoe UI", 9.5F))
            using (SolidBrush txt = new SolidBrush(Color.FromArgb(214, 220, 245)))
            {
                if (datos.Count == 0)
                {
                    using (SolidBrush suave = new SolidBrush(Color.FromArgb(120, 130, 190)))
                        g.DrawString("Sin datos", fuente, suave, x0, Height / 2 - 9);
                    return;
                }

                int alto = Math.Max(22, Math.Min(32, (Height - 8) / datos.Count));
                int y0 = Math.Max(4, (Height - datos.Count * alto) / 2);
                for (int i = 0; i < datos.Count; i++)
                {
                    PuntoGrafico d = datos[i];
                    int y = y0 + i * alto;
                    using (SolidBrush punto = new SolidBrush(d.Color))
                        g.FillEllipse(punto, x0, y + (alto - 12) / 2, 12, 12);
                    g.DrawString(d.Etiqueta, fuente, txt, x0 + 22, y + (alto - fuente.Height) / 2);

                    string derecha = d.Valor.ToString("0.##");
                    if (total > 0)
                        derecha += "  (" + ((int)Math.Round(d.Valor / total * 100)).ToString() + "%)";
                    SizeF medida = g.MeasureString(derecha, fuente);
                    g.DrawString(derecha, fuente, txt, Width - 12 - medida.Width, y + (alto - fuente.Height) / 2);
                }
            }
        }
    }
}
