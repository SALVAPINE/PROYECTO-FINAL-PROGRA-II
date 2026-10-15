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
            this.pnlFooter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlAvatar.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContenido
            // 
            this.pnlContenido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Location = new System.Drawing.Point(200, 60);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(920, 655);
            this.pnlContenido.TabIndex = 0;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.pnlFooter.Controls.Add(this.lblFooterIzq);
            this.pnlFooter.Controls.Add(this.lblFooterDer);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(200, 715);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(0, 0, 24, 0);
            this.pnlFooter.Size = new System.Drawing.Size(920, 34);
            this.pnlFooter.TabIndex = 1;
            // 
            // lblFooterIzq
            // 
            this.lblFooterIzq.AutoSize = true;
            this.lblFooterIzq.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFooterIzq.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblFooterIzq.Location = new System.Drawing.Point(20, 10);
            this.lblFooterIzq.Name = "lblFooterIzq";
            this.lblFooterIzq.Size = new System.Drawing.Size(342, 15);
            this.lblFooterIzq.TabIndex = 0;
            this.lblFooterIzq.Text = "Publicidad Multisucursal  |  Creatividad • Estrategia • Resultados";
            // 
            // lblFooterDer
            // 
            this.lblFooterDer.AutoSize = true;
            this.lblFooterDer.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblFooterDer.Font = new System.Drawing.Font("Segoe Script", 11F, System.Drawing.FontStyle.Italic);
            this.lblFooterDer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(72)))), ((int)(((byte)(153)))));
            this.lblFooterDer.Location = new System.Drawing.Point(651, 0);
            this.lblFooterDer.Name = "lblFooterDer";
            this.lblFooterDer.Size = new System.Drawing.Size(245, 23);
            this.lblFooterDer.TabIndex = 1;
            this.lblFooterDer.Text = "Tu idea, nuestra inspiración";
            this.lblFooterDer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(16)))), ((int)(((byte)(48)))));
            this.pnlTop.Controls.Add(this.csBuscarGlobal);
            this.pnlTop.Controls.Add(this.pnlNotificacion);
            this.pnlTop.Controls.Add(this.lblCampana);
            this.pnlTop.Controls.Add(this.pnlAvatar);
            this.pnlTop.Controls.Add(this.lblUsuario);
            this.pnlTop.Controls.Add(this.lblRol);
            this.pnlTop.Controls.Add(this.lblChevron);
            this.pnlTop.Controls.Add(this.pnlTopLinea);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(200, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(920, 60);
            this.pnlTop.TabIndex = 2;
            // 
            // csBuscarGlobal
            // 
            this.csBuscarGlobal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.csBuscarGlobal.Location = new System.Drawing.Point(20, 13);
            this.csBuscarGlobal.Name = "csBuscarGlobal";
            this.csBuscarGlobal.Radio = 8;
            this.csBuscarGlobal.Size = new System.Drawing.Size(420, 34);
            this.csBuscarGlobal.TabIndex = 0;
            this.csBuscarGlobal.EnterPresionado += new System.EventHandler(this.csBuscarGlobal_EnterPresionado);
            // 
            // pnlNotificacion
            // 
            this.pnlNotificacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNotificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(63)))), ((int)(((byte)(94)))));
            this.pnlNotificacion.ColorBorde = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(63)))), ((int)(((byte)(94)))));
            this.pnlNotificacion.Location = new System.Drawing.Point(705, 14);
            this.pnlNotificacion.Name = "pnlNotificacion";
            this.pnlNotificacion.Radio = 4;
            this.pnlNotificacion.Size = new System.Drawing.Size(9, 9);
            this.pnlNotificacion.TabIndex = 1;
            // 
            // lblCampana
            // 
            this.lblCampana.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCampana.AutoSize = true;
            this.lblCampana.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCampana.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14F);
            this.lblCampana.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(245)))));
            this.lblCampana.Location = new System.Drawing.Point(690, 17);
            this.lblCampana.Name = "lblCampana";
            this.lblCampana.Size = new System.Drawing.Size(28, 19);
            this.lblCampana.TabIndex = 2;
            this.lblCampana.Text = "";
            this.lblCampana.Click += new System.EventHandler(this.lblCampana_Click);
            // 
            // pnlAvatar
            // 
            this.pnlAvatar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAvatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.pnlAvatar.ColorBorde = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.pnlAvatar.Controls.Add(this.lblAvatar);
            this.pnlAvatar.Location = new System.Drawing.Point(736, 10);
            this.pnlAvatar.Name = "pnlAvatar";
            this.pnlAvatar.Radio = 20;
            this.pnlAvatar.Size = new System.Drawing.Size(40, 40);
            this.pnlAvatar.TabIndex = 3;
            // 
            // lblAvatar
            // 
            this.lblAvatar.BackColor = System.Drawing.Color.Transparent;
            this.lblAvatar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAvatar.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14F);
            this.lblAvatar.ForeColor = System.Drawing.Color.White;
            this.lblAvatar.Location = new System.Drawing.Point(0, 0);
            this.lblAvatar.Name = "lblAvatar";
            this.lblAvatar.Size = new System.Drawing.Size(40, 40);
            this.lblAvatar.TabIndex = 0;
            this.lblAvatar.Text = "";
            this.lblAvatar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(786, 11);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(55, 17);
            this.lblUsuario.TabIndex = 4;
            this.lblUsuario.Text = "Usuario";
            this.lblUsuario.Click += new System.EventHandler(this.lblUsuario_Click);
            // 
            // lblRol
            // 
            this.lblRol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblRol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblRol.Location = new System.Drawing.Point(787, 30);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(83, 15);
            this.lblRol.TabIndex = 5;
            this.lblRol.Text = "Administrador";
            // 
            // lblChevron
            // 
            this.lblChevron.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChevron.AutoSize = true;
            this.lblChevron.Font = new System.Drawing.Font("Segoe MDL2 Assets", 8F);
            this.lblChevron.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblChevron.Location = new System.Drawing.Point(892, 24);
            this.lblChevron.Name = "lblChevron";
            this.lblChevron.Size = new System.Drawing.Size(16, 11);
            this.lblChevron.TabIndex = 6;
            this.lblChevron.Text = "";
            // 
            // pnlTopLinea
            // 
            this.pnlTopLinea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(90)))));
            this.pnlTopLinea.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTopLinea.Location = new System.Drawing.Point(0, 59);
            this.pnlTopLinea.Name = "pnlTopLinea";
            this.pnlTopLinea.Size = new System.Drawing.Size(920, 1);
            this.pnlTopLinea.TabIndex = 7;
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(64)))));
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
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(200, 749);
            this.pnlSidebar.TabIndex = 3;
            // 
            // logoMarca
            // 
            this.logoMarca.BackColor = System.Drawing.Color.Transparent;
            this.logoMarca.Location = new System.Drawing.Point(14, 18);
            this.logoMarca.Name = "logoMarca";
            this.logoMarca.Size = new System.Drawing.Size(176, 52);
            this.logoMarca.TabIndex = 0;
            // 
            // btnInicio
            // 
            this.btnInicio.BackColor = System.Drawing.Color.Transparent;
            this.btnInicio.ColorGlyph = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(198)))), ((int)(((byte)(240)))));
            this.btnInicio.ColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(112)))));
            this.btnInicio.ColorSeleccionado = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInicio.Degradado = true;
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnInicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(245)))));
            this.btnInicio.Glyph = "";
            this.btnInicio.Location = new System.Drawing.Point(12, 90);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Radio = 10;
            this.btnInicio.Size = new System.Drawing.Size(176, 33);
            this.btnInicio.TabIndex = 1;
            this.btnInicio.Text = "Inicio";
            this.btnInicio.UseVisualStyleBackColor = false;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.BackColor = System.Drawing.Color.Transparent;
            this.btnUsuarios.ColorGlyph = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(198)))), ((int)(((byte)(240)))));
            this.btnUsuarios.ColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(112)))));
            this.btnUsuarios.ColorSeleccionado = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsuarios.Degradado = true;
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnUsuarios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(245)))));
            this.btnUsuarios.Glyph = "";
            this.btnUsuarios.Location = new System.Drawing.Point(12, 127);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Radio = 10;
            this.btnUsuarios.Size = new System.Drawing.Size(176, 33);
            this.btnUsuarios.TabIndex = 2;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = false;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.Transparent;
            this.btnClientes.ColorGlyph = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(198)))), ((int)(((byte)(240)))));
            this.btnClientes.ColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(112)))));
            this.btnClientes.ColorSeleccionado = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClientes.Degradado = true;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(245)))));
            this.btnClientes.Glyph = "";
            this.btnClientes.Location = new System.Drawing.Point(12, 164);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Radio = 10;
            this.btnClientes.Size = new System.Drawing.Size(176, 33);
            this.btnClientes.TabIndex = 3;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnCotizaciones
            // 
            this.btnCotizaciones.BackColor = System.Drawing.Color.Transparent;
            this.btnCotizaciones.ColorGlyph = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(198)))), ((int)(((byte)(240)))));
            this.btnCotizaciones.ColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(112)))));
            this.btnCotizaciones.ColorSeleccionado = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnCotizaciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCotizaciones.Degradado = true;
            this.btnCotizaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCotizaciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCotizaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(245)))));
            this.btnCotizaciones.Glyph = "";
            this.btnCotizaciones.Location = new System.Drawing.Point(12, 201);
            this.btnCotizaciones.Name = "btnCotizaciones";
            this.btnCotizaciones.Radio = 10;
            this.btnCotizaciones.Size = new System.Drawing.Size(176, 33);
            this.btnCotizaciones.TabIndex = 4;
            this.btnCotizaciones.Text = "Cotizaciones";
            this.btnCotizaciones.UseVisualStyleBackColor = false;
            this.btnCotizaciones.Click += new System.EventHandler(this.btnCotizaciones_Click);
            // 
            // btnTipoServicio
            // 
            this.btnTipoServicio.BackColor = System.Drawing.Color.Transparent;
            this.btnTipoServicio.ColorGlyph = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(198)))), ((int)(((byte)(240)))));
            this.btnTipoServicio.ColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(112)))));
            this.btnTipoServicio.ColorSeleccionado = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnTipoServicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTipoServicio.Degradado = true;
            this.btnTipoServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTipoServicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTipoServicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(245)))));
            this.btnTipoServicio.Glyph = "";
            this.btnTipoServicio.Location = new System.Drawing.Point(12, 238);
            this.btnTipoServicio.Name = "btnTipoServicio";
            this.btnTipoServicio.Radio = 10;
            this.btnTipoServicio.Size = new System.Drawing.Size(176, 33);
            this.btnTipoServicio.TabIndex = 5;
            this.btnTipoServicio.Text = "Tipo de Servicio";
            this.btnTipoServicio.UseVisualStyleBackColor = false;
            this.btnTipoServicio.Click += new System.EventHandler(this.btnTipoServicio_Click);
            // 
            // btnMateriales
            // 
            this.btnMateriales.BackColor = System.Drawing.Color.Transparent;
            this.btnMateriales.ColorGlyph = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(198)))), ((int)(((byte)(240)))));
            this.btnMateriales.ColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(112)))));
            this.btnMateriales.ColorSeleccionado = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnMateriales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMateriales.Degradado = true;
            this.btnMateriales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMateriales.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMateriales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(245)))));
            this.btnMateriales.Glyph = "";
            this.btnMateriales.Location = new System.Drawing.Point(12, 275);
            this.btnMateriales.Name = "btnMateriales";
            this.btnMateriales.Radio = 10;
            this.btnMateriales.Size = new System.Drawing.Size(176, 33);
            this.btnMateriales.TabIndex = 6;
            this.btnMateriales.Text = "Materiales";
            this.btnMateriales.UseVisualStyleBackColor = false;
            this.btnMateriales.Click += new System.EventHandler(this.btnMateriales_Click);
            // 
            // btnDisenos
            // 
            this.btnDisenos.BackColor = System.Drawing.Color.Transparent;
            this.btnDisenos.ColorGlyph = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(198)))), ((int)(((byte)(240)))));
            this.btnDisenos.ColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(112)))));
            this.btnDisenos.ColorSeleccionado = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnDisenos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDisenos.Degradado = true;
            this.btnDisenos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisenos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDisenos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(245)))));
            this.btnDisenos.Glyph = "";
            this.btnDisenos.Location = new System.Drawing.Point(12, 312);
            this.btnDisenos.Name = "btnDisenos";
            this.btnDisenos.Radio = 10;
            this.btnDisenos.Size = new System.Drawing.Size(176, 33);
            this.btnDisenos.TabIndex = 7;
            this.btnDisenos.Text = "Diseños";
            this.btnDisenos.UseVisualStyleBackColor = false;
            this.btnDisenos.Click += new System.EventHandler(this.btnDisenos_Click);
            // 
            // btnDisenadores
            // 
            this.btnDisenadores.BackColor = System.Drawing.Color.Transparent;
            this.btnDisenadores.ColorGlyph = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(198)))), ((int)(((byte)(240)))));
            this.btnDisenadores.ColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(112)))));
            this.btnDisenadores.ColorSeleccionado = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnDisenadores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDisenadores.Degradado = true;
            this.btnDisenadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisenadores.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDisenadores.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(245)))));
            this.btnDisenadores.Glyph = "";
            this.btnDisenadores.Location = new System.Drawing.Point(12, 349);
            this.btnDisenadores.Name = "btnDisenadores";
            this.btnDisenadores.Radio = 10;
            this.btnDisenadores.Size = new System.Drawing.Size(176, 33);
            this.btnDisenadores.TabIndex = 8;
            this.btnDisenadores.Text = "Diseñadores";
            this.btnDisenadores.UseVisualStyleBackColor = false;
            this.btnDisenadores.Click += new System.EventHandler(this.btnDisenadores_Click);
            // 
            // btnOrdenesTrabajo
            // 
            this.btnOrdenesTrabajo.BackColor = System.Drawing.Color.Transparent;
            this.btnOrdenesTrabajo.ColorGlyph = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(198)))), ((int)(((byte)(240)))));
            this.btnOrdenesTrabajo.ColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(112)))));
            this.btnOrdenesTrabajo.ColorSeleccionado = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnOrdenesTrabajo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrdenesTrabajo.Degradado = true;
            this.btnOrdenesTrabajo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrdenesTrabajo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnOrdenesTrabajo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(245)))));
            this.btnOrdenesTrabajo.Glyph = "";
            this.btnOrdenesTrabajo.Location = new System.Drawing.Point(12, 386);
            this.btnOrdenesTrabajo.Name = "btnOrdenesTrabajo";
            this.btnOrdenesTrabajo.Radio = 10;
            this.btnOrdenesTrabajo.Size = new System.Drawing.Size(176, 33);
            this.btnOrdenesTrabajo.TabIndex = 9;
            this.btnOrdenesTrabajo.Text = "Órdenes de Trabajo";
            this.btnOrdenesTrabajo.UseVisualStyleBackColor = false;
            this.btnOrdenesTrabajo.Click += new System.EventHandler(this.btnOrdenesTrabajo_Click);
            // 
            // btnFacturaciones
            // 
            this.btnFacturaciones.BackColor = System.Drawing.Color.Transparent;
            this.btnFacturaciones.ColorGlyph = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(198)))), ((int)(((byte)(240)))));
            this.btnFacturaciones.ColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(112)))));
            this.btnFacturaciones.ColorSeleccionado = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnFacturaciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFacturaciones.Degradado = true;
            this.btnFacturaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFacturaciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFacturaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(245)))));
            this.btnFacturaciones.Glyph = "";
            this.btnFacturaciones.Location = new System.Drawing.Point(12, 423);
            this.btnFacturaciones.Name = "btnFacturaciones";
            this.btnFacturaciones.Radio = 10;
            this.btnFacturaciones.Size = new System.Drawing.Size(176, 33);
            this.btnFacturaciones.TabIndex = 10;
            this.btnFacturaciones.Text = "Facturaciones";
            this.btnFacturaciones.UseVisualStyleBackColor = false;
            this.btnFacturaciones.Click += new System.EventHandler(this.btnFacturaciones_Click);
            // 
            // btnSucursales
            // 
            this.btnSucursales.BackColor = System.Drawing.Color.Transparent;
            this.btnSucursales.ColorGlyph = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(198)))), ((int)(((byte)(240)))));
            this.btnSucursales.ColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(112)))));
            this.btnSucursales.ColorSeleccionado = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnSucursales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSucursales.Degradado = true;
            this.btnSucursales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSucursales.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSucursales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(245)))));
            this.btnSucursales.Glyph = "";
            this.btnSucursales.Location = new System.Drawing.Point(12, 460);
            this.btnSucursales.Name = "btnSucursales";
            this.btnSucursales.Radio = 10;
            this.btnSucursales.Size = new System.Drawing.Size(176, 33);
            this.btnSucursales.TabIndex = 11;
            this.btnSucursales.Text = "Sucursales";
            this.btnSucursales.UseVisualStyleBackColor = false;
            this.btnSucursales.Click += new System.EventHandler(this.btnSucursales_Click);
            // 
            // btnProveedores
            // 
            this.btnProveedores.BackColor = System.Drawing.Color.Transparent;
            this.btnProveedores.ColorGlyph = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(198)))), ((int)(((byte)(240)))));
            this.btnProveedores.ColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(112)))));
            this.btnProveedores.ColorSeleccionado = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnProveedores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProveedores.Degradado = true;
            this.btnProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProveedores.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnProveedores.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(245)))));
            this.btnProveedores.Glyph = "";
            this.btnProveedores.Location = new System.Drawing.Point(12, 497);
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Radio = 10;
            this.btnProveedores.Size = new System.Drawing.Size(176, 33);
            this.btnProveedores.TabIndex = 12;
            this.btnProveedores.Text = "Proveedores";
            this.btnProveedores.UseVisualStyleBackColor = false;
            this.btnProveedores.Click += new System.EventHandler(this.btnProveedores_Click);
            // 
            // btnInventarios
            // 
            this.btnInventarios.BackColor = System.Drawing.Color.Transparent;
            this.btnInventarios.ColorGlyph = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(198)))), ((int)(((byte)(240)))));
            this.btnInventarios.ColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(112)))));
            this.btnInventarios.ColorSeleccionado = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnInventarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInventarios.Degradado = true;
            this.btnInventarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventarios.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnInventarios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(245)))));
            this.btnInventarios.Glyph = "";
            this.btnInventarios.Location = new System.Drawing.Point(12, 534);
            this.btnInventarios.Name = "btnInventarios";
            this.btnInventarios.Radio = 10;
            this.btnInventarios.Size = new System.Drawing.Size(176, 33);
            this.btnInventarios.TabIndex = 13;
            this.btnInventarios.Text = "Inventarios";
            this.btnInventarios.UseVisualStyleBackColor = false;
            this.btnInventarios.Click += new System.EventHandler(this.btnInventarios_Click);
            // 
            // btnCompras
            // 
            this.btnCompras.BackColor = System.Drawing.Color.Transparent;
            this.btnCompras.ColorGlyph = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(198)))), ((int)(((byte)(240)))));
            this.btnCompras.ColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(112)))));
            this.btnCompras.ColorSeleccionado = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnCompras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompras.Degradado = true;
            this.btnCompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompras.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCompras.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(245)))));
            this.btnCompras.Glyph = "";
            this.btnCompras.Location = new System.Drawing.Point(12, 571);
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.Radio = 10;
            this.btnCompras.Size = new System.Drawing.Size(176, 33);
            this.btnCompras.TabIndex = 14;
            this.btnCompras.Text = "Compras";
            this.btnCompras.UseVisualStyleBackColor = false;
            this.btnCompras.Click += new System.EventHandler(this.btnCompras_Click);
            // 
            // pnlSeparador
            // 
            this.pnlSeparador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlSeparador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(64)))), ((int)(((byte)(130)))));
            this.pnlSeparador.Location = new System.Drawing.Point(12, 641);
            this.pnlSeparador.Name = "pnlSeparador";
            this.pnlSeparador.Size = new System.Drawing.Size(176, 1);
            this.pnlSeparador.TabIndex = 15;
            // 
            // btnConfiguracion
            // 
            this.btnConfiguracion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfiguracion.BackColor = System.Drawing.Color.Transparent;
            this.btnConfiguracion.ColorGlyph = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(198)))), ((int)(((byte)(240)))));
            this.btnConfiguracion.ColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(112)))));
            this.btnConfiguracion.ColorSeleccionado = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnConfiguracion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfiguracion.Degradado = true;
            this.btnConfiguracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfiguracion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnConfiguracion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(245)))));
            this.btnConfiguracion.Glyph = "";
            this.btnConfiguracion.Location = new System.Drawing.Point(12, 655);
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.Radio = 10;
            this.btnConfiguracion.Size = new System.Drawing.Size(176, 33);
            this.btnConfiguracion.TabIndex = 16;
            this.btnConfiguracion.Text = "Configuración";
            this.btnConfiguracion.UseVisualStyleBackColor = false;
            this.btnConfiguracion.Click += new System.EventHandler(this.btnConfiguracion_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCerrarSesion.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrarSesion.ColorGlyph = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(198)))), ((int)(((byte)(240)))));
            this.btnCerrarSesion.ColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(44)))), ((int)(((byte)(112)))));
            this.btnCerrarSesion.ColorSeleccionado = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarSesion.Degradado = true;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(245)))));
            this.btnCerrarSesion.Glyph = "";
            this.btnCerrarSesion.Location = new System.Drawing.Point(12, 695);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Radio = 10;
            this.btnCerrarSesion.Size = new System.Drawing.Size(176, 33);
            this.btnCerrarSesion.TabIndex = 17;
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(1120, 749);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1000, 718);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Publicidad Multisucursal";
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlAvatar.ResumeLayout(false);
            this.pnlSidebar.ResumeLayout(false);
            this.ResumeLayout(false);

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
