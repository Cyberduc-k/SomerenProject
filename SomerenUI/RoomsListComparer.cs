using System;
using System.Collections;
using System.Windows.Forms;
using SomerenModel;

namespace SomerenUI
{
    public class RoomsListComparer : IComparer
    {
        public int Column { get; set; }
        public SortOrder SortOrder { get; set; }

        public RoomsListComparer(int column)
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

            Room a = (Room)li_a.Tag;
            Room b = (Room)li_b.Tag;

            if (a == b) return 0;



            
            if (Column == 0)
                return decimal.Compare(a.Number, b.Number) * order;
            else
                return decimal.Compare(a.Capacity, b.Capacity) * order;

;
                
        }
    }
}
