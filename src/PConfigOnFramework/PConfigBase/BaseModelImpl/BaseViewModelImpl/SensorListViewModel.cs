using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;

namespace PConfigBase.BaseModelImpl.BaseViewModelImpl
{
    public class SensorListViewModel:List<SensorViewModel>, IViewModel
    {
        bool modified;

        public bool Modified
        {
            get { return modified; }
            set { modified = value; }
        }

        public List<string> ModifiedFieldList
        {
            get { return null; }
            set { }
        }

        public void update(IModel model)
        {
            
        }

        public string[] update(IModel model, string[] fields)
        {
            return null;
        }

        public string[] compare(IModel model)
        {
            return null;
        }
    }
}
