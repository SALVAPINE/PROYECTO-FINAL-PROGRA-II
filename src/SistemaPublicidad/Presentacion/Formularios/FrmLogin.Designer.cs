namespace CAPAZ.Presentacion
{
    partial class FrmLogin
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
            this.components = new System.ComponentModel.Container();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.lblPie = new System.Windows.Forms.Label();
            this.btnIngresar = new CAPAZ.Presentacion.Controles.BotonDegradado();
            this.lblError = new System.Windows.Forms.Label();
            this.lnkOlvido = new System.Windows.Forms.LinkLabel();
            this.chkRecordar = new CAPAZ.Presentacion.Controles.CasillaFina();
            this.txtClave = new CAPAZ.Presentacion.Controles.CampoTexto();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtUsuario = new CAPAZ.Presentacion.Controles.CampoTexto();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.btnCerrar = new CAPAZ.Presentacion.Controles.BotonVentana();
            this.btnMinimizar = new CAPAZ.Presentacion.Controles.BotonVentana();
            this.pnlMarca = new CAPAZ.Presentacion.Controles.PanelDegradado();
            this.logoMarca = new CAPAZ.Presentacion.Controles.LogoMarca();
            this.lblLema = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblMarcaSub = new System.Windows.Forms.Label();
            this.lblIdeasQue = new System.Windows.Forms.Label();
            this.lblConectan = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblPieMarca = new System.Windows.Forms.Label();
            this.lblSeccion = new System.Windows.Forms.Label();
            this.trazoPincel = new CAPAZ.Presentacion.Controles.TrazoPincel();
            this.lienzo = new CAPAZ.Presentacion.Controles.LienzoCreativo();
            this.itmCotizaciones = new CAPAZ.Presentacion.Controles.ItemCreativo();
            this.itmCompras = new CAPAZ.Presentacion.Controles.ItemCreativo();
            this.itmFacturacion = new CAPAZ.Presentacion.Controles.ItemCreativo();
            this.tmrFade = new System.Windows.Forms.Timer(this.components);
            this.tmrSacudir = new System.Windows.Forms.Timer(this.components);
            this.pnlLogin.SuspendLayout();
            this.pnlMarca.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLogin
            // 
            this.pnlLogin.BackColor = System.Drawing.Color.FromArgb(10, 16, 48);
            this.pnlLogin.Controls.Add(this.lblPie);
            this.pnlLogin.Controls.Add(this.btnIngresar);
            this.pnlLogin.Controls.Add(this.lblError);
            this.pnlLogin.Controls.Add(this.lnkOlvido);
            this.pnlLogin.Controls.Add(this.chkRecordar);
            this.pnlLogin.Controls.Add(this.txtClave);
            this.pnlLogin.Controls.Add(this.lblClave);
            this.pnlLogin.Controls.Add(this.txtUsuario);
            this.pnlLogin.Controls.Add(this.lblUsuario);
            this.pnlLogin.Controls.Add(this.lblSubtitulo);
            this.pnlLogin.Controls.Add(this.lblBienvenida);
            this.pnlLogin.Controls.Add(this.btnCerrar);
            this.pnlLogin.Controls.Add(this.btnMinimizar);
            this.pnlLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogin.Location = new System.Drawing.Point(740, 0);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(540, 780);
            this.pnlLogin.TabIndex = 0;
            this.pnlLogin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Arrastrar_MouseDown);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Location = new System.Drawing.Point(446, 14);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(36, 30);
            this.btnMinimizar.TabIndex = 20;
            this.btnMinimizar.Tipo = CAPAZ.Presentacion.Controles.TipoBotonVentana.Minimizar;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(488, 14);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(36, 30);
            this.btnCerrar.TabIndex = 21;
            this.btnCerrar.Tipo = CAPAZ.Presentacion.Controles.TipoBotonVentana.Cerrar;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.BackColor = System.Drawing.Color.Transparent;
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI Semibold", 26F);
            this.lblBienvenida.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.lblBienvenida.Location = new System.Drawing.Point(66, 188);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.TabIndex = 0;
            this.lblBienvenida.Text = "Iniciar sesión";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(150, 160, 208);
            this.lblSubtitulo.Location = new System.Drawing.Point(69, 246);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Ingrese sus credenciales para acceder al sistema";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(190, 198, 232);
            this.lblUsuario.Location = new System.Drawing.Point(69, 322);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.TabIndex = 2;
            this.lblUsuario.Text = "Usuario";
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.BackColor = System.Drawing.Color.Transparent;
            this.lblClave.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblClave.ForeColor = System.Drawing.Color.FromArgb(190, 198, 232);
            this.lblClave.Location = new System.Drawing.Point(69, 418);
            this.lblClave.Name = "lblClave";
            this.lblClave.TabIndex = 3;
            this.lblClave.Text = "Contraseña";
            // 
            // txtUsuario
            // 
            this.txtUsuario.CodigoIcono = "E77B";
            this.txtUsuario.Location = new System.Drawing.Point(68, 348);
            this.txtUsuario.MaxLength = 40;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(404, 50);
            this.txtUsuario.TabIndex = 0;
            this.txtUsuario.Text = "";
            this.txtUsuario.TextoAyuda = "Ingrese su usuario";
            // 
            // txtClave
            // 
            this.txtClave.BotonVer = true;
            this.txtClave.CodigoIcono = "E72E";
            this.txtClave.Location = new System.Drawing.Point(68, 444);
            this.txtClave.MaxLength = 40;
            this.txtClave.Name = "txtClave";
            this.txtClave.OcultarTexto = true;
            this.txtClave.Size = new System.Drawing.Size(404, 50);
            this.txtClave.TabIndex = 1;
            this.txtClave.Text = "";
            this.txtClave.TextoAyuda = "Ingrese su contraseña";
            // 
            // chkRecordar
            // 
            this.chkRecordar.Location = new System.Drawing.Point(68, 516);
            this.chkRecordar.Name = "chkRecordar";
            this.chkRecordar.Size = new System.Drawing.Size(170, 24);
            this.chkRecordar.TabIndex = 2;
            this.chkRecordar.Text = "Recordar usuario";
            // 
            // lnkOlvido
            // 
            this.lnkOlvido.ActiveLinkColor = System.Drawing.Color.FromArgb(244, 114, 182);
            this.lnkOlvido.AutoSize = true;
            this.lnkOlvido.BackColor = System.Drawing.Color.FromArgb(10, 16, 48);
            this.lnkOlvido.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkOlvido.LinkColor = System.Drawing.Color.FromArgb(150, 160, 250);
            this.lnkOlvido.Location = new System.Drawing.Point(348, 519);
            this.lnkOlvido.Name = "lnkOlvido";
            this.lnkOlvido.TabIndex = 3;
            this.lnkOlvido.TabStop = true;
            this.lnkOlvido.Text = "¿Olvidó su contraseña?";
            this.lnkOlvido.VisitedLinkColor = System.Drawing.Color.FromArgb(150, 160, 250);
            this.lnkOlvido.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkOlvido_LinkClicked);
            // 
            // lblError
            // 
            this.lblError.BackColor = System.Drawing.Color.FromArgb(10, 16, 48);
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(255, 110, 120);
            this.lblError.Location = new System.Drawing.Point(68, 552);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(404, 20);
            this.lblError.TabIndex = 5;
            // 
            // btnIngresar
            // 
            this.btnIngresar.CodigoIcono = "E72A";
            this.btnIngresar.Font = new System.Drawing.Font("Segoe UI Semibold", 11.5F);
            this.btnIngresar.Location = new System.Drawing.Point(68, 588);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(404, 52);
            this.btnIngresar.TabIndex = 4;
            this.btnIngresar.Text = "INICIAR SESIÓN";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // lblPie
            // 
            this.lblPie.BackColor = System.Drawing.Color.Transparent;
            this.lblPie.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblPie.ForeColor = System.Drawing.Color.FromArgb(104, 114, 170);
            this.lblPie.Location = new System.Drawing.Point(68, 740);
            this.lblPie.Name = "lblPie";
            this.lblPie.Size = new System.Drawing.Size(404, 20);
            this.lblPie.TabIndex = 6;
            this.lblPie.Text = "© 2026 Publicidad Multisucursal · Todos los derechos reservados";
            this.lblPie.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMarca
            // 
            this.pnlMarca.Controls.Add(this.lblPieMarca);
            this.pnlMarca.Controls.Add(this.lblLema);
            this.pnlMarca.Controls.Add(this.lienzo);
            this.pnlMarca.Controls.Add(this.itmFacturacion);
            this.pnlMarca.Controls.Add(this.itmCompras);
            this.pnlMarca.Controls.Add(this.itmCotizaciones);
            this.pnlMarca.Controls.Add(this.lblSeccion);
            this.pnlMarca.Controls.Add(this.trazoPincel);
            this.pnlMarca.Controls.Add(this.lblDescripcion);
            this.pnlMarca.Controls.Add(this.lblConectan);
            this.pnlMarca.Controls.Add(this.lblIdeasQue);
            this.pnlMarca.Controls.Add(this.lblMarcaSub);
            this.pnlMarca.Controls.Add(this.lblMarca);
            this.pnlMarca.Controls.Add(this.logoMarca);
            this.pnlMarca.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMarca.Location = new System.Drawing.Point(0, 0);
            this.pnlMarca.Name = "pnlMarca";
            this.pnlMarca.Size = new System.Drawing.Size(740, 780);
            this.pnlMarca.TabIndex = 1;
            this.pnlMarca.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Arrastrar_MouseDown);
            // 
            // logoMarca
            // 
            this.logoMarca.Location = new System.Drawing.Point(56, 40);
            this.logoMarca.Name = "logoMarca";
            this.logoMarca.Size = new System.Drawing.Size(48, 52);
            this.logoMarca.TabIndex = 20;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.BackColor = System.Drawing.Color.Transparent;
            this.lblMarca.Font = new System.Drawing.Font("Segoe UI Semibold", 17F);
            this.lblMarca.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.lblMarca.Location = new System.Drawing.Point(114, 40);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.TabIndex = 0;
            this.lblMarca.Text = "Publicidad";
            // 
            // lblMarcaSub
            // 
            this.lblMarcaSub.AutoSize = true;
            this.lblMarcaSub.BackColor = System.Drawing.Color.Transparent;
            this.lblMarcaSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblMarcaSub.ForeColor = System.Drawing.Color.FromArgb(160, 170, 226);
            this.lblMarcaSub.Location = new System.Drawing.Point(116, 72);
            this.lblMarcaSub.Name = "lblMarcaSub";
            this.lblMarcaSub.TabIndex = 1;
            this.lblMarcaSub.Text = "M U L T I S U C U R S A L";
            // 
            // lblIdeasQue
            // 
            this.lblIdeasQue.AutoSize = true;
            this.lblIdeasQue.BackColor = System.Drawing.Color.Transparent;
            this.lblIdeasQue.Font = new System.Drawing.Font("Segoe UI Light", 44F);
            this.lblIdeasQue.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.lblIdeasQue.Location = new System.Drawing.Point(54, 190);
            this.lblIdeasQue.Name = "lblIdeasQue";
            this.lblIdeasQue.TabIndex = 2;
            this.lblIdeasQue.Text = "Ideas que";
            // 
            // lblConectan
            // 
            this.lblConectan.AutoSize = false;
            this.lblConectan.Size = new System.Drawing.Size(380, 100);
            this.lblConectan.BackColor = System.Drawing.Color.Transparent;
            this.lblConectan.Font = new System.Drawing.Font("Segoe Script", 54F, System.Drawing.FontStyle.Bold);
            this.lblConectan.ForeColor = System.Drawing.Color.FromArgb(244, 114, 182);
            this.lblConectan.Location = new System.Drawing.Point(54, 258);
            this.lblConectan.Name = "lblConectan";
            this.lblConectan.TabIndex = 3;
            this.lblConectan.Text = "conectan";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = false;
            this.lblDescripcion.Size = new System.Drawing.Size(370, 56);
            this.lblDescripcion.BackColor = System.Drawing.Color.Transparent;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(196, 203, 236);
            this.lblDescripcion.Location = new System.Drawing.Point(60, 404);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.TabIndex = 4;
            this.lblDescripcion.Text = "Sistema de gestión para una publicidad\r\nque deja huella.";
            // 
            // lblPieMarca
            // 
            this.lblPieMarca.AutoSize = true;
            this.lblPieMarca.BackColor = System.Drawing.Color.Transparent;
            this.lblPieMarca.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPieMarca.ForeColor = System.Drawing.Color.FromArgb(150, 160, 214);
            this.lblPieMarca.Location = new System.Drawing.Point(60, 740);
            this.lblPieMarca.Name = "lblPieMarca";
            this.lblPieMarca.TabIndex = 11;
            this.lblPieMarca.Text = "Creatividad • Estrategia • Resultados";
            // 
            // trazoPincel
            // 
            this.trazoPincel.Location = new System.Drawing.Point(58, 362);
            this.trazoPincel.Name = "trazoPincel";
            this.trazoPincel.Size = new System.Drawing.Size(330, 22);
            this.trazoPincel.TabIndex = 40;
            // 
            // lienzo
            // 
            this.lienzo.Location = new System.Drawing.Point(440, 30);
            this.lienzo.Name = "lienzo";
            this.lienzo.Size = new System.Drawing.Size(300, 700);
            this.lienzo.TabIndex = 41;
            // 
            // lblSeccion
            // 
            this.lblSeccion.AutoSize = true;
            this.lblSeccion.BackColor = System.Drawing.Color.Transparent;
            this.lblSeccion.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F);
            this.lblSeccion.ForeColor = System.Drawing.Color.FromArgb(244, 114, 182);
            this.lblSeccion.Location = new System.Drawing.Point(62, 462);
            this.lblSeccion.Name = "lblSeccion";
            this.lblSeccion.TabIndex = 42;
            this.lblSeccion.Text = "T O D O   E N   U N   S O L O   L U G A R";
            // 
            // itmCotizaciones
            // 
            this.itmCotizaciones.ColorFin = System.Drawing.Color.FromArgb(167, 139, 250);
            this.itmCotizaciones.ColorInicio = System.Drawing.Color.FromArgb(244, 114, 182);
            this.itmCotizaciones.Descripcion = "De la primera idea al proyecto terminado.";
            this.itmCotizaciones.Icono = CAPAZ.Presentacion.Controles.IconoCreativo.Lapiz;
            this.itmCotizaciones.Location = new System.Drawing.Point(56, 490);
            this.itmCotizaciones.Name = "itmCotizaciones";
            this.itmCotizaciones.Size = new System.Drawing.Size(380, 72);
            this.itmCotizaciones.TabIndex = 43;
            this.itmCotizaciones.Titulo = "Cotizaciones y órdenes de trabajo";
            // 
            // itmCompras
            // 
            this.itmCompras.ColorFin = System.Drawing.Color.FromArgb(99, 102, 241);
            this.itmCompras.ColorInicio = System.Drawing.Color.FromArgb(167, 139, 250);
            this.itmCompras.Descripcion = "Todo lo que tu creatividad necesita, a la mano.";
            this.itmCompras.Icono = CAPAZ.Presentacion.Controles.IconoCreativo.Cubo;
            this.itmCompras.Location = new System.Drawing.Point(56, 562);
            this.itmCompras.Name = "itmCompras";
            this.itmCompras.Size = new System.Drawing.Size(380, 72);
            this.itmCompras.TabIndex = 44;
            this.itmCompras.Titulo = "Compras, materiales e inventarios";
            // 
            // itmFacturacion
            // 
            this.itmFacturacion.ColorFin = System.Drawing.Color.FromArgb(99, 102, 241);
            this.itmFacturacion.ColorInicio = System.Drawing.Color.FromArgb(34, 211, 238);
            this.itmFacturacion.ConectarAbajo = false;
            this.itmFacturacion.Descripcion = "Resultados claros para cada sucursal.";
            this.itmFacturacion.Icono = CAPAZ.Presentacion.Controles.IconoCreativo.Grafica;
            this.itmFacturacion.Location = new System.Drawing.Point(56, 634);
            this.itmFacturacion.Name = "itmFacturacion";
            this.itmFacturacion.Size = new System.Drawing.Size(380, 72);
            this.itmFacturacion.TabIndex = 45;
            this.itmFacturacion.Titulo = "Facturación y reportes en tiempo real";
            // 
            // lblLema
            // 
            this.lblLema.BackColor = System.Drawing.Color.Transparent;
            this.lblLema.Font = new System.Drawing.Font("Segoe Script", 13F, System.Drawing.FontStyle.Italic);
            this.lblLema.ForeColor = System.Drawing.Color.FromArgb(244, 114, 182);
            this.lblLema.Location = new System.Drawing.Point(330, 730);
            this.lblLema.Name = "lblLema";
            this.lblLema.Size = new System.Drawing.Size(360, 34);
            this.lblLema.TabIndex = 30;
            this.lblLema.Text = "Tu idea, nuestra inspiración";
            this.lblLema.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tmrFade
            // 
            this.tmrFade.Interval = 15;
            this.tmrFade.Tick += new System.EventHandler(this.tmrFade_Tick);
            // 
            // tmrSacudir
            // 
            this.tmrSacudir.Interval = 25;
            this.tmrSacudir.Tick += new System.EventHandler(this.tmrSacudir_Tick);
            // 
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.btnIngresar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(10, 16, 48);
            this.ClientSize = new System.Drawing.Size(1280, 780);
            this.Controls.Add(this.pnlLogin);
            this.Controls.Add(this.pnlMarca);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Publicidad Multisucursal - Inicio de sesión";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmLogin_KeyDown);
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.pnlMarca.ResumeLayout(false);
            this.pnlMarca.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlLogin;
        private Controles.PanelDegradado pnlMarca;
        private Controles.LogoMarca logoMarca;
        private System.Windows.Forms.Label lblLema;
        private System.Windows.Forms.Label lblSeccion;
        private Controles.TrazoPincel trazoPincel;
        private Controles.LienzoCreativo lienzo;
        private Controles.ItemCreativo itmCotizaciones;
        private Controles.ItemCreativo itmCompras;
        private Controles.ItemCreativo itmFacturacion;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblMarcaSub;
        private System.Windows.Forms.Label lblIdeasQue;
        private System.Windows.Forms.Label lblConectan;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblPieMarca;
        private Controles.BotonVentana btnMinimizar;
        private Controles.BotonVentana btnCerrar;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblUsuario;
        private Controles.CampoTexto txtUsuario;
        private System.Windows.Forms.Label lblClave;
        private Controles.CampoTexto txtClave;
        private Controles.CasillaFina chkRecordar;
        private System.Windows.Forms.LinkLabel lnkOlvido;
        private System.Windows.Forms.Label lblError;
        private Controles.BotonDegradado btnIngresar;
        private System.Windows.Forms.Label lblPie;
        private System.Windows.Forms.Timer tmrFade;
        private System.Windows.Forms.Timer tmrSacudir;
    }
}
