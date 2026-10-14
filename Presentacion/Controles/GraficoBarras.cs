using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion
{
    /// <summary>Gráfico de barras horizontales (etiqueta, barra de color y valor).</summary>
    public class GraficoBarras : Control
    {
        private List<PuntoGrafico> datos = new List<PuntoGrafico>();

        public GraficoBarras()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            BackColor = Color.FromArgb(26, 32, 84);
            ForeColor = Color.White;
            Size = new Size(380, 150);
        }

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

            using (Font fuente = new Font("Segoe UI", 9.5F))
            using (SolidBrush txt = new SolidBrush(Color.FromArgb(214, 220, 245)))
            {
                if (datos.Count == 0)
                {
                    using (SolidBrush suave = new SolidBrush(Color.FromArgb(120, 130, 190)))
                    using (StringFormat centro = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                        g.DrawString("Sin datos", fuente, suave, new RectangleF(0, 0, Width, Height), centro);
                    return;
                }

                int n = datos.Count;
                int fila = Math.Max(24, Math.Min(40, (Height - 8) / n));
                int y0 = Math.Max(4, (Height - n * fila) / 2);
                decimal max = datos.Max(d => d.Valor);
                if (max <= 0) max = 1;

                float anchoEtiqueta = datos.Max(d => g.MeasureString(d.Etiqueta, fuente).Width);
                anchoEtiqueta = Math.Min(anchoEtiqueta, Width * 0.38f);
                int xBarra = (int)anchoEtiqueta + 22;
                int anchoBarra = Width - xBarra - 52;
                if (anchoBarra < 20) return;

                using (Pen guia = new Pen(Color.FromArgb(40, 48, 110)))
                    g.DrawLine(guia, xBarra, y0 - 2, xBarra, y0 + n * fila);

                using (StringFormat etiqueta = new StringFormat { LineAlignment = StringAlignment.Center, Trimming = StringTrimming.EllipsisCharacter, FormatFlags = StringFormatFlags.NoWrap })
                using (StringFormat valor = new StringFormat { LineAlignment = StringAlignment.Center })
                {
                    for (int i = 0; i < n; i++)
                    {
                        PuntoGrafico d = datos[i];
                        int y = y0 + i * fila;
                        g.DrawString(d.Etiqueta, fuente, txt, new RectangleF(6, y, anchoEtiqueta + 10, fila), etiqueta);

                        int largo = (int)((float)(d.Valor / max) * anchoBarra);
                        if (d.Valor > 0 && largo < 4) largo = 4;
                        if (largo > 0)
                        {
                            Rectangle barra = new Rectangle(xBarra + 2, y + (fila - 14) / 2, largo, 14);
                            using (GraphicsPath gp = Dibujo.Redondeado(barra, 7))
                            using (SolidBrush b = new SolidBrush(d.Color))
                                g.FillPath(b, gp);
                        }
                        g.DrawString(d.Valor.ToString("0.##"), fuente, txt, new RectangleF(xBarra + 2 + largo + 10, y, 48, fila), valor);
                    }
                }
            }
        }
    }
}
