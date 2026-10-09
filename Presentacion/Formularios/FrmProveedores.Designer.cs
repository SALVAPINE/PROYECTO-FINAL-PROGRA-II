namespace Presentacion
{
    partial class FrmProveedores
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
            this.dgvProveedores = new System.Windows.Forms.DataGridView();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCorreo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.flpEstado = new System.Windows.Forms.FlowLayoutPanel();
            this.rbActivo = new System.Windows.Forms.RadioButton();
            this.rbInactivo = new System.Windows.Forms.RadioButton();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
            this.SuspendLayout();
            this.pnlLista.SuspendLayout();
            this.pnlPie.SuspendLayout();
            this.pnlBusqueda.SuspendLayout();
            this.pnlSeccion.SuspendLayout();
            this.pnlGestionar.SuspendLayout();
            this.pnlFormulario.SuspendLayout();
            this.tlpCampos.SuspendLayout();
            this.flpEstado.SuspendLayout();
            this.pnlAcciones.SuspendLayout();
            this.tlpAcciones.SuspendLayout();
            this.pnlConsultar.SuspendLayout();
            this.tlpFiltros.SuspendLayout();
            this.pnlCabecera.SuspendLayout();
            // 
            // FrmProveedores
            // 
            this.Controls.Add(this.pnlLista);
            this.Controls.Add(this.pnlSeccion);
            this.Controls.Add(this.pnlCabecera);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.ClientSize = new System.Drawing.Size(920, 600);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmProveedores";
            this.Padding = new System.Windows.Forms.Padding(20, 8, 20, 16);
            this.Text = "Proveedores";
            // 
            // pnlLista
            // 
            this.pnlLista.Controls.Add(this.dgvProveedores);
            this.pnlLista.Controls.Add(this.pnlPie);
            this.pnlLista.Controls.Add(this.pnlBusqueda);
            this.pnlLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLista.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.pnlLista.Name = "pnlLista";
            this.pnlLista.Padding = new System.Windows.Forms.Padding(12, 12, 12, 6);
            this.pnlLista.Size = new System.Drawing.Size(200, 100);
            // 
            // dgvProveedores
            // 
            this.dgvProveedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colNombre,
            this.colTelefono,
            this.colCorreo,
            this.colTipo,
            this.colDireccion,
            this.colEstado});
            this.dgvProveedores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProveedores.Name = "dgvProveedores";
            this.dgvProveedores.Size = new System.Drawing.Size(850, 150);
            this.dgvProveedores.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvProveedores_CellFormatting);
            // 
            // colCodigo
            // 
            this.colCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colCodigo.DataPropertyName = "CodigoProveedor";
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.Width = 70;
            // 
            // colNombre
            // 
            this.colNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNombre.DataPropertyName = "NombreProveedor";
            this.colNombre.FillWeight = 22F;
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.Name = "colNombre";
            // 
            // colTelefono
            // 
            this.colTelefono.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colTelefono.DataPropertyName = "Telefono";
            this.colTelefono.HeaderText = "Teléfono";
            this.colTelefono.Name = "colTelefono";
            this.colTelefono.Width = 90;
            // 
            // colCorreo
            // 
            this.colCorreo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCorreo.DataPropertyName = "Correo";
            this.colCorreo.FillWeight = 24F;
            this.colCorreo.HeaderText = "Correo";
            this.colCorreo.Name = "colCorreo";
            // 
            // colTipo
            // 
            this.colTipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTipo.DataPropertyName = "TipoProveedor";
            this.colTipo.FillWeight = 16F;
            this.colTipo.HeaderText = "Tipo";
            this.colTipo.Name = "colTipo";
            // 
            // colDireccion
            // 
            this.colDireccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDireccion.DataPropertyName = "Direccion";
            this.colDireccion.FillWeight = 28F;
            this.colDireccion.HeaderText = "Dirección";
            this.colDireccion.Name = "colDireccion";
            // 
            // colEstado
            // 
            this.colEstado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colEstado.DataPropertyName = "Estado";
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.Width = 80;
            // 
            // pnlPie
            // 
            this.pnlPie.Controls.Add(this.lblTotalRegistros);
            this.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPie.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.pnlPie.Name = "pnlPie";
            this.pnlPie.Size = new System.Drawing.Size(200, 26);
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.AutoSize = true;
            this.lblTotalRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalRegistros.ForeColor = System.Drawing.Color.FromArgb(160, 170, 220);
            this.lblTotalRegistros.Location = new System.Drawing.Point(0, 6);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Text = "Total de registros: 0";
            // 
            // pnlBusqueda
            // 
            this.pnlBusqueda.Controls.Add(this.csBuscar);
            this.pnlBusqueda.Controls.Add(this.pnlSeparadorBusqueda);
            this.pnlBusqueda.Controls.Add(this.btnBuscar);
            this.pnlBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBusqueda.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.pnlBusqueda.Name = "pnlBusqueda";
            this.pnlBusqueda.Padding = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.pnlBusqueda.Size = new System.Drawing.Size(200, 46);
            // 
            // csBuscar
            // 
            this.csBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.csBuscar.Name = "csBuscar";
            this.csBuscar.Placeholder = "Buscar por nombre, código o correo...";
            this.csBuscar.Size = new System.Drawing.Size(600, 34);
            // 
            // pnlSeparadorBusqueda
            // 
            this.pnlSeparadorBusqueda.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSeparadorBusqueda.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.pnlSeparadorBusqueda.Name = "pnlSeparadorBusqueda";
            this.pnlSeparadorBusqueda.Size = new System.Drawing.Size(10, 34);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(37, 50, 128);
            this.btnBuscar.ColorBorde = System.Drawing.Color.FromArgb(70, 90, 190);
            this.btnBuscar.Glyph = "\uE721";
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(156, 34);
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // pnlSeccion
            // 
            this.pnlSeccion.Controls.Add(this.pnlGestionar);
            this.pnlSeccion.Controls.Add(this.pnlConsultar);
            this.pnlSeccion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeccion.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.pnlSeccion.Name = "pnlSeccion";
            this.pnlSeccion.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.pnlSeccion.Size = new System.Drawing.Size(880, 225);
            // 
            // pnlGestionar
            // 
            this.pnlGestionar.Controls.Add(this.pnlFormulario);
            this.pnlGestionar.Controls.Add(this.pnlSeparador);
            this.pnlGestionar.Controls.Add(this.pnlAcciones);
            this.pnlGestionar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGestionar.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.pnlGestionar.Name = "pnlGestionar";
            this.pnlGestionar.Size = new System.Drawing.Size(880, 215);
            // 
            // pnlFormulario
            // 
            this.pnlFormulario.Controls.Add(this.tlpCampos);
            this.pnlFormulario.Controls.Add(this.lblDatos);
            this.pnlFormulario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFormulario.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.pnlFormulario.Name = "pnlFormulario";
            this.pnlFormulario.Padding = new System.Windows.Forms.Padding(15, 10, 15, 6);
            this.pnlFormulario.Size = new System.Drawing.Size(720, 215);
            // 
            // tlpCampos  (3 columnas x 3 filas de campo)
            // 
            this.tlpCampos.Controls.Add(this.lblCodigo, 0, 0);
            this.tlpCampos.Controls.Add(this.txtCodigo, 0, 1);
            this.tlpCampos.Controls.Add(this.lblNombre, 1, 0);
            this.tlpCampos.Controls.Add(this.txtNombre, 1, 1);
            this.tlpCampos.Controls.Add(this.lblTelefono, 2, 0);
            this.tlpCampos.Controls.Add(this.txtTelefono, 2, 1);
            this.tlpCampos.Controls.Add(this.lblCorreo, 0, 2);
            this.tlpCampos.Controls.Add(this.txtCorreo, 0, 3);
            this.tlpCampos.Controls.Add(this.lblTipo, 1, 2);
            this.tlpCampos.Controls.Add(this.txtTipo, 1, 3);
            this.tlpCampos.Controls.Add(this.lblDireccion, 2, 2);
            this.tlpCampos.Controls.Add(this.txtDireccion, 2, 3);
            this.tlpCampos.Controls.Add(this.lblEstado, 0, 4);
            this.tlpCampos.Controls.Add(this.flpEstado, 0, 5);
            this.tlpCampos.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.tlpCampos.ColumnCount = 3;
            this.tlpCampos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpCampos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpCampos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpCampos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCampos.Name = "tlpCampos";
            this.tlpCampos.RowCount = 6;
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpCampos.Size = new System.Drawing.Size(200, 100);
            // 
            // lblCodigo
            // 
            this.lblCodigo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCodigo.AutoSize = false;
            this.lblCodigo.BackColor = System.Drawing.Color.Transparent;
            this.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(160, 170, 220);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(100, 20);
            this.lblCodigo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblCodigo.Text = "Código:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodigo.BackColor = System.Drawing.Color.FromArgb(30, 37, 92);
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.ForeColor = System.Drawing.Color.White;
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(200, 23);
            // 
            // lblNombre
            // 
            this.lblNombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNombre.AutoSize = false;
            this.lblNombre.BackColor = System.Drawing.Color.Transparent;
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(160, 170, 220);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(100, 20);
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblNombre.Text = "Nombre / Razón social:";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(30, 37, 92);
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.ForeColor = System.Drawing.Color.White;
            this.txtNombre.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.txtNombre.MaxLength = 45;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 23);
            // 
            // lblTelefono
            // 
            this.lblTelefono.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTelefono.AutoSize = false;
            this.lblTelefono.BackColor = System.Drawing.Color.Transparent;
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(160, 170, 220);
            this.lblTelefono.Margin = new System.Windows.Forms.Padding(0);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(100, 20);
            this.lblTelefono.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTelefono.BackColor = System.Drawing.Color.FromArgb(30, 37, 92);
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefono.ForeColor = System.Drawing.Color.White;
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.txtTelefono.MaxLength = 8;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(200, 23);
            // 
            // lblCorreo
            // 
            this.lblCorreo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCorreo.AutoSize = false;
            this.lblCorreo.BackColor = System.Drawing.Color.Transparent;
            this.lblCorreo.ForeColor = System.Drawing.Color.FromArgb(160, 170, 220);
            this.lblCorreo.Margin = new System.Windows.Forms.Padding(0);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(100, 20);
            this.lblCorreo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblCorreo.Text = "Correo:";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCorreo.BackColor = System.Drawing.Color.FromArgb(30, 37, 92);
            this.txtCorreo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCorreo.ForeColor = System.Drawing.Color.White;
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.txtCorreo.MaxLength = 150;
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(200, 23);
            // 
            // lblTipo
            // 
            this.lblTipo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTipo.AutoSize = false;
            this.lblTipo.BackColor = System.Drawing.Color.Transparent;
            this.lblTipo.ForeColor = System.Drawing.Color.FromArgb(160, 170, 220);
            this.lblTipo.Margin = new System.Windows.Forms.Padding(0);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(100, 20);
            this.lblTipo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblTipo.Text = "Tipo de proveedor:";
            // 
            // txtTipo
            // 
            this.txtTipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTipo.BackColor = System.Drawing.Color.FromArgb(30, 37, 92);
            this.txtTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTipo.ForeColor = System.Drawing.Color.White;
            this.txtTipo.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.txtTipo.MaxLength = 45;
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(200, 23);
            // 
            // lblDireccion
            // 
            this.lblDireccion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDireccion.AutoSize = false;
            this.lblDireccion.BackColor = System.Drawing.Color.Transparent;
            this.lblDireccion.ForeColor = System.Drawing.Color.FromArgb(160, 170, 220);
            this.lblDireccion.Margin = new System.Windows.Forms.Padding(0);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(100, 20);
            this.lblDireccion.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblDireccion.Text = "Dirección:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDireccion.BackColor = System.Drawing.Color.FromArgb(30, 37, 92);
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDireccion.ForeColor = System.Drawing.Color.White;
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.txtDireccion.MaxLength = 150;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(200, 23);
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
            // flpEstado
            // 
            this.flpEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flpEstado.BackColor = System.Drawing.Color.Transparent;
            this.flpEstado.Controls.Add(this.rbActivo);
            this.flpEstado.Controls.Add(this.rbInactivo);
            this.flpEstado.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.flpEstado.Name = "flpEstado";
            this.flpEstado.Size = new System.Drawing.Size(200, 26);
            this.flpEstado.WrapContents = false;
            // 
            // rbActivo
            // 
            this.rbActivo.AutoSize = true;
            this.rbActivo.BackColor = System.Drawing.Color.Transparent;
            this.rbActivo.Checked = true;
            this.rbActivo.ForeColor = System.Drawing.Color.White;
            this.rbActivo.Margin = new System.Windows.Forms.Padding(0, 4, 20, 0);
            this.rbActivo.Name = "rbActivo";
            this.rbActivo.Size = new System.Drawing.Size(70, 19);
            this.rbActivo.TabStop = true;
            this.rbActivo.Text = "Activo";
            this.rbActivo.UseVisualStyleBackColor = false;
            // 
            // rbInactivo
            // 
            this.rbInactivo.AutoSize = true;
            this.rbInactivo.BackColor = System.Drawing.Color.Transparent;
            this.rbInactivo.ForeColor = System.Drawing.Color.White;
            this.rbInactivo.Margin = new System.Windows.Forms.Padding(0, 4, 20, 0);
            this.rbInactivo.Name = "rbInactivo";
            this.rbInactivo.Size = new System.Drawing.Size(70, 19);
            this.rbInactivo.TabStop = false;
            this.rbInactivo.Text = "Inactivo";
            this.rbInactivo.UseVisualStyleBackColor = false;
            // 
            // lblDatos
            // 
            this.lblDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDatos.AutoSize = false;
            this.lblDatos.BackColor = System.Drawing.Color.Transparent;
            this.lblDatos.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDatos.ForeColor = System.Drawing.Color.FromArgb(200, 208, 240);
            this.lblDatos.Name = "lblDatos";
            this.lblDatos.Size = new System.Drawing.Size(100, 26);
            this.lblDatos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDatos.Text = "Datos del Proveedor";
            // 
            // pnlSeparador
            // 
            this.pnlSeparador.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSeparador.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.pnlSeparador.Name = "pnlSeparador";
            this.pnlSeparador.Size = new System.Drawing.Size(10, 215);
            // 
            // pnlAcciones
            // 
            this.pnlAcciones.Controls.Add(this.tlpAcciones);
            this.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlAcciones.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.pnlAcciones.Name = "pnlAcciones";
            this.pnlAcciones.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlAcciones.Size = new System.Drawing.Size(160, 215);
            // 
            // tlpAcciones
            // 
            this.tlpAcciones.Controls.Add(this.btnNuevo, 0, 0);
            this.tlpAcciones.Controls.Add(this.btnGuardar, 0, 1);
            this.tlpAcciones.Controls.Add(this.btnEditar, 0, 2);
            this.tlpAcciones.Controls.Add(this.btnEliminar, 0, 3);
            this.tlpAcciones.Controls.Add(this.btnCancelar, 0, 4);
            this.tlpAcciones.Controls.Add(this.btnLimpiar, 0, 5);
            this.tlpAcciones.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.tlpAcciones.ColumnCount = 1;
            this.tlpAcciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAcciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAcciones.Name = "tlpAcciones";
            this.tlpAcciones.RowCount = 6;
            this.tlpAcciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpAcciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpAcciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpAcciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpAcciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpAcciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpAcciones.Size = new System.Drawing.Size(200, 100);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(14, 130, 170);
            this.btnNuevo.ColorBorde = System.Drawing.Color.FromArgb(40, 180, 220);
            this.btnNuevo.ColorHover = System.Drawing.Color.FromArgb(20, 160, 205);
            this.btnNuevo.Glyph = "\uE710";
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(126, 28);
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGuardar.ColorBorde = System.Drawing.Color.FromArgb(70, 90, 190);
            this.btnGuardar.Glyph = "\uE74E";
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(126, 28);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEditar.ColorBorde = System.Drawing.Color.FromArgb(70, 90, 190);
            this.btnEditar.Glyph = "\uE70F";
            this.btnEditar.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(126, 28);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEliminar.ColorBorde = System.Drawing.Color.FromArgb(70, 90, 190);
            this.btnEliminar.Glyph = "\uE74D";
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(126, 28);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancelar.ColorBorde = System.Drawing.Color.FromArgb(70, 90, 190);
            this.btnCancelar.Glyph = "\uE711";
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(126, 28);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLimpiar.ColorBorde = System.Drawing.Color.FromArgb(70, 90, 190);
            this.btnLimpiar.Glyph = "\uE75C";
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(126, 28);
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // pnlConsultar
            // 
            this.pnlConsultar.Controls.Add(this.tlpFiltros);
            this.pnlConsultar.Controls.Add(this.lblFiltros);
            this.pnlConsultar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConsultar.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.pnlConsultar.Name = "pnlConsultar";
            this.pnlConsultar.Padding = new System.Windows.Forms.Padding(15, 10, 15, 6);
            this.pnlConsultar.Size = new System.Drawing.Size(880, 215);
            this.pnlConsultar.Visible = false;
            // 
            // tlpFiltros
            // 
            this.tlpFiltros.Controls.Add(this.lblFiltroEstado, 0, 0);
            this.tlpFiltros.Controls.Add(this.cmbFiltroEstado, 0, 1);
            this.tlpFiltros.Controls.Add(this.btnQuitarFiltros, 0, 2);
            this.tlpFiltros.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.tlpFiltros.ColumnCount = 2;
            this.tlpFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFiltros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFiltros.Name = "tlpFiltros";
            this.tlpFiltros.RowCount = 3;
            this.tlpFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlpFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpFiltros.Size = new System.Drawing.Size(200, 100);
            // 
            // lblFiltroEstado
            // 
            this.lblFiltroEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFiltroEstado.AutoSize = false;
            this.lblFiltroEstado.BackColor = System.Drawing.Color.Transparent;
            this.lblFiltroEstado.ForeColor = System.Drawing.Color.FromArgb(160, 170, 220);
            this.lblFiltroEstado.Margin = new System.Windows.Forms.Padding(0);
            this.lblFiltroEstado.Name = "lblFiltroEstado";
            this.lblFiltroEstado.Size = new System.Drawing.Size(100, 20);
            this.lblFiltroEstado.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblFiltroEstado.Text = "Estado:";
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
            this.cmbFiltroEstado.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.cmbFiltroEstado.Name = "cmbFiltroEstado";
            this.cmbFiltroEstado.Size = new System.Drawing.Size(200, 23);
            // 
            // btnQuitarFiltros
            // 
            this.btnQuitarFiltros.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnQuitarFiltros.ColorBorde = System.Drawing.Color.FromArgb(70, 90, 190);
            this.btnQuitarFiltros.Glyph = "\uE894";
            this.btnQuitarFiltros.Name = "btnQuitarFiltros";
            this.btnQuitarFiltros.Size = new System.Drawing.Size(150, 30);
            this.btnQuitarFiltros.Text = "Quitar filtros";
            this.btnQuitarFiltros.Click += new System.EventHandler(this.btnQuitarFiltros_Click);
            // 
            // lblFiltros
            // 
            this.lblFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFiltros.AutoSize = false;
            this.lblFiltros.BackColor = System.Drawing.Color.Transparent;
            this.lblFiltros.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFiltros.ForeColor = System.Drawing.Color.FromArgb(200, 208, 240);
            this.lblFiltros.Name = "lblFiltros";
            this.lblFiltros.Size = new System.Drawing.Size(100, 26);
            this.lblFiltros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFiltros.Text = "Filtros de consulta";
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.Controls.Add(this.lblTitulo);
            this.pnlCabecera.Controls.Add(this.btnTabGestionar);
            this.pnlCabecera.Controls.Add(this.btnTabConsultar);
            this.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCabecera.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(880, 72);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.lblTitulo.Location = new System.Drawing.Point(0, 4);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "Proveedores";
            // 
            // btnTabGestionar
            // 
            this.btnTabGestionar.BackColor = System.Drawing.Color.FromArgb(22, 28, 76);
            this.btnTabGestionar.ColorHover = System.Drawing.Color.FromArgb(34, 42, 110);
            this.btnTabGestionar.Location = new System.Drawing.Point(0, 38);
            this.btnTabGestionar.Name = "btnTabGestionar";
            this.btnTabGestionar.Radio = 6;
            this.btnTabGestionar.Size = new System.Drawing.Size(90, 30);
            this.btnTabGestionar.Text = "Gestionar";
            this.btnTabGestionar.Click += new System.EventHandler(this.btnTabGestionar_Click);
            // 
            // btnTabConsultar
            // 
            this.btnTabConsultar.BackColor = System.Drawing.Color.FromArgb(22, 28, 76);
            this.btnTabConsultar.ColorHover = System.Drawing.Color.FromArgb(34, 42, 110);
            this.btnTabConsultar.Location = new System.Drawing.Point(94, 38);
            this.btnTabConsultar.Name = "btnTabConsultar";
            this.btnTabConsultar.Radio = 6;
            this.btnTabConsultar.Size = new System.Drawing.Size(90, 30);
            this.btnTabConsultar.Text = "Consultar";
            this.btnTabConsultar.Click += new System.EventHandler(this.btnTabConsultar_Click);
            this.pnlCabecera.ResumeLayout(false);
            this.tlpFiltros.ResumeLayout(false);
            this.pnlConsultar.ResumeLayout(false);
            this.tlpAcciones.ResumeLayout(false);
            this.pnlAcciones.ResumeLayout(false);
            this.flpEstado.ResumeLayout(false);
            this.flpEstado.PerformLayout();
            this.tlpCampos.ResumeLayout(false);
            this.tlpCampos.PerformLayout();
            this.pnlFormulario.ResumeLayout(false);
            this.pnlGestionar.ResumeLayout(false);
            this.pnlSeccion.ResumeLayout(false);
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlPie.ResumeLayout(false);
            this.pnlLista.ResumeLayout(false);
            this.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
            this.PerformLayout();
        }

        #endregion

        private Presentacion.RoundedPanel pnlLista;
        private System.Windows.Forms.DataGridView dgvProveedores;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCorreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
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
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.FlowLayoutPanel flpEstado;
        private System.Windows.Forms.RadioButton rbActivo;
        private System.Windows.Forms.RadioButton rbInactivo;
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
    }
}