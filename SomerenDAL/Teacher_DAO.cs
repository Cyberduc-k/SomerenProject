using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using SomerenModel;

namespace SomerenDAL
{
    public class Teacher_DAO : Base
    {
        public List<Teacher> Db_Get_All_Teachers()
        {
            string query =
                @"SELECT DocentID, Voornaam, Achternaam, KamerID, (
                      SELECT CAST(CASE WHEN COUNT(*) > 0 THEN 1 ELSE 0 END AS BIT)
                      FROM [Begeleider] AS B WHERE B.DocentId = D.DocentId) AS Begeleider
                  FROM [Docenten] AS D";

            SqlParameter[] sqlParameters = new SqlParameter[0];

            return ReadTeacher(ExecuteSelectQuery(query, sqlParameters));
        }

        public List<Teacher> GetAttending()
        {
            string query =
                @"SELECT DocentId, Voornaam, Achternaam, KamerID, CAST(1 AS BIT) AS Begeleider
                  FROM [Docenten] AS D
                  WHERE EXISTS (SELECT * FROM [Begeleider] AS B WHERE B.DocentId = D.DocentID)";

            SqlParameter[] sqlParameters = new SqlParameter[0];

            return ReadTeacher(ExecuteSelectQuery(query, sqlParameters));
        }

        public List<Teacher> GetNonAttending()
        {
            string query =
                @"SELECT DocentId, Voornaam, Achternaam, KamerID, CAST(0 AS BIT) AS Begeleider
                  FROM [Docenten] AS D
                  WHERE NOT EXISTS (SELECT * FROM [Begeleider] AS B WHERE B.DocentId = D.DocentID)";

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
                    Lead = (bool)dr["Begeleider"],
                };

                teachers.Add(teacher);
            }
            return teachers;
        }
    }
}
