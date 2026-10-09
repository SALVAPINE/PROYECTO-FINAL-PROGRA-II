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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnlGraficos = new System.Windows.Forms.Panel();
            this.tlpGraficos = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCardCotizaciones = new Presentacion.RoundedPanel();
            this.chtCotizaciones = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblCardCotizaciones = new System.Windows.Forms.Label();
            this.pnlCardMonto = new Presentacion.RoundedPanel();
            this.chtMonto = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblCardMonto = new System.Windows.Forms.Label();
            this.pnlCardUsuarios = new Presentacion.RoundedPanel();
            this.chtUsuarios = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblCardUsuarios = new System.Windows.Forms.Label();
            this.pnlCardClientes = new Presentacion.RoundedPanel();
            this.chtClientes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblCardClientes = new System.Windows.Forms.Label();
            this.pnlKpi = new System.Windows.Forms.Panel();
            this.tlpKpi = new System.Windows.Forms.TableLayoutPanel();
            this.statUsuarios = new Presentacion.StatCard();
            this.statClientes = new Presentacion.StatCard();
            this.statCotizaciones = new Presentacion.StatCard();
            this.statMonto = new Presentacion.StatCard();
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.pnlGraficos.SuspendLayout();
            this.tlpGraficos.SuspendLayout();
            this.pnlCardCotizaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtCotizaciones)).BeginInit();
            this.pnlCardMonto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtMonto)).BeginInit();
            this.pnlCardUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtUsuarios)).BeginInit();
            this.pnlCardClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtClientes)).BeginInit();
            this.pnlKpi.SuspendLayout();
            this.tlpKpi.SuspendLayout();
            this.pnlCabecera.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlGraficos
            // 
            this.pnlGraficos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.pnlGraficos.Controls.Add(this.tlpGraficos);
            this.pnlGraficos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGraficos.Location = new System.Drawing.Point(20, 188);
            this.pnlGraficos.Name = "pnlGraficos";
            this.pnlGraficos.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.pnlGraficos.Size = new System.Drawing.Size(1219, 568);
            this.pnlGraficos.TabIndex = 0;
            // 
            // tlpGraficos
            // 
            this.tlpGraficos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.tlpGraficos.ColumnCount = 2;
            this.tlpGraficos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGraficos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGraficos.Controls.Add(this.pnlCardCotizaciones, 0, 0);
            this.tlpGraficos.Controls.Add(this.pnlCardMonto, 1, 0);
            this.tlpGraficos.Controls.Add(this.pnlCardUsuarios, 0, 1);
            this.tlpGraficos.Controls.Add(this.pnlCardClientes, 1, 1);
            this.tlpGraficos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGraficos.Location = new System.Drawing.Point(0, 6);
            this.tlpGraficos.Name = "tlpGraficos";
            this.tlpGraficos.RowCount = 2;
            this.tlpGraficos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGraficos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGraficos.Size = new System.Drawing.Size(1219, 562);
            this.tlpGraficos.TabIndex = 0;
            // 
            // pnlCardCotizaciones
            // 
            this.pnlCardCotizaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlCardCotizaciones.Controls.Add(this.chtCotizaciones);
            this.pnlCardCotizaciones.Controls.Add(this.lblCardCotizaciones);
            this.pnlCardCotizaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardCotizaciones.Location = new System.Drawing.Point(0, 0);
            this.pnlCardCotizaciones.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
            this.pnlCardCotizaciones.Name = "pnlCardCotizaciones";
            this.pnlCardCotizaciones.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.pnlCardCotizaciones.Size = new System.Drawing.Size(597, 269);
            this.pnlCardCotizaciones.TabIndex = 0;
            // 
            // chtCotizaciones
            // 
            this.chtCotizaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            chartArea1.Name = "ChartArea1";
            this.chtCotizaciones.ChartAreas.Add(chartArea1);
            this.chtCotizaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Font = new System.Drawing.Font("Segoe UI", 9F);
            legend1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(208)))), ((int)(((byte)(240)))));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chtCotizaciones.Legends.Add(legend1);
            this.chtCotizaciones.Location = new System.Drawing.Point(12, 36);
            this.chtCotizaciones.Name = "chtCotizaciones";
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.CustomProperties = "DoughnutRadius=55, PieLabelStyle=Disabled";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chtCotizaciones.Series.Add(series1);
            this.chtCotizaciones.Size = new System.Drawing.Size(573, 223);
            this.chtCotizaciones.TabIndex = 0;
            this.chtCotizaciones.Text = "chtCotizaciones";
            // 
            // lblCardCotizaciones
            // 
            this.lblCardCotizaciones.BackColor = System.Drawing.Color.Transparent;
            this.lblCardCotizaciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCardCotizaciones.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCardCotizaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(208)))), ((int)(((byte)(240)))));
            this.lblCardCotizaciones.Location = new System.Drawing.Point(12, 10);
            this.lblCardCotizaciones.Name = "lblCardCotizaciones";
            this.lblCardCotizaciones.Size = new System.Drawing.Size(573, 26);
            this.lblCardCotizaciones.TabIndex = 1;
            this.lblCardCotizaciones.Text = "Cotizaciones por estado";
            this.lblCardCotizaciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlCardMonto
            // 
            this.pnlCardMonto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlCardMonto.Controls.Add(this.chtMonto);
            this.pnlCardMonto.Controls.Add(this.lblCardMonto);
            this.pnlCardMonto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardMonto.Location = new System.Drawing.Point(609, 0);
            this.pnlCardMonto.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.pnlCardMonto.Name = "pnlCardMonto";
            this.pnlCardMonto.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.pnlCardMonto.Size = new System.Drawing.Size(610, 269);
            this.pnlCardMonto.TabIndex = 1;
            // 
            // chtMonto
            // 
            this.chtMonto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            chartArea2.AxisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            chartArea2.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(140)))));
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            chartArea2.AxisY.LabelStyle.Format = "C0";
            chartArea2.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(140)))));
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(48)))), ((int)(((byte)(110)))));
            chartArea2.AxisY.Minimum = 0D;
            chartArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            chartArea2.Name = "ChartArea2";
            this.chtMonto.ChartAreas.Add(chartArea2);
            this.chtMonto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chtMonto.Location = new System.Drawing.Point(12, 36);
            this.chtMonto.Name = "chtMonto";
            series2.ChartArea = "ChartArea2";
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(63)))), ((int)(((byte)(206)))));
            series2.Name = "Series1";
            this.chtMonto.Series.Add(series2);
            this.chtMonto.Size = new System.Drawing.Size(586, 223);
            this.chtMonto.TabIndex = 0;
            this.chtMonto.Text = "chtMonto";
            // 
            // lblCardMonto
            // 
            this.lblCardMonto.BackColor = System.Drawing.Color.Transparent;
            this.lblCardMonto.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCardMonto.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCardMonto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(208)))), ((int)(((byte)(240)))));
            this.lblCardMonto.Location = new System.Drawing.Point(12, 10);
            this.lblCardMonto.Name = "lblCardMonto";
            this.lblCardMonto.Size = new System.Drawing.Size(586, 26);
            this.lblCardMonto.TabIndex = 1;
            this.lblCardMonto.Text = "Monto cotizado por mes";
            this.lblCardMonto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlCardUsuarios
            // 
            this.pnlCardUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlCardUsuarios.Controls.Add(this.chtUsuarios);
            this.pnlCardUsuarios.Controls.Add(this.lblCardUsuarios);
            this.pnlCardUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardUsuarios.Location = new System.Drawing.Point(0, 281);
            this.pnlCardUsuarios.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.pnlCardUsuarios.Name = "pnlCardUsuarios";
            this.pnlCardUsuarios.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.pnlCardUsuarios.Size = new System.Drawing.Size(597, 281);
            this.pnlCardUsuarios.TabIndex = 2;
            // 
            // chtUsuarios
            // 
            this.chtUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            chartArea3.AxisX.IsReversed = true;
            chartArea3.AxisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            chartArea3.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(140)))));
            chartArea3.AxisX.MajorGrid.Enabled = false;
            chartArea3.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            chartArea3.AxisY.LabelStyle.Format = "0.##";
            chartArea3.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(140)))));
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(48)))), ((int)(((byte)(110)))));
            chartArea3.AxisY.Minimum = 0D;
            chartArea3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            chartArea3.Name = "ChartArea3";
            this.chtUsuarios.ChartAreas.Add(chartArea3);
            this.chtUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chtUsuarios.Location = new System.Drawing.Point(12, 36);
            this.chtUsuarios.Name = "chtUsuarios";
            series3.ChartArea = "ChartArea3";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(201)))), ((int)(((byte)(170)))));
            series3.Name = "Series1";
            this.chtUsuarios.Series.Add(series3);
            this.chtUsuarios.Size = new System.Drawing.Size(573, 235);
            this.chtUsuarios.TabIndex = 0;
            this.chtUsuarios.Text = "chtUsuarios";
            // 
            // lblCardUsuarios
            // 
            this.lblCardUsuarios.BackColor = System.Drawing.Color.Transparent;
            this.lblCardUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCardUsuarios.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCardUsuarios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(208)))), ((int)(((byte)(240)))));
            this.lblCardUsuarios.Location = new System.Drawing.Point(12, 10);
            this.lblCardUsuarios.Name = "lblCardUsuarios";
            this.lblCardUsuarios.Size = new System.Drawing.Size(573, 26);
            this.lblCardUsuarios.TabIndex = 1;
            this.lblCardUsuarios.Text = "Usuarios por rol";
            this.lblCardUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlCardClientes
            // 
            this.pnlCardClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.pnlCardClientes.Controls.Add(this.chtClientes);
            this.pnlCardClientes.Controls.Add(this.lblCardClientes);
            this.pnlCardClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardClientes.Location = new System.Drawing.Point(609, 281);
            this.pnlCardClientes.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCardClientes.Name = "pnlCardClientes";
            this.pnlCardClientes.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.pnlCardClientes.Size = new System.Drawing.Size(610, 281);
            this.pnlCardClientes.TabIndex = 3;
            // 
            // chtClientes
            // 
            this.chtClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            chartArea4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            chartArea4.Name = "ChartArea4";
            this.chtClientes.ChartAreas.Add(chartArea4);
            this.chtClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend2.Font = new System.Drawing.Font("Segoe UI", 9F);
            legend2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(208)))), ((int)(((byte)(240)))));
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend1";
            this.chtClientes.Legends.Add(legend2);
            this.chtClientes.Location = new System.Drawing.Point(12, 36);
            this.chtClientes.Name = "chtClientes";
            series4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea4";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series4.CustomProperties = "DoughnutRadius=55, PieLabelStyle=Disabled";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chtClientes.Series.Add(series4);
            this.chtClientes.Size = new System.Drawing.Size(586, 235);
            this.chtClientes.TabIndex = 0;
            this.chtClientes.Text = "chtClientes";
            // 
            // lblCardClientes
            // 
            this.lblCardClientes.BackColor = System.Drawing.Color.Transparent;
            this.lblCardClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCardClientes.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCardClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(208)))), ((int)(((byte)(240)))));
            this.lblCardClientes.Location = new System.Drawing.Point(12, 10);
            this.lblCardClientes.Name = "lblCardClientes";
            this.lblCardClientes.Size = new System.Drawing.Size(586, 26);
            this.lblCardClientes.TabIndex = 1;
            this.lblCardClientes.Text = "Clientes por estado";
            this.lblCardClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlKpi
            // 
            this.pnlKpi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.pnlKpi.Controls.Add(this.tlpKpi);
            this.pnlKpi.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpi.Location = new System.Drawing.Point(20, 72);
            this.pnlKpi.Name = "pnlKpi";
            this.pnlKpi.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.pnlKpi.Size = new System.Drawing.Size(1219, 116);
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
            this.tlpKpi.Location = new System.Drawing.Point(0, 6);
            this.tlpKpi.Name = "tlpKpi";
            this.tlpKpi.RowCount = 1;
            this.tlpKpi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpKpi.Size = new System.Drawing.Size(1219, 104);
            this.tlpKpi.TabIndex = 0;
            // 
            // statUsuarios
            // 
            this.statUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.statUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statUsuarios.Location = new System.Drawing.Point(0, 0);
            this.statUsuarios.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.statUsuarios.Name = "statUsuarios";
            this.statUsuarios.Size = new System.Drawing.Size(292, 104);
            this.statUsuarios.Subtitulo = "Activos: 0";
            this.statUsuarios.TabIndex = 0;
            this.statUsuarios.Titulo = "Usuarios";
            // 
            // statClientes
            // 
            this.statClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.statClientes.ColorIcono = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(120)))), ((int)(((byte)(240)))));
            this.statClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statClientes.Glyph = "";
            this.statClientes.Location = new System.Drawing.Point(304, 0);
            this.statClientes.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.statClientes.Name = "statClientes";
            this.statClientes.Size = new System.Drawing.Size(292, 104);
            this.statClientes.Subtitulo = "Registrados";
            this.statClientes.TabIndex = 1;
            this.statClientes.Titulo = "Clientes";
            // 
            // statCotizaciones
            // 
            this.statCotizaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.statCotizaciones.ColorIcono = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(130)))), ((int)(((byte)(255)))));
            this.statCotizaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statCotizaciones.Glyph = "";
            this.statCotizaciones.Location = new System.Drawing.Point(608, 0);
            this.statCotizaciones.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.statCotizaciones.Name = "statCotizaciones";
            this.statCotizaciones.Size = new System.Drawing.Size(292, 104);
            this.statCotizaciones.Subtitulo = "Totales";
            this.statCotizaciones.TabIndex = 2;
            this.statCotizaciones.Titulo = "Cotizaciones";
            // 
            // statMonto
            // 
            this.statMonto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(84)))));
            this.statMonto.ColorIcono = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.statMonto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statMonto.Glyph = "";
            this.statMonto.Location = new System.Drawing.Point(912, 0);
            this.statMonto.Margin = new System.Windows.Forms.Padding(0);
            this.statMonto.Name = "statMonto";
            this.statMonto.Size = new System.Drawing.Size(307, 104);
            this.statMonto.Subtitulo = "Total cotizado";
            this.statMonto.TabIndex = 3;
            this.statMonto.Titulo = "Monto cotizado";
            this.statMonto.Valor = "Q0.00";
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.pnlCabecera.Controls.Add(this.lblFecha);
            this.pnlCabecera.Controls.Add(this.lblTitulo);
            this.pnlCabecera.Controls.Add(this.lblBienvenida);
            this.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCabecera.Location = new System.Drawing.Point(20, 8);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(1219, 64);
            this.pnlCabecera.TabIndex = 2;
            // 
            // lblFecha
            // 
            this.lblFecha.BackColor = System.Drawing.Color.Transparent;
            this.lblFecha.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(212)))), ((int)(((byte)(122)))));
            this.lblFecha.Location = new System.Drawing.Point(859, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(360, 64);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fecha";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(69, 30);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Inicio";
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.BackColor = System.Drawing.Color.Transparent;
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBienvenida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.lblBienvenida.Location = new System.Drawing.Point(0, 32);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(259, 23);
            this.lblBienvenida.TabIndex = 2;
            this.lblBienvenida.Text = "Bienvenido a Publicidad Creativa";
            // 
            // FrmInicio
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(1259, 772);
            this.Controls.Add(this.pnlGraficos);
            this.Controls.Add(this.pnlKpi);
            this.Controls.Add(this.pnlCabecera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmInicio";
            this.Padding = new System.Windows.Forms.Padding(20, 8, 20, 16);
            this.Text = "Inicio";
            this.pnlGraficos.ResumeLayout(false);
            this.tlpGraficos.ResumeLayout(false);
            this.pnlCardCotizaciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtCotizaciones)).EndInit();
            this.pnlCardMonto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtMonto)).EndInit();
            this.pnlCardUsuarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtUsuarios)).EndInit();
            this.pnlCardClientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtClientes)).EndInit();
            this.pnlKpi.ResumeLayout(false);
            this.tlpKpi.ResumeLayout(false);
            this.pnlCabecera.ResumeLayout(false);
            this.pnlCabecera.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlGraficos;
        private System.Windows.Forms.TableLayoutPanel tlpGraficos;
        private Presentacion.RoundedPanel pnlCardCotizaciones;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtCotizaciones;
        private System.Windows.Forms.Label lblCardCotizaciones;
        private Presentacion.RoundedPanel pnlCardMonto;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtMonto;
        private System.Windows.Forms.Label lblCardMonto;
        private Presentacion.RoundedPanel pnlCardUsuarios;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtUsuarios;
        private System.Windows.Forms.Label lblCardUsuarios;
        private Presentacion.RoundedPanel pnlCardClientes;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtClientes;
        private System.Windows.Forms.Label lblCardClientes;
        private System.Windows.Forms.Panel pnlKpi;
        private System.Windows.Forms.TableLayoutPanel tlpKpi;
        private Presentacion.StatCard statUsuarios;
        private Presentacion.StatCard statClientes;
        private Presentacion.StatCard statCotizaciones;
        private Presentacion.StatCard statMonto;
        private System.Windows.Forms.Panel pnlCabecera;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBienvenida;
    }
}
