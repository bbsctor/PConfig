using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;

namespace PConfigBase.BaseModelImpl.BaseMetaModelImpl
{
    public class TestMetaModel:MetaModel
    {
        public enum TYPE {RAW,CELIBRATE };
        public TYPE type;
    }
}
