namespace Presentacion
{
    partial class FrmFacturaciones
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
            this.dgvFacturaciones = new System.Windows.Forms.DataGridView();
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigoFactura = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblSucursal = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtImpuestos = new System.Windows.Forms.TextBox();
            this.cboxCodigoOrdenTrabajo = new System.Windows.Forms.ComboBox();
            this.txtNoOrden = new System.Windows.Forms.TextBox();
            this.dtpFechaEntrega = new System.Windows.Forms.DateTimePicker();
            this.textBox3 = new System.Windows.Forms.TextBox();
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
            this.panelEstado = new System.Windows.Forms.Panel();
            this.rdbInactivo = new System.Windows.Forms.RadioButton();
            this.rdbActivo = new System.Windows.Forms.RadioButton();
            this.txtCódigoFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboxCodigoOrden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNoFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtsubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtimpuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturaciones)).BeginInit();
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
            this.panelEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLista
            // 
            this.pnlLista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlLista.Controls.Add(this.dgvFacturaciones);
            this.pnlLista.Controls.Add(this.pnlPie);
            this.pnlLista.Controls.Add(this.pnlBusqueda);
            this.pnlLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLista.Location = new System.Drawing.Point(20, 305);
            this.pnlLista.Name = "pnlLista";
            this.pnlLista.Padding = new System.Windows.Forms.Padding(12, 12, 12, 6);
            this.pnlLista.Size = new System.Drawing.Size(1932, 1051);
            this.pnlLista.TabIndex = 0;
            // 
            // dgvFacturaciones
            // 
            this.dgvFacturaciones.ColumnHeadersHeight = 46;
            this.dgvFacturaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtCódigoFactura,
            this.cboxCodigoOrden,
            this.txtNoFactura,
            this.colFecha,
            this.txtsubtotal,
            this.txtimpuesto,
            this.colTotal,
            this.colEstado});
            this.dgvFacturaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFacturaciones.Location = new System.Drawing.Point(12, 58);
            this.dgvFacturaciones.Name = "dgvFacturaciones";
            this.dgvFacturaciones.RowHeadersWidth = 82;
            this.dgvFacturaciones.Size = new System.Drawing.Size(1908, 961);
            this.dgvFacturaciones.TabIndex = 0;
            this.dgvFacturaciones.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvFacturaciones_CellFormatting);
            // 
            // pnlPie
            // 
            this.pnlPie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlPie.Controls.Add(this.lblTotalRegistros);
            this.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPie.Location = new System.Drawing.Point(12, 1019);
            this.pnlPie.Name = "pnlPie";
            this.pnlPie.Size = new System.Drawing.Size(1908, 26);
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
            this.pnlBusqueda.Size = new System.Drawing.Size(1908, 46);
            this.pnlBusqueda.TabIndex = 2;
            // 
            // csBuscar
            // 
            this.csBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.csBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.csBuscar.Location = new System.Drawing.Point(0, 0);
            this.csBuscar.Name = "csBuscar";
            this.csBuscar.Placeholder = "Buscar por número o cliente...";
            this.csBuscar.Radio = 8;
            this.csBuscar.Size = new System.Drawing.Size(1742, 34);
            this.csBuscar.TabIndex = 0;
            // 
            // pnlSeparadorBusqueda
            // 
            this.pnlSeparadorBusqueda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlSeparadorBusqueda.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSeparadorBusqueda.Location = new System.Drawing.Point(1742, 0);
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
            this.btnBuscar.Location = new System.Drawing.Point(1752, 0);
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
            this.pnlSeccion.Size = new System.Drawing.Size(1932, 225);
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
            this.pnlGestionar.Size = new System.Drawing.Size(1932, 215);
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
            this.pnlFormulario.Size = new System.Drawing.Size(1762, 215);
            this.pnlFormulario.TabIndex = 0;
            // 
            // tlpCampos
            // 
            this.tlpCampos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.tlpCampos.ColumnCount = 3;
            this.tlpCampos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpCampos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpCampos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpCampos.Controls.Add(this.panelEstado, 2, 3);
            this.tlpCampos.Controls.Add(this.label2, 2, 2);
            this.tlpCampos.Controls.Add(this.txtTotal, 2, 1);
            this.tlpCampos.Controls.Add(this.label1, 2, 0);
            this.tlpCampos.Controls.Add(this.lblCodigo, 0, 0);
            this.tlpCampos.Controls.Add(this.txtCodigoFactura, 0, 1);
            this.tlpCampos.Controls.Add(this.lblEstado, 1, 0);
            this.tlpCampos.Controls.Add(this.lblCliente, 0, 2);
            this.tlpCampos.Controls.Add(this.lblFecha, 1, 2);
            this.tlpCampos.Controls.Add(this.lblSucursal, 0, 4);
            this.tlpCampos.Controls.Add(this.lblTotal, 1, 4);
            this.tlpCampos.Controls.Add(this.txtImpuestos, 1, 5);
            this.tlpCampos.Controls.Add(this.cboxCodigoOrdenTrabajo, 0, 3);
            this.tlpCampos.Controls.Add(this.txtNoOrden, 0, 5);
            this.tlpCampos.Controls.Add(this.dtpFechaEntrega, 1, 1);
            this.tlpCampos.Controls.Add(this.textBox3, 1, 3);
            this.tlpCampos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCampos.Location = new System.Drawing.Point(15, 36);
            this.tlpCampos.Name = "tlpCampos";
            this.tlpCampos.RowCount = 6;
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpCampos.Size = new System.Drawing.Size(1732, 173);
            this.tlpCampos.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.label2.Location = new System.Drawing.Point(1154, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(578, 22);
            this.label2.TabIndex = 17;
            this.label2.Text = "Estado:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.ForeColor = System.Drawing.Color.White;
            this.txtTotal.Location = new System.Drawing.Point(1154, 25);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.txtTotal.MaxLength = 15;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(562, 31);
            this.txtTotal.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.label1.Location = new System.Drawing.Point(1154, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(578, 22);
            this.label1.TabIndex = 13;
            this.label1.Text = "Total:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblCodigo
            // 
            this.lblCodigo.BackColor = System.Drawing.Color.Transparent;
            this.lblCodigo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblCodigo.Location = new System.Drawing.Point(0, 0);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(577, 22);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código Factura:";
            this.lblCodigo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtCodigoFactura
            // 
            this.txtCodigoFactura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodigoFactura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.txtCodigoFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoFactura.ForeColor = System.Drawing.Color.White;
            this.txtCodigoFactura.Location = new System.Drawing.Point(0, 25);
            this.txtCodigoFactura.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.txtCodigoFactura.Name = "txtCodigoFactura";
            this.txtCodigoFactura.ReadOnly = true;
            this.txtCodigoFactura.Size = new System.Drawing.Size(561, 31);
            this.txtCodigoFactura.TabIndex = 1;
            // 
            // lblEstado
            // 
            this.lblEstado.BackColor = System.Drawing.Color.Transparent;
            this.lblEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblEstado.Location = new System.Drawing.Point(577, 0);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(577, 22);
            this.lblEstado.TabIndex = 2;
            this.lblEstado.Text = "Fecha de entrega:";
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
            this.lblCliente.Size = new System.Drawing.Size(577, 22);
            this.lblCliente.TabIndex = 4;
            this.lblCliente.Text = "Código Orden Trabajo:";
            this.lblCliente.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblFecha
            // 
            this.lblFecha.BackColor = System.Drawing.Color.Transparent;
            this.lblFecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblFecha.Location = new System.Drawing.Point(577, 54);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(577, 22);
            this.lblFecha.TabIndex = 6;
            this.lblFecha.Text = "Subtotal:";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblSucursal
            // 
            this.lblSucursal.BackColor = System.Drawing.Color.Transparent;
            this.lblSucursal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSucursal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblSucursal.Location = new System.Drawing.Point(0, 108);
            this.lblSucursal.Margin = new System.Windows.Forms.Padding(0);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(577, 22);
            this.lblSucursal.TabIndex = 8;
            this.lblSucursal.Text = "No Factura:";
            this.lblSucursal.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblTotal.Location = new System.Drawing.Point(577, 108);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(577, 22);
            this.lblTotal.TabIndex = 10;
            this.lblTotal.Text = "Impuesto:";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtImpuestos
            // 
            this.txtImpuestos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImpuestos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.txtImpuestos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImpuestos.ForeColor = System.Drawing.Color.White;
            this.txtImpuestos.Location = new System.Drawing.Point(577, 136);
            this.txtImpuestos.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.txtImpuestos.MaxLength = 15;
            this.txtImpuestos.Name = "txtImpuestos";
            this.txtImpuestos.Size = new System.Drawing.Size(561, 31);
            this.txtImpuestos.TabIndex = 11;
            // 
            // cboxCodigoOrdenTrabajo
            // 
            this.cboxCodigoOrdenTrabajo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxCodigoOrdenTrabajo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.cboxCodigoOrdenTrabajo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCodigoOrdenTrabajo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxCodigoOrdenTrabajo.ForeColor = System.Drawing.Color.White;
            this.cboxCodigoOrdenTrabajo.Location = new System.Drawing.Point(0, 79);
            this.cboxCodigoOrdenTrabajo.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.cboxCodigoOrdenTrabajo.Name = "cboxCodigoOrdenTrabajo";
            this.cboxCodigoOrdenTrabajo.Size = new System.Drawing.Size(561, 33);
            this.cboxCodigoOrdenTrabajo.TabIndex = 5;
            // 
            // txtNoOrden
            // 
            this.txtNoOrden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoOrden.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.txtNoOrden.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNoOrden.ForeColor = System.Drawing.Color.White;
            this.txtNoOrden.Location = new System.Drawing.Point(0, 136);
            this.txtNoOrden.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.txtNoOrden.MaxLength = 15;
            this.txtNoOrden.Name = "txtNoOrden";
            this.txtNoOrden.Size = new System.Drawing.Size(561, 31);
            this.txtNoOrden.TabIndex = 14;
            // 
            // dtpFechaEntrega
            // 
            this.dtpFechaEntrega.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaEntrega.Location = new System.Drawing.Point(577, 25);
            this.dtpFechaEntrega.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.dtpFechaEntrega.Name = "dtpFechaEntrega";
            this.dtpFechaEntrega.Size = new System.Drawing.Size(561, 31);
            this.dtpFechaEntrega.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.ForeColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(577, 79);
            this.textBox3.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.textBox3.MaxLength = 15;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(561, 31);
            this.textBox3.TabIndex = 16;
            // 
            // lblDatos
            // 
            this.lblDatos.BackColor = System.Drawing.Color.Transparent;
            this.lblDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDatos.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDatos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(208)))), ((int)(((byte)(240)))));
            this.lblDatos.Location = new System.Drawing.Point(15, 10);
            this.lblDatos.Name = "lblDatos";
            this.lblDatos.Size = new System.Drawing.Size(1732, 26);
            this.lblDatos.TabIndex = 1;
            this.lblDatos.Text = "Datos de la Factura";
            this.lblDatos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSeparador
            // 
            this.pnlSeparador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.pnlSeparador.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSeparador.Location = new System.Drawing.Point(1762, 0);
            this.pnlSeparador.Name = "pnlSeparador";
            this.pnlSeparador.Size = new System.Drawing.Size(10, 215);
            this.pnlSeparador.TabIndex = 1;
            // 
            // pnlAcciones
            // 
            this.pnlAcciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlAcciones.Controls.Add(this.tlpAcciones);
            this.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlAcciones.Location = new System.Drawing.Point(1772, 0);
            this.pnlAcciones.Name = "pnlAcciones";
            this.pnlAcciones.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlAcciones.Size = new System.Drawing.Size(160, 215);
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
            this.tlpAcciones.Size = new System.Drawing.Size(136, 199);
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
            this.btnNuevo.Size = new System.Drawing.Size(136, 27);
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
            this.btnGuardar.Location = new System.Drawing.Point(0, 36);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(136, 27);
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
            this.btnEditar.Location = new System.Drawing.Point(0, 69);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(136, 27);
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
            this.btnEliminar.Location = new System.Drawing.Point(0, 102);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(136, 27);
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
            this.btnCancelar.Location = new System.Drawing.Point(0, 135);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(136, 27);
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
            this.btnLimpiar.Location = new System.Drawing.Point(0, 168);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(136, 28);
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
            this.pnlConsultar.Size = new System.Drawing.Size(1932, 215);
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
            this.tlpFiltros.Size = new System.Drawing.Size(1902, 173);
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
            this.lblFiltroEstado.Size = new System.Drawing.Size(951, 22);
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
            "Emitida",
            "Pagada",
            "Anulada"});
            this.cmbFiltroEstado.Location = new System.Drawing.Point(0, 25);
            this.cmbFiltroEstado.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.cmbFiltroEstado.Name = "cmbFiltroEstado";
            this.cmbFiltroEstado.Size = new System.Drawing.Size(935, 33);
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
            this.btnQuitarFiltros.Location = new System.Drawing.Point(3, 98);
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
            this.lblFiltros.Size = new System.Drawing.Size(1902, 26);
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
            this.pnlCabecera.Size = new System.Drawing.Size(1932, 72);
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
            this.lblTitulo.Size = new System.Drawing.Size(244, 47);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Facturaciones";
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
            // panelEstado
            // 
            this.panelEstado.Controls.Add(this.rdbInactivo);
            this.panelEstado.Controls.Add(this.rdbActivo);
            this.panelEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEstado.Location = new System.Drawing.Point(1157, 79);
            this.panelEstado.Name = "panelEstado";
            this.panelEstado.Size = new System.Drawing.Size(572, 26);
            this.panelEstado.TabIndex = 18;
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
            // txtCódigoFactura
            // 
            this.txtCódigoFactura.DataPropertyName = "CodigoFactura";
            this.txtCódigoFactura.HeaderText = "Código Factura";
            this.txtCódigoFactura.MinimumWidth = 10;
            this.txtCódigoFactura.Name = "txtCódigoFactura";
            this.txtCódigoFactura.Width = 90;
            // 
            // cboxCodigoOrden
            // 
            this.cboxCodigoOrden.DataPropertyName = "CodigoOrdenTrabajo";
            this.cboxCodigoOrden.HeaderText = "Codigo Orden Trabajo";
            this.cboxCodigoOrden.MinimumWidth = 10;
            this.cboxCodigoOrden.Name = "cboxCodigoOrden";
            this.cboxCodigoOrden.Width = 90;
            // 
            // txtNoFactura
            // 
            this.txtNoFactura.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.txtNoFactura.DataPropertyName = "NoFactura";
            this.txtNoFactura.HeaderText = "No. factura";
            this.txtNoFactura.MinimumWidth = 10;
            this.txtNoFactura.Name = "txtNoFactura";
            this.txtNoFactura.Width = 200;
            // 
            // colFecha
            // 
            this.colFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colFecha.DataPropertyName = "FechaDeEntrega";
            this.colFecha.HeaderText = "Fecha de Entrega";
            this.colFecha.MinimumWidth = 10;
            this.colFecha.Name = "colFecha";
            this.colFecha.Width = 200;
            // 
            // txtsubtotal
            // 
            this.txtsubtotal.DataPropertyName = "Subtotal";
            this.txtsubtotal.HeaderText = "Subtotal";
            this.txtsubtotal.MinimumWidth = 10;
            this.txtsubtotal.Name = "txtsubtotal";
            this.txtsubtotal.Width = 200;
            // 
            // txtimpuesto
            // 
            this.txtimpuesto.DataPropertyName = "Impuesto";
            this.txtimpuesto.HeaderText = "Impuesto";
            this.txtimpuesto.MinimumWidth = 10;
            this.txtimpuesto.Name = "txtimpuesto";
            this.txtimpuesto.Width = 150;
            // 
            // colTotal
            // 
            this.colTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colTotal.DataPropertyName = "Total";
            this.colTotal.HeaderText = "Total";
            this.colTotal.MinimumWidth = 10;
            this.colTotal.Name = "colTotal";
            this.colTotal.Width = 200;
            // 
            // colEstado
            // 
            this.colEstado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colEstado.DataPropertyName = "Estado";
            this.colEstado.HeaderText = "Estado";
            this.colEstado.MinimumWidth = 10;
            this.colEstado.Name = "colEstado";
            this.colEstado.Width = 90;
            // 
            // FrmFacturaciones
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(1972, 1372);
            this.Controls.Add(this.pnlLista);
            this.Controls.Add(this.pnlSeccion);
            this.Controls.Add(this.pnlCabecera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmFacturaciones";
            this.Padding = new System.Windows.Forms.Padding(20, 8, 20, 16);
            this.Text = "Facturaciones";
            this.pnlLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturaciones)).EndInit();
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
            this.panelEstado.ResumeLayout(false);
            this.panelEstado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Presentacion.RoundedPanel pnlLista;
        private System.Windows.Forms.DataGridView dgvFacturaciones;
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
        private System.Windows.Forms.TextBox txtCodigoFactura;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cboxCodigoOrdenTrabajo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFechaEntrega;
        private System.Windows.Forms.Label lblSucursal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtImpuestos;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNoOrden;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Panel panelEstado;
        private System.Windows.Forms.RadioButton rdbInactivo;
        private System.Windows.Forms.RadioButton rdbActivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCódigoFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn cboxCodigoOrden;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtNoFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtsubtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtimpuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
    }
}
