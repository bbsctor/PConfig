using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace PConfigUI.UIUtil
{
    public class DataGridViewChangeAssitant
    {
        private DataGridView dgv;
        private int changesCount = 0;
        private class Location:IEquatable<Location>
        {
            public int row;
            public int column;
            public Location(int row, int column)
            {
                this.row = row;
                this.column = column;
            }

            public bool Equals(Location obj)
            {
                if (this.row == (obj).row && this.column == (obj).column)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public override bool Equals(Object obj)
            {
                if (obj == null) return base.Equals(obj);

                if (!(obj is Location))
                    throw new InvalidCastException("The 'obj' argument is not a Person object.");
                else
                    return Equals(obj as Location);
            }

            public override int GetHashCode()
            {
                return 0;
            }

            public static bool operator ==(Location location1, Location location2)
            {
                return location1.Equals(location2);
            }

            public static bool operator !=(Location location1, Location location2)
            {
                return (!location1.Equals(location2));
            }
        }

        private Dictionary<Location, string> repository;

        public DataGridViewChangeAssitant(DataGridView dgv)
        {
            this.dgv = dgv;
            repository = new Dictionary<Location, string>();
            for (int i = 0; i < dgv.RowCount; i++)
            {
                for (int j = 0; j < dgv.ColumnCount; j++)
                {
                    if (dgv.Rows[i].Cells[j].Value != null)
                    {
                        repository.Add(new Location(i, j), dgv.Rows[i].Cells[j].Value.ToString());
                    }
                }
            }
        }

        public bool isCellChanged(DataGridViewCell cell)
        {
            Location location = new Location(cell.RowIndex, cell.ColumnIndex);
            string temp;
            repository.TryGetValue(location,out temp);
            if (cell.Value.ToString().Equals(temp))
            {
                cell.Style.ForeColor = Color.Black;
                return false;
            }
            else
            {
                cell.Style.ForeColor = Color.Red;
                changesCount++;
                return true;
            }
        }

        public bool isDGVChanged()
        {
            string temp;
            
            for (int i = 0; i < dgv.RowCount; i++)
            {
                for (int j = 0; j < dgv.ColumnCount; j++)
                {
                    if (dgv.Rows[i].Cells[j].Value != null)
                    {
                        repository.TryGetValue(new Location(i, j), out temp);
                        if (dgv.Rows[i].Cells[j].Value.ToString().Equals(temp) == false)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
