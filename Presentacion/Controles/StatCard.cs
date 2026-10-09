using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Presentacion
{
    /// <summary>Tarjeta de resumen (icono en círculo + título + valor + subtítulo).</summary>
    public class StatCard : RoundedPanel
    {
        private string titulo = "Titulo";
        private string valor = "0";
        private string subtitulo = "";
        private string glyph = "\uE77B";
        private Color colorIcono = Color.FromArgb(32, 201, 170);
        private Color colorSubtitulo = Color.FromArgb(46, 212, 122);

        public StatCard()
        {
            Size = new Size(260, 100);
        }

        [Category("Tarjeta"), DefaultValue("Titulo")]
        public string Titulo { get { return titulo; } set { titulo = value; Invalidate(); } }

        [Category("Tarjeta"), DefaultValue("0")]
        public string Valor { get { return valor; } set { valor = value; Invalidate(); } }

        [Category("Tarjeta"), DefaultValue("")]
        public string Subtitulo { get { return subtitulo; } set { subtitulo = value; Invalidate(); } }

        [Category("Tarjeta"), DefaultValue("\uE77B"), Description("Carácter de la fuente Segoe MDL2 Assets.")]
        public string Glyph { get { return glyph; } set { glyph = value; Invalidate(); } }

        [Category("Tarjeta")]
        public Color ColorIcono { get { return colorIcono; } set { colorIcono = value; Invalidate(); } }
        private bool ShouldSerializeColorIcono() { return colorIcono != Color.FromArgb(32, 201, 170); }
        private void ResetColorIcono() { ColorIcono = Color.FromArgb(32, 201, 170); }

        [Category("Tarjeta")]
        public Color ColorSubtitulo { get { return colorSubtitulo; } set { colorSubtitulo = value; Invalidate(); } }
        private bool ShouldSerializeColorSubtitulo() { return colorSubtitulo != Color.FromArgb(46, 212, 122); }
        private void ResetColorSubtitulo() { ColorSubtitulo = Color.FromArgb(46, 212, 122); }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            int d = 62;
            Rectangle circulo = new Rectangle(16, (Height - d) / 2, d, d);
            using (SolidBrush br = new SolidBrush(Color.FromArgb(55, colorIcono)))
                g.FillEllipse(br, circulo);

            using (Font f = new Font("Segoe MDL2 Assets", 24F))
            using (SolidBrush br = new SolidBrush(colorIcono))
            using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                g.DrawString(glyph, f, br, circulo, sf);

            int x = circulo.Right + 16;
            int disponible = Width - x - 10;

            using (Font f = new Font("Segoe UI", 10F, FontStyle.Bold))
                g.DrawString(titulo, f, Brushes.White, x, 10);

            // El valor reduce su tamaño si no cabe (por ejemplo, montos grandes).
            float tam = 22F;
            Font fv = new Font("Segoe UI", tam, FontStyle.Bold);
            while (tam > 10F && g.MeasureString(valor, fv).Width > disponible)
            {
                fv.Dispose();
                tam -= 1F;
                fv = new Font("Segoe UI", tam, FontStyle.Bold);
            }
            using (fv)
                g.DrawString(valor, fv, Brushes.White, x - 2, 26);

            using (Font f = new Font("Segoe UI", 8.5F))
            using (SolidBrush br = new SolidBrush(colorSubtitulo))
                g.DrawString(subtitulo, f, br, x, Height - 28);
        }
    }
}
