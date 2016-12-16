using PConfigBase.BaseModelImpl.BaseViewModelImpl;
namespace PConfigUI
{
    partial class MainFrame
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.连接串口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.探头信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.载入配置文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.备份配置文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.main_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.configurationTabPage = new System.Windows.Forms.TabPage();
            this.cfgDGV = new System.Windows.Forms.DataGridView();
            this.addr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Depth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.highAir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefreshAir = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lowWater = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefreshWater = new System.Windows.Forms.DataGridViewButtonColumn();
            this.CoefStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sensorViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sensorTestTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.queryAllButton = new System.Windows.Forms.Button();
            this.querySelectedButton = new System.Windows.Forms.Button();
            this.stopQueryingButton = new System.Windows.Forms.Button();
            this.TestDGV = new System.Windows.Forms.DataGridView();
            this.selAddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depthDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rawCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.celibrateValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isSelected4Test = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clockTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.clock_dateTimeLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.clock_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.timeSynButton = new System.Windows.Forms.Button();
            this.clock_samplingIntervalGroupBox = new System.Windows.Forms.GroupBox();
            this.clock_samplingIntervalLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.clock_samplingInterval = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.loggerTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.logger_lastResp = new System.Windows.Forms.TextBox();
            this.logger_urlEdit = new System.Windows.Forms.Button();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.logger_parity = new System.Windows.Forms.ComboBox();
            this.logger_parityLabel = new System.Windows.Forms.Label();
            this.logger_destURL = new System.Windows.Forms.TextBox();
            this.logger_baudRateLabel = new System.Windows.Forms.Label();
            this.logger_baudRate = new System.Windows.Forms.ComboBox();
            this.logger_connectOutLabel = new System.Windows.Forms.Label();
            this.logger_respOutLabel = new System.Windows.Forms.Label();
            this.logger_URLLabel = new System.Windows.Forms.Label();
            this.logger_connectOut = new System.Windows.Forms.NumericUpDown();
            this.logger_respOut = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.logger_sampleCountLabel = new System.Windows.Forms.Label();
            this.logger_dialInUp = new System.Windows.Forms.DateTimePicker();
            this.logger_dialInUpLabel = new System.Windows.Forms.Label();
            this.logger_sampleCount = new System.Windows.Forms.NumericUpDown();
            this.sampleCountLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.logger_IDLabel = new System.Windows.Forms.Label();
            this.logger_sampleOrigin = new System.Windows.Forms.DateTimePicker();
            this.logger_sampleOriginLabel = new System.Windows.Forms.Label();
            this.logger_delReading = new System.Windows.Forms.Button();
            this.logger_ID = new System.Windows.Forms.TextBox();
            this.networkTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.network_disconnectRespLabel = new System.Windows.Forms.Label();
            this.network_init = new System.Windows.Forms.TextBox();
            this.network_initLabel = new System.Windows.Forms.Label();
            this.network_dialInDisableLabel = new System.Windows.Forms.Label();
            this.network_dialInDisable = new System.Windows.Forms.TextBox();
            this.network_dialInEnableLabel = new System.Windows.Forms.Label();
            this.network_disconnectResp = new System.Windows.Forms.TextBox();
            this.network_dialInEnable = new System.Windows.Forms.TextBox();
            this.network_dialInEnableRespLabel = new System.Windows.Forms.Label();
            this.network_disconnectLabel = new System.Windows.Forms.Label();
            this.network_disconnect = new System.Windows.Forms.TextBox();
            this.network_dialInEnableResp = new System.Windows.Forms.TextBox();
            this.network_connectRespLabel = new System.Windows.Forms.Label();
            this.network_connectResp = new System.Windows.Forms.TextBox();
            this.network_initRespLabel = new System.Windows.Forms.Label();
            this.network_connectLabel = new System.Windows.Forms.Label();
            this.network_dialInDisableResp = new System.Windows.Forms.TextBox();
            this.network_connect = new System.Windows.Forms.TextBox();
            this.network_initResp = new System.Windows.Forms.TextBox();
            this.network_dialInDisableRespLabel = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.network_nameLabel = new System.Windows.Forms.Label();
            this.network_pwd = new System.Windows.Forms.TextBox();
            this.network_passwordLabel = new System.Windows.Forms.Label();
            this.network_userName = new System.Windows.Forms.TextBox();
            this.modemTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.modem_atCmdText = new System.Windows.Forms.ComboBox();
            this.modem_send = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.modem_openSession = new System.Windows.Forms.Button();
            this.modem_textbox = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel16 = new System.Windows.Forms.TableLayoutPanel();
            this.modem_progressBar = new System.Windows.Forms.ProgressBar();
            this.modem_test = new System.Windows.Forms.Button();
            this.modem_upload = new System.Windows.Forms.Button();
            this.modem_status = new System.Windows.Forms.Label();
            this.powerTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel17 = new System.Windows.Forms.TableLayoutPanel();
            this.power_disableProbeLabel = new System.Windows.Forms.Label();
            this.power_disableTelecom = new System.Windows.Forms.TextBox();
            this.power_disableTelecomZone = new System.Windows.Forms.Label();
            this.power_disableProbe = new System.Windows.Forms.TextBox();
            this.power_enableProbeZone = new System.Windows.Forms.Label();
            this.power_disableProbeZone = new System.Windows.Forms.Label();
            this.power_disableTelecomLabel = new System.Windows.Forms.Label();
            this.power_enableProbeLabel = new System.Windows.Forms.Label();
            this.power_enableProbe = new System.Windows.Forms.TextBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel18 = new System.Windows.Forms.TableLayoutPanel();
            this.label40 = new System.Windows.Forms.Label();
            this.power_solarChargeLogged = new System.Windows.Forms.CheckBox();
            this.power_supply = new System.Windows.Forms.Label();
            this.power_solarCharge = new System.Windows.Forms.Label();
            this.power_solarLogged = new System.Windows.Forms.CheckBox();
            this.label35 = new System.Windows.Forms.Label();
            this.power_supplyLogged = new System.Windows.Forms.CheckBox();
            this.power_batteryLogged = new System.Windows.Forms.CheckBox();
            this.label33 = new System.Windows.Forms.Label();
            this.power_battery = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.power_solar = new System.Windows.Forms.Label();
            this.tableLayoutPanel19 = new System.Windows.Forms.TableLayoutPanel();
            this.autoDetectButton = new System.Windows.Forms.Button();
            this.readProbeButton = new System.Windows.Forms.Button();
            this.writeProbeButton = new System.Windows.Forms.Button();
            this.backupButton = new System.Windows.Forms.Button();
            this.restoreButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.configurationTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cfgDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensorViewModelBindingSource)).BeginInit();
            this.sensorTestTabPage.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TestDGV)).BeginInit();
            this.clockTabPage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.clock_samplingIntervalGroupBox.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.loggerTabPage.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logger_connectOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logger_respOut)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logger_sampleCount)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.networkTabPage.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tableLayoutPanel13.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.modemTabPage.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.tableLayoutPanel15.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.tableLayoutPanel16.SuspendLayout();
            this.powerTabPage.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.tableLayoutPanel17.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.tableLayoutPanel18.SuspendLayout();
            this.tableLayoutPanel19.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.连接串口ToolStripMenuItem,
            this.探头信息ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(570, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 连接串口ToolStripMenuItem
            // 
            this.连接串口ToolStripMenuItem.Name = "连接串口ToolStripMenuItem";
            this.连接串口ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.连接串口ToolStripMenuItem.Text = "串口设置";
            this.连接串口ToolStripMenuItem.Click += new System.EventHandler(this.连接串口ToolStripMenuItem_Click);
            // 
            // 探头信息ToolStripMenuItem
            // 
            this.探头信息ToolStripMenuItem.Name = "探头信息ToolStripMenuItem";
            this.探头信息ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.探头信息ToolStripMenuItem.Text = "探头信息";
            this.探头信息ToolStripMenuItem.Click += new System.EventHandler(this.探头信息ToolStripMenuItem_Click);
            // 
            // 载入配置文件ToolStripMenuItem
            // 
            this.载入配置文件ToolStripMenuItem.Name = "载入配置文件ToolStripMenuItem";
            this.载入配置文件ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.载入配置文件ToolStripMenuItem.Text = "载入配置文件";
            // 
            // 备份配置文件ToolStripMenuItem
            // 
            this.备份配置文件ToolStripMenuItem.Name = "备份配置文件ToolStripMenuItem";
            this.备份配置文件ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.备份配置文件ToolStripMenuItem.Text = "备份配置文件";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.main_status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 403);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(570, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // main_status
            // 
            this.main_status.Name = "main_status";
            this.main_status.Size = new System.Drawing.Size(56, 17);
            this.main_status.Text = "状态显示";
            // 
            // mainTabControl
            // 
            this.mainTabControl.Location = new System.Drawing.Point(12, 28);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(550, 314);
            this.mainTabControl.TabIndex = 2;
            this.mainTabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.mainTabControl_Selected);
            this.mainTabControl.Deselected += new System.Windows.Forms.TabControlEventHandler(this.mainTabControl_Deselected);
            // 
            // configurationTabPage
            // 
            this.configurationTabPage.Controls.Add(this.cfgDGV);
            this.configurationTabPage.Location = new System.Drawing.Point(4, 22);
            this.configurationTabPage.Name = "configurationTabPage";
            this.configurationTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.configurationTabPage.Size = new System.Drawing.Size(542, 288);
            this.configurationTabPage.TabIndex = 0;
            this.configurationTabPage.Text = "传感器配置";
            this.configurationTabPage.UseVisualStyleBackColor = true;
            // 
            // cfgDGV
            // 
            this.cfgDGV.AllowUserToAddRows = false;
            this.cfgDGV.AllowUserToDeleteRows = false;
            this.cfgDGV.AutoGenerateColumns = false;
            this.cfgDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cfgDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.addr,
            this.Depth,
            this.highAir,
            this.RefreshAir,
            this.lowWater,
            this.RefreshWater,
            this.CoefStr,
            this.isSelected});
            this.cfgDGV.DataSource = this.sensorViewModelBindingSource;
            this.cfgDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cfgDGV.Location = new System.Drawing.Point(3, 3);
            this.cfgDGV.Name = "cfgDGV";
            this.cfgDGV.RowTemplate.Height = 23;
            this.cfgDGV.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.cfgDGV.Size = new System.Drawing.Size(536, 282);
            this.cfgDGV.TabIndex = 1;
            this.cfgDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cfgDGV_CellContentClick);
            this.cfgDGV.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.cfgDGV_CellPainting);
            this.cfgDGV.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.cfgDGV_CellValidating);
            this.cfgDGV.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.cfgDGV_CellValueChanged);
            this.cfgDGV.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.cfgDGV_DataError);
            // 
            // addr
            // 
            this.addr.DataPropertyName = "Addr";
            this.addr.HeaderText = "地址";
            this.addr.Name = "addr";
            this.addr.ReadOnly = true;
            this.addr.Width = 55;
            // 
            // Depth
            // 
            this.Depth.DataPropertyName = "Depth";
            this.Depth.HeaderText = "深度";
            this.Depth.Name = "Depth";
            this.Depth.Width = 55;
            // 
            // highAir
            // 
            this.highAir.DataPropertyName = "HighAir";
            this.highAir.FillWeight = 80F;
            this.highAir.HeaderText = "空气中计频数";
            this.highAir.Name = "highAir";
            this.highAir.Width = 65;
            // 
            // RefreshAir
            // 
            this.RefreshAir.HeaderText = "";
            this.RefreshAir.Name = "RefreshAir";
            this.RefreshAir.Width = 15;
            // 
            // lowWater
            // 
            this.lowWater.DataPropertyName = "LowWater";
            this.lowWater.FillWeight = 80F;
            this.lowWater.HeaderText = "水中计频数";
            this.lowWater.Name = "lowWater";
            this.lowWater.Width = 65;
            // 
            // RefreshWater
            // 
            this.RefreshWater.HeaderText = "";
            this.RefreshWater.Name = "RefreshWater";
            this.RefreshWater.Width = 15;
            // 
            // CoefStr
            // 
            this.CoefStr.DataPropertyName = "CoefStr";
            this.CoefStr.HeaderText = "校准系数";
            this.CoefStr.Name = "CoefStr";
            this.CoefStr.Width = 180;
            // 
            // isSelected
            // 
            this.isSelected.DataPropertyName = "IsSelected";
            this.isSelected.FalseValue = "False";
            this.isSelected.HeaderText = "选定";
            this.isSelected.Name = "isSelected";
            this.isSelected.TrueValue = "True";
            this.isSelected.Width = 60;
            // 
            // sensorViewModelBindingSource
            // 
            this.sensorViewModelBindingSource.DataSource = typeof(PConfigBase.BaseModelImpl.BaseViewModelImpl.SensorViewModel);
            // 
            // sensorTestTabPage
            // 
            this.sensorTestTabPage.AutoScroll = true;
            this.sensorTestTabPage.Controls.Add(this.tableLayoutPanel6);
            this.sensorTestTabPage.Location = new System.Drawing.Point(4, 22);
            this.sensorTestTabPage.Name = "sensorTestTabPage";
            this.sensorTestTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.sensorTestTabPage.Size = new System.Drawing.Size(542, 288);
            this.sensorTestTabPage.TabIndex = 1;
            this.sensorTestTabPage.Text = "传感器测试";
            this.sensorTestTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.Controls.Add(this.queryAllButton, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.querySelectedButton, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.stopQueryingButton, 1, 2);
            this.tableLayoutPanel6.Controls.Add(this.TestDGV, 0, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 3;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(531, 276);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // queryAllButton
            // 
            this.queryAllButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.queryAllButton.Location = new System.Drawing.Point(440, 27);
            this.queryAllButton.Name = "queryAllButton";
            this.queryAllButton.Size = new System.Drawing.Size(75, 38);
            this.queryAllButton.TabIndex = 2;
            this.queryAllButton.Text = "查询全部传感器";
            this.queryAllButton.UseVisualStyleBackColor = true;
            this.queryAllButton.Click += new System.EventHandler(this.queryAllButton_Click);
            // 
            // querySelectedButton
            // 
            this.querySelectedButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.querySelectedButton.Location = new System.Drawing.Point(440, 118);
            this.querySelectedButton.Name = "querySelectedButton";
            this.querySelectedButton.Size = new System.Drawing.Size(75, 39);
            this.querySelectedButton.TabIndex = 3;
            this.querySelectedButton.Text = "查询选定传感器";
            this.querySelectedButton.UseVisualStyleBackColor = true;
            this.querySelectedButton.Click += new System.EventHandler(this.querySelectedButton_Click);
            // 
            // stopQueryingButton
            // 
            this.stopQueryingButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.stopQueryingButton.Location = new System.Drawing.Point(440, 210);
            this.stopQueryingButton.Name = "stopQueryingButton";
            this.stopQueryingButton.Size = new System.Drawing.Size(75, 39);
            this.stopQueryingButton.TabIndex = 4;
            this.stopQueryingButton.Text = "停止查询";
            this.stopQueryingButton.UseVisualStyleBackColor = true;
            this.stopQueryingButton.Click += new System.EventHandler(this.stopQueryingButton_Click);
            // 
            // TestDGV
            // 
            this.TestDGV.AllowUserToAddRows = false;
            this.TestDGV.AllowUserToDeleteRows = false;
            this.TestDGV.AutoGenerateColumns = false;
            this.TestDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TestDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selAddr,
            this.depthDataGridViewTextBoxColumn1,
            this.rawCountDataGridViewTextBoxColumn,
            this.celibrateValueDataGridViewTextBoxColumn,
            this.isSelected4Test});
            this.TestDGV.DataSource = this.sensorViewModelBindingSource;
            this.TestDGV.Location = new System.Drawing.Point(3, 3);
            this.TestDGV.Name = "TestDGV";
            this.TestDGV.ReadOnly = true;
            this.tableLayoutPanel6.SetRowSpan(this.TestDGV, 3);
            this.TestDGV.RowTemplate.Height = 23;
            this.TestDGV.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TestDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TestDGV.Size = new System.Drawing.Size(418, 270);
            this.TestDGV.TabIndex = 1;
            this.TestDGV.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.TestDGV_CellPainting);
            // 
            // selAddr
            // 
            this.selAddr.DataPropertyName = "Addr";
            this.selAddr.HeaderText = "地址";
            this.selAddr.Name = "selAddr";
            this.selAddr.ReadOnly = true;
            this.selAddr.Width = 60;
            // 
            // depthDataGridViewTextBoxColumn1
            // 
            this.depthDataGridViewTextBoxColumn1.DataPropertyName = "Depth";
            this.depthDataGridViewTextBoxColumn1.HeaderText = "深度";
            this.depthDataGridViewTextBoxColumn1.Name = "depthDataGridViewTextBoxColumn1";
            this.depthDataGridViewTextBoxColumn1.ReadOnly = true;
            this.depthDataGridViewTextBoxColumn1.Width = 60;
            // 
            // rawCountDataGridViewTextBoxColumn
            // 
            this.rawCountDataGridViewTextBoxColumn.DataPropertyName = "RawCount";
            this.rawCountDataGridViewTextBoxColumn.HeaderText = "实际计频数";
            this.rawCountDataGridViewTextBoxColumn.Name = "rawCountDataGridViewTextBoxColumn";
            this.rawCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // celibrateValueDataGridViewTextBoxColumn
            // 
            this.celibrateValueDataGridViewTextBoxColumn.DataPropertyName = "CelibrateValue";
            this.celibrateValueDataGridViewTextBoxColumn.HeaderText = "校准值";
            this.celibrateValueDataGridViewTextBoxColumn.Name = "celibrateValueDataGridViewTextBoxColumn";
            this.celibrateValueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isSelected4Test
            // 
            this.isSelected4Test.DataPropertyName = "IsSelected";
            this.isSelected4Test.HeaderText = "已选择";
            this.isSelected4Test.Name = "isSelected4Test";
            this.isSelected4Test.ReadOnly = true;
            this.isSelected4Test.Width = 60;
            // 
            // clockTabPage
            // 
            this.clockTabPage.Controls.Add(this.tableLayoutPanel1);
            this.clockTabPage.Location = new System.Drawing.Point(4, 22);
            this.clockTabPage.Name = "clockTabPage";
            this.clockTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.clockTabPage.Size = new System.Drawing.Size(542, 288);
            this.clockTabPage.TabIndex = 2;
            this.clockTabPage.Text = "时钟配置";
            this.clockTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.clock_samplingIntervalGroupBox, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(504, 292);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.groupBox2.Controls.Add(this.clock_dateTimeLabel);
            this.groupBox2.Controls.Add(this.tableLayoutPanel8);
            this.groupBox2.Location = new System.Drawing.Point(3, 167);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(498, 103);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // clock_dateTimeLabel
            // 
            this.clock_dateTimeLabel.AutoSize = true;
            this.clock_dateTimeLabel.Location = new System.Drawing.Point(20, 45);
            this.clock_dateTimeLabel.Name = "clock_dateTimeLabel";
            this.clock_dateTimeLabel.Size = new System.Drawing.Size(65, 12);
            this.clock_dateTimeLabel.TabIndex = 3;
            this.clock_dateTimeLabel.Text = "日期与时间";
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Controls.Add(this.clock_dateTimePicker, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.timeSynButton, 1, 0);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(119, 20);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(347, 63);
            this.tableLayoutPanel8.TabIndex = 2;
            // 
            // clock_dateTimePicker
            // 
            this.clock_dateTimePicker.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.clock_dateTimePicker.CustomFormat = "yyyy\'/\'M\'/\'d H\':\'mm\':\'ss";
            this.clock_dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.clock_dateTimePicker.Location = new System.Drawing.Point(8, 21);
            this.clock_dateTimePicker.MinDate = new System.DateTime(2001, 1, 1, 0, 0, 0, 0);
            this.clock_dateTimePicker.Name = "clock_dateTimePicker";
            this.clock_dateTimePicker.Size = new System.Drawing.Size(156, 21);
            this.clock_dateTimePicker.TabIndex = 0;
            this.clock_dateTimePicker.CloseUp += new System.EventHandler(this.clock_dateTimePicker_CloseUp);
            this.clock_dateTimePicker.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.clock_dateTimePicker_KeyPress);
            // 
            // timeSynButton
            // 
            this.timeSynButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.timeSynButton.Location = new System.Drawing.Point(222, 20);
            this.timeSynButton.Name = "timeSynButton";
            this.timeSynButton.Size = new System.Drawing.Size(75, 23);
            this.timeSynButton.TabIndex = 1;
            this.timeSynButton.Text = "与电脑同步";
            this.timeSynButton.UseVisualStyleBackColor = true;
            this.timeSynButton.Click += new System.EventHandler(this.timeSynButton_Click);
            // 
            // clock_samplingIntervalGroupBox
            // 
            this.clock_samplingIntervalGroupBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.clock_samplingIntervalGroupBox.Controls.Add(this.clock_samplingIntervalLabel);
            this.clock_samplingIntervalGroupBox.Controls.Add(this.tableLayoutPanel7);
            this.clock_samplingIntervalGroupBox.Location = new System.Drawing.Point(3, 23);
            this.clock_samplingIntervalGroupBox.Name = "clock_samplingIntervalGroupBox";
            this.clock_samplingIntervalGroupBox.Size = new System.Drawing.Size(498, 100);
            this.clock_samplingIntervalGroupBox.TabIndex = 2;
            this.clock_samplingIntervalGroupBox.TabStop = false;
            // 
            // clock_samplingIntervalLabel
            // 
            this.clock_samplingIntervalLabel.AutoSize = true;
            this.clock_samplingIntervalLabel.Location = new System.Drawing.Point(6, 48);
            this.clock_samplingIntervalLabel.Name = "clock_samplingIntervalLabel";
            this.clock_samplingIntervalLabel.Size = new System.Drawing.Size(113, 12);
            this.clock_samplingIntervalLabel.TabIndex = 3;
            this.clock_samplingIntervalLabel.Text = "采样间隔时间(分钟)";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.clock_samplingInterval, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(119, 20);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(347, 69);
            this.tableLayoutPanel7.TabIndex = 2;
            // 
            // clock_samplingInterval
            // 
            this.clock_samplingInterval.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.clock_samplingInterval.FormattingEnabled = true;
            this.clock_samplingInterval.Location = new System.Drawing.Point(30, 24);
            this.clock_samplingInterval.Name = "clock_samplingInterval";
            this.clock_samplingInterval.Size = new System.Drawing.Size(113, 20);
            this.clock_samplingInterval.TabIndex = 0;
            this.clock_samplingInterval.TextChanged += new System.EventHandler(this.clock_samplingInterval_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(179, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "最小值2分钟，最大值6天23小时50分钟(10020分钟)";
            // 
            // loggerTabPage
            // 
            this.loggerTabPage.Controls.Add(this.tableLayoutPanel2);
            this.loggerTabPage.Location = new System.Drawing.Point(4, 22);
            this.loggerTabPage.Name = "loggerTabPage";
            this.loggerTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.loggerTabPage.Size = new System.Drawing.Size(542, 288);
            this.loggerTabPage.TabIndex = 3;
            this.loggerTabPage.Text = "记录器配置";
            this.loggerTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox5, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.groupBox4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(501, 301);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.groupBox5.Controls.Add(this.logger_lastResp);
            this.groupBox5.Controls.Add(this.logger_urlEdit);
            this.groupBox5.Controls.Add(this.tableLayoutPanel11);
            this.groupBox5.Location = new System.Drawing.Point(3, 159);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(494, 132);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            // 
            // logger_lastResp
            // 
            this.logger_lastResp.Location = new System.Drawing.Point(352, 54);
            this.logger_lastResp.Multiline = true;
            this.logger_lastResp.Name = "logger_lastResp";
            this.logger_lastResp.Size = new System.Drawing.Size(116, 65);
            this.logger_lastResp.TabIndex = 12;
            // 
            // logger_urlEdit
            // 
            this.logger_urlEdit.Location = new System.Drawing.Point(377, 5);
            this.logger_urlEdit.Name = "logger_urlEdit";
            this.logger_urlEdit.Size = new System.Drawing.Size(75, 23);
            this.logger_urlEdit.TabIndex = 11;
            this.logger_urlEdit.Text = "编辑";
            this.logger_urlEdit.UseVisualStyleBackColor = true;
            this.logger_urlEdit.Click += new System.EventHandler(this.logger_urlEdit_Click);
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel11.ColumnCount = 2;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel11.Controls.Add(this.logger_parity, 1, 4);
            this.tableLayoutPanel11.Controls.Add(this.logger_parityLabel, 0, 4);
            this.tableLayoutPanel11.Controls.Add(this.logger_destURL, 1, 0);
            this.tableLayoutPanel11.Controls.Add(this.logger_baudRateLabel, 0, 3);
            this.tableLayoutPanel11.Controls.Add(this.logger_baudRate, 1, 3);
            this.tableLayoutPanel11.Controls.Add(this.logger_connectOutLabel, 0, 1);
            this.tableLayoutPanel11.Controls.Add(this.logger_respOutLabel, 0, 2);
            this.tableLayoutPanel11.Controls.Add(this.logger_URLLabel, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.logger_connectOut, 1, 1);
            this.tableLayoutPanel11.Controls.Add(this.logger_respOut, 1, 2);
            this.tableLayoutPanel11.Location = new System.Drawing.Point(48, 2);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 5;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(288, 129);
            this.tableLayoutPanel11.TabIndex = 10;
            // 
            // logger_parity
            // 
            this.logger_parity.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.logger_parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.logger_parity.FormattingEnabled = true;
            this.logger_parity.Items.AddRange(new object[] {
            "无",
            "奇校验",
            "偶校验"});
            this.logger_parity.Location = new System.Drawing.Point(103, 104);
            this.logger_parity.Name = "logger_parity";
            this.logger_parity.Size = new System.Drawing.Size(121, 20);
            this.logger_parity.TabIndex = 4;
            this.logger_parity.TextChanged += new System.EventHandler(this.logger_parity_TextChanged);
            // 
            // logger_parityLabel
            // 
            this.logger_parityLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.logger_parityLabel.AutoSize = true;
            this.logger_parityLabel.Location = new System.Drawing.Point(11, 108);
            this.logger_parityLabel.Name = "logger_parityLabel";
            this.logger_parityLabel.Size = new System.Drawing.Size(77, 12);
            this.logger_parityLabel.TabIndex = 9;
            this.logger_parityLabel.Text = "Modem 校验位";
            // 
            // logger_destURL
            // 
            this.logger_destURL.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.logger_destURL.Location = new System.Drawing.Point(103, 3);
            this.logger_destURL.Name = "logger_destURL";
            this.logger_destURL.Size = new System.Drawing.Size(182, 21);
            this.logger_destURL.TabIndex = 0;
            this.logger_destURL.TextChanged += new System.EventHandler(this.logger_destURL_TextChanged);
            // 
            // logger_baudRateLabel
            // 
            this.logger_baudRateLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.logger_baudRateLabel.AutoSize = true;
            this.logger_baudRateLabel.Location = new System.Drawing.Point(11, 81);
            this.logger_baudRateLabel.Name = "logger_baudRateLabel";
            this.logger_baudRateLabel.Size = new System.Drawing.Size(77, 12);
            this.logger_baudRateLabel.TabIndex = 8;
            this.logger_baudRateLabel.Text = "Modem 波特率";
            // 
            // logger_baudRate
            // 
            this.logger_baudRate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.logger_baudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.logger_baudRate.FormattingEnabled = true;
            this.logger_baudRate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "",
            ""});
            this.logger_baudRate.Location = new System.Drawing.Point(103, 78);
            this.logger_baudRate.Name = "logger_baudRate";
            this.logger_baudRate.Size = new System.Drawing.Size(121, 20);
            this.logger_baudRate.TabIndex = 3;
            this.logger_baudRate.TextChanged += new System.EventHandler(this.logger_baudRate_TextChanged);
            // 
            // logger_connectOutLabel
            // 
            this.logger_connectOutLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.logger_connectOutLabel.AutoSize = true;
            this.logger_connectOutLabel.Location = new System.Drawing.Point(5, 31);
            this.logger_connectOutLabel.Name = "logger_connectOutLabel";
            this.logger_connectOutLabel.Size = new System.Drawing.Size(89, 12);
            this.logger_connectOutLabel.TabIndex = 6;
            this.logger_connectOutLabel.Text = "连接时限（秒）";
            // 
            // logger_respOutLabel
            // 
            this.logger_respOutLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.logger_respOutLabel.AutoSize = true;
            this.logger_respOutLabel.Location = new System.Drawing.Point(5, 56);
            this.logger_respOutLabel.Name = "logger_respOutLabel";
            this.logger_respOutLabel.Size = new System.Drawing.Size(89, 12);
            this.logger_respOutLabel.TabIndex = 7;
            this.logger_respOutLabel.Text = "响应时限（秒）";
            // 
            // logger_URLLabel
            // 
            this.logger_URLLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.logger_URLLabel.AutoSize = true;
            this.logger_URLLabel.Location = new System.Drawing.Point(23, 6);
            this.logger_URLLabel.Name = "logger_URLLabel";
            this.logger_URLLabel.Size = new System.Drawing.Size(53, 12);
            this.logger_URLLabel.TabIndex = 5;
            this.logger_URLLabel.Text = "目标 URL";
            // 
            // logger_connectOut
            // 
            this.logger_connectOut.Location = new System.Drawing.Point(103, 28);
            this.logger_connectOut.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.logger_connectOut.Name = "logger_connectOut";
            this.logger_connectOut.Size = new System.Drawing.Size(120, 21);
            this.logger_connectOut.TabIndex = 10;
            this.logger_connectOut.TextChanged += new System.EventHandler(this.logger_connectOut_TextChanged);
            // 
            // logger_respOut
            // 
            this.logger_respOut.Location = new System.Drawing.Point(103, 53);
            this.logger_respOut.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.logger_respOut.Name = "logger_respOut";
            this.logger_respOut.Size = new System.Drawing.Size(120, 21);
            this.logger_respOut.TabIndex = 11;
            this.logger_respOut.TextChanged += new System.EventHandler(this.logger_respOut_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.groupBox4.Controls.Add(this.tableLayoutPanel10);
            this.groupBox4.Location = new System.Drawing.Point(3, 78);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(494, 69);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 3;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel10.Controls.Add(this.logger_sampleCountLabel, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.logger_dialInUp, 1, 1);
            this.tableLayoutPanel10.Controls.Add(this.logger_dialInUpLabel, 0, 1);
            this.tableLayoutPanel10.Controls.Add(this.logger_sampleCount, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.sampleCountLabel, 2, 0);
            this.tableLayoutPanel10.Location = new System.Drawing.Point(48, 5);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 2;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(425, 58);
            this.tableLayoutPanel10.TabIndex = 5;
            // 
            // logger_sampleCountLabel
            // 
            this.logger_sampleCountLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.logger_sampleCountLabel.AutoSize = true;
            this.logger_sampleCountLabel.Location = new System.Drawing.Point(26, 8);
            this.logger_sampleCountLabel.Name = "logger_sampleCountLabel";
            this.logger_sampleCountLabel.Size = new System.Drawing.Size(53, 12);
            this.logger_sampleCountLabel.TabIndex = 2;
            this.logger_sampleCountLabel.Text = "采样计数";
            // 
            // logger_dialInUp
            // 
            this.logger_dialInUp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.logger_dialInUp.CustomFormat = "HH\':\'mm\':\'ss";
            this.logger_dialInUp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.logger_dialInUp.Location = new System.Drawing.Point(109, 33);
            this.logger_dialInUp.MinDate = new System.DateTime(2001, 1, 1, 0, 0, 0, 0);
            this.logger_dialInUp.Name = "logger_dialInUp";
            this.logger_dialInUp.ShowUpDown = true;
            this.logger_dialInUp.Size = new System.Drawing.Size(142, 21);
            this.logger_dialInUp.TabIndex = 4;
            this.logger_dialInUp.TextChanged += new System.EventHandler(this.logger_dialInUp_TextChanged);
            // 
            // logger_dialInUpLabel
            // 
            this.logger_dialInUpLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.logger_dialInUpLabel.AutoSize = true;
            this.logger_dialInUpLabel.Location = new System.Drawing.Point(26, 37);
            this.logger_dialInUpLabel.Name = "logger_dialInUpLabel";
            this.logger_dialInUpLabel.Size = new System.Drawing.Size(53, 12);
            this.logger_dialInUpLabel.TabIndex = 3;
            this.logger_dialInUpLabel.Text = "上传时间";
            // 
            // logger_sampleCount
            // 
            this.logger_sampleCount.Location = new System.Drawing.Point(109, 3);
            this.logger_sampleCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.logger_sampleCount.Name = "logger_sampleCount";
            this.logger_sampleCount.Size = new System.Drawing.Size(142, 21);
            this.logger_sampleCount.TabIndex = 5;
            this.logger_sampleCount.TextChanged += new System.EventHandler(this.logger_sampleCount_TextChanged);
            // 
            // sampleCountLabel
            // 
            this.sampleCountLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sampleCountLabel.AutoSize = true;
            this.sampleCountLabel.Location = new System.Drawing.Point(307, 23);
            this.sampleCountLabel.Name = "sampleCountLabel";
            this.tableLayoutPanel10.SetRowSpan(this.sampleCountLabel, 2);
            this.sampleCountLabel.Size = new System.Drawing.Size(65, 12);
            this.sampleCountLabel.TabIndex = 6;
            this.sampleCountLabel.Text = "采样总时间";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox3.Controls.Add(this.tableLayoutPanel9);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(495, 69);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 3;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel9.Controls.Add(this.logger_IDLabel, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.logger_sampleOrigin, 1, 1);
            this.tableLayoutPanel9.Controls.Add(this.logger_sampleOriginLabel, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.logger_delReading, 2, 0);
            this.tableLayoutPanel9.Controls.Add(this.logger_ID, 1, 0);
            this.tableLayoutPanel9.Location = new System.Drawing.Point(48, 9);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 2;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(425, 60);
            this.tableLayoutPanel9.TabIndex = 5;
            // 
            // logger_IDLabel
            // 
            this.logger_IDLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.logger_IDLabel.AutoSize = true;
            this.logger_IDLabel.Location = new System.Drawing.Point(26, 9);
            this.logger_IDLabel.Name = "logger_IDLabel";
            this.logger_IDLabel.Size = new System.Drawing.Size(53, 12);
            this.logger_IDLabel.TabIndex = 2;
            this.logger_IDLabel.Text = "记录器ID";
            // 
            // logger_sampleOrigin
            // 
            this.logger_sampleOrigin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.logger_sampleOrigin.CustomFormat = "yyyy\'/\'MM\'/\'dd HH\':\'mm\':\'ss";
            this.logger_sampleOrigin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.logger_sampleOrigin.Location = new System.Drawing.Point(109, 34);
            this.logger_sampleOrigin.Name = "logger_sampleOrigin";
            this.logger_sampleOrigin.Size = new System.Drawing.Size(200, 21);
            this.logger_sampleOrigin.TabIndex = 1;
            this.logger_sampleOrigin.ValueChanged += new System.EventHandler(this.logger_sampleOrigin_ValueChanged);
            // 
            // logger_sampleOriginLabel
            // 
            this.logger_sampleOriginLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.logger_sampleOriginLabel.AutoSize = true;
            this.logger_sampleOriginLabel.Location = new System.Drawing.Point(14, 39);
            this.logger_sampleOriginLabel.Name = "logger_sampleOriginLabel";
            this.logger_sampleOriginLabel.Size = new System.Drawing.Size(77, 12);
            this.logger_sampleOriginLabel.TabIndex = 3;
            this.logger_sampleOriginLabel.Text = "采样起始时间";
            // 
            // logger_delReading
            // 
            this.logger_delReading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.logger_delReading.Location = new System.Drawing.Point(344, 3);
            this.logger_delReading.Name = "logger_delReading";
            this.logger_delReading.Size = new System.Drawing.Size(75, 23);
            this.logger_delReading.TabIndex = 4;
            this.logger_delReading.Text = "删除记录";
            this.logger_delReading.UseVisualStyleBackColor = true;
            this.logger_delReading.Click += new System.EventHandler(this.logger_delReading_Click);
            // 
            // logger_ID
            // 
            this.logger_ID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.logger_ID.Location = new System.Drawing.Point(109, 4);
            this.logger_ID.Name = "logger_ID";
            this.logger_ID.Size = new System.Drawing.Size(100, 21);
            this.logger_ID.TabIndex = 0;
            this.logger_ID.TextChanged += new System.EventHandler(this.logger_ID_TextChanged);
            // 
            // networkTabPage
            // 
            this.networkTabPage.Controls.Add(this.tableLayoutPanel3);
            this.networkTabPage.Location = new System.Drawing.Point(4, 22);
            this.networkTabPage.Name = "networkTabPage";
            this.networkTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.networkTabPage.Size = new System.Drawing.Size(542, 288);
            this.networkTabPage.TabIndex = 4;
            this.networkTabPage.Text = "网络配置";
            this.networkTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox7, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.groupBox6, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(498, 292);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.groupBox7.Controls.Add(this.tableLayoutPanel13);
            this.groupBox7.Location = new System.Drawing.Point(3, 90);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(492, 199);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "命令设置";
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel13.ColumnCount = 4;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel13.Controls.Add(this.network_disconnectRespLabel, 2, 4);
            this.tableLayoutPanel13.Controls.Add(this.network_init, 1, 2);
            this.tableLayoutPanel13.Controls.Add(this.network_initLabel, 0, 2);
            this.tableLayoutPanel13.Controls.Add(this.network_dialInDisableLabel, 0, 1);
            this.tableLayoutPanel13.Controls.Add(this.network_dialInDisable, 1, 1);
            this.tableLayoutPanel13.Controls.Add(this.network_dialInEnableLabel, 0, 0);
            this.tableLayoutPanel13.Controls.Add(this.network_disconnectResp, 3, 4);
            this.tableLayoutPanel13.Controls.Add(this.network_dialInEnable, 1, 0);
            this.tableLayoutPanel13.Controls.Add(this.network_dialInEnableRespLabel, 2, 0);
            this.tableLayoutPanel13.Controls.Add(this.network_disconnectLabel, 0, 4);
            this.tableLayoutPanel13.Controls.Add(this.network_disconnect, 1, 4);
            this.tableLayoutPanel13.Controls.Add(this.network_dialInEnableResp, 3, 0);
            this.tableLayoutPanel13.Controls.Add(this.network_connectRespLabel, 2, 3);
            this.tableLayoutPanel13.Controls.Add(this.network_connectResp, 3, 3);
            this.tableLayoutPanel13.Controls.Add(this.network_initRespLabel, 2, 2);
            this.tableLayoutPanel13.Controls.Add(this.network_connectLabel, 0, 3);
            this.tableLayoutPanel13.Controls.Add(this.network_dialInDisableResp, 3, 1);
            this.tableLayoutPanel13.Controls.Add(this.network_connect, 1, 3);
            this.tableLayoutPanel13.Controls.Add(this.network_initResp, 3, 2);
            this.tableLayoutPanel13.Controls.Add(this.network_dialInDisableRespLabel, 2, 1);
            this.tableLayoutPanel13.Location = new System.Drawing.Point(6, 20);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 5;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(464, 150);
            this.tableLayoutPanel13.TabIndex = 15;
            // 
            // network_disconnectRespLabel
            // 
            this.network_disconnectRespLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.network_disconnectRespLabel.AutoSize = true;
            this.network_disconnectRespLabel.Location = new System.Drawing.Point(238, 129);
            this.network_disconnectRespLabel.Name = "network_disconnectRespLabel";
            this.network_disconnectRespLabel.Size = new System.Drawing.Size(77, 12);
            this.network_disconnectRespLabel.TabIndex = 14;
            this.network_disconnectRespLabel.Text = "断开连接响应";
            // 
            // network_init
            // 
            this.network_init.Location = new System.Drawing.Point(95, 63);
            this.network_init.Name = "network_init";
            this.network_init.Size = new System.Drawing.Size(100, 21);
            this.network_init.TabIndex = 7;
            this.network_init.TextChanged += new System.EventHandler(this.network_init_TextChanged);
            // 
            // network_initLabel
            // 
            this.network_initLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.network_initLabel.AutoSize = true;
            this.network_initLabel.Location = new System.Drawing.Point(25, 69);
            this.network_initLabel.Name = "network_initLabel";
            this.network_initLabel.Size = new System.Drawing.Size(41, 12);
            this.network_initLabel.TabIndex = 9;
            this.network_initLabel.Text = "初始化";
            // 
            // network_dialInDisableLabel
            // 
            this.network_dialInDisableLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.network_dialInDisableLabel.AutoSize = true;
            this.network_dialInDisableLabel.Location = new System.Drawing.Point(19, 39);
            this.network_dialInDisableLabel.Name = "network_dialInDisableLabel";
            this.network_dialInDisableLabel.Size = new System.Drawing.Size(53, 12);
            this.network_dialInDisableLabel.TabIndex = 7;
            this.network_dialInDisableLabel.Text = "禁止拨号";
            // 
            // network_dialInDisable
            // 
            this.network_dialInDisable.Location = new System.Drawing.Point(95, 33);
            this.network_dialInDisable.Name = "network_dialInDisable";
            this.network_dialInDisable.Size = new System.Drawing.Size(100, 21);
            this.network_dialInDisable.TabIndex = 5;
            this.network_dialInDisable.TextChanged += new System.EventHandler(this.network_dialInDisable_TextChanged);
            // 
            // network_dialInEnableLabel
            // 
            this.network_dialInEnableLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.network_dialInEnableLabel.AutoSize = true;
            this.network_dialInEnableLabel.Location = new System.Drawing.Point(19, 9);
            this.network_dialInEnableLabel.Name = "network_dialInEnableLabel";
            this.network_dialInEnableLabel.Size = new System.Drawing.Size(53, 12);
            this.network_dialInEnableLabel.TabIndex = 5;
            this.network_dialInEnableLabel.Text = "允许拨号";
            // 
            // network_disconnectResp
            // 
            this.network_disconnectResp.Location = new System.Drawing.Point(326, 123);
            this.network_disconnectResp.Name = "network_disconnectResp";
            this.network_disconnectResp.Size = new System.Drawing.Size(100, 21);
            this.network_disconnectResp.TabIndex = 11;
            this.network_disconnectResp.TextChanged += new System.EventHandler(this.network_disconnectResp_TextChanged);
            // 
            // network_dialInEnable
            // 
            this.network_dialInEnable.Location = new System.Drawing.Point(95, 3);
            this.network_dialInEnable.Name = "network_dialInEnable";
            this.network_dialInEnable.Size = new System.Drawing.Size(100, 21);
            this.network_dialInEnable.TabIndex = 3;
            this.network_dialInEnable.TextChanged += new System.EventHandler(this.network_dialInEnable_TextChanged);
            // 
            // network_dialInEnableRespLabel
            // 
            this.network_dialInEnableRespLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.network_dialInEnableRespLabel.AutoSize = true;
            this.network_dialInEnableRespLabel.Location = new System.Drawing.Point(238, 9);
            this.network_dialInEnableRespLabel.Name = "network_dialInEnableRespLabel";
            this.network_dialInEnableRespLabel.Size = new System.Drawing.Size(77, 12);
            this.network_dialInEnableRespLabel.TabIndex = 6;
            this.network_dialInEnableRespLabel.Text = "允许拨号响应";
            // 
            // network_disconnectLabel
            // 
            this.network_disconnectLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.network_disconnectLabel.AutoSize = true;
            this.network_disconnectLabel.Location = new System.Drawing.Point(19, 129);
            this.network_disconnectLabel.Name = "network_disconnectLabel";
            this.network_disconnectLabel.Size = new System.Drawing.Size(53, 12);
            this.network_disconnectLabel.TabIndex = 13;
            this.network_disconnectLabel.Text = "断开连接";
            // 
            // network_disconnect
            // 
            this.network_disconnect.Location = new System.Drawing.Point(95, 123);
            this.network_disconnect.Name = "network_disconnect";
            this.network_disconnect.Size = new System.Drawing.Size(100, 21);
            this.network_disconnect.TabIndex = 10;
            this.network_disconnect.TextChanged += new System.EventHandler(this.network_disconnect_TextChanged);
            // 
            // network_dialInEnableResp
            // 
            this.network_dialInEnableResp.Location = new System.Drawing.Point(326, 3);
            this.network_dialInEnableResp.Name = "network_dialInEnableResp";
            this.network_dialInEnableResp.Size = new System.Drawing.Size(100, 21);
            this.network_dialInEnableResp.TabIndex = 4;
            this.network_dialInEnableResp.TextChanged += new System.EventHandler(this.network_dialInEnableResp_TextChanged);
            // 
            // network_connectRespLabel
            // 
            this.network_connectRespLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.network_connectRespLabel.AutoSize = true;
            this.network_connectRespLabel.Location = new System.Drawing.Point(238, 99);
            this.network_connectRespLabel.Name = "network_connectRespLabel";
            this.network_connectRespLabel.Size = new System.Drawing.Size(77, 12);
            this.network_connectRespLabel.TabIndex = 12;
            this.network_connectRespLabel.Text = "建立连接响应";
            // 
            // network_connectResp
            // 
            this.network_connectResp.Location = new System.Drawing.Point(326, 93);
            this.network_connectResp.Name = "network_connectResp";
            this.network_connectResp.Size = new System.Drawing.Size(100, 21);
            this.network_connectResp.TabIndex = 9;
            this.network_connectResp.TextChanged += new System.EventHandler(this.network_connectResp_TextChanged);
            // 
            // network_initRespLabel
            // 
            this.network_initRespLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.network_initRespLabel.AutoSize = true;
            this.network_initRespLabel.Location = new System.Drawing.Point(244, 69);
            this.network_initRespLabel.Name = "network_initRespLabel";
            this.network_initRespLabel.Size = new System.Drawing.Size(65, 12);
            this.network_initRespLabel.TabIndex = 10;
            this.network_initRespLabel.Text = "初始化响应";
            // 
            // network_connectLabel
            // 
            this.network_connectLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.network_connectLabel.AutoSize = true;
            this.network_connectLabel.Location = new System.Drawing.Point(19, 99);
            this.network_connectLabel.Name = "network_connectLabel";
            this.network_connectLabel.Size = new System.Drawing.Size(53, 12);
            this.network_connectLabel.TabIndex = 11;
            this.network_connectLabel.Text = "建立连接";
            // 
            // network_dialInDisableResp
            // 
            this.network_dialInDisableResp.Location = new System.Drawing.Point(326, 33);
            this.network_dialInDisableResp.Name = "network_dialInDisableResp";
            this.network_dialInDisableResp.Size = new System.Drawing.Size(100, 21);
            this.network_dialInDisableResp.TabIndex = 6;
            this.network_dialInDisableResp.TextChanged += new System.EventHandler(this.network_dialInDisableResp_TextChanged);
            // 
            // network_connect
            // 
            this.network_connect.Location = new System.Drawing.Point(95, 93);
            this.network_connect.Name = "network_connect";
            this.network_connect.Size = new System.Drawing.Size(100, 21);
            this.network_connect.TabIndex = 8;
            this.network_connect.TextChanged += new System.EventHandler(this.network_connect_TextChanged);
            // 
            // network_initResp
            // 
            this.network_initResp.Location = new System.Drawing.Point(326, 63);
            this.network_initResp.Name = "network_initResp";
            this.network_initResp.Size = new System.Drawing.Size(100, 21);
            this.network_initResp.TabIndex = 0;
            this.network_initResp.TextChanged += new System.EventHandler(this.network_initResp_TextChanged);
            // 
            // network_dialInDisableRespLabel
            // 
            this.network_dialInDisableRespLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.network_dialInDisableRespLabel.AutoSize = true;
            this.network_dialInDisableRespLabel.Location = new System.Drawing.Point(238, 39);
            this.network_dialInDisableRespLabel.Name = "network_dialInDisableRespLabel";
            this.network_dialInDisableRespLabel.Size = new System.Drawing.Size(77, 12);
            this.network_dialInDisableRespLabel.TabIndex = 8;
            this.network_dialInDisableRespLabel.Text = "禁止拨号响应";
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox6.Controls.Add(this.tableLayoutPanel12);
            this.groupBox6.Location = new System.Drawing.Point(3, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(492, 81);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "网络访问";
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel12.ColumnCount = 2;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel12.Controls.Add(this.network_nameLabel, 0, 0);
            this.tableLayoutPanel12.Controls.Add(this.network_pwd, 1, 1);
            this.tableLayoutPanel12.Controls.Add(this.network_passwordLabel, 0, 1);
            this.tableLayoutPanel12.Controls.Add(this.network_userName, 1, 0);
            this.tableLayoutPanel12.Location = new System.Drawing.Point(6, 20);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 2;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(240, 55);
            this.tableLayoutPanel12.TabIndex = 5;
            // 
            // network_nameLabel
            // 
            this.network_nameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.network_nameLabel.AutoSize = true;
            this.network_nameLabel.Location = new System.Drawing.Point(3, 7);
            this.network_nameLabel.Name = "network_nameLabel";
            this.network_nameLabel.Size = new System.Drawing.Size(41, 12);
            this.network_nameLabel.TabIndex = 3;
            this.network_nameLabel.Text = "用户名";
            // 
            // network_pwd
            // 
            this.network_pwd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.network_pwd.Location = new System.Drawing.Point(51, 30);
            this.network_pwd.Name = "network_pwd";
            this.network_pwd.PasswordChar = '*';
            this.network_pwd.Size = new System.Drawing.Size(100, 21);
            this.network_pwd.TabIndex = 2;
            // 
            // network_passwordLabel
            // 
            this.network_passwordLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.network_passwordLabel.AutoSize = true;
            this.network_passwordLabel.Location = new System.Drawing.Point(9, 35);
            this.network_passwordLabel.Name = "network_passwordLabel";
            this.network_passwordLabel.Size = new System.Drawing.Size(29, 12);
            this.network_passwordLabel.TabIndex = 4;
            this.network_passwordLabel.Text = "密码";
            // 
            // network_userName
            // 
            this.network_userName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.network_userName.Location = new System.Drawing.Point(51, 3);
            this.network_userName.Name = "network_userName";
            this.network_userName.Size = new System.Drawing.Size(100, 21);
            this.network_userName.TabIndex = 1;
            // 
            // modemTabPage
            // 
            this.modemTabPage.Controls.Add(this.tableLayoutPanel4);
            this.modemTabPage.Location = new System.Drawing.Point(4, 22);
            this.modemTabPage.Name = "modemTabPage";
            this.modemTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.modemTabPage.Size = new System.Drawing.Size(542, 288);
            this.modemTabPage.TabIndex = 5;
            this.modemTabPage.Text = "Modem配置";
            this.modemTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoScroll = true;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.groupBox8, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.groupBox9, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.groupBox10, 0, 2);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.08511F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.51773F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.04255F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(501, 282);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.groupBox8.Controls.Add(this.tableLayoutPanel14);
            this.groupBox8.Location = new System.Drawing.Point(3, 3);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(495, 45);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "AT命令";
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel14.ColumnCount = 2;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel14.Controls.Add(this.modem_atCmdText, 0, 0);
            this.tableLayoutPanel14.Controls.Add(this.modem_send, 1, 0);
            this.tableLayoutPanel14.Location = new System.Drawing.Point(23, 9);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 1;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(414, 34);
            this.tableLayoutPanel14.TabIndex = 8;
            // 
            // modem_atCmdText
            // 
            this.modem_atCmdText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.modem_atCmdText.FormattingEnabled = true;
            this.modem_atCmdText.Location = new System.Drawing.Point(25, 7);
            this.modem_atCmdText.Name = "modem_atCmdText";
            this.modem_atCmdText.Size = new System.Drawing.Size(238, 20);
            this.modem_atCmdText.TabIndex = 6;
            this.modem_atCmdText.Validating += new System.ComponentModel.CancelEventHandler(this.modem_atCmdText_Validating);
            // 
            // modem_send
            // 
            this.modem_send.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.modem_send.Location = new System.Drawing.Point(314, 6);
            this.modem_send.Name = "modem_send";
            this.modem_send.Size = new System.Drawing.Size(75, 22);
            this.modem_send.TabIndex = 7;
            this.modem_send.Text = "发送";
            this.modem_send.UseVisualStyleBackColor = true;
            this.modem_send.Click += new System.EventHandler(this.modem_send_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox9.Controls.Add(this.tableLayoutPanel15);
            this.groupBox9.Controls.Add(this.label24);
            this.groupBox9.Location = new System.Drawing.Point(3, 58);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(495, 119);
            this.groupBox9.TabIndex = 1;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Modem响应";
            // 
            // tableLayoutPanel15
            // 
            this.tableLayoutPanel15.ColumnCount = 2;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel15.Controls.Add(this.modem_openSession, 0, 0);
            this.tableLayoutPanel15.Controls.Add(this.modem_textbox, 1, 0);
            this.tableLayoutPanel15.Location = new System.Drawing.Point(23, 12);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 1;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.Size = new System.Drawing.Size(414, 101);
            this.tableLayoutPanel15.TabIndex = 10;
            // 
            // modem_openSession
            // 
            this.modem_openSession.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.modem_openSession.Location = new System.Drawing.Point(24, 39);
            this.modem_openSession.Name = "modem_openSession";
            this.modem_openSession.Size = new System.Drawing.Size(75, 23);
            this.modem_openSession.TabIndex = 8;
            this.modem_openSession.Text = "打开会话";
            this.modem_openSession.UseVisualStyleBackColor = true;
            this.modem_openSession.Click += new System.EventHandler(this.modem_openSession_Click);
            // 
            // modem_textbox
            // 
            this.modem_textbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.modem_textbox.Location = new System.Drawing.Point(132, 6);
            this.modem_textbox.Multiline = true;
            this.modem_textbox.Name = "modem_textbox";
            this.modem_textbox.ReadOnly = true;
            this.modem_textbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.modem_textbox.Size = new System.Drawing.Size(274, 89);
            this.modem_textbox.TabIndex = 7;
            this.modem_textbox.TextChanged += new System.EventHandler(this.modem_textbox_TextChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(29, -18);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(65, 12);
            this.label24.TabIndex = 9;
            this.label24.Text = "Modem 响应";
            // 
            // groupBox10
            // 
            this.groupBox10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.groupBox10.Controls.Add(this.tableLayoutPanel16);
            this.groupBox10.Location = new System.Drawing.Point(3, 188);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(495, 91);
            this.groupBox10.TabIndex = 5;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "服务器命令";
            // 
            // tableLayoutPanel16
            // 
            this.tableLayoutPanel16.ColumnCount = 2;
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel16.Controls.Add(this.modem_progressBar, 1, 0);
            this.tableLayoutPanel16.Controls.Add(this.modem_test, 0, 1);
            this.tableLayoutPanel16.Controls.Add(this.modem_upload, 0, 0);
            this.tableLayoutPanel16.Controls.Add(this.modem_status, 1, 1);
            this.tableLayoutPanel16.Location = new System.Drawing.Point(23, 20);
            this.tableLayoutPanel16.Name = "tableLayoutPanel16";
            this.tableLayoutPanel16.RowCount = 2;
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel16.Size = new System.Drawing.Size(414, 67);
            this.tableLayoutPanel16.TabIndex = 4;
            // 
            // modem_progressBar
            // 
            this.modem_progressBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.modem_progressBar.Location = new System.Drawing.Point(219, 5);
            this.modem_progressBar.Name = "modem_progressBar";
            this.modem_progressBar.Size = new System.Drawing.Size(100, 23);
            this.modem_progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.modem_progressBar.TabIndex = 2;
            // 
            // modem_test
            // 
            this.modem_test.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.modem_test.Location = new System.Drawing.Point(24, 38);
            this.modem_test.Name = "modem_test";
            this.modem_test.Size = new System.Drawing.Size(75, 23);
            this.modem_test.TabIndex = 1;
            this.modem_test.Text = "测试";
            this.modem_test.UseVisualStyleBackColor = true;
            this.modem_test.Click += new System.EventHandler(this.modem_test_Click);
            // 
            // modem_upload
            // 
            this.modem_upload.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.modem_upload.Location = new System.Drawing.Point(24, 5);
            this.modem_upload.Name = "modem_upload";
            this.modem_upload.Size = new System.Drawing.Size(75, 23);
            this.modem_upload.TabIndex = 0;
            this.modem_upload.Text = "上传";
            this.modem_upload.UseVisualStyleBackColor = true;
            this.modem_upload.Click += new System.EventHandler(this.modem_upload_Click);
            // 
            // modem_status
            // 
            this.modem_status.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.modem_status.AutoSize = true;
            this.modem_status.Location = new System.Drawing.Point(242, 44);
            this.modem_status.Name = "modem_status";
            this.modem_status.Size = new System.Drawing.Size(53, 12);
            this.modem_status.TabIndex = 3;
            this.modem_status.Text = "响应信息";
            // 
            // powerTabPage
            // 
            this.powerTabPage.Controls.Add(this.tableLayoutPanel5);
            this.powerTabPage.Location = new System.Drawing.Point(4, 22);
            this.powerTabPage.Name = "powerTabPage";
            this.powerTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.powerTabPage.Size = new System.Drawing.Size(542, 288);
            this.powerTabPage.TabIndex = 6;
            this.powerTabPage.Text = "电源配置";
            this.powerTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.groupBox11, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.groupBox12, 0, 1);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(32, 6);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.71831F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.28169F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(498, 284);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // groupBox11
            // 
            this.groupBox11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.groupBox11.Controls.Add(this.tableLayoutPanel17);
            this.groupBox11.Location = new System.Drawing.Point(3, 3);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(492, 120);
            this.groupBox11.TabIndex = 1;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "操作限制";
            // 
            // tableLayoutPanel17
            // 
            this.tableLayoutPanel17.ColumnCount = 3;
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel17.Controls.Add(this.power_disableProbeLabel, 0, 0);
            this.tableLayoutPanel17.Controls.Add(this.power_disableTelecom, 1, 2);
            this.tableLayoutPanel17.Controls.Add(this.power_disableTelecomZone, 2, 2);
            this.tableLayoutPanel17.Controls.Add(this.power_disableProbe, 1, 0);
            this.tableLayoutPanel17.Controls.Add(this.power_enableProbeZone, 2, 1);
            this.tableLayoutPanel17.Controls.Add(this.power_disableProbeZone, 2, 0);
            this.tableLayoutPanel17.Controls.Add(this.power_disableTelecomLabel, 0, 2);
            this.tableLayoutPanel17.Controls.Add(this.power_enableProbeLabel, 0, 1);
            this.tableLayoutPanel17.Controls.Add(this.power_enableProbe, 1, 1);
            this.tableLayoutPanel17.Location = new System.Drawing.Point(18, 10);
            this.tableLayoutPanel17.Name = "tableLayoutPanel17";
            this.tableLayoutPanel17.RowCount = 3;
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel17.Size = new System.Drawing.Size(437, 100);
            this.tableLayoutPanel17.TabIndex = 9;
            // 
            // power_disableProbeLabel
            // 
            this.power_disableProbeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.power_disableProbeLabel.AutoSize = true;
            this.power_disableProbeLabel.Location = new System.Drawing.Point(35, 10);
            this.power_disableProbeLabel.Name = "power_disableProbeLabel";
            this.power_disableProbeLabel.Size = new System.Drawing.Size(77, 12);
            this.power_disableProbeLabel.TabIndex = 3;
            this.power_disableProbeLabel.Text = "禁用探头电压";
            // 
            // power_disableTelecom
            // 
            this.power_disableTelecom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.power_disableTelecom.Location = new System.Drawing.Point(167, 72);
            this.power_disableTelecom.Name = "power_disableTelecom";
            this.power_disableTelecom.Size = new System.Drawing.Size(100, 21);
            this.power_disableTelecom.TabIndex = 2;
            this.power_disableTelecom.TextChanged += new System.EventHandler(this.power_disableTelecom_TextChanged);
            // 
            // power_disableTelecomZone
            // 
            this.power_disableTelecomZone.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.power_disableTelecomZone.AutoSize = true;
            this.power_disableTelecomZone.Location = new System.Drawing.Point(317, 77);
            this.power_disableTelecomZone.Name = "power_disableTelecomZone";
            this.power_disableTelecomZone.Size = new System.Drawing.Size(89, 12);
            this.power_disableTelecomZone.TabIndex = 8;
            this.power_disableTelecomZone.Text = "(0.0 - 15.0 V)";
            // 
            // power_disableProbe
            // 
            this.power_disableProbe.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.power_disableProbe.Location = new System.Drawing.Point(167, 6);
            this.power_disableProbe.Name = "power_disableProbe";
            this.power_disableProbe.Size = new System.Drawing.Size(100, 21);
            this.power_disableProbe.TabIndex = 0;
            this.power_disableProbe.TextChanged += new System.EventHandler(this.power_disableProbe_TextChanged);
            // 
            // power_enableProbeZone
            // 
            this.power_enableProbeZone.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.power_enableProbeZone.AutoSize = true;
            this.power_enableProbeZone.Location = new System.Drawing.Point(317, 43);
            this.power_enableProbeZone.Name = "power_enableProbeZone";
            this.power_enableProbeZone.Size = new System.Drawing.Size(89, 12);
            this.power_enableProbeZone.TabIndex = 7;
            this.power_enableProbeZone.Text = "(0.0 - 10.0 V)";
            // 
            // power_disableProbeZone
            // 
            this.power_disableProbeZone.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.power_disableProbeZone.AutoSize = true;
            this.power_disableProbeZone.Location = new System.Drawing.Point(317, 10);
            this.power_disableProbeZone.Name = "power_disableProbeZone";
            this.power_disableProbeZone.Size = new System.Drawing.Size(89, 12);
            this.power_disableProbeZone.TabIndex = 6;
            this.power_disableProbeZone.Text = "(0.0 - 10.0 V)";
            // 
            // power_disableTelecomLabel
            // 
            this.power_disableTelecomLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.power_disableTelecomLabel.AutoSize = true;
            this.power_disableTelecomLabel.Location = new System.Drawing.Point(35, 77);
            this.power_disableTelecomLabel.Name = "power_disableTelecomLabel";
            this.power_disableTelecomLabel.Size = new System.Drawing.Size(77, 12);
            this.power_disableTelecomLabel.TabIndex = 5;
            this.power_disableTelecomLabel.Text = "禁用遥测电压";
            // 
            // power_enableProbeLabel
            // 
            this.power_enableProbeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.power_enableProbeLabel.AutoSize = true;
            this.power_enableProbeLabel.Location = new System.Drawing.Point(35, 43);
            this.power_enableProbeLabel.Name = "power_enableProbeLabel";
            this.power_enableProbeLabel.Size = new System.Drawing.Size(77, 12);
            this.power_enableProbeLabel.TabIndex = 4;
            this.power_enableProbeLabel.Text = "启用探头电压";
            // 
            // power_enableProbe
            // 
            this.power_enableProbe.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.power_enableProbe.Location = new System.Drawing.Point(167, 39);
            this.power_enableProbe.Name = "power_enableProbe";
            this.power_enableProbe.Size = new System.Drawing.Size(100, 21);
            this.power_enableProbe.TabIndex = 1;
            this.power_enableProbe.TextChanged += new System.EventHandler(this.power_enableProbe_TextChanged);
            // 
            // groupBox12
            // 
            this.groupBox12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox12.Controls.Add(this.tableLayoutPanel18);
            this.groupBox12.Location = new System.Drawing.Point(3, 130);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(492, 151);
            this.groupBox12.TabIndex = 2;
            this.groupBox12.TabStop = false;
            // 
            // tableLayoutPanel18
            // 
            this.tableLayoutPanel18.ColumnCount = 3;
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel18.Controls.Add(this.label40, 0, 0);
            this.tableLayoutPanel18.Controls.Add(this.power_solarChargeLogged, 2, 3);
            this.tableLayoutPanel18.Controls.Add(this.power_supply, 1, 0);
            this.tableLayoutPanel18.Controls.Add(this.power_solarCharge, 1, 3);
            this.tableLayoutPanel18.Controls.Add(this.power_solarLogged, 2, 2);
            this.tableLayoutPanel18.Controls.Add(this.label35, 0, 3);
            this.tableLayoutPanel18.Controls.Add(this.power_supplyLogged, 2, 0);
            this.tableLayoutPanel18.Controls.Add(this.power_batteryLogged, 2, 1);
            this.tableLayoutPanel18.Controls.Add(this.label33, 0, 1);
            this.tableLayoutPanel18.Controls.Add(this.power_battery, 1, 1);
            this.tableLayoutPanel18.Controls.Add(this.label34, 0, 2);
            this.tableLayoutPanel18.Controls.Add(this.power_solar, 1, 2);
            this.tableLayoutPanel18.Location = new System.Drawing.Point(18, 20);
            this.tableLayoutPanel18.Name = "tableLayoutPanel18";
            this.tableLayoutPanel18.RowCount = 4;
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel18.Size = new System.Drawing.Size(437, 125);
            this.tableLayoutPanel18.TabIndex = 25;
            // 
            // label40
            // 
            this.label40.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(34, 9);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(77, 12);
            this.label40.TabIndex = 13;
            this.label40.Text = "探头供应电压";
            // 
            // power_solarChargeLogged
            // 
            this.power_solarChargeLogged.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.power_solarChargeLogged.AutoSize = true;
            this.power_solarChargeLogged.Enabled = false;
            this.power_solarChargeLogged.Location = new System.Drawing.Point(339, 101);
            this.power_solarChargeLogged.Name = "power_solarChargeLogged";
            this.power_solarChargeLogged.Size = new System.Drawing.Size(48, 16);
            this.power_solarChargeLogged.TabIndex = 24;
            this.power_solarChargeLogged.Text = "记录";
            this.power_solarChargeLogged.UseVisualStyleBackColor = true;
            // 
            // power_supply
            // 
            this.power_supply.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.power_supply.AutoSize = true;
            this.power_supply.Location = new System.Drawing.Point(217, 9);
            this.power_supply.Name = "power_supply";
            this.power_supply.Size = new System.Drawing.Size(0, 12);
            this.power_supply.TabIndex = 17;
            // 
            // power_solarCharge
            // 
            this.power_solarCharge.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.power_solarCharge.AutoSize = true;
            this.power_solarCharge.Location = new System.Drawing.Point(217, 103);
            this.power_solarCharge.Name = "power_solarCharge";
            this.power_solarCharge.Size = new System.Drawing.Size(0, 12);
            this.power_solarCharge.TabIndex = 20;
            // 
            // power_solarLogged
            // 
            this.power_solarLogged.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.power_solarLogged.AutoSize = true;
            this.power_solarLogged.Enabled = false;
            this.power_solarLogged.Location = new System.Drawing.Point(339, 69);
            this.power_solarLogged.Name = "power_solarLogged";
            this.power_solarLogged.Size = new System.Drawing.Size(48, 16);
            this.power_solarLogged.TabIndex = 23;
            this.power_solarLogged.Text = "记录";
            this.power_solarLogged.UseVisualStyleBackColor = true;
            // 
            // label35
            // 
            this.label35.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(40, 103);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(65, 12);
            this.label35.TabIndex = 16;
            this.label35.Text = "太阳能充电";
            // 
            // power_supplyLogged
            // 
            this.power_supplyLogged.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.power_supplyLogged.AutoSize = true;
            this.power_supplyLogged.Checked = true;
            this.power_supplyLogged.CheckState = System.Windows.Forms.CheckState.Checked;
            this.power_supplyLogged.Enabled = false;
            this.power_supplyLogged.Location = new System.Drawing.Point(339, 7);
            this.power_supplyLogged.Name = "power_supplyLogged";
            this.power_supplyLogged.Size = new System.Drawing.Size(48, 16);
            this.power_supplyLogged.TabIndex = 21;
            this.power_supplyLogged.Text = "记录";
            this.power_supplyLogged.UseVisualStyleBackColor = true;
            // 
            // power_batteryLogged
            // 
            this.power_batteryLogged.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.power_batteryLogged.AutoSize = true;
            this.power_batteryLogged.Enabled = false;
            this.power_batteryLogged.Location = new System.Drawing.Point(339, 38);
            this.power_batteryLogged.Name = "power_batteryLogged";
            this.power_batteryLogged.Size = new System.Drawing.Size(48, 16);
            this.power_batteryLogged.TabIndex = 22;
            this.power_batteryLogged.Text = "记录";
            this.power_batteryLogged.UseVisualStyleBackColor = true;
            // 
            // label33
            // 
            this.label33.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(46, 40);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(53, 12);
            this.label33.TabIndex = 14;
            this.label33.Text = "电池电压";
            // 
            // power_battery
            // 
            this.power_battery.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.power_battery.AutoSize = true;
            this.power_battery.Location = new System.Drawing.Point(217, 40);
            this.power_battery.Name = "power_battery";
            this.power_battery.Size = new System.Drawing.Size(0, 12);
            this.power_battery.TabIndex = 18;
            // 
            // label34
            // 
            this.label34.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(40, 71);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(65, 12);
            this.label34.TabIndex = 15;
            this.label34.Text = "太阳能电压";
            // 
            // power_solar
            // 
            this.power_solar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.power_solar.AutoSize = true;
            this.power_solar.Location = new System.Drawing.Point(217, 71);
            this.power_solar.Name = "power_solar";
            this.power_solar.Size = new System.Drawing.Size(0, 12);
            this.power_solar.TabIndex = 19;
            // 
            // tableLayoutPanel19
            // 
            this.tableLayoutPanel19.ColumnCount = 5;
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel19.Controls.Add(this.autoDetectButton, 0, 0);
            this.tableLayoutPanel19.Controls.Add(this.readProbeButton, 1, 0);
            this.tableLayoutPanel19.Controls.Add(this.writeProbeButton, 2, 0);
            this.tableLayoutPanel19.Controls.Add(this.backupButton, 3, 0);
            this.tableLayoutPanel19.Controls.Add(this.restoreButton, 4, 0);
            this.tableLayoutPanel19.Location = new System.Drawing.Point(12, 344);
            this.tableLayoutPanel19.Name = "tableLayoutPanel19";
            this.tableLayoutPanel19.RowCount = 1;
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel19.Size = new System.Drawing.Size(546, 50);
            this.tableLayoutPanel19.TabIndex = 3;
            // 
            // autoDetectButton
            // 
            this.autoDetectButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.autoDetectButton.Location = new System.Drawing.Point(17, 6);
            this.autoDetectButton.Name = "autoDetectButton";
            this.autoDetectButton.Size = new System.Drawing.Size(75, 37);
            this.autoDetectButton.TabIndex = 0;
            this.autoDetectButton.Text = "自动侦测传感器";
            this.autoDetectButton.UseVisualStyleBackColor = true;
            this.autoDetectButton.Click += new System.EventHandler(this.autoDetectButton_Click);
            // 
            // readProbeButton
            // 
            this.readProbeButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.readProbeButton.Location = new System.Drawing.Point(126, 6);
            this.readProbeButton.Name = "readProbeButton";
            this.readProbeButton.Size = new System.Drawing.Size(75, 37);
            this.readProbeButton.TabIndex = 1;
            this.readProbeButton.Text = "读取探头信息";
            this.readProbeButton.UseVisualStyleBackColor = true;
            this.readProbeButton.Click += new System.EventHandler(this.readProbeButton_Click);
            // 
            // writeProbeButton
            // 
            this.writeProbeButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.writeProbeButton.Location = new System.Drawing.Point(235, 6);
            this.writeProbeButton.Name = "writeProbeButton";
            this.writeProbeButton.Size = new System.Drawing.Size(75, 37);
            this.writeProbeButton.TabIndex = 2;
            this.writeProbeButton.Text = "写入探头信息";
            this.writeProbeButton.UseVisualStyleBackColor = true;
            this.writeProbeButton.Click += new System.EventHandler(this.writeProbeButton_Click);
            // 
            // backupButton
            // 
            this.backupButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.backupButton.Location = new System.Drawing.Point(344, 6);
            this.backupButton.Name = "backupButton";
            this.backupButton.Size = new System.Drawing.Size(75, 37);
            this.backupButton.TabIndex = 3;
            this.backupButton.Text = "备份配置";
            this.backupButton.UseVisualStyleBackColor = true;
            this.backupButton.Click += new System.EventHandler(this.backupButton_Click);
            // 
            // restoreButton
            // 
            this.restoreButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.restoreButton.Location = new System.Drawing.Point(453, 6);
            this.restoreButton.Name = "restoreButton";
            this.restoreButton.Size = new System.Drawing.Size(75, 37);
            this.restoreButton.TabIndex = 4;
            this.restoreButton.Text = "恢复配置";
            this.restoreButton.UseVisualStyleBackColor = true;
            this.restoreButton.Click += new System.EventHandler(this.restoreButton_Click);
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 425);
            this.Controls.Add(this.tableLayoutPanel19);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainFrame";
            this.Text = "探头配置工具";
            this.Activated += new System.EventHandler(this.MainFrame_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFrame_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.configurationTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cfgDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensorViewModelBindingSource)).EndInit();
            this.sensorTestTabPage.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TestDGV)).EndInit();
            this.clockTabPage.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.clock_samplingIntervalGroupBox.ResumeLayout(false);
            this.clock_samplingIntervalGroupBox.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.loggerTabPage.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logger_connectOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logger_respOut)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logger_sampleCount)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.networkTabPage.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel13.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            this.modemTabPage.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.tableLayoutPanel14.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.tableLayoutPanel15.ResumeLayout(false);
            this.tableLayoutPanel15.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.tableLayoutPanel16.ResumeLayout(false);
            this.tableLayoutPanel16.PerformLayout();
            this.powerTabPage.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.tableLayoutPanel17.ResumeLayout(false);
            this.tableLayoutPanel17.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.tableLayoutPanel18.ResumeLayout(false);
            this.tableLayoutPanel18.PerformLayout();
            this.tableLayoutPanel19.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 载入配置文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 备份配置文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 连接串口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 探头信息ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage configurationTabPage;
        private System.Windows.Forms.TabPage sensorTestTabPage;
        private System.Windows.Forms.TabPage clockTabPage;
        private System.Windows.Forms.TabPage loggerTabPage;
        private System.Windows.Forms.TabPage networkTabPage;
        private System.Windows.Forms.TabPage modemTabPage;
        private System.Windows.Forms.TabPage powerTabPage;
        private System.Windows.Forms.ToolStripStatusLabel main_status;
        private System.Windows.Forms.DataGridView cfgDGV;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox clock_samplingIntervalGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox clock_samplingInterval;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button timeSynButton;
        private System.Windows.Forms.DateTimePicker clock_dateTimePicker;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button logger_delReading;
        private System.Windows.Forms.Label logger_sampleOriginLabel;
        private System.Windows.Forms.Label logger_IDLabel;
        private System.Windows.Forms.DateTimePicker logger_sampleOrigin;
        private System.Windows.Forms.TextBox logger_ID;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label logger_dialInUpLabel;
        private System.Windows.Forms.Label logger_sampleCountLabel;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label logger_parityLabel;
        private System.Windows.Forms.Label logger_baudRateLabel;
        private System.Windows.Forms.Label logger_respOutLabel;
        private System.Windows.Forms.Label logger_connectOutLabel;
        private System.Windows.Forms.Label logger_URLLabel;
        private System.Windows.Forms.ComboBox logger_parity;
        private System.Windows.Forms.ComboBox logger_baudRate;
        private System.Windows.Forms.TextBox logger_destURL;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label network_passwordLabel;
        private System.Windows.Forms.Label network_nameLabel;
        private System.Windows.Forms.TextBox network_pwd;
        private System.Windows.Forms.TextBox network_userName;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label network_dialInEnableLabel;
        private System.Windows.Forms.Label network_dialInEnableRespLabel;
        private System.Windows.Forms.Label network_dialInDisableLabel;
        private System.Windows.Forms.Label network_dialInDisableRespLabel;
        private System.Windows.Forms.Label network_initLabel;
        private System.Windows.Forms.Label network_initRespLabel;
        private System.Windows.Forms.Label network_connectLabel;
        private System.Windows.Forms.Label network_connectRespLabel;
        private System.Windows.Forms.Label network_disconnectLabel;
        private System.Windows.Forms.Label network_disconnectRespLabel;
        private System.Windows.Forms.TextBox network_dialInEnable;
        private System.Windows.Forms.TextBox network_dialInEnableResp;
        private System.Windows.Forms.TextBox network_dialInDisable;
        private System.Windows.Forms.TextBox network_dialInDisableResp;
        private System.Windows.Forms.TextBox network_init;
        private System.Windows.Forms.TextBox network_connect;
        private System.Windows.Forms.TextBox network_connectResp;
        private System.Windows.Forms.TextBox network_disconnect;
        private System.Windows.Forms.TextBox network_disconnectResp;
        private System.Windows.Forms.TextBox network_initResp;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button modem_send;
        private System.Windows.Forms.ComboBox modem_atCmdText;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button modem_openSession;
        private System.Windows.Forms.TextBox modem_textbox;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label modem_status;
        private System.Windows.Forms.ProgressBar modem_progressBar;
        private System.Windows.Forms.Button modem_test;
        private System.Windows.Forms.Button modem_upload;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label power_disableTelecomZone;
        private System.Windows.Forms.Label power_enableProbeZone;
        private System.Windows.Forms.Label power_disableProbeZone;
        private System.Windows.Forms.Label power_disableTelecomLabel;
        private System.Windows.Forms.Label power_enableProbeLabel;
        private System.Windows.Forms.Label power_disableProbeLabel;
        private System.Windows.Forms.TextBox power_disableTelecom;
        private System.Windows.Forms.TextBox power_enableProbe;
        private System.Windows.Forms.TextBox power_disableProbe;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.CheckBox power_solarChargeLogged;
        private System.Windows.Forms.CheckBox power_solarLogged;
        private System.Windows.Forms.CheckBox power_batteryLogged;
        private System.Windows.Forms.CheckBox power_supplyLogged;
        private System.Windows.Forms.Label power_solarCharge;
        private System.Windows.Forms.Label power_solar;
        private System.Windows.Forms.Label power_battery;
        private System.Windows.Forms.Label power_supply;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.DateTimePicker logger_dialInUp;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel16;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel17;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel18;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel19;
        private System.Windows.Forms.Button autoDetectButton;
        private System.Windows.Forms.Button readProbeButton;
        private System.Windows.Forms.Button writeProbeButton;
        private System.Windows.Forms.Button backupButton;
        private System.Windows.Forms.Button restoreButton;
        private System.Windows.Forms.Button logger_urlEdit;
        private System.Windows.Forms.TextBox logger_lastResp;
        private System.Windows.Forms.BindingSource sensorViewModelBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button queryAllButton;
        private System.Windows.Forms.Button querySelectedButton;
        private System.Windows.Forms.DataGridView TestDGV;
        private System.Windows.Forms.Button stopQueryingButton;
        private System.Windows.Forms.Label clock_samplingIntervalLabel;
        private System.Windows.Forms.NumericUpDown logger_connectOut;
        private System.Windows.Forms.NumericUpDown logger_respOut;
        private System.Windows.Forms.NumericUpDown logger_sampleCount;
        private System.Windows.Forms.Label clock_dateTimeLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn selAddr;
        private System.Windows.Forms.DataGridViewTextBoxColumn depthDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn rawCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn celibrateValueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isSelected4Test;
        private System.Windows.Forms.DataGridViewTextBoxColumn addr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Depth;
        private System.Windows.Forms.DataGridViewTextBoxColumn highAir;
        private System.Windows.Forms.DataGridViewButtonColumn RefreshAir;
        private System.Windows.Forms.DataGridViewTextBoxColumn lowWater;
        private System.Windows.Forms.DataGridViewButtonColumn RefreshWater;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoefStr;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isSelected;
        private System.Windows.Forms.Label sampleCountLabel;
    }
}

