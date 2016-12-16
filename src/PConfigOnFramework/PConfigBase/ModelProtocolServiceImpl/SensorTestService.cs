using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;
using ConfigFrame.BaseService;
using ConfigFrame.Protocol;
using PConfigBase.ProtocolImpl;
using PConfigBase.BaseModelImpl.BaseMetaModelImpl;
using PConfigBase.BaseModelImpl.BaseDataModelImpl;
using PConfigBase.ModelProtocolServiceImpl.Convert;

namespace PConfigBase.ModelProtocolServiceImpl
{
    public class SensorTestService : BasicService
    {
        public enum IdleMode { COMMON, ALL, SELECTED };
        public IdleMode idleMode = IdleMode.COMMON;
        static int times = 0;
        private SensorListDataModel model;
        private byte[] addr;
        public SensorTestService()
        {
            this.idleMode = IdleMode.COMMON;
        }
        public override IRequest[] genRequestByActionName(string action, IDataModel dModel)
        {
            SensorListDataModel model = dModel as SensorListDataModel;
            switch (action)
            {
                case "read":
                    return genRead(model);
                case "write":
                    return genWrite(model);
                case "queryAll":
                    //idleReqs = genQueryAllSensor(model);
                    this.model = model;
                    return genQueryAllSensor(model);
                case "querySelected":
                    //idleReqs = genQuerySelectedSensor(model);
                    this.model = model;
                    return genQuerySelectedSensor(model);
            }
            if (action.Contains("queryRTSelected"))
            {
                string[] temp = action.Substring(15).Split(',');
                addr = new byte[temp.Length];
                for (int i = 0; i < temp.Length; i++)
                {
                    addr[i] = (byte)int.Parse(temp[i]);
                }
                return genQuerySelectedSensor(addr);
            }
            return null;
        }

//数据长度	功能码	数据
//03H	    64H	    63 74

//数据长度	功能码	    数据 
//                      序号	
//04H	    4DH	    74	递增	00

//数据长度	功能码	数据 
//                          传感器数	传感器顺序
//09H	    64H	    72 73	05	        01 02 03 04 05

//数据长度	功能码	数据
//                          传感器数	传感器顺序
//09H	    64H	    63 73	05	        01 02 03 04 05



        public IRequest[] genQueryAllSensor(SensorListDataModel model)
        {
            byte[] sensors = getSensorAddr(model);
            Request[] req = new Request[5];
            req[4] = new Request(0x64, new byte[]{0x63, 0x74});
            times++;

            req[0] = new Request(0x4D, new byte[]{0x74, (byte)times, 0x00});
            
            byte[] seg1 = new byte[] { 0x72, 0x73, (byte)(sensors.Length) };
            seg1 = seg1.Concat(sensors).ToArray();
            req[1] = new Request(0x64, seg1.ToArray());

            req[2] = new Request(0x64, seg1.ToArray());

            seg1 = new byte[] { 0x63, 0x73, (byte)(sensors.Length) };
            seg1 = seg1.Concat(sensors).ToArray();
            req[3] = new Request(0x64, seg1.ToArray());
            
            return req;
        }

        private byte[] getSensorAddr(SensorListDataModel sensorList)
        {
            byte[] addr = new byte[sensorList.Count];
            for (int i = 0; i < addr.Length; i++)
            {
                addr[i] = (byte)((SensorDataModel)(sensorList[i])).addr;
            }
            return addr;
        }
//数据长度	功能码	数据
//                  序号	传感器数	传感器顺序
//04H-08H	6DH	    递增	1Byte	1-5Byte
//数据长度	功能码	数据
//03H	    64H	    72 73
//数据长度	功能码	数据
//03H	    64H	    63 73
        private IRequest[] genQuerySelectedSensor(SensorListDataModel modelList)
        {
            int selectedNum = 0;
            List<byte> sensorSequence = new List<byte>(); 
            for (int i = 0; i < modelList.Count; i++)
            {
                if (modelList[i].isSelected == true)
                {
                    selectedNum++;
                    sensorSequence.Add((byte)(modelList[i].addr));
                }
            }
            Request[] req = new Request[5];
            req[0] = new Request(0x64, new byte[]{0x63, 0x74});

            req[1] = new Request();
            req[1].func = 0x6D;
            req[1].dataLength = (ushort)(selectedNum + 3);
            req[1].Data = new byte[] {(byte)times, (byte)selectedNum};
            req[1].Data = req[1].Data.Concat(sensorSequence.ToArray()).ToArray();
            times++;

            req[2] = new Request(0x64, new byte[] { 0x72, 0x73 });
            req[3] = new Request(0x64, new byte[] { 0x72, 0x73 });
            req[4] = new Request(0x64, new byte[] { 0x63, 0x73 });
            
            return req;
        }

        private IRequest[] genQuerySelectedSensor(byte[] addr)
        {
            Request[] req = new Request[5];
            req[0] = new Request(0x64, new byte[] { 0x63, 0x74 });

            req[1] = new Request();
            req[1].func = 0x6D;
            req[1].Data = new byte[] { (byte)times, (byte)addr.Length };
            req[1].Data = req[1].Data.Concat(addr).ToArray();
            times++;

            req[2] = new Request(0x64, new byte[] { 0x72, 0x73 });
            req[3] = new Request(0x64, new byte[] { 0x72, 0x73 });
            req[4] = new Request(0x64, new byte[] { 0x63, 0x73 });

            return req;
        }

        public override IMetaModel handleResponse(IResponse response)
        {
            MetaModel model = MetaModel.NULL;
            if (response.IsNull == false)
            {
                Response resp = (Response)response;
                byte[] data = resp.Data;
                Request request = (Request)resp.Request;
                switch (request.func)
                {
                    case 0x4D:
                        break;
                    case 0x6D:
                        break;
                    case 0x64:
                        if (request.Data[0] == 0x72 && request.Data[1] == 0x73)
                        {
                            if (response.Data != null)
                            {
                                return parseRawData(resp.Data);
                            }

                        }
                        else if (request.Data[0] == 0x63 && request.Data[1] == 0x73)
                        {
                            return parseCelibrateData(resp.Data);
                        }
                        break;
                    default:
                        break;
                }
            }
            return model;
        }
        //数据长度	序号	探头数	探头顺序	Raw Count
        //                                      1	    2	    3	    4	    5
        //11H	    1Byte	1Byte	5Byte	    2Byte	2Byte	2Byte	2Byte	2Byte

        public IMetaModel parseRawData(byte[] data)
        {
            TestMetaModel mModel = new TestMetaModel();
            mModel.type = TestMetaModel.TYPE.RAW;
            SensorListDataModel modelList = new SensorListDataModel();
            int sensorNum = (int)data[1];
            SensorDataModel[] models = new SensorDataModel[sensorNum];

            for (int i = 0; i < sensorNum; i++)
            {
                models[i] = new SensorDataModel();
                models[i].addr = (int)data[2 + i];

                System.Array.Reverse(data, 2 + sensorNum + 2 * i, 2);
                models[i].rawCount = BitConverter.ToUInt16(data, 2 + sensorNum + 2 * i);

                modelList.Add(models[i]);
            }

            mModel.Data = modelList;
            return mModel;
        }

        public IMetaModel parseCelibrateData(byte[] data)
        {
            TestMetaModel mModel = new TestMetaModel();
            mModel.type = TestMetaModel.TYPE.CELIBRATE;

            SensorListDataModel modelList = new SensorListDataModel();
            int sensorNum = (int)data[1];
            SensorDataModel[] models = new SensorDataModel[sensorNum];

            for (int i = 0; i < sensorNum; i++)
            {
                models[i] = new SensorDataModel();
                models[i].addr = (int)data[2 + i];

                System.Array.Reverse(data, 2 + sensorNum + 4 * i, 4);
                models[i].celibrateValue = BitConverter.ToSingle(data, 2 + sensorNum + 4 * i);

                modelList.Add(models[i]);
            }

            mModel.Data = modelList;
            return mModel;
        }

        private IRequest[] genRead(IDataModel model)
        {
            return new RequestWrapper(Request.createNullRequest()).getRequestArray();
        }

        public IRequest[] genWrite(IDataModel model)
        {
            return new RequestWrapper(Request.createNullRequest()).getRequestArray();
        }

        public override IRequest[] genIdleRequest()
        {
            if (idleMode == IdleMode.ALL)
            {
                return genQueryAllSensor(model);
            }
            else if (idleMode == IdleMode.SELECTED)
            {
                return genQuerySelectedSensor(addr);
            }
            else
            {
                return base.genIdleRequest();
            }
        }
    }
}
