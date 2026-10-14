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
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblFooterIzq = new System.Windows.Forms.Label();
            this.lblFooterDer = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.csBuscarGlobal = new Presentacion.CampoBusqueda();
            this.pnlNotificacion = new Presentacion.RoundedPanel();
            this.lblCampana = new System.Windows.Forms.Label();
            this.pnlAvatar = new Presentacion.RoundedPanel();
            this.lblAvatar = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.lblChevron = new System.Windows.Forms.Label();
            this.pnlTopLinea = new System.Windows.Forms.Panel();
            this.pnlSidebar = new Presentacion.PanelDegradado();
            this.logoMarca = new Presentacion.LogoMarca();
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
            this.btnInventarios = new Presentacion.BotonIcono();
            this.btnCompras = new Presentacion.BotonIcono();
            this.pnlSeparador = new System.Windows.Forms.Panel();
            this.btnConfiguracion = new Presentacion.BotonIcono();
            this.btnCerrarSesion = new Presentacion.BotonIcono();
            this.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlAvatar.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            // 
            // FrmMain
            // 
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlFooter);
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
            this.Text = "Publicidad Multisucursal";
            // 
            // pnlContenido
            // 
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(920, 686);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.lblFooterIzq);
            this.pnlFooter.Controls.Add(this.lblFooterDer);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(0, 0, 24, 0);
            this.pnlFooter.Size = new System.Drawing.Size(920, 34);
            // 
            // lblFooterIzq
            // 
            this.lblFooterIzq.AutoSize = true;
            this.lblFooterIzq.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFooterIzq.ForeColor = System.Drawing.Color.FromArgb(160, 170, 220);
            this.lblFooterIzq.Location = new System.Drawing.Point(20, 10);
            this.lblFooterIzq.Name = "lblFooterIzq";
            this.lblFooterIzq.Text = "Publicidad Multisucursal  |  Creatividad • Estrategia • Resultados";
            // 
            // lblFooterDer
            // 
            this.lblFooterDer.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblFooterDer.AutoSize = true;
            this.lblFooterDer.Font = new System.Drawing.Font("Segoe Script", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic))));
            this.lblFooterDer.ForeColor = System.Drawing.Color.FromArgb(236, 72, 153);
            this.lblFooterDer.Name = "lblFooterDer";
            this.lblFooterDer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblFooterDer.Text = "Tu idea, nuestra inspiración";
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.csBuscarGlobal);
            this.pnlTop.Controls.Add(this.pnlNotificacion);
            this.pnlTop.Controls.Add(this.lblCampana);
            this.pnlTop.Controls.Add(this.pnlAvatar);
            this.pnlTop.Controls.Add(this.lblUsuario);
            this.pnlTop.Controls.Add(this.lblRol);
            this.pnlTop.Controls.Add(this.lblChevron);
            this.pnlTop.Controls.Add(this.pnlTopLinea);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(12, 16, 48);
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
            // pnlNotificacion
            // 
            this.pnlNotificacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNotificacion.BackColor = System.Drawing.Color.FromArgb(244, 63, 94);
            this.pnlNotificacion.ColorBorde = System.Drawing.Color.FromArgb(244, 63, 94);
            this.pnlNotificacion.Location = new System.Drawing.Point(705, 14);
            this.pnlNotificacion.Name = "pnlNotificacion";
            this.pnlNotificacion.Radio = 4;
            this.pnlNotificacion.Size = new System.Drawing.Size(9, 9);
            // 
            // lblCampana
            // 
            this.lblCampana.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCampana.AutoSize = true;
            this.lblCampana.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCampana.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14F);
            this.lblCampana.ForeColor = System.Drawing.Color.FromArgb(214, 220, 245);
            this.lblCampana.Location = new System.Drawing.Point(690, 17);
            this.lblCampana.Name = "lblCampana";
            this.lblCampana.Text = "\uEA8F";
            this.lblCampana.Click += new System.EventHandler(this.lblCampana_Click);
            // 
            // pnlAvatar
            // 
            this.pnlAvatar.Controls.Add(this.lblAvatar);
            this.pnlAvatar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAvatar.BackColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.pnlAvatar.ColorBorde = System.Drawing.Color.FromArgb(59, 130, 246);
            this.pnlAvatar.Location = new System.Drawing.Point(736, 10);
            this.pnlAvatar.Name = "pnlAvatar";
            this.pnlAvatar.Radio = 20;
            this.pnlAvatar.Size = new System.Drawing.Size(40, 40);
            // 
            // lblAvatar
            // 
            this.lblAvatar.BackColor = System.Drawing.Color.Transparent;
            this.lblAvatar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAvatar.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14F);
            this.lblAvatar.ForeColor = System.Drawing.Color.White;
            this.lblAvatar.Name = "lblAvatar";
            this.lblAvatar.Size = new System.Drawing.Size(40, 40);
            this.lblAvatar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAvatar.Text = "\uE77B";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(786, 11);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Text = "JseSalva";
            // 
            // lblRol
            // 
            this.lblRol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblRol.ForeColor = System.Drawing.Color.FromArgb(160, 170, 220);
            this.lblRol.Location = new System.Drawing.Point(787, 30);
            this.lblRol.Name = "lblRol";
            this.lblRol.Text = "Administrador";
            // 
            // lblChevron
            // 
            this.lblChevron.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChevron.AutoSize = true;
            this.lblChevron.Font = new System.Drawing.Font("Segoe MDL2 Assets", 8F);
            this.lblChevron.ForeColor = System.Drawing.Color.FromArgb(160, 170, 220);
            this.lblChevron.Location = new System.Drawing.Point(892, 24);
            this.lblChevron.Name = "lblChevron";
            this.lblChevron.Text = "\uE70D";
            // 
            // pnlTopLinea
            // 
            this.pnlTopLinea.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTopLinea.BackColor = System.Drawing.Color.FromArgb(30, 36, 90);
            this.pnlTopLinea.Name = "pnlTopLinea";
            this.pnlTopLinea.Size = new System.Drawing.Size(200, 1);
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.Controls.Add(this.logoMarca);
            this.pnlSidebar.Controls.Add(this.btnInicio);
            this.pnlSidebar.Controls.Add(this.btnUsuarios);
            this.pnlSidebar.Controls.Add(this.btnClientes);
            this.pnlSidebar.Controls.Add(this.btnCotizaciones);
            this.pnlSidebar.Controls.Add(this.btnTipoServicio);
            this.pnlSidebar.Controls.Add(this.btnMateriales);
            this.pnlSidebar.Controls.Add(this.btnDisenos);
            this.pnlSidebar.Controls.Add(this.btnDisenadores);
            this.pnlSidebar.Controls.Add(this.btnOrdenesTrabajo);
            this.pnlSidebar.Controls.Add(this.btnFacturaciones);
            this.pnlSidebar.Controls.Add(this.btnSucursales);
            this.pnlSidebar.Controls.Add(this.btnProveedores);
            this.pnlSidebar.Controls.Add(this.btnInventarios);
            this.pnlSidebar.Controls.Add(this.btnCompras);
            this.pnlSidebar.Controls.Add(this.pnlSeparador);
            this.pnlSidebar.Controls.Add(this.btnConfiguracion);
            this.pnlSidebar.Controls.Add(this.btnCerrarSesion);
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(14, 18, 64);
            this.pnlSidebar.ColorFin = System.Drawing.Color.FromArgb(40, 22, 96);
            this.pnlSidebar.ColorInicio = System.Drawing.Color.FromArgb(14, 18, 64);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(200, 780);
            // 
            // logoMarca
            // 
            this.logoMarca.Location = new System.Drawing.Point(14, 18);
            this.logoMarca.Name = "logoMarca";
            this.logoMarca.Size = new System.Drawing.Size(176, 52);
            // 
            // btnInicio
            // 
            this.btnInicio.BackColor = System.Drawing.Color.Transparent;
            this.btnInicio.ColorGlyph = System.Drawing.Color.FromArgb(190, 198, 240);
            this.btnInicio.ColorHover = System.Drawing.Color.FromArgb(38, 44, 112);
            this.btnInicio.ColorSeleccionado = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnInicio.ColorSeleccionadoFin = System.Drawing.Color.FromArgb(124, 58, 237);
            this.btnInicio.Degradado = true;
            this.btnInicio.ForeColor = System.Drawing.Color.FromArgb(214, 220, 245);
            this.btnInicio.Glyph = "\uE80F";
            this.btnInicio.Location = new System.Drawing.Point(12, 90);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Radio = 10;
            this.btnInicio.Size = new System.Drawing.Size(176, 33);
            this.btnInicio.Text = "Inicio";
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.BackColor = System.Drawing.Color.Transparent;
            this.btnUsuarios.ColorGlyph = System.Drawing.Color.FromArgb(190, 198, 240);
            this.btnUsuarios.ColorHover = System.Drawing.Color.FromArgb(38, 44, 112);
            this.btnUsuarios.ColorSeleccionado = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnUsuarios.ColorSeleccionadoFin = System.Drawing.Color.FromArgb(124, 58, 237);
            this.btnUsuarios.Degradado = true;
            this.btnUsuarios.ForeColor = System.Drawing.Color.FromArgb(214, 220, 245);
            this.btnUsuarios.Glyph = "\uE77B";
            this.btnUsuarios.Location = new System.Drawing.Point(12, 127);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Radio = 10;
            this.btnUsuarios.Size = new System.Drawing.Size(176, 33);
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.Transparent;
            this.btnClientes.ColorGlyph = System.Drawing.Color.FromArgb(190, 198, 240);
            this.btnClientes.ColorHover = System.Drawing.Color.FromArgb(38, 44, 112);
            this.btnClientes.ColorSeleccionado = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnClientes.ColorSeleccionadoFin = System.Drawing.Color.FromArgb(124, 58, 237);
            this.btnClientes.Degradado = true;
            this.btnClientes.ForeColor = System.Drawing.Color.FromArgb(214, 220, 245);
            this.btnClientes.Glyph = "\uE716";
            this.btnClientes.Location = new System.Drawing.Point(12, 164);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Radio = 10;
            this.btnClientes.Size = new System.Drawing.Size(176, 33);
            this.btnClientes.Text = "Clientes";
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnCotizaciones
            // 
            this.btnCotizaciones.BackColor = System.Drawing.Color.Transparent;
            this.btnCotizaciones.ColorGlyph = System.Drawing.Color.FromArgb(190, 198, 240);
            this.btnCotizaciones.ColorHover = System.Drawing.Color.FromArgb(38, 44, 112);
            this.btnCotizaciones.ColorSeleccionado = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnCotizaciones.ColorSeleccionadoFin = System.Drawing.Color.FromArgb(124, 58, 237);
            this.btnCotizaciones.Degradado = true;
            this.btnCotizaciones.ForeColor = System.Drawing.Color.FromArgb(214, 220, 245);
            this.btnCotizaciones.Glyph = "\uE8A5";
            this.btnCotizaciones.Location = new System.Drawing.Point(12, 201);
            this.btnCotizaciones.Name = "btnCotizaciones";
            this.btnCotizaciones.Radio = 10;
            this.btnCotizaciones.Size = new System.Drawing.Size(176, 33);
            this.btnCotizaciones.Text = "Cotizaciones";
            this.btnCotizaciones.Click += new System.EventHandler(this.btnCotizaciones_Click);
            // 
            // btnTipoServicio
            // 
            this.btnTipoServicio.BackColor = System.Drawing.Color.Transparent;
            this.btnTipoServicio.ColorGlyph = System.Drawing.Color.FromArgb(190, 198, 240);
            this.btnTipoServicio.ColorHover = System.Drawing.Color.FromArgb(38, 44, 112);
            this.btnTipoServicio.ColorSeleccionado = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnTipoServicio.ColorSeleccionadoFin = System.Drawing.Color.FromArgb(124, 58, 237);
            this.btnTipoServicio.Degradado = true;
            this.btnTipoServicio.ForeColor = System.Drawing.Color.FromArgb(214, 220, 245);
            this.btnTipoServicio.Glyph = "\uE8FD";
            this.btnTipoServicio.Location = new System.Drawing.Point(12, 238);
            this.btnTipoServicio.Name = "btnTipoServicio";
            this.btnTipoServicio.Radio = 10;
            this.btnTipoServicio.Size = new System.Drawing.Size(176, 33);
            this.btnTipoServicio.Text = "Tipo de Servicio";
            this.btnTipoServicio.Click += new System.EventHandler(this.btnTipoServicio_Click);
            // 
            // btnMateriales
            // 
            this.btnMateriales.BackColor = System.Drawing.Color.Transparent;
            this.btnMateriales.ColorGlyph = System.Drawing.Color.FromArgb(190, 198, 240);
            this.btnMateriales.ColorHover = System.Drawing.Color.FromArgb(38, 44, 112);
            this.btnMateriales.ColorSeleccionado = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnMateriales.ColorSeleccionadoFin = System.Drawing.Color.FromArgb(124, 58, 237);
            this.btnMateriales.Degradado = true;
            this.btnMateriales.ForeColor = System.Drawing.Color.FromArgb(214, 220, 245);
            this.btnMateriales.Glyph = "\uE7B8";
            this.btnMateriales.Location = new System.Drawing.Point(12, 275);
            this.btnMateriales.Name = "btnMateriales";
            this.btnMateriales.Radio = 10;
            this.btnMateriales.Size = new System.Drawing.Size(176, 33);
            this.btnMateriales.Text = "Materiales";
            this.btnMateriales.Click += new System.EventHandler(this.btnMateriales_Click);
            // 
            // btnDisenos
            // 
            this.btnDisenos.BackColor = System.Drawing.Color.Transparent;
            this.btnDisenos.ColorGlyph = System.Drawing.Color.FromArgb(190, 198, 240);
            this.btnDisenos.ColorHover = System.Drawing.Color.FromArgb(38, 44, 112);
            this.btnDisenos.ColorSeleccionado = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnDisenos.ColorSeleccionadoFin = System.Drawing.Color.FromArgb(124, 58, 237);
            this.btnDisenos.Degradado = true;
            this.btnDisenos.ForeColor = System.Drawing.Color.FromArgb(214, 220, 245);
            this.btnDisenos.Glyph = "\uE91B";
            this.btnDisenos.Location = new System.Drawing.Point(12, 312);
            this.btnDisenos.Name = "btnDisenos";
            this.btnDisenos.Radio = 10;
            this.btnDisenos.Size = new System.Drawing.Size(176, 33);
            this.btnDisenos.Text = "Diseños";
            this.btnDisenos.Click += new System.EventHandler(this.btnDisenos_Click);
            // 
            // btnDisenadores
            // 
            this.btnDisenadores.BackColor = System.Drawing.Color.Transparent;
            this.btnDisenadores.ColorGlyph = System.Drawing.Color.FromArgb(190, 198, 240);
            this.btnDisenadores.ColorHover = System.Drawing.Color.FromArgb(38, 44, 112);
            this.btnDisenadores.ColorSeleccionado = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnDisenadores.ColorSeleccionadoFin = System.Drawing.Color.FromArgb(124, 58, 237);
            this.btnDisenadores.Degradado = true;
            this.btnDisenadores.ForeColor = System.Drawing.Color.FromArgb(214, 220, 245);
            this.btnDisenadores.Glyph = "\uE70F";
            this.btnDisenadores.Location = new System.Drawing.Point(12, 349);
            this.btnDisenadores.Name = "btnDisenadores";
            this.btnDisenadores.Radio = 10;
            this.btnDisenadores.Size = new System.Drawing.Size(176, 33);
            this.btnDisenadores.Text = "Diseñadores";
            this.btnDisenadores.Click += new System.EventHandler(this.btnDisenadores_Click);
            // 
            // btnOrdenesTrabajo
            // 
            this.btnOrdenesTrabajo.BackColor = System.Drawing.Color.Transparent;
            this.btnOrdenesTrabajo.ColorGlyph = System.Drawing.Color.FromArgb(190, 198, 240);
            this.btnOrdenesTrabajo.ColorHover = System.Drawing.Color.FromArgb(38, 44, 112);
            this.btnOrdenesTrabajo.ColorSeleccionado = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnOrdenesTrabajo.ColorSeleccionadoFin = System.Drawing.Color.FromArgb(124, 58, 237);
            this.btnOrdenesTrabajo.Degradado = true;
            this.btnOrdenesTrabajo.ForeColor = System.Drawing.Color.FromArgb(214, 220, 245);
            this.btnOrdenesTrabajo.Glyph = "\uE7C3";
            this.btnOrdenesTrabajo.Location = new System.Drawing.Point(12, 386);
            this.btnOrdenesTrabajo.Name = "btnOrdenesTrabajo";
            this.btnOrdenesTrabajo.Radio = 10;
            this.btnOrdenesTrabajo.Size = new System.Drawing.Size(176, 33);
            this.btnOrdenesTrabajo.Text = "Órdenes de Trabajo";
            this.btnOrdenesTrabajo.Click += new System.EventHandler(this.btnOrdenesTrabajo_Click);
            // 
            // btnFacturaciones
            // 
            this.btnFacturaciones.BackColor = System.Drawing.Color.Transparent;
            this.btnFacturaciones.ColorGlyph = System.Drawing.Color.FromArgb(190, 198, 240);
            this.btnFacturaciones.ColorHover = System.Drawing.Color.FromArgb(38, 44, 112);
            this.btnFacturaciones.ColorSeleccionado = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnFacturaciones.ColorSeleccionadoFin = System.Drawing.Color.FromArgb(124, 58, 237);
            this.btnFacturaciones.Degradado = true;
            this.btnFacturaciones.ForeColor = System.Drawing.Color.FromArgb(214, 220, 245);
            this.btnFacturaciones.Glyph = "\uE8EF";
            this.btnFacturaciones.Location = new System.Drawing.Point(12, 423);
            this.btnFacturaciones.Name = "btnFacturaciones";
            this.btnFacturaciones.Radio = 10;
            this.btnFacturaciones.Size = new System.Drawing.Size(176, 33);
            this.btnFacturaciones.Text = "Facturaciones";
            this.btnFacturaciones.Click += new System.EventHandler(this.btnFacturaciones_Click);
            // 
            // btnSucursales
            // 
            this.btnSucursales.BackColor = System.Drawing.Color.Transparent;
            this.btnSucursales.ColorGlyph = System.Drawing.Color.FromArgb(190, 198, 240);
            this.btnSucursales.ColorHover = System.Drawing.Color.FromArgb(38, 44, 112);
            this.btnSucursales.ColorSeleccionado = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnSucursales.ColorSeleccionadoFin = System.Drawing.Color.FromArgb(124, 58, 237);
            this.btnSucursales.Degradado = true;
            this.btnSucursales.ForeColor = System.Drawing.Color.FromArgb(214, 220, 245);
            this.btnSucursales.Glyph = "\uE81D";
            this.btnSucursales.Location = new System.Drawing.Point(12, 460);
            this.btnSucursales.Name = "btnSucursales";
            this.btnSucursales.Radio = 10;
            this.btnSucursales.Size = new System.Drawing.Size(176, 33);
            this.btnSucursales.Text = "Sucursales";
            this.btnSucursales.Click += new System.EventHandler(this.btnSucursales_Click);
            // 
            // btnProveedores
            // 
            this.btnProveedores.BackColor = System.Drawing.Color.Transparent;
            this.btnProveedores.ColorGlyph = System.Drawing.Color.FromArgb(190, 198, 240);
            this.btnProveedores.ColorHover = System.Drawing.Color.FromArgb(38, 44, 112);
            this.btnProveedores.ColorSeleccionado = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnProveedores.ColorSeleccionadoFin = System.Drawing.Color.FromArgb(124, 58, 237);
            this.btnProveedores.Degradado = true;
            this.btnProveedores.ForeColor = System.Drawing.Color.FromArgb(214, 220, 245);
            this.btnProveedores.Glyph = "\uE719";
            this.btnProveedores.Location = new System.Drawing.Point(12, 497);
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Radio = 10;
            this.btnProveedores.Size = new System.Drawing.Size(176, 33);
            this.btnProveedores.Text = "Proveedores";
            this.btnProveedores.Click += new System.EventHandler(this.btnProveedores_Click);
            // 
            // btnInventarios
            // 
            this.btnInventarios.BackColor = System.Drawing.Color.Transparent;
            this.btnInventarios.ColorGlyph = System.Drawing.Color.FromArgb(190, 198, 240);
            this.btnInventarios.ColorHover = System.Drawing.Color.FromArgb(38, 44, 112);
            this.btnInventarios.ColorSeleccionado = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnInventarios.ColorSeleccionadoFin = System.Drawing.Color.FromArgb(124, 58, 237);
            this.btnInventarios.Degradado = true;
            this.btnInventarios.ForeColor = System.Drawing.Color.FromArgb(214, 220, 245);
            this.btnInventarios.Glyph = "\uE8B7";
            this.btnInventarios.Location = new System.Drawing.Point(12, 534);
            this.btnInventarios.Name = "btnInventarios";
            this.btnInventarios.Radio = 10;
            this.btnInventarios.Size = new System.Drawing.Size(176, 33);
            this.btnInventarios.Text = "Inventarios";
            this.btnInventarios.Click += new System.EventHandler(this.btnInventarios_Click);
            // 
            // btnCompras
            // 
            this.btnCompras.BackColor = System.Drawing.Color.Transparent;
            this.btnCompras.ColorGlyph = System.Drawing.Color.FromArgb(190, 198, 240);
            this.btnCompras.ColorHover = System.Drawing.Color.FromArgb(38, 44, 112);
            this.btnCompras.ColorSeleccionado = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnCompras.ColorSeleccionadoFin = System.Drawing.Color.FromArgb(124, 58, 237);
            this.btnCompras.Degradado = true;
            this.btnCompras.ForeColor = System.Drawing.Color.FromArgb(214, 220, 245);
            this.btnCompras.Glyph = "\uE7BF";
            this.btnCompras.Location = new System.Drawing.Point(12, 571);
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.Radio = 10;
            this.btnCompras.Size = new System.Drawing.Size(176, 33);
            this.btnCompras.Text = "Compras";
            this.btnCompras.Click += new System.EventHandler(this.btnCompras_Click);
            // 
            // pnlSeparador
            // 
            this.pnlSeparador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlSeparador.BackColor = System.Drawing.Color.FromArgb(58, 64, 130);
            this.pnlSeparador.Location = new System.Drawing.Point(12, 672);
            this.pnlSeparador.Name = "pnlSeparador";
            this.pnlSeparador.Size = new System.Drawing.Size(176, 1);
            // 
            // btnConfiguracion
            // 
            this.btnConfiguracion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfiguracion.BackColor = System.Drawing.Color.Transparent;
            this.btnConfiguracion.ColorGlyph = System.Drawing.Color.FromArgb(190, 198, 240);
            this.btnConfiguracion.ColorHover = System.Drawing.Color.FromArgb(38, 44, 112);
            this.btnConfiguracion.ColorSeleccionado = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnConfiguracion.ColorSeleccionadoFin = System.Drawing.Color.FromArgb(124, 58, 237);
            this.btnConfiguracion.Degradado = true;
            this.btnConfiguracion.ForeColor = System.Drawing.Color.FromArgb(214, 220, 245);
            this.btnConfiguracion.Glyph = "\uE713";
            this.btnConfiguracion.Location = new System.Drawing.Point(12, 686);
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.Radio = 10;
            this.btnConfiguracion.Size = new System.Drawing.Size(176, 33);
            this.btnConfiguracion.Text = "Configuración";
            this.btnConfiguracion.Click += new System.EventHandler(this.btnConfiguracion_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCerrarSesion.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrarSesion.ColorGlyph = System.Drawing.Color.FromArgb(190, 198, 240);
            this.btnCerrarSesion.ColorHover = System.Drawing.Color.FromArgb(38, 44, 112);
            this.btnCerrarSesion.ColorSeleccionado = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnCerrarSesion.ColorSeleccionadoFin = System.Drawing.Color.FromArgb(124, 58, 237);
            this.btnCerrarSesion.Degradado = true;
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.FromArgb(214, 220, 245);
            this.btnCerrarSesion.Glyph = "\uE7E8";
            this.btnCerrarSesion.Location = new System.Drawing.Point(12, 726);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Radio = 10;
            this.btnCerrarSesion.Size = new System.Drawing.Size(176, 33);
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlAvatar.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblFooterIzq;
        private System.Windows.Forms.Label lblFooterDer;
        private System.Windows.Forms.Panel pnlTop;
        private Presentacion.CampoBusqueda csBuscarGlobal;
        private Presentacion.RoundedPanel pnlNotificacion;
        private System.Windows.Forms.Label lblCampana;
        private Presentacion.RoundedPanel pnlAvatar;
        private System.Windows.Forms.Label lblAvatar;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label lblChevron;
        private System.Windows.Forms.Panel pnlTopLinea;
        private Presentacion.PanelDegradado pnlSidebar;
        private Presentacion.LogoMarca logoMarca;
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
        private Presentacion.BotonIcono btnInventarios;
        private Presentacion.BotonIcono btnCompras;
        private System.Windows.Forms.Panel pnlSeparador;
        private Presentacion.BotonIcono btnConfiguracion;
        private Presentacion.BotonIcono btnCerrarSesion;
    }
}
