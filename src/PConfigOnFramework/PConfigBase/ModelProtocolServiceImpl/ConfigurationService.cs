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
    public class ConfigurationService : BasicService
    {
        public override IRequest[] genRequestByActionName(string action, IDataModel dModel)
        {
            SensorListDataModel model = dModel as SensorListDataModel;

            if (action.Equals("read"))
            {
                return genRead(model);
            }
            else if (action.Equals("write"))
            {
                return genWrite(model);
            }
            else if (action.Equals("sensorNum"))
            {
                return genGetSensorNumber();
            }
            else if (action.Equals("readSelected"))
            {
                return new RequestWrapper(genQuerySelected()).getRequestArray();
            }
            else if (action.Equals("autoDetect"))
            {
                return genAutoDetect();
            }
            else if (action.Contains("readAddr"))
            {
                int addr = int.Parse(action.Substring(8));
                return new RequestWrapper(genGetSensorConfiguration(addr)).getRequestArray();
            }
            else if (action.Contains("readAir"))
            {
                int addr = int.Parse(action.Substring(7));
                return genReadAirByAddr(addr);
            }
            else if (action.Contains("readWater"))
            {
                int addr = int.Parse(action.Substring(9));
                return genReadAirByAddr(addr);
            }
            else if (action.Contains("unknownWork"))
            {
                return genUnknownWork();
            }
            return null;
        }

//AA FF AA FF AA FF AA FF AA FF AA FF AA FF AA FF AA FF AA FF 00 7D DF 04 00 00 01 00 2A 11 C8 00 04 64 72 69 02 3D BD FF
//AA FF AA FF AA FF AA FF AA FF AA FF AA FF AA FF AA FF AA FF 00 7D DF 04 00 00 01 00 2B 01 E9 00 04 64 72 69 03 2D 9C FF
//AA FF AA FF AA FF AA FF AA FF AA FF AA FF AA FF AA FF AA FF 00 7D DF 04 00 00 01 00 2C 71 0E 00 04 64 72 69 04 5D 7B FF
//AA FF AA FF AA FF AA FF AA FF AA FF AA FF AA FF AA FF AA FF 00 7D DF 04 00 00 01 00 2D 61 2F 00 04 64 72 69 05 4D 5A FF
        private IRequest genReadSingleCount(int addr)
        {
            return new Request(0x64, new byte[]{0x72, 0x69, (byte)addr});
        }

        public IRequest[] genReadAirByAddr(int addr)
        {
            //return new RequestWrapper(genGetSensorConfiguration(addr)).getRequestArray();
            return new RequestWrapper(genReadSingleCount(addr)).getRequestArray();
        }
        public IRequest[] genReadAllAir(SensorListDataModel model)
        {
            return genGetAllSensorConfiguration(model);
        }

        public IRequest[] genReadWaterByAddr(int addr)
        {
            //return new RequestWrapper(genGetSensorConfiguration(addr)).getRequestArray();
            return new RequestWrapper(genReadSingleCount(addr)).getRequestArray();
        }
        public IRequest[] genReadAllWater(SensorListDataModel model)
        {
            return genGetAllSensorConfiguration(model);
        }

        public IRequest[] genWrite(IDataModel modelList)
        {
            if (modelList.Modified == false)
            {
                return new RequestWrapper(Request.createNullRequest()).getRequestArray();
            }
            return genModifyAllSensor((SensorListDataModel)modelList);
        }

        public override IMetaModel handleResponse(IResponse resp)
        {
            if (((Request)(resp.Request)).func == 0x6B)
            {
                return parseResponseData((Response)resp);
            }
            else if (((Request)(resp.Request)).func == 0x64)
            {
                if (((Request)(resp.Request)).Data[0] == 0x72 && ((Request)(resp.Request)).Data[1] == 0x69)
                {
                    return parseSingleCountData((Response)resp);
                }
                else if (((Request)(resp.Request)).Data[0] == 0x74 && ((Request)(resp.Request)).Data[1] == 0x67)
                {
                    return parseSelected((Response)resp);
                }

            }
            return MetaModel.NULL;
        }
        //AA FF 00 00 04 00 00 02 02 BD 78 D5 00 02 01 01 4D 70 FF
        private IMetaModel parseSelected(Response resp)
        {
            ConfigurationMetaModel mModel = new ConfigurationMetaModel();
            mModel.type = ConfigurationMetaModel.TYPE.SELECTED;
            int num = resp.Data[0];
            
            SensorListDataModel modelList = new SensorListDataModel();
            SensorDataModel[] models = new SensorDataModel[num];

            for (int i = 0; i < num; i++)
            {
                models[i] = new SensorDataModel();
                models[i].addr = resp.Data[1 + i];
                models[i].isSelected = true;

                modelList.Add(models[i]);
            }

            mModel.Data = modelList;
            return mModel;
        }
   
//数据长度	待定	    传感器编号	传感器深度	Low/Water	High/Air	Equation
//                                                                      A	    B	    C
//19H	    05 18 01 02	1Byte	    4 Byte	    2 Byte	    2 Byte	    4 Byte	4 Byte	4 Byte

        private IMetaModel parseResponseData(Response resp)
        {
            ConfigurationMetaModel mModel = new ConfigurationMetaModel();
            if (resp.responseFrame.Data.Length > 0x12)
            {
                mModel.type = ConfigurationMetaModel.TYPE.SENSOR;

                mModel.Data = PDSensorConverter.parseSensorData(resp);
            }
            else if (resp.responseFrame.Data.Length == 0x12)
            {
                mModel.type = ConfigurationMetaModel.TYPE.SENSORNUM;

                mModel.Data = (int)resp.responseFrame.Data[14];
            }

            return mModel;
        }

        //AA FF 00 00 04 00 00 02 00 2A ED E9 00 02 93 E1 CE D7 FF
        //AA FF 00 00 04 00 00 02 00 2B FD C8 00 02 00 00 6E 60 FF
        //AA FF 00 00 04 00 00 02 00 2C 8D 2F 00 02 00 00 6E 60 FF
        //AA FF 00 00 04 00 00 02 00 2D 9D 0E 00 02 00 00 6E 60 FF
        private IMetaModel parseSingleCountData(Response resp)
        {
            ConfigurationMetaModel mModel = new ConfigurationMetaModel();
            mModel.type = ConfigurationMetaModel.TYPE.COUNT;
            byte[] temp = new byte[]{resp.Data[0], resp.Data[1]};
            System.Array.Reverse(temp, 0, 2);
            mModel.Data = BitConverter.ToUInt16(temp, 0);
            return mModel;
        }

        private IRequest genGetSensorConfiguration(int addr)
        {
            Request req = new Request(0x6B, new byte[] { (byte)addr });
            return req;
        }
        private IRequest[] genGetAllSensorConfiguration(SensorListDataModel model)
        {
            List<IRequest> reqs = new List<IRequest>();
            reqs.Add(genQuerySelected());
            for (int i = 0; i < model.Count; i++)
            {
                reqs.Add(genGetSensorConfiguration(model[i].addr));
            }
            return reqs.ToArray();
        }

        private IRequest[] genUnknownWork()
        {
            List<IRequest> reqs = new List<IRequest>();
            //reqs.Add(new Request(0x73, new byte[]{0x7D}));
            reqs.Add(new Request(0x64, new byte[]{0x69, 0x73}));
            return reqs.ToArray();
        }

        public IRequest[] genGetSensorNumber()
        {
            Request req = new Request(0x6B, new byte[] { 0x00 });
            return new RequestWrapper(req).getRequestArray();

            //List<IRequest> reqs = new List<IRequest>();
            //reqs.Add(new Request(0x73, new byte[] { 0x7D }));
            //reqs.Add(new Request(0x64, new byte[] { 0x74, 0x67 }));
            //reqs.Add(new Request(0x6B, new byte[] { 0x00 }));
            //return reqs.ToArray();
        }
        

        private IRequest[] genModifyAllSensor(SensorListDataModel modelList)
        { 
            List<IRequest> reqs = new List<IRequest>();
            if (genSettingSelected(modelList) != null)
            {
                reqs.Add(genSettingSelected(modelList));
                reqs.Add(genQuerySelected());
            }
            for (int i = 0; i < modelList.Count; i++)
            {
                if (modelList[i].Modified == true)
                {
                    reqs.Add(PDSensorConverter.genModifySensor(modelList[i], (byte)modelList.Count));
                }
            }
            if (reqs.Count == 0)
            {
                Request req = new Request();
                req.IsNull = true;
                reqs.Add(req);
            }
            return reqs.ToArray();
        }

//AA FF(10) 00 7D DF 04 00 00 01 02 BB E4 32 00  05(dataLength)  64(func)  74 63(spec) 01(num) 01(addr) BA 74 FF（设置）
        private IRequest genSettingSelected(SensorListDataModel modelList)
        {
            int num = 0;
            List<byte> addrs = new List<byte>();
            SensorDataModel temp;
            for (int i = 0; i < modelList.Count; i++)
            {
                temp = (SensorDataModel)modelList[i];
                if (temp.isSelected == true)
                {
                    num++;
                    addrs.Add((byte)temp.addr);
                }
            }
            if (num > 0)
            {
                List<byte> data = new List<byte>(new byte[] { 0x74, 0x63, (byte)num });
                data.AddRange(addrs.ToArray());
                return new Request(0x64, data.ToArray());
            }
            else
            {
                return new Request(0x64, new byte[]{0x74, 0x63, 0x00});
            }
        }

//AA FF(10) 00 7D DF 04 00 00 01 02 BD 84 F4 00 03 64 74 67 04 AB FF（查询）
        private IRequest genQuerySelected()
        {
            return new Request(0x64, new byte[]{0x74, 0x67});
        }

        private IRequest[] genRead(SensorListDataModel model)
        {
            return genGetAllSensorConfiguration(model);
        }

        //AA FF(10) 00 7D DF 04 00 00 01 00 2C 71 0E 00 01 73 7D 5D C5 FF
        //AA FF(10) 00 7D DF 04 00 00 01 00 2D 61 2F 00 0B 65 22 62 74 73 5F 30 30 30 31 22 21 60 FF
        //AA FF(10) 00 7D DF 04 00 00 01 00 2E 51 4C 00 0B 65 22 62 74 73 5F 30 30 30 31 22 21 60 FF
        //AA FF(10) 00 7D DF 04 00 00 01 00 2F 41 6D 00 0B 65 22 62 74 73 5F 30 30 30 31 22 21 60 FF
        //AA FF(10) 00 7D DF 04 00 00 01 00 30 A2 B3 00 0B 65 22 62 74 73 5F 30 30 30 31 22 21 60 FF
        //AA FF(10) 00 7D DF 04 00 00 01 00 31 B2 92 00 0B 65 22 62 74 73 5F 30 30 30 31 22 21 60 FF
        //AA FF(10) 00 7D DF 04 00 00 01 00 32 82 F1 00 03 64 74 67 04 AB FF
        //AA FF(10) 00 7D DF 04 00 00 01 00 33 92 D0 00 02 6B 00 B9 B0 FF
        //AA FF(10) 00 7D DF 04 00 00 01 00 34 E2 37 00 02 6B 01 A9 91 FF
        //AA FF(10) 00 7D DF 04 00 00 01 00 35 F2 16 00 02 6B 02 99 F2 FF

        private IRequest[] genAutoDetect()
        {
            List<IRequest> reqs = new List<IRequest>();
            reqs.Add(new Request(0x73, null));
            for (int i = 0; i < 5; i++)
            {
                reqs.AddRange(base.genIdleRequest());
            }    
            reqs.Add(new Request(0x64, new byte[] { 0x74, 0x67 }));

            return reqs.ToArray();
        }
    }
}
