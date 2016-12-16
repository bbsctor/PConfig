using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PConfigBase.ProtocolImpl
{
    public static class ProtocolContext
    {
        static private ushort fn = 0x0001;
        public enum Request_Frame_Local
        {
            Request_Frame_Local_Leader = 0,
            Request_Frame_Local_Header = 0,
            Request_Frame_Local_ProbeAddr = 2,
            Request_Frame_Local_HostAddr = 4,
            Request_Frame_Local_FrameNo = 6,
            Request_Frame_Local_CRC1 = 8,
            Request_Frame_Local_DataLen = 10,
            Request_Frame_Local_FunctionCode = 12,
            Request_Frame_Local_DataStart = 13
        };
        public enum Response_Frame_Local
        {
            Response_Frame_Local_Leader = 0,
            Response_Frame_Local_Header = 2,
            Response_Frame_Local_ProbeAddr = 4,
            Response_Frame_Local_HostAddr = 6,
            Response_Frame_Local_FrameNo = 8,
            Response_Frame_Local_CRC1 = 10,
            Response_Frame_Local_DataLen = 12,
            //Response_Frame_Local_FunctionCode=12;
            Response_Frame_Local_DataStart = 14
        };

        public const ushort Request_Leader = 0xAAFF;
        public const ushort Request_Header = 0x00FF;
        //public static ushort Reserve1 = 0xFFFF;
        public const ushort Request_Addr = 0x0001;

        public const ushort Response_Leader = 0xAAFF;
        public const ushort Response_Header = 0x0000;
        public const ushort Response_Addr = 0x0002;

        public static ushort Probe_Addr = 0xFFFF;
        public const byte Frame_End = 0xFF;

        public static ushort genFrameNO()
        {
            return fn++;
        }
    }
}
