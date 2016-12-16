using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PConfigUI.UIUtil
{
    public class DGVSequenceAssistant
    {
        public static string genWrittingString(DataGridView dgv)
        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dgv.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dgv.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Export data.
            for (int i = 0; i < dgv.RowCount; i++)
            {
                string stLine = "";
                for (int j = 0; j < dgv.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dgv.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            return stOutput;
        }

        public static DataGridView genDGV(string str)
        {
            DataGridView dgv = new DataGridView();
            string[] temp = str.Split(new char[]{'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries );
            if (temp.Length > 0)
            {
                string[] headers = temp[0].Split(new char[]{'\t'}, StringSplitOptions.RemoveEmptyEntries);
                dgv.ColumnCount = headers.Length;
                for (int i = 0; i < headers.Length; i++)
                {
                    dgv.Columns[i].HeaderText = headers[i];
                }
            }

            if (temp.Length > 1)
            {
                dgv.RowCount = temp.Length - 1;
                for (int i = 1; i < temp.Length; i++)
                {
                    string[] cells = temp[i].Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < cells.Length; j++ )
                    {
                        dgv.Rows[i - 1].Cells[j].Value = cells[j];
                    }
                }
            }

            return dgv;
        }

        public static void updateDGV(DataGridView oldDGV, DataGridView newDGV)
        {
            for (int i = 0, j = 0; i < newDGV.Columns.Count;)
            {
                DataGridViewColumn col = oldDGV.Columns[newDGV.Columns[i].HeaderText];
                if (oldDGV.Columns[j].HeaderText.Equals(newDGV.Columns[i].HeaderText) == true)
                {
                    for (int k = 0; k < newDGV.Rows.Count; k++)
                    {
                        oldDGV.Rows[k].Cells[j].Value= newDGV.Rows[k].Cells[i].Value;
                    }
                    i++;
                    j++;
                }
                else
                {
                    j++;
                    continue;
                }

            }
        }
    }
}
