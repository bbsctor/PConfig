using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PConfigUI.UIUtil
{
    public class DictionarySequenceAssistant
    {
        private Dictionary<string, string> dict;
        public DictionarySequenceAssistant()
        {
            dict = new Dictionary<string, string>();
        }

        public void clear()
        {
            dict.Clear();
        }

        public void add(string fieldName, string value)
        {
            if (value != null && value.Length > 0)
            {
                dict.Add(fieldName, value);
            }
        }

        public string get(string fieldName)
        {
            string temp = null;
            dict.TryGetValue(fieldName, out temp);
            return temp;
        }

        public string build()
        {
            string stOutput = "";

            // Export data.
            Dictionary<string, string>.KeyCollection keyColl = dict.Keys;
            string stLine = "";
            foreach (string s in keyColl)
            {
                stLine = stLine.ToString() + s + "\t";
            }
            stOutput += stLine + "\r\n";

            stLine = "";
            Dictionary<string, string>.ValueCollection valColl = dict.Values;
            foreach (string s in valColl)
            {
                stLine = stLine.ToString() + s + "\t";
            }
            stOutput += stLine + "\r\n";

            return stOutput;
        }

        public void parse(string inStr)
        {
            string[] temp = inStr.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            if (temp.Length == 2)
            {
                string[] keys = temp[0].Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                string[] vals = temp[1].Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < keys.Length; i++)
                {
                    dict.Add(keys[i], vals[i]);
                }
            }
        }
    }
}
