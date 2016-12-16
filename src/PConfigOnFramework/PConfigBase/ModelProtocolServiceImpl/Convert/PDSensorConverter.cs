using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;
using ConfigFrame.Protocol;
using ConfigFrame.Protocol.Complex;
using PConfigBase.BaseModelImpl.BaseDataModelImpl;
using PConfigBase.ProtocolImpl;
using PConfigProtocol.FrameDef.Configuration;

namespace PConfigBase.ModelProtocolServiceImpl.Convert
{
    public class PDSensorConverter:IProtocolDModelConverter
    {
        public static SensorDataModel parseSensorData(IComplexResponse resp)
        {
            SensorDataModel model = new SensorDataModel();

            byte[] temp;

            model.addr = (int)Response_6BFrame.addr.Data[0];

            temp = Response_6BFrame.depth.Data;
            System.Array.Reverse(temp, 0, 4);
            model.depth = BitConverter.ToSingle(temp, 0);

            temp = Response_6BFrame.lowWater.Data;
            System.Array.Reverse(temp, 0, 2);
            model.lowWater = BitConverter.ToUInt16(temp, 0);

            temp = Response_6BFrame.highAir.Data;
            System.Array.Reverse(temp, 0, 2);
            model.highAir = BitConverter.ToUInt16(temp, 0);

            temp = Response_6BFrame.equationA.Data;
            System.Array.Reverse(temp, 0, 4);
            model.equationA = BitConverter.ToSingle(temp, 0);

            temp = Response_6BFrame.equationB.Data;
            System.Array.Reverse(temp, 0, 4);
            model.equationB = BitConverter.ToSingle(temp, 0);

            temp = Response_6BFrame.equationC.Data;
            System.Array.Reverse(temp, 0, 4);
            model.equationC = BitConverter.ToSingle(temp, 0);

            return model;
        }

        //public static SensorDataModel parseSensorData(IComplexResponse resp)
        //{
        //    SensorDataModel model = new SensorDataModel();

        //    byte[] temp;
        //    resp.ParaMap.TryGetValue("addr", out temp);
        //    model.addr = (int)temp[0];

        //    resp.ParaMap.TryGetValue("depth", out temp);
        //    System.Array.Reverse(temp, 0, 4);
        //    model.depth = BitConverter.ToSingle(temp, 0);

        //    resp.ParaMap.TryGetValue("lowWater", out temp);
        //    System.Array.Reverse(temp, 0, 2);
        //    model.lowWater = BitConverter.ToUInt16(temp, 0);

        //    resp.ParaMap.TryGetValue("highAir", out temp);
        //    System.Array.Reverse(temp, 0, 2);
        //    model.highAir = BitConverter.ToUInt16(temp, 0);

        //    resp.ParaMap.TryGetValue("equationA", out temp);
        //    System.Array.Reverse(temp, 0, 4);
        //    model.equationA = BitConverter.ToSingle(temp, 0);

        //    resp.ParaMap.TryGetValue("equationB", out temp);
        //    System.Array.Reverse(temp, 0, 4);
        //    model.equationB = BitConverter.ToSingle(temp, 0);

        //    resp.ParaMap.TryGetValue("equationC", out temp);
        //    System.Array.Reverse(temp, 0, 4);
        //    model.equationC = BitConverter.ToSingle(temp, 0);

        //    return model;
        //}

        /*
        数据长度	功能码	待定	    修改的传感器编号	传感器深度	Low/Water	High/Air	Equation（浮点数）
							                                                                    A	B	C
        1AH	        4BH	    05 18 01 02	1 Byte	            4 Byte	    2 Byte	    2 Byte	    4 Byte	4 Byte	4 Byte 
        */
        public static IRequest genModifySensor(SensorDataModel sensor, byte sNum)
        {
            Request req = new Request();

            byte[] depth = BitConverter.GetBytes(sensor.depth);
            System.Array.Reverse(depth, 0, 4);

            byte[] lowWater = BitConverter.GetBytes(sensor.lowWater);
            System.Array.Reverse(lowWater, 0, 2);

            byte[] highAir = BitConverter.GetBytes(sensor.highAir);
            System.Array.Reverse(highAir, 0, 2);

            byte[] equationA = BitConverter.GetBytes(sensor.equationA);
            System.Array.Reverse(equationA, 0, 4);

            byte[] equationB = BitConverter.GetBytes(sensor.equationB);
            System.Array.Reverse(equationB, 0, 4);

            byte[] equationC = BitConverter.GetBytes(sensor.equationC);
            System.Array.Reverse(equationC, 0, 4);

            Request_4BFrame frame = new Request_4BFrame(sNum, (byte)(sensor.addr), depth, lowWater,
                highAir, equationA, equationB, equationC);
            req.requestFrame = frame;

            return req;
        }

        //public static IRequest genModifySensor(SensorDataModel sensor, byte sNum)
        //{
        //    Request_4B req = new Request_4B();

        //    req.ParaMap.Add("sensorNum", new byte[] { sNum });
        //    req.ParaMap.Add("addr", new byte[] { (byte)(sensor.addr) });

        //    byte[] depth = BitConverter.GetBytes(sensor.depth);
        //    System.Array.Reverse(depth, 0, 4);
        //    req.ParaMap.Add("depth", depth);

        //    byte[] lowWater = BitConverter.GetBytes(sensor.lowWater);
        //    System.Array.Reverse(lowWater, 0, 2);
        //    req.ParaMap.Add("lowWater", lowWater);

        //    byte[] highAir = BitConverter.GetBytes(sensor.highAir);
        //    System.Array.Reverse(highAir, 0, 2);
        //    req.ParaMap.Add("highAir", highAir);

        //    byte[] equationA = BitConverter.GetBytes(sensor.equationA);
        //    System.Array.Reverse(equationA, 0, 4);
        //    req.ParaMap.Add("equationA", equationA);

        //    byte[] equationB = BitConverter.GetBytes(sensor.equationB);
        //    System.Array.Reverse(equationB, 0, 4);
        //    req.ParaMap.Add("equationB", equationB);

        //    byte[] equationC = BitConverter.GetBytes(sensor.equationC);
        //    System.Array.Reverse(equationC, 0, 4);
        //    req.ParaMap.Add("equationC", equationC);

        //    return req;
        //}
    }
}
