using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PConfigBase.BaseModelImpl.ModelConverterImpl
{
//    波特率	300	  600	1200	2400	4800	9600	19200	38400	57600	115200
//对应十六进制	00H	  01H	02H	    03H	    04H	    05H	    06H	    07H	    08H	    09H

    public class BaudRateConverter
    {
        public static string getBaudRateByHex(byte b)
        {
            string bandRate = null;
            switch (b)
            {
                case 0x00:
                    bandRate = "300";
                    break;
                case 0x01:
                    bandRate = "600";
                    break;
                case 0x02:
                    bandRate = "1200";
                    break;
                case 0x03:
                    bandRate = "2400";
                    break;
                case 0x04:
                    bandRate = "4800";
                    break;
                case 0x05:
                    bandRate = "9600";
                    break;
                case 0x06:
                    bandRate = "19200";
                    break;
                case 0x07:
                    bandRate = "38400";
                    break;
                case 0x08:
                    bandRate = "57600";
                    break;
                case 0x09:
                    bandRate = "115200";
                    break;
                default:
                    break;
            }
            return bandRate;
        }

        public static byte getHexByBaudRate(string baudRate)
        {
            byte b = 0x00; ;
            if ("300".Equals(baudRate))
            {
                b = 0x00;
            }
            else if ("600".Equals(baudRate))
            {
                b = 0x01;
            }
            else if ("1200".Equals(baudRate))
            {
                b = 0x02;
            }
            else if ("2400".Equals(baudRate))
            {
                b = 0x03;
            }
            else if ("4800".Equals(baudRate))
            {
                b = 0x04;
            }
            else if ("9600".Equals(baudRate))
            {
                b = 0x05;
            }
            else if ("19200".Equals(baudRate))
            {
                b = 0x06;
            }
            else if ("38400".Equals(baudRate))
            {
                b = 0x07;
            }
            else if ("57600".Equals(baudRate))
            {
                b = 0x08;
            }
            else if ("115200".Equals(baudRate))
            {
                b = 0x09;
            }
            return b;
        }
    }
}
