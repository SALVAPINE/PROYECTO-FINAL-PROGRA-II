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
            this.roundedPanel2 = new Presentacion.RoundedPanel();
            this.graficoDona1 = new Presentacion.GraficoDona();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlCardCotizaciones = new Presentacion.RoundedPanel();
            this.graCotizaciones = new Presentacion.GraficoDona();
            this.pnlTituloCotizaciones = new System.Windows.Forms.Panel();
            this.lblIconoCotizaciones = new System.Windows.Forms.Label();
            this.lblTituloCotizaciones = new System.Windows.Forms.Label();
            this.roundedPanel1 = new Presentacion.RoundedPanel();
            this.graficoColumnas1 = new Presentacion.GraficoColumnas();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.pnlFecha = new System.Windows.Forms.Panel();
            this.lblCalendario = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.pnlGraficos.SuspendLayout();
            this.tlpGraficos.SuspendLayout();
            this.roundedPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlCardCotizaciones.SuspendLayout();
            this.pnlTituloCotizaciones.SuspendLayout();
            this.roundedPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlKpi.SuspendLayout();
            this.tlpKpi.SuspendLayout();
            this.pnlCabecera.SuspendLayout();
            this.tlpCabecera.SuspendLayout();
            this.pnlSaludo.SuspendLayout();
            this.pnlFecha.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlGraficos
            // 
            this.pnlGraficos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.pnlGraficos.Controls.Add(this.tlpGraficos);
            this.pnlGraficos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGraficos.Location = new System.Drawing.Point(20, 236);
            this.pnlGraficos.Name = "pnlGraficos";
            this.pnlGraficos.Size = new System.Drawing.Size(880, 400);
            this.pnlGraficos.TabIndex = 0;
            // 
            // tlpGraficos
            // 
            this.tlpGraficos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.tlpGraficos.ColumnCount = 2;
            this.tlpGraficos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGraficos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGraficos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpGraficos.Controls.Add(this.roundedPanel2, 1, 0);
            this.tlpGraficos.Controls.Add(this.pnlCardCotizaciones, 0, 0);
            this.tlpGraficos.Controls.Add(this.roundedPanel1, 0, 1);
            this.tlpGraficos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGraficos.Location = new System.Drawing.Point(0, 0);
            this.tlpGraficos.Name = "tlpGraficos";
            this.tlpGraficos.RowCount = 2;
            this.tlpGraficos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGraficos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGraficos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpGraficos.Size = new System.Drawing.Size(880, 400);
            this.tlpGraficos.TabIndex = 0;
            // 
            // roundedPanel2
            // 
            this.roundedPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.roundedPanel2.Controls.Add(this.graficoDona1);
            this.roundedPanel2.Controls.Add(this.panel2);
            this.roundedPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roundedPanel2.Location = new System.Drawing.Point(447, 7);
            this.roundedPanel2.Margin = new System.Windows.Forms.Padding(7);
            this.roundedPanel2.Name = "roundedPanel2";
            this.roundedPanel2.Padding = new System.Windows.Forms.Padding(14, 10, 14, 10);
            this.roundedPanel2.Size = new System.Drawing.Size(426, 186);
            this.roundedPanel2.TabIndex = 5;
            this.roundedPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.roundedPanel2_Paint);
            // 
            // graficoDona1
            // 
            this.graficoDona1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.graficoDona1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graficoDona1.ForeColor = System.Drawing.Color.White;
            this.graficoDona1.Location = new System.Drawing.Point(14, 42);
            this.graficoDona1.Name = "graficoDona1";
            this.graficoDona1.Size = new System.Drawing.Size(398, 134);
            this.graficoDona1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(14, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(398, 32);
            this.panel2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.label3.Font = new System.Drawing.Font("Segoe MDL2 Assets", 13F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(85)))), ((int)(((byte)(247)))));
            this.label3.Location = new System.Drawing.Point(0, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(28, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "Clientes por estado";
            // 
            // pnlCardCotizaciones
            // 
            this.pnlCardCotizaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlCardCotizaciones.Controls.Add(this.graCotizaciones);
            this.pnlCardCotizaciones.Controls.Add(this.pnlTituloCotizaciones);
            this.pnlCardCotizaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardCotizaciones.Location = new System.Drawing.Point(7, 7);
            this.pnlCardCotizaciones.Margin = new System.Windows.Forms.Padding(7);
            this.pnlCardCotizaciones.Name = "pnlCardCotizaciones";
            this.pnlCardCotizaciones.Padding = new System.Windows.Forms.Padding(14, 10, 14, 10);
            this.pnlCardCotizaciones.Size = new System.Drawing.Size(426, 186);
            this.pnlCardCotizaciones.TabIndex = 0;
            // 
            // graCotizaciones
            // 
            this.graCotizaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.graCotizaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graCotizaciones.ForeColor = System.Drawing.Color.White;
            this.graCotizaciones.Location = new System.Drawing.Point(14, 42);
            this.graCotizaciones.Name = "graCotizaciones";
            this.graCotizaciones.Size = new System.Drawing.Size(398, 134);
            this.graCotizaciones.TabIndex = 0;
            // 
            // pnlTituloCotizaciones
            // 
            this.pnlTituloCotizaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlTituloCotizaciones.Controls.Add(this.lblIconoCotizaciones);
            this.pnlTituloCotizaciones.Controls.Add(this.lblTituloCotizaciones);
            this.pnlTituloCotizaciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTituloCotizaciones.Location = new System.Drawing.Point(14, 10);
            this.pnlTituloCotizaciones.Name = "pnlTituloCotizaciones";
            this.pnlTituloCotizaciones.Size = new System.Drawing.Size(398, 32);
            this.pnlTituloCotizaciones.TabIndex = 1;
            // 
            // lblIconoCotizaciones
            // 
            this.lblIconoCotizaciones.AutoSize = true;
            this.lblIconoCotizaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.lblIconoCotizaciones.Font = new System.Drawing.Font("Segoe MDL2 Assets", 13F);
            this.lblIconoCotizaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(165)))), ((int)(((byte)(250)))));
            this.lblIconoCotizaciones.Location = new System.Drawing.Point(0, 3);
            this.lblIconoCotizaciones.Name = "lblIconoCotizaciones";
            this.lblIconoCotizaciones.Size = new System.Drawing.Size(32, 22);
            this.lblIconoCotizaciones.TabIndex = 0;
            this.lblIconoCotizaciones.Text = "";
            // 
            // lblTituloCotizaciones
            // 
            this.lblTituloCotizaciones.AutoSize = true;
            this.lblTituloCotizaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.lblTituloCotizaciones.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTituloCotizaciones.ForeColor = System.Drawing.Color.White;
            this.lblTituloCotizaciones.Location = new System.Drawing.Point(28, 4);
            this.lblTituloCotizaciones.Name = "lblTituloCotizaciones";
            this.lblTituloCotizaciones.Size = new System.Drawing.Size(200, 23);
            this.lblTituloCotizaciones.TabIndex = 1;
            this.lblTituloCotizaciones.Text = "Cotizaciones por estado";
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.tlpGraficos.SetColumnSpan(this.roundedPanel1, 2);
            this.roundedPanel1.Controls.Add(this.graficoColumnas1);
            this.roundedPanel1.Controls.Add(this.panel1);
            this.roundedPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roundedPanel1.Location = new System.Drawing.Point(7, 207);
            this.roundedPanel1.Margin = new System.Windows.Forms.Padding(7);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Padding = new System.Windows.Forms.Padding(14, 10, 14, 10);
            this.roundedPanel1.Size = new System.Drawing.Size(866, 186);
            this.roundedPanel1.TabIndex = 4;
            // 
            // graficoColumnas1
            // 
            this.graficoColumnas1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.graficoColumnas1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graficoColumnas1.ForeColor = System.Drawing.Color.White;
            this.graficoColumnas1.Location = new System.Drawing.Point(14, 42);
            this.graficoColumnas1.Name = "graficoColumnas1";
            this.graficoColumnas1.Size = new System.Drawing.Size(838, 134);
            this.graficoColumnas1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(14, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(838, 32);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.label1.Font = new System.Drawing.Font("Segoe MDL2 Assets", 13F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(85)))), ((int)(((byte)(247)))));
            this.label1.Location = new System.Drawing.Point(0, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(28, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Monto cotizado por mes";
            // 
            // pnlKpi
            // 
            this.pnlKpi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.pnlKpi.Controls.Add(this.tlpKpi);
            this.pnlKpi.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpi.Location = new System.Drawing.Point(20, 102);
            this.pnlKpi.Name = "pnlKpi";
            this.pnlKpi.Padding = new System.Windows.Forms.Padding(0, 8, 0, 12);
            this.pnlKpi.Size = new System.Drawing.Size(880, 134);
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
            this.tlpKpi.Controls.Add(this.statUsuarios, 0, 0);
            this.tlpKpi.Controls.Add(this.statClientes, 1, 0);
            this.tlpKpi.Controls.Add(this.statCotizaciones, 2, 0);
            this.tlpKpi.Controls.Add(this.statMonto, 3, 0);
            this.tlpKpi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpKpi.Location = new System.Drawing.Point(0, 8);
            this.tlpKpi.Name = "tlpKpi";
            this.tlpKpi.RowCount = 1;
            this.tlpKpi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpKpi.Size = new System.Drawing.Size(880, 114);
            this.tlpKpi.TabIndex = 0;
            // 
            // statUsuarios
            // 
            this.statUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.statUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statUsuarios.Location = new System.Drawing.Point(0, 0);
            this.statUsuarios.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.statUsuarios.Name = "statUsuarios";
            this.statUsuarios.Size = new System.Drawing.Size(208, 114);
            this.statUsuarios.Subtitulo = "Activos: 0";
            this.statUsuarios.TabIndex = 0;
            this.statUsuarios.Titulo = "Usuarios";
            // 
            // statClientes
            // 
            this.statClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.statClientes.ColorFin = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(40)))), ((int)(((byte)(120)))));
            this.statClientes.ColorInicio = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(62)))), ((int)(((byte)(140)))));
            this.statClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statClientes.Glyph = "";
            this.statClientes.Location = new System.Drawing.Point(220, 0);
            this.statClientes.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.statClientes.Name = "statClientes";
            this.statClientes.Size = new System.Drawing.Size(208, 114);
            this.statClientes.Subtitulo = "Registrados";
            this.statClientes.TabIndex = 1;
            this.statClientes.Titulo = "Clientes";
            // 
            // statCotizaciones
            // 
            this.statCotizaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.statCotizaciones.ColorFin = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
            this.statCotizaciones.ColorInicio = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(184)))), ((int)(((byte)(166)))));
            this.statCotizaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statCotizaciones.Glyph = "";
            this.statCotizaciones.Location = new System.Drawing.Point(440, 0);
            this.statCotizaciones.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.statCotizaciones.Name = "statCotizaciones";
            this.statCotizaciones.Size = new System.Drawing.Size(208, 114);
            this.statCotizaciones.Subtitulo = "Totales";
            this.statCotizaciones.TabIndex = 2;
            this.statCotizaciones.Titulo = "Cotizaciones";
            // 
            // statMonto
            // 
            this.statMonto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.statMonto.ColorFin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(101)))), ((int)(((byte)(12)))));
            this.statMonto.ColorInicio = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.statMonto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statMonto.Glyph = "";
            this.statMonto.Location = new System.Drawing.Point(660, 0);
            this.statMonto.Margin = new System.Windows.Forms.Padding(0);
            this.statMonto.Name = "statMonto";
            this.statMonto.Size = new System.Drawing.Size(220, 114);
            this.statMonto.Subtitulo = "Total cotizado";
            this.statMonto.TabIndex = 3;
            this.statMonto.Titulo = "Monto cotizado";
            this.statMonto.Valor = "Q0.00";
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.pnlCabecera.Controls.Add(this.tlpCabecera);
            this.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCabecera.Location = new System.Drawing.Point(20, 10);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(880, 92);
            this.pnlCabecera.TabIndex = 2;
            // 
            // tlpCabecera
            // 
            this.tlpCabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.tlpCabecera.ColumnCount = 3;
            this.tlpCabecera.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44F));
            this.tlpCabecera.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.tlpCabecera.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
            this.tlpCabecera.Controls.Add(this.pnlSaludo, 0, 0);
            this.tlpCabecera.Controls.Add(this.pnlLema, 1, 0);
            this.tlpCabecera.Controls.Add(this.pnlFecha, 2, 0);
            this.tlpCabecera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCabecera.Location = new System.Drawing.Point(0, 0);
            this.tlpCabecera.Name = "tlpCabecera";
            this.tlpCabecera.RowCount = 1;
            this.tlpCabecera.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCabecera.Size = new System.Drawing.Size(880, 92);
            this.tlpCabecera.TabIndex = 0;
            // 
            // pnlSaludo
            // 
            this.pnlSaludo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.pnlSaludo.Controls.Add(this.lblBienvenida);
            this.pnlSaludo.Controls.Add(this.lblEmoji);
            this.pnlSaludo.Controls.Add(this.lblDescripcion);
            this.pnlSaludo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSaludo.Location = new System.Drawing.Point(3, 3);
            this.pnlSaludo.Name = "pnlSaludo";
            this.pnlSaludo.Size = new System.Drawing.Size(381, 86);
            this.pnlSaludo.TabIndex = 0;
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.BackColor = System.Drawing.Color.Transparent;
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblBienvenida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblBienvenida.Location = new System.Drawing.Point(0, 4);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(222, 46);
            this.lblBienvenida.TabIndex = 0;
            this.lblBienvenida.Text = "¡Bienvenido!";
            // 
            // lblEmoji
            // 
            this.lblEmoji.AutoSize = true;
            this.lblEmoji.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.lblEmoji.Font = new System.Drawing.Font("Segoe UI Emoji", 18F);
            this.lblEmoji.ForeColor = System.Drawing.Color.White;
            this.lblEmoji.Location = new System.Drawing.Point(173, 8);
            this.lblEmoji.Name = "lblEmoji";
            this.lblEmoji.Size = new System.Drawing.Size(58, 40);
            this.lblEmoji.TabIndex = 1;
            this.lblEmoji.Text = "👋";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.BackColor = System.Drawing.Color.Transparent;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(245)))));
            this.lblDescripcion.Location = new System.Drawing.Point(0, 50);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(371, 23);
            this.lblDescripcion.TabIndex = 2;
            this.lblDescripcion.Text = "Sistema de gestión de Publicidad Multisucursal.";
            // 
            // pnlLema
            // 
            this.pnlLema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.pnlLema.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLema.Location = new System.Drawing.Point(390, 3);
            this.pnlLema.Name = "pnlLema";
            this.pnlLema.Size = new System.Drawing.Size(205, 86);
            this.pnlLema.TabIndex = 1;
            // 
            // pnlFecha
            // 
            this.pnlFecha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.pnlFecha.Controls.Add(this.lblCalendario);
            this.pnlFecha.Controls.Add(this.lblFecha);
            this.pnlFecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFecha.Location = new System.Drawing.Point(601, 3);
            this.pnlFecha.Name = "pnlFecha";
            this.pnlFecha.Size = new System.Drawing.Size(276, 86);
            this.pnlFecha.TabIndex = 2;
            // 
            // lblCalendario
            // 
            this.lblCalendario.AutoSize = true;
            this.lblCalendario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.lblCalendario.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblCalendario.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F);
            this.lblCalendario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblCalendario.Location = new System.Drawing.Point(189, 0);
            this.lblCalendario.Name = "lblCalendario";
            this.lblCalendario.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.lblCalendario.Size = new System.Drawing.Size(37, 20);
            this.lblCalendario.TabIndex = 0;
            this.lblCalendario.Text = "";
            this.lblCalendario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.BackColor = System.Drawing.Color.Transparent;
            this.lblFecha.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(245)))));
            this.lblFecha.Location = new System.Drawing.Point(226, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(50, 21);
            this.lblFecha.TabIndex = 1;
            this.lblFecha.Text = "Fecha";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmInicio
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(920, 640);
            this.Controls.Add(this.pnlGraficos);
            this.Controls.Add(this.pnlKpi);
            this.Controls.Add(this.pnlCabecera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmInicio";
            this.Padding = new System.Windows.Forms.Padding(20, 10, 20, 4);
            this.Text = "Inicio";
            this.pnlGraficos.ResumeLayout(false);
            this.tlpGraficos.ResumeLayout(false);
            this.roundedPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlCardCotizaciones.ResumeLayout(false);
            this.pnlTituloCotizaciones.ResumeLayout(false);
            this.pnlTituloCotizaciones.PerformLayout();
            this.roundedPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlKpi.ResumeLayout(false);
            this.tlpKpi.ResumeLayout(false);
            this.pnlCabecera.ResumeLayout(false);
            this.tlpCabecera.ResumeLayout(false);
            this.pnlSaludo.ResumeLayout(false);
            this.pnlSaludo.PerformLayout();
            this.pnlFecha.ResumeLayout(false);
            this.pnlFecha.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlGraficos;
        private System.Windows.Forms.TableLayoutPanel tlpGraficos;
        private Presentacion.RoundedPanel pnlCardCotizaciones;
        private Presentacion.GraficoDona graCotizaciones;
        private System.Windows.Forms.Panel pnlTituloCotizaciones;
        private System.Windows.Forms.Label lblIconoCotizaciones;
        private System.Windows.Forms.Label lblTituloCotizaciones;
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
        private System.Windows.Forms.Panel pnlFecha;
        private System.Windows.Forms.Label lblCalendario;
        private System.Windows.Forms.Label lblFecha;
        private RoundedPanel roundedPanel2;
        private GraficoDona graficoDona1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private RoundedPanel roundedPanel1;
        private GraficoColumnas graficoColumnas1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
