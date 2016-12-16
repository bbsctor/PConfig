using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PConfigProtocol.FrameDef;
using PConfigProtocol.FrameDef.Clock;
using PConfigProtocol.FrameDef.Configuration;

namespace PConfigBase.ProtocolImpl
{
    public class FrameMapper
    {
        private static FrameMapper instance = null;

        public static FrameMapper getInstance()
        {
            if (instance == null)
            {
                instance = new FrameMapper();
            }
            return instance;
        }
        private Dictionary<byte, FrameTypePair> mapper;
        private FrameMapper()
        {
            mapper = new Dictionary<byte, FrameTypePair>();
            mapper.Add(0x54, new FrameTypePair(typeof(Request_54Frame), null));
            mapper.Add(0x74, new FrameTypePair(null, typeof(Response_74Frame)));
            mapper.Add(0x4B, new FrameTypePair(typeof(Request_4BFrame), null));
            mapper.Add(0x6B, new FrameTypePair(null, typeof(Response_6BFrame)));
        }

        public void add(byte func, FrameTypePair pair)
        {
            mapper.Add(func, pair);
        }

        public Type getReqFrameType(byte func)
        {
            FrameTypePair ftp;
            bool isExist = mapper.TryGetValue(func, out ftp);
            if (isExist == false)
            {
                return null;
            }
            else
            {
                return ftp.reqFrameType;
            }

        }

        public Type getRespFrameType(byte func)
        {
            FrameTypePair ftp;
            bool isExist = mapper.TryGetValue(func, out ftp);
            if (isExist == false)
            {
                return null;
            }
            else
            {
                return ftp.respFrameType;
            }

        }

    }

    public class FrameTypePair
    {
        public Type reqFrameType;
        public Type respFrameType;

        public FrameTypePair(Type reqFrameType, Type respFrameType)
        {
            this.reqFrameType = reqFrameType;
            this.respFrameType = respFrameType;
        }
    }
}
