using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Entidad;

namespace CAPAZ.Presentacion
{
    /// <summary>
    /// Pantalla de inicio de sesión de Publicidad Multisucursal.
    /// Devuelve DialogResult.OK cuando las credenciales son correctas; el usuario queda en
    /// UsuarioAutenticado. Las credenciales se validan en ServicioLogin.
    /// </summary>
    public partial class FrmLogin : Form
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        private const int CS_DROPSHADOW = 0x20000;

        [DllImport("user32.dll")] private static extern bool ReleaseCapture();
        [DllImport("user32.dll")] private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        private static readonly string ArchivoRecuerdo =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PublicidadMultisucursal", "login.txt");

        private int _pasoSacudida;
        private Point _posicionOriginal;
        private static readonly int[] Sacudida = { -14, 14, -10, 10, -6, 6, -3, 3, 0 };

        public Usuario UsuarioAutenticado { get; private set; }

        public FrmLogin()
        {
            InitializeComponent();
            CargarRecuerdo();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Opacity = 0;
            tmrFade.Start();
            if (txtUsuario.Text.Length > 0) { txtClave.Focus(); } else { txtUsuario.Focus(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var lapiz = new Pen(Color.FromArgb(44, 56, 134)))
            {
                e.Graphics.DrawRectangle(lapiz, 0, 0, Width - 1, Height - 1);
            }
        }

        // ------------------------------------------------------------------ Inicio de sesión

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text;

            if (usuario.Length == 0) { MostrarError("Ingrese su usuario."); txtUsuario.Focus(); return; }
            if (clave.Length == 0) { MostrarError("Ingrese su contraseña."); txtClave.Focus(); return; }

            try
            {
                Usuario autenticado = ServicioLogin.Autenticar(usuario, clave);
                if (autenticado != null)
                {
                    GuardarRecuerdo();
                    UsuarioAutenticado = autenticado;
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }
                txtClave.Text = string.Empty;
                txtClave.Focus();
                Sacudir();
                MostrarError("Usuario o contraseña incorrectos o inactivos.");
            }
            catch (Exception ex)
            {
                MostrarError("No se pudo validar el acceso: " + ex.Message);
            }
        }

        private void MostrarError(string mensaje)
        {
            lblError.Text = mensaje;
        }

        // ------------------------------------------------------------------ Animaciones

        private void tmrFade_Tick(object sender, EventArgs e)
        {
            if (Opacity >= 1.0) { tmrFade.Stop(); return; }
            Opacity = Math.Min(1.0, Opacity + 0.09);
        }

        private void Sacudir()
        {
            if (tmrSacudir.Enabled) { return; }
            _posicionOriginal = Location;
            _pasoSacudida = 0;
            tmrSacudir.Start();
        }

        private void tmrSacudir_Tick(object sender, EventArgs e)
        {
            if (_pasoSacudida >= Sacudida.Length)
            {
                tmrSacudir.Stop();
                Location = _posicionOriginal;
                return;
            }
            Location = new Point(_posicionOriginal.X + Sacudida[_pasoSacudida], _posicionOriginal.Y);
            _pasoSacudida++;
        }

        // ------------------------------------------------------------------ Controles varios

        private void lnkOlvido_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Para recuperar su acceso comuníquese con el administrador del sistema.",
                "Publicidad Multisucursal", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        /// <summary>Permite mover la ventana arrastrando los paneles (la ventana no tiene barra de título).</summary>
        private void Arrastrar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) { return; }
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        // ------------------------------------------------------------------ Recordar usuario

        private void CargarRecuerdo()
        {
            try
            {
                if (!File.Exists(ArchivoRecuerdo)) { return; }
                string[] lineas = File.ReadAllLines(ArchivoRecuerdo);
                if (lineas.Length > 0) { txtUsuario.Text = lineas[0]; chkRecordar.Checked = lineas[0].Length > 0; }
            }
            catch (Exception)
            {
                // Si no se puede leer, se ignora: solo es una comodidad.
            }
        }

        private void GuardarRecuerdo()
        {
            try
            {
                if (chkRecordar.Checked)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(ArchivoRecuerdo));
                    File.WriteAllLines(ArchivoRecuerdo, new[] { txtUsuario.Text.Trim() });
                }
                else if (File.Exists(ArchivoRecuerdo))
                {
                    File.Delete(ArchivoRecuerdo);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
