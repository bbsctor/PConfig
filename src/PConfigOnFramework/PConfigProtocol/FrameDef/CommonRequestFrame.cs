using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtocolFrame.ElementDef.BasicImpl;

namespace PConfigProtocol.FrameDef
{
    public class CommonRequestFrame:BasicFrame,ICommonFrame
    {
        public static BasicElement leader;
        public static BasicElement header;
        public static BasicElement addr1;
        public static BasicElement addr2;
        public static FrameNOElement frameNO;
        public static CRCElement crc1;

        public static DataLengthElement dataLength;
        public static BasicElement funcNo;
        public static CompositeElement data;
        public static CRCElement crc2;
        public static BasicElement tail;

        static CommonRequestFrame()
        {
            //前导帧	    帧头	地址位1	        地址位2	帧序号	CRC1	数据长度	功能码	数据	CRC2	帧尾
            //AA FF(10对)	00 FF	04 0A(FF FF)	2 Byte	2 Byte	2 Byte	2 Byte	    1 Byte	n Byte	2 Byte	FF

            leader = new BasicElement();
            leader.Name = "leader";
            leader.Data = new byte[20] { 0xAA, 0xFF, 0xAA, 0xFF, 0xAA, 0xFF, 0xAA, 0xFF, 0xAA, 0xFF,
                0xAA, 0xFF, 0xAA, 0xFF, 0xAA, 0xFF, 0xAA, 0xFF, 0xAA, 0xFF};
            leader.Size = 20;

            header = new BasicElement();
            header.Name = "header";
            header.Data = new byte[2] { 0x00, 0xFF };
            header.Size = 2;

            addr1 = new BasicElement();
            addr1.Name = "addr1";
            addr1.Data = new byte[2] { 0xFF, 0xFF };
            addr1.Size = 2;

            addr2 = new BasicElement();
            addr2.Name = "addr2";
            addr2.Data = new byte[2] { 0x00, 0x01 };
            addr2.Size = 2;

            frameNO = new FrameNOElement();
            frameNO.Name = "frameNO";
            frameNO.Size = 2;

            crc1 = new CRCElement();
            crc1.Name = "crc1";
            crc1.RelateElements = new BasicElement[] {
                header, addr1, addr2, frameNO
            };
            crc1.Size = 2;

            funcNo = new BasicElement();
            funcNo.Name = "funcNo";

            data = new CompositeElement();
            data.Name = "data";

            dataLength = new DataLengthElement();
            dataLength.Name = "dataLength";
            dataLength.RelateElements = new BasicElement[] { funcNo, data };
            dataLength.Size = 2;

            crc2 = new CRCElement();
            crc2.Name = "crc2";
            crc2.RelateElements = new BasicElement[] {
                dataLength, funcNo, data
            };
            crc2.Size = 2;

            tail = new BasicElement();
            tail.Name = "tail";
            tail.Data = new byte[1] { 0xFF };
            tail.Size = 1;
        }

        public CommonRequestFrame()
        {

        }

        public CommonRequestFrame(byte func, byte[] sendData)
        {
            data.Data = null;
            data.Size = 0;
            data.RelateElements = null;
            preBuild(func, sendData);
            build();
        }

        public void preBuild(byte func, byte[] sendData)
        {
            frameNO.build();
            crc1.build();

            funcNo.Data = new byte[] { func };
            funcNo.Size = 1;

            if (sendData != null)
            {
                data.Data = sendData;
                data.Size = data.Data.Length;
            }
            else
            {
                data.Data = null;
                data.Size = 0;
            }

            dataLength.build();
            crc2.build();

            this.RelateElements = new BasicElement[]{
                leader, header, addr1, addr2, frameNO, crc1, dataLength, funcNo, data, crc2, tail
            };
        }
    }
}
