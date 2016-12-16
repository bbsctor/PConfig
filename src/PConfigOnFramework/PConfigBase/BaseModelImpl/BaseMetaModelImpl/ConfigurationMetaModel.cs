using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;

namespace PConfigBase.BaseModelImpl.BaseMetaModelImpl
{
    public class ConfigurationMetaModel : MetaModel
    {
        public enum TYPE { SENSOR, SENSORNUM, COUNT, SELECTED };
        public TYPE type;
    }
}
