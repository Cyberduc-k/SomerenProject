using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using SomerenModel;

namespace SomerenDAL
{
   public  class Activity_DAO : Base
    {
        public List<Activity> Db_Get_All_Activities()
        {
            string query =
                "SELECT A.ActiviteitID, A.Activiteitnaam, A.Dag, count(DISTINCT N.StudentID) as [NStudent], count (DISTINCT B.DocentID) as [NGuide]\n"+
                "FROM Activiteiten AS A\n" +
                "JOIN NeemtDeel AS N ON A.ActiviteitID = N.ActiviteitID\n" +
                "JOIN Begeleid AS B ON A.ActiviteitID = B.ActiviteitID\n" +
                "GROUP BY A.ActiviteitID, A.Activiteitnaam, A.Dag";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            return ReadActivity(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Activity> ReadActivity(DataTable dataTable)
        {
            List<Activity> activities = new List<Activity>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Activity activity = new Activity()
                {
                    ActivityID = (int)dr["ActiviteitID"],
                    Name = (string)dr["Activiteitnaam"],
                    Date = (string)dr["Dag"],
                    NStudent = (int)dr["NStudent"],
                    NGuide = (int)dr["NGuide"]
                };

                activities.Add(activity);
            }
            return activities;
        }
    }
}