using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Presentacion
{
    /// <summary>
    /// Botón con icono (fuente Segoe MDL2 Assets), esquinas redondeadas y estado "Seleccionado".
    /// Se usa para el menú lateral, las pestañas y los botones de acción.
    /// El color base es la propiedad BackColor.
    /// </summary>
    public class BotonIcono : Button
    {
        private bool hover, presionado, seleccionado;
        private string glyph = "";
        private int radio = 8;
        private Color colorHover = Color.FromArgb(55, 70, 170);
        private Color colorSeleccionado = Color.FromArgb(61, 63, 206);
        private Color colorBorde = Color.Transparent;
        private Color colorGlyph = Color.White;

        public BotonIcono()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Cursor = Cursors.Hand;
            Size = new Size(126, 28);
            BackColor = Color.FromArgb(37, 50, 128);
            ForeColor = Color.White;
            Font = new Font("Segoe UI", 9F);
        }

        [Category("Icono"), DefaultValue(""), Description("Carácter de la fuente Segoe MDL2 Assets, por ejemplo \\uE710.")]
        public string Glyph { get { return glyph; } set { glyph = value ?? ""; Invalidate(); } }

        [Category("Icono"), DefaultValue(typeof(Color), "White")]
        public Color ColorGlyph { get { return colorGlyph; } set { colorGlyph = value; Invalidate(); } }

        [Category("Apariencia"), DefaultValue(8)]
        public int Radio { get { return radio; } set { radio = value; Invalidate(); } }

        [Category("Apariencia")]
        public Color ColorHover { get { return colorHover; } set { colorHover = value; Invalidate(); } }
        private bool ShouldSerializeColorHover() { return colorHover != Color.FromArgb(55, 70, 170); }
        private void ResetColorHover() { ColorHover = Color.FromArgb(55, 70, 170); }

        [Category("Apariencia")]
        public Color ColorSeleccionado { get { return colorSeleccionado; } set { colorSeleccionado = value; Invalidate(); } }
        private bool ShouldSerializeColorSeleccionado() { return colorSeleccionado != Color.FromArgb(61, 63, 206); }
        private void ResetColorSeleccionado() { ColorSeleccionado = Color.FromArgb(61, 63, 206); }

        [Category("Apariencia"), DefaultValue(typeof(Color), "Transparent")]
        public Color ColorBorde { get { return colorBorde; } set { colorBorde = value; Invalidate(); } }

        [Category("Apariencia"), DefaultValue(false)]
        public bool Seleccionado { get { return seleccionado; } set { seleccionado = value; Invalidate(); } }

        protected override void OnMouseEnter(EventArgs e) { hover = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { hover = false; presionado = false; Invalidate(); base.OnMouseLeave(e); }
        protected override void OnMouseDown(MouseEventArgs e) { presionado = true; Invalidate(); base.OnMouseDown(e); }
        protected override void OnMouseUp(MouseEventArgs e) { presionado = false; Invalidate(); base.OnMouseUp(e); }
        protected override void OnEnabledChanged(EventArgs e) { hover = false; presionado = false; Invalidate(); base.OnEnabledChanged(e); }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            Color fondoPadre = Dibujo.FondoPadre(this);
            g.Clear(fondoPadre);

            Color fondo;
            Color texto = ForeColor;
            Color colorIcono = colorGlyph;
            if (!Enabled)
            {
                fondo = Dibujo.Mezclar(BackColor, fondoPadre, 0.55f);
                texto = Color.FromArgb(110, 118, 165);
                colorIcono = texto;
            }
            else if (seleccionado) fondo = colorSeleccionado;
            else if (presionado) fondo = Dibujo.Mezclar(BackColor, Color.Black, 0.25f);
            else if (hover) fondo = colorHover;
            else fondo = BackColor;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            using (GraphicsPath path = Dibujo.Redondeado(rect, radio))
            using (SolidBrush br = new SolidBrush(fondo))
            {
                g.FillPath(br, path);
                if (colorBorde.A > 0 && !seleccionado)
                    using (Pen pen = new Pen(colorBorde)) g.DrawPath(pen, path);
            }

            bool tieneIcono = glyph.Length > 0;
            int inicioTexto = tieneIcono ? 44 : 0;

            if (tieneIcono)
            {
                using (Font f = new Font("Segoe MDL2 Assets", 11F))
                using (SolidBrush b = new SolidBrush(colorIcono))
                using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                    g.DrawString(glyph, f, b, new RectangleF(10, 0, 28, Height), sf);
            }

            using (SolidBrush b = new SolidBrush(texto))
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = tieneIcono ? StringAlignment.Near : StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                sf.Trimming = StringTrimming.EllipsisCharacter;
                sf.FormatFlags = StringFormatFlags.NoWrap;
                g.DrawString(Text, Font, b, new RectangleF(inicioTexto, 0, Width - inicioTexto - 4, Height), sf);
            }
        }
    }
}
