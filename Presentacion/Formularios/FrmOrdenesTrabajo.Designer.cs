namespace Presentacion
{
    partial class FrmOrdenesTrabajo
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
            this.pnlLista = new Presentacion.RoundedPanel();
            this.dgvOrdenesTrabajo = new System.Windows.Forms.DataGridView();
            this.pnlPie = new System.Windows.Forms.Panel();
            this.lblTotalRegistros = new System.Windows.Forms.Label();
            this.pnlBusqueda = new System.Windows.Forms.Panel();
            this.csBuscar = new Presentacion.CampoBusqueda();
            this.pnlSeparadorBusqueda = new System.Windows.Forms.Panel();
            this.btnBuscar = new Presentacion.BotonIcono();
            this.pnlSeccion = new System.Windows.Forms.Panel();
            this.pnlGestionar = new System.Windows.Forms.Panel();
            this.pnlFormulario = new Presentacion.RoundedPanel();
            this.tlpCampos = new System.Windows.Forms.TableLayoutPanel();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigoOrdenTrabajo = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblTipoServicio = new System.Windows.Forms.Label();
            this.lblFechaEntrega = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblDatos = new System.Windows.Forms.Label();
            this.pnlSeparador = new System.Windows.Forms.Panel();
            this.pnlAcciones = new Presentacion.RoundedPanel();
            this.tlpAcciones = new System.Windows.Forms.TableLayoutPanel();
            this.btnNuevo = new Presentacion.BotonIcono();
            this.btnGuardar = new Presentacion.BotonIcono();
            this.btnEditar = new Presentacion.BotonIcono();
            this.btnEliminar = new Presentacion.BotonIcono();
            this.btnCancelar = new Presentacion.BotonIcono();
            this.btnLimpiar = new Presentacion.BotonIcono();
            this.pnlConsultar = new Presentacion.RoundedPanel();
            this.tlpFiltros = new System.Windows.Forms.TableLayoutPanel();
            this.lblFiltroEstado = new System.Windows.Forms.Label();
            this.cmbFiltroEstado = new System.Windows.Forms.ComboBox();
            this.btnQuitarFiltros = new Presentacion.BotonIcono();
            this.lblFiltros = new System.Windows.Forms.Label();
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnTabGestionar = new Presentacion.BotonIcono();
            this.btnTabConsultar = new Presentacion.BotonIcono();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboxCodigoSucursal = new System.Windows.Forms.ComboBox();
            this.cboxCodigoTipoServicio = new System.Windows.Forms.ComboBox();
            this.cboxCodigoCotizacion = new System.Windows.Forms.ComboBox();
            this.cboxCodigoDiseñador = new System.Windows.Forms.ComboBox();
            this.txtNombreOrden = new System.Windows.Forms.TextBox();
            this.txtTipoOrden = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFechaFinalizacion = new System.Windows.Forms.DateTimePicker();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdbInactivo = new System.Windows.Forms.RadioButton();
            this.rdbActivo = new System.Windows.Forms.RadioButton();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigoSucursal = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colCodigoTipoServicio = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colCodigoCotizacion = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colCodigoDiseñador = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colNombreOrden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipoOrden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaFinalizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenesTrabajo)).BeginInit();
            this.pnlPie.SuspendLayout();
            this.pnlBusqueda.SuspendLayout();
            this.pnlSeccion.SuspendLayout();
            this.pnlGestionar.SuspendLayout();
            this.pnlFormulario.SuspendLayout();
            this.tlpCampos.SuspendLayout();
            this.pnlAcciones.SuspendLayout();
            this.tlpAcciones.SuspendLayout();
            this.pnlConsultar.SuspendLayout();
            this.tlpFiltros.SuspendLayout();
            this.pnlCabecera.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLista
            // 
            this.pnlLista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlLista.Controls.Add(this.dgvOrdenesTrabajo);
            this.pnlLista.Controls.Add(this.pnlPie);
            this.pnlLista.Controls.Add(this.pnlBusqueda);
            this.pnlLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLista.Location = new System.Drawing.Point(20, 351);
            this.pnlLista.Name = "pnlLista";
            this.pnlLista.Padding = new System.Windows.Forms.Padding(12, 12, 12, 6);
            this.pnlLista.Size = new System.Drawing.Size(1996, 1007);
            this.pnlLista.TabIndex = 0;
            // 
            // dgvOrdenesTrabajo
            // 
            this.dgvOrdenesTrabajo.ColumnHeadersHeight = 46;
            this.dgvOrdenesTrabajo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colCodigoSucursal,
            this.colCodigoTipoServicio,
            this.colCodigoCotizacion,
            this.colCodigoDiseñador,
            this.colNombreOrden,
            this.colTipoOrden,
            this.colFechaInicio,
            this.colFechaFinalizacion,
            this.colDescripcion,
            this.colEstado});
            this.dgvOrdenesTrabajo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrdenesTrabajo.Location = new System.Drawing.Point(12, 58);
            this.dgvOrdenesTrabajo.Name = "dgvOrdenesTrabajo";
            this.dgvOrdenesTrabajo.RowHeadersWidth = 82;
            this.dgvOrdenesTrabajo.Size = new System.Drawing.Size(1972, 917);
            this.dgvOrdenesTrabajo.TabIndex = 0;
            this.dgvOrdenesTrabajo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvOrdenesTrabajo_CellFormatting);
            // 
            // pnlPie
            // 
            this.pnlPie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlPie.Controls.Add(this.lblTotalRegistros);
            this.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPie.Location = new System.Drawing.Point(12, 975);
            this.pnlPie.Name = "pnlPie";
            this.pnlPie.Size = new System.Drawing.Size(1972, 26);
            this.pnlPie.TabIndex = 1;
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.AutoSize = true;
            this.lblTotalRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalRegistros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblTotalRegistros.Location = new System.Drawing.Point(0, 6);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(203, 25);
            this.lblTotalRegistros.TabIndex = 0;
            this.lblTotalRegistros.Text = "Total de registros: 0";
            // 
            // pnlBusqueda
            // 
            this.pnlBusqueda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlBusqueda.Controls.Add(this.csBuscar);
            this.pnlBusqueda.Controls.Add(this.pnlSeparadorBusqueda);
            this.pnlBusqueda.Controls.Add(this.btnBuscar);
            this.pnlBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBusqueda.Location = new System.Drawing.Point(12, 12);
            this.pnlBusqueda.Name = "pnlBusqueda";
            this.pnlBusqueda.Padding = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.pnlBusqueda.Size = new System.Drawing.Size(1972, 46);
            this.pnlBusqueda.TabIndex = 2;
            // 
            // csBuscar
            // 
            this.csBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.csBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.csBuscar.Location = new System.Drawing.Point(0, 0);
            this.csBuscar.Name = "csBuscar";
            this.csBuscar.Placeholder = "Buscar por código, cliente o descripción...";
            this.csBuscar.Radio = 8;
            this.csBuscar.Size = new System.Drawing.Size(1806, 34);
            this.csBuscar.TabIndex = 0;
            // 
            // pnlSeparadorBusqueda
            // 
            this.pnlSeparadorBusqueda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlSeparadorBusqueda.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSeparadorBusqueda.Location = new System.Drawing.Point(1806, 0);
            this.pnlSeparadorBusqueda.Name = "pnlSeparadorBusqueda";
            this.pnlSeparadorBusqueda.Size = new System.Drawing.Size(10, 34);
            this.pnlSeparadorBusqueda.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(50)))), ((int)(((byte)(128)))));
            this.btnBuscar.ColorBorde = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(190)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Glyph = "";
            this.btnBuscar.Location = new System.Drawing.Point(1816, 0);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(156, 34);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // pnlSeccion
            // 
            this.pnlSeccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.pnlSeccion.Controls.Add(this.pnlGestionar);
            this.pnlSeccion.Controls.Add(this.pnlConsultar);
            this.pnlSeccion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeccion.Location = new System.Drawing.Point(20, 80);
            this.pnlSeccion.Name = "pnlSeccion";
            this.pnlSeccion.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.pnlSeccion.Size = new System.Drawing.Size(1996, 271);
            this.pnlSeccion.TabIndex = 1;
            // 
            // pnlGestionar
            // 
            this.pnlGestionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.pnlGestionar.Controls.Add(this.pnlFormulario);
            this.pnlGestionar.Controls.Add(this.pnlSeparador);
            this.pnlGestionar.Controls.Add(this.pnlAcciones);
            this.pnlGestionar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGestionar.Location = new System.Drawing.Point(0, 0);
            this.pnlGestionar.Name = "pnlGestionar";
            this.pnlGestionar.Size = new System.Drawing.Size(1996, 261);
            this.pnlGestionar.TabIndex = 0;
            // 
            // pnlFormulario
            // 
            this.pnlFormulario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlFormulario.Controls.Add(this.tlpCampos);
            this.pnlFormulario.Controls.Add(this.lblDatos);
            this.pnlFormulario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFormulario.Location = new System.Drawing.Point(0, 0);
            this.pnlFormulario.Name = "pnlFormulario";
            this.pnlFormulario.Padding = new System.Windows.Forms.Padding(15, 10, 15, 6);
            this.pnlFormulario.Size = new System.Drawing.Size(1826, 261);
            this.pnlFormulario.TabIndex = 0;
            // 
            // tlpCampos
            // 
            this.tlpCampos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.tlpCampos.ColumnCount = 3;
            this.tlpCampos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpCampos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpCampos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpCampos.Controls.Add(this.panel1, 2, 5);
            this.tlpCampos.Controls.Add(this.txtDescripcion, 2, 3);
            this.tlpCampos.Controls.Add(this.dtpFechaFinalizacion, 2, 1);
            this.tlpCampos.Controls.Add(this.label6, 1, 6);
            this.tlpCampos.Controls.Add(this.txtTipoOrden, 1, 5);
            this.tlpCampos.Controls.Add(this.txtNombreOrden, 1, 3);
            this.tlpCampos.Controls.Add(this.cboxCodigoDiseñador, 1, 1);
            this.tlpCampos.Controls.Add(this.label5, 0, 6);
            this.tlpCampos.Controls.Add(this.label4, 2, 4);
            this.tlpCampos.Controls.Add(this.label3, 2, 2);
            this.tlpCampos.Controls.Add(this.label1, 2, 0);
            this.tlpCampos.Controls.Add(this.lblCodigo, 0, 0);
            this.tlpCampos.Controls.Add(this.txtCodigoOrdenTrabajo, 0, 1);
            this.tlpCampos.Controls.Add(this.lblEstado, 1, 0);
            this.tlpCampos.Controls.Add(this.lblCliente, 0, 2);
            this.tlpCampos.Controls.Add(this.lblTipoServicio, 1, 2);
            this.tlpCampos.Controls.Add(this.lblFechaEntrega, 0, 4);
            this.tlpCampos.Controls.Add(this.lblDescripcion, 1, 4);
            this.tlpCampos.Controls.Add(this.cboxCodigoSucursal, 0, 3);
            this.tlpCampos.Controls.Add(this.cboxCodigoTipoServicio, 0, 5);
            this.tlpCampos.Controls.Add(this.cboxCodigoCotizacion, 0, 7);
            this.tlpCampos.Controls.Add(this.dtpFechaInicio, 1, 7);
            this.tlpCampos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCampos.Location = new System.Drawing.Point(15, 36);
            this.tlpCampos.Name = "tlpCampos";
            this.tlpCampos.RowCount = 10;
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpCampos.Size = new System.Drawing.Size(1796, 219);
            this.tlpCampos.TabIndex = 0;
            // 
            // lblCodigo
            // 
            this.lblCodigo.BackColor = System.Drawing.Color.Transparent;
            this.lblCodigo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblCodigo.Location = new System.Drawing.Point(0, 0);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(598, 22);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código Orden:";
            this.lblCodigo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtCodigoOrdenTrabajo
            // 
            this.txtCodigoOrdenTrabajo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodigoOrdenTrabajo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.txtCodigoOrdenTrabajo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoOrdenTrabajo.ForeColor = System.Drawing.Color.White;
            this.txtCodigoOrdenTrabajo.Location = new System.Drawing.Point(0, 25);
            this.txtCodigoOrdenTrabajo.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.txtCodigoOrdenTrabajo.Name = "txtCodigoOrdenTrabajo";
            this.txtCodigoOrdenTrabajo.ReadOnly = true;
            this.txtCodigoOrdenTrabajo.Size = new System.Drawing.Size(582, 31);
            this.txtCodigoOrdenTrabajo.TabIndex = 1;
            // 
            // lblEstado
            // 
            this.lblEstado.BackColor = System.Drawing.Color.Transparent;
            this.lblEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblEstado.Location = new System.Drawing.Point(598, 0);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(598, 22);
            this.lblEstado.TabIndex = 2;
            this.lblEstado.Text = "Código Diseñador:";
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblCliente
            // 
            this.lblCliente.BackColor = System.Drawing.Color.Transparent;
            this.lblCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblCliente.Location = new System.Drawing.Point(0, 54);
            this.lblCliente.Margin = new System.Windows.Forms.Padding(0);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(598, 22);
            this.lblCliente.TabIndex = 4;
            this.lblCliente.Text = "Código Sucursal:";
            this.lblCliente.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblTipoServicio
            // 
            this.lblTipoServicio.BackColor = System.Drawing.Color.Transparent;
            this.lblTipoServicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTipoServicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblTipoServicio.Location = new System.Drawing.Point(598, 54);
            this.lblTipoServicio.Margin = new System.Windows.Forms.Padding(0);
            this.lblTipoServicio.Name = "lblTipoServicio";
            this.lblTipoServicio.Size = new System.Drawing.Size(598, 22);
            this.lblTipoServicio.TabIndex = 6;
            this.lblTipoServicio.Text = "Nombre Orden:";
            this.lblTipoServicio.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblFechaEntrega
            // 
            this.lblFechaEntrega.BackColor = System.Drawing.Color.Transparent;
            this.lblFechaEntrega.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFechaEntrega.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblFechaEntrega.Location = new System.Drawing.Point(0, 108);
            this.lblFechaEntrega.Margin = new System.Windows.Forms.Padding(0);
            this.lblFechaEntrega.Name = "lblFechaEntrega";
            this.lblFechaEntrega.Size = new System.Drawing.Size(598, 22);
            this.lblFechaEntrega.TabIndex = 8;
            this.lblFechaEntrega.Text = "Código Tipo Servicio:";
            this.lblFechaEntrega.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(598, 187);
            this.dtpFechaInicio.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(582, 31);
            this.dtpFechaInicio.TabIndex = 9;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.BackColor = System.Drawing.Color.Transparent;
            this.lblDescripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblDescripcion.Location = new System.Drawing.Point(598, 108);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(598, 22);
            this.lblDescripcion.TabIndex = 10;
            this.lblDescripcion.Text = "Tipo de orden:";
            this.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblDatos
            // 
            this.lblDatos.BackColor = System.Drawing.Color.Transparent;
            this.lblDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDatos.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDatos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(208)))), ((int)(((byte)(240)))));
            this.lblDatos.Location = new System.Drawing.Point(15, 10);
            this.lblDatos.Name = "lblDatos";
            this.lblDatos.Size = new System.Drawing.Size(1796, 26);
            this.lblDatos.TabIndex = 1;
            this.lblDatos.Text = "Datos de la Orden de Trabajo";
            this.lblDatos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSeparador
            // 
            this.pnlSeparador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.pnlSeparador.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSeparador.Location = new System.Drawing.Point(1826, 0);
            this.pnlSeparador.Name = "pnlSeparador";
            this.pnlSeparador.Size = new System.Drawing.Size(10, 261);
            this.pnlSeparador.TabIndex = 1;
            // 
            // pnlAcciones
            // 
            this.pnlAcciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlAcciones.Controls.Add(this.tlpAcciones);
            this.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlAcciones.Location = new System.Drawing.Point(1836, 0);
            this.pnlAcciones.Name = "pnlAcciones";
            this.pnlAcciones.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlAcciones.Size = new System.Drawing.Size(160, 261);
            this.pnlAcciones.TabIndex = 2;
            // 
            // tlpAcciones
            // 
            this.tlpAcciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.tlpAcciones.ColumnCount = 1;
            this.tlpAcciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAcciones.Controls.Add(this.btnNuevo, 0, 0);
            this.tlpAcciones.Controls.Add(this.btnGuardar, 0, 1);
            this.tlpAcciones.Controls.Add(this.btnEditar, 0, 2);
            this.tlpAcciones.Controls.Add(this.btnEliminar, 0, 3);
            this.tlpAcciones.Controls.Add(this.btnCancelar, 0, 4);
            this.tlpAcciones.Controls.Add(this.btnLimpiar, 0, 5);
            this.tlpAcciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAcciones.Location = new System.Drawing.Point(12, 8);
            this.tlpAcciones.Name = "tlpAcciones";
            this.tlpAcciones.RowCount = 6;
            this.tlpAcciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpAcciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpAcciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpAcciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpAcciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpAcciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpAcciones.Size = new System.Drawing.Size(136, 245);
            this.tlpAcciones.TabIndex = 0;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(130)))), ((int)(((byte)(170)))));
            this.btnNuevo.ColorBorde = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(180)))), ((int)(((byte)(220)))));
            this.btnNuevo.ColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(160)))), ((int)(((byte)(205)))));
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Glyph = "";
            this.btnNuevo.Location = new System.Drawing.Point(0, 3);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(136, 34);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(50)))), ((int)(((byte)(128)))));
            this.btnGuardar.ColorBorde = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(190)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Glyph = "";
            this.btnGuardar.Location = new System.Drawing.Point(0, 43);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(136, 34);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(50)))), ((int)(((byte)(128)))));
            this.btnEditar.ColorBorde = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(190)))));
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Glyph = "";
            this.btnEditar.Location = new System.Drawing.Point(0, 83);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(136, 34);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(50)))), ((int)(((byte)(128)))));
            this.btnEliminar.ColorBorde = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(190)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Glyph = "";
            this.btnEliminar.Location = new System.Drawing.Point(0, 123);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(136, 34);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(50)))), ((int)(((byte)(128)))));
            this.btnCancelar.ColorBorde = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(190)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Glyph = "";
            this.btnCancelar.Location = new System.Drawing.Point(0, 163);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(136, 34);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(50)))), ((int)(((byte)(128)))));
            this.btnLimpiar.ColorBorde = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(190)))));
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Glyph = "";
            this.btnLimpiar.Location = new System.Drawing.Point(0, 203);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(136, 39);
            this.btnLimpiar.TabIndex = 5;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // pnlConsultar
            // 
            this.pnlConsultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlConsultar.Controls.Add(this.tlpFiltros);
            this.pnlConsultar.Controls.Add(this.lblFiltros);
            this.pnlConsultar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConsultar.Location = new System.Drawing.Point(0, 0);
            this.pnlConsultar.Name = "pnlConsultar";
            this.pnlConsultar.Padding = new System.Windows.Forms.Padding(15, 10, 15, 6);
            this.pnlConsultar.Size = new System.Drawing.Size(1996, 261);
            this.pnlConsultar.TabIndex = 1;
            this.pnlConsultar.Visible = false;
            // 
            // tlpFiltros
            // 
            this.tlpFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.tlpFiltros.ColumnCount = 2;
            this.tlpFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFiltros.Controls.Add(this.lblFiltroEstado, 0, 0);
            this.tlpFiltros.Controls.Add(this.cmbFiltroEstado, 0, 1);
            this.tlpFiltros.Controls.Add(this.btnQuitarFiltros, 0, 2);
            this.tlpFiltros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFiltros.Location = new System.Drawing.Point(15, 36);
            this.tlpFiltros.Name = "tlpFiltros";
            this.tlpFiltros.RowCount = 3;
            this.tlpFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlpFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpFiltros.Size = new System.Drawing.Size(1966, 219);
            this.tlpFiltros.TabIndex = 0;
            // 
            // lblFiltroEstado
            // 
            this.lblFiltroEstado.BackColor = System.Drawing.Color.Transparent;
            this.lblFiltroEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFiltroEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblFiltroEstado.Location = new System.Drawing.Point(0, 0);
            this.lblFiltroEstado.Margin = new System.Windows.Forms.Padding(0);
            this.lblFiltroEstado.Name = "lblFiltroEstado";
            this.lblFiltroEstado.Size = new System.Drawing.Size(983, 22);
            this.lblFiltroEstado.TabIndex = 0;
            this.lblFiltroEstado.Text = "Estado:";
            this.lblFiltroEstado.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
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
            "Pendiente",
            "En proceso",
            "Terminada",
            "Entregada"});
            this.cmbFiltroEstado.Location = new System.Drawing.Point(0, 25);
            this.cmbFiltroEstado.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.cmbFiltroEstado.Name = "cmbFiltroEstado";
            this.cmbFiltroEstado.Size = new System.Drawing.Size(967, 33);
            this.cmbFiltroEstado.TabIndex = 1;
            // 
            // btnQuitarFiltros
            // 
            this.btnQuitarFiltros.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnQuitarFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(50)))), ((int)(((byte)(128)))));
            this.btnQuitarFiltros.ColorBorde = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(190)))));
            this.btnQuitarFiltros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitarFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarFiltros.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnQuitarFiltros.ForeColor = System.Drawing.Color.White;
            this.btnQuitarFiltros.Glyph = "";
            this.btnQuitarFiltros.Location = new System.Drawing.Point(3, 121);
            this.btnQuitarFiltros.Name = "btnQuitarFiltros";
            this.btnQuitarFiltros.Size = new System.Drawing.Size(150, 30);
            this.btnQuitarFiltros.TabIndex = 2;
            this.btnQuitarFiltros.Text = "Quitar filtros";
            this.btnQuitarFiltros.UseVisualStyleBackColor = false;
            this.btnQuitarFiltros.Click += new System.EventHandler(this.btnQuitarFiltros_Click);
            // 
            // lblFiltros
            // 
            this.lblFiltros.BackColor = System.Drawing.Color.Transparent;
            this.lblFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFiltros.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFiltros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(208)))), ((int)(((byte)(240)))));
            this.lblFiltros.Location = new System.Drawing.Point(15, 10);
            this.lblFiltros.Name = "lblFiltros";
            this.lblFiltros.Size = new System.Drawing.Size(1966, 26);
            this.lblFiltros.TabIndex = 1;
            this.lblFiltros.Text = "Filtros de consulta";
            this.lblFiltros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.pnlCabecera.Controls.Add(this.lblTitulo);
            this.pnlCabecera.Controls.Add(this.btnTabGestionar);
            this.pnlCabecera.Controls.Add(this.btnTabConsultar);
            this.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCabecera.Location = new System.Drawing.Point(20, 8);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(1996, 72);
            this.pnlCabecera.TabIndex = 2;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblTitulo.Location = new System.Drawing.Point(0, 4);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(341, 47);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Órdenes de Trabajo";
            // 
            // btnTabGestionar
            // 
            this.btnTabGestionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(28)))), ((int)(((byte)(76)))));
            this.btnTabGestionar.ColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.btnTabGestionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabGestionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabGestionar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTabGestionar.ForeColor = System.Drawing.Color.White;
            this.btnTabGestionar.Location = new System.Drawing.Point(0, 38);
            this.btnTabGestionar.Name = "btnTabGestionar";
            this.btnTabGestionar.Radio = 6;
            this.btnTabGestionar.Size = new System.Drawing.Size(90, 30);
            this.btnTabGestionar.TabIndex = 1;
            this.btnTabGestionar.Text = "Gestionar";
            this.btnTabGestionar.UseVisualStyleBackColor = false;
            this.btnTabGestionar.Click += new System.EventHandler(this.btnTabGestionar_Click);
            // 
            // btnTabConsultar
            // 
            this.btnTabConsultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(28)))), ((int)(((byte)(76)))));
            this.btnTabConsultar.ColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(42)))), ((int)(((byte)(110)))));
            this.btnTabConsultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabConsultar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTabConsultar.ForeColor = System.Drawing.Color.White;
            this.btnTabConsultar.Location = new System.Drawing.Point(94, 38);
            this.btnTabConsultar.Name = "btnTabConsultar";
            this.btnTabConsultar.Radio = 6;
            this.btnTabConsultar.Size = new System.Drawing.Size(90, 30);
            this.btnTabConsultar.TabIndex = 2;
            this.btnTabConsultar.Text = "Consultar";
            this.btnTabConsultar.UseVisualStyleBackColor = false;
            this.btnTabConsultar.Click += new System.EventHandler(this.btnTabConsultar_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.label1.Location = new System.Drawing.Point(1196, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(600, 22);
            this.label1.TabIndex = 14;
            this.label1.Text = "Fecha de Finalización:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.label3.Location = new System.Drawing.Point(1196, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(600, 22);
            this.label3.TabIndex = 16;
            this.label3.Text = "Descripción:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.label4.Location = new System.Drawing.Point(1196, 108);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(600, 22);
            this.label4.TabIndex = 17;
            this.label4.Text = "Estado:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.label5.Location = new System.Drawing.Point(0, 162);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(598, 22);
            this.label5.TabIndex = 18;
            this.label5.Text = "Código Cotización:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cboxCodigoSucursal
            // 
            this.cboxCodigoSucursal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxCodigoSucursal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.cboxCodigoSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCodigoSucursal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxCodigoSucursal.ForeColor = System.Drawing.Color.White;
            this.cboxCodigoSucursal.Location = new System.Drawing.Point(0, 79);
            this.cboxCodigoSucursal.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.cboxCodigoSucursal.Name = "cboxCodigoSucursal";
            this.cboxCodigoSucursal.Size = new System.Drawing.Size(582, 33);
            this.cboxCodigoSucursal.TabIndex = 20;
            // 
            // cboxCodigoTipoServicio
            // 
            this.cboxCodigoTipoServicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxCodigoTipoServicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.cboxCodigoTipoServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCodigoTipoServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxCodigoTipoServicio.ForeColor = System.Drawing.Color.White;
            this.cboxCodigoTipoServicio.Location = new System.Drawing.Point(0, 133);
            this.cboxCodigoTipoServicio.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.cboxCodigoTipoServicio.Name = "cboxCodigoTipoServicio";
            this.cboxCodigoTipoServicio.Size = new System.Drawing.Size(582, 33);
            this.cboxCodigoTipoServicio.TabIndex = 21;
            // 
            // cboxCodigoCotizacion
            // 
            this.cboxCodigoCotizacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxCodigoCotizacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.cboxCodigoCotizacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCodigoCotizacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxCodigoCotizacion.ForeColor = System.Drawing.Color.White;
            this.cboxCodigoCotizacion.Location = new System.Drawing.Point(0, 187);
            this.cboxCodigoCotizacion.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.cboxCodigoCotizacion.Name = "cboxCodigoCotizacion";
            this.cboxCodigoCotizacion.Size = new System.Drawing.Size(582, 33);
            this.cboxCodigoCotizacion.TabIndex = 22;
            // 
            // cboxCodigoDiseñador
            // 
            this.cboxCodigoDiseñador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxCodigoDiseñador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.cboxCodigoDiseñador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCodigoDiseñador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxCodigoDiseñador.ForeColor = System.Drawing.Color.White;
            this.cboxCodigoDiseñador.Location = new System.Drawing.Point(598, 25);
            this.cboxCodigoDiseñador.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.cboxCodigoDiseñador.Name = "cboxCodigoDiseñador";
            this.cboxCodigoDiseñador.Size = new System.Drawing.Size(582, 33);
            this.cboxCodigoDiseñador.TabIndex = 23;
            // 
            // txtNombreOrden
            // 
            this.txtNombreOrden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombreOrden.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.txtNombreOrden.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreOrden.ForeColor = System.Drawing.Color.White;
            this.txtNombreOrden.Location = new System.Drawing.Point(598, 79);
            this.txtNombreOrden.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.txtNombreOrden.MaxLength = 150;
            this.txtNombreOrden.Name = "txtNombreOrden";
            this.txtNombreOrden.Size = new System.Drawing.Size(582, 31);
            this.txtNombreOrden.TabIndex = 24;
            // 
            // txtTipoOrden
            // 
            this.txtTipoOrden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTipoOrden.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.txtTipoOrden.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTipoOrden.ForeColor = System.Drawing.Color.White;
            this.txtTipoOrden.Location = new System.Drawing.Point(598, 133);
            this.txtTipoOrden.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.txtTipoOrden.MaxLength = 150;
            this.txtTipoOrden.Name = "txtTipoOrden";
            this.txtTipoOrden.Size = new System.Drawing.Size(582, 31);
            this.txtTipoOrden.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.label6.Location = new System.Drawing.Point(598, 162);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(598, 22);
            this.label6.TabIndex = 26;
            this.label6.Text = "Fecha de Inicio:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // dtpFechaFinalizacion
            // 
            this.dtpFechaFinalizacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFechaFinalizacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFinalizacion.Location = new System.Drawing.Point(1196, 25);
            this.dtpFechaFinalizacion.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.dtpFechaFinalizacion.Name = "dtpFechaFinalizacion";
            this.dtpFechaFinalizacion.Size = new System.Drawing.Size(584, 31);
            this.dtpFechaFinalizacion.TabIndex = 27;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.ForeColor = System.Drawing.Color.White;
            this.txtDescripcion.Location = new System.Drawing.Point(1196, 79);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.txtDescripcion.MaxLength = 150;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(584, 26);
            this.txtDescripcion.TabIndex = 28;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdbInactivo);
            this.panel1.Controls.Add(this.rdbActivo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1199, 133);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(594, 26);
            this.panel1.TabIndex = 29;
            // 
            // rdbInactivo
            // 
            this.rdbInactivo.AutoSize = true;
            this.rdbInactivo.Location = new System.Drawing.Point(358, 0);
            this.rdbInactivo.Name = "rdbInactivo";
            this.rdbInactivo.Size = new System.Drawing.Size(117, 29);
            this.rdbInactivo.TabIndex = 15;
            this.rdbInactivo.TabStop = true;
            this.rdbInactivo.Text = "Inactivo";
            this.rdbInactivo.UseVisualStyleBackColor = true;
            // 
            // rdbActivo
            // 
            this.rdbActivo.AutoSize = true;
            this.rdbActivo.Location = new System.Drawing.Point(0, -3);
            this.rdbActivo.Name = "rdbActivo";
            this.rdbActivo.Size = new System.Drawing.Size(102, 29);
            this.rdbActivo.TabIndex = 14;
            this.rdbActivo.TabStop = true;
            this.rdbActivo.Text = "Activo";
            this.rdbActivo.UseVisualStyleBackColor = true;
            // 
            // colCodigo
            // 
            this.colCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colCodigo.DataPropertyName = "txtCodigoOrden";
            this.colCodigo.HeaderText = "Código Orden";
            this.colCodigo.MinimumWidth = 10;
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.Width = 90;
            // 
            // colCodigoSucursal
            // 
            this.colCodigoSucursal.HeaderText = "Código Sucursal";
            this.colCodigoSucursal.MinimumWidth = 10;
            this.colCodigoSucursal.Name = "colCodigoSucursal";
            this.colCodigoSucursal.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCodigoSucursal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colCodigoSucursal.Width = 90;
            // 
            // colCodigoTipoServicio
            // 
            this.colCodigoTipoServicio.HeaderText = "Código Tipo Servicio";
            this.colCodigoTipoServicio.MinimumWidth = 10;
            this.colCodigoTipoServicio.Name = "colCodigoTipoServicio";
            this.colCodigoTipoServicio.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCodigoTipoServicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colCodigoTipoServicio.Width = 90;
            // 
            // colCodigoCotizacion
            // 
            this.colCodigoCotizacion.HeaderText = "Código Cotización";
            this.colCodigoCotizacion.MinimumWidth = 10;
            this.colCodigoCotizacion.Name = "colCodigoCotizacion";
            this.colCodigoCotizacion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCodigoCotizacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colCodigoCotizacion.Width = 90;
            // 
            // colCodigoDiseñador
            // 
            this.colCodigoDiseñador.HeaderText = "Código Diseñador";
            this.colCodigoDiseñador.MinimumWidth = 10;
            this.colCodigoDiseñador.Name = "colCodigoDiseñador";
            this.colCodigoDiseñador.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCodigoDiseñador.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colCodigoDiseñador.Width = 90;
            // 
            // colNombreOrden
            // 
            this.colNombreOrden.HeaderText = "Nombre Orden";
            this.colNombreOrden.MinimumWidth = 10;
            this.colNombreOrden.Name = "colNombreOrden";
            this.colNombreOrden.Width = 300;
            // 
            // colTipoOrden
            // 
            this.colTipoOrden.HeaderText = "Tipo de Orden";
            this.colTipoOrden.MinimumWidth = 10;
            this.colTipoOrden.Name = "colTipoOrden";
            this.colTipoOrden.Width = 200;
            // 
            // colFechaInicio
            // 
            this.colFechaInicio.HeaderText = "Fecha Inicio";
            this.colFechaInicio.MinimumWidth = 10;
            this.colFechaInicio.Name = "colFechaInicio";
            this.colFechaInicio.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colFechaInicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colFechaInicio.Width = 200;
            // 
            // colFechaFinalizacion
            // 
            this.colFechaFinalizacion.HeaderText = "Fecha Finalización";
            this.colFechaFinalizacion.MinimumWidth = 10;
            this.colFechaFinalizacion.Name = "colFechaFinalizacion";
            this.colFechaFinalizacion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colFechaFinalizacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colFechaFinalizacion.Width = 200;
            // 
            // colDescripcion
            // 
            this.colDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescripcion.DataPropertyName = "txtDescripcion";
            this.colDescripcion.FillWeight = 35F;
            this.colDescripcion.HeaderText = "Descripción";
            this.colDescripcion.MinimumWidth = 10;
            this.colDescripcion.Name = "colDescripcion";
            // 
            // colEstado
            // 
            this.colEstado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colEstado.DataPropertyName = "rdbActivo";
            this.colEstado.HeaderText = "Estado";
            this.colEstado.MinimumWidth = 10;
            this.colEstado.Name = "colEstado";
            // 
            // FrmOrdenesTrabajo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(2036, 1374);
            this.Controls.Add(this.pnlLista);
            this.Controls.Add(this.pnlSeccion);
            this.Controls.Add(this.pnlCabecera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmOrdenesTrabajo";
            this.Padding = new System.Windows.Forms.Padding(20, 8, 20, 16);
            this.Text = "Órdenes de Trabajo";
            this.pnlLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenesTrabajo)).EndInit();
            this.pnlPie.ResumeLayout(false);
            this.pnlPie.PerformLayout();
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlSeccion.ResumeLayout(false);
            this.pnlGestionar.ResumeLayout(false);
            this.pnlFormulario.ResumeLayout(false);
            this.tlpCampos.ResumeLayout(false);
            this.tlpCampos.PerformLayout();
            this.pnlAcciones.ResumeLayout(false);
            this.tlpAcciones.ResumeLayout(false);
            this.pnlConsultar.ResumeLayout(false);
            this.tlpFiltros.ResumeLayout(false);
            this.pnlCabecera.ResumeLayout(false);
            this.pnlCabecera.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Presentacion.RoundedPanel pnlLista;
        private System.Windows.Forms.DataGridView dgvOrdenesTrabajo;
        private System.Windows.Forms.Panel pnlPie;
        private System.Windows.Forms.Label lblTotalRegistros;
        private System.Windows.Forms.Panel pnlBusqueda;
        private Presentacion.CampoBusqueda csBuscar;
        private System.Windows.Forms.Panel pnlSeparadorBusqueda;
        private Presentacion.BotonIcono btnBuscar;
        private System.Windows.Forms.Panel pnlSeccion;
        private System.Windows.Forms.Panel pnlGestionar;
        private Presentacion.RoundedPanel pnlFormulario;
        private System.Windows.Forms.TableLayoutPanel tlpCampos;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigoOrdenTrabajo;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblTipoServicio;
        private System.Windows.Forms.Label lblFechaEntrega;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblDatos;
        private System.Windows.Forms.Panel pnlSeparador;
        private Presentacion.RoundedPanel pnlAcciones;
        private System.Windows.Forms.TableLayoutPanel tlpAcciones;
        private Presentacion.BotonIcono btnNuevo;
        private Presentacion.BotonIcono btnGuardar;
        private Presentacion.BotonIcono btnEditar;
        private Presentacion.BotonIcono btnEliminar;
        private Presentacion.BotonIcono btnCancelar;
        private Presentacion.BotonIcono btnLimpiar;
        private Presentacion.RoundedPanel pnlConsultar;
        private System.Windows.Forms.TableLayoutPanel tlpFiltros;
        private System.Windows.Forms.Label lblFiltroEstado;
        private System.Windows.Forms.ComboBox cmbFiltroEstado;
        private Presentacion.BotonIcono btnQuitarFiltros;
        private System.Windows.Forms.Label lblFiltros;
        private System.Windows.Forms.Panel pnlCabecera;
        private System.Windows.Forms.Label lblTitulo;
        private Presentacion.BotonIcono btnTabGestionar;
        private Presentacion.BotonIcono btnTabConsultar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboxCodigoSucursal;
        private System.Windows.Forms.ComboBox cboxCodigoTipoServicio;
        private System.Windows.Forms.ComboBox cboxCodigoCotizacion;
        private System.Windows.Forms.TextBox txtNombreOrden;
        private System.Windows.Forms.ComboBox cboxCodigoDiseñador;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTipoOrden;
        private System.Windows.Forms.DateTimePicker dtpFechaFinalizacion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdbInactivo;
        private System.Windows.Forms.RadioButton rdbActivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewComboBoxColumn colCodigoSucursal;
        private System.Windows.Forms.DataGridViewComboBoxColumn colCodigoTipoServicio;
        private System.Windows.Forms.DataGridViewComboBoxColumn colCodigoCotizacion;
        private System.Windows.Forms.DataGridViewComboBoxColumn colCodigoDiseñador;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreOrden;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoOrden;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaFinalizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
    }
}
