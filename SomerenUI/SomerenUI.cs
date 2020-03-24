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
        private SomerenLogic.Stock_Service stock_Service = new SomerenLogic.Stock_Service();
        private SomerenLogic.Activity_Service activity_Service = new SomerenLogic.Activity_Service();

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
            pnl_Stock.Hide();
            pnl_Activity.Hide();
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
            else if (panelName == "Students")
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
                    List.SubItems.Add(t.Lead.ToString());
                    listViewTeachers.Items.Add(List);
                }
            }
            else if (panelName == "Rooms")
            {
                // show rooms
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
            else if (panelName == "Activities")
            {
                //show activities panel
                pnl_Activity.Show();

                // fill the activities listview within the panel with a list of activities
                List<Activity> activitiesList = activity_Service.GetActivities();

                // clear the listview before filling it again
                listViewActivities.Items.Clear();

                
                foreach (Activity a in activitiesList)
                {
                    ListViewItem List = new ListViewItem(a.ActivityID.ToString());
                    List.Tag = a;
                    List.SubItems.Add(a.Name);
                    List.SubItems.Add(a.Date);
                    List.SubItems.Add(a.NStudent.ToString());
                    List.SubItems.Add(a.NGuide.ToString());


                    listViewActivities.Items.Add(List);
                    //List view task (right arrow) then View and then details to see the columns
                }
            }
            else if (panelName == "Register")
            {
                // show Register
                pnl_Register.Show();

                // fill the rooms listview within the rooms panel with a list of rooms
                List<Drink> DrinkList = Drink_Service.GetDrink();
                List<Student> StudentList = studService.GetStudents();

                // clear the listview before filling it again
                listView_Register.Items.Clear();
                listView_Register2.Items.Clear();

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
            else if (panelName == "Stock")
            {
                // show Stock
                pnl_Stock.Show();

                // clear the listview before filling it again
                listViewStock.Items.Clear();

                // fill the teachers listview within the teachers panel with a list of teachers
                List<Stock> stockList = stock_Service.GetStock();

                foreach (Stock s in stockList)
                {
                    ListViewItem List = new ListViewItem(s.DrinkID.ToString());
                    List.Tag = s;
                    List.SubItems.Add(s.Name);
                    List.SubItems.Add(s.Price.ToString());
                    List.SubItems.Add(s.Amount.ToString());
                    listViewStock.Items.Add(List);
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

            lbl_Term.Text = $"Term: {calendarTerm.SelectionStart.Date.ToString("dd-MM-yyyy")} - {calendarTerm.SelectionEnd.Date.ToString("dd-MM-yyyy")}";

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

        //this button enables you to update the stock 
        public void btnUpdate_Click(object sender, EventArgs e)
        {
            
            int DrankID = int.Parse(txtBoxDrinkID.Text);
            int Amount = int.Parse(txtBoxAmount.Text);
            string Name = txtBoxName.Text;
           
            stock_Service.Update_Stock(DrankID, Amount);
            stock_Service.Update_Name(DrankID, Name);
            listViewStock.Items.Clear();
            showPanel("Stock");

        }
        public void btnAddToStock_Click(object sender, EventArgs e)
        {
            int DrankID = int.Parse(txtBoxDrinkID.Text);
            int Amount = int.Parse(txtBoxAmount.Text);
            int Price = int.Parse(txtBoxPrice.Text);
            string Name = txtBoxName.Text;
            //int RegisterID = '0';
            stock_Service.Add_To_Stock(DrankID, Name, Price,Amount,false);
            listViewStock.Items.Clear();
            showPanel("Stock");
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

        
        private void lblRegisterID_Click(object sender, EventArgs e)
        {

        }

        private void lblDrinkID_Click(object sender, EventArgs e)
        {

        }

        private void txtBoxAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxRegisterID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxDrinkID_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblAmount_Click(object sender, EventArgs e)
        {

        }

        private void calendar_End_DateChanged(object sender, DateRangeEventArgs e)
        {
            updateSales();
        }

        private void listView_Register2_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }
        
        private void btn_Bestelling_Click(object sender, EventArgs e)
        {


            ListViewItem item = listView_Register.SelectedItems[0];
            Drink Drink = (Drink)item.Tag;

            ListViewItem item2 = listView_Register2.SelectedItems[0];
            Student Student = (Student)item2.Tag;

            new Order()
            {
                Id = orderService.OrderCount(),
                Drink = Drink,
                Student = Student,
                Date = DateTime.Now,
                Number = int.Parse(txtbox_Aantal.Text)
            };
            orderService.Db_Update_Order(orderService.OrderCount() ,Drink ,Student ,DateTime.Now, int.Parse(txtbox_Aantal.Text));
            MessageBox.Show("Order Placed");
            txtbox_Aantal.Text = "1";
        }

        private void listView_Register_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void activitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Activities");
        }

        private void registerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showPanel("Register");
        }

        private void salesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showPanel("Sales");
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Stock");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewActivities_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
