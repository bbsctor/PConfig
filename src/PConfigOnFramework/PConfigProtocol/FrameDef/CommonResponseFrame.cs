using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtocolFrame.ElementDef.BasicImpl;

namespace PConfigProtocol.FrameDef
{
    public class CommonResponseFrame : BasicFrame,ICommonFrame
    {
        public static BasicElement leader;
        public static BasicElement header;
        public static BasicElement addr1;
        public static BasicElement addr2;
        public static BasicElement frameNO;
        public static CRCElement crc1;

        public static DataLengthElement dataLength;
        public static CompositeElement data;
        public static CRCElement crc2;
        public static BasicElement tail;

        public enum DataMode { SHORT, COMPLETE};
        public static DataMode currentMode;

        public void setDataMode(DataMode mode)
        {
            switch (mode)
            {
                case DataMode.COMPLETE:
                    leader.Size = 2;
                    header.Size = 2;
                    addr1.Size = 2;
                    addr2.Size = 2;
                    frameNO.Size = 2;
                    crc1.Size = 2;
                    dataLength.Size = 2;
                    crc2.Size = 2;
                    tail.Size = 1;
                    currentMode = DataMode.COMPLETE;
                    break;
                case DataMode.SHORT:
                    leader.Size = 2;
                    header.Size = 2;
                    addr1.Size = 2;
                    addr2.Size = 2;
                    frameNO.Size = 2;
                    crc1.Size = 2;
                    dataLength.Size = 0;
                    crc2.Size = 0;
                    tail.Size = 1;
                    currentMode = DataMode.SHORT;
                    break;
            }
        }

        static CommonResponseFrame()
        {
            //前导帧	帧头	地址位1	地址位2	帧序号	CRC1	数据长度	数据	CRC2	帧尾
            //AA FF	    00 00	04 0A	2 Byte	2 Byte	2 Byte	2 Byte	    n Byte	2 Byte	FF

            leader = new BasicElement();
            leader.Name = "leader";
            leader.Size = 2;

            header = new BasicElement();
            header.Name = "header";
            header.Size = 2;

            addr1 = new BasicElement();
            addr1.Name = "addr1";
            addr1.Size = 2;

            addr2 = new BasicElement();
            addr2.Name = "addr2";
            addr2.Size = 2;

            frameNO = new BasicElement();
            frameNO.Name = "frameNO";
            frameNO.Size = 2;

            crc1 = new CRCElement();
            crc1.Name = "crc1";
            crc1.RelateElements = new BasicElement[] {
                header, addr1, addr2, frameNO
            };
            crc1.Size = 2;

            dataLength = new DataLengthElement();
            dataLength.Name = "dataLength";
            dataLength.RelateElements = new BasicElement[] { data };
            dataLength.Size = 2;

            data = new CompositeElement();
            data.Name = "data";

            crc2 = new CRCElement();
            crc2.Name = "crc2";
            crc2.RelateElements = new BasicElement[] {
                dataLength, data
            };
            crc2.Size = 2;

            tail = new BasicElement();
            tail.Name = "tail";
            tail.Data = new byte[1] { 0xFF};
            tail.Size = 1;

            //this.RelateElements = new BasicElement[]{
            //    leader, header, addr1, addr2, frameNO, crc1, dataLength, data, crc2, tail
            //};
        }

        public CommonResponseFrame()
        {
            CommonResponseFrame.data.RelateElements = null;
            this.RelateElements = new BasicElement[]{
                leader, header, addr1, addr2, frameNO, crc1, dataLength, data, crc2, tail
            };
        }

        public override bool parse()
        {
            preParse();
            return base.parse();
        }

        private void preParse()
        {
            if (base.Data[12] != 0xFF)
            {
                setDataMode(DataMode.COMPLETE);
                byte[] temp = new byte[2];
                System.Array.Copy(base.Data, 12, temp, 0, 2);
                System.Array.Reverse(temp);
                int dataLen = (int)BitConverter.ToUInt16(temp, 0);
                data.Size = dataLen;
            }
            else
            {
                setDataMode(DataMode.SHORT);
            }
            
        }
    }
}
