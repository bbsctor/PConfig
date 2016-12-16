using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PConfigUI.UIUtil
{
    public class SerializationAssistant
    {
        public static void writeToPlainFile(Stream stream, string stOutput)
        {
            Encoding utf16 = Encoding.GetEncoding(-0);
            byte[] output = utf16.GetBytes(stOutput);

            stream.Write(output, 0, output.Length); //write the encoded file
            stream.Flush();
            //stream.Close();
        }

        public static string readFromPlainFile(Stream stream)
        {
            Encoding utf16 = Encoding.GetEncoding(-0);
            
            long len = stream.Length;
            byte[] buff = new byte[len];
            stream.Read(buff, 0 , (int)len);
            string temp = utf16.GetString(buff);
            return temp;
        }
    }
}
