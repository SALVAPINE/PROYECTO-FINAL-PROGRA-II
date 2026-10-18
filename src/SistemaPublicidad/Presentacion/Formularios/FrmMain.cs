using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidad;

namespace Presentacion
{
    public partial class FrmMain : Form
    {
        private FrmInicio frmInicio;
        private FrmUsuarios frmUsuarios;
        private FrmClientes frmClientes;
        private FrmCotizaciones frmCotizaciones;
        private FrmTipoServicio frmTipoServicio;
        private FrmMateriales frmMateriales;
        private FrmDisenos frmDisenos;
        private FrmDisenadores frmDisenadores;
        private FrmOrdenesTrabajo frmOrdenesTrabajo;
        private FrmFacturaciones frmFacturaciones;
        private FrmSucursales frmSucursales;
        private FrmProveedores frmProveedores;
        private FrmInventarios frmInventarios;
        private FrmCompras frmCompras;

        public FrmMain() : this(null) { }

        public FrmMain(Usuario usuario)
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            frmInicio = new FrmInicio();
            frmUsuarios = new FrmUsuarios();
            frmClientes = new FrmClientes();
            frmCotizaciones = new FrmCotizaciones();
            frmTipoServicio = new FrmTipoServicio();
            frmMateriales = new FrmMateriales();
            frmDisenos = new FrmDisenos();
            frmDisenadores = new FrmDisenadores();
            frmOrdenesTrabajo = new FrmOrdenesTrabajo();
            frmFacturaciones = new FrmFacturaciones();
            frmSucursales = new FrmSucursales();
            frmProveedores = new FrmProveedores();
            frmInventarios = new FrmInventarios();
            frmCompras = new FrmCompras();

            Incrustar(frmInicio);
            Incrustar(frmUsuarios);
            Incrustar(frmClientes);
            Incrustar(frmCotizaciones);
            Incrustar(frmTipoServicio);
            Incrustar(frmMateriales);
            Incrustar(frmDisenos);
            Incrustar(frmDisenadores);
            Incrustar(frmOrdenesTrabajo);
            Incrustar(frmFacturaciones);
            Incrustar(frmSucursales);
            Incrustar(frmProveedores);
            Incrustar(frmInventarios);
            Incrustar(frmCompras);

            Mostrar(frmInicio, btnInicio);
            if (usuario != null) AplicarPerfil(usuario);
        }

        private void AplicarPerfil(Usuario usuario)
        {
            lblUsuario.Text = usuario.NombreUsuario;
            lblRol.Text = usuario.TipoUsuario;
            bool admin = usuario.TipoUsuario == "Administrador";
            string[] permitidos = admin
                ? new string[] { "btnInicio", "btnUsuarios", "btnClientes", "btnCotizaciones", "btnTipoServicio", "btnMateriales", "btnDisenos", "btnDisenadores", "btnOrdenesTrabajo", "btnFacturaciones", "btnSucursales", "btnProveedores", "btnInventarios", "btnCompras" }
                : usuario.TipoUsuario == "Diseñador"
                    ? new string[] { "btnInicio", "btnClientes", "btnCotizaciones", "btnMateriales", "btnDisenos", "btnDisenadores", "btnOrdenesTrabajo", "btnSucursales" }
                    : new string[] { "btnInicio", "btnClientes", "btnCotizaciones", "btnTipoServicio", "btnMateriales", "btnDisenos", "btnOrdenesTrabajo", "btnFacturaciones", "btnInventarios", "btnCompras" };
            BotonIcono[] botones = { btnInicio, btnUsuarios, btnClientes, btnCotizaciones, btnTipoServicio, btnMateriales, btnDisenos, btnDisenadores, btnOrdenesTrabajo, btnFacturaciones, btnSucursales, btnProveedores, btnInventarios, btnCompras };
            int y = 127;
            foreach (BotonIcono boton in botones)
            {
                boton.Visible = Array.IndexOf(permitidos, boton.Name) >= 0;
                if (boton.Visible) { boton.Location = new Point(boton.Left, y); y += 37; }
            }
            btnConfiguracion.Visible = admin;
        }

        /// <summary>Muestra un formulario dentro del panel de contenido (como una pantalla más de la ventana principal).</summary>
        private void Incrustar(Form formulario)
        {
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            pnlContenido.Controls.Add(formulario);
            formulario.Show();
        }

        private void Mostrar(Form vista, BotonIcono boton)
        {
            foreach (Control c in pnlContenido.Controls)
                c.Visible = (c == vista);
            foreach (BotonIcono b in new[] { btnInicio, btnUsuarios, btnClientes, btnCotizaciones, btnTipoServicio, btnMateriales, btnDisenos, btnDisenadores, btnOrdenesTrabajo, btnFacturaciones, btnSucursales, btnProveedores, btnInventarios, btnCompras })
                b.Seleccionado = (b == boton);

            vista.BringToFront();

            // El dashboard se recalcula cada vez que se vuelve a Inicio.
            if (vista == frmInicio)
                frmInicio.ActualizarDashboard();
        }

        // ---------- Menú lateral ----------
        private void btnInicio_Click(object sender, EventArgs e) { Mostrar(frmInicio, btnInicio); }
        private void btnUsuarios_Click(object sender, EventArgs e) { Mostrar(frmUsuarios, btnUsuarios); }
        private void btnClientes_Click(object sender, EventArgs e) { Mostrar(frmClientes, btnClientes); }
        private void btnCotizaciones_Click(object sender, EventArgs e) { Mostrar(frmCotizaciones, btnCotizaciones); }
        private void btnTipoServicio_Click(object sender, EventArgs e) { Mostrar(frmTipoServicio, btnTipoServicio); }
        private void btnMateriales_Click(object sender, EventArgs e) { Mostrar(frmMateriales, btnMateriales); }
        private void btnDisenos_Click(object sender, EventArgs e) { Mostrar(frmDisenos, btnDisenos); }
        private void btnDisenadores_Click(object sender, EventArgs e) { Mostrar(frmDisenadores, btnDisenadores); }
        private void btnOrdenesTrabajo_Click(object sender, EventArgs e) { Mostrar(frmOrdenesTrabajo, btnOrdenesTrabajo); }
        private void btnFacturaciones_Click(object sender, EventArgs e) { Mostrar(frmFacturaciones, btnFacturaciones); }
        private void btnSucursales_Click(object sender, EventArgs e) { Mostrar(frmSucursales, btnSucursales); }
        private void btnProveedores_Click(object sender, EventArgs e) { Mostrar(frmProveedores, btnProveedores); }
        private void btnInventarios_Click(object sender, EventArgs e) { Mostrar(frmInventarios, btnInventarios); }
        private void btnCompras_Click(object sender, EventArgs e) { Mostrar(frmCompras, btnCompras); }

        // ---------- Pendientes de implementar ----------
        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void lblCampana_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void csBuscarGlobal_EnterPresionado(object sender, EventArgs e)
        {
            // TODO
        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {

        }
    }

    public sealed class FrmMenuDisenador : FrmMain
    {
        public FrmMenuDisenador(Usuario usuario) : base(usuario) { }
    }

    public sealed class FrmMenuOperador : FrmMain
    {
        public FrmMenuOperador(Usuario usuario) : base(usuario) { }
    }
}
