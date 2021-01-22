namespace SerialCommunicationApp.UserControls
{
    partial class MenuUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnUpdateConfiguration = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefreshService = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbRefreshTime = new System.Windows.Forms.ComboBox();
            this.cmbSites = new System.Windows.Forms.ComboBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cmbAvailableBaudRates = new System.Windows.Forms.ComboBox();
            this.portsLabel = new DevExpress.XtraEditors.LabelControl();
            this.cmbAvailablePorts = new System.Windows.Forms.ComboBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblData = new DevExpress.XtraEditors.LabelControl();
            this.lblUpdateSerialConfigurations = new DevExpress.XtraEditors.LabelControl();
            this.portResponseLbl = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpdateConfiguration
            // 
            this.btnUpdateConfiguration.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUpdateConfiguration.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnUpdateConfiguration.Appearance.Options.UseFont = true;
            this.btnUpdateConfiguration.Location = new System.Drawing.Point(240, 231);
            this.btnUpdateConfiguration.Name = "btnUpdateConfiguration";
            this.btnUpdateConfiguration.Size = new System.Drawing.Size(134, 44);
            this.btnUpdateConfiguration.TabIndex = 2;
            this.btnUpdateConfiguration.Text = "Update Configuration";
            this.btnUpdateConfiguration.Click += new System.EventHandler(this.BtnUpdateConfigurationClick);
            // 
            // btnRefreshService
            // 
            this.btnRefreshService.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRefreshService.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnRefreshService.Appearance.Options.UseFont = true;
            this.btnRefreshService.Location = new System.Drawing.Point(82, 231);
            this.btnRefreshService.Name = "btnRefreshService";
            this.btnRefreshService.Size = new System.Drawing.Size(134, 44);
            this.btnRefreshService.TabIndex = 3;
            this.btnRefreshService.Text = "Refresh";
            this.btnRefreshService.Click += new System.EventHandler(this.BtnRefreshServiceClick);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupBox1);
            this.panelControl1.Controls.Add(this.lblData);
            this.panelControl1.Controls.Add(this.lblUpdateSerialConfigurations);
            this.panelControl1.Controls.Add(this.portResponseLbl);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(584, 401);
            this.panelControl1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.cmbRefreshTime);
            this.groupBox1.Controls.Add(this.cmbSites);
            this.groupBox1.Controls.Add(this.labelControl3);
            this.groupBox1.Controls.Add(this.labelControl2);
            this.groupBox1.Controls.Add(this.btnUpdateConfiguration);
            this.groupBox1.Controls.Add(this.btnRefreshService);
            this.groupBox1.Controls.Add(this.cmbAvailableBaudRates);
            this.groupBox1.Controls.Add(this.portsLabel);
            this.groupBox1.Controls.Add(this.cmbAvailablePorts);
            this.groupBox1.Controls.Add(this.labelControl1);
            this.groupBox1.Location = new System.Drawing.Point(50, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(475, 316);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Settings";
            // 
            // cmbRefreshTime
            // 
            this.cmbRefreshTime.FormattingEnabled = true;
            this.cmbRefreshTime.Items.AddRange(new object[] {
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cmbRefreshTime.Location = new System.Drawing.Point(83, 198);
            this.cmbRefreshTime.Name = "cmbRefreshTime";
            this.cmbRefreshTime.Size = new System.Drawing.Size(291, 21);
            this.cmbRefreshTime.TabIndex = 13;
            // 
            // cmbSites
            // 
            this.cmbSites.FormattingEnabled = true;
            this.cmbSites.Location = new System.Drawing.Point(83, 147);
            this.cmbSites.Name = "cmbSites";
            this.cmbSites.Size = new System.Drawing.Size(291, 21);
            this.cmbSites.TabIndex = 13;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(83, 129);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(86, 13);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "Available Sites:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(82, 179);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(78, 13);
            this.labelControl2.TabIndex = 12;
            this.labelControl2.Text = "Refresh Time:";
            // 
            // cmbAvailableBaudRates
            // 
            this.cmbAvailableBaudRates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAvailableBaudRates.FormattingEnabled = true;
            this.cmbAvailableBaudRates.Items.AddRange(new object[] {
            "300",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "74880",
            "115200",
            "230400",
            "250000",
            "500000"});
            this.cmbAvailableBaudRates.Location = new System.Drawing.Point(82, 100);
            this.cmbAvailableBaudRates.Name = "cmbAvailableBaudRates";
            this.cmbAvailableBaudRates.Size = new System.Drawing.Size(291, 21);
            this.cmbAvailableBaudRates.TabIndex = 10;
            // 
            // portsLabel
            // 
            this.portsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.portsLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.portsLabel.Appearance.Options.UseFont = true;
            this.portsLabel.Location = new System.Drawing.Point(82, 33);
            this.portsLabel.Name = "portsLabel";
            this.portsLabel.Size = new System.Drawing.Size(88, 13);
            this.portsLabel.TabIndex = 7;
            this.portsLabel.Text = "Available Ports:";
            // 
            // cmbAvailablePorts
            // 
            this.cmbAvailablePorts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAvailablePorts.Font = new System.Drawing.Font("Tahoma", 8F);
            this.cmbAvailablePorts.FormattingEnabled = true;
            this.cmbAvailablePorts.IntegralHeight = false;
            this.cmbAvailablePorts.ItemHeight = 13;
            this.cmbAvailablePorts.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15",
            "COM16",
            "COM17",
            "COM18",
            "COM19",
            "COM20"});
            this.cmbAvailablePorts.Location = new System.Drawing.Point(82, 52);
            this.cmbAvailablePorts.MaxDropDownItems = 10;
            this.cmbAvailablePorts.Name = "cmbAvailablePorts";
            this.cmbAvailablePorts.Size = new System.Drawing.Size(292, 21);
            this.cmbAvailablePorts.TabIndex = 8;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(82, 81);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(122, 13);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Available Baud Rates:";
            // 
            // lblData
            // 
            this.lblData.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblData.Appearance.Options.UseFont = true;
            this.lblData.Appearance.Options.UseTextOptions = true;
            this.lblData.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblData.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblData.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblData.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblData.Location = new System.Drawing.Point(2, 39);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(580, 35);
            this.lblData.TabIndex = 11;
            this.lblData.Text = "Current Configuration Settings";
            // 
            // lblUpdateSerialConfigurations
            // 
            this.lblUpdateSerialConfigurations.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lblUpdateSerialConfigurations.Appearance.Options.UseFont = true;
            this.lblUpdateSerialConfigurations.Appearance.Options.UseTextOptions = true;
            this.lblUpdateSerialConfigurations.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblUpdateSerialConfigurations.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblUpdateSerialConfigurations.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUpdateSerialConfigurations.Location = new System.Drawing.Point(2, 2);
            this.lblUpdateSerialConfigurations.Name = "lblUpdateSerialConfigurations";
            this.lblUpdateSerialConfigurations.Size = new System.Drawing.Size(580, 37);
            this.lblUpdateSerialConfigurations.TabIndex = 5;
            this.lblUpdateSerialConfigurations.Text = "Serial Configurations";
            // 
            // portResponseLbl
            // 
            this.portResponseLbl.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.portResponseLbl.Appearance.Options.UseFont = true;
            this.portResponseLbl.Appearance.Options.UseTextOptions = true;
            this.portResponseLbl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.portResponseLbl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.portResponseLbl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.portResponseLbl.Location = new System.Drawing.Point(2, 364);
            this.portResponseLbl.Name = "portResponseLbl";
            this.portResponseLbl.Size = new System.Drawing.Size(580, 35);
            this.portResponseLbl.TabIndex = 4;
            // 
            // MenuUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "MenuUserControl";
            this.Size = new System.Drawing.Size(584, 401);
            this.Load += new System.EventHandler(this.MenuUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnUpdateConfiguration;
        private DevExpress.XtraEditors.SimpleButton btnRefreshService;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl portResponseLbl;
        public DevExpress.XtraEditors.LabelControl lblUpdateSerialConfigurations;
        private DevExpress.XtraEditors.LabelControl portsLabel;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.LabelControl lblData;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public System.Windows.Forms.ComboBox cmbAvailablePorts;
        public System.Windows.Forms.ComboBox cmbAvailableBaudRates;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public System.Windows.Forms.ComboBox cmbSites;
        public System.Windows.Forms.ComboBox cmbRefreshTime;
    }
}
