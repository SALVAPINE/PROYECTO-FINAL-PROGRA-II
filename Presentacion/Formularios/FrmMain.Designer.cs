namespace Presentacion
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.csBuscarGlobal = new Presentacion.CampoBusqueda();
            this.lblCampana = new System.Windows.Forms.Label();
            this.pnlAvatar = new Presentacion.RoundedPanel();
            this.lblAvatar = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblChevron = new System.Windows.Forms.Label();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnInicio = new Presentacion.BotonIcono();
            this.btnUsuarios = new Presentacion.BotonIcono();
            this.btnClientes = new Presentacion.BotonIcono();
            this.btnCotizaciones = new Presentacion.BotonIcono();
            this.btnTipoServicio = new Presentacion.BotonIcono();
            this.btnMateriales = new Presentacion.BotonIcono();
            this.btnDisenos = new Presentacion.BotonIcono();
            this.btnDisenadores = new Presentacion.BotonIcono();
            this.btnOrdenesTrabajo = new Presentacion.BotonIcono();
            this.btnFacturaciones = new Presentacion.BotonIcono();
            this.btnSucursales = new Presentacion.BotonIcono();
            this.btnProveedores = new Presentacion.BotonIcono();
            this.btnDetalleFactura = new Presentacion.BotonIcono();
            this.btnInventarios = new Presentacion.BotonIcono();
            this.btnCompras = new Presentacion.BotonIcono();
            this.btnDetalleCompra = new Presentacion.BotonIcono();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.btnConfiguracion = new Presentacion.BotonIcono();
            this.btnCerrarSesion = new Presentacion.BotonIcono();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lblLogoIcono = new System.Windows.Forms.Label();
            this.lblLogo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlAvatar.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlInferior.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            // 
            // FrmMain
            // 
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlSidebar);
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.ClientSize = new System.Drawing.Size(1120, 780);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1000, 720);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CAPAZ - Sistema de Gestión Empresarial";
            // 
            // pnlContenido
            // 
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(920, 720);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.csBuscarGlobal);
            this.pnlTop.Controls.Add(this.lblCampana);
            this.pnlTop.Controls.Add(this.pnlAvatar);
            this.pnlTop.Controls.Add(this.lblUsuario);
            this.pnlTop.Controls.Add(this.lblChevron);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(920, 60);
            // 
            // csBuscarGlobal
            // 
            this.csBuscarGlobal.Location = new System.Drawing.Point(20, 13);
            this.csBuscarGlobal.Name = "csBuscarGlobal";
            this.csBuscarGlobal.Placeholder = "Buscar...";
            this.csBuscarGlobal.Size = new System.Drawing.Size(420, 34);
            this.csBuscarGlobal.EnterPresionado += new System.EventHandler(this.csBuscarGlobal_EnterPresionado);
            // 
            // lblCampana
            // 
            this.lblCampana.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCampana.AutoSize = true;
            this.lblCampana.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCampana.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14F);
            this.lblCampana.ForeColor = System.Drawing.Color.FromArgb(160, 170, 220);
            this.lblCampana.Location = new System.Drawing.Point(700, 16);
            this.lblCampana.Name = "lblCampana";
            this.lblCampana.Text = "\uEA8F";
            this.lblCampana.Click += new System.EventHandler(this.lblCampana_Click);
            // 
            // pnlAvatar
            // 
            this.pnlAvatar.Controls.Add(this.lblAvatar);
            this.pnlAvatar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAvatar.BackColor = System.Drawing.Color.FromArgb(61, 63, 206);
            this.pnlAvatar.ColorBorde = System.Drawing.Color.FromArgb(61, 63, 206);
            this.pnlAvatar.Location = new System.Drawing.Point(748, 13);
            this.pnlAvatar.Name = "pnlAvatar";
            this.pnlAvatar.Radio = 17;
            this.pnlAvatar.Size = new System.Drawing.Size(34, 34);
            // 
            // lblAvatar
            // 
            this.lblAvatar.BackColor = System.Drawing.Color.Transparent;
            this.lblAvatar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAvatar.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F);
            this.lblAvatar.ForeColor = System.Drawing.Color.White;
            this.lblAvatar.Name = "lblAvatar";
            this.lblAvatar.Size = new System.Drawing.Size(34, 34);
            this.lblAvatar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAvatar.Text = "\uE77B";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(788, 20);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Text = "JseSalva";
            // 
            // lblChevron
            // 
            this.lblChevron.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChevron.AutoSize = true;
            this.lblChevron.Font = new System.Drawing.Font("Segoe MDL2 Assets", 8F);
            this.lblChevron.ForeColor = System.Drawing.Color.FromArgb(160, 170, 220);
            this.lblChevron.Location = new System.Drawing.Point(890, 22);
            this.lblChevron.Name = "lblChevron";
            this.lblChevron.Text = "\uE70D";
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.Controls.Add(this.pnlMenu);
            this.pnlSidebar.Controls.Add(this.pnlInferior);
            this.pnlSidebar.Controls.Add(this.pnlLogo);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(17, 22, 66);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(200, 780);
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.btnInicio);
            this.pnlMenu.Controls.Add(this.btnUsuarios);
            this.pnlMenu.Controls.Add(this.btnClientes);
            this.pnlMenu.Controls.Add(this.btnCotizaciones);
            this.pnlMenu.Controls.Add(this.btnTipoServicio);
            this.pnlMenu.Controls.Add(this.btnMateriales);
            this.pnlMenu.Controls.Add(this.btnDisenos);
            this.pnlMenu.Controls.Add(this.btnDisenadores);
            this.pnlMenu.Controls.Add(this.btnOrdenesTrabajo);
            this.pnlMenu.Controls.Add(this.btnFacturaciones);
            this.pnlMenu.Controls.Add(this.btnSucursales);
            this.pnlMenu.Controls.Add(this.btnProveedores);
            this.pnlMenu.Controls.Add(this.btnDetalleFactura);
            this.pnlMenu.Controls.Add(this.btnInventarios);
            this.pnlMenu.Controls.Add(this.btnCompras);
            this.pnlMenu.Controls.Add(this.btnDetalleCompra);
            this.pnlMenu.AutoScroll = true;
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(17, 22, 66);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(200, 580);
            // 
            // btnInicio
            // 
            this.btnInicio.BackColor = System.Drawing.Color.FromArgb(17, 22, 66);
            this.btnInicio.ColorHover = System.Drawing.Color.FromArgb(30, 38, 105);
            this.btnInicio.Glyph = "\uE80F";
            this.btnInicio.Location = new System.Drawing.Point(8, 4);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Radio = 8;
            this.btnInicio.Size = new System.Drawing.Size(168, 32);
            this.btnInicio.Text = "Inicio";
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.BackColor = System.Drawing.Color.FromArgb(17, 22, 66);
            this.btnUsuarios.ColorHover = System.Drawing.Color.FromArgb(30, 38, 105);
            this.btnUsuarios.Glyph = "\uE77B";
            this.btnUsuarios.Location = new System.Drawing.Point(8, 39);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Radio = 8;
            this.btnUsuarios.Size = new System.Drawing.Size(168, 32);
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.FromArgb(17, 22, 66);
            this.btnClientes.ColorHover = System.Drawing.Color.FromArgb(30, 38, 105);
            this.btnClientes.Glyph = "\uE716";
            this.btnClientes.Location = new System.Drawing.Point(8, 74);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Radio = 8;
            this.btnClientes.Size = new System.Drawing.Size(168, 32);
            this.btnClientes.Text = "Clientes";
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnCotizaciones
            // 
            this.btnCotizaciones.BackColor = System.Drawing.Color.FromArgb(17, 22, 66);
            this.btnCotizaciones.ColorHover = System.Drawing.Color.FromArgb(30, 38, 105);
            this.btnCotizaciones.Glyph = "\uE8A5";
            this.btnCotizaciones.Location = new System.Drawing.Point(8, 109);
            this.btnCotizaciones.Name = "btnCotizaciones";
            this.btnCotizaciones.Radio = 8;
            this.btnCotizaciones.Size = new System.Drawing.Size(168, 32);
            this.btnCotizaciones.Text = "Cotizaciones";
            this.btnCotizaciones.Click += new System.EventHandler(this.btnCotizaciones_Click);
            // 
            // btnTipoServicio
            // 
            this.btnTipoServicio.BackColor = System.Drawing.Color.FromArgb(17, 22, 66);
            this.btnTipoServicio.ColorHover = System.Drawing.Color.FromArgb(30, 38, 105);
            this.btnTipoServicio.Glyph = "\uE8FD";
            this.btnTipoServicio.Location = new System.Drawing.Point(8, 144);
            this.btnTipoServicio.Name = "btnTipoServicio";
            this.btnTipoServicio.Radio = 8;
            this.btnTipoServicio.Size = new System.Drawing.Size(168, 32);
            this.btnTipoServicio.Text = "Tipo de Servicio";
            this.btnTipoServicio.Click += new System.EventHandler(this.btnTipoServicio_Click);
            // 
            // btnMateriales
            // 
            this.btnMateriales.BackColor = System.Drawing.Color.FromArgb(17, 22, 66);
            this.btnMateriales.ColorHover = System.Drawing.Color.FromArgb(30, 38, 105);
            this.btnMateriales.Glyph = "\uE7B8";
            this.btnMateriales.Location = new System.Drawing.Point(8, 179);
            this.btnMateriales.Name = "btnMateriales";
            this.btnMateriales.Radio = 8;
            this.btnMateriales.Size = new System.Drawing.Size(168, 32);
            this.btnMateriales.Text = "Materiales";
            this.btnMateriales.Click += new System.EventHandler(this.btnMateriales_Click);
            // 
            // btnDisenos
            // 
            this.btnDisenos.BackColor = System.Drawing.Color.FromArgb(17, 22, 66);
            this.btnDisenos.ColorHover = System.Drawing.Color.FromArgb(30, 38, 105);
            this.btnDisenos.Glyph = "\uE91B";
            this.btnDisenos.Location = new System.Drawing.Point(8, 214);
            this.btnDisenos.Name = "btnDisenos";
            this.btnDisenos.Radio = 8;
            this.btnDisenos.Size = new System.Drawing.Size(168, 32);
            this.btnDisenos.Text = "Diseños";
            this.btnDisenos.Click += new System.EventHandler(this.btnDisenos_Click);
            // 
            // btnDisenadores
            // 
            this.btnDisenadores.BackColor = System.Drawing.Color.FromArgb(17, 22, 66);
            this.btnDisenadores.ColorHover = System.Drawing.Color.FromArgb(30, 38, 105);
            this.btnDisenadores.Glyph = "\uE70F";
            this.btnDisenadores.Location = new System.Drawing.Point(8, 249);
            this.btnDisenadores.Name = "btnDisenadores";
            this.btnDisenadores.Radio = 8;
            this.btnDisenadores.Size = new System.Drawing.Size(168, 32);
            this.btnDisenadores.Text = "Diseñadores";
            this.btnDisenadores.Click += new System.EventHandler(this.btnDisenadores_Click);
            // 
            // btnOrdenesTrabajo
            // 
            this.btnOrdenesTrabajo.BackColor = System.Drawing.Color.FromArgb(17, 22, 66);
            this.btnOrdenesTrabajo.ColorHover = System.Drawing.Color.FromArgb(30, 38, 105);
            this.btnOrdenesTrabajo.Glyph = "\uE7C3";
            this.btnOrdenesTrabajo.Location = new System.Drawing.Point(8, 284);
            this.btnOrdenesTrabajo.Name = "btnOrdenesTrabajo";
            this.btnOrdenesTrabajo.Radio = 8;
            this.btnOrdenesTrabajo.Size = new System.Drawing.Size(168, 32);
            this.btnOrdenesTrabajo.Text = "Órdenes de Trabajo";
            this.btnOrdenesTrabajo.Click += new System.EventHandler(this.btnOrdenesTrabajo_Click);
            // 
            // btnFacturaciones
            // 
            this.btnFacturaciones.BackColor = System.Drawing.Color.FromArgb(17, 22, 66);
            this.btnFacturaciones.ColorHover = System.Drawing.Color.FromArgb(30, 38, 105);
            this.btnFacturaciones.Glyph = "\uE8EF";
            this.btnFacturaciones.Location = new System.Drawing.Point(8, 319);
            this.btnFacturaciones.Name = "btnFacturaciones";
            this.btnFacturaciones.Radio = 8;
            this.btnFacturaciones.Size = new System.Drawing.Size(168, 32);
            this.btnFacturaciones.Text = "Facturaciones";
            this.btnFacturaciones.Click += new System.EventHandler(this.btnFacturaciones_Click);
            // 
            // btnSucursales
            // 
            this.btnSucursales.BackColor = System.Drawing.Color.FromArgb(17, 22, 66);
            this.btnSucursales.ColorHover = System.Drawing.Color.FromArgb(30, 38, 105);
            this.btnSucursales.Glyph = "\uE81D";
            this.btnSucursales.Location = new System.Drawing.Point(8, 354);
            this.btnSucursales.Name = "btnSucursales";
            this.btnSucursales.Radio = 8;
            this.btnSucursales.Size = new System.Drawing.Size(168, 32);
            this.btnSucursales.Text = "Sucursales";
            this.btnSucursales.Click += new System.EventHandler(this.btnSucursales_Click);
            // 
            // btnProveedores
            // 
            this.btnProveedores.BackColor = System.Drawing.Color.FromArgb(17, 22, 66);
            this.btnProveedores.ColorHover = System.Drawing.Color.FromArgb(30, 38, 105);
            this.btnProveedores.Glyph = "\uE719";
            this.btnProveedores.Location = new System.Drawing.Point(8, 389);
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Radio = 8;
            this.btnProveedores.Size = new System.Drawing.Size(168, 32);
            this.btnProveedores.Text = "Proveedores";
            this.btnProveedores.Click += new System.EventHandler(this.btnProveedores_Click);
            // 
            // btnDetalleFactura
            // 
            this.btnDetalleFactura.BackColor = System.Drawing.Color.FromArgb(17, 22, 66);
            this.btnDetalleFactura.ColorHover = System.Drawing.Color.FromArgb(30, 38, 105);
            this.btnDetalleFactura.Glyph = "\uE8C8";
            this.btnDetalleFactura.Location = new System.Drawing.Point(8, 424);
            this.btnDetalleFactura.Name = "btnDetalleFactura";
            this.btnDetalleFactura.Radio = 8;
            this.btnDetalleFactura.Size = new System.Drawing.Size(168, 32);
            this.btnDetalleFactura.Text = "Detalle de Factura";
            this.btnDetalleFactura.Click += new System.EventHandler(this.btnDetalleFactura_Click);
            // 
            // btnInventarios
            // 
            this.btnInventarios.BackColor = System.Drawing.Color.FromArgb(17, 22, 66);
            this.btnInventarios.ColorHover = System.Drawing.Color.FromArgb(30, 38, 105);
            this.btnInventarios.Glyph = "\uE8B7";
            this.btnInventarios.Location = new System.Drawing.Point(8, 459);
            this.btnInventarios.Name = "btnInventarios";
            this.btnInventarios.Radio = 8;
            this.btnInventarios.Size = new System.Drawing.Size(168, 32);
            this.btnInventarios.Text = "Inventarios";
            this.btnInventarios.Click += new System.EventHandler(this.btnInventarios_Click);
            // 
            // btnCompras
            // 
            this.btnCompras.BackColor = System.Drawing.Color.FromArgb(17, 22, 66);
            this.btnCompras.ColorHover = System.Drawing.Color.FromArgb(30, 38, 105);
            this.btnCompras.Glyph = "\uE7BF";
            this.btnCompras.Location = new System.Drawing.Point(8, 494);
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.Radio = 8;
            this.btnCompras.Size = new System.Drawing.Size(168, 32);
            this.btnCompras.Text = "Compras";
            this.btnCompras.Click += new System.EventHandler(this.btnCompras_Click);
            // 
            // btnDetalleCompra
            // 
            this.btnDetalleCompra.BackColor = System.Drawing.Color.FromArgb(17, 22, 66);
            this.btnDetalleCompra.ColorHover = System.Drawing.Color.FromArgb(30, 38, 105);
            this.btnDetalleCompra.Glyph = "\uE8C8";
            this.btnDetalleCompra.Location = new System.Drawing.Point(8, 529);
            this.btnDetalleCompra.Name = "btnDetalleCompra";
            this.btnDetalleCompra.Radio = 8;
            this.btnDetalleCompra.Size = new System.Drawing.Size(168, 32);
            this.btnDetalleCompra.Text = "Detalle de Compra";
            this.btnDetalleCompra.Click += new System.EventHandler(this.btnDetalleCompra_Click);
            // 
            // pnlInferior
            // 
            this.pnlInferior.Controls.Add(this.btnConfiguracion);
            this.pnlInferior.Controls.Add(this.btnCerrarSesion);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInferior.BackColor = System.Drawing.Color.FromArgb(17, 22, 66);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Size = new System.Drawing.Size(200, 100);
            // 
            // btnConfiguracion
            // 
            this.btnConfiguracion.BackColor = System.Drawing.Color.FromArgb(17, 22, 66);
            this.btnConfiguracion.ColorHover = System.Drawing.Color.FromArgb(30, 38, 105);
            this.btnConfiguracion.Glyph = "\uE713";
            this.btnConfiguracion.Location = new System.Drawing.Point(12, 8);
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.Radio = 8;
            this.btnConfiguracion.Size = new System.Drawing.Size(176, 38);
            this.btnConfiguracion.Text = "Configuración";
            this.btnConfiguracion.Click += new System.EventHandler(this.btnConfiguracion_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(17, 22, 66);
            this.btnCerrarSesion.ColorHover = System.Drawing.Color.FromArgb(30, 38, 105);
            this.btnCerrarSesion.Glyph = "\uE7E8";
            this.btnCerrarSesion.Location = new System.Drawing.Point(12, 52);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Radio = 8;
            this.btnCerrarSesion.Size = new System.Drawing.Size(176, 38);
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // pnlLogo
            // 
            this.pnlLogo.Controls.Add(this.lblLogoIcono);
            this.pnlLogo.Controls.Add(this.lblLogo);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(17, 22, 66);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(200, 100);
            // 
            // lblLogoIcono
            // 
            this.lblLogoIcono.AutoSize = true;
            this.lblLogoIcono.Font = new System.Drawing.Font("Segoe MDL2 Assets", 26F);
            this.lblLogoIcono.ForeColor = System.Drawing.Color.FromArgb(40, 150, 235);
            this.lblLogoIcono.Location = new System.Drawing.Point(10, 22);
            this.lblLogoIcono.Name = "lblLogoIcono";
            this.lblLogoIcono.Text = "\uE7B8";
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(58, 20);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Text = "PUBLICIDAD\r\nCREATIVA";
            this.pnlLogo.ResumeLayout(false);
            this.pnlInferior.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlAvatar.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.Panel pnlTop;
        private Presentacion.CampoBusqueda csBuscarGlobal;
        private System.Windows.Forms.Label lblCampana;
        private Presentacion.RoundedPanel pnlAvatar;
        private System.Windows.Forms.Label lblAvatar;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblChevron;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlMenu;
        private Presentacion.BotonIcono btnInicio;
        private Presentacion.BotonIcono btnUsuarios;
        private Presentacion.BotonIcono btnClientes;
        private Presentacion.BotonIcono btnCotizaciones;
        private Presentacion.BotonIcono btnTipoServicio;
        private Presentacion.BotonIcono btnMateriales;
        private Presentacion.BotonIcono btnDisenos;
        private Presentacion.BotonIcono btnDisenadores;
        private Presentacion.BotonIcono btnOrdenesTrabajo;
        private Presentacion.BotonIcono btnFacturaciones;
        private Presentacion.BotonIcono btnSucursales;
        private Presentacion.BotonIcono btnProveedores;
        private Presentacion.BotonIcono btnDetalleFactura;
        private Presentacion.BotonIcono btnInventarios;
        private Presentacion.BotonIcono btnCompras;
        private Presentacion.BotonIcono btnDetalleCompra;
        private System.Windows.Forms.Panel pnlInferior;
        private Presentacion.BotonIcono btnConfiguracion;
        private Presentacion.BotonIcono btnCerrarSesion;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblLogoIcono;
        private System.Windows.Forms.Label lblLogo;
    }
}
