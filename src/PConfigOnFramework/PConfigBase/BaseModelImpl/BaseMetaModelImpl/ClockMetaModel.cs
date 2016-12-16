using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;

namespace PConfigBase.BaseModelImpl.BaseMetaModelImpl
{
    public class ClockMetaModel : MetaModel
    {
        public enum TYPE{DATETIME, SAMPLINGINTERVAL };
        public TYPE type;
    }
}
