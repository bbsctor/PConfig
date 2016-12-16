using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;

namespace PConfigBase.BaseModelImpl.BaseMetaModelImpl
{
    public class PowerMetaModel : MetaModel
    {
        public enum TYPE {OBSERVE, ENABLEPROBE, DISABLEPROBE, DISABLETELECOM };
        public TYPE type;
    }
}
