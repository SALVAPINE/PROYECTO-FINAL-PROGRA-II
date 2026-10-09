using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Presentacion
{
    /// <summary>Caja de búsqueda con icono de lupa y texto de ayuda (placeholder).</summary>
    public class CampoBusqueda : RoundedPanel
    {
        private readonly TextBox txt = new TextBox();
        private string placeholder = "Buscar...";

        public event EventHandler TextoCambiado;
        public event EventHandler EnterPresionado;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

        public CampoBusqueda()
        {
            Radio = 8;
            BackColor = Color.FromArgb(30, 37, 92);
            Size = new Size(300, 34);

            txt.BorderStyle = BorderStyle.None;
            txt.BackColor = BackColor;
            txt.ForeColor = Color.White;
            txt.Font = new Font("Segoe UI", 9.5F);
            txt.TextChanged += delegate (object s, EventArgs e)
            {
                EventHandler h = TextoCambiado;
                if (h != null) h(this, EventArgs.Empty);
            };
            txt.KeyDown += delegate (object s, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    EventHandler h = EnterPresionado;
                    if (h != null) h(this, EventArgs.Empty);
                }
            };
            txt.HandleCreated += delegate { AplicarPlaceholder(); };
            Controls.Add(txt);
            Distribuir();
        }

        [Category("Búsqueda"), DefaultValue("Buscar...")]
        public string Placeholder
        {
            get { return placeholder; }
            set { placeholder = value ?? ""; AplicarPlaceholder(); }
        }

        [Category("Búsqueda"), DefaultValue("")]
        public string Texto
        {
            get { return txt.Text; }
            set { txt.Text = value ?? ""; }
        }

        public new bool Focus()
        {
            return txt.Focus();
        }

        private void AplicarPlaceholder()
        {
            if (txt.IsHandleCreated)
                SendMessage(txt.Handle, 0x1501, IntPtr.Zero, placeholder);
        }

        private void Distribuir()
        {
            txt.Left = 36;
            txt.Width = Math.Max(10, Width - 48);
            txt.Top = Math.Max(0, (Height - txt.Height) / 2);
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            Distribuir();
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            txt.BackColor = BackColor;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            using (Font f = new Font("Segoe MDL2 Assets", 11F))
            using (SolidBrush br = new SolidBrush(Color.FromArgb(160, 170, 220)))
            using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                e.Graphics.DrawString("\uE721", f, br, new RectangleF(6, 0, 26, Height), sf);
        }
    }
}
