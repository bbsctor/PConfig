using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;
using Microsoft.Win32;
using ConfigFrame.UITask;
using ConfigFrame.Util;
using PConfigUI.UIServiceImpl;
using PConfigUI.UIUtil;
using PConfigBase.BaseModelImpl.BaseViewModelImpl;
using PConfigBase.BaseModelImpl.BaseDataModelImpl;
using PConfigBase.BaseModelImpl.ModelConverterImpl;

namespace PConfigUI
{
    public partial class SerialDialog : Form
    {
        private SerialUIManager serialManager;
        public bool noData;

        public SerialDialog()
        {
            InitializeComponent();

            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            serial_port.Items.AddRange(ports);
            serial_port.SelectedIndex = 0;

            string[] baudRate = new string[] { "300", "600", "1200", "2400", "4800", 
                "9600", "19200", "38400", "57600", "115200"};
            serial_baudRate.Items.AddRange(baudRate);

            serial_baudRate.SelectedIndex = 0;

            string fileName = "probeConfig.nme";
            FileStream stream = null;
            if (File.Exists(fileName))
            {
                stream = File.OpenRead(fileName);
                string whole = SerializationAssistant.readFromPlainFile(stream);
                CfgFileAssistant.clear();
                CfgFileAssistant.parse(whole);
                string temp = CfgFileAssistant.get("connection");
                if (temp != null)
                {
                    restoreConnection(temp);
                }

                stream.Close();
            }

            

            serialManager = new SerialUIManager(this);
            serialManager.updateUI();
        }

        private string genConnectionSequence()
        {
            DictionarySequenceAssistant connectionAssistant = new DictionarySequenceAssistant();
            connectionAssistant.add("port", this.serial_port.Text);
            connectionAssistant.add("baudRate", this.serial_baudRate.Text);
            return connectionAssistant.build();
        }

        private void restoreConnection(string temp)
        {
            DictionarySequenceAssistant connectionAssistant = new DictionarySequenceAssistant();
            connectionAssistant.parse(temp);
            string value = connectionAssistant.get("port");
            if (value != null)
            {
                this.serial_port.Text = value;
            }
            value = connectionAssistant.get("baudRate");
            if (value != null)
            {
                this.serial_baudRate.Text = value;
            }
        }

        private void serial_connect_Click(object sender, EventArgs e)
        {
            if (serialManager.inputValidating())
            {
                serialManager.updateDataModel();
                string fileName = "probeConfig.nme";
                FileStream stream = null;
                if (File.Exists(fileName))
                {
                    stream = File.OpenWrite(fileName);
                }
                else
                {
                    stream = File.Create(fileName);
                }
                CfgFileAssistant.clear();
                CfgFileAssistant.add("[connection]", genConnectionSequence());
                SerializationAssistant.writeToPlainFile(stream, CfgFileAssistant.build());
                stream.Close();
            }
            else
            {
                noData = true;
            }
        }

        private class SerialUIManager:BasicBlockUIManager
        {
            private SerialDialog serialDialog;

            public SerialUIManager(Control control)
                : base(control)
            {
                this.serialDialog = (SerialDialog)control;
            }

            public override bool inputValidating()
            {
                if (serialDialog.serial_port.Text == "" || serialDialog.serial_baudRate.Text == "")
                {
                    MessageBox.Show("请设置连接参数！");
                    return false;
                }
                return true;

            }

            public override void updateDataModel()
            {
                SerialViewModel vModel = new SerialViewModel();
                vModel.Port = serialDialog.serial_port.Text;
                vModel.BaudRate = System.Convert.ToInt32(serialDialog.serial_baudRate.Text);
                //vModel.Port = "COM6";
                //vModel.BaudRate = System.Convert.ToInt32("9600");

                ConnectDataModel model = (ConnectDataModel)SerialConverter.getInstance().genDataModel(vModel);
                UISerialService.updateDataModel(model);
            }
            public override void updateUI()
            {
                SerialViewModel vModel = UISerialService.getViewModel();
                serialDialog.serial_baudRate.Text = System.Convert.ToString(vModel.BaudRate);
                serialDialog.serial_port.Text = vModel.Port;
                serialDialog.serial_loggerID.Text = vModel.LoggerID;
                if (vModel.IsConnected == true)
                {
                    serialDialog.serial_port.Enabled = false;
                    serialDialog.serial_baudRate.Enabled = false;
                    serialDialog.serial_loggerID.Enabled = false;
                    serialDialog.serial_connect.Text = "断开连接";
                }
                else if (vModel.IsConnected == false)
                {
                    serialDialog.serial_port.Enabled = true;
                    serialDialog.serial_baudRate.Enabled = true;
                    serialDialog.serial_loggerID.Enabled = true;
                    serialDialog.serial_connect.Text = "建立连接";
                }
            }
        }
    }
}
