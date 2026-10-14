namespace Presentacion
{
    partial class FrmInventarios
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
            this.tabModulo = new Presentacion.TabControlSinEncabezado();
            this.tpConsultar = new System.Windows.Forms.TabPage();
            this.pnlLista = new Presentacion.RoundedPanel();
            this.dgvInventarios = new System.Windows.Forms.DataGridView();
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
            this.lblFiltroEstado = new System.Windows.Forms.Label();
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
            this.lblCodigoInventario = new System.Windows.Forms.Label();
            this.txtCodigoInventario = new System.Windows.Forms.TextBox();
            this.lblCodigoSucursal = new System.Windows.Forms.Label();
            this.cmbCodigoSucursal = new System.Windows.Forms.ComboBox();
            this.lblCodigoMaterial = new System.Windows.Forms.Label();
            this.cmbCodigoMaterial = new System.Windows.Forms.ComboBox();
            this.lblNombreProducto = new System.Windows.Forms.Label();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.lblTipoProducto = new System.Windows.Forms.Label();
            this.txtTipoProducto = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.lblPrecioCompra = new System.Windows.Forms.Label();
            this.txtPrecioCompra = new System.Windows.Forms.TextBox();
            this.lblFechaAlmacenamiento = new System.Windows.Forms.Label();
            this.dtpFechaAlmacenamiento = new System.Windows.Forms.DateTimePicker();
            this.lblEstado = new System.Windows.Forms.Label();
            this.pnlEstado = new System.Windows.Forms.Panel();
            this.rdoActivo = new System.Windows.Forms.RadioButton();
            this.rdoInactivo = new System.Windows.Forms.RadioButton();
            this.pnlTituloForm = new System.Windows.Forms.Panel();
            this.pnlIconoForm = new Presentacion.RoundedPanel();
            this.lblGlyphForm = new System.Windows.Forms.Label();
            this.lblTituloForm = new System.Windows.Forms.Label();
            this.pnlTituloGestion = new System.Windows.Forms.Panel();
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
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this.btnTabConsultar = new Presentacion.BotonIcono();
            this.btnTabGestionar = new Presentacion.BotonIcono();
            this.btnTabResumen = new Presentacion.BotonIcono();
            this.bannerDegradado1 = new Presentacion.BannerDegradado();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabModulo.SuspendLayout();
            this.tpConsultar.SuspendLayout();
            this.pnlLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventarios)).BeginInit();
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
            this.tpResumen.SuspendLayout();
            this.tlpResumenGraficos.SuspendLayout();
            this.pnlCardEstado.SuspendLayout();
            this.pnlTituloEstado.SuspendLayout();
            this.pnlCardCategoria.SuspendLayout();
            this.pnlTituloCategoria.SuspendLayout();
            this.pnlTituloResumen.SuspendLayout();
            this.pnlCabecera.SuspendLayout();
            this.bannerDegradado1.SuspendLayout();
            this.SuspendLayout();
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
            this.tabModulo.Size = new System.Drawing.Size(1067, 720);
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
            this.tpConsultar.Size = new System.Drawing.Size(1025, 620);
            this.tpConsultar.TabIndex = 0;
            this.tpConsultar.Text = "Consultar";
            // 
            // pnlLista
            // 
            this.pnlLista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlLista.Controls.Add(this.dgvInventarios);
            this.pnlLista.Controls.Add(this.pnlPie);
            this.pnlLista.Controls.Add(this.pnlToolbar);
            this.pnlLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLista.Location = new System.Drawing.Point(0, 202);
            this.pnlLista.Name = "pnlLista";
            this.pnlLista.Padding = new System.Windows.Forms.Padding(16, 8, 16, 4);
            this.pnlLista.Size = new System.Drawing.Size(1025, 418);
            this.pnlLista.TabIndex = 0;
            // 
            // dgvInventarios
            // 
            this.dgvInventarios.ColumnHeadersHeight = 29;
            this.dgvInventarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventarios.Location = new System.Drawing.Point(16, 108);
            this.dgvInventarios.Name = "dgvInventarios";
            this.dgvInventarios.RowHeadersWidth = 51;
            this.dgvInventarios.Size = new System.Drawing.Size(993, 264);
            this.dgvInventarios.TabIndex = 0;
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
            this.pnlPie.Location = new System.Drawing.Point(16, 372);
            this.pnlPie.Name = "pnlPie";
            this.pnlPie.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.pnlPie.Size = new System.Drawing.Size(993, 42);
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
            this.btnPagAnterior.Location = new System.Drawing.Point(885, 6);
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
            this.sepPagA.Location = new System.Drawing.Point(917, 6);
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
            this.btnPagina.Location = new System.Drawing.Point(923, 6);
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
            this.sepPagB.Location = new System.Drawing.Point(955, 6);
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
            this.btnPagSiguiente.Location = new System.Drawing.Point(961, 6);
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
            this.pnlToolbar.Size = new System.Drawing.Size(993, 100);
            this.pnlToolbar.TabIndex = 2;
            // 
            // pnlToolbarFiltros
            // 
            this.pnlToolbarFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlToolbarFiltros.Controls.Add(this.csBuscar);
            this.pnlToolbarFiltros.Controls.Add(this.lblFiltroEstado);
            this.pnlToolbarFiltros.Controls.Add(this.pnlFiltroEstado);
            this.pnlToolbarFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbarFiltros.Location = new System.Drawing.Point(0, 54);
            this.pnlToolbarFiltros.Name = "pnlToolbarFiltros";
            this.pnlToolbarFiltros.Padding = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.pnlToolbarFiltros.Size = new System.Drawing.Size(993, 46);
            this.pnlToolbarFiltros.TabIndex = 0;
            // 
            // csBuscar
            // 
            this.csBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.csBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.csBuscar.Location = new System.Drawing.Point(0, 0);
            this.csBuscar.Name = "csBuscar";
            this.csBuscar.Placeholder = "Buscar por producto o código...";
            this.csBuscar.Radio = 8;
            this.csBuscar.Size = new System.Drawing.Size(790, 34);
            this.csBuscar.TabIndex = 0;
            this.csBuscar.EnterPresionado += new System.EventHandler(this.csBuscar_EnterPresionado);
            // 
            // lblFiltroEstado
            // 
            this.lblFiltroEstado.AutoSize = true;
            this.lblFiltroEstado.BackColor = System.Drawing.Color.Transparent;
            this.lblFiltroEstado.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblFiltroEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblFiltroEstado.Location = new System.Drawing.Point(790, 0);
            this.lblFiltroEstado.Name = "lblFiltroEstado";
            this.lblFiltroEstado.Padding = new System.Windows.Forms.Padding(14, 0, 6, 0);
            this.lblFiltroEstado.Size = new System.Drawing.Size(73, 16);
            this.lblFiltroEstado.TabIndex = 1;
            this.lblFiltroEstado.Text = "Estado:";
            this.lblFiltroEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlFiltroEstado
            // 
            this.pnlFiltroEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlFiltroEstado.Controls.Add(this.cmbFiltroEstado);
            this.pnlFiltroEstado.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFiltroEstado.Location = new System.Drawing.Point(863, 0);
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
            this.cmbFiltroEstado.Location = new System.Drawing.Point(0, 5);
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
            this.pnlToolbarTop.Size = new System.Drawing.Size(993, 54);
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
            this.lblGlyphLista.Text = "";
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
            this.lblTituloLista.Size = new System.Drawing.Size(207, 25);
            this.lblTituloLista.TabIndex = 1;
            this.lblTituloLista.Text = "Listado de inventarios";
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
            this.btnEditar.Location = new System.Drawing.Point(759, 8);
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
            this.sepToolbarA.Location = new System.Drawing.Point(803, 8);
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
            this.btnEliminar.Location = new System.Drawing.Point(811, 8);
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
            this.sepToolbarB.Location = new System.Drawing.Point(855, 8);
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
            this.btnNuevo.Location = new System.Drawing.Point(863, 8);
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
            this.pnlKpi.Size = new System.Drawing.Size(1025, 132);
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
            this.tlpKpi.Size = new System.Drawing.Size(1025, 120);
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
            this.statTotal.Size = new System.Drawing.Size(242, 120);
            this.statTotal.Subtitulo = "Registros";
            this.statTotal.TabIndex = 0;
            this.statTotal.Titulo = "Total de inventarios";
            // 
            // statEstado1
            // 
            this.statEstado1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.statEstado1.ColorFin = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(40)))), ((int)(((byte)(120)))));
            this.statEstado1.ColorInicio = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(62)))), ((int)(((byte)(140)))));
            this.statEstado1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statEstado1.Glyph = "";
            this.statEstado1.Location = new System.Drawing.Point(256, 0);
            this.statEstado1.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.statEstado1.Name = "statEstado1";
            this.statEstado1.Size = new System.Drawing.Size(242, 120);
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
            this.statEstado2.Location = new System.Drawing.Point(512, 0);
            this.statEstado2.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.statEstado2.Name = "statEstado2";
            this.statEstado2.Size = new System.Drawing.Size(242, 120);
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
            this.statExtra.Location = new System.Drawing.Point(768, 0);
            this.statExtra.Margin = new System.Windows.Forms.Padding(0);
            this.statExtra.Name = "statExtra";
            this.statExtra.Size = new System.Drawing.Size(257, 120);
            this.statExtra.TabIndex = 3;
            this.statExtra.Titulo = "Existencias";
            // 
            // pnlTituloConsulta
            // 
            this.pnlTituloConsulta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.pnlTituloConsulta.Controls.Add(this.lblTituloConsulta);
            this.pnlTituloConsulta.Controls.Add(this.lblSubtituloConsulta);
            this.pnlTituloConsulta.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTituloConsulta.Location = new System.Drawing.Point(0, 0);
            this.pnlTituloConsulta.Name = "pnlTituloConsulta";
            this.pnlTituloConsulta.Size = new System.Drawing.Size(1025, 70);
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
            this.lblTituloConsulta.Size = new System.Drawing.Size(349, 41);
            this.lblTituloConsulta.TabIndex = 0;
            this.lblTituloConsulta.Text = "Consulta de inventarios";
            // 
            // lblSubtituloConsulta
            // 
            this.lblSubtituloConsulta.AutoSize = true;
            this.lblSubtituloConsulta.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtituloConsulta.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtituloConsulta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblSubtituloConsulta.Location = new System.Drawing.Point(0, 36);
            this.lblSubtituloConsulta.Name = "lblSubtituloConsulta";
            this.lblSubtituloConsulta.Size = new System.Drawing.Size(339, 21);
            this.lblSubtituloConsulta.TabIndex = 1;
            this.lblSubtituloConsulta.Text = "Consulte y administre inventarios de la agencia.";
            // 
            // tpGestionar
            // 
            this.tpGestionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.tpGestionar.Controls.Add(this.pnlBarra);
            this.tpGestionar.Controls.Add(this.pnlFormulario);
            this.tpGestionar.Controls.Add(this.pnlTituloGestion);
            this.tpGestionar.Location = new System.Drawing.Point(4, 25);
            this.tpGestionar.Name = "tpGestionar";
            this.tpGestionar.Size = new System.Drawing.Size(1059, 691);
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
            this.pnlBarra.Location = new System.Drawing.Point(0, 466);
            this.pnlBarra.Name = "pnlBarra";
            this.pnlBarra.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.pnlBarra.Size = new System.Drawing.Size(1059, 58);
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
            this.btnLimpiar.Location = new System.Drawing.Point(695, 12);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(104, 46);
            this.btnLimpiar.TabIndex = 0;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // sepBarraA
            // 
            this.sepBarraA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.sepBarraA.Dock = System.Windows.Forms.DockStyle.Right;
            this.sepBarraA.Location = new System.Drawing.Point(799, 12);
            this.sepBarraA.Name = "sepBarraA";
            this.sepBarraA.Size = new System.Drawing.Size(8, 46);
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
            this.btnCancelar.Location = new System.Drawing.Point(807, 12);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(112, 46);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // sepBarraB
            // 
            this.sepBarraB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.sepBarraB.Dock = System.Windows.Forms.DockStyle.Right;
            this.sepBarraB.Location = new System.Drawing.Point(919, 12);
            this.sepBarraB.Name = "sepBarraB";
            this.sepBarraB.Size = new System.Drawing.Size(8, 46);
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
            this.btnGuardar.Location = new System.Drawing.Point(927, 12);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(132, 46);
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
            this.pnlFormulario.Size = new System.Drawing.Size(1059, 314);
            this.pnlFormulario.TabIndex = 2;
            // 
            // tlpCampos
            // 
            this.tlpCampos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.tlpCampos.ColumnCount = 2;
            this.tlpCampos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCampos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCampos.Controls.Add(this.lblCodigoInventario, 0, 0);
            this.tlpCampos.Controls.Add(this.txtCodigoInventario, 0, 1);
            this.tlpCampos.Controls.Add(this.lblCodigoSucursal, 0, 2);
            this.tlpCampos.Controls.Add(this.cmbCodigoSucursal, 0, 3);
            this.tlpCampos.Controls.Add(this.lblCodigoMaterial, 0, 4);
            this.tlpCampos.Controls.Add(this.cmbCodigoMaterial, 0, 5);
            this.tlpCampos.Controls.Add(this.lblNombreProducto, 0, 6);
            this.tlpCampos.Controls.Add(this.txtNombreProducto, 0, 7);
            this.tlpCampos.Controls.Add(this.lblTipoProducto, 0, 8);
            this.tlpCampos.Controls.Add(this.txtTipoProducto, 0, 9);
            this.tlpCampos.Controls.Add(this.lblStock, 1, 0);
            this.tlpCampos.Controls.Add(this.txtStock, 1, 1);
            this.tlpCampos.Controls.Add(this.lblPrecioCompra, 1, 2);
            this.tlpCampos.Controls.Add(this.txtPrecioCompra, 1, 3);
            this.tlpCampos.Controls.Add(this.lblFechaAlmacenamiento, 1, 4);
            this.tlpCampos.Controls.Add(this.dtpFechaAlmacenamiento, 1, 5);
            this.tlpCampos.Controls.Add(this.lblEstado, 1, 6);
            this.tlpCampos.Controls.Add(this.pnlEstado, 1, 7);
            this.tlpCampos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCampos.Location = new System.Drawing.Point(18, 62);
            this.tlpCampos.Name = "tlpCampos";
            this.tlpCampos.RowCount = 11;
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCampos.Size = new System.Drawing.Size(1023, 246);
            this.tlpCampos.TabIndex = 0;
            // 
            // lblCodigoInventario
            // 
            this.lblCodigoInventario.BackColor = System.Drawing.Color.Transparent;
            this.lblCodigoInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCodigoInventario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblCodigoInventario.Location = new System.Drawing.Point(0, 0);
            this.lblCodigoInventario.Margin = new System.Windows.Forms.Padding(0);
            this.lblCodigoInventario.Name = "lblCodigoInventario";
            this.lblCodigoInventario.Size = new System.Drawing.Size(511, 18);
            this.lblCodigoInventario.TabIndex = 0;
            this.lblCodigoInventario.Text = "CodigoInventario:";
            this.lblCodigoInventario.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtCodigoInventario
            // 
            this.txtCodigoInventario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodigoInventario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.txtCodigoInventario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoInventario.ForeColor = System.Drawing.Color.White;
            this.txtCodigoInventario.Location = new System.Drawing.Point(0, 21);
            this.txtCodigoInventario.Margin = new System.Windows.Forms.Padding(0, 2, 10, 2);
            this.txtCodigoInventario.Name = "txtCodigoInventario";
            this.txtCodigoInventario.ReadOnly = true;
            this.txtCodigoInventario.Size = new System.Drawing.Size(501, 22);
            this.txtCodigoInventario.TabIndex = 1;
            // 
            // lblCodigoSucursal
            // 
            this.lblCodigoSucursal.BackColor = System.Drawing.Color.Transparent;
            this.lblCodigoSucursal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCodigoSucursal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblCodigoSucursal.Location = new System.Drawing.Point(0, 46);
            this.lblCodigoSucursal.Margin = new System.Windows.Forms.Padding(0);
            this.lblCodigoSucursal.Name = "lblCodigoSucursal";
            this.lblCodigoSucursal.Size = new System.Drawing.Size(511, 18);
            this.lblCodigoSucursal.TabIndex = 2;
            this.lblCodigoSucursal.Text = "CodigoSucursal:";
            this.lblCodigoSucursal.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cmbCodigoSucursal
            // 
            this.cmbCodigoSucursal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCodigoSucursal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.cmbCodigoSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCodigoSucursal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCodigoSucursal.ForeColor = System.Drawing.Color.White;
            this.cmbCodigoSucursal.Location = new System.Drawing.Point(0, 66);
            this.cmbCodigoSucursal.Margin = new System.Windows.Forms.Padding(0, 2, 10, 2);
            this.cmbCodigoSucursal.Name = "cmbCodigoSucursal";
            this.cmbCodigoSucursal.Size = new System.Drawing.Size(501, 24);
            this.cmbCodigoSucursal.TabIndex = 3;
            // 
            // lblCodigoMaterial
            // 
            this.lblCodigoMaterial.BackColor = System.Drawing.Color.Transparent;
            this.lblCodigoMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCodigoMaterial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblCodigoMaterial.Location = new System.Drawing.Point(0, 92);
            this.lblCodigoMaterial.Margin = new System.Windows.Forms.Padding(0);
            this.lblCodigoMaterial.Name = "lblCodigoMaterial";
            this.lblCodigoMaterial.Size = new System.Drawing.Size(511, 18);
            this.lblCodigoMaterial.TabIndex = 4;
            this.lblCodigoMaterial.Text = "CodigoMaterial:";
            this.lblCodigoMaterial.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cmbCodigoMaterial
            // 
            this.cmbCodigoMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCodigoMaterial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.cmbCodigoMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCodigoMaterial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCodigoMaterial.ForeColor = System.Drawing.Color.White;
            this.cmbCodigoMaterial.Location = new System.Drawing.Point(0, 112);
            this.cmbCodigoMaterial.Margin = new System.Windows.Forms.Padding(0, 2, 10, 2);
            this.cmbCodigoMaterial.Name = "cmbCodigoMaterial";
            this.cmbCodigoMaterial.Size = new System.Drawing.Size(501, 24);
            this.cmbCodigoMaterial.TabIndex = 5;
            // 
            // lblNombreProducto
            // 
            this.lblNombreProducto.BackColor = System.Drawing.Color.Transparent;
            this.lblNombreProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNombreProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblNombreProducto.Location = new System.Drawing.Point(0, 138);
            this.lblNombreProducto.Margin = new System.Windows.Forms.Padding(0);
            this.lblNombreProducto.Name = "lblNombreProducto";
            this.lblNombreProducto.Size = new System.Drawing.Size(511, 18);
            this.lblNombreProducto.TabIndex = 6;
            this.lblNombreProducto.Text = "NombreProducto:";
            this.lblNombreProducto.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombreProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.txtNombreProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreProducto.ForeColor = System.Drawing.Color.White;
            this.txtNombreProducto.Location = new System.Drawing.Point(0, 159);
            this.txtNombreProducto.Margin = new System.Windows.Forms.Padding(0, 2, 10, 2);
            this.txtNombreProducto.MaxLength = 45;
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Size = new System.Drawing.Size(501, 22);
            this.txtNombreProducto.TabIndex = 7;
            // 
            // lblTipoProducto
            // 
            this.lblTipoProducto.BackColor = System.Drawing.Color.Transparent;
            this.lblTipoProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTipoProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblTipoProducto.Location = new System.Drawing.Point(0, 184);
            this.lblTipoProducto.Margin = new System.Windows.Forms.Padding(0);
            this.lblTipoProducto.Name = "lblTipoProducto";
            this.lblTipoProducto.Size = new System.Drawing.Size(511, 18);
            this.lblTipoProducto.TabIndex = 8;
            this.lblTipoProducto.Text = "TipoProducto:";
            this.lblTipoProducto.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtTipoProducto
            // 
            this.txtTipoProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTipoProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.txtTipoProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTipoProducto.ForeColor = System.Drawing.Color.White;
            this.txtTipoProducto.Location = new System.Drawing.Point(0, 205);
            this.txtTipoProducto.Margin = new System.Windows.Forms.Padding(0, 2, 10, 2);
            this.txtTipoProducto.MaxLength = 45;
            this.txtTipoProducto.Name = "txtTipoProducto";
            this.txtTipoProducto.Size = new System.Drawing.Size(501, 22);
            this.txtTipoProducto.TabIndex = 9;
            // 
            // lblStock
            // 
            this.lblStock.BackColor = System.Drawing.Color.Transparent;
            this.lblStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblStock.Location = new System.Drawing.Point(511, 0);
            this.lblStock.Margin = new System.Windows.Forms.Padding(0);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(512, 18);
            this.lblStock.TabIndex = 10;
            this.lblStock.Text = "Stock:";
            this.lblStock.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtStock
            // 
            this.txtStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.txtStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStock.ForeColor = System.Drawing.Color.White;
            this.txtStock.Location = new System.Drawing.Point(511, 21);
            this.txtStock.Margin = new System.Windows.Forms.Padding(0, 2, 10, 2);
            this.txtStock.MaxLength = 10;
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(502, 22);
            this.txtStock.TabIndex = 11;
            // 
            // lblPrecioCompra
            // 
            this.lblPrecioCompra.BackColor = System.Drawing.Color.Transparent;
            this.lblPrecioCompra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPrecioCompra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblPrecioCompra.Location = new System.Drawing.Point(511, 46);
            this.lblPrecioCompra.Margin = new System.Windows.Forms.Padding(0);
            this.lblPrecioCompra.Name = "lblPrecioCompra";
            this.lblPrecioCompra.Size = new System.Drawing.Size(512, 18);
            this.lblPrecioCompra.TabIndex = 12;
            this.lblPrecioCompra.Text = "PrecioCompra:";
            this.lblPrecioCompra.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtPrecioCompra
            // 
            this.txtPrecioCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrecioCompra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.txtPrecioCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecioCompra.ForeColor = System.Drawing.Color.White;
            this.txtPrecioCompra.Location = new System.Drawing.Point(511, 67);
            this.txtPrecioCompra.Margin = new System.Windows.Forms.Padding(0, 2, 10, 2);
            this.txtPrecioCompra.MaxLength = 15;
            this.txtPrecioCompra.Name = "txtPrecioCompra";
            this.txtPrecioCompra.Size = new System.Drawing.Size(502, 22);
            this.txtPrecioCompra.TabIndex = 13;
            // 
            // lblFechaAlmacenamiento
            // 
            this.lblFechaAlmacenamiento.BackColor = System.Drawing.Color.Transparent;
            this.lblFechaAlmacenamiento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFechaAlmacenamiento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblFechaAlmacenamiento.Location = new System.Drawing.Point(511, 92);
            this.lblFechaAlmacenamiento.Margin = new System.Windows.Forms.Padding(0);
            this.lblFechaAlmacenamiento.Name = "lblFechaAlmacenamiento";
            this.lblFechaAlmacenamiento.Size = new System.Drawing.Size(512, 18);
            this.lblFechaAlmacenamiento.TabIndex = 14;
            this.lblFechaAlmacenamiento.Text = "FechaAlmacenamiento:";
            this.lblFechaAlmacenamiento.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // dtpFechaAlmacenamiento
            // 
            this.dtpFechaAlmacenamiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFechaAlmacenamiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaAlmacenamiento.Location = new System.Drawing.Point(511, 113);
            this.dtpFechaAlmacenamiento.Margin = new System.Windows.Forms.Padding(0, 2, 10, 2);
            this.dtpFechaAlmacenamiento.Name = "dtpFechaAlmacenamiento";
            this.dtpFechaAlmacenamiento.Size = new System.Drawing.Size(502, 22);
            this.dtpFechaAlmacenamiento.TabIndex = 15;
            // 
            // lblEstado
            // 
            this.lblEstado.BackColor = System.Drawing.Color.Transparent;
            this.lblEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblEstado.Location = new System.Drawing.Point(511, 138);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(512, 18);
            this.lblEstado.TabIndex = 16;
            this.lblEstado.Text = "Estado:";
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // pnlEstado
            // 
            this.pnlEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlEstado.Controls.Add(this.rdoActivo);
            this.pnlEstado.Controls.Add(this.rdoInactivo);
            this.pnlEstado.Location = new System.Drawing.Point(511, 158);
            this.pnlEstado.Margin = new System.Windows.Forms.Padding(0, 2, 10, 2);
            this.pnlEstado.Name = "pnlEstado";
            this.pnlEstado.Size = new System.Drawing.Size(502, 23);
            this.pnlEstado.TabIndex = 17;
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
            this.pnlTituloForm.Size = new System.Drawing.Size(1023, 52);
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
            this.lblGlyphForm.Text = "";
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
            this.lblTituloForm.Size = new System.Drawing.Size(205, 28);
            this.lblTituloForm.TabIndex = 1;
            this.lblTituloForm.Text = "Datos del Inventario";
            // 
            // pnlTituloGestion
            // 
            this.pnlTituloGestion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.pnlTituloGestion.Controls.Add(this.bannerDegradado1);
            this.pnlTituloGestion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTituloGestion.Location = new System.Drawing.Point(0, 0);
            this.pnlTituloGestion.Name = "pnlTituloGestion";
            this.pnlTituloGestion.Size = new System.Drawing.Size(1059, 152);
            this.pnlTituloGestion.TabIndex = 3;
            // 
            // tpResumen
            // 
            this.tpResumen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.tpResumen.Controls.Add(this.tlpResumenGraficos);
            this.tpResumen.Controls.Add(this.pnlTituloResumen);
            this.tpResumen.Location = new System.Drawing.Point(4, 25);
            this.tpResumen.Name = "tpResumen";
            this.tpResumen.Size = new System.Drawing.Size(872, 531);
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
            this.tlpResumenGraficos.Size = new System.Drawing.Size(872, 461);
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
            this.pnlCardEstado.Size = new System.Drawing.Size(422, 461);
            this.pnlCardEstado.TabIndex = 0;
            // 
            // graEstado
            // 
            this.graEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.graEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graEstado.ForeColor = System.Drawing.Color.White;
            this.graEstado.Location = new System.Drawing.Point(14, 42);
            this.graEstado.Name = "graEstado";
            this.graEstado.Size = new System.Drawing.Size(394, 409);
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
            this.pnlTituloEstado.Size = new System.Drawing.Size(394, 32);
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
            this.pnlCardCategoria.Location = new System.Drawing.Point(436, 0);
            this.pnlCardCategoria.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCardCategoria.Name = "pnlCardCategoria";
            this.pnlCardCategoria.Padding = new System.Windows.Forms.Padding(14, 10, 14, 10);
            this.pnlCardCategoria.Size = new System.Drawing.Size(436, 461);
            this.pnlCardCategoria.TabIndex = 1;
            // 
            // graCategoria
            // 
            this.graCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.graCategoria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graCategoria.ForeColor = System.Drawing.Color.White;
            this.graCategoria.Location = new System.Drawing.Point(14, 42);
            this.graCategoria.Name = "graCategoria";
            this.graCategoria.Size = new System.Drawing.Size(408, 409);
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
            this.pnlTituloCategoria.Size = new System.Drawing.Size(408, 32);
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
            this.lblTituloCategoria.Size = new System.Drawing.Size(266, 23);
            this.lblTituloCategoria.TabIndex = 1;
            this.lblTituloCategoria.Text = "Inventario por tipo de producto";
            // 
            // pnlTituloResumen
            // 
            this.pnlTituloResumen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.pnlTituloResumen.Controls.Add(this.lblTituloResumen);
            this.pnlTituloResumen.Controls.Add(this.lblSubtituloResumen);
            this.pnlTituloResumen.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTituloResumen.Location = new System.Drawing.Point(0, 0);
            this.pnlTituloResumen.Name = "pnlTituloResumen";
            this.pnlTituloResumen.Size = new System.Drawing.Size(872, 70);
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
            this.lblTituloResumen.Size = new System.Drawing.Size(353, 41);
            this.lblTituloResumen.TabIndex = 0;
            this.lblTituloResumen.Text = "Resumen de inventarios";
            // 
            // lblSubtituloResumen
            // 
            this.lblSubtituloResumen.AutoSize = true;
            this.lblSubtituloResumen.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtituloResumen.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtituloResumen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblSubtituloResumen.Location = new System.Drawing.Point(0, 36);
            this.lblSubtituloResumen.Name = "lblSubtituloResumen";
            this.lblSubtituloResumen.Size = new System.Drawing.Size(292, 21);
            this.lblSubtituloResumen.TabIndex = 1;
            this.lblSubtituloResumen.Text = "Estadísticas y distribución de inventarios.";
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
            this.pnlCabecera.Size = new System.Drawing.Size(1067, 44);
            this.pnlCabecera.TabIndex = 1;
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
            // bannerDegradado1
            // 
            this.bannerDegradado1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.bannerDegradado1.Controls.Add(this.label1);
            this.bannerDegradado1.Controls.Add(this.label2);
            this.bannerDegradado1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bannerDegradado1.Glyph = "";
            this.bannerDegradado1.Location = new System.Drawing.Point(0, 0);
            this.bannerDegradado1.MinimumSize = new System.Drawing.Size(0, 120);
            this.bannerDegradado1.Name = "bannerDegradado1";
            this.bannerDegradado1.Radio = 14;
            this.bannerDegradado1.Size = new System.Drawing.Size(1059, 152);
            this.bannerDegradado1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.label1.Location = new System.Drawing.Point(18, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Registre o edite los datos de inventarios.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(15, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(333, 41);
            this.label2.TabIndex = 0;
            this.label2.Text = "Gestión de inventarios";
            // 
            // FrmInventarios
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(1107, 782);
            this.Controls.Add(this.tabModulo);
            this.Controls.Add(this.pnlCabecera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmInventarios";
            this.Padding = new System.Windows.Forms.Padding(20, 10, 20, 8);
            this.Text = "Inventarios";
            this.tabModulo.ResumeLayout(false);
            this.tpConsultar.ResumeLayout(false);
            this.pnlLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventarios)).EndInit();
            this.pnlPie.ResumeLayout(false);
            this.pnlPie.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbarFiltros.ResumeLayout(false);
            this.pnlToolbarFiltros.PerformLayout();
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
            this.pnlCabecera.ResumeLayout(false);
            this.bannerDegradado1.ResumeLayout(false);
            this.bannerDegradado1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Presentacion.TabControlSinEncabezado tabModulo;
        private System.Windows.Forms.TabPage tpConsultar;
        private Presentacion.RoundedPanel pnlLista;
        private System.Windows.Forms.DataGridView dgvInventarios;
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
        private System.Windows.Forms.Label lblFiltroEstado;
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
        private System.Windows.Forms.Label lblCodigoInventario;
        private System.Windows.Forms.TextBox txtCodigoInventario;
        private System.Windows.Forms.Label lblCodigoSucursal;
        private System.Windows.Forms.ComboBox cmbCodigoSucursal;
        private System.Windows.Forms.Label lblCodigoMaterial;
        private System.Windows.Forms.ComboBox cmbCodigoMaterial;
        private System.Windows.Forms.Label lblNombreProducto;
        private System.Windows.Forms.TextBox txtNombreProducto;
        private System.Windows.Forms.Label lblTipoProducto;
        private System.Windows.Forms.TextBox txtTipoProducto;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label lblPrecioCompra;
        private System.Windows.Forms.TextBox txtPrecioCompra;
        private System.Windows.Forms.Label lblFechaAlmacenamiento;
        private System.Windows.Forms.DateTimePicker dtpFechaAlmacenamiento;
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
