namespace SerialCommunicationApp
{
    partial class SerialForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SerialForm));
            this.mainPanel = new DevExpress.XtraEditors.PanelControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.com1ServiceMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.com2ServiceMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.com3ServiceMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.com4ServiceMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.com5ServiceMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.mainPanel)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.AutoSize = true;
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 24);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1270, 455);
            this.mainPanel.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.com1ServiceMenuStrip,
            this.com2ServiceMenuStrip,
            this.com3ServiceMenuStrip,
            this.com4ServiceMenuStrip,
            this.com5ServiceMenuStrip});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1270, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // com1ServiceMenuStrip
            // 
            this.com1ServiceMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.com1ServiceMenuStrip.Checked = true;
            this.com1ServiceMenuStrip.CheckState = System.Windows.Forms.CheckState.Checked;
            this.com1ServiceMenuStrip.Image = global::SerialCommunicationApp.Properties.Resources.com_1;
            this.com1ServiceMenuStrip.Name = "com1ServiceMenuStrip";
            this.com1ServiceMenuStrip.Size = new System.Drawing.Size(111, 20);
            this.com1ServiceMenuStrip.Text = "Port1 - Service";
            this.com1ServiceMenuStrip.Click += new System.EventHandler(this.COMTabClick);
            // 
            // com2ServiceMenuStrip
            // 
            this.com2ServiceMenuStrip.Image = global::SerialCommunicationApp.Properties.Resources.com_2;
            this.com2ServiceMenuStrip.Name = "com2ServiceMenuStrip";
            this.com2ServiceMenuStrip.Size = new System.Drawing.Size(111, 20);
            this.com2ServiceMenuStrip.Text = "Port2 - Service";
            // 
            // com3ServiceMenuStrip
            // 
            this.com3ServiceMenuStrip.Image = global::SerialCommunicationApp.Properties.Resources.com_3;
            this.com3ServiceMenuStrip.Name = "com3ServiceMenuStrip";
            this.com3ServiceMenuStrip.Size = new System.Drawing.Size(111, 20);
            this.com3ServiceMenuStrip.Text = "Port3 - Service";
            // 
            // com4ServiceMenuStrip
            // 
            this.com4ServiceMenuStrip.Image = global::SerialCommunicationApp.Properties.Resources.com_4;
            this.com4ServiceMenuStrip.Name = "com4ServiceMenuStrip";
            this.com4ServiceMenuStrip.Size = new System.Drawing.Size(111, 20);
            this.com4ServiceMenuStrip.Text = "Port4 - Service";
            // 
            // com5ServiceMenuStrip
            // 
            this.com5ServiceMenuStrip.Image = global::SerialCommunicationApp.Properties.Resources.com_5;
            this.com5ServiceMenuStrip.Name = "com5ServiceMenuStrip";
            this.com5ServiceMenuStrip.Size = new System.Drawing.Size(111, 20);
            this.com5ServiceMenuStrip.Text = "Port5 - Service";
            // 
            // SerialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 479);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SerialForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "emView";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SerailFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.mainPanel)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl mainPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem com1ServiceMenuStrip;
        public System.Windows.Forms.ToolStripMenuItem com2ServiceMenuStrip;
        public System.Windows.Forms.ToolStripMenuItem com3ServiceMenuStrip;
        public System.Windows.Forms.ToolStripMenuItem com4ServiceMenuStrip;
        public System.Windows.Forms.ToolStripMenuItem com5ServiceMenuStrip;
    }
}

