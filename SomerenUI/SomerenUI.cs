﻿using SomerenModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
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

        private void showPanel(string panelName)
        {
            if(panelName == "Dashboard")
            {
                // hide all other panels
                pnl_Students.Hide();
                pnl_Teachers.Hide();
                pnl_Rooms.Hide();
                pnl_Register.Hide();

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
                pnl_Register.Hide();

                // show students
                pnl_Students.Show();

                // fill the students listview within the students panel with a list of students
                SomerenLogic.Student_Service studService = new SomerenLogic.Student_Service();
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
                
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Students.Hide();
                pnl_Rooms.Hide();
                pnl_Register.Hide();

                // show teachers
                pnl_Teachers.Show();

                // clear the listview before filling it again
                listViewTeachers.Items.Clear();

                // fill the teachers listview within the teachers panel with a list of teachers
                SomerenLogic.Teacher_Service teacher_Service = new SomerenLogic.Teacher_Service();
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
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Students.Hide();
                pnl_Teachers.Hide();
                pnl_Register.Hide();

                // show rooms
                pnl_Rooms.Show();
                pnl_Rooms.Show();
              

 
                // fill the rooms listview within the rooms panel with a list of rooms
                SomerenLogic.Room_Service room_Service = new SomerenLogic.Room_Service();
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
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Students.Hide();
                pnl_Teachers.Hide();
                pnl_Rooms.Hide();

                // show Register
                pnl_Register.Show();
                pnl_Register.Show();



                // fill the rooms listview within the rooms panel with a list of rooms
                SomerenLogic.Drink_Service Drink_Service = new SomerenLogic.Drink_Service();
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

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Register");
        }

        private void listView_Register2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
