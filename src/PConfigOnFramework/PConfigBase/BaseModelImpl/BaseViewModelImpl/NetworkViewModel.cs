using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;

namespace PConfigBase.BaseModelImpl.BaseViewModelImpl
{
    public class NetworkViewModel : BasicModel, IViewModel
    {
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private string dialInEnable;

        public string DialInEnable
        {
            get { return dialInEnable; }
            set { dialInEnable = value; }
        }
        private string dialInEnableResp;

        public string DialInEnableResp
        {
            get { return dialInEnableResp; }
            set { dialInEnableResp = value; }
        }
        private string dialInDisable;

        public string DialInDisable
        {
            get { return dialInDisable; }
            set { dialInDisable = value; }
        }
        private string dialInDisableResp;

        public string DialInDisableResp
        {
            get { return dialInDisableResp; }
            set { dialInDisableResp = value; }
        }
        private string init;

        public string Init
        {
            get { return init; }
            set { init = value; }
        }
        private string initResp;

        public string InitResp
        {
            get { return initResp; }
            set { initResp = value; }
        }
        private string connect;

        public string Connect
        {
            get { return connect; }
            set { connect = value; }
        }
        private string connectResp;

        public string ConnectResp
        {
            get { return connectResp; }
            set { connectResp = value; }
        }
        private string disconnect;

        public string Disconnect
        {
            get { return disconnect; }
            set { disconnect = value; }
        }
        private string disconnectResp;

        public string DisconnectResp
        {
            get { return disconnectResp; }
            set { disconnectResp = value; }
        }
    }
}
