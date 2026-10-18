using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CAPAZ.Presentacion.Controles
{
    /// <summary>
    /// Cuadro de texto oscuro con borde redondeado fino, icono opcional, texto de ayuda
    /// y (opcional) botón de "ver contraseña" dibujado por código.
    /// </summary>
    [DefaultEvent("TextChanged")]
    public class CampoTexto : Control
    {
        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

        private readonly TextBox _txt = new TextBox();
        private int _radio = 10;
        private int _margenDerecho = 12;
        private bool _enfocado;
        private bool _botonVer;
        private bool _encimaOjo;
        private string _codigoIcono = string.Empty;
        private string _glifo = string.Empty;
        private string _textoAyuda = string.Empty;
        private Font _fuenteIcono = new Font("Segoe MDL2 Assets", 11f);
        private Color _colorIcono = Color.FromArgb(132, 142, 198);
        private Color _colorRelleno = Color.FromArgb(15, 22, 66);
        private Color _colorBorde = Color.FromArgb(38, 48, 112);
        private Color _colorBordeFoco = Color.FromArgb(129, 140, 248);

        public CampoTexto()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            ForeColor = Color.White;
            Font = new Font("Segoe UI", 10.5f);
            Size = new Size(300, 48);

            _txt.BorderStyle = BorderStyle.None;
            _txt.BackColor = _colorRelleno;
            _txt.ForeColor = ForeColor;
            _txt.Font = Font;
            Controls.Add(_txt);

            _txt.TextChanged += delegate { OnTextChanged(EventArgs.Empty); };
            _txt.KeyDown += delegate(object s, KeyEventArgs ev) { OnKeyDown(ev); };
            _txt.GotFocus += delegate { _enfocado = true; Invalidate(); };
            _txt.LostFocus += delegate { _enfocado = false; Invalidate(); };
            _txt.HandleCreated += delegate { AplicarTextoAyuda(); };
            Acomodar();
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
         Category("CAPAZ"), Description("Texto del campo.")]
        public override string Text
        {
            get { return _txt.Text; }
            set { _txt.Text = value; }
        }

        [Category("CAPAZ"), Description("Texto gris que se muestra cuando el campo está vacío.")]
        public string TextoAyuda
        {
            get { return _textoAyuda; }
            set { _textoAyuda = value ?? string.Empty; AplicarTextoAyuda(); }
        }

        [Category("CAPAZ"), Description("Código hexadecimal del icono (Segoe MDL2 Assets). Vacío = sin icono.")]
        public string CodigoIcono
        {
            get { return _codigoIcono; }
            set { _codigoIcono = value ?? string.Empty; _glifo = GraficosUi.GlifoDesdeCodigo(_codigoIcono); Acomodar(); Invalidate(); }
        }

        [Category("CAPAZ"), Description("Muestra el ojo para ver u ocultar el texto (para contraseñas).")]
        public bool BotonVer
        {
            get { return _botonVer; }
            set { _botonVer = value; Acomodar(); Invalidate(); }
        }

        [Category("CAPAZ")] public Font FuenteIcono { get { return _fuenteIcono; } set { _fuenteIcono = value ?? _fuenteIcono; Acomodar(); Invalidate(); } }
        [Category("CAPAZ")] public Color ColorIcono { get { return _colorIcono; } set { _colorIcono = value; Invalidate(); } }
        [Category("CAPAZ")] public int RadioEsquinas { get { return _radio; } set { _radio = Math.Max(0, value); Invalidate(); } }
        [Category("CAPAZ")] public int MargenDerecho { get { return _margenDerecho; } set { _margenDerecho = Math.Max(0, value); Acomodar(); } }
        [Category("CAPAZ")] public Color ColorBorde { get { return _colorBorde; } set { _colorBorde = value; Invalidate(); } }
        [Category("CAPAZ")] public Color ColorBordeFoco { get { return _colorBordeFoco; } set { _colorBordeFoco = value; Invalidate(); } }

        [Category("CAPAZ")]
        public Color ColorRelleno
        {
            get { return _colorRelleno; }
            set { _colorRelleno = value; _txt.BackColor = value; Invalidate(); }
        }

        [Category("CAPAZ")] public int MaxLength { get { return _txt.MaxLength; } set { _txt.MaxLength = value; } }

        [Category("CAPAZ")]
        public bool OcultarTexto
        {
            get { return _txt.UseSystemPasswordChar; }
            set { _txt.UseSystemPasswordChar = value; Invalidate(); }
        }

        public void SeleccionarTodo() { _txt.SelectAll(); }

        public new bool Focus() { return _txt.Focus(); }

        private Rectangle AreaOjo
        {
            get { return new Rectangle(Width - 44, 0, 40, Height); }
        }

        protected override void OnClick(EventArgs e) { _txt.Focus(); base.OnClick(e); }
        protected override void OnResize(EventArgs e) { base.OnResize(e); Acomodar(); }
        protected override void OnFontChanged(EventArgs e) { base.OnFontChanged(e); _txt.Font = Font; Acomodar(); }
        protected override void OnForeColorChanged(EventArgs e) { base.OnForeColorChanged(e); _txt.ForeColor = ForeColor; }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            bool encima = _botonVer && AreaOjo.Contains(e.Location);
            if (encima != _encimaOjo)
            {
                _encimaOjo = encima;
                Cursor = encima ? Cursors.Hand : Cursors.Default;
                Invalidate();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (_encimaOjo) { _encimaOjo = false; Cursor = Cursors.Default; Invalidate(); }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (_botonVer && AreaOjo.Contains(e.Location))
            {
                OcultarTexto = !OcultarTexto;
            }
            _txt.Focus();
        }

        private void AplicarTextoAyuda()
        {
            if (_txt.IsHandleCreated)
            {
                SendMessage(_txt.Handle, EM_SETCUEBANNER, (IntPtr)1, _textoAyuda);
            }
        }

        private void Acomodar()
        {
            if (_txt == null) { return; }
            int izquierda = 16;
            if (_glifo.Length > 0)
            {
                Size ti = TextRenderer.MeasureText(_glifo, _fuenteIcono, new Size(int.MaxValue, int.MaxValue),
                    TextFormatFlags.NoPadding);
                izquierda += ti.Width + 12;
            }
            int derecha = _margenDerecho + (_botonVer ? 40 : 0);
            int alto = _txt.PreferredHeight;
            _txt.Location = new Point(izquierda, Math.Max(0, (Height - alto) / 2));
            _txt.Width = Math.Max(10, Width - izquierda - derecha);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            var rect = new RectangleF(0.5f, 0.5f, Width - 2f, Height - 2f);
            using (GraphicsPath path = GraficosUi.RectanguloRedondeado(rect, _radio))
            {
                using (var pincel = new SolidBrush(_colorRelleno)) { g.FillPath(pincel, path); }
                using (var lapiz = new Pen(_enfocado ? _colorBordeFoco : _colorBorde, 1f)) { g.DrawPath(lapiz, path); }
            }

            if (_glifo.Length > 0)
            {
                const TextFormatFlags f = TextFormatFlags.NoPadding | TextFormatFlags.SingleLine;
                Size ti = TextRenderer.MeasureText(g, _glifo, _fuenteIcono, new Size(int.MaxValue, int.MaxValue), f);
                Color c = _enfocado ? _colorBordeFoco : _colorIcono;
                TextRenderer.DrawText(g, _glifo, _fuenteIcono, new Point(16, (Height - ti.Height) / 2), c, f);
            }

            if (_botonVer) { DibujarOjo(g, AreaOjo); }
        }

        /// <summary>Ojo dibujado con líneas (no depende de ninguna fuente). Con barra = el texto está visible.</summary>
        private void DibujarOjo(Graphics g, Rectangle r)
        {
            float cx = r.X + r.Width / 2f;
            float cy = r.Y + r.Height / 2f;
            Color c = _encimaOjo ? Color.White : _colorIcono;
            using (var lapiz = new Pen(c, 1.5f))
            using (var ruta = new GraphicsPath())
            {
                lapiz.StartCap = LineCap.Round;
                lapiz.EndCap = LineCap.Round;
                ruta.AddBezier(cx - 9f, cy, cx - 4f, cy - 7f, cx + 4f, cy - 7f, cx + 9f, cy);
                ruta.AddBezier(cx + 9f, cy, cx + 4f, cy + 7f, cx - 4f, cy + 7f, cx - 9f, cy);
                g.DrawPath(lapiz, ruta);
                g.DrawEllipse(lapiz, cx - 2.6f, cy - 2.6f, 5.2f, 5.2f);
                if (!OcultarTexto)
                {
                    g.DrawLine(lapiz, cx - 8f, cy + 8f, cx + 8f, cy - 8f);
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) { _fuenteIcono.Dispose(); }
            base.Dispose(disposing);
        }
    }
}
