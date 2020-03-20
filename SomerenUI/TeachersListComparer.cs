using System;
using System.Collections;
using System.Windows.Forms;
using SomerenModel;

namespace SomerenUI
{
    class TeachersListComparer : IComparer
    {
        public int Column { get; set; }
        public SortOrder SortOrder { get; set; }

        public TeachersListComparer(int column)
        {
            Column = column;
        }

        public int Compare(object obj_a, object obj_b)
        {
            int order;

            if (SortOrder == SortOrder.Ascending) order = 1;
            else order = -1;

            if (obj_a == null && obj_b == null)
                return 0;
            else if (obj_a == null)
                return -order;
            else if (obj_b == null)
                return order;

            ListViewItem li_a = (ListViewItem)obj_a;
            ListViewItem li_b = (ListViewItem)obj_b;
            Teacher a = (Teacher)li_a.Tag;
            Teacher b = (Teacher)li_b.Tag;

            if (a == b) return 0;

            if (Column == 0)
                return decimal.Compare(a.Id, b.Id) * order;
            else if (Column == 1)
                return string.Compare(a.FirstName, b.FirstName) * order;
            else if (Column == 2)
                return string.Compare(a.LastName, b.LastName) * order;
            else if (Column == 3)
                return decimal.Compare(a.RoomNumber, b.RoomNumber) * order;
            else
                return a.Lead == b.Lead ? 0 : a.Lead ? order: - order;

        }
    }
}
