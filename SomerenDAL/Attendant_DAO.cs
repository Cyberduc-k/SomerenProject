using SomerenModel;
using System.Data.SqlClient;

namespace SomerenDAL
{
    public class Attendant_DAO : Base
    {
        public void AddAttendant(Teacher teacher)
        {
            string query = $"INSERT INTO [Begeleider] (DocentID) VALUES ({teacher.Id})";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            ExecuteEditQuery(query, sqlParameters);
        }

        public void RemoveAttendant(Teacher teacher)
        {
            string query = $"DELETE FROM [Begeleider] WHERE DocentId = {teacher.Id}";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            ExecuteEditQuery(query, sqlParameters);
        }
    }
}
