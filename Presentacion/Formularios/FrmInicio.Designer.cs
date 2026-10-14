namespace Presentacion
{
    partial class FrmInicio
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
            this.pnlGraficos = new System.Windows.Forms.Panel();
            this.tlpGraficos = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCardCotizaciones = new Presentacion.RoundedPanel();
            this.graCotizaciones = new Presentacion.GraficoDona();
            this.pnlTituloCotizaciones = new System.Windows.Forms.Panel();
            this.lblIconoCotizaciones = new System.Windows.Forms.Label();
            this.lblTituloCotizaciones = new System.Windows.Forms.Label();
            this.pnlCardMonto = new Presentacion.RoundedPanel();
            this.graMonto = new Presentacion.GraficoColumnas();
            this.pnlTituloMonto = new System.Windows.Forms.Panel();
            this.lblIconoMonto = new System.Windows.Forms.Label();
            this.lblTituloMonto = new System.Windows.Forms.Label();
            this.pnlCardUsuarios = new Presentacion.RoundedPanel();
            this.graUsuarios = new Presentacion.GraficoBarras();
            this.pnlTituloUsuarios = new System.Windows.Forms.Panel();
            this.lblIconoUsuarios = new System.Windows.Forms.Label();
            this.lblTituloUsuarios = new System.Windows.Forms.Label();
            this.pnlCardClientes = new Presentacion.RoundedPanel();
            this.graClientes = new Presentacion.GraficoDona();
            this.pnlTituloClientes = new System.Windows.Forms.Panel();
            this.lblIconoClientes = new System.Windows.Forms.Label();
            this.lblTituloClientes = new System.Windows.Forms.Label();
            this.pnlKpi = new System.Windows.Forms.Panel();
            this.tlpKpi = new System.Windows.Forms.TableLayoutPanel();
            this.statUsuarios = new Presentacion.StatCard();
            this.statClientes = new Presentacion.StatCard();
            this.statCotizaciones = new Presentacion.StatCard();
            this.statMonto = new Presentacion.StatCard();
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this.tlpCabecera = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSaludo = new System.Windows.Forms.Panel();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.lblEmoji = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.pnlLema = new System.Windows.Forms.Panel();
            this.lblLemaPequeno = new System.Windows.Forms.Label();
            this.lblLemaGrande = new System.Windows.Forms.Label();
            this.pnlFecha = new System.Windows.Forms.Panel();
            this.lblCalendario = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.SuspendLayout();
            this.pnlGraficos.SuspendLayout();
            this.tlpGraficos.SuspendLayout();
            this.pnlCardCotizaciones.SuspendLayout();
            this.pnlTituloCotizaciones.SuspendLayout();
            this.pnlCardMonto.SuspendLayout();
            this.pnlTituloMonto.SuspendLayout();
            this.pnlCardUsuarios.SuspendLayout();
            this.pnlTituloUsuarios.SuspendLayout();
            this.pnlCardClientes.SuspendLayout();
            this.pnlTituloClientes.SuspendLayout();
            this.pnlKpi.SuspendLayout();
            this.tlpKpi.SuspendLayout();
            this.pnlCabecera.SuspendLayout();
            this.tlpCabecera.SuspendLayout();
            this.pnlSaludo.SuspendLayout();
            this.pnlLema.SuspendLayout();
            this.pnlFecha.SuspendLayout();
            // 
            // FrmInicio
            // 
            this.Controls.Add(this.pnlGraficos);
            this.Controls.Add(this.pnlKpi);
            this.Controls.Add(this.pnlCabecera);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.ClientSize = new System.Drawing.Size(920, 640);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmInicio";
            this.Padding = new System.Windows.Forms.Padding(20, 10, 20, 4);
            this.Text = "Inicio";
            // 
            // pnlGraficos
            // 
            this.pnlGraficos.Controls.Add(this.tlpGraficos);
            this.pnlGraficos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGraficos.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.pnlGraficos.Name = "pnlGraficos";
            this.pnlGraficos.Size = new System.Drawing.Size(880, 380);
            // 
            // tlpGraficos
            // 
            this.tlpGraficos.Controls.Add(this.pnlCardCotizaciones, 0, 0);
            this.tlpGraficos.Controls.Add(this.pnlCardMonto, 1, 0);
            this.tlpGraficos.Controls.Add(this.pnlCardUsuarios, 0, 1);
            this.tlpGraficos.Controls.Add(this.pnlCardClientes, 1, 1);
            this.tlpGraficos.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.tlpGraficos.ColumnCount = 2;
            this.tlpGraficos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGraficos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGraficos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGraficos.Name = "tlpGraficos";
            this.tlpGraficos.RowCount = 2;
            this.tlpGraficos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGraficos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGraficos.Size = new System.Drawing.Size(200, 100);
            // 
            // pnlCardCotizaciones
            // 
            this.pnlCardCotizaciones.Controls.Add(this.graCotizaciones);
            this.pnlCardCotizaciones.Controls.Add(this.pnlTituloCotizaciones);
            this.pnlCardCotizaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardCotizaciones.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.pnlCardCotizaciones.Margin = new System.Windows.Forms.Padding(0, 0, 14, 14);
            this.pnlCardCotizaciones.Name = "pnlCardCotizaciones";
            this.pnlCardCotizaciones.Padding = new System.Windows.Forms.Padding(14, 10, 14, 10);
            this.pnlCardCotizaciones.Size = new System.Drawing.Size(200, 100);
            // 
            // graCotizaciones
            // 
            this.graCotizaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graCotizaciones.Name = "graCotizaciones";
            this.graCotizaciones.Size = new System.Drawing.Size(300, 160);
            this.graCotizaciones.TextoCentro = "Total";
            // 
            // pnlTituloCotizaciones
            // 
            this.pnlTituloCotizaciones.Controls.Add(this.lblIconoCotizaciones);
            this.pnlTituloCotizaciones.Controls.Add(this.lblTituloCotizaciones);
            this.pnlTituloCotizaciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTituloCotizaciones.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.pnlTituloCotizaciones.Name = "pnlTituloCotizaciones";
            this.pnlTituloCotizaciones.Size = new System.Drawing.Size(200, 32);
            // 
            // lblIconoCotizaciones
            // 
            this.lblIconoCotizaciones.AutoSize = true;
            this.lblIconoCotizaciones.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.lblIconoCotizaciones.Font = new System.Drawing.Font("Segoe MDL2 Assets", 13F);
            this.lblIconoCotizaciones.ForeColor = System.Drawing.Color.FromArgb(96, 165, 250);
            this.lblIconoCotizaciones.Location = new System.Drawing.Point(0, 3);
            this.lblIconoCotizaciones.Name = "lblIconoCotizaciones";
            this.lblIconoCotizaciones.Text = "\uE8A5";
            // 
            // lblTituloCotizaciones
            // 
            this.lblTituloCotizaciones.AutoSize = true;
            this.lblTituloCotizaciones.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.lblTituloCotizaciones.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTituloCotizaciones.ForeColor = System.Drawing.Color.White;
            this.lblTituloCotizaciones.Location = new System.Drawing.Point(28, 4);
            this.lblTituloCotizaciones.Name = "lblTituloCotizaciones";
            this.lblTituloCotizaciones.Text = "Cotizaciones por estado";
            // 
            // pnlCardMonto
            // 
            this.pnlCardMonto.Controls.Add(this.graMonto);
            this.pnlCardMonto.Controls.Add(this.pnlTituloMonto);
            this.pnlCardMonto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardMonto.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.pnlCardMonto.Margin = new System.Windows.Forms.Padding(0, 0, 0, 14);
            this.pnlCardMonto.Name = "pnlCardMonto";
            this.pnlCardMonto.Padding = new System.Windows.Forms.Padding(14, 10, 14, 10);
            this.pnlCardMonto.Size = new System.Drawing.Size(200, 100);
            // 
            // graMonto
            // 
            this.graMonto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graMonto.Name = "graMonto";
            this.graMonto.Size = new System.Drawing.Size(300, 160);
            this.graMonto.PrefijoValor = "Q";
            // 
            // pnlTituloMonto
            // 
            this.pnlTituloMonto.Controls.Add(this.lblIconoMonto);
            this.pnlTituloMonto.Controls.Add(this.lblTituloMonto);
            this.pnlTituloMonto.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTituloMonto.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.pnlTituloMonto.Name = "pnlTituloMonto";
            this.pnlTituloMonto.Size = new System.Drawing.Size(200, 32);
            // 
            // lblIconoMonto
            // 
            this.lblIconoMonto.AutoSize = true;
            this.lblIconoMonto.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.lblIconoMonto.Font = new System.Drawing.Font("Segoe MDL2 Assets", 13F);
            this.lblIconoMonto.ForeColor = System.Drawing.Color.FromArgb(168, 85, 247);
            this.lblIconoMonto.Location = new System.Drawing.Point(0, 3);
            this.lblIconoMonto.Name = "lblIconoMonto";
            this.lblIconoMonto.Text = "\uE8EF";
            // 
            // lblTituloMonto
            // 
            this.lblTituloMonto.AutoSize = true;
            this.lblTituloMonto.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.lblTituloMonto.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTituloMonto.ForeColor = System.Drawing.Color.White;
            this.lblTituloMonto.Location = new System.Drawing.Point(28, 4);
            this.lblTituloMonto.Name = "lblTituloMonto";
            this.lblTituloMonto.Text = "Monto cotizado por mes";
            // 
            // pnlCardUsuarios
            // 
            this.pnlCardUsuarios.Controls.Add(this.graUsuarios);
            this.pnlCardUsuarios.Controls.Add(this.pnlTituloUsuarios);
            this.pnlCardUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardUsuarios.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.pnlCardUsuarios.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.pnlCardUsuarios.Name = "pnlCardUsuarios";
            this.pnlCardUsuarios.Padding = new System.Windows.Forms.Padding(14, 10, 14, 10);
            this.pnlCardUsuarios.Size = new System.Drawing.Size(200, 100);
            // 
            // graUsuarios
            // 
            this.graUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graUsuarios.Name = "graUsuarios";
            this.graUsuarios.Size = new System.Drawing.Size(300, 160);
            // 
            // pnlTituloUsuarios
            // 
            this.pnlTituloUsuarios.Controls.Add(this.lblIconoUsuarios);
            this.pnlTituloUsuarios.Controls.Add(this.lblTituloUsuarios);
            this.pnlTituloUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTituloUsuarios.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.pnlTituloUsuarios.Name = "pnlTituloUsuarios";
            this.pnlTituloUsuarios.Size = new System.Drawing.Size(200, 32);
            // 
            // lblIconoUsuarios
            // 
            this.lblIconoUsuarios.AutoSize = true;
            this.lblIconoUsuarios.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.lblIconoUsuarios.Font = new System.Drawing.Font("Segoe MDL2 Assets", 13F);
            this.lblIconoUsuarios.ForeColor = System.Drawing.Color.FromArgb(168, 85, 247);
            this.lblIconoUsuarios.Location = new System.Drawing.Point(0, 3);
            this.lblIconoUsuarios.Name = "lblIconoUsuarios";
            this.lblIconoUsuarios.Text = "\uE77B";
            // 
            // lblTituloUsuarios
            // 
            this.lblTituloUsuarios.AutoSize = true;
            this.lblTituloUsuarios.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.lblTituloUsuarios.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTituloUsuarios.ForeColor = System.Drawing.Color.White;
            this.lblTituloUsuarios.Location = new System.Drawing.Point(28, 4);
            this.lblTituloUsuarios.Name = "lblTituloUsuarios";
            this.lblTituloUsuarios.Text = "Usuarios por rol";
            // 
            // pnlCardClientes
            // 
            this.pnlCardClientes.Controls.Add(this.graClientes);
            this.pnlCardClientes.Controls.Add(this.pnlTituloClientes);
            this.pnlCardClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardClientes.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.pnlCardClientes.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.pnlCardClientes.Name = "pnlCardClientes";
            this.pnlCardClientes.Padding = new System.Windows.Forms.Padding(14, 10, 14, 10);
            this.pnlCardClientes.Size = new System.Drawing.Size(200, 100);
            // 
            // graClientes
            // 
            this.graClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graClientes.Name = "graClientes";
            this.graClientes.Size = new System.Drawing.Size(300, 160);
            this.graClientes.TextoCentro = "Total";
            // 
            // pnlTituloClientes
            // 
            this.pnlTituloClientes.Controls.Add(this.lblIconoClientes);
            this.pnlTituloClientes.Controls.Add(this.lblTituloClientes);
            this.pnlTituloClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTituloClientes.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.pnlTituloClientes.Name = "pnlTituloClientes";
            this.pnlTituloClientes.Size = new System.Drawing.Size(200, 32);
            // 
            // lblIconoClientes
            // 
            this.lblIconoClientes.AutoSize = true;
            this.lblIconoClientes.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.lblIconoClientes.Font = new System.Drawing.Font("Segoe MDL2 Assets", 13F);
            this.lblIconoClientes.ForeColor = System.Drawing.Color.FromArgb(168, 85, 247);
            this.lblIconoClientes.Location = new System.Drawing.Point(0, 3);
            this.lblIconoClientes.Name = "lblIconoClientes";
            this.lblIconoClientes.Text = "\uE716";
            // 
            // lblTituloClientes
            // 
            this.lblTituloClientes.AutoSize = true;
            this.lblTituloClientes.BackColor = System.Drawing.Color.FromArgb(26, 32, 84);
            this.lblTituloClientes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTituloClientes.ForeColor = System.Drawing.Color.White;
            this.lblTituloClientes.Location = new System.Drawing.Point(28, 4);
            this.lblTituloClientes.Name = "lblTituloClientes";
            this.lblTituloClientes.Text = "Clientes por estado";
            // 
            // pnlKpi
            // 
            this.pnlKpi.Controls.Add(this.tlpKpi);
            this.pnlKpi.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpi.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.pnlKpi.Name = "pnlKpi";
            this.pnlKpi.Padding = new System.Windows.Forms.Padding(0, 8, 0, 12);
            this.pnlKpi.Size = new System.Drawing.Size(880, 134);
            // 
            // tlpKpi
            // 
            this.tlpKpi.Controls.Add(this.statUsuarios, 0, 0);
            this.tlpKpi.Controls.Add(this.statClientes, 1, 0);
            this.tlpKpi.Controls.Add(this.statCotizaciones, 2, 0);
            this.tlpKpi.Controls.Add(this.statMonto, 3, 0);
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
            // statUsuarios
            // 
            this.statUsuarios.ColorFin = System.Drawing.Color.FromArgb(124, 58, 237);
            this.statUsuarios.ColorInicio = System.Drawing.Color.FromArgb(79, 70, 229);
            this.statUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statUsuarios.Glyph = "\uE77B";
            this.statUsuarios.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.statUsuarios.Name = "statUsuarios";
            this.statUsuarios.Size = new System.Drawing.Size(200, 110);
            this.statUsuarios.Subtitulo = "Activos: 0";
            this.statUsuarios.Titulo = "Usuarios";
            this.statUsuarios.Valor = "0";
            // 
            // statClientes
            // 
            this.statClientes.ColorFin = System.Drawing.Color.FromArgb(150, 40, 120);
            this.statClientes.ColorInicio = System.Drawing.Color.FromArgb(232, 62, 140);
            this.statClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statClientes.Glyph = "\uE716";
            this.statClientes.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.statClientes.Name = "statClientes";
            this.statClientes.Size = new System.Drawing.Size(200, 110);
            this.statClientes.Subtitulo = "Registrados";
            this.statClientes.Titulo = "Clientes";
            this.statClientes.Valor = "0";
            // 
            // statCotizaciones
            // 
            this.statCotizaciones.ColorFin = System.Drawing.Color.FromArgb(14, 116, 144);
            this.statCotizaciones.ColorInicio = System.Drawing.Color.FromArgb(20, 184, 166);
            this.statCotizaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statCotizaciones.Glyph = "\uE8A5";
            this.statCotizaciones.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.statCotizaciones.Name = "statCotizaciones";
            this.statCotizaciones.Size = new System.Drawing.Size(200, 110);
            this.statCotizaciones.Subtitulo = "Totales";
            this.statCotizaciones.Titulo = "Cotizaciones";
            this.statCotizaciones.Valor = "0";
            // 
            // statMonto
            // 
            this.statMonto.ColorFin = System.Drawing.Color.FromArgb(194, 101, 12);
            this.statMonto.ColorInicio = System.Drawing.Color.FromArgb(245, 158, 11);
            this.statMonto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statMonto.Glyph = "\uE8EF";
            this.statMonto.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.statMonto.Name = "statMonto";
            this.statMonto.Size = new System.Drawing.Size(200, 110);
            this.statMonto.Subtitulo = "Total cotizado";
            this.statMonto.Titulo = "Monto cotizado";
            this.statMonto.Valor = "Q0.00";
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.Controls.Add(this.tlpCabecera);
            this.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCabecera.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(880, 92);
            // 
            // tlpCabecera
            // 
            this.tlpCabecera.Controls.Add(this.pnlSaludo, 0, 0);
            this.tlpCabecera.Controls.Add(this.pnlLema, 1, 0);
            this.tlpCabecera.Controls.Add(this.pnlFecha, 2, 0);
            this.tlpCabecera.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.tlpCabecera.ColumnCount = 3;
            this.tlpCabecera.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44F));
            this.tlpCabecera.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.tlpCabecera.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
            this.tlpCabecera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCabecera.Name = "tlpCabecera";
            this.tlpCabecera.RowCount = 1;
            this.tlpCabecera.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCabecera.Size = new System.Drawing.Size(200, 100);
            // 
            // pnlSaludo
            // 
            this.pnlSaludo.Controls.Add(this.lblBienvenida);
            this.pnlSaludo.Controls.Add(this.lblEmoji);
            this.pnlSaludo.Controls.Add(this.lblDescripcion);
            this.pnlSaludo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSaludo.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.pnlSaludo.Name = "pnlSaludo";
            this.pnlSaludo.Size = new System.Drawing.Size(200, 100);
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.BackColor = System.Drawing.Color.Transparent;
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblBienvenida.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.lblBienvenida.Location = new System.Drawing.Point(0, 4);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Text = "¡Bienvenido!";
            // 
            // lblEmoji
            // 
            this.lblEmoji.AutoSize = true;
            this.lblEmoji.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.lblEmoji.Font = new System.Drawing.Font("Segoe UI Emoji", 18F);
            this.lblEmoji.Location = new System.Drawing.Point(156, 6);
            this.lblEmoji.Name = "lblEmoji";
            this.lblEmoji.Text = "\U0001F44B";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.BackColor = System.Drawing.Color.Transparent;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(214, 220, 245);
            this.lblDescripcion.Location = new System.Drawing.Point(0, 50);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Text = "Sistema de gestión de Publicidad Multisucursal.";
            // 
            // pnlLema
            // 
            this.pnlLema.Controls.Add(this.lblLemaPequeno);
            this.pnlLema.Controls.Add(this.lblLemaGrande);
            this.pnlLema.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLema.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.pnlLema.Name = "pnlLema";
            this.pnlLema.Size = new System.Drawing.Size(200, 100);
            // 
            // lblLemaPequeno
            // 
            this.lblLemaPequeno.AutoSize = true;
            this.lblLemaPequeno.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.lblLemaPequeno.Font = new System.Drawing.Font("Segoe Script", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic))));
            this.lblLemaPequeno.ForeColor = System.Drawing.Color.White;
            this.lblLemaPequeno.Location = new System.Drawing.Point(30, 6);
            this.lblLemaPequeno.Name = "lblLemaPequeno";
            this.lblLemaPequeno.Text = "Ideas que";
            // 
            // lblLemaGrande
            // 
            this.lblLemaGrande.AutoSize = true;
            this.lblLemaGrande.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.lblLemaGrande.Font = new System.Drawing.Font("Segoe Script", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblLemaGrande.ForeColor = System.Drawing.Color.FromArgb(236, 72, 153);
            this.lblLemaGrande.Location = new System.Drawing.Point(52, 24);
            this.lblLemaGrande.Name = "lblLemaGrande";
            this.lblLemaGrande.Text = "conectan";
            // 
            // pnlFecha
            // 
            this.pnlFecha.Controls.Add(this.lblCalendario);
            this.pnlFecha.Controls.Add(this.lblFecha);
            this.pnlFecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFecha.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.pnlFecha.Name = "pnlFecha";
            this.pnlFecha.Size = new System.Drawing.Size(200, 100);
            // 
            // lblCalendario
            // 
            this.lblCalendario.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblCalendario.AutoSize = true;
            this.lblCalendario.BackColor = System.Drawing.Color.FromArgb(14, 18, 52);
            this.lblCalendario.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F);
            this.lblCalendario.ForeColor = System.Drawing.Color.FromArgb(160, 170, 220);
            this.lblCalendario.Name = "lblCalendario";
            this.lblCalendario.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.lblCalendario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCalendario.Text = "\uE787";
            // 
            // lblFecha
            // 
            this.lblFecha.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblFecha.AutoSize = true;
            this.lblFecha.BackColor = System.Drawing.Color.Transparent;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(214, 220, 245);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblFecha.Text = "Fecha";
            this.pnlFecha.ResumeLayout(false);
            this.pnlLema.ResumeLayout(false);
            this.pnlSaludo.ResumeLayout(false);
            this.tlpCabecera.ResumeLayout(false);
            this.pnlCabecera.ResumeLayout(false);
            this.tlpKpi.ResumeLayout(false);
            this.pnlKpi.ResumeLayout(false);
            this.pnlTituloClientes.ResumeLayout(false);
            this.pnlCardClientes.ResumeLayout(false);
            this.pnlTituloUsuarios.ResumeLayout(false);
            this.pnlCardUsuarios.ResumeLayout(false);
            this.pnlTituloMonto.ResumeLayout(false);
            this.pnlCardMonto.ResumeLayout(false);
            this.pnlTituloCotizaciones.ResumeLayout(false);
            this.pnlCardCotizaciones.ResumeLayout(false);
            this.tlpGraficos.ResumeLayout(false);
            this.pnlGraficos.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlGraficos;
        private System.Windows.Forms.TableLayoutPanel tlpGraficos;
        private Presentacion.RoundedPanel pnlCardCotizaciones;
        private Presentacion.GraficoDona graCotizaciones;
        private System.Windows.Forms.Panel pnlTituloCotizaciones;
        private System.Windows.Forms.Label lblIconoCotizaciones;
        private System.Windows.Forms.Label lblTituloCotizaciones;
        private Presentacion.RoundedPanel pnlCardMonto;
        private Presentacion.GraficoColumnas graMonto;
        private System.Windows.Forms.Panel pnlTituloMonto;
        private System.Windows.Forms.Label lblIconoMonto;
        private System.Windows.Forms.Label lblTituloMonto;
        private Presentacion.RoundedPanel pnlCardUsuarios;
        private Presentacion.GraficoBarras graUsuarios;
        private System.Windows.Forms.Panel pnlTituloUsuarios;
        private System.Windows.Forms.Label lblIconoUsuarios;
        private System.Windows.Forms.Label lblTituloUsuarios;
        private Presentacion.RoundedPanel pnlCardClientes;
        private Presentacion.GraficoDona graClientes;
        private System.Windows.Forms.Panel pnlTituloClientes;
        private System.Windows.Forms.Label lblIconoClientes;
        private System.Windows.Forms.Label lblTituloClientes;
        private System.Windows.Forms.Panel pnlKpi;
        private System.Windows.Forms.TableLayoutPanel tlpKpi;
        private Presentacion.StatCard statUsuarios;
        private Presentacion.StatCard statClientes;
        private Presentacion.StatCard statCotizaciones;
        private Presentacion.StatCard statMonto;
        private System.Windows.Forms.Panel pnlCabecera;
        private System.Windows.Forms.TableLayoutPanel tlpCabecera;
        private System.Windows.Forms.Panel pnlSaludo;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblEmoji;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Panel pnlLema;
        private System.Windows.Forms.Label lblLemaPequeno;
        private System.Windows.Forms.Label lblLemaGrande;
        private System.Windows.Forms.Panel pnlFecha;
        private System.Windows.Forms.Label lblCalendario;
        private System.Windows.Forms.Label lblFecha;
    }
}
