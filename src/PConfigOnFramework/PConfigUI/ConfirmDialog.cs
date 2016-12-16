using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PConfigUI
{
    public partial class ConfirmDialog : Form
    {
        public TabPage[] changedPages;
        public List<TabPage> checkedPages;

        public ConfirmDialog(TabPage[] values)
        {
            InitializeComponent();
            this.confirm_listView.View = View.List;
            this.confirm_listView.CheckBoxes = true;
            
            ListViewItem[] items = new ListViewItem[values.Length];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new ListViewItem(values[i].Text.Substring(0, values[i].Text.Length - 1), 0);
                items[i].Checked = true;
                this.confirm_listView.Items.Add(items[i]);
            }

            changedPages = values;
            checkedPages = new List<TabPage>();
        }

        private void confirm_listView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListViewItem temp = e.Item;
            for (int i = 0; i < changedPages.Length; i++)
            {
                if (temp.Checked == true && changedPages[i].Text.Contains(temp.Text))
                {
                    checkedPages.Add(changedPages[i]);
                }
            }    
        }
    }
}
