using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PConfigProtocol.FrameDef;
using ProtocolFrame.ElementDef.BasicImpl;

namespace PConfigProtocol.FrameDef.Configuration
{
    /*
    数据长度	功能码	待定	                修改的传感器编号	传感器深度	Low/Water	High/Air	Equation（浮点数）
							                                                                A	B	C
    1AH	        4BH	    05(sensorNum) 18 01 02	1 Byte	            4 Byte	    2 Byte	    2 Byte	    4 Byte	4 Byte	4 Byte 
    */
    public class Request_4BFrame:CommonRequestFrame
    {
        public static BasicElement unknown;
        public static BasicElement addr;
        public static BasicElement depth;
        public static BasicElement lowWater;
        public static BasicElement highAir;
        public static BasicElement equationA;
        public static BasicElement equationB;
        public static BasicElement equationC;

        static Request_4BFrame()
        {
            unknown = new BasicElement();
            unknown.Size = 4;

            addr = new BasicElement();
            addr.Size = 1;

            depth = new BasicElement();
            depth.Size = 4;

            lowWater = new BasicElement();
            lowWater.Size = 2;

            highAir = new BasicElement();
            highAir.Size = 2;

            equationA = new BasicElement();
            equationA.Size = 4;

            equationB = new BasicElement();
            equationB.Size = 4;

            equationC = new BasicElement();
            equationC.Size = 4;
        }

        public Request_4BFrame(byte sensorNO, byte addr, byte[] depth, byte[] lowWater, byte[] highAir,
            byte[] equationA, byte[] equationB, byte[] equationC)
        {
            CommonRequestFrame.funcNo.Data = new byte[]{0x4B};

            Request_4BFrame.unknown.Data = new byte[] { sensorNO, 0x18, 0x01, 0x02 };
            Request_4BFrame.addr.Data = new byte[]{addr};
            Request_4BFrame.depth.Data = depth;
            Request_4BFrame.lowWater.Data = lowWater;
            Request_4BFrame.highAir.Data = highAir;
            Request_4BFrame.equationA.Data = equationA;
            Request_4BFrame.equationB.Data = equationB;
            Request_4BFrame.equationC.Data = equationC;

            Request_4BFrame.data.RelateElements = new BasicElement[]{
                Request_4BFrame.unknown,
                Request_4BFrame.addr,
                Request_4BFrame.depth,
                Request_4BFrame.lowWater,
                Request_4BFrame.highAir,
                Request_4BFrame.equationA,
                Request_4BFrame.equationB,
                Request_4BFrame.equationC
            };

            Request_4BFrame.data.build();
            preBuild(0x4B, Request_4BFrame.data.Data);
            build();
        }
    }
}
