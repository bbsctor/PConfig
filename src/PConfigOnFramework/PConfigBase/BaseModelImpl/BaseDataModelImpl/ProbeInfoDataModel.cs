using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;

namespace PConfigBase.BaseModelImpl.BaseDataModelImpl
{
    public class ProbeInfoDataModel : BasicModel, IDataModel
    {
        public byte[] type;
        public byte[] serialNumber;
        public ushort addr;
        public byte bigVersion;
        public byte middleVersion;
        public ushort littleVersion;

        public virtual void update(IModel model)
        {
            update(model, new string[]{"addr"});
        }

        public override bool Equals(object obj)
        {
            ProbeInfoDataModel model = obj as ProbeInfoDataModel;
            if (model != null)
            {
                if (this.addr != model.addr)
                {
                    return false;
                }
                
                return true;
            }
            return false;
        }
    }
}
