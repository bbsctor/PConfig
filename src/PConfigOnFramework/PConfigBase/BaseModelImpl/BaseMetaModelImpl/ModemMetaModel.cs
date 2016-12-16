using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;

namespace PConfigBase.BaseModelImpl.BaseMetaModelImpl
{
    public class ModemMetaModel:MetaModel
    {
        public enum TYPE {OPENSESSION, SENDAT, TEST, UPLOAD};
        public TYPE type;
    }
}
