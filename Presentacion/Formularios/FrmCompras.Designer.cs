namespace Presentacion
{
    partial class FrmCompras
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
            this.dgvCompras = new System.Windows.Forms.DataGridView();
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
            this.pnlDetalle = new Presentacion.RoundedPanel();
            this.dgvDetalleCompra = new System.Windows.Forms.DataGridView();
            this.tlpDetalle = new System.Windows.Forms.TableLayoutPanel();
            this.lblCodigoDetalleCompra = new System.Windows.Forms.Label();
            this.txtCodigoDetalleCompra = new System.Windows.Forms.TextBox();
            this.lblTipoDeCompra = new System.Windows.Forms.Label();
            this.txtTipoDeCompra = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblPrecioUnitario = new System.Windows.Forms.Label();
            this.txtPrecioUnitario = new System.Windows.Forms.TextBox();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.lblDescuentoCompra = new System.Windows.Forms.Label();
            this.txtDescuentoCompra = new System.Windows.Forms.TextBox();
            this.lblEstadoDetalle = new System.Windows.Forms.Label();
            this.pnlEstadoDetalle = new System.Windows.Forms.Panel();
            this.rdoActivoDetalle = new System.Windows.Forms.RadioButton();
            this.rdoInactivoDetalle = new System.Windows.Forms.RadioButton();
            this.btnAgregarDetalle = new Presentacion.BotonIcono();
            this.pnlTituloDetalle = new System.Windows.Forms.Panel();
            this.pnlIconoDetalle = new Presentacion.RoundedPanel();
            this.lblGlyphDetalle = new System.Windows.Forms.Label();
            this.lblTituloDetalle = new System.Windows.Forms.Label();
            this.pnlBarra = new System.Windows.Forms.Panel();
            this.lblSubtotalDetalle = new System.Windows.Forms.Label();
            this.lblDescuentoDetalle = new System.Windows.Forms.Label();
            this.lblTotalDetalle = new System.Windows.Forms.Label();
            this.btnLimpiar = new Presentacion.BotonIcono();
            this.sepBarraA = new System.Windows.Forms.Panel();
            this.btnCancelar = new Presentacion.BotonIcono();
            this.sepBarraB = new System.Windows.Forms.Panel();
            this.btnGuardar = new Presentacion.BotonIcono();
            this.pnlEncabezadoWrap = new System.Windows.Forms.Panel();
            this.pnlFormulario = new Presentacion.RoundedPanel();
            this.tlpCampos = new System.Windows.Forms.TableLayoutPanel();
            this.lblCodigoCompra = new System.Windows.Forms.Label();
            this.txtCodigoCompra = new System.Windows.Forms.TextBox();
            this.lblCodigoProveedor = new System.Windows.Forms.Label();
            this.cmbCodigoProveedor = new System.Windows.Forms.ComboBox();
            this.lblCodigoMaterial = new System.Windows.Forms.Label();
            this.cmbCodigoMaterial = new System.Windows.Forms.ComboBox();
            this.lblCantidadComprada = new System.Windows.Forms.Label();
            this.txtCantidadComprada = new System.Windows.Forms.TextBox();
            this.lblTotalCompra = new System.Windows.Forms.Label();
            this.txtTotalCompra = new System.Windows.Forms.TextBox();
            this.lblFechaCompra = new System.Windows.Forms.Label();
            this.dtpFechaCompra = new System.Windows.Forms.DateTimePicker();
            this.lblFechaEntrega = new System.Windows.Forms.Label();
            this.dtpFechaEntrega = new System.Windows.Forms.DateTimePicker();
            this.lblEstado = new System.Windows.Forms.Label();
            this.pnlEstado = new System.Windows.Forms.Panel();
            this.rdoActivo = new System.Windows.Forms.RadioButton();
            this.rdoInactivo = new System.Windows.Forms.RadioButton();
            this.pnlTituloForm = new System.Windows.Forms.Panel();
            this.pnlIconoForm = new Presentacion.RoundedPanel();
            this.lblGlyphForm = new System.Windows.Forms.Label();
            this.lblTituloForm = new System.Windows.Forms.Label();
            this.pnlTituloGestion = new System.Windows.Forms.Panel();
            this.lblTituloGestion = new System.Windows.Forms.Label();
            this.lblSubtituloGestion = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleCompra)).BeginInit();
            this.SuspendLayout();
            this.tabModulo.SuspendLayout();
            this.tpConsultar.SuspendLayout();
            this.pnlLista.SuspendLayout();
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
            this.pnlDetalle.SuspendLayout();
            this.tlpDetalle.SuspendLayout();
            this.pnlEstadoDetalle.SuspendLayout();
            this.pnlTituloDetalle.SuspendLayout();
            this.pnlIconoDetalle.SuspendLayout();
            this.pnlBarra.SuspendLayout();
            this.pnlEncabezadoWrap.SuspendLayout();
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
            // 
            // FrmCompras
            // 
            this.Controls.Add(this.tabModulo);
            this.Controls.Add(this.pnlCabecera);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.ClientSize = new System.Drawing.Size(920, 640);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCompras";
            this.Padding = new System.Windows.Forms.Padding(20, 10, 20, 8);
            this.Text = "Compras";
            // 
            // tabModulo
            // 
            this.tabModulo.Controls.Add(this.tpConsultar);
            this.tabModulo.Controls.Add(this.tpGestionar);
            this.tabModulo.Controls.Add(this.tpResumen);
            this.tabModulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabModulo.Name = "tabModulo";
            this.tabModulo.SelectedIndex = 0;
            this.tabModulo.Size = new System.Drawing.Size(880, 560);
            // 
            // tpConsultar
            // 
            this.tpConsultar.Controls.Add(this.pnlLista);
            this.tpConsultar.Controls.Add(this.pnlKpi);
            this.tpConsultar.Controls.Add(this.pnlTituloConsulta);
            this.tpConsultar.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.tpConsultar.Name = "tpConsultar";
            this.tpConsultar.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.tpConsultar.Text = "Consultar";
            this.tpConsultar.UseVisualStyleBackColor = false;
            // 
            // pnlLista
            // 
            this.pnlLista.Controls.Add(this.dgvCompras);
            this.pnlLista.Controls.Add(this.pnlPie);
            this.pnlLista.Controls.Add(this.pnlToolbar);
            this.pnlLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLista.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.pnlLista.Name = "pnlLista";
            this.pnlLista.Padding = new System.Windows.Forms.Padding(16, 8, 16, 4);
            this.pnlLista.Size = new System.Drawing.Size(200, 100);
            // 
            // dgvCompras
            // 
            this.dgvCompras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCompras.Name = "dgvCompras";
            this.dgvCompras.Size = new System.Drawing.Size(850, 150);
            // 
            // pnlPie
            // 
            this.pnlPie.Controls.Add(this.lblTotalRegistros);
            this.pnlPie.Controls.Add(this.btnPagAnterior);
            this.pnlPie.Controls.Add(this.sepPagA);
            this.pnlPie.Controls.Add(this.btnPagina);
            this.pnlPie.Controls.Add(this.sepPagB);
            this.pnlPie.Controls.Add(this.btnPagSiguiente);
            this.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPie.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.pnlPie.Name = "pnlPie";
            this.pnlPie.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.pnlPie.Size = new System.Drawing.Size(200, 42);
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.AutoSize = true;
            this.lblTotalRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalRegistros.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalRegistros.ForeColor = System.Drawing.Color.FromArgb(200, 208, 240);
            this.lblTotalRegistros.Location = new System.Drawing.Point(0, 12);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Text = "Mostrando 0 de 0 resultados";
            // 
            // btnPagAnterior
            // 
            this.btnPagAnterior.BackColor = System.Drawing.Color.FromArgb(30, 38, 100);
            this.btnPagAnterior.ColorBorde = System.Drawing.Color.FromArgb(48, 58, 130);
            this.btnPagAnterior.ColorHover = System.Drawing.Color.FromArgb(45, 56, 130);
            this.btnPagAnterior.ColorSeleccionado = System.Drawing.Color.FromArgb(14, 130, 170);
            this.btnPagAnterior.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPagAnterior.Name = "btnPagAnterior";
            this.btnPagAnterior.Radio = 6;
            this.btnPagAnterior.Size = new System.Drawing.Size(32, 30);
            this.btnPagAnterior.Text = "‹";
            // 
            // sepPagA
            // 
            this.sepPagA.Dock = System.Windows.Forms.DockStyle.Right;
            this.sepPagA.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.sepPagA.Name = "sepPagA";
            this.sepPagA.Size = new System.Drawing.Size(6, 30);
            // 
            // btnPagina
            // 
            this.btnPagina.BackColor = System.Drawing.Color.FromArgb(30, 38, 100);
            this.btnPagina.ColorBorde = System.Drawing.Color.FromArgb(48, 58, 130);
            this.btnPagina.ColorHover = System.Drawing.Color.FromArgb(45, 56, 130);
            this.btnPagina.ColorSeleccionado = System.Drawing.Color.FromArgb(14, 130, 170);
            this.btnPagina.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPagina.Name = "btnPagina";
            this.btnPagina.Radio = 6;
            this.btnPagina.Seleccionado = true;
            this.btnPagina.Size = new System.Drawing.Size(32, 30);
            this.btnPagina.Text = "1";
            // 
            // sepPagB
            // 
            this.sepPagB.Dock = System.Windows.Forms.DockStyle.Right;
            this.sepPagB.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.sepPagB.Name = "sepPagB";
            this.sepPagB.Size = new System.Drawing.Size(6, 30);
            // 
            // btnPagSiguiente
            // 
            this.btnPagSiguiente.BackColor = System.Drawing.Color.FromArgb(30, 38, 100);
            this.btnPagSiguiente.ColorBorde = System.Drawing.Color.FromArgb(48, 58, 130);
            this.btnPagSiguiente.ColorHover = System.Drawing.Color.FromArgb(45, 56, 130);
            this.btnPagSiguiente.ColorSeleccionado = System.Drawing.Color.FromArgb(14, 130, 170);
            this.btnPagSiguiente.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPagSiguiente.Name = "btnPagSiguiente";
            this.btnPagSiguiente.Radio = 6;
            this.btnPagSiguiente.Size = new System.Drawing.Size(32, 30);
            this.btnPagSiguiente.Text = "›";
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Controls.Add(this.pnlToolbarFiltros);
            this.pnlToolbar.Controls.Add(this.pnlToolbarTop);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(200, 100);
            // 
            // pnlToolbarFiltros
            // 
            this.pnlToolbarFiltros.Controls.Add(this.csBuscar);
            this.pnlToolbarFiltros.Controls.Add(this.lblFiltroEstado);
            this.pnlToolbarFiltros.Controls.Add(this.pnlFiltroEstado);
            this.pnlToolbarFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbarFiltros.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.pnlToolbarFiltros.Name = "pnlToolbarFiltros";
            this.pnlToolbarFiltros.Padding = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.pnlToolbarFiltros.Size = new System.Drawing.Size(200, 46);
            // 
            // csBuscar
            // 
            this.csBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.csBuscar.Name = "csBuscar";
            this.csBuscar.Placeholder = "Buscar por código...";
            this.csBuscar.Size = new System.Drawing.Size(300, 34);
            this.csBuscar.EnterPresionado += new System.EventHandler(this.csBuscar_EnterPresionado);
            // 
            // lblFiltroEstado
            // 
            this.lblFiltroEstado.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblFiltroEstado.AutoSize = true;
            this.lblFiltroEstado.BackColor = System.Drawing.Color.Transparent;
            this.lblFiltroEstado.ForeColor = System.Drawing.Color.FromArgb(160, 170, 220);
            this.lblFiltroEstado.Name = "lblFiltroEstado";
            this.lblFiltroEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblFiltroEstado.Text = "Estado:";
            this.lblFiltroEstado.Padding = new System.Windows.Forms.Padding(14, 0, 6, 0);
            // 
            // pnlFiltroEstado
            // 
            this.pnlFiltroEstado.Controls.Add(this.cmbFiltroEstado);
            this.pnlFiltroEstado.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFiltroEstado.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.pnlFiltroEstado.Name = "pnlFiltroEstado";
            this.pnlFiltroEstado.Size = new System.Drawing.Size(130, 34);
            // 
            // cmbFiltroEstado
            // 
            this.cmbFiltroEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFiltroEstado.BackColor = System.Drawing.Color.FromArgb(30, 37, 92);
            this.cmbFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFiltroEstado.ForeColor = System.Drawing.Color.White;
            this.cmbFiltroEstado.Items.AddRange(new object[] {
            "Todos",
            "Activo",
            "Inactivo"});
            this.cmbFiltroEstado.Location = new System.Drawing.Point(0, 5);
            this.cmbFiltroEstado.Name = "cmbFiltroEstado";
            this.cmbFiltroEstado.SelectedIndex = 0;
            this.cmbFiltroEstado.Size = new System.Drawing.Size(130, 23);
            // 
            // pnlToolbarTop
            // 
            this.pnlToolbarTop.Controls.Add(this.pnlIconoLista);
            this.pnlToolbarTop.Controls.Add(this.lblTituloLista);
            this.pnlToolbarTop.Controls.Add(this.btnEditar);
            this.pnlToolbarTop.Controls.Add(this.sepToolbarA);
            this.pnlToolbarTop.Controls.Add(this.btnEliminar);
            this.pnlToolbarTop.Controls.Add(this.sepToolbarB);
            this.pnlToolbarTop.Controls.Add(this.btnNuevo);
            this.pnlToolbarTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbarTop.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.pnlToolbarTop.Name = "pnlToolbarTop";
            this.pnlToolbarTop.Padding = new System.Windows.Forms.Padding(0, 8, 0, 10);
            this.pnlToolbarTop.Size = new System.Drawing.Size(200, 54);
            // 
            // pnlIconoLista
            // 
            this.pnlIconoLista.Controls.Add(this.lblGlyphLista);
            this.pnlIconoLista.BackColor = System.Drawing.Color.FromArgb(36, 52, 120);
            this.pnlIconoLista.ColorBorde = System.Drawing.Color.FromArgb(36, 52, 120);
            this.pnlIconoLista.Location = new System.Drawing.Point(0, 8);
            this.pnlIconoLista.Name = "pnlIconoLista";
            this.pnlIconoLista.Radio = 10;
            this.pnlIconoLista.Size = new System.Drawing.Size(38, 38);
            // 
            // lblGlyphLista
            // 
            this.lblGlyphLista.BackColor = System.Drawing.Color.FromArgb(36, 52, 120);
            this.lblGlyphLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGlyphLista.Font = new System.Drawing.Font("Segoe MDL2 Assets", 13F);
            this.lblGlyphLista.ForeColor = System.Drawing.Color.FromArgb(96, 165, 250);
            this.lblGlyphLista.Name = "lblGlyphLista";
            this.lblGlyphLista.Size = new System.Drawing.Size(38, 38);
            this.lblGlyphLista.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblGlyphLista.Text = "\uE7BF";
            // 
            // lblTituloLista
            // 
            this.lblTituloLista.AutoSize = true;
            this.lblTituloLista.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloLista.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTituloLista.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.lblTituloLista.Location = new System.Drawing.Point(48, 17);
            this.lblTituloLista.Name = "lblTituloLista";
            this.lblTituloLista.Text = "Listado de compras";
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(30, 38, 100);
            this.btnEditar.ColorBorde = System.Drawing.Color.FromArgb(48, 58, 130);
            this.btnEditar.ColorGlyph = System.Drawing.Color.FromArgb(96, 165, 250);
            this.btnEditar.ColorHover = System.Drawing.Color.FromArgb(45, 56, 130);
            this.btnEditar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEditar.Glyph = "\uE70F";
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(44, 34);
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // sepToolbarA
            // 
            this.sepToolbarA.Dock = System.Windows.Forms.DockStyle.Right;
            this.sepToolbarA.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.sepToolbarA.Name = "sepToolbarA";
            this.sepToolbarA.Size = new System.Drawing.Size(8, 34);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(30, 38, 100);
            this.btnEliminar.ColorBorde = System.Drawing.Color.FromArgb(48, 58, 130);
            this.btnEliminar.ColorGlyph = System.Drawing.Color.FromArgb(244, 63, 94);
            this.btnEliminar.ColorHover = System.Drawing.Color.FromArgb(45, 56, 130);
            this.btnEliminar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEliminar.Glyph = "\uE74D";
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(44, 34);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // sepToolbarB
            // 
            this.sepToolbarB.Dock = System.Windows.Forms.DockStyle.Right;
            this.sepToolbarB.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.sepToolbarB.Name = "sepToolbarB";
            this.sepToolbarB.Size = new System.Drawing.Size(8, 34);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(14, 130, 170);
            this.btnNuevo.ColorBorde = System.Drawing.Color.FromArgb(40, 180, 220);
            this.btnNuevo.ColorHover = System.Drawing.Color.FromArgb(20, 160, 205);
            this.btnNuevo.Glyph = "\uE710";
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(130, 34);
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // pnlKpi
            // 
            this.pnlKpi.Controls.Add(this.tlpKpi);
            this.pnlKpi.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpi.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.pnlKpi.Name = "pnlKpi";
            this.pnlKpi.Padding = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.pnlKpi.Size = new System.Drawing.Size(880, 132);
            // 
            // tlpKpi
            // 
            this.tlpKpi.Controls.Add(this.statTotal, 0, 0);
            this.tlpKpi.Controls.Add(this.statEstado1, 1, 0);
            this.tlpKpi.Controls.Add(this.statEstado2, 2, 0);
            this.tlpKpi.Controls.Add(this.statExtra, 3, 0);
            this.tlpKpi.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.tlpKpi.ColumnCount = 4;
            this.tlpKpi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpKpi.Name = "tlpKpi";
            this.tlpKpi.RowCount = 1;
            this.tlpKpi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpKpi.Size = new System.Drawing.Size(200, 100);
            // 
            // statTotal
            // 
            this.statTotal.ColorFin = System.Drawing.Color.FromArgb(124, 58, 237);
            this.statTotal.ColorInicio = System.Drawing.Color.FromArgb(79, 70, 229);
            this.statTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statTotal.Glyph = "\uE8A5";
            this.statTotal.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.statTotal.Name = "statTotal";
            this.statTotal.Size = new System.Drawing.Size(200, 110);
            this.statTotal.Subtitulo = "Registros";
            this.statTotal.Titulo = "Total de compras";
            this.statTotal.Valor = "0";
            // 
            // statEstado1
            // 
            this.statEstado1.ColorFin = System.Drawing.Color.FromArgb(150, 40, 120);
            this.statEstado1.ColorInicio = System.Drawing.Color.FromArgb(232, 62, 140);
            this.statEstado1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statEstado1.Glyph = "\uE73E";
            this.statEstado1.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.statEstado1.Name = "statEstado1";
            this.statEstado1.Size = new System.Drawing.Size(200, 110);
            this.statEstado1.Subtitulo = "";
            this.statEstado1.Titulo = "Activos";
            this.statEstado1.Valor = "0";
            // 
            // statEstado2
            // 
            this.statEstado2.ColorFin = System.Drawing.Color.FromArgb(14, 116, 144);
            this.statEstado2.ColorInicio = System.Drawing.Color.FromArgb(20, 184, 166);
            this.statEstado2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statEstado2.Glyph = "\uE81C";
            this.statEstado2.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.statEstado2.Name = "statEstado2";
            this.statEstado2.Size = new System.Drawing.Size(200, 110);
            this.statEstado2.Subtitulo = "";
            this.statEstado2.Titulo = "Inactivos";
            this.statEstado2.Valor = "0";
            // 
            // statExtra
            // 
            this.statExtra.ColorFin = System.Drawing.Color.FromArgb(194, 101, 12);
            this.statExtra.ColorInicio = System.Drawing.Color.FromArgb(245, 158, 11);
            this.statExtra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statExtra.Glyph = "\uE8EF";
            this.statExtra.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.statExtra.Name = "statExtra";
            this.statExtra.Size = new System.Drawing.Size(200, 110);
            this.statExtra.Subtitulo = "";
            this.statExtra.Titulo = "Total comprado";
            this.statExtra.Valor = "0";
            // 
            // pnlTituloConsulta
            // 
            this.pnlTituloConsulta.Controls.Add(this.lblTituloConsulta);
            this.pnlTituloConsulta.Controls.Add(this.lblSubtituloConsulta);
            this.pnlTituloConsulta.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTituloConsulta.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.pnlTituloConsulta.Name = "pnlTituloConsulta";
            this.pnlTituloConsulta.Size = new System.Drawing.Size(880, 70);
            // 
            // lblTituloConsulta
            // 
            this.lblTituloConsulta.AutoSize = true;
            this.lblTituloConsulta.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloConsulta.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTituloConsulta.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.lblTituloConsulta.Location = new System.Drawing.Point(0, 0);
            this.lblTituloConsulta.Name = "lblTituloConsulta";
            this.lblTituloConsulta.Text = "Consulta de compras";
            // 
            // lblSubtituloConsulta
            // 
            this.lblSubtituloConsulta.AutoSize = true;
            this.lblSubtituloConsulta.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtituloConsulta.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtituloConsulta.ForeColor = System.Drawing.Color.FromArgb(160, 170, 220);
            this.lblSubtituloConsulta.Location = new System.Drawing.Point(0, 36);
            this.lblSubtituloConsulta.Name = "lblSubtituloConsulta";
            this.lblSubtituloConsulta.Text = "Consulte y administre compras de la agencia.";
            // 
            // tpGestionar
            // 
            this.tpGestionar.Controls.Add(this.pnlDetalle);
            this.tpGestionar.Controls.Add(this.pnlBarra);
            this.tpGestionar.Controls.Add(this.pnlEncabezadoWrap);
            this.tpGestionar.Controls.Add(this.pnlTituloGestion);
            this.tpGestionar.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.tpGestionar.Name = "tpGestionar";
            this.tpGestionar.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.tpGestionar.Text = "Gestionar";
            this.tpGestionar.UseVisualStyleBackColor = false;
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.dgvDetalleCompra);
            this.pnlDetalle.Controls.Add(this.tlpDetalle);
            this.pnlDetalle.Controls.Add(this.pnlTituloDetalle);
            this.pnlDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetalle.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Padding = new System.Windows.Forms.Padding(18, 10, 18, 8);
            this.pnlDetalle.Size = new System.Drawing.Size(200, 100);
            // 
            // dgvDetalleCompra
            // 
            this.dgvDetalleCompra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalleCompra.Name = "dgvDetalleCompra";
            this.dgvDetalleCompra.Size = new System.Drawing.Size(850, 150);
            // 
            // tlpDetalle
            // 
            this.tlpDetalle.Controls.Add(this.lblCodigoDetalleCompra, 0, 0);
            this.tlpDetalle.Controls.Add(this.txtCodigoDetalleCompra, 0, 1);
            this.tlpDetalle.Controls.Add(this.lblTipoDeCompra, 1, 0);
            this.tlpDetalle.Controls.Add(this.txtTipoDeCompra, 1, 1);
            this.tlpDetalle.Controls.Add(this.lblDescripcion, 2, 0);
            this.tlpDetalle.Controls.Add(this.txtDescripcion, 2, 1);
            this.tlpDetalle.Controls.Add(this.lblPrecioUnitario, 3, 0);
            this.tlpDetalle.Controls.Add(this.txtPrecioUnitario, 3, 1);
            this.tlpDetalle.Controls.Add(this.lblSubtotal, 0, 2);
            this.tlpDetalle.Controls.Add(this.txtSubtotal, 0, 3);
            this.tlpDetalle.Controls.Add(this.lblDescuentoCompra, 1, 2);
            this.tlpDetalle.Controls.Add(this.txtDescuentoCompra, 1, 3);
            this.tlpDetalle.Controls.Add(this.lblEstadoDetalle, 2, 2);
            this.tlpDetalle.Controls.Add(this.pnlEstadoDetalle, 2, 3);
            this.tlpDetalle.Controls.Add(this.btnAgregarDetalle, 3, 3);
            this.tlpDetalle.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.tlpDetalle.ColumnCount = 4;
            this.tlpDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDetalle.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpDetalle.Name = "tlpDetalle";
            this.tlpDetalle.RowCount = 4;
            this.tlpDetalle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tlpDetalle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpDetalle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tlpDetalle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpDetalle.Size = new System.Drawing.Size(200, 96);
            // 
            // lblCodigoDetalleCompra
            // 
            this.lblCodigoDetalleCompra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCodigoDetalleCompra.AutoSize = false;
            this.lblCodigoDetalleCompra.BackColor = System.Drawing.Color.Transparent;
            this.lblCodigoDetalleCompra.ForeColor = System.Drawing.Color.FromArgb(160, 170, 220);
            this.lblCodigoDetalleCompra.Margin = new System.Windows.Forms.Padding(0);
            this.lblCodigoDetalleCompra.Name = "lblCodigoDetalleCompra";
            this.lblCodigoDetalleCompra.Size = new System.Drawing.Size(100, 20);
            this.lblCodigoDetalleCompra.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblCodigoDetalleCompra.Text = "CodigoDetalleCompra:";
            // 
            // txtCodigoDetalleCompra
            // 
            this.txtCodigoDetalleCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodigoDetalleCompra.BackColor = System.Drawing.Color.FromArgb(30, 37, 92);
            this.txtCodigoDetalleCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoDetalleCompra.ForeColor = System.Drawing.Color.White;
            this.txtCodigoDetalleCompra.Margin = new System.Windows.Forms.Padding(0, 2, 10, 2);
            this.txtCodigoDetalleCompra.Name = "txtCodigoDetalleCompra";
            this.txtCodigoDetalleCompra.ReadOnly = true;
            this.txtCodigoDetalleCompra.Enabled = false;
            this.txtCodigoDetalleCompra.Size = new System.Drawing.Size(200, 23);
            // 
            // lblTipoDeCompra
            // 
            this.lblTipoDeCompra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTipoDeCompra.AutoSize = false;
            this.lblTipoDeCompra.BackColor = System.Drawing.Color.Transparent;
            this.lblTipoDeCompra.ForeColor = System.Drawing.Color.FromArgb(160, 170, 220);
            this.lblTipoDeCompra.Margin = new System.Windows.Forms.Padding(0);
            this.lblTipoDeCompra.Name = "lblTipoDeCompra";
            this.lblTipoDeCompra.Size = new System.Drawing.Size(100, 20);
            this.lblTipoDeCompra.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblTipoDeCompra.Text = "TipoDeCompra:";
            // 
            // txtTipoDeCompra
            // 
            this.txtTipoDeCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTipoDeCompra.BackColor = System.Drawing.Color.FromArgb(30, 37, 92);
            this.txtTipoDeCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTipoDeCompra.ForeColor = System.Drawing.Color.White;
            this.txtTipoDeCompra.Margin = new System.Windows.Forms.Padding(0, 2, 10, 2);
            this.txtTipoDeCompra.MaxLength = 45;
            this.txtTipoDeCompra.Name = "txtTipoDeCompra";
            this.txtTipoDeCompra.Size = new System.Drawing.Size(200, 23);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescripcion.AutoSize = false;
            this.lblDescripcion.BackColor = System.Drawing.Color.Transparent;
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(160, 170, 220);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(100, 20);
            this.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblDescripcion.Text = "Descripcion:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcion.BackColor = System.Drawing.Color.FromArgb(30, 37, 92);
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.ForeColor = System.Drawing.Color.White;
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(0, 2, 10, 2);
            this.txtDescripcion.MaxLength = 150;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(200, 23);
            // 
            // lblPrecioUnitario
            // 
            this.lblPrecioUnitario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPrecioUnitario.AutoSize = false;
            this.lblPrecioUnitario.BackColor = System.Drawing.Color.Transparent;
            this.lblPrecioUnitario.ForeColor = System.Drawing.Color.FromArgb(160, 170, 220);
            this.lblPrecioUnitario.Margin = new System.Windows.Forms.Padding(0);
            this.lblPrecioUnitario.Name = "lblPrecioUnitario";
            this.lblPrecioUnitario.Size = new System.Drawing.Size(100, 20);
            this.lblPrecioUnitario.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblPrecioUnitario.Text = "PrecioUnitario:";
            // 
            // txtPrecioUnitario
            // 
            this.txtPrecioUnitario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrecioUnitario.BackColor = System.Drawing.Color.FromArgb(30, 37, 92);
            this.txtPrecioUnitario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecioUnitario.ForeColor = System.Drawing.Color.White;
            this.txtPrecioUnitario.Margin = new System.Windows.Forms.Padding(0, 2, 10, 2);
            this.txtPrecioUnitario.MaxLength = 15;
            this.txtPrecioUnitario.Name = "txtPrecioUnitario";
            this.txtPrecioUnitario.Size = new System.Drawing.Size(200, 23);
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSubtotal.AutoSize = false;
            this.lblSubtotal.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtotal.ForeColor = System.Drawing.Color.FromArgb(160, 170, 220);
            this.lblSubtotal.Margin = new System.Windows.Forms.Padding(0);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(100, 20);
            this.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblSubtotal.Text = "Subtotal:";
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubtotal.BackColor = System.Drawing.Color.FromArgb(30, 37, 92);
            this.txtSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSubtotal.ForeColor = System.Drawing.Color.White;
            this.txtSubtotal.Margin = new System.Windows.Forms.Padding(0, 2, 10, 2);
            this.txtSubtotal.MaxLength = 15;
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.Size = new System.Drawing.Size(200, 23);
            // 
            // lblDescuentoCompra
            // 
            this.lblDescuentoCompra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescuentoCompra.AutoSize = false;
            this.lblDescuentoCompra.BackColor = System.Drawing.Color.Transparent;
            this.lblDescuentoCompra.ForeColor = System.Drawing.Color.FromArgb(160, 170, 220);
            this.lblDescuentoCompra.Margin = new System.Windows.Forms.Padding(0);
            this.lblDescuentoCompra.Name = "lblDescuentoCompra";
            this.lblDescuentoCompra.Size = new System.Drawing.Size(100, 20);
            this.lblDescuentoCompra.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblDescuentoCompra.Text = "DescuentoCompra:";
            // 
            // txtDescuentoCompra
            // 
            this.txtDescuentoCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescuentoCompra.BackColor = System.Drawing.Color.FromArgb(30, 37, 92);
            this.txtDescuentoCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescuentoCompra.ForeColor = System.Drawing.Color.White;
            this.txtDescuentoCompra.Margin = new System.Windows.Forms.Padding(0, 2, 10, 2);
            this.txtDescuentoCompra.MaxLength = 15;
            this.txtDescuentoCompra.Name = "txtDescuentoCompra";
            this.txtDescuentoCompra.Size = new System.Drawing.Size(200, 23);
            // 
            // lblEstadoDetalle
            // 
            this.lblEstadoDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEstadoDetalle.AutoSize = false;
            this.lblEstadoDetalle.BackColor = System.Drawing.Color.Transparent;
            this.lblEstadoDetalle.ForeColor = System.Drawing.Color.FromArgb(160, 170, 220);
            this.lblEstadoDetalle.Margin = new System.Windows.Forms.Padding(0);
            this.lblEstadoDetalle.Name = "lblEstadoDetalle";
            this.lblEstadoDetalle.Size = new System.Drawing.Size(100, 20);
            this.lblEstadoDetalle.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblEstadoDetalle.Text = "Estado:";
            // 
            // pnlEstadoDetalle
            // 
            this.pnlEstadoDetalle.Controls.Add(this.rdoActivoDetalle);
            this.pnlEstadoDetalle.Controls.Add(this.rdoInactivoDetalle);
            this.pnlEstadoDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEstadoDetalle.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.pnlEstadoDetalle.Margin = new System.Windows.Forms.Padding(0, 2, 10, 2);
            this.pnlEstadoDetalle.Name = "pnlEstadoDetalle";
            this.pnlEstadoDetalle.Size = new System.Drawing.Size(160, 23);
            // 
            // rdoActivoDetalle
            // 
            this.rdoActivoDetalle.AutoSize = true;
            this.rdoActivoDetalle.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.rdoActivoDetalle.Checked = true;
            this.rdoActivoDetalle.ForeColor = System.Drawing.Color.White;
            this.rdoActivoDetalle.Location = new System.Drawing.Point(2, 2);
            this.rdoActivoDetalle.Name = "rdoActivoDetalle";
            this.rdoActivoDetalle.TabStop = true;
            this.rdoActivoDetalle.Text = "Activo";
            this.rdoActivoDetalle.UseVisualStyleBackColor = false;
            // 
            // rdoInactivoDetalle
            // 
            this.rdoInactivoDetalle.AutoSize = true;
            this.rdoInactivoDetalle.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.rdoInactivoDetalle.ForeColor = System.Drawing.Color.White;
            this.rdoInactivoDetalle.Location = new System.Drawing.Point(76, 2);
            this.rdoInactivoDetalle.Name = "rdoInactivoDetalle";
            this.rdoInactivoDetalle.Text = "Inactivo";
            this.rdoInactivoDetalle.UseVisualStyleBackColor = false;
            // 
            // btnAgregarDetalle
            // 
            this.btnAgregarDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAgregarDetalle.BackColor = System.Drawing.Color.FromArgb(14, 130, 170);
            this.btnAgregarDetalle.ColorBorde = System.Drawing.Color.FromArgb(40, 180, 220);
            this.btnAgregarDetalle.ColorHover = System.Drawing.Color.FromArgb(20, 160, 205);
            this.btnAgregarDetalle.Glyph = "\uE710";
            this.btnAgregarDetalle.Margin = new System.Windows.Forms.Padding(6, 2, 0, 2);
            this.btnAgregarDetalle.Name = "btnAgregarDetalle";
            this.btnAgregarDetalle.Size = new System.Drawing.Size(126, 28);
            this.btnAgregarDetalle.Text = "Agregar línea";
            this.btnAgregarDetalle.Click += new System.EventHandler(this.btnAgregarDetalle_Click);
            // 
            // pnlTituloDetalle
            // 
            this.pnlTituloDetalle.Controls.Add(this.pnlIconoDetalle);
            this.pnlTituloDetalle.Controls.Add(this.lblTituloDetalle);
            this.pnlTituloDetalle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTituloDetalle.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.pnlTituloDetalle.Name = "pnlTituloDetalle";
            this.pnlTituloDetalle.Size = new System.Drawing.Size(200, 52);
            // 
            // pnlIconoDetalle
            // 
            this.pnlIconoDetalle.Controls.Add(this.lblGlyphDetalle);
            this.pnlIconoDetalle.BackColor = System.Drawing.Color.FromArgb(36, 52, 120);
            this.pnlIconoDetalle.ColorBorde = System.Drawing.Color.FromArgb(36, 52, 120);
            this.pnlIconoDetalle.Location = new System.Drawing.Point(0, 7);
            this.pnlIconoDetalle.Name = "pnlIconoDetalle";
            this.pnlIconoDetalle.Radio = 10;
            this.pnlIconoDetalle.Size = new System.Drawing.Size(38, 38);
            // 
            // lblGlyphDetalle
            // 
            this.lblGlyphDetalle.BackColor = System.Drawing.Color.FromArgb(36, 52, 120);
            this.lblGlyphDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGlyphDetalle.Font = new System.Drawing.Font("Segoe MDL2 Assets", 13F);
            this.lblGlyphDetalle.ForeColor = System.Drawing.Color.FromArgb(96, 165, 250);
            this.lblGlyphDetalle.Name = "lblGlyphDetalle";
            this.lblGlyphDetalle.Size = new System.Drawing.Size(38, 38);
            this.lblGlyphDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblGlyphDetalle.Text = "\uE8A5";
            // 
            // lblTituloDetalle
            // 
            this.lblTituloDetalle.AutoSize = true;
            this.lblTituloDetalle.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloDetalle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloDetalle.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.lblTituloDetalle.Location = new System.Drawing.Point(50, 15);
            this.lblTituloDetalle.Name = "lblTituloDetalle";
            this.lblTituloDetalle.Text = "Detalle de la compra";
            // 
            // pnlBarra
            // 
            this.pnlBarra.Controls.Add(this.lblSubtotalDetalle);
            this.pnlBarra.Controls.Add(this.lblDescuentoDetalle);
            this.pnlBarra.Controls.Add(this.lblTotalDetalle);
            this.pnlBarra.Controls.Add(this.btnLimpiar);
            this.pnlBarra.Controls.Add(this.sepBarraA);
            this.pnlBarra.Controls.Add(this.btnCancelar);
            this.pnlBarra.Controls.Add(this.sepBarraB);
            this.pnlBarra.Controls.Add(this.btnGuardar);
            this.pnlBarra.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBarra.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.pnlBarra.Name = "pnlBarra";
            this.pnlBarra.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.pnlBarra.Size = new System.Drawing.Size(880, 58);
            // 
            // lblSubtotalDetalle
            // 
            this.lblSubtotalDetalle.AutoSize = true;
            this.lblSubtotalDetalle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtotalDetalle.ForeColor = System.Drawing.Color.FromArgb(160, 170, 220);
            this.lblSubtotalDetalle.Location = new System.Drawing.Point(0, 22);
            this.lblSubtotalDetalle.Name = "lblSubtotalDetalle";
            this.lblSubtotalDetalle.Text = "Subtotal:  Q 0.00";
            // 
            // lblDescuentoDetalle
            // 
            this.lblDescuentoDetalle.AutoSize = true;
            this.lblDescuentoDetalle.BackColor = System.Drawing.Color.Transparent;
            this.lblDescuentoDetalle.ForeColor = System.Drawing.Color.FromArgb(160, 170, 220);
            this.lblDescuentoDetalle.Location = new System.Drawing.Point(140, 22);
            this.lblDescuentoDetalle.Name = "lblDescuentoDetalle";
            this.lblDescuentoDetalle.Text = "Descuento:  Q 0.00";
            // 
            // lblTotalDetalle
            // 
            this.lblTotalDetalle.AutoSize = true;
            this.lblTotalDetalle.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalDetalle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalDetalle.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.lblTotalDetalle.Location = new System.Drawing.Point(290, 17);
            this.lblTotalDetalle.Name = "lblTotalDetalle";
            this.lblTotalDetalle.Text = "Total:  Q 0.00";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLimpiar.ColorBorde = System.Drawing.Color.FromArgb(70, 90, 190);
            this.btnLimpiar.Glyph = "\uE75C";
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(104, 34);
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // sepBarraA
            // 
            this.sepBarraA.Dock = System.Windows.Forms.DockStyle.Right;
            this.sepBarraA.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.sepBarraA.Name = "sepBarraA";
            this.sepBarraA.Size = new System.Drawing.Size(8, 34);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancelar.ColorBorde = System.Drawing.Color.FromArgb(70, 90, 190);
            this.btnCancelar.Glyph = "\uE711";
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(112, 34);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // sepBarraB
            // 
            this.sepBarraB.Dock = System.Windows.Forms.DockStyle.Right;
            this.sepBarraB.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.sepBarraB.Name = "sepBarraB";
            this.sepBarraB.Size = new System.Drawing.Size(8, 34);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(14, 130, 170);
            this.btnGuardar.ColorBorde = System.Drawing.Color.FromArgb(40, 180, 220);
            this.btnGuardar.ColorHover = System.Drawing.Color.FromArgb(20, 160, 205);
            this.btnGuardar.Glyph = "\uE74E";
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(132, 34);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // pnlEncabezadoWrap
            // 
            this.pnlEncabezadoWrap.Controls.Add(this.pnlFormulario);
            this.pnlEncabezadoWrap.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezadoWrap.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.pnlEncabezadoWrap.Name = "pnlEncabezadoWrap";
            this.pnlEncabezadoWrap.Padding = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.pnlEncabezadoWrap.Size = new System.Drawing.Size(880, 178);
            // 
            // pnlFormulario
            // 
            this.pnlFormulario.Controls.Add(this.tlpCampos);
            this.pnlFormulario.Controls.Add(this.pnlTituloForm);
            this.pnlFormulario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFormulario.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.pnlFormulario.Name = "pnlFormulario";
            this.pnlFormulario.Padding = new System.Windows.Forms.Padding(18, 10, 18, 6);
            this.pnlFormulario.Size = new System.Drawing.Size(880, 200);
            // 
            // tlpCampos
            // 
            this.tlpCampos.Controls.Add(this.lblCodigoCompra, 0, 0);
            this.tlpCampos.Controls.Add(this.txtCodigoCompra, 0, 1);
            this.tlpCampos.Controls.Add(this.lblCodigoProveedor, 1, 0);
            this.tlpCampos.Controls.Add(this.cmbCodigoProveedor, 1, 1);
            this.tlpCampos.Controls.Add(this.lblCodigoMaterial, 2, 0);
            this.tlpCampos.Controls.Add(this.cmbCodigoMaterial, 2, 1);
            this.tlpCampos.Controls.Add(this.lblCantidadComprada, 3, 0);
            this.tlpCampos.Controls.Add(this.txtCantidadComprada, 3, 1);
            this.tlpCampos.Controls.Add(this.lblTotalCompra, 0, 2);
            this.tlpCampos.Controls.Add(this.txtTotalCompra, 0, 3);
            this.tlpCampos.Controls.Add(this.lblFechaCompra, 1, 2);
            this.tlpCampos.Controls.Add(this.dtpFechaCompra, 1, 3);
            this.tlpCampos.Controls.Add(this.lblFechaEntrega, 2, 2);
            this.tlpCampos.Controls.Add(this.dtpFechaEntrega, 2, 3);
            this.tlpCampos.Controls.Add(this.lblEstado, 3, 2);
            this.tlpCampos.Controls.Add(this.pnlEstado, 3, 3);
            this.tlpCampos.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.tlpCampos.ColumnCount = 4;
            this.tlpCampos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0F));
            this.tlpCampos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0F));
            this.tlpCampos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0F));
            this.tlpCampos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0F));
            this.tlpCampos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCampos.Name = "tlpCampos";
            this.tlpCampos.RowCount = 5;
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCampos.Size = new System.Drawing.Size(200, 100);
            // 
            // lblCodigoCompra
            // 
            this.lblCodigoCompra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCodigoCompra.AutoSize = false;
            this.lblCodigoCompra.BackColor = System.Drawing.Color.Transparent;
            this.lblCodigoCompra.ForeColor = System.Drawing.Color.FromArgb(160, 170, 220);
            this.lblCodigoCompra.Margin = new System.Windows.Forms.Padding(0);
            this.lblCodigoCompra.Name = "lblCodigoCompra";
            this.lblCodigoCompra.Size = new System.Drawing.Size(100, 20);
            this.lblCodigoCompra.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblCodigoCompra.Text = "CodigoCompra:";
            // 
            // txtCodigoCompra
            // 
            this.txtCodigoCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodigoCompra.BackColor = System.Drawing.Color.FromArgb(30, 37, 92);
            this.txtCodigoCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoCompra.ForeColor = System.Drawing.Color.White;
            this.txtCodigoCompra.Margin = new System.Windows.Forms.Padding(0, 2, 10, 2);
            this.txtCodigoCompra.Name = "txtCodigoCompra";
            this.txtCodigoCompra.ReadOnly = true;
            this.txtCodigoCompra.Enabled = false;
            this.txtCodigoCompra.Size = new System.Drawing.Size(200, 23);
            // 
            // lblCodigoProveedor
            // 
            this.lblCodigoProveedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCodigoProveedor.AutoSize = false;
            this.lblCodigoProveedor.BackColor = System.Drawing.Color.Transparent;
            this.lblCodigoProveedor.ForeColor = System.Drawing.Color.FromArgb(160, 170, 220);
            this.lblCodigoProveedor.Margin = new System.Windows.Forms.Padding(0);
            this.lblCodigoProveedor.Name = "lblCodigoProveedor";
            this.lblCodigoProveedor.Size = new System.Drawing.Size(100, 20);
            this.lblCodigoProveedor.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblCodigoProveedor.Text = "CodigoProveedor:";
            // 
            // cmbCodigoProveedor
            // 
            this.cmbCodigoProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCodigoProveedor.BackColor = System.Drawing.Color.FromArgb(30, 37, 92);
            this.cmbCodigoProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCodigoProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCodigoProveedor.ForeColor = System.Drawing.Color.White;
            this.cmbCodigoProveedor.Margin = new System.Windows.Forms.Padding(0, 2, 10, 2);
            this.cmbCodigoProveedor.Name = "cmbCodigoProveedor";
            this.cmbCodigoProveedor.Size = new System.Drawing.Size(200, 23);
            // 
            // lblCodigoMaterial
            // 
            this.lblCodigoMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCodigoMaterial.AutoSize = false;
            this.lblCodigoMaterial.BackColor = System.Drawing.Color.Transparent;
            this.lblCodigoMaterial.ForeColor = System.Drawing.Color.FromArgb(160, 170, 220);
            this.lblCodigoMaterial.Margin = new System.Windows.Forms.Padding(0);
            this.lblCodigoMaterial.Name = "lblCodigoMaterial";
            this.lblCodigoMaterial.Size = new System.Drawing.Size(100, 20);
            this.lblCodigoMaterial.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblCodigoMaterial.Text = "CodigoMaterial:";
            // 
            // cmbCodigoMaterial
            // 
            this.cmbCodigoMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCodigoMaterial.BackColor = System.Drawing.Color.FromArgb(30, 37, 92);
            this.cmbCodigoMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCodigoMaterial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCodigoMaterial.ForeColor = System.Drawing.Color.White;
            this.cmbCodigoMaterial.Margin = new System.Windows.Forms.Padding(0, 2, 10, 2);
            this.cmbCodigoMaterial.Name = "cmbCodigoMaterial";
            this.cmbCodigoMaterial.Size = new System.Drawing.Size(200, 23);
            // 
            // lblCantidadComprada
            // 
            this.lblCantidadComprada.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCantidadComprada.AutoSize = false;
            this.lblCantidadComprada.BackColor = System.Drawing.Color.Transparent;
            this.lblCantidadComprada.ForeColor = System.Drawing.Color.FromArgb(160, 170, 220);
            this.lblCantidadComprada.Margin = new System.Windows.Forms.Padding(0);
            this.lblCantidadComprada.Name = "lblCantidadComprada";
            this.lblCantidadComprada.Size = new System.Drawing.Size(100, 20);
            this.lblCantidadComprada.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblCantidadComprada.Text = "CantidadComprada:";
            // 
            // txtCantidadComprada
            // 
            this.txtCantidadComprada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCantidadComprada.BackColor = System.Drawing.Color.FromArgb(30, 37, 92);
            this.txtCantidadComprada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidadComprada.ForeColor = System.Drawing.Color.White;
            this.txtCantidadComprada.Margin = new System.Windows.Forms.Padding(0, 2, 10, 2);
            this.txtCantidadComprada.MaxLength = 10;
            this.txtCantidadComprada.Name = "txtCantidadComprada";
            this.txtCantidadComprada.Size = new System.Drawing.Size(200, 23);
            // 
            // lblTotalCompra
            // 
            this.lblTotalCompra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalCompra.AutoSize = false;
            this.lblTotalCompra.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalCompra.ForeColor = System.Drawing.Color.FromArgb(160, 170, 220);
            this.lblTotalCompra.Margin = new System.Windows.Forms.Padding(0);
            this.lblTotalCompra.Name = "lblTotalCompra";
            this.lblTotalCompra.Size = new System.Drawing.Size(100, 20);
            this.lblTotalCompra.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblTotalCompra.Text = "TotalCompra:";
            // 
            // txtTotalCompra
            // 
            this.txtTotalCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalCompra.BackColor = System.Drawing.Color.FromArgb(30, 37, 92);
            this.txtTotalCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalCompra.ForeColor = System.Drawing.Color.White;
            this.txtTotalCompra.Margin = new System.Windows.Forms.Padding(0, 2, 10, 2);
            this.txtTotalCompra.MaxLength = 15;
            this.txtTotalCompra.Name = "txtTotalCompra";
            this.txtTotalCompra.Size = new System.Drawing.Size(200, 23);
            // 
            // lblFechaCompra
            // 
            this.lblFechaCompra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFechaCompra.AutoSize = false;
            this.lblFechaCompra.BackColor = System.Drawing.Color.Transparent;
            this.lblFechaCompra.ForeColor = System.Drawing.Color.FromArgb(160, 170, 220);
            this.lblFechaCompra.Margin = new System.Windows.Forms.Padding(0);
            this.lblFechaCompra.Name = "lblFechaCompra";
            this.lblFechaCompra.Size = new System.Drawing.Size(100, 20);
            this.lblFechaCompra.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblFechaCompra.Text = "FechaCompra:";
            // 
            // dtpFechaCompra
            // 
            this.dtpFechaCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFechaCompra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCompra.Margin = new System.Windows.Forms.Padding(0, 2, 10, 2);
            this.dtpFechaCompra.Name = "dtpFechaCompra";
            this.dtpFechaCompra.Size = new System.Drawing.Size(200, 23);
            // 
            // lblFechaEntrega
            // 
            this.lblFechaEntrega.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFechaEntrega.AutoSize = false;
            this.lblFechaEntrega.BackColor = System.Drawing.Color.Transparent;
            this.lblFechaEntrega.ForeColor = System.Drawing.Color.FromArgb(160, 170, 220);
            this.lblFechaEntrega.Margin = new System.Windows.Forms.Padding(0);
            this.lblFechaEntrega.Name = "lblFechaEntrega";
            this.lblFechaEntrega.Size = new System.Drawing.Size(100, 20);
            this.lblFechaEntrega.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblFechaEntrega.Text = "FechaEntrega:";
            // 
            // dtpFechaEntrega
            // 
            this.dtpFechaEntrega.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaEntrega.Margin = new System.Windows.Forms.Padding(0, 2, 10, 2);
            this.dtpFechaEntrega.Name = "dtpFechaEntrega";
            this.dtpFechaEntrega.Size = new System.Drawing.Size(200, 23);
            // 
            // lblEstado
            // 
            this.lblEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEstado.AutoSize = false;
            this.lblEstado.BackColor = System.Drawing.Color.Transparent;
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(160, 170, 220);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(100, 20);
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblEstado.Text = "Estado:";
            // 
            // pnlEstado
            // 
            this.pnlEstado.Controls.Add(this.rdoActivo);
            this.pnlEstado.Controls.Add(this.rdoInactivo);
            this.pnlEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEstado.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.pnlEstado.Margin = new System.Windows.Forms.Padding(0, 2, 10, 2);
            this.pnlEstado.Name = "pnlEstado";
            this.pnlEstado.Size = new System.Drawing.Size(160, 23);
            // 
            // rdoActivo
            // 
            this.rdoActivo.AutoSize = true;
            this.rdoActivo.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.rdoActivo.Checked = true;
            this.rdoActivo.ForeColor = System.Drawing.Color.White;
            this.rdoActivo.Location = new System.Drawing.Point(2, 2);
            this.rdoActivo.Name = "rdoActivo";
            this.rdoActivo.TabStop = true;
            this.rdoActivo.Text = "Activo";
            this.rdoActivo.UseVisualStyleBackColor = false;
            // 
            // rdoInactivo
            // 
            this.rdoInactivo.AutoSize = true;
            this.rdoInactivo.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.rdoInactivo.ForeColor = System.Drawing.Color.White;
            this.rdoInactivo.Location = new System.Drawing.Point(76, 2);
            this.rdoInactivo.Name = "rdoInactivo";
            this.rdoInactivo.Text = "Inactivo";
            this.rdoInactivo.UseVisualStyleBackColor = false;
            // 
            // pnlTituloForm
            // 
            this.pnlTituloForm.Controls.Add(this.pnlIconoForm);
            this.pnlTituloForm.Controls.Add(this.lblTituloForm);
            this.pnlTituloForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTituloForm.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.pnlTituloForm.Name = "pnlTituloForm";
            this.pnlTituloForm.Size = new System.Drawing.Size(200, 52);
            // 
            // pnlIconoForm
            // 
            this.pnlIconoForm.Controls.Add(this.lblGlyphForm);
            this.pnlIconoForm.BackColor = System.Drawing.Color.FromArgb(36, 52, 120);
            this.pnlIconoForm.ColorBorde = System.Drawing.Color.FromArgb(36, 52, 120);
            this.pnlIconoForm.Location = new System.Drawing.Point(0, 7);
            this.pnlIconoForm.Name = "pnlIconoForm";
            this.pnlIconoForm.Radio = 10;
            this.pnlIconoForm.Size = new System.Drawing.Size(38, 38);
            // 
            // lblGlyphForm
            // 
            this.lblGlyphForm.BackColor = System.Drawing.Color.FromArgb(36, 52, 120);
            this.lblGlyphForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGlyphForm.Font = new System.Drawing.Font("Segoe MDL2 Assets", 13F);
            this.lblGlyphForm.ForeColor = System.Drawing.Color.FromArgb(96, 165, 250);
            this.lblGlyphForm.Name = "lblGlyphForm";
            this.lblGlyphForm.Size = new System.Drawing.Size(38, 38);
            this.lblGlyphForm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblGlyphForm.Text = "\uE7BF";
            // 
            // lblTituloForm
            // 
            this.lblTituloForm.AutoSize = true;
            this.lblTituloForm.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloForm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloForm.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.lblTituloForm.Location = new System.Drawing.Point(50, 15);
            this.lblTituloForm.Name = "lblTituloForm";
            this.lblTituloForm.Text = "Encabezado de la compra";
            // 
            // pnlTituloGestion
            // 
            this.pnlTituloGestion.Controls.Add(this.lblTituloGestion);
            this.pnlTituloGestion.Controls.Add(this.lblSubtituloGestion);
            this.pnlTituloGestion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTituloGestion.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.pnlTituloGestion.Name = "pnlTituloGestion";
            this.pnlTituloGestion.Size = new System.Drawing.Size(880, 70);
            // 
            // lblTituloGestion
            // 
            this.lblTituloGestion.AutoSize = true;
            this.lblTituloGestion.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloGestion.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTituloGestion.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.lblTituloGestion.Location = new System.Drawing.Point(0, 0);
            this.lblTituloGestion.Name = "lblTituloGestion";
            this.lblTituloGestion.Text = "Gestión de compras";
            // 
            // lblSubtituloGestion
            // 
            this.lblSubtituloGestion.AutoSize = true;
            this.lblSubtituloGestion.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtituloGestion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtituloGestion.ForeColor = System.Drawing.Color.FromArgb(160, 170, 220);
            this.lblSubtituloGestion.Location = new System.Drawing.Point(0, 36);
            this.lblSubtituloGestion.Name = "lblSubtituloGestion";
            this.lblSubtituloGestion.Text = "Registre el encabezado y las líneas del detalle.";
            // 
            // tpResumen
            // 
            this.tpResumen.Controls.Add(this.tlpResumenGraficos);
            this.tpResumen.Controls.Add(this.pnlTituloResumen);
            this.tpResumen.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.tpResumen.Name = "tpResumen";
            this.tpResumen.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.tpResumen.Text = "Resumen";
            this.tpResumen.UseVisualStyleBackColor = false;
            // 
            // tlpResumenGraficos
            // 
            this.tlpResumenGraficos.Controls.Add(this.pnlCardEstado, 0, 0);
            this.tlpResumenGraficos.Controls.Add(this.pnlCardCategoria, 1, 0);
            this.tlpResumenGraficos.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.tlpResumenGraficos.ColumnCount = 2;
            this.tlpResumenGraficos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpResumenGraficos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpResumenGraficos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpResumenGraficos.Name = "tlpResumenGraficos";
            this.tlpResumenGraficos.RowCount = 1;
            this.tlpResumenGraficos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpResumenGraficos.Size = new System.Drawing.Size(200, 100);
            // 
            // pnlCardEstado
            // 
            this.pnlCardEstado.Controls.Add(this.graEstado);
            this.pnlCardEstado.Controls.Add(this.pnlTituloEstado);
            this.pnlCardEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardEstado.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.pnlCardEstado.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.pnlCardEstado.Name = "pnlCardEstado";
            this.pnlCardEstado.Padding = new System.Windows.Forms.Padding(14, 10, 14, 10);
            this.pnlCardEstado.Size = new System.Drawing.Size(200, 100);
            // 
            // graEstado
            // 
            this.graEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graEstado.Name = "graEstado";
            this.graEstado.Size = new System.Drawing.Size(300, 160);
            this.graEstado.TextoCentro = "Total";
            // 
            // pnlTituloEstado
            // 
            this.pnlTituloEstado.Controls.Add(this.lblIconoEstado);
            this.pnlTituloEstado.Controls.Add(this.lblTituloEstado);
            this.pnlTituloEstado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTituloEstado.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.pnlTituloEstado.Name = "pnlTituloEstado";
            this.pnlTituloEstado.Size = new System.Drawing.Size(200, 32);
            // 
            // lblIconoEstado
            // 
            this.lblIconoEstado.AutoSize = true;
            this.lblIconoEstado.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.lblIconoEstado.Font = new System.Drawing.Font("Segoe MDL2 Assets", 13F);
            this.lblIconoEstado.ForeColor = System.Drawing.Color.FromArgb(168, 85, 247);
            this.lblIconoEstado.Location = new System.Drawing.Point(0, 3);
            this.lblIconoEstado.Name = "lblIconoEstado";
            this.lblIconoEstado.Text = "\uE71D";
            // 
            // lblTituloEstado
            // 
            this.lblTituloEstado.AutoSize = true;
            this.lblTituloEstado.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.lblTituloEstado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTituloEstado.ForeColor = System.Drawing.Color.White;
            this.lblTituloEstado.Location = new System.Drawing.Point(28, 4);
            this.lblTituloEstado.Name = "lblTituloEstado";
            this.lblTituloEstado.Text = "Registros por estado";
            // 
            // pnlCardCategoria
            // 
            this.pnlCardCategoria.Controls.Add(this.graCategoria);
            this.pnlCardCategoria.Controls.Add(this.pnlTituloCategoria);
            this.pnlCardCategoria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardCategoria.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.pnlCardCategoria.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.pnlCardCategoria.Name = "pnlCardCategoria";
            this.pnlCardCategoria.Padding = new System.Windows.Forms.Padding(14, 10, 14, 10);
            this.pnlCardCategoria.Size = new System.Drawing.Size(200, 100);
            // 
            // graCategoria
            // 
            this.graCategoria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graCategoria.Name = "graCategoria";
            this.graCategoria.Size = new System.Drawing.Size(300, 160);
            // 
            // pnlTituloCategoria
            // 
            this.pnlTituloCategoria.Controls.Add(this.lblIconoCategoria);
            this.pnlTituloCategoria.Controls.Add(this.lblTituloCategoria);
            this.pnlTituloCategoria.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTituloCategoria.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.pnlTituloCategoria.Name = "pnlTituloCategoria";
            this.pnlTituloCategoria.Size = new System.Drawing.Size(200, 32);
            // 
            // lblIconoCategoria
            // 
            this.lblIconoCategoria.AutoSize = true;
            this.lblIconoCategoria.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.lblIconoCategoria.Font = new System.Drawing.Font("Segoe MDL2 Assets", 13F);
            this.lblIconoCategoria.ForeColor = System.Drawing.Color.FromArgb(96, 165, 250);
            this.lblIconoCategoria.Location = new System.Drawing.Point(0, 3);
            this.lblIconoCategoria.Name = "lblIconoCategoria";
            this.lblIconoCategoria.Text = "\uE8FD";
            // 
            // lblTituloCategoria
            // 
            this.lblTituloCategoria.AutoSize = true;
            this.lblTituloCategoria.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.lblTituloCategoria.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTituloCategoria.ForeColor = System.Drawing.Color.White;
            this.lblTituloCategoria.Location = new System.Drawing.Point(28, 4);
            this.lblTituloCategoria.Name = "lblTituloCategoria";
            this.lblTituloCategoria.Text = "Registros por estado";
            // 
            // pnlTituloResumen
            // 
            this.pnlTituloResumen.Controls.Add(this.lblTituloResumen);
            this.pnlTituloResumen.Controls.Add(this.lblSubtituloResumen);
            this.pnlTituloResumen.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTituloResumen.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.pnlTituloResumen.Name = "pnlTituloResumen";
            this.pnlTituloResumen.Size = new System.Drawing.Size(880, 70);
            // 
            // lblTituloResumen
            // 
            this.lblTituloResumen.AutoSize = true;
            this.lblTituloResumen.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloResumen.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTituloResumen.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.lblTituloResumen.Location = new System.Drawing.Point(0, 0);
            this.lblTituloResumen.Name = "lblTituloResumen";
            this.lblTituloResumen.Text = "Resumen de compras";
            // 
            // lblSubtituloResumen
            // 
            this.lblSubtituloResumen.AutoSize = true;
            this.lblSubtituloResumen.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtituloResumen.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtituloResumen.ForeColor = System.Drawing.Color.FromArgb(160, 170, 220);
            this.lblSubtituloResumen.Location = new System.Drawing.Point(0, 36);
            this.lblSubtituloResumen.Name = "lblSubtituloResumen";
            this.lblSubtituloResumen.Text = "Estadísticas y distribución de compras.";
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.Controls.Add(this.btnTabConsultar);
            this.pnlCabecera.Controls.Add(this.btnTabGestionar);
            this.pnlCabecera.Controls.Add(this.btnTabResumen);
            this.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCabecera.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(880, 44);
            // 
            // btnTabConsultar
            // 
            this.btnTabConsultar.BackColor = System.Drawing.Color.FromArgb(22, 28, 76);
            this.btnTabConsultar.ColorHover = System.Drawing.Color.FromArgb(34, 42, 110);
            this.btnTabConsultar.ColorSeleccionado = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnTabConsultar.ColorSeleccionadoFin = System.Drawing.Color.FromArgb(124, 58, 237);
            this.btnTabConsultar.Degradado = true;
            this.btnTabConsultar.Location = new System.Drawing.Point(0, 6);
            this.btnTabConsultar.Name = "btnTabConsultar";
            this.btnTabConsultar.Radio = 6;
            this.btnTabConsultar.Size = new System.Drawing.Size(104, 30);
            this.btnTabConsultar.Text = "Consultar";
            this.btnTabConsultar.Click += new System.EventHandler(this.btnTabConsultar_Click);
            // 
            // btnTabGestionar
            // 
            this.btnTabGestionar.BackColor = System.Drawing.Color.FromArgb(22, 28, 76);
            this.btnTabGestionar.ColorHover = System.Drawing.Color.FromArgb(34, 42, 110);
            this.btnTabGestionar.ColorSeleccionado = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnTabGestionar.ColorSeleccionadoFin = System.Drawing.Color.FromArgb(124, 58, 237);
            this.btnTabGestionar.Degradado = true;
            this.btnTabGestionar.Location = new System.Drawing.Point(108, 6);
            this.btnTabGestionar.Name = "btnTabGestionar";
            this.btnTabGestionar.Radio = 6;
            this.btnTabGestionar.Size = new System.Drawing.Size(104, 30);
            this.btnTabGestionar.Text = "Gestionar";
            this.btnTabGestionar.Click += new System.EventHandler(this.btnTabGestionar_Click);
            // 
            // btnTabResumen
            // 
            this.btnTabResumen.BackColor = System.Drawing.Color.FromArgb(22, 28, 76);
            this.btnTabResumen.ColorHover = System.Drawing.Color.FromArgb(34, 42, 110);
            this.btnTabResumen.ColorSeleccionado = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnTabResumen.ColorSeleccionadoFin = System.Drawing.Color.FromArgb(124, 58, 237);
            this.btnTabResumen.Degradado = true;
            this.btnTabResumen.Location = new System.Drawing.Point(216, 6);
            this.btnTabResumen.Name = "btnTabResumen";
            this.btnTabResumen.Radio = 6;
            this.btnTabResumen.Size = new System.Drawing.Size(104, 30);
            this.btnTabResumen.Text = "Resumen";
            this.btnTabResumen.Click += new System.EventHandler(this.btnTabResumen_Click);
            this.pnlCabecera.ResumeLayout(false);
            this.pnlTituloResumen.ResumeLayout(false);
            this.pnlTituloCategoria.ResumeLayout(false);
            this.pnlCardCategoria.ResumeLayout(false);
            this.pnlTituloEstado.ResumeLayout(false);
            this.pnlCardEstado.ResumeLayout(false);
            this.tlpResumenGraficos.ResumeLayout(false);
            this.tpResumen.ResumeLayout(false);
            this.pnlTituloGestion.ResumeLayout(false);
            this.pnlIconoForm.ResumeLayout(false);
            this.pnlTituloForm.ResumeLayout(false);
            this.pnlEstado.ResumeLayout(false);
            this.tlpCampos.ResumeLayout(false);
            this.pnlFormulario.ResumeLayout(false);
            this.pnlEncabezadoWrap.ResumeLayout(false);
            this.pnlBarra.ResumeLayout(false);
            this.pnlIconoDetalle.ResumeLayout(false);
            this.pnlTituloDetalle.ResumeLayout(false);
            this.pnlEstadoDetalle.ResumeLayout(false);
            this.tlpDetalle.ResumeLayout(false);
            this.pnlDetalle.ResumeLayout(false);
            this.tpGestionar.ResumeLayout(false);
            this.pnlTituloConsulta.ResumeLayout(false);
            this.tlpKpi.ResumeLayout(false);
            this.pnlKpi.ResumeLayout(false);
            this.pnlIconoLista.ResumeLayout(false);
            this.pnlToolbarTop.ResumeLayout(false);
            this.pnlFiltroEstado.ResumeLayout(false);
            this.pnlToolbarFiltros.ResumeLayout(false);
            this.pnlToolbar.ResumeLayout(false);
            this.pnlPie.ResumeLayout(false);
            this.pnlLista.ResumeLayout(false);
            this.tpConsultar.ResumeLayout(false);
            this.tabModulo.ResumeLayout(false);
            this.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleCompra)).EndInit();
            this.PerformLayout();
        }

        #endregion

        private Presentacion.TabControlSinEncabezado tabModulo;
        private System.Windows.Forms.TabPage tpConsultar;
        private Presentacion.RoundedPanel pnlLista;
        private System.Windows.Forms.DataGridView dgvCompras;
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
        private Presentacion.RoundedPanel pnlDetalle;
        private System.Windows.Forms.DataGridView dgvDetalleCompra;
        private System.Windows.Forms.TableLayoutPanel tlpDetalle;
        private System.Windows.Forms.Label lblCodigoDetalleCompra;
        private System.Windows.Forms.TextBox txtCodigoDetalleCompra;
        private System.Windows.Forms.Label lblTipoDeCompra;
        private System.Windows.Forms.TextBox txtTipoDeCompra;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblPrecioUnitario;
        private System.Windows.Forms.TextBox txtPrecioUnitario;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Label lblDescuentoCompra;
        private System.Windows.Forms.TextBox txtDescuentoCompra;
        private System.Windows.Forms.Label lblEstadoDetalle;
        private System.Windows.Forms.Panel pnlEstadoDetalle;
        private System.Windows.Forms.RadioButton rdoActivoDetalle;
        private System.Windows.Forms.RadioButton rdoInactivoDetalle;
        private Presentacion.BotonIcono btnAgregarDetalle;
        private System.Windows.Forms.Panel pnlTituloDetalle;
        private Presentacion.RoundedPanel pnlIconoDetalle;
        private System.Windows.Forms.Label lblGlyphDetalle;
        private System.Windows.Forms.Label lblTituloDetalle;
        private System.Windows.Forms.Panel pnlBarra;
        private System.Windows.Forms.Label lblSubtotalDetalle;
        private System.Windows.Forms.Label lblDescuentoDetalle;
        private System.Windows.Forms.Label lblTotalDetalle;
        private Presentacion.BotonIcono btnLimpiar;
        private System.Windows.Forms.Panel sepBarraA;
        private Presentacion.BotonIcono btnCancelar;
        private System.Windows.Forms.Panel sepBarraB;
        private Presentacion.BotonIcono btnGuardar;
        private System.Windows.Forms.Panel pnlEncabezadoWrap;
        private Presentacion.RoundedPanel pnlFormulario;
        private System.Windows.Forms.TableLayoutPanel tlpCampos;
        private System.Windows.Forms.Label lblCodigoCompra;
        private System.Windows.Forms.TextBox txtCodigoCompra;
        private System.Windows.Forms.Label lblCodigoProveedor;
        private System.Windows.Forms.ComboBox cmbCodigoProveedor;
        private System.Windows.Forms.Label lblCodigoMaterial;
        private System.Windows.Forms.ComboBox cmbCodigoMaterial;
        private System.Windows.Forms.Label lblCantidadComprada;
        private System.Windows.Forms.TextBox txtCantidadComprada;
        private System.Windows.Forms.Label lblTotalCompra;
        private System.Windows.Forms.TextBox txtTotalCompra;
        private System.Windows.Forms.Label lblFechaCompra;
        private System.Windows.Forms.DateTimePicker dtpFechaCompra;
        private System.Windows.Forms.Label lblFechaEntrega;
        private System.Windows.Forms.DateTimePicker dtpFechaEntrega;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Panel pnlEstado;
        private System.Windows.Forms.RadioButton rdoActivo;
        private System.Windows.Forms.RadioButton rdoInactivo;
        private System.Windows.Forms.Panel pnlTituloForm;
        private Presentacion.RoundedPanel pnlIconoForm;
        private System.Windows.Forms.Label lblGlyphForm;
        private System.Windows.Forms.Label lblTituloForm;
        private System.Windows.Forms.Panel pnlTituloGestion;
        private System.Windows.Forms.Label lblTituloGestion;
        private System.Windows.Forms.Label lblSubtituloGestion;
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
    }
}
