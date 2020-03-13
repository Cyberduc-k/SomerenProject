using SomerenLogic;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        public SomerenUI()
        {
            InitializeComponent();
        }

        private void SomerenUI_Load(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void showPanel(string panelName)
        {

            if(panelName == "Dashboard")
            {

                // hide all other panels
                pnl_Students.Hide();
                pnl_Teachers.Hide();
                pnl_Rooms.Hide();

                // show dashboard
                pnl_Dashboard.Show();
                img_Dashboard.Show();

            }
            else if(panelName == "Students")
            {
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Teachers.Hide();
                pnl_Rooms.Hide();

                // show students
                pnl_Students.Show();


                

                // fill the students listview within the students panel with a list of students
                SomerenLogic.Student_Service studService = new SomerenLogic.Student_Service();
                List<Student> studentList = studService.GetStudents();

                // clear the listview before filling it again
                listViewStudents.Clear();

                foreach (SomerenModel.Student s in studentList)
                {

                    ListViewItem li = new ListViewItem(s.Name);
                    listViewStudents.Items.Add(li);
                }
            }
            else if (panelName == "Teachers")
            {
                
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Students.Hide();
                pnl_Rooms.Hide();

                // show teachers
                pnl_Teachers.Show();

                // clear the listview before filling it again
                listViewTeachers.Clear();

                // fill the teachers listview within the teachers panel with a list of teachers
                SomerenLogic.Teacher_Service teacher_Service = new SomerenLogic.Teacher_Service();
                List<Teacher> teacherList = teacher_Service.GetTeacher();
               
                foreach (SomerenModel.Teacher t in teacherList)
                {
                    ListViewItem li = new ListViewItem(t.Name);
                    listViewTeachers.Items.Add(li);
                }
                

            }
            else if (panelName == "Rooms")
            {
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Students.Hide();
                pnl_Teachers.Hide();


                // show rooms
                pnl_Rooms.Show();

                

                // fill the rooms listview within the rooms panel with a list of rooms
                SomerenLogic.Room_Service room_Service = new SomerenLogic.Room_Service();
                List<Room> roomList = room_Service.GetRoom();

                // clear the listview before filling it again
                ListViewRooms.Clear();

                foreach (SomerenModel.Room t in roomList)
                {
                    ListViewItem ID = new ListViewItem(t.Number.ToString());

                    ID.SubItems.Add(t.Number.ToString());
                    ID.SubItems.Add(t.Capacity.ToString());


                    ListViewRooms.Items.Add(ID);
                }

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

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pnl_Teacher_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_Teachers_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Students_Click(object sender, EventArgs e)
        {

        }

        private void pnl_Students_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void ListView_Rooms_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Rooms");
        }

        private void listViewStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
