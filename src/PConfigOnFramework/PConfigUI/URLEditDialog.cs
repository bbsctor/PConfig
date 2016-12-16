using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PConfigBase.BaseModelImpl.BaseViewModelImpl;

namespace PConfigUI
{
    public partial class URLEditDialog : Form
    {
        private URLViewModel model;

        public URLEditDialog(URLViewModel vModel)
        {
            InitializeComponent();
            model = vModel;
            this.url_password.Text = model.Password;
            this.url_path.Text = model.Path;
            this.url_port.Text = model.Port;
            this.url_servAddr.Text = model.ServerAddr;
            this.url_userName.Text = model.UserName;

        }

        private void url_OK_Click(object sender, EventArgs e)
        {
            model.Password = this.url_password.Text;
            model.Path = this.url_path.Text;
            model.Port = this.url_port.Text;
            model.ServerAddr = this.url_servAddr.Text;
            model.UserName = this.url_userName.Text;
        }
    }
}
