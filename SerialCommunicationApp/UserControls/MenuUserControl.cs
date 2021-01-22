using DevExpress.XtraEditors;
using log4net;
using SerialCommunicationApp.Models;
using SerialCommunicationApp.UTILS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace SerialCommunicationApp.UserControls
{
    public partial class MenuUserControl : XtraUserControl
    {
        private SerialPort serialPort1;
        private string _serialPortReply = string.Empty;
        private string _reply;
        private static readonly log4net.ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string configFileName = ConfigurationManager.AppSettings["config_file_name"];
        private readonly string restartServiceBatchFileName = ConfigurationManager.AppSettings["restart_service_batch_file_name"];
        private readonly string startServiceBatchFileName = ConfigurationManager.AppSettings["start_service_batch_file_name"];
        private string stopServiceBatchFileName = ConfigurationManager.AppSettings["stop_service_batch_file_name"];
        private string installServiceBatchFileName = ConfigurationManager.AppSettings["install_service_batch_file_name"];
        private string dataFileName = ConfigurationManager.AppSettings["data_file_name"];
        private string[] availablePorts, lines;
        private string[] availableSites;
        private string appConfigFilePath, sites, rootPath, serviceFolderPath, serviceConfigFilePath, _fwDateCommandResponse, _tndCommandResponse, _getValuesResponse, _getCellResponse;

        public MenuUserControl()
        {
            InitializeComponent();
            availablePorts = SerialPort.GetPortNames();
            serialPort1 = new SerialPort();
            log.Info("Menu user control has started!");
        }

        public SerialForm ParentForm { get; set; }

        private void MenuUserControl_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            groupBox1.Left = (this.ClientSize.Width - groupBox1.Width) / 2;
            groupBox1.Top = (this.ClientSize.Height - groupBox1.Height) / 2;
            sites = ConfigurationManager.AppSettings["available_sites"];
            availableSites = sites.Split(',');
            cmbSites.Items.AddRange(availableSites);
        }

        private void BtnRefreshServiceClick(object sender, EventArgs e)
        {
            try
            {
                lines = File.ReadAllLines(serviceConfigFilePath);
                this.portResponseLbl.Text = "";
                if (!Array.Exists(availablePorts, availablePort => availablePort == cmbAvailablePorts.Text))
                {
                    XtraMessageBox.Show($"The '{ cmbAvailablePorts.Text }' does not exist. Please check\\change available ports.", cmbAvailablePorts.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cmbAvailablePorts.SelectedIndex >= 0)
                {
                    //Port accessiblity check start
                    if (serialPort1.IsOpen)
                        serialPort1.Close();
                    serialPort1.PortName = cmbAvailablePorts.Text;
                    serialPort1.Open();
                    serialPort1.Close();
                    //Port accessiblity check end

                    CheckForConfigFile();
                    lines = File.ReadAllLines(serviceConfigFilePath);
                    if (lines.Length >= 4 &&
                        (lines[0] != cmbAvailablePorts.Text ||
                        lines[1] != cmbAvailableBaudRates.Text ||
                        (Convert.ToInt32(lines[2]) / 60000).ToString() != cmbRefreshTime.Text ||
                        lines[3] != cmbSites.Text))
                    {
                        XtraMessageBox.Show($"Selected data is different from {SelectedTab} Service configuration file!{Environment.NewLine} You need to update configuration file before you refresh the service.", "emView Service", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                        InstallAndStartService();
                }
                else
                {
                    XtraMessageBox.Show("Please select any port to update/start the service.", "Port", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                log.Error($"### Reading Error {ex}");
                this.portResponseLbl.Text = ex.Message;
                serialPort1.Close();
            }
        }

        private void InstallAndStartService()
        {
            AppService.RunServiceBatchFile(installServiceBatchFileName, SelectedTab);
            string b = SelectedTab;
            b = b.Replace("COM", "Port");
            XtraMessageBox.Show($"{b} Service has been started successfully!", "emView Service", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void CheckForConfigFile()
        {
            PrepareFilesPath(SelectedTab);
            serviceConfigFilePath = Path.Combine(serviceFolderPath, "ConfigurationFile.txt");
            if (!Directory.Exists(serviceFolderPath))
            {
                Directory.CreateDirectory(serviceFolderPath);
            }
            if (!File.Exists(serviceConfigFilePath))
            {
                File.Create(serviceConfigFilePath).Close();
            }
        }

        public void StartReadingFromDevice()
        {
            try
            {
                List<string> getValuesAndGetCells = new List<string>();
                bool isGetValues = false;
                bool isGetCell = false;
                if (serialPort1.IsOpen)
                {
                    log.Info($"COM port is open and starting reading data from {serialPort1.PortName}");

                    #region GET_VALUES# and GET_CELL#

                    int portResponse = 3;
                    while (portResponse > 0)
                    {
                        try
                        {
                            Thread.Sleep(4000);
                            serialPort1.Write("CHECK#");
                            Thread.Sleep(4000);
                            _getValuesResponse = serialPort1.ReadTo("!");
                            if (_getValuesResponse.Contains("OKAY"))
                            {
                                DataLoggerControl.Write($"CHECK Command is successfull on port {serialPort1.PortName}");
                                DataLoggerControl.Write($"CHECK Command response is: {_getValuesResponse}");

                                DataLoggerControl.Write($"Command sent: GET_VALUES#");
                                Thread.Sleep(4000);
                                serialPort1.Write("GET_VALUES#");
                                Thread.Sleep(4000);
                                _getValuesResponse = serialPort1.ReadTo("!");
                                Thread.Sleep(2000);
                                if (_getValuesResponse.Contains("ERROR") || _getValuesResponse == "")
                                {
                                    DataLoggerControl.Write($"GET_VALUES# ERROR response: {_getValuesResponse}{Environment.NewLine}");
                                }
                                else
                                {
                                    getValuesAndGetCells.Add(_getValuesResponse);
                                    isGetValues = true;
                                    DataLoggerControl.Write($"Command response: {_getValuesResponse}{Environment.NewLine}");
                                }

                                Thread.Sleep(4000);
                                serialPort1.Write("GET_CELL#");
                                Thread.Sleep(4000);
                                _getCellResponse = serialPort1.ReadTo("!");
                                Thread.Sleep(2000);
                                if (_getCellResponse.Contains("ERROR") || _getCellResponse == "")
                                {
                                    DataLoggerControl.Write($"GET_CELL# ERROR response: {_getCellResponse}{Environment.NewLine}");
                                }
                                else
                                {
                                    getValuesAndGetCells.Add(_getCellResponse);
                                    isGetCell = true;
                                    DataLoggerControl.Write($"Command response: {_getCellResponse}{Environment.NewLine}");
                                }

                                portResponse = 0;
                            }
                            else if (_getValuesResponse.Contains("ERROR"))
                            {
                                DataLoggerControl.Write($"{_getValuesResponse}{Environment.NewLine}");
                                portResponse--;
                            }
                        }
                        catch (Exception ex)
                        {
                            log.Error($"{ex}");
                            DataLoggerControl.Write($"GET_VALUES# Command: {ex.Message}");
                            _getValuesResponse = string.Empty;
                            portResponse--;
                        }
                    }

                    if (isGetCell && isGetValues)
                    {
                        foreach (var item in getValuesAndGetCells)
                        {
                            AppService.RunTestModulePostAsync(item, _serialPortReply);
                        }
                    }

                    #endregion GET_VALUES# and GET_CELL#

                    #region GET_FW#

                    portResponse = 3;
                    while (portResponse > 0)
                    {
                        try
                        {
                            Thread.Sleep(4000);
                            serialPort1.Write("CHECK#");
                            Thread.Sleep(4000);
                            _reply = serialPort1.ReadTo("!");
                            if (_reply.Contains("OKAY"))
                            {
                                DataLoggerControl.Write($"CHECK Command is successfull on port {serialPort1.PortName}");
                                DataLoggerControl.Write($"CHECK Command response is: {_reply}");

                                DataLoggerControl.Write($"Command sent: GET_FW#");
                                Thread.Sleep(4000);
                                serialPort1.Write("GET_FW#");
                                Thread.Sleep(4000);
                                _reply = serialPort1.ReadTo("!");
                                Thread.Sleep(2000);
                                if (_reply.Contains("ERROR") || _reply == "")
                                {
                                    DataLoggerControl.Write($"GET_FW# ERROR response: {_reply}{Environment.NewLine}");
                                }
                                else
                                {
                                    DataLoggerControl.Write($"Command response: {_reply}{Environment.NewLine}");
                                }
                                portResponse = 0;
                            }
                            else if (_reply.Contains("ERROR"))
                            {
                                DataLoggerControl.Write($"CHECK# {_reply}{Environment.NewLine}");
                                portResponse--;
                            }
                        }
                        catch (Exception ex)
                        {
                            log.Error($"{ex}");
                            DataLoggerControl.Write($"GET_FW# Command: {ex.Message}");
                            _reply = string.Empty;
                            portResponse--;
                        }
                    }

                    #endregion GET_FW#
                }
                else
                {
                    log.Warn($"COM Port {serialPort1.PortName} is not opened!");
                }
                _reply = string.Empty;
            }
            catch (Exception ex)
            {
                log.Error($"### Initialising Reading Error {ex}");
                log.Warn($"{ex.Message}. Service is re-started.");
            }
        }

        /// <summary>
        /// Creating module at the start of the service
        /// </summary>
        private bool CreateModule()
        {
            #region GET_TND# and GET_FW_DATE#

            bool isFW_DATE = false;
            bool isTND = false;
            bool isTestModuleCreated = false;

            int portResponse = 3;
            while (portResponse > 0)
            {
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        Thread.Sleep(4000);
                        serialPort1.Write("CHECK#");
                        Thread.Sleep(4000);
                        _tndCommandResponse = serialPort1.ReadTo("!");
                        if (_tndCommandResponse.Contains("OKAY"))
                        {
                            DataLoggerControl.Write($"CHECK Command is successfull on port {serialPort1.PortName}");
                            DataLoggerControl.Write($"CHECK Command response is: {_tndCommandResponse}");

                            DataLoggerControl.Write($"Command sent: GET_TND#");
                            Thread.Sleep(4000);
                            serialPort1.Write("GET_TND#");
                            Thread.Sleep(4000);
                            _tndCommandResponse = serialPort1.ReadTo("!");
                            Thread.Sleep(2000);
                            if (_tndCommandResponse.Contains("ERROR") || _tndCommandResponse == "")
                            {
                                DataLoggerControl.Write($"GET_TND# ERROR response: {_tndCommandResponse}{Environment.NewLine}");
                            }
                            else
                            {
                                isTND = true;
                                DataLoggerControl.Write($"Command response: {_tndCommandResponse}{Environment.NewLine}");
                            }

                            DataLoggerControl.Write($"Command sent: GET_FW_DATE#");
                            Thread.Sleep(4000);
                            serialPort1.Write("GET_FW_DATE#");
                            Thread.Sleep(4000);
                            _fwDateCommandResponse = serialPort1.ReadTo("!");
                            Thread.Sleep(2000);
                            if (_fwDateCommandResponse.Contains("ERROR") || _fwDateCommandResponse == "")
                            {
                                DataLoggerControl.Write($"GET_FW_DATE# ERROR response: {_fwDateCommandResponse}{Environment.NewLine}");
                            }
                            else
                            {
                                isFW_DATE = true;
                                isTestModuleCreated = true;
                                DataLoggerControl.Write($"Command response: {_fwDateCommandResponse}{Environment.NewLine}");
                            }
                            portResponse = 0;
                        }
                        else if (_tndCommandResponse.Contains("ERROR"))
                        {
                            DataLoggerControl.Write($"CHECK# {_tndCommandResponse}{Environment.NewLine}");
                            portResponse--;
                        }
                    }
                    else
                    {
                        log.Warn($"Serial port {serialPort1.PortName} is not opened!");
                    }

                    //Module creation at the start of the service
                    if (isFW_DATE && isTND)
                    {
                        ModuleObject moduleObject = PrepareModuleObject(_fwDateCommandResponse, _tndCommandResponse);
                        AppService.RunModulePostAsync(moduleObject);
                        isTestModuleCreated = true;
                    }
                }
                catch (Exception ex)
                {
                    log.Error($"{ex}");
                    DataLoggerControl.Write($"GET_TND# Command: {ex.Message}");
                    _tndCommandResponse = string.Empty;
                    _fwDateCommandResponse = string.Empty;
                    portResponse--;
                }
            }

            return isTestModuleCreated;

            #endregion GET_TND# and GET_FW_DATE#
        }

        private ModuleObject PrepareModuleObject(string _fwDateCommandResponse, string _tndCommandResponse)
        {
            ModuleObject moduleObject = new ModuleObject();
            moduleObject.serialNumber = _serialPortReply;
            moduleObject.name = _serialPortReply;
            moduleObject.sitesName = _serialPortReply;
            moduleObject.geT_FW_DATE = _fwDateCommandResponse;
            moduleObject.geT_TND = _tndCommandResponse;
            return moduleObject;
        }

        private void BtnUpdateConfigurationClick(object sender, EventArgs e)
        {
            log.Info(string.Format("Update button is clicked"));
            string selectedComPort = cmbAvailablePorts.Text;
            UpdateConfigurationFile(selectedComPort);
        }

        private bool UpdateConfigurationFile(string selectedComPort)
        {
            bool isFileUpdated = false;
            if (cmbAvailablePorts.SelectedIndex >= 0)
                CheckForConfigFile();
            else
            {
                XtraMessageBox.Show("Please select any port to update/start the service.", "Port", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (XtraMessageBox.Show($"You need to stop the service before updating configurations file.{Environment.NewLine}" +
                $"Do you want to stop the service?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
            {
                AppService.RunServiceBatchFile(stopServiceBatchFileName, SelectedTab);
                ReplaceConfigSettingsInFile(selectedComPort, cmbAvailableBaudRates.Text, cmbRefreshTime.Text, cmbSites.Text);
                isFileUpdated = true;
            }
            else
                isFileUpdated = false;

            return isFileUpdated;
        }

        private void PrepareFilesPath(string selectedComPort)
        {
            rootPath = AppDomain.CurrentDomain.BaseDirectory;
            string serviceFolder = string.Empty;
            serviceFolder = "SerialReaderService\\emViewService" + selectedComPort;
            serviceFolderPath = Path.Combine(rootPath, serviceFolder);
        }

        public string SelectedTab { get; set; }

        /// <summary>
        /// Updates the configuration file
        /// </summary>
        /// <param name="comPort"></param>
        /// <param name="baudRate"></param>
        /// <param name="refreshTimeInterval"></param>
        /// <returns></returns>
        public bool ReplaceConfigSettingsInFile(string comPort = null, string baudRate = null, string refreshTimeInterval = null, string site = null)
        {
            bool isConfigFileUpdated = false;
            {
                try
                {
                    lines = File.ReadAllLines(serviceConfigFilePath);
                    if ((comPort != null && comPort.Contains("COM") && cmbAvailablePorts.SelectedIndex >= 0) &&
                        (baudRate != null && cmbAvailableBaudRates.SelectedIndex >= 0) && !string.IsNullOrEmpty(refreshTimeInterval))
                    {
                        File.WriteAllText(serviceConfigFilePath, String.Empty);
                        File.AppendAllText(serviceConfigFilePath, comPort + Environment.NewLine + baudRate + Environment.NewLine + (Convert.ToInt32(refreshTimeInterval) * 60 * 1000) + Environment.NewLine + site);
                        isConfigFileUpdated = true;
                        lines = File.ReadAllLines(serviceConfigFilePath);
                        this.lblData.Text = $"COM Port: {lines[0]}   Baud Rate: {lines[1]}   Refresh Time: {(Convert.ToInt32(lines[2]) / 60000)}m ";
                        XtraMessageBox.Show($"Confiuration file has been updated with:{Environment.NewLine}PORT = {comPort}{Environment.NewLine}Baud Rate = {baudRate}{Environment.NewLine}Refresh Time Interval = {refreshTimeInterval}", "Configuration File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataLoggerControl.Write($"Confiuration file has been updated with PORT = {comPort}, Baud Rate = {baudRate} and Refresh Time Interval = {refreshTimeInterval}");
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }
            }
            return isConfigFileUpdated;
        }
    }
}