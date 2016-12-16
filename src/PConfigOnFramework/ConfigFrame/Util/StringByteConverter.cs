using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigFrame.Util
{
    public class StringByteConverter 
    {
        public static byte[] stringToByteArray(string str)
        {
            if (str != null)
            {
                char[] chars = str.ToCharArray();
                byte[] bytes = new byte[chars.Length];
                for (int i = 0; i < chars.Length; i++)
                {
                    bytes[i] = System.Convert.ToByte(chars[i]);
                }
                return bytes;
            }
            return null;
        }

        public static string byteArrayToString(byte[] bytes)
        {
            if (bytes != null)
            {
                List<char> chars = new List<char>(); ;
                for (int i = 0; i < bytes.Length; i++)
                {
                    if (bytes[i] < 0x80)
                    {
                        chars.Add(BitConverter.ToChar(new byte[] { bytes[i], 0x00 }, 0));
                    }
                    
                }
                return new string(chars.ToArray());
            }
            return null;
        }
    }
}
