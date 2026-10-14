using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Presentacion
{
    /// <summary>Tarjeta de resumen con degradado: icono, título, valor, tendencia opcional y subtítulo.</summary>
    public class StatCard : RoundedPanel
    {
        private string titulo = "Titulo";
        private string valor = "0";
        private string subtitulo = "";
        private string tendencia = "";
        private string glyph = "\uE77B";
        private Color colorInicio = Color.FromArgb(79, 70, 229);
        private Color colorFin = Color.FromArgb(124, 58, 237);

        public StatCard()
        {
            Size = new Size(260, 110);
        }

        [Category("Tarjeta"), DefaultValue("Titulo")]
        public string Titulo { get { return titulo; } set { titulo = value; Invalidate(); } }

        [Category("Tarjeta"), DefaultValue("0")]
        public string Valor { get { return valor; } set { valor = value; Invalidate(); } }

        [Category("Tarjeta"), DefaultValue("")]
        public string Subtitulo { get { return subtitulo; } set { subtitulo = value; Invalidate(); } }

        [Category("Tarjeta"), DefaultValue(""), Description("Texto opcional de tendencia (por ejemplo: 25%). Se muestra en verde con una flecha.")]
        public string Tendencia { get { return tendencia; } set { tendencia = value; Invalidate(); } }

        [Category("Tarjeta"), DefaultValue("\uE77B"), Description("Carácter de la fuente Segoe MDL2 Assets.")]
        public string Glyph { get { return glyph; } set { glyph = value; Invalidate(); } }

        [Category("Tarjeta")]
        public Color ColorInicio { get { return colorInicio; } set { colorInicio = value; Invalidate(); } }
        private bool ShouldSerializeColorInicio() { return colorInicio != Color.FromArgb(79, 70, 229); }
        private void ResetColorInicio() { ColorInicio = Color.FromArgb(79, 70, 229); }

        [Category("Tarjeta")]
        public Color ColorFin { get { return colorFin; } set { colorFin = value; Invalidate(); } }
        private bool ShouldSerializeColorFin() { return colorFin != Color.FromArgb(124, 58, 237); }
        private void ResetColorFin() { ColorFin = Color.FromArgb(124, 58, 237); }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Dibujo.FondoPadre(this));
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            if (rect.Width < 120 || rect.Height < 70) return;

            using (GraphicsPath path = Dibujo.Redondeado(rect, Radio))
            {
                using (LinearGradientBrush lg = new LinearGradientBrush(rect, colorInicio, colorFin, 35f))
                    g.FillPath(lg, path);

                // icono grande, translúcido, de adorno
                g.SetClip(path);
                using (Font fd = new Font("Segoe MDL2 Assets", 54F))
                using (SolidBrush bd = new SolidBrush(Color.FromArgb(36, 255, 255, 255)))
                    g.DrawString(glyph, fd, bd, Width - 104, Height - 96);
                g.ResetClip();

                using (Pen pen = new Pen(Color.FromArgb(90, 255, 255, 255)))
                    g.DrawPath(pen, path);
            }

            // icono en cuadro redondeado
            Rectangle cuadro = new Rectangle(16, 16, 54, 54);
            using (GraphicsPath cp = Dibujo.Redondeado(cuadro, 14))
            using (SolidBrush cb = new SolidBrush(Color.FromArgb(70, 255, 255, 255)))
                g.FillPath(cb, cp);
            using (Font f = new Font("Segoe MDL2 Assets", 22F))
            using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                g.DrawString(glyph, f, Brushes.White, cuadro, sf);

            int x = cuadro.Right + 14;
            int disponible = Width - x - 12;

            using (Font f = new Font("Segoe UI", 11F, FontStyle.Bold))
                g.DrawString(titulo, f, Brushes.White, x, 12);

            // el valor reduce su tamaño si no cabe (por ejemplo, montos grandes)
            float tam = 24F;
            Font fv = new Font("Segoe UI", tam, FontStyle.Bold);
            while (tam > 10F && g.MeasureString(valor, fv).Width > disponible)
            {
                fv.Dispose();
                tam -= 1F;
                fv = new Font("Segoe UI", tam, FontStyle.Bold);
            }
            using (fv)
                g.DrawString(valor, fv, Brushes.White, x - 3, 30);

            if (!string.IsNullOrEmpty(tendencia))
            {
                using (Font f = new Font("Segoe UI", 8.5F, FontStyle.Bold))
                using (SolidBrush b = new SolidBrush(Color.FromArgb(120, 255, 170)))
                    g.DrawString("\u25B2 " + tendencia, f, b, x, Height - 44);
            }
            using (Font f = new Font("Segoe UI", 9F))
            using (SolidBrush b = new SolidBrush(Color.FromArgb(235, 255, 255, 255)))
                g.DrawString(subtitulo, f, b, x, Height - 28);
        }
    }
}
