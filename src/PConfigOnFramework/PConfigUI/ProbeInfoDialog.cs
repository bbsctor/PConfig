using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ConfigFrame.UITask;
using PConfigUI.UITaskImpl;
using PConfigUI.UIUtil;
using PConfigBase.BaseModelImpl.BaseViewModelImpl;
using PConfigUI.UIServiceImpl;
using PConfigBase.BaseModelImpl.BaseDataModelImpl;
using PConfigBase.BaseModelImpl.ModelConverterImpl;

namespace PConfigUI
{
    public partial class ProbeInfoDialog : Form
    {
        private ProbeInfoViewModel oldViewModel;
        public bool isWrite;

        public ProbeInfoDialog(ProbeInfoViewModel vModel)
        {
            InitializeComponent();
            
            updateUI(vModel);
        }

        private bool inputValidating()
        {
            if (this.probeInfo_addr.Text == "")
            {
                this.probeInfo_addr.Text = oldViewModel.Addr.ToString();
            }
            
            return true;
        }

        private void updateUI(ProbeInfoViewModel vModel)
        {
            oldViewModel = vModel;

            this.probeInfo_type.Text = vModel.Type;
            this.probeInfo_serialNumber.Text = vModel.SerialNumber;
            this.probeInfo_addr.Text = vModel.Addr.ToString();

            this.probeInfo_version.Text = vModel.Version;
        }

        public ushort getAddr()
        {
            return ushort.Parse(probeInfo_addr.Text);
        }

        public void setType(string type)
        {
            this.probeInfo_type.Text = type;
        }

        public void setSerialNumber(string sn)
        {
            this.probeInfo_serialNumber.Text = sn;
        }

        public void setAddr(string addr)
        {
            this.probeInfo_addr.Text = addr;
        }

        public void setVersion(string v)
        {
            this.probeInfo_version.Text = v;
        }

        private void probeInfo_refresh_Click(object sender, EventArgs e)
        {
            inputValidating();
            if (this.probeInfo_addr.Text.Equals(oldViewModel.Addr.ToString()) == false)
            {
                isWrite = true;
            }
        }

        private void probeInfo_addr_TextChanged(object sender, EventArgs e)
        {
            ushort temp;
            if (ushort.TryParse(this.probeInfo_addr.Text, out temp) == false)
            {
                MessageBox.Show("地址格式为1-65534之间的整数！");
                return;
            }
            SingleChangeAssistor.alertChange(this.probeInfo_addr, probeInfo_addrLabel, oldViewModel.Addr.ToString());
        }
    }
}
