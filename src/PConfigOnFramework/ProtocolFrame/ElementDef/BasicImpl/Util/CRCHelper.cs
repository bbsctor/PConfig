﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolFrame.ElementDef.BasicImpl.Util
{
    public class CRCHelper
    {
        const ushort poly = 0x1021;
        ushort[] table = new ushort[256];
        ushort initialValue = 0;

        private static CRCHelper instance = null;

        public static CRCHelper getInstance()
        {
            if (instance == null)
            {
                instance = new CRCHelper();
            }
            return instance;
        }

        public ushort ComputeChecksum(byte[] bytes)
        {
            ushort crc = this.initialValue;
            for (int i = 0; i < bytes.Length; ++i)
            {
                crc = (ushort)((crc << 8) ^ table[((crc >> 8) ^ (0xff & bytes[i]))]);
            }
            return crc;
        }

        public byte[] ComputeChecksumBytes(byte[] bytes)
        {
            ushort crc = ComputeChecksum(bytes);
            return BitConverter.GetBytes(crc);
        }

        public ushort getCrc(byte[] bytes)
        {
            return ComputeChecksum(bytes);
        }

        private CRCHelper()
        {
            ushort temp, a;
            for (int i = 0; i < table.Length; ++i)
            {
                temp = 0;
                a = (ushort)(i << 8);
                for (int j = 0; j < 8; ++j)
                {
                    if (((temp ^ a) & 0x8000) != 0)
                    {
                        temp = (ushort)((temp << 1) ^ poly);
                    }
                    else
                    {
                        temp <<= 1;
                    }
                    a <<= 1;
                }
                table[i] = temp;
            }
        }
    }
}
