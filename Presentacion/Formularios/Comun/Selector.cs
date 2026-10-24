using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SistemaPublicidad.Formularios
{
    class ColoresOscuros : ProfessionalColorTable
    {
        public override Color ToolStripDropDownBackground { get { return Tema.Campo; } }
        public override Color MenuItemSelected { get { return Color.FromArgb(95, 70, 225); } }
        public override Color MenuItemSelectedGradientBegin { get { return Color.FromArgb(120, 70, 240); } }
        public override Color MenuItemSelectedGradientEnd { get { return Color.FromArgb(220, 80, 210); } }
        public override Color MenuItemBorder { get { return Color.FromArgb(160, 100, 255); } }
        public override Color MenuBorder { get { return Tema.Borde; } }
        public override Color ImageMarginGradientBegin { get { return Tema.Campo; } }
        public override Color ImageMarginGradientMiddle { get { return Tema.Campo; } }
        public override Color ImageMarginGradientEnd { get { return Tema.Campo; } }
    }

    // Lista desplegable con el estilo del sistema (sin el recuadro blanco del ComboBox)
    public class Selector : Control
    {
        public string Rotulo = ""; public List<string> Items = new List<string>(); public List<int> Codigos = new List<int>(); int sel;
        public event EventHandler Cambio;
        public int Seleccion { get { return sel; } set { sel = value; Invalidate(); if (Cambio != null) Cambio(this, EventArgs.Empty); } }
        public string Texto { get { return sel >= 0 && sel < Items.Count ? Items[sel] : ""; } }
        public Selector() { SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true); BackColor = Color.Transparent; Cursor = Cursors.Hand; }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias; g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            if (Width < 30 || Height < 20) return;
            using (var p = Tema.Ruta(new RectangleF(0.5f, 0.5f, Width - 2, Height - 2), 12))
            { using (var b = new SolidBrush(Tema.Campo)) g.FillPath(b, p); using (var pn = new Pen(Color.FromArgb(150, Tema.Borde), 1.3f)) g.DrawPath(pn, p); }
            using (var f = Tema.F(8)) using (var b = new SolidBrush(Tema.Sub)) g.DrawString(Rotulo, f, b, 12, 4);
            using (var f = Tema.F(10.5f)) using (var sf = new StringFormat { Trimming = StringTrimming.EllipsisCharacter, FormatFlags = StringFormatFlags.NoWrap })
                g.DrawString(Texto, f, Brushes.White, new RectangleF(12, 20, Width - 40, 22), sf);
            using (var pn = new Pen(Color.White, 1.8f) { StartCap = LineCap.Round, EndCap = LineCap.Round })
                g.DrawLines(pn, new[] { new PointF(Width - 24, Height / 2f - 2), new PointF(Width - 19, Height / 2f + 3), new PointF(Width - 14, Height / 2f - 2) });
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            var m = new ContextMenuStrip { Renderer = new ToolStripProfessionalRenderer(new ColoresOscuros()), ShowImageMargin = false, BackColor = Tema.Campo, ForeColor = Color.White, Font = Tema.F(10), MinimumSize = new Size(Width, 0) };
            for (int i = 0; i < Items.Count; i++)
            {
                int idx = i; var mi = new ToolStripMenuItem(Items[i]) { ForeColor = Color.White };
                mi.Click += (s, a) => Seleccion = idx; m.Items.Add(mi);
            }
            m.Show(this, new Point(0, Height + 2));
        }
    }
}
