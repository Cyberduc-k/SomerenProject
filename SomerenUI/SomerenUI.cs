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
                    List.SubItems.Add(t.FirstName);
                    List.SubItems.Add(t.LastName);
                    List.SubItems.Add(t.RoomNumber.ToString());
                    listViewTeachers.Items.Add(List);

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

        private void listViewTeachers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewTeachers_ColumnClick(object sender, ColumnClickEventArgs e)
        {
          
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
    }
}
