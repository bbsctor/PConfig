using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;

namespace PConfigBase.BaseModelImpl.BaseViewModelImpl
{
    public class SensorViewModel : BasicModel, IViewModel
    {
        public SensorViewModel(int addr, float depth,string coefStr, 
                            ushort highAir, ushort lowWater, Boolean isSelected)
        {
            this.addr = addr;
            this.depth = depth;
            this.CoefStr = coefStr;
            this.highAir = highAir;
            this.lowWater = lowWater;
            this.isSelected = isSelected;
        }

        public SensorViewModel()
        {
            // TODO: Complete member initialization
        }
        private int addr;

        public int Addr
        {
            get { return addr; }
            set { addr = value; }
        }
        public float celibrateValue;

        public string CelibrateValue
        {
            get { return celibrateValue.ToString("0.000000"); }
            set {
                float temp;
                float.TryParse(value, out temp);
                celibrateValue = temp;
                }
        }
        private float depth;

        public float Depth
        {
            get { return depth; }
            set { depth = value; }
        }
        private float equationA;

        public float EquationA
        {
            get { return equationA; }
            set { equationA = value; }
        }
        private float equationB;

        public float EquationB
        {
            get { return equationB; }
            set { equationB = value; }
        }
        private float equationC;

        public float EquationC
        {
            get { return equationC; }
            set { equationC = value; }
        }


        public string CoefStr
        {
            get { return equationA.ToString("0.000000") + ";" 
                + equationB.ToString("0.000000") + ";" + equationC.ToString("0.000000"); }
            set { parseCoefStr(value); }
        }

        private void parseCoefStr(string value)
        {
            string[] buff = value.Split(new Char[]{';'});

            equationA = float.Parse(buff[0]);
            equationB = float.Parse(buff[1]);
            equationC = float.Parse(buff[2]);
        }

        private ushort highAir;

        public ushort HighAir
        {
            get { return highAir; }
            set { highAir = value; }
        }
        private ushort lowWater;

        public ushort LowWater
        {
            get { return lowWater; }
            set { lowWater = value; }
        }
        private Boolean isSelected;

        public Boolean IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; }
        }
        private ushort rawCount;

        public ushort RawCount
        {
            get { return rawCount; }
            set { rawCount = value; }
        }

        public class ModelCompare : IComparer<SensorViewModel>
        {
            public int Compare(SensorViewModel x, SensorViewModel y)
            {
                int retval = 0;
                if (x != null && y != null)
                {
                    if (x.depth < y.depth)
                    {
                        retval = -1;
                    }
                    else if (x.depth > y.depth)
                    {
                        retval = 1;
                    }
                    else
                    {
                        if (x.addr < y.addr)
                        {
                            retval = -1;
                        }
                        else if (x.addr > y.addr)
                        {
                            retval = 1;
                        }
                    }
                }
                return retval;
            }
        }
    }
}
