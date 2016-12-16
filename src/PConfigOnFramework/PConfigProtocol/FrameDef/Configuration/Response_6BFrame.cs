using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PConfigProtocol.FrameDef;
using ProtocolFrame.ElementDef.BasicImpl;

namespace PConfigProtocol.FrameDef.Configuration
{
    //数据长度	待定	    传感器编号	传感器深度	Low/Water	High/Air	Equation
    //                                                                      A	    B	    C
    //19H	    05 18 01 02	1Byte	    4 Byte	    2 Byte	    2 Byte	    4 Byte	4 Byte	4 Byte
    public class Response_6BFrame:CommonResponseFrame
    {
        public static BasicElement unknown;
        public static BasicElement addr;
        public static BasicElement depth;
        public static BasicElement lowWater;
        public static BasicElement highAir;
        public static BasicElement equationA;
        public static BasicElement equationB;
        public static BasicElement equationC;

        static Response_6BFrame()
        {
            unknown = new BasicElement();
            addr = new BasicElement();
            depth = new BasicElement();
            lowWater = new BasicElement();
            highAir = new BasicElement();
            equationA = new BasicElement();
            equationB = new BasicElement();
            equationC = new BasicElement();
        }

        public Response_6BFrame()
        {
            CommonResponseFrame.data.RelateElements = new BasicElement[]{
                Response_6BFrame.unknown,
                Response_6BFrame.addr,
                Response_6BFrame.depth,
                Response_6BFrame.lowWater,
                Response_6BFrame.highAir,
                Response_6BFrame.equationA,
                Response_6BFrame.equationB,
                Response_6BFrame.equationC
            };
        }

        public enum DataMode { TOTAL, DETAIL };
        public static DataMode currentMode;

        public void setDataMode(DataMode mode)
        {
            switch (mode)
            {
                case DataMode.DETAIL:
                    unknown.Size = 4;
                    addr.Size = 1;
                    depth.Size = 4;
                    lowWater.Size = 2;
                    highAir.Size = 2;
                    equationA.Size = 4;
                    equationB.Size = 4;
                    equationC.Size = 4;
                    currentMode = DataMode.DETAIL;
                    break;
                case DataMode.TOTAL:
                    unknown.Size = 0;
                    addr.Size = 1;
                    depth.Size = 0;
                    lowWater.Size = 0;
                    highAir.Size = 0;
                    equationA.Size = 0;
                    equationB.Size = 0;
                    equationC.Size = 0;
                    currentMode = DataMode.TOTAL;
                    break;
            }
        }

        public override bool parse()
        {
            preParse();
            return base.parse();
        }

        private void preParse()
        {
            if (base.Data.Length == 0x12)
            {
                setDataMode(DataMode.TOTAL);
            }
            else
            {
                setDataMode(DataMode.DETAIL);
            }
        }
    }
}
