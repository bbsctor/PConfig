using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;

namespace PConfigBase.BaseModelImpl.BaseDataModelImpl
{
    public class SensorDataModel : BasicModel, IDataModel
    {
        public int addr;
        public float celibrateValue;
        public float depth;
        public float equationA;
        public float equationB;
        public float equationC;
        public ushort highAir;
        public ushort lowWater;
        public Boolean isSelected;
        public ushort rawCount;

        public virtual void update(IModel model)
        {
            update(model, new string[]{"depth", "equationA", "equationB",
                "equationC", "highAir", "lowWater", "isSelected"});
        }

        public void update(IDataModel model, string[] fields)
        {
            base.update(model, fields);
        }

        public override bool Equals(object obj)
        {
            SensorDataModel model = obj as SensorDataModel;
            if (model != null)
            {
                if (this.addr != model.addr)
                {
                    return false;
                }
                if (this.depth != model.depth)
                {
                    return false;
                }
                if (this.equationA != model.equationA)
                {
                    return false;
                }
                if (this.equationB != model.equationB)
                {
                    return false;
                }
                if (this.equationC != model.equationC)
                {
                    return false;
                }
                if (this.rawCount != model.rawCount)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
