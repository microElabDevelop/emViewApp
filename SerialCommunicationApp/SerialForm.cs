using Microsoft.Win32;
using SerialCommunicationApp.UserControls;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace SerialCommunicationApp
{
    public partial class SerialForm : Form
    {
        private string configFileName = ConfigurationManager.AppSettings["config_file_name"];
        private string dataFileName = ConfigurationManager.AppSettings["data_file_name"];
        private static string rootPath;
        private string[] availablePorts;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string appConfigFilePath, serviceBatchFilePath, serviceConfigFilePath, _fwDateCommandResponse, _tndCommandResponse, _getValuesResponse, _getCellResponse;

        public SerialForm()
        {
            InitializeComponent();
            //rootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SerialReaderServices");
        }

        private void SerailFormLoad(object sender, EventArgs e)
        {
            RegisterTabsEvents();
            log.Info(string.Format("Main application loaded"));
            string keyName = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
            string valueName = "Serial Communication Application";
            if (Registry.GetValue(keyName, valueName, null) == null)
            {
                //code if key Not Exist
                RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                reg.SetValue(valueName, Application.ExecutablePath.ToString());
            }
            //DeleteOldFile(Path.Combine(rootPath, "Logs"));
            com1ServiceMenuStrip.BackColor = Color.FromArgb(73, 216, 230);
            availablePorts = SerialPort.GetPortNames();
            LoadServiceData("COM1");
        }

        private void RegisterTabsEvents()
        {
            com1ServiceMenuStrip.Click += new EventHandler(COMTabClick);
            com2ServiceMenuStrip.Click += new EventHandler(COMTabClick);
            com3ServiceMenuStrip.Click += new EventHandler(COMTabClick);
            com4ServiceMenuStrip.Click += new EventHandler(COMTabClick);
            com5ServiceMenuStrip.Click += new EventHandler(COMTabClick);
        }

        public void LoadServiceData(string serviceName = null)
        {
            MenuUserControl menuUserControl = new MenuUserControl();
            string[] lines = new string[3];
            menuUserControl.SelectedTab = serviceName;

            menuUserControl.CheckForConfigFile();

            rootPath = AppDomain.CurrentDomain.BaseDirectory;
            string serviceFolder = string.Empty;
            serviceFolder = "SerialReaderService\\emViewService" + serviceName;
            string interimConfigFilePath = string.Empty;
            interimConfigFilePath = Path.Combine(rootPath, serviceFolder);
            serviceConfigFilePath = Path.Combine(interimConfigFilePath, configFileName);
            lines = File.ReadAllLines(serviceConfigFilePath);
            this.mainPanel.Controls.Clear();
            menuUserControl.ParentForm = this;
            menuUserControl.lblData.Text = $"COM Port: {lines[0]}   Baud Rate: {lines[1]}   Refresh Time: {(Convert.ToInt32(lines[2]) / 60000)}m ";
            menuUserControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            menuUserControl.cmbAvailablePorts.Text = lines[0];
            menuUserControl.cmbAvailableBaudRates.Text = lines[1];
            menuUserControl.cmbSites.Text = lines[3];
            menuUserControl.cmbRefreshTime.Text = (Convert.ToInt32(lines[2]) / 60000).ToString();
            this.mainPanel.Controls.Add(menuUserControl);
        }

        public static void DeleteOldFile(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
            string[] files = Directory.GetFiles(directoryPath);
            string destinationDirectory = Path.Combine(rootPath, "BackupLogs");
            if (!Directory.Exists(destinationDirectory))
                Directory.CreateDirectory(destinationDirectory);
            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                if (fi.LastAccessTime < DateTime.Now.AddDays(-2))
                {
                    File.Copy(file, Path.Combine(destinationDirectory, Path.GetFileName(file)));
                }
            }
        }

        private void COMTabClick(object sender, EventArgs e)
        {
            com1ServiceMenuStrip.BackColor = Color.WhiteSmoke;
            com2ServiceMenuStrip.BackColor = Color.WhiteSmoke;
            com3ServiceMenuStrip.BackColor = Color.WhiteSmoke;
            com4ServiceMenuStrip.BackColor = Color.WhiteSmoke;
            com5ServiceMenuStrip.BackColor = Color.WhiteSmoke;
            ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
            toolStripMenuItem.BackColor = Color.FromArgb(73, 216, 230);
            string b = toolStripMenuItem.Text.ToString().Split(' ')[0];
            b = b.Replace("Port", "COM");
            LoadServiceData(b);
        }
    }
}