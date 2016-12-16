using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PConfigUI.UIUtil
{
    public class CfgFileAssistant
    {
        public static Dictionary<string, string> dict;
        static CfgFileAssistant()
        {
            dict = new Dictionary<string, string>();
        }

        public static void clear()
        {
            dict.Clear();
        }

        public static void add(string block, string content)
        {
            dict.Add(block, content);
        }

        public static string get(string block)
        {
            string temp = null;
            dict.TryGetValue(block, out temp);
            return temp;
        }

        public static string build()
        {
            string outStr = "";
            foreach (KeyValuePair<string, string> kvp in dict)
            {
                outStr += kvp.Key + "\r\n" + kvp.Value + "\r\n";
            }

            return outStr;
        }

        public static void parse(string inStr)
        {
            string[] temp = inStr.Split(new char[]{'[', ']'}, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < temp.Length; )
            {
                dict.Add(temp[i], temp[i + 1]);
                i = i + 2;
            }
        }
    }
}
