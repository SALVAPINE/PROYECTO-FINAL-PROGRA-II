using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Presentacion
{
    /// <summary>Logo de la aplicación: icono con degradado y el nombre "Publicidad Multisucursal".</summary>
    public class LogoMarca : Control
    {
        public LogoMarca()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            Size = new Size(176, 52);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // El fondo se pinta completo en OnPaint.
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            PanelDegradado degradadoPadre = Parent as PanelDegradado;
            if (degradadoPadre != null)
            {
                GraphicsState estado = g.Save();
                g.TranslateTransform(-Left, -Top);
                degradadoPadre.DibujarFondo(g);
                g.Restore(estado);
            }
            else g.Clear(Dibujo.FondoPadre(this));
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            Rectangle caja = new Rectangle(0, 4, 44, 44);
            using (GraphicsPath gp = Dibujo.Redondeado(caja, 12))
            using (LinearGradientBrush lg = new LinearGradientBrush(caja, Color.FromArgb(244, 63, 94), Color.FromArgb(99, 102, 241), 45f))
                g.FillPath(lg, gp);
            using (Font f = new Font("Segoe MDL2 Assets", 20F))
            using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                g.DrawString("\uE719", f, Brushes.White, caja, sf);

            using (Font f = new Font("Segoe UI", 13F, FontStyle.Bold))
            {
                g.DrawString("Publicidad", f, Brushes.White, 52, 3);
                g.DrawString("Multisucursal", f, Brushes.White, 52, 24);
            }
        }
    }
}
