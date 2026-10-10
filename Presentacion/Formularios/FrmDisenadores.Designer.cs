namespace Presentacion
{
    partial class FrmDisenadores
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
            this.dgvDisenadores = new System.Windows.Forms.DataGridView();
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
            this.txtCodigoDiseñador = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.Edad = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.txtEspecialidad = new System.Windows.Forms.TextBox();
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
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.rdbActivo = new System.Windows.Forms.RadioButton();
            this.rdbInactivo = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.colCodigoFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.años = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCorreo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisenadores)).BeginInit();
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
            this.pnlLista.Controls.Add(this.dgvDisenadores);
            this.pnlLista.Controls.Add(this.pnlPie);
            this.pnlLista.Controls.Add(this.pnlBusqueda);
            this.pnlLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLista.Location = new System.Drawing.Point(20, 305);
            this.pnlLista.Name = "pnlLista";
            this.pnlLista.Padding = new System.Windows.Forms.Padding(12, 12, 12, 6);
            this.pnlLista.Size = new System.Drawing.Size(1970, 1025);
            this.pnlLista.TabIndex = 0;
            // 
            // dgvDisenadores
            // 
            this.dgvDisenadores.ColumnHeadersHeight = 46;
            this.dgvDisenadores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigoFactura,
            this.colNombre,
            this.años,
            this.colEspecialidad,
            this.colTelefono,
            this.colCorreo,
            this.colEstado});
            this.dgvDisenadores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDisenadores.Location = new System.Drawing.Point(12, 58);
            this.dgvDisenadores.Name = "dgvDisenadores";
            this.dgvDisenadores.RowHeadersWidth = 82;
            this.dgvDisenadores.Size = new System.Drawing.Size(1946, 935);
            this.dgvDisenadores.TabIndex = 0;
            this.dgvDisenadores.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDisenadores_CellFormatting);
            // 
            // pnlPie
            // 
            this.pnlPie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlPie.Controls.Add(this.lblTotalRegistros);
            this.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPie.Location = new System.Drawing.Point(12, 993);
            this.pnlPie.Name = "pnlPie";
            this.pnlPie.Size = new System.Drawing.Size(1946, 26);
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
            this.pnlBusqueda.Size = new System.Drawing.Size(1946, 46);
            this.pnlBusqueda.TabIndex = 2;
            // 
            // csBuscar
            // 
            this.csBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.csBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.csBuscar.Location = new System.Drawing.Point(0, 0);
            this.csBuscar.Name = "csBuscar";
            this.csBuscar.Placeholder = "Buscar por nombre, código o correo...";
            this.csBuscar.Radio = 8;
            this.csBuscar.Size = new System.Drawing.Size(1780, 34);
            this.csBuscar.TabIndex = 0;
            // 
            // pnlSeparadorBusqueda
            // 
            this.pnlSeparadorBusqueda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlSeparadorBusqueda.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSeparadorBusqueda.Location = new System.Drawing.Point(1780, 0);
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
            this.btnBuscar.Location = new System.Drawing.Point(1790, 0);
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
            this.pnlSeccion.Size = new System.Drawing.Size(1970, 225);
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
            this.pnlGestionar.Size = new System.Drawing.Size(1970, 215);
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
            this.pnlFormulario.Size = new System.Drawing.Size(1800, 215);
            this.pnlFormulario.TabIndex = 0;
            // 
            // tlpCampos
            // 
            this.tlpCampos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.tlpCampos.ColumnCount = 3;
            this.tlpCampos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpCampos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpCampos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpCampos.Controls.Add(this.label1, 2, 0);
            this.tlpCampos.Controls.Add(this.lblCodigo, 0, 0);
            this.tlpCampos.Controls.Add(this.txtCodigoDiseñador, 0, 1);
            this.tlpCampos.Controls.Add(this.lblEstado, 1, 0);
            this.tlpCampos.Controls.Add(this.lblNombre, 0, 2);
            this.tlpCampos.Controls.Add(this.txtNombre, 0, 3);
            this.tlpCampos.Controls.Add(this.lblTelefono, 1, 2);
            this.tlpCampos.Controls.Add(this.txtTelefono, 1, 3);
            this.tlpCampos.Controls.Add(this.Edad, 0, 4);
            this.tlpCampos.Controls.Add(this.lblEspecialidad, 1, 4);
            this.tlpCampos.Controls.Add(this.txtEdad, 0, 5);
            this.tlpCampos.Controls.Add(this.txtEspecialidad, 1, 1);
            this.tlpCampos.Controls.Add(this.txtCorreo, 1, 5);
            this.tlpCampos.Controls.Add(this.panel1, 2, 1);
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
            this.tlpCampos.Size = new System.Drawing.Size(1770, 173);
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
            this.lblCodigo.Size = new System.Drawing.Size(589, 22);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código Diseñador:";
            this.lblCodigo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtCodigoDiseñador
            // 
            this.txtCodigoDiseñador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodigoDiseñador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.txtCodigoDiseñador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoDiseñador.ForeColor = System.Drawing.Color.White;
            this.txtCodigoDiseñador.Location = new System.Drawing.Point(0, 25);
            this.txtCodigoDiseñador.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.txtCodigoDiseñador.Name = "txtCodigoDiseñador";
            this.txtCodigoDiseñador.ReadOnly = true;
            this.txtCodigoDiseñador.Size = new System.Drawing.Size(573, 31);
            this.txtCodigoDiseñador.TabIndex = 1;
            // 
            // lblEstado
            // 
            this.lblEstado.BackColor = System.Drawing.Color.Transparent;
            this.lblEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblEstado.Location = new System.Drawing.Point(589, 0);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(589, 22);
            this.lblEstado.TabIndex = 2;
            this.lblEstado.Text = "Especialidad:";
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblNombre
            // 
            this.lblNombre.BackColor = System.Drawing.Color.Transparent;
            this.lblNombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblNombre.Location = new System.Drawing.Point(0, 54);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(589, 22);
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.ForeColor = System.Drawing.Color.White;
            this.txtNombre.Location = new System.Drawing.Point(0, 79);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.txtNombre.MaxLength = 80;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(573, 31);
            this.txtNombre.TabIndex = 5;
            // 
            // lblTelefono
            // 
            this.lblTelefono.BackColor = System.Drawing.Color.Transparent;
            this.lblTelefono.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblTelefono.Location = new System.Drawing.Point(589, 54);
            this.lblTelefono.Margin = new System.Windows.Forms.Padding(0);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(589, 22);
            this.lblTelefono.TabIndex = 6;
            this.lblTelefono.Text = "Teléfono:";
            this.lblTelefono.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTelefono.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefono.ForeColor = System.Drawing.Color.White;
            this.txtTelefono.Location = new System.Drawing.Point(589, 79);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.txtTelefono.MaxLength = 20;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(573, 31);
            this.txtTelefono.TabIndex = 7;
            // 
            // Edad
            // 
            this.Edad.BackColor = System.Drawing.Color.Transparent;
            this.Edad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Edad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.Edad.Location = new System.Drawing.Point(0, 108);
            this.Edad.Margin = new System.Windows.Forms.Padding(0);
            this.Edad.Name = "Edad";
            this.Edad.Size = new System.Drawing.Size(589, 22);
            this.Edad.TabIndex = 8;
            this.Edad.Text = "Edad:";
            this.Edad.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCorreo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.txtCorreo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCorreo.ForeColor = System.Drawing.Color.White;
            this.txtCorreo.Location = new System.Drawing.Point(589, 136);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.txtCorreo.MaxLength = 100;
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(573, 31);
            this.txtCorreo.TabIndex = 9;
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.BackColor = System.Drawing.Color.Transparent;
            this.lblEspecialidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEspecialidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblEspecialidad.Location = new System.Drawing.Point(589, 108);
            this.lblEspecialidad.Margin = new System.Windows.Forms.Padding(0);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(589, 22);
            this.lblEspecialidad.TabIndex = 10;
            this.lblEspecialidad.Text = "Correo:";
            this.lblEspecialidad.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtEspecialidad
            // 
            this.txtEspecialidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEspecialidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.txtEspecialidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEspecialidad.ForeColor = System.Drawing.Color.White;
            this.txtEspecialidad.Location = new System.Drawing.Point(589, 25);
            this.txtEspecialidad.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.txtEspecialidad.MaxLength = 60;
            this.txtEspecialidad.Name = "txtEspecialidad";
            this.txtEspecialidad.Size = new System.Drawing.Size(573, 31);
            this.txtEspecialidad.TabIndex = 11;
            // 
            // lblDatos
            // 
            this.lblDatos.BackColor = System.Drawing.Color.Transparent;
            this.lblDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDatos.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDatos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(208)))), ((int)(((byte)(240)))));
            this.lblDatos.Location = new System.Drawing.Point(15, 10);
            this.lblDatos.Name = "lblDatos";
            this.lblDatos.Size = new System.Drawing.Size(1770, 26);
            this.lblDatos.TabIndex = 1;
            this.lblDatos.Text = "Datos del Diseñador";
            this.lblDatos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSeparador
            // 
            this.pnlSeparador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.pnlSeparador.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSeparador.Location = new System.Drawing.Point(1800, 0);
            this.pnlSeparador.Name = "pnlSeparador";
            this.pnlSeparador.Size = new System.Drawing.Size(10, 215);
            this.pnlSeparador.TabIndex = 1;
            // 
            // pnlAcciones
            // 
            this.pnlAcciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlAcciones.Controls.Add(this.tlpAcciones);
            this.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlAcciones.Location = new System.Drawing.Point(1810, 0);
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
            this.pnlConsultar.Size = new System.Drawing.Size(1970, 215);
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
            this.tlpFiltros.Size = new System.Drawing.Size(1940, 173);
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
            this.lblFiltroEstado.Size = new System.Drawing.Size(970, 22);
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
            "Activo",
            "Inactivo"});
            this.cmbFiltroEstado.Location = new System.Drawing.Point(0, 25);
            this.cmbFiltroEstado.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.cmbFiltroEstado.Name = "cmbFiltroEstado";
            this.cmbFiltroEstado.Size = new System.Drawing.Size(954, 33);
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
            this.lblFiltros.Size = new System.Drawing.Size(1940, 26);
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
            this.pnlCabecera.Size = new System.Drawing.Size(1970, 72);
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
            this.lblTitulo.Size = new System.Drawing.Size(221, 47);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Diseñadores";
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
            this.label1.Location = new System.Drawing.Point(1178, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(592, 22);
            this.label1.TabIndex = 12;
            this.label1.Text = "Estado:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtEdad
            // 
            this.txtEdad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEdad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(92)))));
            this.txtEdad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEdad.ForeColor = System.Drawing.Color.White;
            this.txtEdad.Location = new System.Drawing.Point(0, 136);
            this.txtEdad.Margin = new System.Windows.Forms.Padding(0, 3, 16, 3);
            this.txtEdad.MaxLength = 20;
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(573, 31);
            this.txtEdad.TabIndex = 13;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.rdbInactivo);
            this.panel1.Controls.Add(this.rdbActivo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1181, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(586, 26);
            this.panel1.TabIndex = 16;
            // 
            // colCodigoFactura
            // 
            this.colCodigoFactura.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colCodigoFactura.DataPropertyName = "txtCodigoDiseñador";
            this.colCodigoFactura.HeaderText = "Código Diseñador";
            this.colCodigoFactura.MinimumWidth = 10;
            this.colCodigoFactura.Name = "colCodigoFactura";
            this.colCodigoFactura.Width = 90;
            // 
            // colNombre
            // 
            this.colNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNombre.DataPropertyName = "txtNombre";
            this.colNombre.FillWeight = 30F;
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.MinimumWidth = 10;
            this.colNombre.Name = "colNombre";
            // 
            // años
            // 
            this.años.HeaderText = "Edad";
            this.años.MinimumWidth = 10;
            this.años.Name = "años";
            this.años.Width = 200;
            // 
            // colEspecialidad
            // 
            this.colEspecialidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEspecialidad.DataPropertyName = "txtEspecialidad";
            this.colEspecialidad.FillWeight = 25F;
            this.colEspecialidad.HeaderText = "Especialidad";
            this.colEspecialidad.MinimumWidth = 10;
            this.colEspecialidad.Name = "colEspecialidad";
            // 
            // colTelefono
            // 
            this.colTelefono.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colTelefono.DataPropertyName = "txtTelefono";
            this.colTelefono.HeaderText = "Teléfono";
            this.colTelefono.MinimumWidth = 10;
            this.colTelefono.Name = "colTelefono";
            // 
            // colCorreo
            // 
            this.colCorreo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCorreo.DataPropertyName = "txtCorreo";
            this.colCorreo.FillWeight = 30F;
            this.colCorreo.HeaderText = "Correo";
            this.colCorreo.MinimumWidth = 10;
            this.colCorreo.Name = "colCorreo";
            // 
            // colEstado
            // 
            this.colEstado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colEstado.DataPropertyName = "rdbActivo";
            this.colEstado.HeaderText = "Estado";
            this.colEstado.MinimumWidth = 10;
            this.colEstado.Name = "colEstado";
            this.colEstado.Width = 90;
            // 
            // FrmDisenadores
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(2010, 1346);
            this.Controls.Add(this.pnlLista);
            this.Controls.Add(this.pnlSeccion);
            this.Controls.Add(this.pnlCabecera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDisenadores";
            this.Padding = new System.Windows.Forms.Padding(20, 8, 20, 16);
            this.Text = "Diseñadores";
            this.pnlLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisenadores)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvDisenadores;
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
        private System.Windows.Forms.TextBox txtCodigoDiseñador;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label Edad;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.TextBox txtEspecialidad;
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
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdbInactivo;
        private System.Windows.Forms.RadioButton rdbActivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn años;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCorreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
    }
}
