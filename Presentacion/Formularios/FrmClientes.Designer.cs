namespace Presentacion
{
    partial class FrmClientes
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
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this.tabModulo = new Presentacion.TabControlSinEncabezado();
            this.tpConsultar = new System.Windows.Forms.TabPage();
            this.pnlLista = new Presentacion.RoundedPanel();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.pnlPie = new System.Windows.Forms.Panel();
            this.lblTotalRegistros = new System.Windows.Forms.Label();
            this.btnPagAnterior = new Presentacion.BotonIcono();
            this.sepPagA = new System.Windows.Forms.Panel();
            this.btnPagina = new Presentacion.BotonIcono();
            this.sepPagB = new System.Windows.Forms.Panel();
            this.btnPagSiguiente = new Presentacion.BotonIcono();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.pnlToolbarFiltros = new System.Windows.Forms.Panel();
            this.csBuscar = new Presentacion.CampoBusqueda();
            this.pnlFiltroEstado = new System.Windows.Forms.Panel();
            this.cmbFiltroEstado = new System.Windows.Forms.ComboBox();
            this.pnlToolbarTop = new System.Windows.Forms.Panel();
            this.pnlIconoLista = new Presentacion.RoundedPanel();
            this.lblGlyphLista = new System.Windows.Forms.Label();
            this.lblTituloLista = new System.Windows.Forms.Label();
            this.btnEditar = new Presentacion.BotonIcono();
            this.sepToolbarA = new System.Windows.Forms.Panel();
            this.btnEliminar = new Presentacion.BotonIcono();
            this.sepToolbarB = new System.Windows.Forms.Panel();
            this.btnNuevo = new Presentacion.BotonIcono();
            this.pnlKpi = new System.Windows.Forms.Panel();
            this.tlpKpi = new System.Windows.Forms.TableLayoutPanel();
            this.statTotal = new Presentacion.StatCard();
            this.statEstado1 = new Presentacion.StatCard();
            this.statEstado2 = new Presentacion.StatCard();
            this.statExtra = new Presentacion.StatCard();
            this.pnlTituloConsulta = new System.Windows.Forms.Panel();
            this.lblTituloConsulta = new System.Windows.Forms.Label();
            this.lblSubtituloConsulta = new System.Windows.Forms.Label();
            this.tpGestionar = new System.Windows.Forms.TabPage();
            this.pnlBarra = new System.Windows.Forms.Panel();
            this.btnLimpiar = new Presentacion.BotonIcono();
            this.sepBarraA = new System.Windows.Forms.Panel();
            this.btnCancelar = new Presentacion.BotonIcono();
            this.sepBarraB = new System.Windows.Forms.Panel();
            this.btnGuardar = new Presentacion.BotonIcono();
            this.pnlFormulario = new Presentacion.RoundedPanel();
            this.tlpCampos = new System.Windows.Forms.TableLayoutPanel();
            this.lblCodigoCliente = new System.Windows.Forms.Label();
            this.txtCodigoCliente = new System.Windows.Forms.TextBox();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblDPI = new System.Windows.Forms.Label();
            this.txtDPI = new System.Windows.Forms.TextBox();
            this.lblEdad = new System.Windows.Forms.Label();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.lblNIT = new System.Windows.Forms.Label();
            this.txtNIT = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.pnlEstado = new System.Windows.Forms.Panel();
            this.rdoActivo = new System.Windows.Forms.RadioButton();
            this.rdoInactivo = new System.Windows.Forms.RadioButton();
            this.pnlTituloForm = new System.Windows.Forms.Panel();
            this.pnlIconoForm = new Presentacion.RoundedPanel();
            this.lblGlyphForm = new System.Windows.Forms.Label();
            this.lblTituloForm = new System.Windows.Forms.Label();
            this.pnlTituloGestion = new System.Windows.Forms.Panel();
            this.bannerDegradado1 = new Presentacion.BannerDegradado();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tpResumen = new System.Windows.Forms.TabPage();
            this.tlpResumenGraficos = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCardEstado = new Presentacion.RoundedPanel();
            this.graEstado = new Presentacion.GraficoDona();
            this.pnlTituloEstado = new System.Windows.Forms.Panel();
            this.lblIconoEstado = new System.Windows.Forms.Label();
            this.lblTituloEstado = new System.Windows.Forms.Label();
            this.pnlCardCategoria = new Presentacion.RoundedPanel();
            this.graCategoria = new Presentacion.GraficoBarras();
            this.pnlTituloCategoria = new System.Windows.Forms.Panel();
            this.lblIconoCategoria = new System.Windows.Forms.Label();
            this.lblTituloCategoria = new System.Windows.Forms.Label();
            this.pnlTituloResumen = new System.Windows.Forms.Panel();
            this.lblTituloResumen = new System.Windows.Forms.Label();
            this.lblSubtituloResumen = new System.Windows.Forms.Label();
            this.btnTabConsultar = new Presentacion.BotonIcono();
            this.btnTabGestionar = new Presentacion.BotonIcono();
            this.btnTabResumen = new Presentacion.BotonIcono();
            this.pnlCabecera.SuspendLayout();
            this.tabModulo.SuspendLayout();
            this.tpConsultar.SuspendLayout();
            this.pnlLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.pnlPie.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlToolbarFiltros.SuspendLayout();
            this.pnlFiltroEstado.SuspendLayout();
            this.pnlToolbarTop.SuspendLayout();
            this.pnlIconoLista.SuspendLayout();
            this.pnlKpi.SuspendLayout();
            this.tlpKpi.SuspendLayout();
            this.pnlTituloConsulta.SuspendLayout();
            this.tpGestionar.SuspendLayout();
            this.pnlBarra.SuspendLayout();
            this.pnlFormulario.SuspendLayout();
            this.tlpCampos.SuspendLayout();
            this.pnlEstado.SuspendLayout();
            this.pnlTituloForm.SuspendLayout();
            this.pnlIconoForm.SuspendLayout();
            this.pnlTituloGestion.SuspendLayout();
            this.bannerDegradado1.SuspendLayout();
            this.tpResumen.SuspendLayout();
            this.tlpResumenGraficos.SuspendLayout();
            this.pnlCardEstado.SuspendLayout();
            this.pnlTituloEstado.SuspendLayout();
            this.pnlCardCategoria.SuspendLayout();
            this.pnlTituloCategoria.SuspendLayout();
            this.pnlTituloResumen.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.pnlCabecera.Controls.Add(this.btnTabConsultar);
            this.pnlCabecera.Controls.Add(this.btnTabGestionar);
            this.pnlCabecera.Controls.Add(this.btnTabResumen);
            this.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCabecera.Location = new System.Drawing.Point(20, 10);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(1050, 44);
            this.pnlCabecera.TabIndex = 1;
            // 
            // tabModulo
            // 
            this.tabModulo.Controls.Add(this.tpConsultar);
            this.tabModulo.Controls.Add(this.tpGestionar);
            this.tabModulo.Controls.Add(this.tpResumen);
            this.tabModulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabModulo.Location = new System.Drawing.Point(20, 54);
            this.tabModulo.Name = "tabModulo";
            this.tabModulo.SelectedIndex = 0;
            this.tabModulo.Size = new System.Drawing.Size(1050, 666);
            this.tabModulo.TabIndex = 0;
            // 
            // tpConsultar
            // 
            this.tpConsultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.tpConsultar.Controls.Add(this.pnlLista);
            this.tpConsultar.Controls.Add(this.pnlKpi);
            this.tpConsultar.Controls.Add(this.pnlTituloConsulta);
            this.tpConsultar.Location = new System.Drawing.Point(4, 25);
            this.tpConsultar.Name = "tpConsultar";
            this.tpConsultar.Size = new System.Drawing.Size(1042, 637);
            this.tpConsultar.TabIndex = 0;
            this.tpConsultar.Text = "Consultar";
            // 
            // pnlLista
            // 
            this.pnlLista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlLista.Controls.Add(this.dgvClientes);
            this.pnlLista.Controls.Add(this.pnlPie);
            this.pnlLista.Controls.Add(this.pnlToolbar);
            this.pnlLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLista.Location = new System.Drawing.Point(0, 202);
            this.pnlLista.Name = "pnlLista";
            this.pnlLista.Padding = new System.Windows.Forms.Padding(16, 8, 16, 4);
            this.pnlLista.Size = new System.Drawing.Size(1042, 435);
            this.pnlLista.TabIndex = 0;
            // 
            // dgvClientes
            // 
            this.dgvClientes.ColumnHeadersHeight = 29;
            this.dgvClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClientes.Location = new System.Drawing.Point(16, 108);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.RowHeadersWidth = 51;
            this.dgvClientes.Size = new System.Drawing.Size(1010, 281);
            this.dgvClientes.TabIndex = 0;
            // 
            // pnlPie
            // 
            this.pnlPie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlPie.Controls.Add(this.lblTotalRegistros);
            this.pnlPie.Controls.Add(this.btnPagAnterior);
            this.pnlPie.Controls.Add(this.sepPagA);
            this.pnlPie.Controls.Add(this.btnPagina);
            this.pnlPie.Controls.Add(this.sepPagB);
            this.pnlPie.Controls.Add(this.btnPagSiguiente);
            this.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPie.Location = new System.Drawing.Point(16, 389);
            this.pnlPie.Name = "pnlPie";
            this.pnlPie.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.pnlPie.Size = new System.Drawing.Size(1010, 42);
            this.pnlPie.TabIndex = 1;
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.AutoSize = true;
            this.lblTotalRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalRegistros.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalRegistros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(208)))), ((int)(((byte)(240)))));
            this.lblTotalRegistros.Location = new System.Drawing.Point(0, 12);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(210, 20);
            this.lblTotalRegistros.TabIndex = 0;
            this.lblTotalRegistros.Text = "Mostrando 0 de 0 resultados";
            // 
            // btnPagAnterior
            // 
            this.btnPagAnterior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(100)))));
            this.btnPagAnterior.ColorBorde = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(58)))), ((int)(((byte)(130)))));
            this.btnPagAnterior.ColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(56)))), ((int)(((byte)(130)))));
            this.btnPagAnterior.ColorSeleccionado = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(130)))), ((int)(((byte)(170)))));
            this.btnPagAnterior.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPagAnterior.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPagAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagAnterior.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPagAnterior.ForeColor = System.Drawing.Color.White;
            this.btnPagAnterior.Location = new System.Drawing.Point(902, 6);
            this.btnPagAnterior.Name = "btnPagAnterior";
            this.btnPagAnterior.Radio = 6;
            this.btnPagAnterior.Size = new System.Drawing.Size(32, 36);
            this.btnPagAnterior.TabIndex = 1;
            this.btnPagAnterior.Text = "‹";
            this.btnPagAnterior.UseVisualStyleBackColor = false;
            // 
            // sepPagA
            // 
            this.sepPagA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.sepPagA.Dock = System.Windows.Forms.DockStyle.Right;
            this.sepPagA.Location = new System.Drawing.Point(934, 6);
            this.sepPagA.Name = "sepPagA";
            this.sepPagA.Size = new System.Drawing.Size(6, 36);
            this.sepPagA.TabIndex = 2;
            // 
            // btnPagina
            // 
            this.btnPagina.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(100)))));
            this.btnPagina.ColorBorde = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(58)))), ((int)(((byte)(130)))));
            this.btnPagina.ColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(56)))), ((int)(((byte)(130)))));
            this.btnPagina.ColorSeleccionado = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(130)))), ((int)(((byte)(170)))));
            this.btnPagina.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPagina.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPagina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagina.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPagina.ForeColor = System.Drawing.Color.White;
            this.btnPagina.Location = new System.Drawing.Point(940, 6);
            this.btnPagina.Name = "btnPagina";
            this.btnPagina.Radio = 6;
            this.btnPagina.Seleccionado = true;
            this.btnPagina.Size = new System.Drawing.Size(32, 36);
            this.btnPagina.TabIndex = 3;
            this.btnPagina.Text = "1";
            this.btnPagina.UseVisualStyleBackColor = false;
            // 
            // sepPagB
            // 
            this.sepPagB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.sepPagB.Dock = System.Windows.Forms.DockStyle.Right;
            this.sepPagB.Location = new System.Drawing.Point(972, 6);
            this.sepPagB.Name = "sepPagB";
            this.sepPagB.Size = new System.Drawing.Size(6, 36);
            this.sepPagB.TabIndex = 4;
            // 
            // btnPagSiguiente
            // 
            this.btnPagSiguiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(100)))));
            this.btnPagSiguiente.ColorBorde = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(58)))), ((int)(((byte)(130)))));
            this.btnPagSiguiente.ColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(56)))), ((int)(((byte)(130)))));
            this.btnPagSiguiente.ColorSeleccionado = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(130)))), ((int)(((byte)(170)))));
            this.btnPagSiguiente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPagSiguiente.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPagSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagSiguiente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPagSiguiente.ForeColor = System.Drawing.Color.White;
            this.btnPagSiguiente.Location = new System.Drawing.Point(978, 6);
            this.btnPagSiguiente.Name = "btnPagSiguiente";
            this.btnPagSiguiente.Radio = 6;
            this.btnPagSiguiente.Size = new System.Drawing.Size(32, 36);
            this.btnPagSiguiente.TabIndex = 5;
            this.btnPagSiguiente.Text = "›";
            this.btnPagSiguiente.UseVisualStyleBackColor = false;
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlToolbar.Controls.Add(this.pnlToolbarFiltros);
            this.pnlToolbar.Controls.Add(this.pnlToolbarTop);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(16, 8);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(1010, 100);
            this.pnlToolbar.TabIndex = 2;
            // 
            // pnlToolbarFiltros
            // 
            this.pnlToolbarFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlToolbarFiltros.Controls.Add(this.csBuscar);
            this.pnlToolbarFiltros.Controls.Add(this.pnlFiltroEstado);
            this.pnlToolbarFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbarFiltros.Location = new System.Drawing.Point(0, 54);
            this.pnlToolbarFiltros.Name = "pnlToolbarFiltros";
            this.pnlToolbarFiltros.Padding = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.pnlToolbarFiltros.Size = new System.Drawing.Size(1010, 46);
            this.pnlToolbarFiltros.TabIndex = 0;
            // 
            // csBuscar
            // 
            this.csBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.csBuscar.Dock = System.Windows.Forms.DockStyle.Left;
            this.csBuscar.Location = new System.Drawing.Point(0, 0);
            this.csBuscar.Name = "csBuscar";
            this.csBuscar.Placeholder = "Buscar por nombre, código, DPI o NIT...";
            this.csBuscar.Radio = 8;
            this.csBuscar.Size = new System.Drawing.Size(864, 34);
            this.csBuscar.TabIndex = 0;
            this.csBuscar.EnterPresionado += new System.EventHandler(this.csBuscar_EnterPresionado);
            // 
            // pnlFiltroEstado
            // 
            this.pnlFiltroEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlFiltroEstado.Controls.Add(this.cmbFiltroEstado);
            this.pnlFiltroEstado.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFiltroEstado.Location = new System.Drawing.Point(880, 0);
            this.pnlFiltroEstado.Name = "pnlFiltroEstado";
            this.pnlFiltroEstado.Size = new System.Drawing.Size(130, 34);
            this.pnlFiltroEstado.TabIndex = 2;
            // 
            // cmbFiltroEstado
            // 
            this.cmbFiltroEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFiltroEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.cmbFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFiltroEstado.ForeColor = System.Drawing.Color.White;
            this.cmbFiltroEstado.Items.AddRange(new object[] {
            "Todos",
            "Activo",
            "Inactivo"});
            this.cmbFiltroEstado.Location = new System.Drawing.Point(0, 3);
            this.cmbFiltroEstado.Name = "cmbFiltroEstado";
            this.cmbFiltroEstado.Size = new System.Drawing.Size(130, 24);
            this.cmbFiltroEstado.TabIndex = 0;
            // 
            // pnlToolbarTop
            // 
            this.pnlToolbarTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlToolbarTop.Controls.Add(this.pnlIconoLista);
            this.pnlToolbarTop.Controls.Add(this.lblTituloLista);
            this.pnlToolbarTop.Controls.Add(this.btnEditar);
            this.pnlToolbarTop.Controls.Add(this.sepToolbarA);
            this.pnlToolbarTop.Controls.Add(this.btnEliminar);
            this.pnlToolbarTop.Controls.Add(this.sepToolbarB);
            this.pnlToolbarTop.Controls.Add(this.btnNuevo);
            this.pnlToolbarTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbarTop.Location = new System.Drawing.Point(0, 0);
            this.pnlToolbarTop.Name = "pnlToolbarTop";
            this.pnlToolbarTop.Padding = new System.Windows.Forms.Padding(0, 8, 0, 10);
            this.pnlToolbarTop.Size = new System.Drawing.Size(1010, 54);
            this.pnlToolbarTop.TabIndex = 1;
            // 
            // pnlIconoLista
            // 
            this.pnlIconoLista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(52)))), ((int)(((byte)(120)))));
            this.pnlIconoLista.ColorBorde = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(52)))), ((int)(((byte)(120)))));
            this.pnlIconoLista.Controls.Add(this.lblGlyphLista);
            this.pnlIconoLista.Location = new System.Drawing.Point(0, 8);
            this.pnlIconoLista.Name = "pnlIconoLista";
            this.pnlIconoLista.Radio = 10;
            this.pnlIconoLista.Size = new System.Drawing.Size(38, 38);
            this.pnlIconoLista.TabIndex = 0;
            // 
            // lblGlyphLista
            // 
            this.lblGlyphLista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(52)))), ((int)(((byte)(120)))));
            this.lblGlyphLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGlyphLista.Font = new System.Drawing.Font("Segoe MDL2 Assets", 13F);
            this.lblGlyphLista.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(165)))), ((int)(((byte)(250)))));
            this.lblGlyphLista.Location = new System.Drawing.Point(0, 0);
            this.lblGlyphLista.Name = "lblGlyphLista";
            this.lblGlyphLista.Size = new System.Drawing.Size(38, 38);
            this.lblGlyphLista.TabIndex = 0;
            this.lblGlyphLista.Text = "";
            this.lblGlyphLista.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTituloLista
            // 
            this.lblTituloLista.AutoSize = true;
            this.lblTituloLista.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloLista.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTituloLista.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblTituloLista.Location = new System.Drawing.Point(48, 17);
            this.lblTituloLista.Name = "lblTituloLista";
            this.lblTituloLista.Size = new System.Drawing.Size(174, 25);
            this.lblTituloLista.TabIndex = 1;
            this.lblTituloLista.Text = "Listado de clientes";
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(100)))));
            this.btnEditar.ColorBorde = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(58)))), ((int)(((byte)(130)))));
            this.btnEditar.ColorGlyph = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(165)))), ((int)(((byte)(250)))));
            this.btnEditar.ColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(56)))), ((int)(((byte)(130)))));
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Glyph = "";
            this.btnEditar.Location = new System.Drawing.Point(776, 8);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(44, 36);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // sepToolbarA
            // 
            this.sepToolbarA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.sepToolbarA.Dock = System.Windows.Forms.DockStyle.Right;
            this.sepToolbarA.Location = new System.Drawing.Point(820, 8);
            this.sepToolbarA.Name = "sepToolbarA";
            this.sepToolbarA.Size = new System.Drawing.Size(8, 36);
            this.sepToolbarA.TabIndex = 3;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(100)))));
            this.btnEliminar.ColorBorde = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(58)))), ((int)(((byte)(130)))));
            this.btnEliminar.ColorGlyph = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(63)))), ((int)(((byte)(94)))));
            this.btnEliminar.ColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(56)))), ((int)(((byte)(130)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Glyph = "";
            this.btnEliminar.Location = new System.Drawing.Point(828, 8);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(44, 36);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // sepToolbarB
            // 
            this.sepToolbarB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.sepToolbarB.Dock = System.Windows.Forms.DockStyle.Right;
            this.sepToolbarB.Location = new System.Drawing.Point(872, 8);
            this.sepToolbarB.Name = "sepToolbarB";
            this.sepToolbarB.Size = new System.Drawing.Size(8, 36);
            this.sepToolbarB.TabIndex = 5;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(130)))), ((int)(((byte)(170)))));
            this.btnNuevo.ColorBorde = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(180)))), ((int)(((byte)(220)))));
            this.btnNuevo.ColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(160)))), ((int)(((byte)(205)))));
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Glyph = "";
            this.btnNuevo.Location = new System.Drawing.Point(880, 8);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(130, 36);
            this.btnNuevo.TabIndex = 6;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // pnlKpi
            // 
            this.pnlKpi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.pnlKpi.Controls.Add(this.tlpKpi);
            this.pnlKpi.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpi.Location = new System.Drawing.Point(0, 70);
            this.pnlKpi.Name = "pnlKpi";
            this.pnlKpi.Padding = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.pnlKpi.Size = new System.Drawing.Size(1042, 132);
            this.pnlKpi.TabIndex = 1;
            // 
            // tlpKpi
            // 
            this.tlpKpi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.tlpKpi.ColumnCount = 4;
            this.tlpKpi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpi.Controls.Add(this.statTotal, 0, 0);
            this.tlpKpi.Controls.Add(this.statEstado1, 1, 0);
            this.tlpKpi.Controls.Add(this.statEstado2, 2, 0);
            this.tlpKpi.Controls.Add(this.statExtra, 3, 0);
            this.tlpKpi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpKpi.Location = new System.Drawing.Point(0, 0);
            this.tlpKpi.Name = "tlpKpi";
            this.tlpKpi.RowCount = 1;
            this.tlpKpi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpKpi.Size = new System.Drawing.Size(1042, 120);
            this.tlpKpi.TabIndex = 0;
            // 
            // statTotal
            // 
            this.statTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.statTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statTotal.Glyph = "";
            this.statTotal.Location = new System.Drawing.Point(0, 0);
            this.statTotal.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.statTotal.Name = "statTotal";
            this.statTotal.Size = new System.Drawing.Size(246, 120);
            this.statTotal.Subtitulo = "Registros";
            this.statTotal.TabIndex = 0;
            this.statTotal.Titulo = "Total de clientes";
            // 
            // statEstado1
            // 
            this.statEstado1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.statEstado1.ColorFin = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(40)))), ((int)(((byte)(120)))));
            this.statEstado1.ColorInicio = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(62)))), ((int)(((byte)(140)))));
            this.statEstado1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statEstado1.Glyph = "";
            this.statEstado1.Location = new System.Drawing.Point(260, 0);
            this.statEstado1.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.statEstado1.Name = "statEstado1";
            this.statEstado1.Size = new System.Drawing.Size(246, 120);
            this.statEstado1.TabIndex = 1;
            this.statEstado1.Titulo = "Activos";
            // 
            // statEstado2
            // 
            this.statEstado2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.statEstado2.ColorFin = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
            this.statEstado2.ColorInicio = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(184)))), ((int)(((byte)(166)))));
            this.statEstado2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statEstado2.Glyph = "";
            this.statEstado2.Location = new System.Drawing.Point(520, 0);
            this.statEstado2.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.statEstado2.Name = "statEstado2";
            this.statEstado2.Size = new System.Drawing.Size(246, 120);
            this.statEstado2.TabIndex = 2;
            this.statEstado2.Titulo = "Inactivos";
            // 
            // statExtra
            // 
            this.statExtra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.statExtra.ColorFin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(101)))), ((int)(((byte)(12)))));
            this.statExtra.ColorInicio = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.statExtra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statExtra.Glyph = "";
            this.statExtra.Location = new System.Drawing.Point(780, 0);
            this.statExtra.Margin = new System.Windows.Forms.Padding(0);
            this.statExtra.Name = "statExtra";
            this.statExtra.Size = new System.Drawing.Size(262, 120);
            this.statExtra.TabIndex = 3;
            this.statExtra.Titulo = "Categorías";
            // 
            // pnlTituloConsulta
            // 
            this.pnlTituloConsulta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.pnlTituloConsulta.Controls.Add(this.lblTituloConsulta);
            this.pnlTituloConsulta.Controls.Add(this.lblSubtituloConsulta);
            this.pnlTituloConsulta.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTituloConsulta.Location = new System.Drawing.Point(0, 0);
            this.pnlTituloConsulta.Name = "pnlTituloConsulta";
            this.pnlTituloConsulta.Size = new System.Drawing.Size(1042, 70);
            this.pnlTituloConsulta.TabIndex = 2;
            // 
            // lblTituloConsulta
            // 
            this.lblTituloConsulta.AutoSize = true;
            this.lblTituloConsulta.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloConsulta.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTituloConsulta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblTituloConsulta.Location = new System.Drawing.Point(0, 0);
            this.lblTituloConsulta.Name = "lblTituloConsulta";
            this.lblTituloConsulta.Size = new System.Drawing.Size(299, 41);
            this.lblTituloConsulta.TabIndex = 0;
            this.lblTituloConsulta.Text = "Consulta de clientes";
            // 
            // lblSubtituloConsulta
            // 
            this.lblSubtituloConsulta.AutoSize = true;
            this.lblSubtituloConsulta.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtituloConsulta.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtituloConsulta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblSubtituloConsulta.Location = new System.Drawing.Point(0, 36);
            this.lblSubtituloConsulta.Name = "lblSubtituloConsulta";
            this.lblSubtituloConsulta.Size = new System.Drawing.Size(314, 21);
            this.lblSubtituloConsulta.TabIndex = 1;
            this.lblSubtituloConsulta.Text = "Consulte y administre clientes de la agencia.";
            // 
            // tpGestionar
            // 
            this.tpGestionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.tpGestionar.Controls.Add(this.pnlBarra);
            this.tpGestionar.Controls.Add(this.pnlFormulario);
            this.tpGestionar.Controls.Add(this.pnlTituloGestion);
            this.tpGestionar.Location = new System.Drawing.Point(4, 25);
            this.tpGestionar.Name = "tpGestionar";
            this.tpGestionar.Size = new System.Drawing.Size(1042, 637);
            this.tpGestionar.TabIndex = 1;
            this.tpGestionar.Text = "Gestionar";
            // 
            // pnlBarra
            // 
            this.pnlBarra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.pnlBarra.Controls.Add(this.btnLimpiar);
            this.pnlBarra.Controls.Add(this.sepBarraA);
            this.pnlBarra.Controls.Add(this.btnCancelar);
            this.pnlBarra.Controls.Add(this.sepBarraB);
            this.pnlBarra.Controls.Add(this.btnGuardar);
            this.pnlBarra.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarra.Location = new System.Drawing.Point(0, 437);
            this.pnlBarra.Name = "pnlBarra";
            this.pnlBarra.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.pnlBarra.Size = new System.Drawing.Size(1042, 70);
            this.pnlBarra.TabIndex = 1;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(50)))), ((int)(((byte)(128)))));
            this.btnLimpiar.ColorBorde = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(190)))));
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Glyph = "";
            this.btnLimpiar.Location = new System.Drawing.Point(678, 12);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(104, 58);
            this.btnLimpiar.TabIndex = 0;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // sepBarraA
            // 
            this.sepBarraA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.sepBarraA.Dock = System.Windows.Forms.DockStyle.Right;
            this.sepBarraA.Location = new System.Drawing.Point(782, 12);
            this.sepBarraA.Name = "sepBarraA";
            this.sepBarraA.Size = new System.Drawing.Size(8, 58);
            this.sepBarraA.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(50)))), ((int)(((byte)(128)))));
            this.btnCancelar.ColorBorde = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(190)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Glyph = "";
            this.btnCancelar.Location = new System.Drawing.Point(790, 12);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(112, 58);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // sepBarraB
            // 
            this.sepBarraB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.sepBarraB.Dock = System.Windows.Forms.DockStyle.Right;
            this.sepBarraB.Location = new System.Drawing.Point(902, 12);
            this.sepBarraB.Name = "sepBarraB";
            this.sepBarraB.Size = new System.Drawing.Size(8, 58);
            this.sepBarraB.TabIndex = 3;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(130)))), ((int)(((byte)(170)))));
            this.btnGuardar.ColorBorde = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(180)))), ((int)(((byte)(220)))));
            this.btnGuardar.ColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(160)))), ((int)(((byte)(205)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Glyph = "";
            this.btnGuardar.Location = new System.Drawing.Point(910, 12);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(132, 58);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // pnlFormulario
            // 
            this.pnlFormulario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlFormulario.Controls.Add(this.tlpCampos);
            this.pnlFormulario.Controls.Add(this.pnlTituloForm);
            this.pnlFormulario.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFormulario.Location = new System.Drawing.Point(0, 152);
            this.pnlFormulario.Name = "pnlFormulario";
            this.pnlFormulario.Padding = new System.Windows.Forms.Padding(18, 10, 18, 6);
            this.pnlFormulario.Size = new System.Drawing.Size(1042, 285);
            this.pnlFormulario.TabIndex = 2;
            // 
            // tlpCampos
            // 
            this.tlpCampos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.tlpCampos.ColumnCount = 2;
            this.tlpCampos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCampos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCampos.Controls.Add(this.lblCodigoCliente, 0, 0);
            this.tlpCampos.Controls.Add(this.txtCodigoCliente, 0, 1);
            this.tlpCampos.Controls.Add(this.lblNombreCliente, 0, 2);
            this.tlpCampos.Controls.Add(this.txtNombreCliente, 0, 3);
            this.tlpCampos.Controls.Add(this.lblDireccion, 0, 4);
            this.tlpCampos.Controls.Add(this.txtDireccion, 0, 5);
            this.tlpCampos.Controls.Add(this.lblDPI, 0, 6);
            this.tlpCampos.Controls.Add(this.txtDPI, 0, 7);
            this.tlpCampos.Controls.Add(this.lblEdad, 1, 0);
            this.tlpCampos.Controls.Add(this.txtEdad, 1, 1);
            this.tlpCampos.Controls.Add(this.lblNIT, 1, 2);
            this.tlpCampos.Controls.Add(this.txtNIT, 1, 3);
            this.tlpCampos.Controls.Add(this.lblTelefono, 1, 4);
            this.tlpCampos.Controls.Add(this.txtTelefono, 1, 5);
            this.tlpCampos.Controls.Add(this.lblEstado, 1, 6);
            this.tlpCampos.Controls.Add(this.pnlEstado, 1, 7);
            this.tlpCampos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCampos.Location = new System.Drawing.Point(18, 62);
            this.tlpCampos.Name = "tlpCampos";
            this.tlpCampos.RowCount = 9;
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCampos.Size = new System.Drawing.Size(1006, 217);
            this.tlpCampos.TabIndex = 0;
            // 
            // lblCodigoCliente
            // 
            this.lblCodigoCliente.BackColor = System.Drawing.Color.Transparent;
            this.lblCodigoCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCodigoCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblCodigoCliente.Location = new System.Drawing.Point(0, 0);
            this.lblCodigoCliente.Margin = new System.Windows.Forms.Padding(0);
            this.lblCodigoCliente.Name = "lblCodigoCliente";
            this.lblCodigoCliente.Size = new System.Drawing.Size(503, 18);
            this.lblCodigoCliente.TabIndex = 0;
            this.lblCodigoCliente.Text = "CodigoCliente:";
            this.lblCodigoCliente.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtCodigoCliente
            // 
            this.txtCodigoCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodigoCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.txtCodigoCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoCliente.ForeColor = System.Drawing.Color.White;
            this.txtCodigoCliente.Location = new System.Drawing.Point(0, 21);
            this.txtCodigoCliente.Margin = new System.Windows.Forms.Padding(0, 2, 10, 2);
            this.txtCodigoCliente.Name = "txtCodigoCliente";
            this.txtCodigoCliente.ReadOnly = true;
            this.txtCodigoCliente.Enabled = false;
            this.txtCodigoCliente.Size = new System.Drawing.Size(493, 22);
            this.txtCodigoCliente.TabIndex = 1;
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.BackColor = System.Drawing.Color.Transparent;
            this.lblNombreCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNombreCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblNombreCliente.Location = new System.Drawing.Point(0, 46);
            this.lblNombreCliente.Margin = new System.Windows.Forms.Padding(0);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(503, 18);
            this.lblNombreCliente.TabIndex = 2;
            this.lblNombreCliente.Text = "NombreCliente:";
            this.lblNombreCliente.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombreCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.txtNombreCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreCliente.ForeColor = System.Drawing.Color.White;
            this.txtNombreCliente.Location = new System.Drawing.Point(0, 67);
            this.txtNombreCliente.Margin = new System.Windows.Forms.Padding(0, 2, 10, 2);
            this.txtNombreCliente.MaxLength = 45;
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(493, 22);
            this.txtNombreCliente.TabIndex = 3;
            // 
            // lblDireccion
            // 
            this.lblDireccion.BackColor = System.Drawing.Color.Transparent;
            this.lblDireccion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDireccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblDireccion.Location = new System.Drawing.Point(0, 92);
            this.lblDireccion.Margin = new System.Windows.Forms.Padding(0);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(503, 18);
            this.lblDireccion.TabIndex = 4;
            this.lblDireccion.Text = "Direccion:";
            this.lblDireccion.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDireccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDireccion.ForeColor = System.Drawing.Color.White;
            this.txtDireccion.Location = new System.Drawing.Point(0, 113);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(0, 2, 10, 2);
            this.txtDireccion.MaxLength = 150;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(493, 22);
            this.txtDireccion.TabIndex = 5;
            // 
            // lblDPI
            // 
            this.lblDPI.BackColor = System.Drawing.Color.Transparent;
            this.lblDPI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDPI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblDPI.Location = new System.Drawing.Point(0, 138);
            this.lblDPI.Margin = new System.Windows.Forms.Padding(0);
            this.lblDPI.Name = "lblDPI";
            this.lblDPI.Size = new System.Drawing.Size(503, 18);
            this.lblDPI.TabIndex = 6;
            this.lblDPI.Text = "DPI:";
            this.lblDPI.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtDPI
            // 
            this.txtDPI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDPI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.txtDPI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDPI.ForeColor = System.Drawing.Color.White;
            this.txtDPI.Location = new System.Drawing.Point(0, 159);
            this.txtDPI.Margin = new System.Windows.Forms.Padding(0, 2, 10, 2);
            this.txtDPI.MaxLength = 13;
            this.txtDPI.Name = "txtDPI";
            this.txtDPI.Size = new System.Drawing.Size(493, 22);
            this.txtDPI.TabIndex = 7;
            // 
            // lblEdad
            // 
            this.lblEdad.BackColor = System.Drawing.Color.Transparent;
            this.lblEdad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEdad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblEdad.Location = new System.Drawing.Point(503, 0);
            this.lblEdad.Margin = new System.Windows.Forms.Padding(0);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(503, 18);
            this.lblEdad.TabIndex = 8;
            this.lblEdad.Text = "Edad:";
            this.lblEdad.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtEdad
            // 
            this.txtEdad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEdad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.txtEdad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEdad.ForeColor = System.Drawing.Color.White;
            this.txtEdad.Location = new System.Drawing.Point(503, 21);
            this.txtEdad.Margin = new System.Windows.Forms.Padding(0, 2, 10, 2);
            this.txtEdad.MaxLength = 3;
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(493, 22);
            this.txtEdad.TabIndex = 9;
            // 
            // lblNIT
            // 
            this.lblNIT.BackColor = System.Drawing.Color.Transparent;
            this.lblNIT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNIT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblNIT.Location = new System.Drawing.Point(503, 46);
            this.lblNIT.Margin = new System.Windows.Forms.Padding(0);
            this.lblNIT.Name = "lblNIT";
            this.lblNIT.Size = new System.Drawing.Size(503, 18);
            this.lblNIT.TabIndex = 10;
            this.lblNIT.Text = "NIT:";
            this.lblNIT.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtNIT
            // 
            this.txtNIT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNIT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.txtNIT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNIT.ForeColor = System.Drawing.Color.White;
            this.txtNIT.Location = new System.Drawing.Point(503, 67);
            this.txtNIT.Margin = new System.Windows.Forms.Padding(0, 2, 10, 2);
            this.txtNIT.MaxLength = 10;
            this.txtNIT.Name = "txtNIT";
            this.txtNIT.Size = new System.Drawing.Size(493, 22);
            this.txtNIT.TabIndex = 11;
            // 
            // lblTelefono
            // 
            this.lblTelefono.BackColor = System.Drawing.Color.Transparent;
            this.lblTelefono.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblTelefono.Location = new System.Drawing.Point(503, 92);
            this.lblTelefono.Margin = new System.Windows.Forms.Padding(0);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(503, 18);
            this.lblTelefono.TabIndex = 12;
            this.lblTelefono.Text = "Telefono:";
            this.lblTelefono.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTelefono.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefono.ForeColor = System.Drawing.Color.White;
            this.txtTelefono.Location = new System.Drawing.Point(503, 113);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(0, 2, 10, 2);
            this.txtTelefono.MaxLength = 10;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(493, 22);
            this.txtTelefono.TabIndex = 13;
            // 
            // lblEstado
            // 
            this.lblEstado.BackColor = System.Drawing.Color.Transparent;
            this.lblEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblEstado.Location = new System.Drawing.Point(503, 138);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(503, 18);
            this.lblEstado.TabIndex = 14;
            this.lblEstado.Text = "Estado:";
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // pnlEstado
            // 
            this.pnlEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlEstado.Controls.Add(this.rdoActivo);
            this.pnlEstado.Controls.Add(this.rdoInactivo);
            this.pnlEstado.Location = new System.Drawing.Point(503, 158);
            this.pnlEstado.Margin = new System.Windows.Forms.Padding(0, 2, 10, 2);
            this.pnlEstado.Name = "pnlEstado";
            this.pnlEstado.Size = new System.Drawing.Size(493, 23);
            this.pnlEstado.TabIndex = 15;
            // 
            // rdoActivo
            // 
            this.rdoActivo.AutoSize = true;
            this.rdoActivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.rdoActivo.Checked = true;
            this.rdoActivo.ForeColor = System.Drawing.Color.White;
            this.rdoActivo.Location = new System.Drawing.Point(2, 2);
            this.rdoActivo.Name = "rdoActivo";
            this.rdoActivo.Size = new System.Drawing.Size(65, 20);
            this.rdoActivo.TabIndex = 0;
            this.rdoActivo.TabStop = true;
            this.rdoActivo.Text = "Activo";
            this.rdoActivo.UseVisualStyleBackColor = false;
            // 
            // rdoInactivo
            // 
            this.rdoInactivo.AutoSize = true;
            this.rdoInactivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.rdoInactivo.ForeColor = System.Drawing.Color.White;
            this.rdoInactivo.Location = new System.Drawing.Point(76, 2);
            this.rdoInactivo.Name = "rdoInactivo";
            this.rdoInactivo.Size = new System.Drawing.Size(74, 20);
            this.rdoInactivo.TabIndex = 1;
            this.rdoInactivo.Text = "Inactivo";
            this.rdoInactivo.UseVisualStyleBackColor = false;
            // 
            // pnlTituloForm
            // 
            this.pnlTituloForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlTituloForm.Controls.Add(this.pnlIconoForm);
            this.pnlTituloForm.Controls.Add(this.lblTituloForm);
            this.pnlTituloForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTituloForm.Location = new System.Drawing.Point(18, 10);
            this.pnlTituloForm.Name = "pnlTituloForm";
            this.pnlTituloForm.Size = new System.Drawing.Size(1006, 52);
            this.pnlTituloForm.TabIndex = 1;
            // 
            // pnlIconoForm
            // 
            this.pnlIconoForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(52)))), ((int)(((byte)(120)))));
            this.pnlIconoForm.ColorBorde = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(52)))), ((int)(((byte)(120)))));
            this.pnlIconoForm.Controls.Add(this.lblGlyphForm);
            this.pnlIconoForm.Location = new System.Drawing.Point(0, 7);
            this.pnlIconoForm.Name = "pnlIconoForm";
            this.pnlIconoForm.Radio = 10;
            this.pnlIconoForm.Size = new System.Drawing.Size(38, 38);
            this.pnlIconoForm.TabIndex = 0;
            // 
            // lblGlyphForm
            // 
            this.lblGlyphForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(52)))), ((int)(((byte)(120)))));
            this.lblGlyphForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGlyphForm.Font = new System.Drawing.Font("Segoe MDL2 Assets", 13F);
            this.lblGlyphForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(165)))), ((int)(((byte)(250)))));
            this.lblGlyphForm.Location = new System.Drawing.Point(0, 0);
            this.lblGlyphForm.Name = "lblGlyphForm";
            this.lblGlyphForm.Size = new System.Drawing.Size(38, 38);
            this.lblGlyphForm.TabIndex = 0;
            this.lblGlyphForm.Text = "";
            this.lblGlyphForm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTituloForm
            // 
            this.lblTituloForm.AutoSize = true;
            this.lblTituloForm.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloForm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblTituloForm.Location = new System.Drawing.Point(50, 15);
            this.lblTituloForm.Name = "lblTituloForm";
            this.lblTituloForm.Size = new System.Drawing.Size(174, 28);
            this.lblTituloForm.TabIndex = 1;
            this.lblTituloForm.Text = "Datos del Cliente";
            // 
            // pnlTituloGestion
            // 
            this.pnlTituloGestion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.pnlTituloGestion.Controls.Add(this.bannerDegradado1);
            this.pnlTituloGestion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTituloGestion.Location = new System.Drawing.Point(0, 0);
            this.pnlTituloGestion.Name = "pnlTituloGestion";
            this.pnlTituloGestion.Size = new System.Drawing.Size(1042, 152);
            this.pnlTituloGestion.TabIndex = 3;
            // 
            // bannerDegradado1
            // 
            this.bannerDegradado1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.bannerDegradado1.Controls.Add(this.label1);
            this.bannerDegradado1.Controls.Add(this.label2);
            this.bannerDegradado1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bannerDegradado1.Glyph = "";
            this.bannerDegradado1.Location = new System.Drawing.Point(0, 0);
            this.bannerDegradado1.MinimumSize = new System.Drawing.Size(0, 120);
            this.bannerDegradado1.Name = "bannerDegradado1";
            this.bannerDegradado1.Radio = 14;
            this.bannerDegradado1.Size = new System.Drawing.Size(1042, 152);
            this.bannerDegradado1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.label1.Location = new System.Drawing.Point(18, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Registre o edite los datos de clientes.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(15, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(283, 41);
            this.label2.TabIndex = 0;
            this.label2.Text = "Gestión de clientes";
            // 
            // tpResumen
            // 
            this.tpResumen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.tpResumen.Controls.Add(this.tlpResumenGraficos);
            this.tpResumen.Controls.Add(this.pnlTituloResumen);
            this.tpResumen.Location = new System.Drawing.Point(4, 25);
            this.tpResumen.Name = "tpResumen";
            this.tpResumen.Size = new System.Drawing.Size(1042, 637);
            this.tpResumen.TabIndex = 2;
            this.tpResumen.Text = "Resumen";
            // 
            // tlpResumenGraficos
            // 
            this.tlpResumenGraficos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.tlpResumenGraficos.ColumnCount = 2;
            this.tlpResumenGraficos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpResumenGraficos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpResumenGraficos.Controls.Add(this.pnlCardEstado, 0, 0);
            this.tlpResumenGraficos.Controls.Add(this.pnlCardCategoria, 1, 0);
            this.tlpResumenGraficos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpResumenGraficos.Location = new System.Drawing.Point(0, 70);
            this.tlpResumenGraficos.Name = "tlpResumenGraficos";
            this.tlpResumenGraficos.RowCount = 1;
            this.tlpResumenGraficos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpResumenGraficos.Size = new System.Drawing.Size(1042, 567);
            this.tlpResumenGraficos.TabIndex = 0;
            // 
            // pnlCardEstado
            // 
            this.pnlCardEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlCardEstado.Controls.Add(this.graEstado);
            this.pnlCardEstado.Controls.Add(this.pnlTituloEstado);
            this.pnlCardEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardEstado.Location = new System.Drawing.Point(0, 0);
            this.pnlCardEstado.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.pnlCardEstado.Name = "pnlCardEstado";
            this.pnlCardEstado.Padding = new System.Windows.Forms.Padding(14, 10, 14, 10);
            this.pnlCardEstado.Size = new System.Drawing.Size(507, 567);
            this.pnlCardEstado.TabIndex = 0;
            // 
            // graEstado
            // 
            this.graEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.graEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graEstado.ForeColor = System.Drawing.Color.White;
            this.graEstado.Location = new System.Drawing.Point(14, 42);
            this.graEstado.Name = "graEstado";
            this.graEstado.Size = new System.Drawing.Size(479, 515);
            this.graEstado.TabIndex = 0;
            // 
            // pnlTituloEstado
            // 
            this.pnlTituloEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlTituloEstado.Controls.Add(this.lblIconoEstado);
            this.pnlTituloEstado.Controls.Add(this.lblTituloEstado);
            this.pnlTituloEstado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTituloEstado.Location = new System.Drawing.Point(14, 10);
            this.pnlTituloEstado.Name = "pnlTituloEstado";
            this.pnlTituloEstado.Size = new System.Drawing.Size(479, 32);
            this.pnlTituloEstado.TabIndex = 1;
            // 
            // lblIconoEstado
            // 
            this.lblIconoEstado.AutoSize = true;
            this.lblIconoEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.lblIconoEstado.Font = new System.Drawing.Font("Segoe MDL2 Assets", 13F);
            this.lblIconoEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(85)))), ((int)(((byte)(247)))));
            this.lblIconoEstado.Location = new System.Drawing.Point(0, 3);
            this.lblIconoEstado.Name = "lblIconoEstado";
            this.lblIconoEstado.Size = new System.Drawing.Size(32, 22);
            this.lblIconoEstado.TabIndex = 0;
            this.lblIconoEstado.Text = "";
            // 
            // lblTituloEstado
            // 
            this.lblTituloEstado.AutoSize = true;
            this.lblTituloEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.lblTituloEstado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTituloEstado.ForeColor = System.Drawing.Color.White;
            this.lblTituloEstado.Location = new System.Drawing.Point(28, 4);
            this.lblTituloEstado.Name = "lblTituloEstado";
            this.lblTituloEstado.Size = new System.Drawing.Size(175, 23);
            this.lblTituloEstado.TabIndex = 1;
            this.lblTituloEstado.Text = "Registros por estado";
            // 
            // pnlCardCategoria
            // 
            this.pnlCardCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlCardCategoria.Controls.Add(this.graCategoria);
            this.pnlCardCategoria.Controls.Add(this.pnlTituloCategoria);
            this.pnlCardCategoria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardCategoria.Location = new System.Drawing.Point(521, 0);
            this.pnlCardCategoria.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCardCategoria.Name = "pnlCardCategoria";
            this.pnlCardCategoria.Padding = new System.Windows.Forms.Padding(14, 10, 14, 10);
            this.pnlCardCategoria.Size = new System.Drawing.Size(521, 567);
            this.pnlCardCategoria.TabIndex = 1;
            // 
            // graCategoria
            // 
            this.graCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.graCategoria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graCategoria.ForeColor = System.Drawing.Color.White;
            this.graCategoria.Location = new System.Drawing.Point(14, 42);
            this.graCategoria.Name = "graCategoria";
            this.graCategoria.Size = new System.Drawing.Size(493, 515);
            this.graCategoria.TabIndex = 0;
            // 
            // pnlTituloCategoria
            // 
            this.pnlTituloCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlTituloCategoria.Controls.Add(this.lblIconoCategoria);
            this.pnlTituloCategoria.Controls.Add(this.lblTituloCategoria);
            this.pnlTituloCategoria.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTituloCategoria.Location = new System.Drawing.Point(14, 10);
            this.pnlTituloCategoria.Name = "pnlTituloCategoria";
            this.pnlTituloCategoria.Size = new System.Drawing.Size(493, 32);
            this.pnlTituloCategoria.TabIndex = 1;
            // 
            // lblIconoCategoria
            // 
            this.lblIconoCategoria.AutoSize = true;
            this.lblIconoCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.lblIconoCategoria.Font = new System.Drawing.Font("Segoe MDL2 Assets", 13F);
            this.lblIconoCategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(165)))), ((int)(((byte)(250)))));
            this.lblIconoCategoria.Location = new System.Drawing.Point(0, 3);
            this.lblIconoCategoria.Name = "lblIconoCategoria";
            this.lblIconoCategoria.Size = new System.Drawing.Size(32, 22);
            this.lblIconoCategoria.TabIndex = 0;
            this.lblIconoCategoria.Text = "";
            // 
            // lblTituloCategoria
            // 
            this.lblTituloCategoria.AutoSize = true;
            this.lblTituloCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.lblTituloCategoria.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTituloCategoria.ForeColor = System.Drawing.Color.White;
            this.lblTituloCategoria.Location = new System.Drawing.Point(28, 4);
            this.lblTituloCategoria.Name = "lblTituloCategoria";
            this.lblTituloCategoria.Size = new System.Drawing.Size(175, 23);
            this.lblTituloCategoria.TabIndex = 1;
            this.lblTituloCategoria.Text = "Registros por estado";
            // 
            // pnlTituloResumen
            // 
            this.pnlTituloResumen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.pnlTituloResumen.Controls.Add(this.lblTituloResumen);
            this.pnlTituloResumen.Controls.Add(this.lblSubtituloResumen);
            this.pnlTituloResumen.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTituloResumen.Location = new System.Drawing.Point(0, 0);
            this.pnlTituloResumen.Name = "pnlTituloResumen";
            this.pnlTituloResumen.Size = new System.Drawing.Size(1042, 70);
            this.pnlTituloResumen.TabIndex = 1;
            // 
            // lblTituloResumen
            // 
            this.lblTituloResumen.AutoSize = true;
            this.lblTituloResumen.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloResumen.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTituloResumen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblTituloResumen.Location = new System.Drawing.Point(0, 0);
            this.lblTituloResumen.Name = "lblTituloResumen";
            this.lblTituloResumen.Size = new System.Drawing.Size(303, 41);
            this.lblTituloResumen.TabIndex = 0;
            this.lblTituloResumen.Text = "Resumen de clientes";
            // 
            // lblSubtituloResumen
            // 
            this.lblSubtituloResumen.AutoSize = true;
            this.lblSubtituloResumen.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtituloResumen.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtituloResumen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblSubtituloResumen.Location = new System.Drawing.Point(0, 36);
            this.lblSubtituloResumen.Name = "lblSubtituloResumen";
            this.lblSubtituloResumen.Size = new System.Drawing.Size(267, 21);
            this.lblSubtituloResumen.TabIndex = 1;
            this.lblSubtituloResumen.Text = "Estadísticas y distribución de clientes.";
            // 
            // btnTabConsultar
            // 
            this.btnTabConsultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(28)))), ((int)(((byte)(76)))));
            this.btnTabConsultar.ColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.btnTabConsultar.ColorSeleccionado = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnTabConsultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabConsultar.Degradado = true;
            this.btnTabConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabConsultar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTabConsultar.ForeColor = System.Drawing.Color.White;
            this.btnTabConsultar.Location = new System.Drawing.Point(0, 6);
            this.btnTabConsultar.Name = "btnTabConsultar";
            this.btnTabConsultar.Radio = 6;
            this.btnTabConsultar.Size = new System.Drawing.Size(104, 30);
            this.btnTabConsultar.TabIndex = 0;
            this.btnTabConsultar.Text = "Consultar";
            this.btnTabConsultar.UseVisualStyleBackColor = false;
            this.btnTabConsultar.Click += new System.EventHandler(this.btnTabConsultar_Click);
            // 
            // btnTabGestionar
            // 
            this.btnTabGestionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(28)))), ((int)(((byte)(76)))));
            this.btnTabGestionar.ColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.btnTabGestionar.ColorSeleccionado = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnTabGestionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabGestionar.Degradado = true;
            this.btnTabGestionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabGestionar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTabGestionar.ForeColor = System.Drawing.Color.White;
            this.btnTabGestionar.Location = new System.Drawing.Point(108, 6);
            this.btnTabGestionar.Name = "btnTabGestionar";
            this.btnTabGestionar.Radio = 6;
            this.btnTabGestionar.Size = new System.Drawing.Size(104, 30);
            this.btnTabGestionar.TabIndex = 1;
            this.btnTabGestionar.Text = "Gestionar";
            this.btnTabGestionar.UseVisualStyleBackColor = false;
            this.btnTabGestionar.Click += new System.EventHandler(this.btnTabGestionar_Click);
            // 
            // btnTabResumen
            // 
            this.btnTabResumen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(28)))), ((int)(((byte)(76)))));
            this.btnTabResumen.ColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.btnTabResumen.ColorSeleccionado = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnTabResumen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabResumen.Degradado = true;
            this.btnTabResumen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabResumen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTabResumen.ForeColor = System.Drawing.Color.White;
            this.btnTabResumen.Location = new System.Drawing.Point(216, 6);
            this.btnTabResumen.Name = "btnTabResumen";
            this.btnTabResumen.Radio = 6;
            this.btnTabResumen.Size = new System.Drawing.Size(104, 30);
            this.btnTabResumen.TabIndex = 2;
            this.btnTabResumen.Text = "Resumen";
            this.btnTabResumen.UseVisualStyleBackColor = false;
            this.btnTabResumen.Click += new System.EventHandler(this.btnTabResumen_Click);
            // 
            // FrmClientes
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(1090, 728);
            this.Controls.Add(this.tabModulo);
            this.Controls.Add(this.pnlCabecera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmClientes";
            this.Padding = new System.Windows.Forms.Padding(20, 10, 20, 8);
            this.Text = "Clientes";
            this.pnlCabecera.ResumeLayout(false);
            this.tabModulo.ResumeLayout(false);
            this.tpConsultar.ResumeLayout(false);
            this.pnlLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.pnlPie.ResumeLayout(false);
            this.pnlPie.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbarFiltros.ResumeLayout(false);
            this.pnlFiltroEstado.ResumeLayout(false);
            this.pnlToolbarTop.ResumeLayout(false);
            this.pnlToolbarTop.PerformLayout();
            this.pnlIconoLista.ResumeLayout(false);
            this.pnlKpi.ResumeLayout(false);
            this.tlpKpi.ResumeLayout(false);
            this.pnlTituloConsulta.ResumeLayout(false);
            this.pnlTituloConsulta.PerformLayout();
            this.tpGestionar.ResumeLayout(false);
            this.pnlBarra.ResumeLayout(false);
            this.pnlFormulario.ResumeLayout(false);
            this.tlpCampos.ResumeLayout(false);
            this.tlpCampos.PerformLayout();
            this.pnlEstado.ResumeLayout(false);
            this.pnlEstado.PerformLayout();
            this.pnlTituloForm.ResumeLayout(false);
            this.pnlTituloForm.PerformLayout();
            this.pnlIconoForm.ResumeLayout(false);
            this.pnlTituloGestion.ResumeLayout(false);
            this.bannerDegradado1.ResumeLayout(false);
            this.bannerDegradado1.PerformLayout();
            this.tpResumen.ResumeLayout(false);
            this.tlpResumenGraficos.ResumeLayout(false);
            this.pnlCardEstado.ResumeLayout(false);
            this.pnlTituloEstado.ResumeLayout(false);
            this.pnlTituloEstado.PerformLayout();
            this.pnlCardCategoria.ResumeLayout(false);
            this.pnlTituloCategoria.ResumeLayout(false);
            this.pnlTituloCategoria.PerformLayout();
            this.pnlTituloResumen.ResumeLayout(false);
            this.pnlTituloResumen.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Presentacion.TabControlSinEncabezado tabModulo;
        private System.Windows.Forms.TabPage tpConsultar;
        private Presentacion.RoundedPanel pnlLista;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.Panel pnlPie;
        private System.Windows.Forms.Label lblTotalRegistros;
        private Presentacion.BotonIcono btnPagAnterior;
        private System.Windows.Forms.Panel sepPagA;
        private Presentacion.BotonIcono btnPagina;
        private System.Windows.Forms.Panel sepPagB;
        private Presentacion.BotonIcono btnPagSiguiente;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Panel pnlToolbarFiltros;
        private Presentacion.CampoBusqueda csBuscar;
        private System.Windows.Forms.Panel pnlFiltroEstado;
        private System.Windows.Forms.ComboBox cmbFiltroEstado;
        private System.Windows.Forms.Panel pnlToolbarTop;
        private Presentacion.RoundedPanel pnlIconoLista;
        private System.Windows.Forms.Label lblGlyphLista;
        private System.Windows.Forms.Label lblTituloLista;
        private Presentacion.BotonIcono btnEditar;
        private System.Windows.Forms.Panel sepToolbarA;
        private Presentacion.BotonIcono btnEliminar;
        private System.Windows.Forms.Panel sepToolbarB;
        private Presentacion.BotonIcono btnNuevo;
        private System.Windows.Forms.Panel pnlKpi;
        private System.Windows.Forms.TableLayoutPanel tlpKpi;
        private Presentacion.StatCard statTotal;
        private Presentacion.StatCard statEstado1;
        private Presentacion.StatCard statEstado2;
        private Presentacion.StatCard statExtra;
        private System.Windows.Forms.Panel pnlTituloConsulta;
        private System.Windows.Forms.Label lblTituloConsulta;
        private System.Windows.Forms.Label lblSubtituloConsulta;
        private System.Windows.Forms.TabPage tpGestionar;
        private System.Windows.Forms.Panel pnlBarra;
        private Presentacion.BotonIcono btnLimpiar;
        private System.Windows.Forms.Panel sepBarraA;
        private Presentacion.BotonIcono btnCancelar;
        private System.Windows.Forms.Panel sepBarraB;
        private Presentacion.BotonIcono btnGuardar;
        private Presentacion.RoundedPanel pnlFormulario;
        private System.Windows.Forms.TableLayoutPanel tlpCampos;
        private System.Windows.Forms.Label lblCodigoCliente;
        private System.Windows.Forms.TextBox txtCodigoCliente;
        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblDPI;
        private System.Windows.Forms.TextBox txtDPI;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.Label lblNIT;
        private System.Windows.Forms.TextBox txtNIT;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Panel pnlEstado;
        private System.Windows.Forms.RadioButton rdoActivo;
        private System.Windows.Forms.RadioButton rdoInactivo;
        private System.Windows.Forms.Panel pnlTituloForm;
        private Presentacion.RoundedPanel pnlIconoForm;
        private System.Windows.Forms.Label lblGlyphForm;
        private System.Windows.Forms.Label lblTituloForm;
        private System.Windows.Forms.Panel pnlTituloGestion;
        private System.Windows.Forms.TabPage tpResumen;
        private System.Windows.Forms.TableLayoutPanel tlpResumenGraficos;
        private Presentacion.RoundedPanel pnlCardEstado;
        private Presentacion.GraficoDona graEstado;
        private System.Windows.Forms.Panel pnlTituloEstado;
        private System.Windows.Forms.Label lblIconoEstado;
        private System.Windows.Forms.Label lblTituloEstado;
        private Presentacion.RoundedPanel pnlCardCategoria;
        private Presentacion.GraficoBarras graCategoria;
        private System.Windows.Forms.Panel pnlTituloCategoria;
        private System.Windows.Forms.Label lblIconoCategoria;
        private System.Windows.Forms.Label lblTituloCategoria;
        private System.Windows.Forms.Panel pnlTituloResumen;
        private System.Windows.Forms.Label lblTituloResumen;
        private System.Windows.Forms.Label lblSubtituloResumen;
        private System.Windows.Forms.Panel pnlCabecera;
        private Presentacion.BotonIcono btnTabConsultar;
        private Presentacion.BotonIcono btnTabGestionar;
        private Presentacion.BotonIcono btnTabResumen;
        private BannerDegradado bannerDegradado1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
