using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading;
using ConfigFrame.AppInterface;
using ConfigFrame.Protocol;
using ConfigFrame.BaseModel;
using ConfigFrame.CommunicationService;
using PConfigBase.BaseModelImpl.BaseDataModelImpl;
using PConfigBase.ModelProtocolServiceImpl;
using PConfigBase.BaseModelImpl.BaseMetaModelImpl;

namespace PConfigBase.AppInterfaceImpl
{
    public class ConfigurationController : BasicDynamicController 
    {
        private string[] updateField;
        private int sensorNum = -1;
        private int currentAddr;
        private enum Mode { WATER, AIR };
        private Mode currentMode;

        public override void execute(string action)
        {
            if ("read".Equals(action))
            {
                resetDataModel();
                readAllInfo();
                return;
            }
            else if ("autoDetect".Equals(action))
            {
                server.BusyInterval = 500;
                resetDataModel();
                autoDetect();
                server.BusyInterval = 0;
                return;
            }
            else if (action.Contains("readAir"))
            {
                resetDataModel();
                int addr = int.Parse(action.Substring(7));
                readAirByAddr(addr);
                return;
            }
            else if (action.Contains("readWater"))
            {
                resetDataModel();
                int addr = int.Parse(action.Substring(9));
                readWaterByAddr(addr);
                return;
            }

            base.execute(action);
        }

        public void readAirByAddr(int addr)
        {
            this.currentAddr = addr;
            this.currentMode = Mode.AIR;
            this.updateField = new string[] { "highAir" };
            this.target = "readAir" + addr;
            server.doWork(this);
        }

        public void readAllAir()
        {
            for (int i = 0; i < sensorNum; i++)
            {
                readAirByAddr(i + 1);
            }
        }

        public void readWaterByAddr(int addr)
        {
            this.currentAddr = addr;
            this.currentMode = Mode.WATER;
            this.updateField = new string[]{"lowWater" };
            this.target = "readWater" + addr;
            server.doWork(this);
        }

        public void readAllWater()
        {
            for (int i = 0; i < 5; i++)
            {
                readWaterByAddr(i + 1);
            }
        }

        public void readAllInfo()
        {
            ((SensorListDataModel)model).Clear();
            readSensorNum();
            while (sensorNum == -1)
            {
                Thread.Sleep(1000);
            }
            for (int i = 0; i < sensorNum; i++)
            {
                readInfoByAddr(i + 1);
            }
            //doUnknownWork();
            //readSelected();
        }

        private void doUnknownWork()
        {
            this.Target = "unknownWork";
            server.doWork(this);
        }

        private void readSensorNum()
        {
            this.target = "sensorNum";
            server.doWork(this);
        }

        private void readSelected()
        {
            this.updateField = new string[] { "isSelected"};
            this.target = "readSelected";
            server.doWork(this);
        }

        private void readInfoByAddr(int addr)
        {
            this.updateField = new string[]{"addr","celibrateValue", "depth", "equationA", "equationB", 
                "equationC", "highAir", "lowWater","isSelected", "rawCount" };
            this.target = "readAddr" + addr;
            server.doWork(this);
        }

        public void readProbe()
        {
            this.readAllInfo();
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
        private void autoDetect()
        {
            base.execute("autoDetect");
            readAllInfo();
        }

        public override void handleResult(IMetaModel mModel)
        {
            if (mModel != MetaModel.NULL)
            {
                ConfigurationMetaModel cModel = mModel as ConfigurationMetaModel;
                if (cModel != null)
                {
                    switch (cModel.type)
                    {
                        case ConfigurationMetaModel.TYPE.SENSOR:
                            SensorDataModel sensor = (SensorDataModel)cModel.Data;
                            ((SensorListDataModel)model).update(sensor, this.updateField);
                            break;
                        case ConfigurationMetaModel.TYPE.SENSORNUM:
                            sensorNum = (int)cModel.Data;
                            break;
                        case ConfigurationMetaModel.TYPE.COUNT:
                            ushort count = (ushort)cModel.Data;
                            SensorDataModel temp = new SensorDataModel();
                            temp.addr = currentAddr;
                            if (currentMode == Mode.AIR)
                            {
                                temp.highAir = count;
                            }
                            else
                            {
                                temp.lowWater = count;
                            }
                            ((SensorListDataModel)model).update(temp, this.updateField);
                            break;
                        case ConfigurationMetaModel.TYPE.SELECTED:
                            SensorListDataModel modelList = (SensorListDataModel)cModel.Data;
                            for (int i = 0; i < modelList.Count; i++)
                            {
                                ((SensorListDataModel)model).update(modelList[i], new string[] { "isSelected" });
                            }
                            break;
                    }
                } 
            }  
        }
    }
}
