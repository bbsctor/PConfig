﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PConfigProtocol.FrameDef.Util
{
    public class ClarityAssistant
    {
        //处理数据	透明数据
        //7D 8A	    AA
        //7D DF	    FF
        //7D 5D	    7D
        public static byte[] dataClarityProcess(CommonRequestFrame frame)
        {
            List<byte> bList = new List<byte>();
            bList.AddRange(CommonRequestFrame.leader.Data);
            for (int i = 20; i < frame.Size -1; i++)
            {
                if (frame.Data[i] == 0xAA)
                {
                    bList.Add(0x7D);
                    bList.Add(0x8A);
                }
                else if (frame.Data[i] == 0xFF)
                {
                    bList.Add(0x7D);
                    bList.Add(0xDF);
                }
                else if (frame.Data[i] == 0x7D)
                {
                    bList.Add(0x7D);
                    bList.Add(0x5D);
                }
                else
                {
                    bList.Add(frame.Data[i]);
                }
            }
            bList.AddRange(CommonRequestFrame.tail.Data);
            return bList.ToArray();
        }

        public static byte[] dataDeClarityProcess(byte[] original)
        {
            List<byte> bList = new List<byte>();
            for (int i = 0; i < original.Length; i++)
            {
                if (original[i] == 0x7D && original[i + 1] == 0x8A)
                {
                    bList.Add(0xAA);
                    i++;
                }
                else if (original[i] == 0x7D && original[i + 1] == 0xDF)
                {
                    bList.Add(0xFF);
                    i++;
                }
                else if (original[i] == 0x7D && original[i + 1] == 0x5D)
                {
                    bList.Add(0x7D);
                    i++;
                }
                else
                {
                    bList.Add(original[i]);
                }
            }
            return bList.ToArray();
        }

        //public static byte[] dataDeClarityProcess(CommonResponseFrame frame)
        //{
        //    List<byte> bList = new List<byte>();
        //    bList.AddRange(CommonResponseFrame.leader.Data);
        //    for (int i = 2; i < frame.Size - 1; i++)
        //    {
        //        if (frame.Data[i] == 0x7D && frame.Data[i + 1] == 0x8A)
        //        {
        //            bList.Add(0xAA);
        //            i++;
        //        }
        //        else if (frame.Data[i] == 0x7D && frame.Data[i + 1] == 0xDF)
        //        {
        //            bList.Add(0xFF);
        //            i++;
        //        }
        //        else if (frame.Data[i] == 0x7D && frame.Data[i + 1] == 0x5D)
        //        {
        //            bList.Add(0x7D);
        //            i++;
        //        }
        //        else
        //        {
        //            bList.Add(frame.Data[i]);
        //        }
        //    }
        //    bList.AddRange(CommonResponseFrame.tail.Data);
        //    return bList.ToArray();
        //}
    }
}
