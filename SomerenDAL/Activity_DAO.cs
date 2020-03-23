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
            string query = "SELECT ActiviteitID, Activiteitnaam, Dag, Tijdstip  FROM [Activiteiten]";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            return ReadActivity(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Activity> ReadActivity(DataTable dataTable)
        {
            List<Activity> Activities = new List<Activity>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Activity activity = new Activity()
                {
                    ID = (int)dr["ActiviteitID"],
                    Name = (string)dr["Activiteitnaam"],
                    Date = (string)dr["Dag"],
                    Time = (DateTime)dr["Tijdstip"]
                };

                Activities.Add(activity);
            }
            return Activities;
        }
    }
}