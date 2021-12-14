
namespace Interface_V2
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.port1 = new System.IO.Ports.SerialPort(this.components);
            this.tbxLogRX = new System.Windows.Forms.TextBox();
            this.tbxLogTX = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxConfigIdent = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnConfig = new System.Windows.Forms.Button();
            this.tbxVersion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxIdent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPortClose = new System.Windows.Forms.Button();
            this.btnPortOpen = new System.Windows.Forms.Button();
            this.cbxPort = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbxOverview = new System.Windows.Forms.GroupBox();
            this.systemDiagram1 = new Interface_V2.SystemDiagram();
            this.gbxLogging = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.chartPress = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTemp = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogSave = new System.Windows.Forms.Button();
            this.btnLogStop = new System.Windows.Forms.Button();
            this.btnLogStart = new System.Windows.Forms.Button();
            this.gbxControls = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbxHeliumFlow = new System.Windows.Forms.CheckBox();
            this.btnPurgeOx = new System.Windows.Forms.Button();
            this.btnPurgeFuel = new System.Windows.Forms.Button();
            this.btnManual = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnState1 = new System.Windows.Forms.Button();
            this.btnState2 = new System.Windows.Forms.Button();
            this.btnState8 = new System.Windows.Forms.Button();
            this.btnState3 = new System.Windows.Forms.Button();
            this.btnState7 = new System.Windows.Forms.Button();
            this.btnState5 = new System.Windows.Forms.Button();
            this.btnState6 = new System.Windows.Forms.Button();
            this.btnState4 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gbxComms = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dialogConfig = new System.Windows.Forms.OpenFileDialog();
            this.dialogLog = new System.Windows.Forms.SaveFileDialog();
            this.tmrPurge = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.gbxOverview.SuspendLayout();
            this.gbxLogging.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemp)).BeginInit();
            this.panel1.SuspendLayout();
            this.gbxControls.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbxComms.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // port1
            // 
            this.port1.BaudRate = 115200;
            this.port1.ReadTimeout = 2000;
            // 
            // tbxLogRX
            // 
            this.tbxLogRX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxLogRX.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxLogRX.Location = new System.Drawing.Point(8, 50);
            this.tbxLogRX.Margin = new System.Windows.Forms.Padding(4);
            this.tbxLogRX.Name = "tbxLogRX";
            this.tbxLogRX.ReadOnly = true;
            this.tbxLogRX.Size = new System.Drawing.Size(1876, 20);
            this.tbxLogRX.TabIndex = 24;
            // 
            // tbxLogTX
            // 
            this.tbxLogTX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxLogTX.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxLogTX.Location = new System.Drawing.Point(8, 23);
            this.tbxLogTX.Margin = new System.Windows.Forms.Padding(4);
            this.tbxLogTX.Name = "tbxLogTX";
            this.tbxLogTX.ReadOnly = true;
            this.tbxLogTX.Size = new System.Drawing.Size(1876, 20);
            this.tbxLogTX.TabIndex = 23;
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.tbxConfigIdent);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnConfig);
            this.groupBox1.Controls.Add(this.tbxVersion);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbxIdent);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnPortClose);
            this.groupBox1.Controls.Add(this.btnPortOpen);
            this.groupBox1.Controls.Add(this.cbxPort);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1893, 61);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // tbxConfigIdent
            // 
            this.tbxConfigIdent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxConfigIdent.Location = new System.Drawing.Point(1681, 25);
            this.tbxConfigIdent.Margin = new System.Windows.Forms.Padding(4);
            this.tbxConfigIdent.Name = "tbxConfigIdent";
            this.tbxConfigIdent.ReadOnly = true;
            this.tbxConfigIdent.Size = new System.Drawing.Size(195, 22);
            this.tbxConfigIdent.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1617, 30);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "Config";
            // 
            // btnConfig
            // 
            this.btnConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfig.Location = new System.Drawing.Point(1467, 22);
            this.btnConfig.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(131, 26);
            this.btnConfig.TabIndex = 22;
            this.btnConfig.Text = "LOAD CONFIG";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // tbxVersion
            // 
            this.tbxVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tbxVersion.Location = new System.Drawing.Point(829, 22);
            this.tbxVersion.Margin = new System.Windows.Forms.Padding(4);
            this.tbxVersion.Name = "tbxVersion";
            this.tbxVersion.ReadOnly = true;
            this.tbxVersion.Size = new System.Drawing.Size(195, 22);
            this.tbxVersion.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(765, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Version";
            // 
            // tbxIdent
            // 
            this.tbxIdent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tbxIdent.Location = new System.Drawing.Point(561, 22);
            this.tbxIdent.Margin = new System.Windows.Forms.Padding(4);
            this.tbxIdent.Name = "tbxIdent";
            this.tbxIdent.ReadOnly = true;
            this.tbxIdent.Size = new System.Drawing.Size(195, 22);
            this.tbxIdent.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(491, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Identifier";
            // 
            // btnPortClose
            // 
            this.btnPortClose.Enabled = false;
            this.btnPortClose.Location = new System.Drawing.Point(373, 21);
            this.btnPortClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnPortClose.Name = "btnPortClose";
            this.btnPortClose.Size = new System.Drawing.Size(100, 28);
            this.btnPortClose.TabIndex = 16;
            this.btnPortClose.Text = "CLOSE";
            this.btnPortClose.UseVisualStyleBackColor = true;
            this.btnPortClose.Click += new System.EventHandler(this.btnPortClose_Click);
            // 
            // btnPortOpen
            // 
            this.btnPortOpen.Location = new System.Drawing.Point(265, 21);
            this.btnPortOpen.Margin = new System.Windows.Forms.Padding(4);
            this.btnPortOpen.Name = "btnPortOpen";
            this.btnPortOpen.Size = new System.Drawing.Size(100, 28);
            this.btnPortOpen.TabIndex = 15;
            this.btnPortOpen.Text = "OPEN";
            this.btnPortOpen.UseVisualStyleBackColor = true;
            this.btnPortOpen.Click += new System.EventHandler(this.btnPortOpen_Click);
            // 
            // cbxPort
            // 
            this.cbxPort.FormattingEnabled = true;
            this.cbxPort.Location = new System.Drawing.Point(61, 23);
            this.cbxPort.Margin = new System.Windows.Forms.Padding(4);
            this.cbxPort.Name = "cbxPort";
            this.cbxPort.Size = new System.Drawing.Size(195, 24);
            this.cbxPort.TabIndex = 14;
            this.cbxPort.DropDown += new System.EventHandler(this.cbxPort_DropDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Port";
            // 
            // gbxOverview
            // 
            this.gbxOverview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxOverview.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbxOverview.Controls.Add(this.systemDiagram1);
            this.gbxOverview.Location = new System.Drawing.Point(4, 73);
            this.gbxOverview.Margin = new System.Windows.Forms.Padding(4);
            this.gbxOverview.Name = "gbxOverview";
            this.gbxOverview.Padding = new System.Windows.Forms.Padding(4);
            this.gbxOverview.Size = new System.Drawing.Size(941, 483);
            this.gbxOverview.TabIndex = 19;
            this.gbxOverview.TabStop = false;
            this.gbxOverview.Text = "System Overview";
            // 
            // systemDiagram1
            // 
            this.systemDiagram1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.systemDiagram1.Location = new System.Drawing.Point(8, 23);
            this.systemDiagram1.Margin = new System.Windows.Forms.Padding(4);
            this.systemDiagram1.Name = "systemDiagram1";
            this.systemDiagram1.Size = new System.Drawing.Size(925, 452);
            this.systemDiagram1.TabIndex = 0;
            this.systemDiagram1.Text = "systemDiagram1";
            // 
            // gbxLogging
            // 
            this.gbxLogging.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxLogging.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbxLogging.Controls.Add(this.tableLayoutPanel2);
            this.gbxLogging.Location = new System.Drawing.Point(953, 73);
            this.gbxLogging.Margin = new System.Windows.Forms.Padding(4);
            this.gbxLogging.Name = "gbxLogging";
            this.gbxLogging.Padding = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.SetRowSpan(this.gbxLogging, 2);
            this.gbxLogging.Size = new System.Drawing.Size(944, 613);
            this.gbxLogging.TabIndex = 20;
            this.gbxLogging.TabStop = false;
            this.gbxLogging.Text = "Data Logging";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.chartPress, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.chartTemp, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(8, 23);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(928, 582);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // chartPress
            // 
            this.chartPress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.AxisY.Maximum = 2D;
            chartArea1.AxisY.Minimum = -1D;
            chartArea1.AxisY.Title = "Pressure [kPa]";
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 100F;
            chartArea1.Position.Width = 100F;
            this.chartPress.ChartAreas.Add(chartArea1);
            legend1.DockedToChartArea = "ChartArea1";
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left;
            legend1.Name = "Legend1";
            this.chartPress.Legends.Add(legend1);
            this.chartPress.Location = new System.Drawing.Point(4, 275);
            this.chartPress.Margin = new System.Windows.Forms.Padding(4);
            this.chartPress.Name = "chartPress";
            this.chartPress.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Series3";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "Series4";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Legend = "Legend1";
            series5.Name = "Series5";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "Series6";
            this.chartPress.Series.Add(series1);
            this.chartPress.Series.Add(series2);
            this.chartPress.Series.Add(series3);
            this.chartPress.Series.Add(series4);
            this.chartPress.Series.Add(series5);
            this.chartPress.Series.Add(series6);
            this.chartPress.Size = new System.Drawing.Size(920, 263);
            this.chartPress.TabIndex = 1;
            this.chartPress.Text = "chart1";
            // 
            // chartTemp
            // 
            this.chartTemp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea2.AxisY.Title = "Temperature [K]";
            chartArea2.Name = "ChartArea1";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 100F;
            chartArea2.Position.Width = 100F;
            this.chartTemp.ChartAreas.Add(chartArea2);
            legend2.DockedToChartArea = "ChartArea1";
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left;
            legend2.Name = "Legend1";
            this.chartTemp.Legends.Add(legend2);
            this.chartTemp.Location = new System.Drawing.Point(4, 4);
            this.chartTemp.Margin = new System.Windows.Forms.Padding(4);
            this.chartTemp.Name = "chartTemp";
            this.chartTemp.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Legend = "Legend1";
            series8.Name = "Series2";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series9.Legend = "Legend1";
            series9.Name = "Series3";
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series10.Legend = "Legend1";
            series10.Name = "Series4";
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series11.Legend = "Legend1";
            series11.Name = "Series5";
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series12.Legend = "Legend1";
            series12.Name = "Series6";
            this.chartTemp.Series.Add(series7);
            this.chartTemp.Series.Add(series8);
            this.chartTemp.Series.Add(series9);
            this.chartTemp.Series.Add(series10);
            this.chartTemp.Series.Add(series11);
            this.chartTemp.Series.Add(series12);
            this.chartTemp.Size = new System.Drawing.Size(920, 263);
            this.chartTemp.TabIndex = 0;
            this.chartTemp.Text = "chart1";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnLogSave);
            this.panel1.Controls.Add(this.btnLogStop);
            this.panel1.Controls.Add(this.btnLogStart);
            this.panel1.Location = new System.Drawing.Point(4, 546);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(920, 32);
            this.panel1.TabIndex = 2;
            // 
            // btnLogSave
            // 
            this.btnLogSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogSave.Location = new System.Drawing.Point(817, 2);
            this.btnLogSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogSave.Name = "btnLogSave";
            this.btnLogSave.Size = new System.Drawing.Size(100, 28);
            this.btnLogSave.TabIndex = 2;
            this.btnLogSave.Text = "SAVE";
            this.btnLogSave.UseVisualStyleBackColor = true;
            this.btnLogSave.Click += new System.EventHandler(this.btnLogSave_Click);
            // 
            // btnLogStop
            // 
            this.btnLogStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogStop.Location = new System.Drawing.Point(709, 2);
            this.btnLogStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogStop.Name = "btnLogStop";
            this.btnLogStop.Size = new System.Drawing.Size(100, 28);
            this.btnLogStop.TabIndex = 1;
            this.btnLogStop.Text = "STOP";
            this.btnLogStop.UseVisualStyleBackColor = true;
            this.btnLogStop.Click += new System.EventHandler(this.btnLogStop_Click);
            // 
            // btnLogStart
            // 
            this.btnLogStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogStart.Location = new System.Drawing.Point(601, 2);
            this.btnLogStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogStart.Name = "btnLogStart";
            this.btnLogStart.Size = new System.Drawing.Size(100, 28);
            this.btnLogStart.TabIndex = 0;
            this.btnLogStart.Text = "START";
            this.btnLogStart.UseVisualStyleBackColor = true;
            this.btnLogStart.Click += new System.EventHandler(this.btnLogStart_Click);
            // 
            // gbxControls
            // 
            this.gbxControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxControls.Controls.Add(this.groupBox3);
            this.gbxControls.Controls.Add(this.groupBox2);
            this.gbxControls.Controls.Add(this.label6);
            this.gbxControls.Controls.Add(this.label5);
            this.gbxControls.Location = new System.Drawing.Point(4, 564);
            this.gbxControls.Margin = new System.Windows.Forms.Padding(4);
            this.gbxControls.Name = "gbxControls";
            this.gbxControls.Padding = new System.Windows.Forms.Padding(4);
            this.gbxControls.Size = new System.Drawing.Size(941, 122);
            this.gbxControls.TabIndex = 21;
            this.gbxControls.TabStop = false;
            this.gbxControls.Text = "System Controls";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.Pink;
            this.groupBox3.Controls.Add(this.cbxHeliumFlow);
            this.groupBox3.Controls.Add(this.btnPurgeOx);
            this.groupBox3.Controls.Add(this.btnPurgeFuel);
            this.groupBox3.Controls.Add(this.btnManual);
            this.groupBox3.Location = new System.Drawing.Point(659, 23);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(275, 92);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Manual Control (DANGER)";
            // 
            // cbxHeliumFlow
            // 
            this.cbxHeliumFlow.AutoSize = true;
            this.cbxHeliumFlow.Location = new System.Drawing.Point(116, 25);
            this.cbxHeliumFlow.Margin = new System.Windows.Forms.Padding(4);
            this.cbxHeliumFlow.Name = "cbxHeliumFlow";
            this.cbxHeliumFlow.Size = new System.Drawing.Size(124, 20);
            this.cbxHeliumFlow.TabIndex = 11;
            this.cbxHeliumFlow.Text = "HELIUM BLEED";
            this.cbxHeliumFlow.UseVisualStyleBackColor = true;
            this.cbxHeliumFlow.CheckedChanged += new System.EventHandler(this.cbxHeliumFlow_CheckedChanged);
            // 
            // btnPurgeOx
            // 
            this.btnPurgeOx.Location = new System.Drawing.Point(8, 20);
            this.btnPurgeOx.Margin = new System.Windows.Forms.Padding(4);
            this.btnPurgeOx.Name = "btnPurgeOx";
            this.btnPurgeOx.Size = new System.Drawing.Size(100, 28);
            this.btnPurgeOx.TabIndex = 8;
            this.btnPurgeOx.Text = "PURGE";
            this.btnPurgeOx.UseVisualStyleBackColor = true;
            this.btnPurgeOx.Click += new System.EventHandler(this.btnPurgeOx_Click);
            // 
            // btnPurgeFuel
            // 
            this.btnPurgeFuel.Location = new System.Drawing.Point(8, 55);
            this.btnPurgeFuel.Margin = new System.Windows.Forms.Padding(4);
            this.btnPurgeFuel.Name = "btnPurgeFuel";
            this.btnPurgeFuel.Size = new System.Drawing.Size(100, 28);
            this.btnPurgeFuel.TabIndex = 9;
            this.btnPurgeFuel.Text = "PURGE";
            this.btnPurgeFuel.UseVisualStyleBackColor = true;
            this.btnPurgeFuel.Click += new System.EventHandler(this.btnPurgeFuel_Click);
            // 
            // btnManual
            // 
            this.btnManual.Location = new System.Drawing.Point(116, 55);
            this.btnManual.Margin = new System.Windows.Forms.Padding(4);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(151, 28);
            this.btnManual.TabIndex = 10;
            this.btnManual.Text = "MANUAL";
            this.btnManual.UseVisualStyleBackColor = true;
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnState1);
            this.groupBox2.Controls.Add(this.btnState2);
            this.groupBox2.Controls.Add(this.btnState8);
            this.groupBox2.Controls.Add(this.btnState3);
            this.groupBox2.Controls.Add(this.btnState7);
            this.groupBox2.Controls.Add(this.btnState5);
            this.groupBox2.Controls.Add(this.btnState6);
            this.groupBox2.Controls.Add(this.btnState4);
            this.groupBox2.Location = new System.Drawing.Point(100, 23);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(551, 92);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "State Machine";
            // 
            // btnState1
            // 
            this.btnState1.Location = new System.Drawing.Point(8, 20);
            this.btnState1.Margin = new System.Windows.Forms.Padding(4);
            this.btnState1.Name = "btnState1";
            this.btnState1.Size = new System.Drawing.Size(100, 28);
            this.btnState1.TabIndex = 0;
            this.btnState1.Text = "FILL/DRAIN";
            this.btnState1.UseVisualStyleBackColor = true;
            // 
            // btnState2
            // 
            this.btnState2.Location = new System.Drawing.Point(8, 55);
            this.btnState2.Margin = new System.Windows.Forms.Padding(4);
            this.btnState2.Name = "btnState2";
            this.btnState2.Size = new System.Drawing.Size(100, 28);
            this.btnState2.TabIndex = 1;
            this.btnState2.Text = "FILL/DRAIN";
            this.btnState2.UseVisualStyleBackColor = true;
            // 
            // btnState8
            // 
            this.btnState8.Location = new System.Drawing.Point(440, 20);
            this.btnState8.Margin = new System.Windows.Forms.Padding(4);
            this.btnState8.Name = "btnState8";
            this.btnState8.Size = new System.Drawing.Size(100, 64);
            this.btnState8.TabIndex = 7;
            this.btnState8.Text = "ABORT";
            this.btnState8.UseVisualStyleBackColor = true;
            // 
            // btnState3
            // 
            this.btnState3.Location = new System.Drawing.Point(116, 20);
            this.btnState3.Margin = new System.Windows.Forms.Padding(4);
            this.btnState3.Name = "btnState3";
            this.btnState3.Size = new System.Drawing.Size(100, 28);
            this.btnState3.TabIndex = 2;
            this.btnState3.Text = "SAFE";
            this.btnState3.UseVisualStyleBackColor = true;
            // 
            // btnState7
            // 
            this.btnState7.Location = new System.Drawing.Point(332, 20);
            this.btnState7.Margin = new System.Windows.Forms.Padding(4);
            this.btnState7.Name = "btnState7";
            this.btnState7.Size = new System.Drawing.Size(100, 64);
            this.btnState7.TabIndex = 6;
            this.btnState7.Text = "FIRE";
            this.btnState7.UseVisualStyleBackColor = true;
            // 
            // btnState5
            // 
            this.btnState5.Location = new System.Drawing.Point(224, 20);
            this.btnState5.Margin = new System.Windows.Forms.Padding(4);
            this.btnState5.Name = "btnState5";
            this.btnState5.Size = new System.Drawing.Size(100, 28);
            this.btnState5.TabIndex = 3;
            this.btnState5.Text = "PRESSED";
            this.btnState5.UseVisualStyleBackColor = true;
            // 
            // btnState6
            // 
            this.btnState6.Location = new System.Drawing.Point(224, 55);
            this.btnState6.Margin = new System.Windows.Forms.Padding(4);
            this.btnState6.Name = "btnState6";
            this.btnState6.Size = new System.Drawing.Size(100, 28);
            this.btnState6.TabIndex = 5;
            this.btnState6.Text = "PRESSED";
            this.btnState6.UseVisualStyleBackColor = true;
            // 
            // btnState4
            // 
            this.btnState4.Location = new System.Drawing.Point(116, 55);
            this.btnState4.Margin = new System.Windows.Forms.Padding(4);
            this.btnState4.Name = "btnState4";
            this.btnState4.Size = new System.Drawing.Size(100, 28);
            this.btnState4.TabIndex = 4;
            this.btnState4.Text = "SAFE";
            this.btnState4.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 86);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "FUEL SIDE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 50);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "OX SIDE";
            // 
            // gbxComms
            // 
            this.gbxComms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.gbxComms, 2);
            this.gbxComms.Controls.Add(this.tbxLogRX);
            this.gbxComms.Controls.Add(this.tbxLogTX);
            this.gbxComms.Location = new System.Drawing.Point(4, 694);
            this.gbxComms.Margin = new System.Windows.Forms.Padding(4);
            this.gbxComms.Name = "gbxComms";
            this.gbxComms.Padding = new System.Windows.Forms.Padding(4);
            this.gbxComms.Size = new System.Drawing.Size(1893, 81);
            this.gbxComms.TabIndex = 22;
            this.gbxComms.TabStop = false;
            this.gbxComms.Text = "Raw Data";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 949F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gbxComms, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.gbxLogging, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.gbxControls, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.gbxOverview, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1901, 779);
            this.tableLayoutPanel1.TabIndex = 23;
            // 
            // dialogConfig
            // 
            this.dialogConfig.Filter = "JSON Files|*.json";
            this.dialogConfig.Title = "Choose config file";
            // 
            // dialogLog
            // 
            this.dialogLog.Filter = "CSV Files|*.csv";
            // 
            // tmrPurge
            // 
            this.tmrPurge.Interval = 1000;
            this.tmrPurge.Tick += new System.EventHandler(this.tmrPurge_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1901, 782);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1917, 821);
            this.Name = "FormMain";
            this.Text = "CAT GSE Controller";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbxOverview.ResumeLayout(false);
            this.gbxLogging.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartPress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemp)).EndInit();
            this.panel1.ResumeLayout(false);
            this.gbxControls.ResumeLayout(false);
            this.gbxControls.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.gbxComms.ResumeLayout(false);
            this.gbxComms.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort port1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox tbxLogRX;
        private System.Windows.Forms.TextBox tbxLogTX;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxIdent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPortClose;
        private System.Windows.Forms.Button btnPortOpen;
        private System.Windows.Forms.ComboBox cbxPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbxOverview;
        private System.Windows.Forms.GroupBox gbxLogging;
        private System.Windows.Forms.GroupBox gbxControls;
        private System.Windows.Forms.GroupBox gbxComms;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTemp;
        private System.Windows.Forms.Button btnState8;
        private System.Windows.Forms.Button btnState7;
        private System.Windows.Forms.Button btnState6;
        private System.Windows.Forms.Button btnState4;
        private System.Windows.Forms.Button btnState5;
        private System.Windows.Forms.Button btnState3;
        private System.Windows.Forms.Button btnState2;
        private System.Windows.Forms.Button btnState1;
        private System.Windows.Forms.TextBox tbxConfigIdent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.OpenFileDialog dialogConfig;
        private SystemDiagram systemDiagram1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPress;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLogSave;
        private System.Windows.Forms.Button btnLogStop;
        private System.Windows.Forms.Button btnLogStart;
        private System.Windows.Forms.SaveFileDialog dialogLog;
        private System.Windows.Forms.Button btnManual;
        private System.Windows.Forms.Button btnPurgeFuel;
        private System.Windows.Forms.Button btnPurgeOx;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbxHeliumFlow;
        private System.Windows.Forms.Timer tmrPurge;
    }
}

