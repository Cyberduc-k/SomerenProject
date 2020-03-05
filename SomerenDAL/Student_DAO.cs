using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using SomerenModel;

namespace SomerenDAL
{
    public class Student_DAO : Base
    {
        public List<Student> GetAll()
        {
            string query = "SELECT StudentID, Voornaam, Achternaam FROM [Studenten]";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            return ReadStudent(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Student> ReadStudent(DataTable dataTable)
        {
            List<Student> students = new List<Student>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Student student = new Student()
                {
                    Id = (int)dr["StudentID"],
                    FirstName = (string)dr["Voornaam"],
                    LastName = (string)dr["Achternaam"]
                };

                students.Add(student);
            }
            return students;
        }

    }
}
