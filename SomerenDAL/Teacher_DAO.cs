using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using SomerenModel;

namespace SomerenDAL
{
    public class Teacher_DAO : Base
    {
        public List<Teacher> Db_Get_All_Teachers()
        {
            string query = "SELECT * FROM [Docenten]";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            return ReadTeacher(ExecuteSelectQuery(query, sqlParameters));
        }
        private List<Teacher> ReadTeacher(DataTable dataTable)
        {
            List<Teacher> teachers = new List<Teacher>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Teacher teacher = new Teacher()
                {
                    Id = (int)dr["DocentID"],
                    FirstName = (string)dr["Voornaam"],
                    LastName = (string)dr["Achternaam"],
                    RoomNumber = (int)dr["KamerID"],

                };

                teachers.Add(teacher);
            }
            return teachers;
        }
    }
}
