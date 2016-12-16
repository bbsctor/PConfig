using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;
using System.Globalization;
using System.IO;
using ConfigFrame.UITask;
using ConfigFrame.Util;
using PConfigUI.UITaskImpl;
using PConfigUI.UIServiceImpl;
using PConfigUI.UIUtil;
using PConfigUI.UIException;
using PConfigBase.AppInterfaceImpl;
using PConfigBase.Status;
using PConfigBase.BaseModelImpl.BaseDataModelImpl;
using PConfigBase.BaseModelImpl.ModelConverterImpl;
using PConfigBase.BaseModelImpl.BaseViewModelImpl;
using PConfigFacade.SpringFacade;

namespace PConfigUI
{
    public partial class MainFrame : Form
    {
        public enum STATUS {CONNECTED, DISCONNECTED, INIT }
        public STATUS currentStatus;

        private ConfigurationUIManager configurationUIManager;
        private TestUIManager testUIManager;
        private ClockUIManager clockUIManager;
        private LoggerUIManager loggerUIManager;
        private NetworkUIManager networkUIManager;
        private PowerUIManager powerUIManager;
        private ModemUIManager modemUIManager;
        private ProbeInfoUIManager probeInfoUIManager;

        private TestSensorTaskGroup querySensor;
        private QueryTimeTaskGroup queryTime;
        private ReadWriteTaskGroup readWriteProbe;
        private ModemTaskGroup modemManager;
        private QueryConfigurationTaskGroup queryConfiguration;
        private QueryPowerTaskGroup queryPower;

        private UIManager uiManager;

        private StatusScriber statusScriber;

        private Control[] powerLabelArray;
        private Control[] networkLabelArray;
        private Control[] loggerLabelArray;
        private Control[] clockLabelArray;

        private UIExceptionHandler uiExceptionHandler;

        public MainFrame()
        {
            currentStatus = STATUS.INIT;
            
            InitializeComponent();

            SpringContext.initContext();

            initUIManagers();

            //initTask();

            initObserveLabels();

            statusScriber = new StatusScriber(StatusManagerProvider.getSatatusManager(), this.main_status);

            uiExceptionHandler = new UIExceptionHandler(this);
            SpringContext.setLocalServerExceptionHandler(uiExceptionHandler);

            setUISupport(currentStatus);

            queryAllButton.Enabled = true;
            querySelectedButton.Enabled = true;
            stopQueryingButton.Enabled = false;

        }

        private void initTabControl()
        {
            this.mainTabControl.Controls.Add(this.configurationTabPage);
            this.mainTabControl.Controls.Add(this.sensorTestTabPage);
            this.mainTabControl.Controls.Add(this.clockTabPage);
            this.mainTabControl.Controls.Add(this.loggerTabPage);
            this.mainTabControl.Controls.Add(this.networkTabPage);
            this.mainTabControl.Controls.Add(this.modemTabPage);
            this.mainTabControl.Controls.Add(this.powerTabPage);
        }

        private void cleanTabControl()
        {
            this.mainTabControl.Controls.Remove(this.configurationTabPage);
            this.mainTabControl.Controls.Remove(this.sensorTestTabPage);
            this.mainTabControl.Controls.Remove(this.clockTabPage);
            this.mainTabControl.Controls.Remove(this.loggerTabPage);
            this.mainTabControl.Controls.Remove(this.networkTabPage);
            this.mainTabControl.Controls.Remove(this.modemTabPage);
            this.mainTabControl.Controls.Remove(this.powerTabPage);
        }

        private void initUIManagers()
        {
            uiManager = new UIManager();

            configurationUIManager = new ConfigurationUIManager(this.cfgDGV);
            configurationUIManager.tablePage = configurationTabPage;

            testUIManager = new TestUIManager(this.TestDGV);
            clockUIManager = new ClockUIManager(this);
            loggerUIManager = new LoggerUIManager(this);
            networkUIManager = new NetworkUIManager(this);
            powerUIManager = new PowerUIManager(this);
            modemUIManager = new ModemUIManager(this);

            uiManager.add("configuration", configurationUIManager);
            uiManager.add("test", testUIManager);
            uiManager.add("clock", clockUIManager);
            uiManager.add("logger", loggerUIManager);
            uiManager.add("network", networkUIManager);
            uiManager.add("power", powerUIManager);
            uiManager.add("modem", modemUIManager);
        }

        private void initTask()
        {
            queryTime = new QueryTimeTaskGroup(clock_dateTimePicker, clockUIManager.updateTime);
            queryTime.exceptionHandler = uiExceptionHandler;

            querySensor = new TestSensorTaskGroup(TestDGV, testUIManager.updateUI);
            querySensor.exceptionHandler = uiExceptionHandler;

            readWriteProbe = new ReadWriteTaskGroup(this, uiManager.updateViewModel);
            readWriteProbe.exceptionHandler = uiExceptionHandler;

            queryConfiguration = new QueryConfigurationTaskGroup(cfgDGV, configurationUIManager.updateUI);
            queryConfiguration.exceptionHandler = uiExceptionHandler;
            
            modemManager = new ModemTaskGroup(modem_atCmdText, modemUIManager.updateUI);
            modemManager.exceptionHandler = uiExceptionHandler;
            
            queryPower = new QueryPowerTaskGroup(this, powerUIManager.updateActualVoltageUI);
            queryPower.exceptionHandler = uiExceptionHandler;
        }

        private void initObserveLabels()
        {
            loggerLabelArray = new Control[] {
                this.logger_IDLabel,
                this.logger_URLLabel,
                this.logger_baudRateLabel,
                this.logger_connectOutLabel,
                this.logger_dialInUpLabel,
                this.logger_parityLabel,
                this.logger_respOutLabel,
                this.logger_sampleCountLabel,
                this.logger_sampleOriginLabel
                };
            networkLabelArray = new Control[]{
                this.network_dialInEnableLabel,
                this.network_dialInEnableRespLabel,
                this.network_dialInDisableLabel,
                this.network_dialInDisableRespLabel,
                this.network_initLabel,
                this.network_initRespLabel,
                this.network_connectLabel,
                this.network_connectRespLabel,
                this.network_disconnectLabel,
                this.network_disconnectRespLabel,
                };
            powerLabelArray = new Control[] { 
                this.power_disableProbeLabel,
                this.power_enableProbeLabel,
                this.power_disableTelecomLabel};
            clockLabelArray = new Control[] { this.clock_samplingIntervalLabel, this.clock_dateTimeLabel };
           
        }

        private void cleanDecoration()
        {
            DecorateTextAssitor.undecorateText(configurationTabPage);
            MultiChangeAssistor.removeChange(loggerTabPage, loggerLabelArray);
            MultiChangeAssistor.removeChange(networkTabPage, networkLabelArray);
            MultiChangeAssistor.removeChange(powerTabPage, powerLabelArray);
            MultiChangeAssistor.removeChange(clockTabPage, clockLabelArray);
        }

        private void setUISupport(STATUS status)
        {
            setFrameUISupport(status);
            
        }

        private void setFrameUISupport(STATUS status)
        {
            switch (status)
            {
                case STATUS.INIT:
                case STATUS.DISCONNECTED:
                    this.autoDetectButton.Enabled = false;
                    this.readProbeButton.Enabled = false;
                    this.writeProbeButton.Enabled = false;
                    this.backupButton.Enabled = false;
                    this.restoreButton.Enabled = false;
                    break;
                case STATUS.CONNECTED:
                    this.autoDetectButton.Enabled = true;
                    this.readProbeButton.Enabled = true;
                    this.writeProbeButton.Enabled = true;
                    this.backupButton.Enabled = true;
                    this.restoreButton.Enabled = true;
                    break;
            }
        }

        private void autoDetectButton_Click(object sender, EventArgs e)
        {
            //queryConfiguration.updateAll();
            MessageBox.Show("重新侦测传感器,已有的传感器数据将丢失！");
            configurationUIManager.cleanUI();
            testUIManager.cleanUI();
            uiManager.updateType = UIManager.UpdateType.PART;
            uiManager.updateList = new List<string>(new string[]{"configuration", "test"});
            //readWriteProbe.readProbe();
            readWriteProbe.autoDetect();
        }

        private void readProbeButton_Click(object sender, EventArgs e)
        {
            configurationUIManager.cleanUI();
            testUIManager.cleanUI();
            uiManager.updateType = UIManager.UpdateType.ALL;
            readWriteProbe.readProbe();
        }
        

        private void writeProbeButton_Click(object sender, EventArgs e)
        {
            showConfirmDialog();              
        }

        private class ConfigurationUIManager : BasicBlockUIManager
        {
            public TabPage tablePage;
            private DataGridView dgv;
            private DataGridViewChangeAssitant dgvca;
            public enum UpdateMode { ALL, SINGLE };
            public UpdateMode currentMode;
            public int row;
            public int column;
            public enum Field { AIR, WATER };
            public Field field;


            public ConfigurationUIManager(Control control)
                : base(control)
            {
                dgv = (DataGridView)control;
                currentMode = UpdateMode.ALL;
            }

            public override bool inputValidating()
            {
                int air,water;
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    int.TryParse(dgv.Rows[i].Cells["highAir"].FormattedValue.ToString(), out air);
                    int.TryParse(dgv.Rows[i].Cells["lowWater"].FormattedValue.ToString(), out water);
                    if (air <= water)
                    {
                        MessageBox.Show("空气中计频数应该大于水中计频数！");
                        return false;
                    }
                }
                return true;
            }

            public override void updateUI()
            {
                DecorateTextAssitor.undecorateText(tablePage);
                dgv.DefaultCellStyle.ForeColor = Color.Black;
                SensorListViewModel vList = UICommonService.getSensorListView();
                if (currentMode == UpdateMode.ALL)
                {
                    dgv.DataSource = vList;
                    dgv.Refresh();
                    dgvca = new DataGridViewChangeAssitant(dgv);
                }
                else if (currentMode == UpdateMode.SINGLE)
                {
                    if (field == Field.AIR)
                    {
                        dgv.Rows[row].Cells[column].Value = vList[row].HighAir;

                    }
                    else if (field == Field.WATER)
                    {
                        dgv.Rows[row].Cells[column].Value = vList[row].LowWater;
                    }
                    currentMode = UpdateMode.ALL;
                }
            }

            public override void cleanUI()
            {
                dgv.DataSource = null;
                dgv.Refresh();
            }

            public override void updateDataModel()
            {
                if (inputValidating() == true)
                {
                    SensorListDataModel sensorList = (SensorListDataModel)SensorListConverter.getInstance().
                    genDataModel((SensorListViewModel)dgv.DataSource);
                    UICommonService.updateSensorListDataModel(sensorList);
                }
                
            }

            public bool isCellChanged(DataGridViewCell cell)
            {
                return dgvca.isCellChanged(cell);
            }

            public bool isDGVChanged()
            {
                return dgvca.isDGVChanged();
            }
        }

        private class TestUIManager : BasicBlockUIManager
        {
            private DataGridView dgv;
            public TestUIManager(Control control)
                : base(control)
            {
                dgv = (DataGridView)control;
            }

            public override void updateUI()
            {
                dgv.DataSource = UICommonService.getSensorListView();
                dgv.Refresh();
            }

            public override void cleanUI()
            {
                dgv.DataSource = null;
                dgv.Refresh();
            }
        }

        private class ClockUIManager : BasicBlockUIManager
        {
            private MainFrame frame;
            public uint oldInterval;
            public DateTime oldDateTime;
            public enum DateTimeMode { PROBETIME, HOSTTIME, EDIT };
            public enum SamplingMode { DISPLAY, EDIT };
            public DateTimeMode dateTimeMode;
            public SamplingMode samplingMode;

            public ClockUIManager(Control control)
                : base(control)
            {
                frame = (MainFrame)control;
                dateTimeMode = DateTimeMode.PROBETIME;
                samplingMode = SamplingMode.DISPLAY;
            }

            public override bool inputValidating()
            {
                int temp;

                if (int.TryParse(frame.clock_samplingInterval.Text, out temp) && temp <= 2 || temp > 10020)
                {
                    MessageBox.Show("超出合理数值范围！");
                    return false;
                }
                if (frame.clock_samplingInterval.Text == "" && oldInterval != 0)
                {
                    frame.clock_samplingInterval.Text = oldInterval.ToString();
                }
                return true;
            }

            public override void updateUI()
            {
                if (dateTimeMode == DateTimeMode.PROBETIME && samplingMode == SamplingMode.DISPLAY)
                {
                    frame.clockTabPage.Text = "时钟配置";
                    MultiChangeAssistor.removeChange(frame.clockTabPage, frame.clockLabelArray);
                }


                updateSamplingInterval();
                updateTime();
            }

            public void updateSamplingInterval()
            {
                if (samplingMode == SamplingMode.DISPLAY)
                {
                    uint samplingInterval = UIClockService.getSamplingIntervalView();
                    oldInterval = samplingInterval / 60;
                    frame.clock_samplingInterval.Text = System.Convert.ToString(samplingInterval / 60); 
                }
            }

            public void updateTime()
            {
                if (dateTimeMode == DateTimeMode.PROBETIME)
                {
                    frame.clock_dateTimePicker.Value = UIClockService.getTimeView();
                    oldDateTime = frame.clock_dateTimePicker.Value;
                    frame.queryTime.startQueryProbeLoop();
                }
                else if (dateTimeMode == DateTimeMode.HOSTTIME)
                {
                    updateHostTime();
                }
            }

            public void updateHostTime()
            {
                frame.clock_dateTimePicker.Value = DateTime.Now;
            }

            public override void updateDataModel()
            {
                if (inputValidating() == true)
                {
                    ClockDataModel cModel = new ClockDataModel();
                    cModel.samplingInterval = System.Convert.ToUInt32(frame.clock_samplingInterval.Text) * 60;
                    cModel.timeModel = TimeConverter.genTimeDataModel(frame.clock_dateTimePicker.Value);
                    UIClockService.updateDataModel(cModel);
                    dateTimeMode = DateTimeMode.PROBETIME;
                    samplingMode = SamplingMode.DISPLAY;
                }
                
            }
        }

        private class LoggerUIManager : BasicBlockUIManager
        {
            private MainFrame frame;
            public LoggerViewModel oldViewModel;
            public LoggerUIManager(Control control)
                : base(control)
            {
                frame = (MainFrame)control;
            }

            public override bool inputValidating()
            {
                if (oldViewModel != null)
                {
                    if (frame.logger_baudRate.Text == "")
                    {
                        frame.logger_baudRate.Text = oldViewModel.BaudRate;
                    }
                    if (frame.logger_connectOut.Text == "")
                    {
                        frame.logger_connectOut.Text = System.Convert.ToString(oldViewModel.ConnectOut);
                    }
                    if (frame.logger_destURL.Text == "")
                    {
                        frame.logger_baudRate.Text = oldViewModel.DestURL.FullURL;
                    }
                    
                    if (frame.logger_ID.Text == "")
                    {
                        frame.logger_ID.Text = oldViewModel.LoggerID;
                    }
                    if (frame.logger_parity.Text == "")
                    {
                        frame.logger_parity.Text = oldViewModel.Parity;
                    }
                    if (frame.logger_respOut.Text == "")
                    {
                        frame.logger_respOut.Text = System.Convert.ToString(oldViewModel.ResponseOut);;
                    }
                }
                return true;
            }

            public override void updateUI()
            {
                frame.loggerTabPage.Text = "记录器配置";
                MultiChangeAssistor.removeChange(frame.loggerTabPage, frame.loggerLabelArray);
                LoggerViewModel vModel = UILoggerService.getViewModel();
                oldViewModel = vModel;

                frame.logger_baudRateLabel.Text = "Modem波特率";
                frame.logger_connectOutLabel.Text = "连接时限";
                frame.logger_dialInUpLabel.Text = "上传时间";
                frame.logger_IDLabel.Text = "记录器ID";
                frame.logger_parityLabel.Text = "Modem校验位";
                frame.logger_respOutLabel.Text = "响应时限";
                frame.logger_sampleCountLabel.Text = "采样计数";
                frame.logger_sampleOriginLabel.Text = "采样起始时间";
                frame.logger_URLLabel.Text = "目标URL";

                frame.logger_baudRate.Text = vModel.BaudRate;
                frame.logger_connectOut.Text = System.Convert.ToString(vModel.ConnectOut);
                frame.logger_destURL.Text = vModel.DestURL.FullURL;
                frame.logger_dialInUp.Value = DateTime.Today + vModel.DialInTime;
                frame.logger_ID.Text = vModel.LoggerID;
                frame.logger_parity.Text = vModel.Parity;
                
                frame.logger_respOut.Text = System.Convert.ToString(vModel.ResponseOut);
                frame.logger_sampleCount.Text = System.Convert.ToString(vModel.SampleCount);
                frame.logger_sampleOrigin.Value = vModel.SampleOrigin;
                frame.logger_lastResp.Text = System.Convert.ToString(vModel.ConnectStatus);

                updateSampleCountLable();
            }
            public override void updateDataModel()
            {
                inputValidating();
                LoggerViewModel lModel = new LoggerViewModel();
                lModel.BaudRate = frame.logger_baudRate.Text;
                lModel.ConnectOut = System.Convert.ToUInt16(frame.logger_connectOut.Text);
                lModel.DestURL = new URLViewModel(frame.logger_destURL.Text);
                //DateTime dateTime = frame.logger_dialInUp.Value;
                //lModel.DialInTime = (uint)(dateTime.Hour * 60 * 60 + dateTime.Minute * 60 + dateTime.Second);
                lModel.DialInTime = frame.logger_dialInUp.Value - DateTime.Today; 
                lModel.LoggerID = frame.logger_ID.Text;
                lModel.Parity = frame.logger_parity.Text;
                lModel.ResponseOut = System.Convert.ToUInt16(frame.logger_respOut.Text);
                lModel.SampleCount = System.Convert.ToUInt16(frame.logger_sampleCount.Text);
                lModel.SampleOrigin = frame.logger_sampleOrigin.Value;

                LoggerDataModel model = (LoggerDataModel)LoggerConverter.getInstance().genDataModel(lModel);
                UILoggerService.updateDataModel(model);
            }

            public void updateSampleCountLable()
            {
                int count = (int)frame.logger_sampleCount.Value;
                int interval;
                int.TryParse(frame.clock_samplingInterval.Text, out interval);
                frame.sampleCountLabel.Text = "探头将在" + count * interval + "分钟内上传" + count + "条记录";
            }
        }

        private class NetworkUIManager : BasicBlockUIManager
        {
            private MainFrame frame;
            public NetworkViewModel oldViewModel;
            public NetworkUIManager(Control control)
                : base(control)
            {
                frame = (MainFrame)control;
            }
            public override void updateUI()
            {
                frame.networkTabPage.Text = "网络配置";
                MultiChangeAssistor.removeChange(frame.networkTabPage, frame.networkLabelArray);

                NetworkViewModel vModel = UINetworkService.getViewModel();
                oldViewModel = vModel;

                frame.network_connect.Text = vModel.Connect;
                frame.network_connectResp.Text = vModel.ConnectResp;
                frame.network_dialInDisable.Text = vModel.DialInDisable;
                frame.network_dialInDisableResp.Text = vModel.DialInDisableResp;
                frame.network_dialInEnable.Text = vModel.DialInEnable;
                frame.network_dialInEnableResp.Text = vModel.DialInEnableResp;
                frame.network_disconnect.Text = vModel.Disconnect;
                frame.network_disconnectResp.Text = vModel.DisconnectResp;
                frame.network_init.Text = vModel.Init;
                frame.network_initResp.Text = vModel.InitResp;
                frame.network_pwd.Text = vModel.Password;
                frame.network_userName.Text = vModel.UserName;
            }
            public override void updateDataModel()
            {
                NetworkViewModel vModel = new NetworkViewModel();

                vModel.Connect = frame.network_connect.Text;
                vModel.ConnectResp = frame.network_connectResp.Text;
                vModel.DialInDisable = frame.network_dialInDisable.Text;
                vModel.DialInDisableResp = frame.network_dialInDisableResp.Text;
                vModel.DialInEnable = frame.network_dialInEnable.Text;
                vModel.DialInEnableResp = frame.network_dialInEnableResp.Text;
                vModel.Disconnect = frame.network_disconnect.Text;
                vModel.DisconnectResp = frame.network_disconnectResp.Text;
                vModel.Init = frame.network_init.Text;
                vModel.InitResp = frame.network_initResp.Text;
                vModel.Password = frame.network_pwd.Text;
                vModel.UserName = frame.network_userName.Text;
                UINetworkService.updateDataModel((NetworkDataModel)(NetworkConverter.getInstance().genDataModel(vModel)));
            }
        }

        private class ModemUIManager : BasicBlockUIManager
        {
            private MainFrame frame;
            public string lastRecv;
            public enum Mode { SESSION,TEST, COMMON};
            public Mode mode;
            public ModemUIManager(Control control)
                : base(control)
            {
                frame = (MainFrame)control;
                frame.modem_send.Enabled = false;
                mode = Mode.COMMON;
            }
            public override void updateUI()
            {
                //frame.modemTabPage.Text = "Modem配置";
                ModemViewModel model = UIModemService.getViewModel();
                
                if (mode == Mode.SESSION  && (lastRecv == null || lastRecv.Equals(model.SessionRecv) == false))
                {
                    if (model.SessionRecv != null)
                    {
                        lastRecv = model.SessionRecv;
                        frame.modem_textbox.AppendText(model.SessionRecv);
                    }
                    frame.modem_status.Text = "解析数据";
                }
                else if (mode == Mode.COMMON)
                {
                    frame.modem_textbox.Text = null;
                    lastRecv = null;
                    
                }
                else if (mode == Mode.TEST)
                {
                    frame.modem_status.Text = model.Status;
                    frame.logger_lastResp.Text = model.Status;
                    if (frame.modem_progressBar.Value < frame.modem_progressBar.Maximum)
                    {
                        frame.modem_progressBar.PerformStep();
                    }
                    else
                    {
                        frame.modem_progressBar.Value = frame.modem_progressBar.Minimum;
                    }
                    if ((frame.modem_status.Text.Contains("Failure") == true || 
                        frame.modem_status.Text.Contains("Success") == true) && mode == Mode.TEST)
                    {
                        frame.modemManager.closeTest();
                        frame.modem_test.Text = "测试";
                        frame.modem_upload.Text = "上传";
                        frame.modem_progressBar.Value = frame.modem_progressBar.Minimum;
                        mode = Mode.COMMON;
                    }
                }
            }

            public override void updateDataModel()
            {
                ModemDataModel model = new ModemDataModel();
                model.atCommand = StringByteConverter.stringToByteArray(frame.modem_atCmdText.Text);
                UIModemService.updateDataModel(model);
            }
        }

        private class PowerUIManager : BasicBlockUIManager
        {
            private MainFrame frame;
            public PowerViewModel oldViewModel;
            public PowerUIManager(Control control)
                : base(control)
            {
                frame = (MainFrame)control;
            }

            public override bool inputValidating()
            {
                if (oldViewModel != null)
                {
                    if (frame.power_disableProbe.Text == "")
                    {
                        frame.power_disableProbe.Text = Convert.ToString(oldViewModel.DisableProbe);
                    }
                    if (frame.power_disableTelecom.Text == "")
                    {
                        frame.power_disableTelecom.Text = Convert.ToString(oldViewModel.DisableTelecom);
                    }
                    if (frame.power_enableProbe.Text == "")
                    {
                        frame.power_enableProbe.Text = Convert.ToString(oldViewModel.EnableProbe);
                    }
                }
                float disable, enable, disTelecom;
                if (float.TryParse(frame.power_disableProbe.Text, out disable) == false)
                {
                    MessageBox.Show("数据格式错误！");
                    return false;
                }
                else
                {
                    if (disable < oldViewModel.DisableProbe_low || disable > oldViewModel.DisableProbe_high)
                    {
                        MessageBox.Show("数值超出范围！");
                        return false;
                    }
                }

                if (float.TryParse(frame.power_disableTelecom.Text, out disTelecom) == false)
                {
                    MessageBox.Show("数据格式错误！");
                    return false;
                }
                else
                {
                    if (disTelecom < oldViewModel.DisableTelecom_low || disTelecom > oldViewModel.DisableTelecom_high)
                    {
                        MessageBox.Show("数值超出范围！");
                        return false;
                    }
                }

                if (float.TryParse(frame.power_enableProbe.Text, out enable) == false)
                {
                    MessageBox.Show("数据格式错误！");
                    return false;
                }
                else
                {
                    if (enable < oldViewModel.EnableProbe_low || enable > oldViewModel.EnableProbe_high)
                    {
                        MessageBox.Show("数值超出范围！");
                        return false;
                    }
                }

                if (enable <= disable)
                {
                    MessageBox.Show("启用电压值不能小于等于禁用电压值！");
                    return false;
                }

                return true;
            }
            public override void updateUI()
            {
                frame.powerTabPage.Text = "电源配置";
                MultiChangeAssistor.removeChange(frame.powerTabPage, frame.powerLabelArray);

                PowerViewModel model = UIPowerService.getViewModel();
                oldViewModel = model;

                frame.power_battery.Text = Convert.ToString(model.Battery) + "V";
                frame.power_batteryLogged.Checked = false;
                frame.power_disableProbe.Text = Convert.ToString(model.DisableProbe);
                frame.power_disableProbeZone.Text = Convert.ToString(model.DisableProbe_low) + "-" + Convert.ToString(model.DisableProbe_high) + "V";
                frame.power_disableTelecom.Text = Convert.ToString(model.DisableTelecom);
                frame.power_disableTelecomZone.Text = Convert.ToString(model.DisableTelecom_low) + "-" + Convert.ToString(model.DisableTelecom_high) + "V";
                frame.power_enableProbe.Text = Convert.ToString(model.EnableProbe);
                frame.power_enableProbeZone.Text = Convert.ToString(model.EnableProbe_low) + "-" + Convert.ToString(model.EnableProbe_high) + "V";
                frame.power_solar.Text = Convert.ToString(model.Solar) + "V";
                frame.power_solarCharge.Text = Convert.ToString(model.SolarCharge) + "mA";
                frame.power_solarChargeLogged.Checked = false;
                frame.power_solarLogged.Checked = false;
                frame.power_supply.Text = Convert.ToString(model.Supply) + "V";
                frame.power_supplyLogged.Checked = false;

                frame.mainTabControl.Enabled = true;
            }

            public void updateActualVoltageUI()
            {
                PowerViewModel model = UIPowerService.getViewModel();
                frame.power_supply.Text = Convert.ToString(Math.Round(model.Supply, 2)) + "V";
            }
            public override void updateDataModel()
            {
                if (inputValidating() == true)
                {
                    PowerViewModel vModel = new PowerViewModel();
                    vModel.DisableProbe = System.Convert.ToSingle(frame.power_disableProbe.Text);
                    vModel.DisableTelecom = System.Convert.ToSingle(frame.power_disableTelecom.Text);
                    vModel.EnableProbe = System.Convert.ToSingle(frame.power_enableProbe.Text);
                    UIPowerService.updateDataModel((PowerDataModel)(PowerConverter.getInstance().genDataModel(vModel)));
                }
            }
        }

        private class ProbeInfoUIManager : BasicBlockUIManager
        {
            private ProbeInfoDialog probeInfoDialog;
            public ProbeInfoUIManager(Control control)
                : base(control)
            {
                this.probeInfoDialog = (ProbeInfoDialog)control;
            }

            public override void updateDataModel()
            {

                if (probeInfoDialog.isWrite == true)
                {
                    ProbeInfoViewModel vModel = UIProbeInfoService.getViewModel();
                    vModel.Addr = probeInfoDialog.getAddr();
                    UIProbeInfoService.updateDataModel((ProbeInfoDataModel)(ProbeInfoConverter.getInstance().genDataModel(vModel)));
                }

            }
            public override void updateUI()
            {
                ProbeInfoViewModel vModel = UIProbeInfoService.getViewModel();
                probeInfoDialog.setType(vModel.Type);
                probeInfoDialog.setSerialNumber(vModel.SerialNumber);
                probeInfoDialog.setAddr(System.Convert.ToString(vModel.Addr));
                probeInfoDialog.setVersion(vModel.Version);
            }

            public override bool inputValidating()
            {
                return true;
            }
        }

        private void mainTabControl_Deselected(object sender, TabControlEventArgs e)
        {
            if (currentStatus == STATUS.CONNECTED)
            {
                if (e.TabPage.Name.Equals("configurationTabPage"))
                {
                    //SensorListDataModel sensorList = (SensorListDataModel)SensorListConverter.getInstance().
                    //            genDataModel((SensorListViewModel)((BindingSource)cfgDGV.DataSource).DataSource);
                    SensorListDataModel sensorList = (SensorListDataModel)SensorListConverter.getInstance().
                                genDataModel((SensorListViewModel)cfgDGV.DataSource);
                    UICommonService.updateSensorListDataModel(sensorList);
                }
                else if (e.TabPage.Name.Equals("sensorTestTabPage"))
                {
                    if (stopQueryingButton.Enabled == true)
                    {
                        querySensor.stopQueryLoop();

                        queryAllButton.Enabled = true;
                        querySelectedButton.Enabled = true;
                        stopQueryingButton.Enabled = false;
                    }
                }
                else if (e.TabPage.Name.Equals("clockTabPage"))
                {
                    queryTime.stopQueryLoop();
                }
                else if (e.TabPage.Name.Equals("powerTabPage"))
                {
                    queryPower.stopQueryLoop();
                }
            }
        }

        private void mainTabControl_Selected(object sender, TabControlEventArgs e)
        {
            if (currentStatus == STATUS.CONNECTED)
            {
                if (e.TabPage.Name.Equals("sensorTestTabPage"))
                {
                    testUIManager.updateUI();
                }
                else if (e.TabPage.Name.Equals("powerTabPage"))
                {
                    queryPower.startQueryPowerLoop();
                }
                else if (e.TabPage.Name.Equals("clockTabPage"))
                {
                    clockUIManager.updateUI();
                }

                string pageName = e.TabPage.Name;
                string controllerName = pageName.Substring(0, pageName.Length - 7) + "Controller";
                UICommonService.setSelectedController(controllerName);
            }
        }

        private void querySelectedButton_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dgvrc = TestDGV.SelectedRows;
            if (dgvrc.Count == 0)
            {
                MessageBox.Show("请选定传感器！");
                return;
            }

            int[] addrs = new int[dgvrc.Count];
            for (int i = 0; i < dgvrc.Count; i++)
            {
                addrs[i] = (int)dgvrc[i].Cells["selAddr"].Value;
            }

            querySensor.queryRTSelectedSensor(addrs);

            queryAllButton.Enabled = false;
            querySelectedButton.Enabled = false;
            stopQueryingButton.Enabled = true;
        }

        private void stopQueryingButton_Click(object sender, EventArgs e)
        {
            querySensor.stopQueryLoop();

            queryAllButton.Enabled = true;
            querySelectedButton.Enabled = true;
            stopQueryingButton.Enabled = false;
        }

        private void queryAllButton_Click(object sender, EventArgs e)
        {
            querySensor.queryAllSensor();

            queryAllButton.Enabled = false;
            querySelectedButton.Enabled = false;
            stopQueryingButton.Enabled = true;
        }

        private void timeSynButton_Click(object sender, EventArgs e)
        {
            //queryTime.startQueryHostLoop();
            clockUIManager.dateTimeMode = ClockUIManager.DateTimeMode.HOSTTIME;
            clockUIManager.updateUI();
            SingleChangeAssistor.alertChange(this.clock_dateTimePicker, this.clock_dateTimeLabel,
                            clockUIManager.oldDateTime.ToString());
            MultiChangeAssistor.alertChange(clockLabelArray, clockTabPage);
        }

        private void modem_openSession_Click(object sender, EventArgs e)
        {
            if ("打开会话".Equals(modem_openSession.Text))
            {
                modemUIManager.mode = ModemUIManager.Mode.SESSION;
                modemManager.openSession();
                modem_openSession.Text = "关闭会话";
                modem_send.Enabled = true;
                modem_test.Enabled = false;
                modem_upload.Enabled = false;
            }
            else if ("关闭会话".Equals(modem_openSession.Text))
            {
                modemUIManager.mode = ModemUIManager.Mode.COMMON;
                modemManager.closeSession();
                modem_openSession.Text = "打开会话";
                modem_send.Enabled = false;
                modem_test.Enabled = true;
                modem_upload.Enabled = true;
                this.modem_status.Text = "";
            }
        }


        private void modem_upload_Click(object sender, EventArgs e)
        {
            if ("上传".Equals(modem_upload.Text))
            {
                modemUIManager.mode = ModemUIManager.Mode.TEST;
                modemManager.upload();
                modem_upload.Text = "取消";
            }
            else if ("取消".Equals(modem_upload.Text))
            {
                modemUIManager.mode = ModemUIManager.Mode.COMMON;
                this.modemManager.closeTest();
                modem_upload.Text = "上传";
            }
        }

        private void modem_test_Click(object sender, EventArgs e)
        {
            if ("测试".Equals(modem_test.Text))
            {
                modemUIManager.mode = ModemUIManager.Mode.TEST;
                modemManager.test();
                modem_test.Text = "取消";
            }
            else if ("取消".Equals(modem_test.Text))
            {
                modemUIManager.mode = ModemUIManager.Mode.COMMON;
                this.modemManager.closeTest();
                modem_test.Text = "测试";
            }
        }



        private void modem_send_Click(object sender, EventArgs e)
        {
            modemUIManager.updateDataModel();
            if (this.modem_atCmdText.Items.Contains(this.modem_atCmdText.Text) == false)
            {
                this.modem_atCmdText.Items.Add(this.modem_atCmdText.Text);
            }
            this.modem_atCmdText.Text = "";
            modemManager.sendAT();
        }

        private void 探头信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showProbeInfoDialog();
        }

        private void logger_urlEdit_Click(object sender, EventArgs e)
        {
            URLViewModel vModel = new URLViewModel();
            vModel.FullURL = this.logger_destURL.Text;
            using (URLEditDialog dlg = new URLEditDialog(vModel))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.logger_destURL.Text = vModel.FullURL;
                }
            }
        }

        private bool isUnique(DataGridViewCellValidatingEventArgs e)
        {
            for (int i = 0; i < cfgDGV.RowCount; i++)
            {
                if (i != e.RowIndex)
                {
                    float a = (float)(cfgDGV.Rows[i].Cells[1].Value);
                    float b = float.Parse(e.FormattedValue.ToString());
                    if ( a == b)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void cfgDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             if (cfgDGV.Columns[e.ColumnIndex].Name == "RefreshAir" ||
                 cfgDGV.Columns[e.ColumnIndex].Name == "RefreshWater")
             {
                 int addr = (int)cfgDGV.Rows[e.RowIndex].Cells[0].Value;
                 configurationUIManager.row = e.RowIndex;
                 configurationUIManager.column = e.ColumnIndex - 1;
                 configurationUIManager.currentMode = ConfigurationUIManager.UpdateMode.SINGLE;
                 if (cfgDGV.Columns[e.ColumnIndex].Name == "RefreshAir")
                 {
                     configurationUIManager.field = ConfigurationUIManager.Field.AIR;
                     queryConfiguration.updateAirByAddr(addr);
                 }
                 else if (cfgDGV.Columns[e.ColumnIndex].Name == "RefreshWater")
                 {
                     configurationUIManager.field = ConfigurationUIManager.Field.WATER;
                     queryConfiguration.updateWaterByAddr(addr);
                 }
             }
             else if (cfgDGV.Columns[e.ColumnIndex].Name == "isSelected")
             {
                 DataGridViewCell cell = cfgDGV.Rows[e.RowIndex].Cells[e.ColumnIndex];
                 if ((bool)cell.EditedFormattedValue == true)
                 {
                     cell.Value = true;
                 }
                 else
                 {
                     cell.Value = false;
                 }
                 
             }
            
        }

        private void cfgDGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            cfgDGV.Rows[e.RowIndex].ErrorText = "";
            int newInteger;
            if (cfgDGV.Columns[e.ColumnIndex].Name == "Depth")
            {
                if (int.TryParse(e.FormattedValue.ToString(), out newInteger) == true)
                {
                    if (newInteger <= 0)
                    {
                        MessageBox.Show("无效值！");
                        cfgDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                        return;
                    }
                    else if (isUnique(e) == false)
                    {
                        e.Cancel = true;
                        MessageBox.Show("深度值设置必须唯一！");
                    }
                }
            }
            else if (cfgDGV.Columns[e.ColumnIndex].Name == "HighAir" || cfgDGV.Columns[e.ColumnIndex].Name == "LowWater")
            {
                if (int.TryParse(e.FormattedValue.ToString(), out newInteger) == true && newInteger <= 0)
                {
                    MessageBox.Show("无效值！");
                    cfgDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                    return;
                }
            }
            else if (cfgDGV.Columns[e.ColumnIndex].Name == "CoefStr")
            {
                string pattern = @"\b([\+-]?\d+(\.\d+)?){3}\b";
                string value = cfgDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                Regex regex = new Regex(pattern);
                if (!regex.IsMatch(value))
                {
                    e.Cancel = true;
                    cfgDGV.Rows[e.RowIndex].ErrorText = "字符串必须满足格式要求";
                }
            }
        }

        private void cfgDGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (configurationUIManager.isCellChanged(((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex]) == true
                                && configurationUIManager.isDGVChanged() == true)
                {
                    DecorateTextAssitor.decorateText(this.configurationTabPage, Color.Black);
                }
                else if (configurationUIManager.isCellChanged(((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex]) == false
                    && configurationUIManager.isDGVChanged() == false)
                {
                    DecorateTextAssitor.undecorateText(this.configurationTabPage);
                }
            }
                
        }

        private void 连接串口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showSerialDialog();
        }

        private class StatusScriber
        {
            private ToolStripStatusLabel sb;

            public StatusScriber(StatusManager manager, ToolStripStatusLabel sb)
            {
                IProcessStatus p = (IProcessStatus)manager;
                p.ProcessChanged += new EventHandler(updateStatus);
                this.sb = sb;
            }

            void updateStatus(object sender, EventArgs e)
            {
                ProcessEventArgs pe = (ProcessEventArgs)e;
                sb.Text = pe.message;
            }
        }

        private class ExceptionScriber
        {
            public ExceptionScriber(ExceptionManager manager)
            {
                IHandleException h = (IHandleException)manager;
                h.ExceptionOccurred += new EventHandler(alertException);
            }

            void alertException(object sender, EventArgs e)
            {
                ExceptionEventArgs ee = (ExceptionEventArgs)e;
                MessageBox.Show(ee.exception.ToString());
            }
        }

        public void showSerialDialog()
        {
            using(SerialDialog dlg = new SerialDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (((Button)(dlg.AcceptButton)).Text.Equals("建立连接"))
                    {
                        if (dlg.noData == true)
                        {
                            showSerialDialog();
                        }
                        try
                        {
                            UISerialService.connect();
                            currentStatus = STATUS.CONNECTED;
                        }
                        catch (TimeoutException te)
                        {
                            MessageBox.Show("连接超时!");
                            UISerialService.closePort();
                            currentStatus = STATUS.DISCONNECTED;
                        }
                        catch (UnauthorizedAccessException ue)
                        {
                            MessageBox.Show("对端口的访问被拒绝!");
                            UISerialService.closePort();
                            currentStatus = STATUS.DISCONNECTED;
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("此端口处于无效状态!");
                            UISerialService.closePort();
                            currentStatus = STATUS.DISCONNECTED;
                        }
                        if (currentStatus == STATUS.CONNECTED)
                        {
                            initTask();
                            UICommonService.startLocalServer();
                            readWriteProbe.readProbe();
                            initTabControl();
                            setUISupport(currentStatus);
                            this.mainTabControl.Enabled = false;
                        }
                        else
                        {
                            showSerialDialog();
                        }
                    }
                    else if (((Button)(dlg.AcceptButton)).Text.Equals("断开连接"))
                    {
                        finish();
                        currentStatus = STATUS.DISCONNECTED;
                        //UICommonService.stopLocalServer();
                        

                        cleanTabControl();
                        //cleanUI();
                        configurationUIManager.cleanUI();
                        testUIManager.cleanUI();
                        setUISupport(currentStatus);
                        finish();
                        UISerialService.disconnect();
                    }
                }
            }
        }

        private void showProbeInfoDialog()
        {
            if (currentStatus == STATUS.CONNECTED)
            {
                ProbeInfoViewModel vModel = UIProbeInfoService.getViewModel();
                using (ProbeInfoDialog dlg = new ProbeInfoDialog(vModel))
                {
                    probeInfoUIManager = new ProbeInfoUIManager(dlg);
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        if (dlg.isWrite == true)
                        {
                            probeInfoUIManager.updateDataModel();
                            UIProbeInfoService.writeProbeInfo();
                            showProbeInfoDialog();
                        }
                        else
                        {
                            UIProbeInfoService.readProbeInfo();
                        }
                    }
                }
            }
        }

        private void MainFrame_Activated(object sender, EventArgs e)
        {
            if (currentStatus == STATUS.INIT)
            {
                currentStatus = STATUS.DISCONNECTED;
                showSerialDialog();
            }
        }

        private void clock_samplingInterval_TextChanged(object sender, EventArgs e)
        {
            uint temp;
            if (uint.TryParse(this.clock_samplingInterval.Text, out temp) == false)
            {
                MessageBox.Show("数据格式错误！");
                return;
            }
            bool  b = SingleChangeAssistor.alertChange(this.clock_samplingInterval, this.clock_samplingIntervalLabel, 
                clockUIManager.oldInterval.ToString());
            if (b == true)
            {
                clockUIManager.samplingMode = ClockUIManager.SamplingMode.EDIT;
            }
            else
            {
                clockUIManager.samplingMode = ClockUIManager.SamplingMode.DISPLAY;
            }
            MultiChangeAssistor.alertChange(clockLabelArray, clockTabPage);
            loggerUIManager.updateSampleCountLable();
        }

        private void clock_dateTimePicker_CloseUp(object sender, EventArgs e)
        {
            
            if(this.clock_dateTimePicker.Value.Date != clockUIManager.oldDateTime.Date)
            {
                clockUIManager.dateTimeMode = ClockUIManager.DateTimeMode.EDIT;
                queryTime.stopQueryLoop();
                SingleChangeAssistor.alertChange(this.clock_dateTimePicker, this.clock_dateTimeLabel,
                                clockUIManager.oldDateTime.ToString());
                MultiChangeAssistor.alertChange(clockLabelArray, clockTabPage);
            }
            //else
            //{
            //    clockUIManager.updateMode = ClockUIManager.UpdateMode.PROBETIME;
            //}
        }

        private void clock_dateTimePicker_KeyPress(object sender, KeyPressEventArgs e)
        {
            clockUIManager.dateTimeMode = ClockUIManager.DateTimeMode.EDIT;
            queryTime.stopQueryLoop();
            SingleChangeAssistor.alertChange(this.clock_dateTimePicker, this.clock_dateTimeLabel,
                            clockUIManager.oldDateTime.ToString());
            MultiChangeAssistor.alertChange(clockLabelArray, clockTabPage);
        }   

        private void logger_ID_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < logger_ID.Text.Length; i++)
            {
                if (char.IsLetterOrDigit(logger_ID.Text[i]) == false && '_'.Equals(logger_ID.Text[i]) == false)
                {
                    MessageBox.Show("包含不规范字符！");
                    logger_ID.Focus();
                }
            }
            SingleChangeAssistor.alertChange(this.logger_ID, this.logger_IDLabel,
                    loggerUIManager.oldViewModel.LoggerID);
            MultiChangeAssistor.alertChange(loggerLabelArray, loggerTabPage);
        }

        private void logger_destURL_TextChanged(object sender, EventArgs e)
        {
            SingleChangeAssistor.alertChange(this.logger_destURL, this.logger_URLLabel,
                loggerUIManager.oldViewModel.DestURL.FullURL);
            MultiChangeAssistor.alertChange(loggerLabelArray, loggerTabPage);
        }

        //private void logger_sampleOrigin_TextChanged(object sender, EventArgs e)
        //{
        //    SingleChangeAssistor.alertChange(this.logger_sampleOrigin, this.logger_sampleOriginLabel,
        //        loggerUIManager.oldViewModel.SampleOrigin.ToString(new CultureInfo(0x0804)));
        //    MultiChangeAssistor.alertChange(loggerLabelArray, loggerTabPage);
        //}

        private void logger_sampleOrigin_ValueChanged(object sender, EventArgs e)
        {
            if (this.logger_sampleOrigin.Value.Equals(loggerUIManager.oldViewModel.SampleOrigin) == false)
            {
                DecorateTextAssitor.decorateText(this.logger_sampleOriginLabel, System.Drawing.Color.Red);
            }
            else
            {
                DecorateTextAssitor.undecorateText(this.logger_sampleOriginLabel);
            }
            MultiChangeAssistor.alertChange(loggerLabelArray, loggerTabPage);
        }

        private void logger_sampleCount_TextChanged(object sender, EventArgs e)
        {
            ushort temp;
            if (ushort.TryParse(this.logger_sampleCount.Text, out temp) == false)
            {
                MessageBox.Show("数据格式错误！");
                return;
            }
            SingleChangeAssistor.alertChange(this.logger_sampleCount, this.logger_sampleCountLabel,
                            loggerUIManager.oldViewModel.SampleCount.ToString());
            MultiChangeAssistor.alertChange(loggerLabelArray, loggerTabPage);
            loggerUIManager.updateSampleCountLable();
        }

        private void logger_dialInUp_TextChanged(object sender, EventArgs e)
        {
            SingleChangeAssistor.alertChange(this.logger_dialInUp, this.logger_dialInUpLabel,
                            loggerUIManager.oldViewModel.DialInTime.ToString());
            MultiChangeAssistor.alertChange(loggerLabelArray, loggerTabPage);
        }

        private void logger_connectOut_TextChanged(object sender, EventArgs e)
        {
            uint temp;
            if (uint.TryParse(this.logger_connectOut.Text, out temp) == false)
            {
                MessageBox.Show("数据格式错误！");
                return;
            }
            SingleChangeAssistor.alertChange(this.logger_connectOut, this.logger_connectOutLabel,
                            loggerUIManager.oldViewModel.ConnectOut.ToString());
            MultiChangeAssistor.alertChange(loggerLabelArray, loggerTabPage);
        }

        private void logger_respOut_TextChanged(object sender, EventArgs e)
        {
            uint temp;
            if (uint.TryParse(this.logger_respOut.Text, out temp) == false)
            {
                MessageBox.Show("数据格式错误！");
                return;
            }
            SingleChangeAssistor.alertChange(this.logger_respOut, this.logger_respOutLabel,
                            loggerUIManager.oldViewModel.ResponseOut.ToString());
            MultiChangeAssistor.alertChange(loggerLabelArray, loggerTabPage);
        }

        private void logger_baudRate_TextChanged(object sender, EventArgs e)
        {
            SingleChangeAssistor.alertChange(this.logger_baudRate, this.logger_baudRateLabel,
                            loggerUIManager.oldViewModel.BaudRate.ToString());
            MultiChangeAssistor.alertChange(loggerLabelArray, loggerTabPage);
        }

        private void logger_parity_TextChanged(object sender, EventArgs e)
        {
            SingleChangeAssistor.alertChange(this.logger_parity, this.logger_parityLabel,
                            loggerUIManager.oldViewModel.Parity.ToString());
            MultiChangeAssistor.alertChange(loggerLabelArray, loggerTabPage);
        }


        private void network_dialInEnable_TextChanged(object sender, EventArgs e)
        {
            SingleChangeAssistor.alertChange(this.network_dialInEnable, this.network_dialInEnableLabel,
                networkUIManager.oldViewModel.DialInEnable);
            MultiChangeAssistor.alertChange(networkLabelArray, networkTabPage);
        }

        private void network_dialInEnableResp_TextChanged(object sender, EventArgs e)
        {
            SingleChangeAssistor.alertChange(this.network_dialInEnableResp, this.network_dialInEnableRespLabel,
                networkUIManager.oldViewModel.DialInEnableResp);
            MultiChangeAssistor.alertChange(networkLabelArray, networkTabPage);
        }

        private void network_dialInDisable_TextChanged(object sender, EventArgs e)
        {
            SingleChangeAssistor.alertChange(this.network_dialInDisable, this.network_dialInDisableLabel,
                networkUIManager.oldViewModel.DialInDisable);
            MultiChangeAssistor.alertChange(networkLabelArray, networkTabPage);
        }

        private void network_dialInDisableResp_TextChanged(object sender, EventArgs e)
        {
            SingleChangeAssistor.alertChange(this.network_dialInDisableResp, this.network_dialInDisableRespLabel,
                networkUIManager.oldViewModel.DialInDisableResp);
            MultiChangeAssistor.alertChange(networkLabelArray, networkTabPage);
        }

        private void network_init_TextChanged(object sender, EventArgs e)
        {
            SingleChangeAssistor.alertChange(this.network_init, this.network_initLabel,
                networkUIManager.oldViewModel.Init);
            MultiChangeAssistor.alertChange(networkLabelArray, networkTabPage);
        }

        private void network_initResp_TextChanged(object sender, EventArgs e)
        {
            SingleChangeAssistor.alertChange(this.network_initResp, this.network_initRespLabel,
                networkUIManager.oldViewModel.InitResp);
            MultiChangeAssistor.alertChange(networkLabelArray, networkTabPage);
        }

        private void network_connect_TextChanged(object sender, EventArgs e)
        {
            SingleChangeAssistor.alertChange(this.network_connect, this.network_connectLabel,
                networkUIManager.oldViewModel.Connect);
            MultiChangeAssistor.alertChange(networkLabelArray, networkTabPage);
        }

        private void network_connectResp_TextChanged(object sender, EventArgs e)
        {
            SingleChangeAssistor.alertChange(this.network_connectResp, this.network_connectRespLabel,
                networkUIManager.oldViewModel.ConnectResp);
            MultiChangeAssistor.alertChange(networkLabelArray, networkTabPage);
        }

        private void network_disconnect_TextChanged(object sender, EventArgs e)
        {
            SingleChangeAssistor.alertChange(this.network_disconnect, this.network_disconnectLabel,
                networkUIManager.oldViewModel.Disconnect);
            MultiChangeAssistor.alertChange(networkLabelArray, networkTabPage);
        }

        private void network_disconnectResp_TextChanged(object sender, EventArgs e)
        {
            SingleChangeAssistor.alertChange(this.network_disconnectResp, this.network_disconnectRespLabel,
                networkUIManager.oldViewModel.DisconnectResp);
            MultiChangeAssistor.alertChange(networkLabelArray, networkTabPage);
        }

        


        private void power_disableProbe_TextChanged(object sender, EventArgs e)
        {
            float temp;
            if (float.TryParse(this.power_disableProbe.Text, out temp) == false)
            {
                MessageBox.Show("数据格式错误！");
                this.power_disableProbe.Text = powerUIManager.oldViewModel.DisableProbe.ToString();
                return;
            }
            SingleChangeAssistor.alertChange(this.power_disableProbe, this.power_disableProbeLabel,
                powerUIManager.oldViewModel.DisableProbe.ToString());
            MultiChangeAssistor.alertChange(powerLabelArray, powerTabPage);
        }

        private void power_enableProbe_TextChanged(object sender, EventArgs e)
        {
            float temp;
            if (float.TryParse(this.power_enableProbe.Text, out temp) == false)
            {
                MessageBox.Show("数据格式错误！");
                this.power_enableProbe.Text = powerUIManager.oldViewModel.EnableProbe.ToString();
                return;
            }
            SingleChangeAssistor.alertChange(this.power_enableProbe, this.power_enableProbeLabel,
                powerUIManager.oldViewModel.EnableProbe.ToString());
            MultiChangeAssistor.alertChange(powerLabelArray, powerTabPage);
        }

        private void power_disableTelecom_TextChanged(object sender, EventArgs e)
        {
            float temp;
            if (float.TryParse(this.power_disableTelecom.Text, out temp) == false)
            {
                MessageBox.Show("数据格式错误！");
                this.power_disableTelecom.Text = powerUIManager.oldViewModel.DisableTelecom.ToString();
                return;
            }
            SingleChangeAssistor.alertChange(this.power_disableTelecom, this.power_disableTelecomLabel,
                powerUIManager.oldViewModel.DisableTelecom.ToString());
            MultiChangeAssistor.alertChange(powerLabelArray, powerTabPage);
        }


        private TabPage[] getChangedPages()
        {
            List<TabPage> result = new List<TabPage>();
            TabControl.TabPageCollection pages = mainTabControl.TabPages;
            for (int i = 0; i < pages.Count; i++)
            {
                if (pages[i].Text.EndsWith("*") == true)
                {
                    result.Add(pages[i]);
                }
            }
            return result.ToArray();
        }

        private void showConfirmDialog()
        {
            if (currentStatus == STATUS.CONNECTED)
            {
                TabPage[] changedPages = getChangedPages();
                if (changedPages.Length > 0)
                {
                    using (ConfirmDialog dlg = new ConfirmDialog(changedPages))
                    {
                        dlg.ShowDialog();
                        if (dlg.DialogResult == DialogResult.OK)
                        {
                            for (int i = 0; i < dlg.checkedPages.Count; i++)
                            {
                                string name = dlg.checkedPages[i].Name.Substring(0, dlg.checkedPages[i].Name.Length - 7);
                                uiManager.updateList.Add(name);
                            }
                            uiManager.updateType = UIManager.UpdateType.PART;
                            uiManager.updateDataModel();
                            readWriteProbe.writeProbe();
                        }
                        else if (dlg.DialogResult == DialogResult.Retry)
                        {
                            if (dlg.checkedPages.Count > 0)
                            {
                                mainTabControl.SelectTab(dlg.checkedPages[0]);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("没有修改过的数据内容！");
                }
            }
        }

        private void MainFrame_FormClosed(object sender, FormClosedEventArgs e)
        {
            finish();
        }

        public void finish()
        {
            if (currentStatus == STATUS.CONNECTED)
            {
                UICommonService.stopLocalServer();

                querySensor.finish();
                queryTime.finish();
                readWriteProbe.finish();
                modemManager.finish();
                queryConfiguration.finish();
                queryPower.finish();
            }
            
        }

        private void logger_delReading_Click(object sender, EventArgs e)
        {
            UILoggerService.deleteReading();
        }

        private void cfgDGV_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("数值超出范围或数据格式错误！");
        }

        private void backupButton_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            //saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Filter = "cfg files (*.cfg)|*.cfg|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    string temp = DGVSequenceAssistant.genWrittingString(this.cfgDGV);
                    CfgFileAssistant.clear();
                    CfgFileAssistant.add("[configuration]", temp);
                    CfgFileAssistant.add("[clock]", genClockSequence());
                    CfgFileAssistant.add("[logger]", genLoggerSequence());
                    CfgFileAssistant.add("[network]", genNetworkSequence());
                    CfgFileAssistant.add("[power]", genPowerSequence());
                    SerializationAssistant.writeToPlainFile(myStream, CfgFileAssistant.build());

                    myStream.Close();
                }
            }
        }

        private string genClockSequence()
        {
            DictionarySequenceAssistant clockAssistant = new DictionarySequenceAssistant();
            clockAssistant.add("interval", this.clock_samplingInterval.Text);
            return clockAssistant.build();
        }

        private string genPowerSequence()
        {
            DictionarySequenceAssistant powerAssistant = new DictionarySequenceAssistant();
            powerAssistant.add("disableTelecom", this.power_disableTelecom.Text);
            powerAssistant.add("enableProbe", this.power_enableProbe.Text);
            powerAssistant.add("disableProbe", this.power_disableProbe.Text);
            return powerAssistant.build();
        }

        private string genLoggerSequence()
        {
            DictionarySequenceAssistant loggerAssistant = new DictionarySequenceAssistant();
            loggerAssistant.add("loggerID", this.logger_ID.Text);
            loggerAssistant.add("sampleOrigin", this.logger_sampleOrigin.Text);
            loggerAssistant.add("sampleCount", this.logger_sampleCount.Text);
            loggerAssistant.add("dialIn", this.logger_dialInUp.Text);
            loggerAssistant.add("destURL", this.logger_destURL.Text);
            loggerAssistant.add("connectOut", this.logger_connectOut.Text);
            loggerAssistant.add("responseOut", this.logger_respOut.Text);
            loggerAssistant.add("baudRate", this.logger_baudRate.Text);
            loggerAssistant.add("parity", this.logger_parity.Text);
            return loggerAssistant.build();
        }

        private string genNetworkSequence()
        {
            DictionarySequenceAssistant networkAssistant = new DictionarySequenceAssistant();
            networkAssistant.add("userName", this.network_userName.Text);
            //networkAssistant.add("password", this.network_pwd.Text);
            networkAssistant.add("dialInEnable", this.network_dialInEnable.Text);
            networkAssistant.add("dialInEnableResp", this.network_dialInEnableResp.Text);
            networkAssistant.add("dialInDisable", this.network_dialInDisable.Text);
            networkAssistant.add("dialInDisableResp", this.network_dialInDisableResp.Text);
            networkAssistant.add("init", this.network_init.Text);
            networkAssistant.add("initResp", this.network_initResp.Text);
            networkAssistant.add("connect", this.network_connect.Text);
            networkAssistant.add("connectResp", this.network_connectResp.Text);
            networkAssistant.add("disconnect", this.network_disconnect.Text);
            networkAssistant.add("disconnectResp", this.network_disconnectResp.Text);
            return networkAssistant.build();
        }

        private void restoreButton_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            // Insert code to read the stream here.
                            string whole = SerializationAssistant.readFromPlainFile(myStream);
                            CfgFileAssistant.clear();
                            CfgFileAssistant.parse(whole);
                            string temp = CfgFileAssistant.get("configuration");
                            if (temp != null)
                            {
                                DataGridView dgv = DGVSequenceAssistant.genDGV(temp);
                                DGVSequenceAssistant.updateDGV(this.cfgDGV, dgv);
                            }
                            temp = CfgFileAssistant.get("clock");
                            if (temp != null)
                            {
                                restoreClock(temp);
                            }
                            temp = CfgFileAssistant.get("logger");
                            if (temp != null)
                            {
                                restoreLogger(temp);
                            }
                            temp = CfgFileAssistant.get("network");
                            if (temp != null)
                            {
                                restoreNetwork(temp);
                            }
                            temp = CfgFileAssistant.get("power");
                            if (temp != null)
                            {
                                restorePower(temp);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void restoreClock(string temp)
        {
            DictionarySequenceAssistant clockAssistant = new DictionarySequenceAssistant();
            clockAssistant.parse(temp);
            string value = clockAssistant.get("interval");
            if (value != null)
            {
                this.clock_samplingInterval.Text = value;
            }
        }

        private void restoreLogger(string temp)
        {
            DictionarySequenceAssistant loggerAssistant = new DictionarySequenceAssistant();
            loggerAssistant.parse(temp);
            string value = loggerAssistant.get("loggerID");
            if (value != null)
            {
                this.logger_ID.Text = value;
            }

            value = loggerAssistant.get("sampleOrigin");
            if (value != null)
            {
                this.logger_sampleOrigin.Text = value;
            }

            value = loggerAssistant.get("sampleCount");
            if (value != null)
            {
                this.logger_sampleCount.Text = value;
            }

            value = loggerAssistant.get("dialIn");
            if (value != null)
            {
                this.logger_dialInUp.Text = value;
            }

            value = loggerAssistant.get("destURL");
            if (value != null)
            {
                this.logger_destURL.Text = value;
            }

            value = loggerAssistant.get("connectOut");
            if (value != null)
            {
                this.logger_connectOut.Text = value;
            }

            value = loggerAssistant.get("responseOut");
            if (value != null)
            {
                this.logger_respOut.Text = value;
            }

            value = loggerAssistant.get("baudRate");
            if (value != null)
            {
                this.logger_baudRate.Text = value;
            }

            value = loggerAssistant.get("parity");
            if (value != null)
            {
                this.logger_parity.Text = value;
            }
        }

        private void restoreNetwork(string temp)
        {
            DictionarySequenceAssistant networkAssistant = new DictionarySequenceAssistant();
            networkAssistant.parse(temp);
            string value = networkAssistant.get("userName");
            if (value != null)
            {
                this.network_userName.Text = value;
            }

            value = networkAssistant.get("dialInEnable");
            if (value != null)
            {
                this.network_dialInEnable.Text = value;
            }

            value = networkAssistant.get("dialInEnableResp");
            if (value != null)
            {
                this.network_dialInEnableResp.Text = value;
            }

            value = networkAssistant.get("dialInDisable");
            if (value != null)
            {
                this.network_dialInDisable.Text = value;
            }

            value = networkAssistant.get("dialInDisableResp");
            if (value != null)
            {
                this.network_dialInDisableResp.Text = value;
            }

            value = networkAssistant.get("init");
            if (value != null)
            {
                this.network_init.Text = value;
            }

            value = networkAssistant.get("initResp");
            if (value != null)
            {
                this.network_initResp.Text = value;
            }

            value = networkAssistant.get("connect");
            if (value != null)
            {
                this.network_connect.Text = value;
            }

            value = networkAssistant.get("connectResp");
            if (value != null)
            {
                this.network_connectResp.Text = value;
            }

            value = networkAssistant.get("disconnect");
            if (value != null)
            {
                this.network_disconnect.Text = value;
            }

            value = networkAssistant.get("disconnectResp");
            if (value != null)
            {
                this.network_disconnectResp.Text = value;
            }
        }

        private void restorePower(string temp)
        {
            DictionarySequenceAssistant powerAssistant = new DictionarySequenceAssistant();
            powerAssistant.parse(temp);
            string value = powerAssistant.get("disableTelecom");
            if (value != null)
            {
                this.power_disableTelecom.Text = value;
            }

            value = powerAssistant.get("disableProbe");
            if (value != null)
            {
                this.power_disableProbe.Text = value;
            }

            value = powerAssistant.get("enableProbe");
            if (value != null)
            {
                this.power_enableProbe.Text = value;
            }
        }

        private void modem_textbox_TextChanged(object sender, EventArgs e)
        {
            modem_textbox.ScrollToCaret();
        }

        private void modem_atCmdText_Validating(object sender, CancelEventArgs e)
        {
            string temp = this.modem_atCmdText.Text;
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] < 0 || temp[i] > 127)
                {
                    MessageBox.Show("输入中包含非法字符！");
                    this.modem_atCmdText.Text = "";
                }
            }
        }

        private void cfgDGV_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (this.cfgDGV.Columns["addr"].Index ==
        e.ColumnIndex && e.RowIndex >= 0)
            {
                Icon img = PConfigUI.Properties.Resources.water;
                int temp;
                if (int.TryParse(e.FormattedValue.ToString(), out temp) != true && temp > 5)
                {
                    img = PConfigUI.Properties.Resources.water;
                }


                Rectangle newRect = new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Height,
                    e.CellBounds.Height);

                using (Brush gridBrush = new SolidBrush(this.cfgDGV.GridColor), backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                {
                    using (Pen gridLinePen = new Pen(gridBrush, 2))
                    {
                        // Erase the cell.
                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds);

                        //划线
                        Point p1 = new Point(e.CellBounds.Left + e.CellBounds.Width, e.CellBounds.Top);
                        Point p2 = new Point(e.CellBounds.Left + e.CellBounds.Width, e.CellBounds.Top + e.CellBounds.Height);
                        Point p3 = new Point(e.CellBounds.Left, e.CellBounds.Top + e.CellBounds.Height);
                        Point[] ps = new Point[] { p1, p2, p3 };
                        e.Graphics.DrawLines(gridLinePen, ps);

                        //画图标
                        e.Graphics.DrawIcon(img, newRect);
                        //画字符串
                        e.Graphics.DrawString(e.FormattedValue.ToString(), e.CellStyle.Font, Brushes.Black,
                            e.CellBounds.Left + 20, e.CellBounds.Top + 5, StringFormat.GenericDefault);
                        e.Handled = true;
                    }
                }
            }
        }

        private void TestDGV_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (this.TestDGV.Columns["selAddr"].Index ==
        e.ColumnIndex && e.RowIndex >= 0)
            {
                Icon img = PConfigUI.Properties.Resources.water;
                int temp;
                if (int.TryParse(e.FormattedValue.ToString(), out temp) != true && temp > 5)
                {
                    img = PConfigUI.Properties.Resources.water;
                }


                Rectangle newRect = new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Height,
                    e.CellBounds.Height);

                using (Brush gridBrush = new SolidBrush(this.cfgDGV.GridColor), backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                {
                    using (Pen gridLinePen = new Pen(gridBrush, 2))
                    {
                        // Erase the cell.
                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds);

                        //划线
                        Point p1 = new Point(e.CellBounds.Left + e.CellBounds.Width, e.CellBounds.Top);
                        Point p2 = new Point(e.CellBounds.Left + e.CellBounds.Width, e.CellBounds.Top + e.CellBounds.Height);
                        Point p3 = new Point(e.CellBounds.Left, e.CellBounds.Top + e.CellBounds.Height);
                        Point[] ps = new Point[] { p1, p2, p3 };
                        e.Graphics.DrawLines(gridLinePen, ps);

                        //画图标
                        e.Graphics.DrawIcon(img, newRect);
                        //画字符串
                        e.Graphics.DrawString(e.FormattedValue.ToString(), e.CellStyle.Font, Brushes.Black,
                            e.CellBounds.Left + 20, e.CellBounds.Top + 5, StringFormat.GenericDefault);
                        e.Handled = true;
                    }
                }
            }
        }



    }
}
