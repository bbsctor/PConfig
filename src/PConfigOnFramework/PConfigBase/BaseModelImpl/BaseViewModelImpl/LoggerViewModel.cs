using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;

namespace PConfigBase.BaseModelImpl.BaseViewModelImpl
{
    public class LoggerViewModel:BasicModel,IViewModel
    {
        private string baudRate;

        public string BaudRate
        {
            get { return baudRate; }
            set { baudRate = value; }
        }
        private uint connectOut;

        public uint ConnectOut
        {
            get { return connectOut; }
            set { connectOut = value; }
        }

        private TimeSpan dialInTime;
        public TimeSpan DialInTime
        {
            get { return dialInTime; }
            set { this.dialInTime = value; }
        }

        private URLViewModel destURL;

        public URLViewModel DestURL
        {
            get { return destURL; }
            set { destURL = value; }
        }

        private string loggerID;

        public string LoggerID
        {
            get { return loggerID; }
            set { loggerID = value; }
        }
        private string parity;

        public string Parity
        {
            get { return parity; }
            set { parity = value; }
        }

        private uint responseOut;

        public uint ResponseOut
        {
            get { return responseOut; }
            set { responseOut = value; }
        }

        private ushort sampleCount;

        public ushort SampleCount
        {
            get { return sampleCount; }
            set { sampleCount = value; }
        }
        private DateTime sampleOrigin;

        public DateTime SampleOrigin
        {
            get { return sampleOrigin; }
            set { sampleOrigin = value; }
        }

        private string connectStatus;

        public string ConnectStatus
        {
            get { return connectStatus; }
            set { connectStatus = value; }
        }
    }
}
