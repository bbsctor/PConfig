using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;

namespace PConfigBase.BaseModelImpl.BaseDataModelImpl
{
    public class NetworkDataModel : BasicModel, IDataModel
    {
        public byte[] userName;
        public byte[] password;
        public byte[] dialInEnable;
        public byte[] dialInEnableResp;
        public byte[] dialInDisable;
        public byte[] dialInDisableResp;
        public byte[] init;
        public byte[] initResp;
        public byte[] connect;
        public byte[] connectResp;
        public byte[] disconnect;
        public byte[] disconnectResp;

        public override bool Equals(object obj)
        {
            NetworkDataModel model = obj as NetworkDataModel;
            if (model != null)
            {
                if (arrayEqual(this.userName, model.userName) == false)
                {
                    return false;
                }
                if (arrayEqual(this.password, model.password) == false)
                {
                    return false;
                }
                if (arrayEqual(this.dialInEnable, model.dialInEnable) == false)
                {
                    return false;
                }
                if (arrayEqual(this.dialInEnableResp, model.dialInEnableResp) == false)
                {
                    return false;
                }
                if (arrayEqual(this.dialInDisable, model.dialInDisable) == false)
                {
                    return false;
                }
                if (arrayEqual(this.dialInDisableResp, model.dialInDisableResp) == false)
                {
                    return false;
                }
                if (arrayEqual(this.init, model.init) == false)
                {
                    return false;
                }
                if (arrayEqual(this.initResp, model.initResp) == false)
                {
                    return false;
                }
                if (arrayEqual(this.connect, model.connect) == false)
                {
                    return false;
                }
                if (arrayEqual(this.connectResp, model.connectResp) == false)
                {
                    return false;
                }
                if (arrayEqual(this.disconnect, model.disconnect) == false)
                {
                    return false;
                }
                if (arrayEqual(this.disconnectResp, model.disconnectResp) == false)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
