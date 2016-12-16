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
    public class PowerService : BasicService
    {
        public override IRequest[] genRequestByActionName(string action, IDataModel dModel)
        {
            PowerDataModel model = dModel as PowerDataModel;
            switch (action)
            {
                case "read":
                    return genRead(model);
                case "write":
                    return genWrite(model);
                case "queryVoltage":
                    return genNonAction();
            }
            return null;
        }

//数据长度	功能码	序号
//02H	    76H	
//                  00H	无操作
//                  01H	关闭探头电压
//                  02H	激活探头电压
//                  03H	关闭无线传输电压

        private IRequest genQuery(byte number)
        {
            Request req = new Request();
            req.func = 0x76;
            req.Data = new byte[] {number };
            return req;
        }

        private IRequest[] genNonAction()
        {
            return new RequestWrapper(genQuery(0x00)).getRequestArray();
        }

        private IRequest genEnableProbe()
        {
            return genQuery(0x02);
        }

        private IRequest genDisableProbe()
        {
            return genQuery(0x01);
        }

        private IRequest genDisableTelecom()
        {
            return genQuery(0x03);
        }

        public override IMetaModel handleResponse(IResponse response)
        {
            Response resp = (Response)response;
            byte[] data = resp.Data;

            switch (((Request)(resp.Request)).func)
            {
                case 0x76:
                    switch (((Request)(resp.Request)).Data[0])
                    {
                        case 0x00:
                            return parseObserveData(data);
                        case 0x01:
                            return parseDisableProbeData(data);
                        case 0x02:
                            return parseEnableProbeData(data);
                        case 0x03:
                            return parseDisableTelecomData(data);
                        default:
                            break;
                    }
                    break;
                case 0x56:
                    return null;
            }
            return null;
        }

        private List<float> parseData(byte[] data)
        {
            List<float> result = new List<float>();

            System.Array.Reverse(data, 0, 4);
            result.Add(BitConverter.ToSingle(data, 0));
            System.Array.Reverse(data, 4, 4);
            result.Add(BitConverter.ToSingle(data, 4));
            System.Array.Reverse(data, 8, 4);
            result.Add(BitConverter.ToSingle(data, 8));
            return result;
        }

//数据长度	数据
//0CH	    探头电压	4Byte 00H	4Byte 00H

//数据长度	数据
//0CH	    关闭探头电压	低阈值	高阈值

//数据长度	数据
//0CH	    激活探头电压	低阈值	高阈值

//数据长度	数据
//0CH	    关闭无线传输电压	低阈值	高阈值
        private IMetaModel parseObserveData(byte[] data)
        {
            return parsePowerInfo(PowerMetaModel.TYPE.OBSERVE, data);
        }

        private IMetaModel parseDisableProbeData(byte[] data)
        {
            return parsePowerInfo(PowerMetaModel.TYPE.DISABLEPROBE, data);
        }

        private IMetaModel parseEnableProbeData(byte[] data)
        {
            return parsePowerInfo(PowerMetaModel.TYPE.ENABLEPROBE, data);
        }

        private IMetaModel parseDisableTelecomData(byte[] data)
        {
            return parsePowerInfo(PowerMetaModel.TYPE.DISABLETELECOM, data);
        }

        private IMetaModel parsePowerInfo(PowerMetaModel.TYPE type, byte[] data)
        {
            PowerMetaModel model = new PowerMetaModel();
            model.type = type;
            List<float> result = parseData(data);
            if (result.Count != 3)
            {
                throw new Exception();
            }
            model.Data = result;
            return model;
        }

//数据长度	功能码	序号
//02H	    76H	
//                  00H	无操作
//                  01H	关闭探头电压
//                  02H	激活探头电压
//                  03H	关闭无线传输电压

        private IRequest[] genRead(IDataModel model)
        {
            Request[] reqs = new Request[4]{
                new Request(0x76, new byte[]{0x00}),
                new Request(0x76, new byte[]{0x01}),
                new Request(0x76, new byte[]{0x02}),
                new Request(0x76, new byte[]{0x03}),
            };
            return reqs;
        }

        private IRequest[] genWrite(IDataModel powerModel)
        {
            if (powerModel.Modified == false)
            {
                return new RequestWrapper(Request.createNullRequest()).getRequestArray();
            }
            PowerDataModel model = powerModel as PowerDataModel;

            return genModify(model);
        }

        private IRequest[] genModify(PowerDataModel model)
        {
            List<IRequest> reqs = new List<IRequest>();
            if (model.ModifiedFieldList.Contains("enableProbe"))
            {
                reqs.Add(genModifyEnableProbeVoltage(model.enableProbe));
            }
            if (model.ModifiedFieldList.Contains("disableProbe"))
            {
                reqs.Add(genModifyDisableProbeVoltage(model.disableProbe));
            }
            if (model.ModifiedFieldList.Contains("disableTelecom"))
            {
                reqs.Add(genModifyDisableTelecom(model.disableTelecom));
            }
            if (reqs.Count == 0)
            {
                reqs.Add(Request.createNullRequest());
            }
            return reqs.ToArray();
        }

        private IRequest genModifyVoltage(byte tag,float voltage)
        {
            byte[] temp = BitConverter.GetBytes(voltage);
            System.Array.Reverse(temp, 0, 4);

            return new Request(0x56, new byte[]{tag}.Concat(temp).ToArray());
        }

        private IRequest genModifyEnableProbeVoltage(float voltage)
        {
            return genModifyVoltage(0x02, voltage);
        }

        private IRequest genModifyDisableProbeVoltage(float voltage)
        {
            return genModifyVoltage(0x01, voltage);
        }

        private IRequest genModifyDisableTelecom(float voltage)
        {
            return genModifyVoltage(0x03, voltage);
        }
    }
}
