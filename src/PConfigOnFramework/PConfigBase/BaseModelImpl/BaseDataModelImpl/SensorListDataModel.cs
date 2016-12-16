using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using ConfigFrame.BaseModel;

namespace PConfigBase.BaseModelImpl.BaseDataModelImpl
{
    public class SensorListDataModel : List<SensorDataModel>, IDataModel
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

        public void cleanRowCount()
        {
            for (int i = 0; i < this.Count; i++)
            {
                this[i].rawCount = 0;
            }
        }

        public void cleanCelibrate()
        {
            for (int i = 0; i < this.Count; i++)
            {
                this[i].celibrateValue = 0;
            }
        }

        public void updateBasicSensor(SensorDataModel model)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].addr == model.addr)
                {
                    this[i].update(model);
                    return;
                }
            }
            this.Add(model);
        }

        public string[] update(IModel iModel, string[] fieldName)
        {
            if (iModel != null)
            {
                SensorDataModel model = iModel as SensorDataModel;
                for (int i = 0; i < this.Count; i++)
                {
                    if (this[i].addr == model.addr)
                    {
                        this[i].update(model, fieldName);
                        return null;
                    }
                }
                this.Add(model);
            }
            
            return null;
        }

        public void update(IModel model)
        {
            this.modified = true;
            SensorListDataModel listModel = model as SensorListDataModel;
            if (listModel != null)
            {
                for (int i = 0; i < listModel.Count; i++)
                {
                    updateBasicSensor(listModel[i]);
                }
            }
        }

        public string[] compare(IModel model)
        {
            return null;
        }
    }
}
