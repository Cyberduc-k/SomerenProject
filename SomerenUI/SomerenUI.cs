using SomerenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        private SomerenLogic.Student_Service studService = new SomerenLogic.Student_Service();
        private SomerenLogic.Teacher_Service teacher_Service = new SomerenLogic.Teacher_Service();
        private SomerenLogic.Room_Service room_Service = new SomerenLogic.Room_Service();
        private SomerenLogic.Order_Service orderService = new SomerenLogic.Order_Service();
        private SomerenLogic.Drink_Service Drink_Service = new SomerenLogic.Drink_Service();

        public SomerenUI()
        {
            InitializeComponent();

            listViewStudents.ListViewItemSorter = new StudentsListComparer(0);
            listViewTeachers.ListViewItemSorter = new TeachersListComparer(0);
            ListViewRooms.ListViewItemSorter = new RoomsListComparer(0);
        }

        private void SomerenUI_Load(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void hideAllPanels()
        {
            pnl_Dashboard.Hide();
            img_Dashboard.Hide();
            pnl_Students.Hide();
            pnl_Teachers.Hide();
            pnl_Rooms.Hide();
            pnl_Sales.Hide();
            pnl_Register.Hide();
        }

        private void showPanel(string panelName)
        {
            hideAllPanels();

            if(panelName == "Dashboard")
            {
                // show dashboard
                pnl_Dashboard.Show();
                img_Dashboard.Show();
            }
            else if(panelName == "Students")
            {
                // show students
                pnl_Students.Show();

                // fill the students listview within the students panel with a list of students
                List<Student> studentList = studService.GetStudents();

                // clear the listview before filling it again
                listViewStudents.Items.Clear();

                foreach (Student s in studentList)
                {
                    ListViewItem li = new ListViewItem(s.Id.ToString());

                    li.Tag = s;
                    li.SubItems.Add(s.FirstName);
                    li.SubItems.Add(s.LastName);
                    li.SubItems.Add(s.BirthDate.ToString("dd-mm-yyyy"));

                    listViewStudents.Items.Add(li);
                }
            }
            else if (panelName == "Teachers")
            {
                // show teachers
                pnl_Teachers.Show();

                // clear the listview before filling it again
                listViewTeachers.Items.Clear();

                // fill the teachers listview within the teachers panel with a list of teachers
                List<Teacher> teacherList = teacher_Service.GetTeacher();
               
                foreach (Teacher t in teacherList)
                {
                    ListViewItem List = new ListViewItem(t.Id.ToString());
                    List.Tag = t;
                    List.SubItems.Add(t.FirstName);
                    List.SubItems.Add(t.LastName);
                    List.SubItems.Add(t.RoomNumber.ToString());
                    listViewTeachers.Items.Add(List);
                }         
            }
            else if (panelName == "Rooms")
            {
                // show rooms
                pnl_Rooms.Show();
                pnl_Rooms.Show();
              

 
                // fill the rooms listview within the rooms panel with a list of rooms
                List<Room> roomList = room_Service.GetRoom();

                // clear the listview before filling it again
                ListViewRooms.Items.Clear();

                foreach (Room t in roomList)
                {
                    ListViewItem li = new ListViewItem(t.Number.ToString());

                    li.Tag = t;
                    li.SubItems.Add(t.Capacity.ToString());

                    ListViewRooms.Items.Add(li);
                }

            }
            else if (panelName == "Register")
            {
                // show Register
                pnl_Register.Show();

                // fill the rooms listview within the rooms panel with a list of rooms
                List<Drink> DrinkList = Drink_Service.GetDrink();

                SomerenLogic.Student_Service student_Service = new SomerenLogic.Student_Service();
                List<Student> StudentList = student_Service.GetStudents();

                // clear the listview before filling it again
                listView_Register.Items.Clear();


                foreach (Drink t in DrinkList)
                {

                    ListViewItem li = new ListViewItem(t.Id.ToString());

                    li.Tag = t;
                    li.SubItems.Add(t.Name.ToString());
                    li.SubItems.Add(t.Price.ToString());
                    li.SubItems.Add(t.Alcoholic.ToString());

                    listView_Register.Items.Add(li);
                }
                foreach (Student t in StudentList)
                {

                    ListViewItem li = new ListViewItem(t.Id.ToString());

                    li.Tag = t;
                    li.SubItems.Add(t.FirstName.ToString());
                    li.SubItems.Add(t.LastName.ToString());

                    listView_Register2.Items.Add(li);
                }

            }
            else if (panelName == "Sales")
            {
                pnl_Sales.Show();
                updateSales();
            }
        }

        private void updateSales()
        {
            validateDates(calendarTerm.SelectionStart.Date, calendarTerm.SelectionEnd.Date);

            List<Order> allOrders = orderService.GetAllInRange(calendarTerm.SelectionStart, calendarTerm.SelectionEnd);
            Dictionary<DateTime, List<Order>> ordersByDate = allOrders
                .GroupBy(order => order.Date.Date)
                .ToDictionary(kv => kv.Key, kv => kv.ToList());

            lv_Sales.Items.Clear();

            foreach (KeyValuePair<DateTime, List<Order>> pair in ordersByDate)
            {
                List<Order> orders = pair.Value;
                List<int> customers = new List<int>();
                int sold = 0;
                int total = 0;

                foreach (Order order in orders)
                {
                    sold += order.Number;
                    total += order.Drink.Price * order.Number;

                    if (!customers.Contains(order.Student.Id))
                        customers.Add(order.Student.Id);
                }

                ListViewItem li = new ListViewItem(pair.Key.ToString("dd-MM-yyyy"));

                li.SubItems.Add(sold.ToString());
                li.SubItems.Add(total.ToString());
                li.SubItems.Add(customers.Count.ToString());

                lv_Sales.Items.Add(li);
            }
        }
        
        private void validateDates(DateTime start, DateTime end)
        {
            DateTime today = DateTime.Today.Date;

            if (start > today)
            {
                MessageBox.Show("Invalid start date selected");

                calendarTerm.SelectionStart = today;
            }

            if (end > today)
            {
                MessageBox.Show("Invalid end date selected");

                calendarTerm.SelectionEnd = today;
            }

            if (start > end)
            {
                MessageBox.Show("Start date is after end date");

                calendarTerm.SelectionRange.Start = calendarTerm.SelectionRange.End;
            }
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
           //
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dashboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void img_Dashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("What happens in Someren, stays in Someren!");
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Students");
        }

        private void lecturersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void teacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Teachers");
        }

        private void listViewTeachers_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            TeachersListComparer sorter = (TeachersListComparer)listViewTeachers.ListViewItemSorter;
            if (sorter.SortOrder == SortOrder.Ascending)
                sorter.SortOrder = SortOrder.Descending;
            else
                sorter.SortOrder = SortOrder.Ascending;

            sorter.Column = e.Column;
            listViewTeachers.Sort();
        }

        private void listViewStudents_ColumnClicked(object sender, ColumnClickEventArgs e)
        {
            StudentsListComparer sorter = (StudentsListComparer)listViewStudents.ListViewItemSorter;

            if (sorter.SortOrder == SortOrder.Ascending)
                sorter.SortOrder = SortOrder.Descending;
            else
                sorter.SortOrder = SortOrder.Ascending;

            sorter.Column = e.Column;
            listViewStudents.Sort();
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Rooms");
        }

        private void listViewRooms_ColumnClicked(object sender, ColumnClickEventArgs e)
        {
            RoomsListComparer sorter = (RoomsListComparer)ListViewRooms.ListViewItemSorter;

            if (sorter.SortOrder == SortOrder.Ascending)
                sorter.SortOrder = SortOrder.Descending;
            else
                sorter.SortOrder = SortOrder.Ascending;

            sorter.Column = e.Column;
            ListViewRooms.Sort();
        }

        private void listViewTeachers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Sales");
        }

        private void calendar_End_DateChanged(object sender, DateRangeEventArgs e)
        {
            updateSales();
        }
        
        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Register");
        }

        private void listView_Register2_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }
    }
}
