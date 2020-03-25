using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class Activity_Service
    {
        Activity_DAO activity_db = new Activity_DAO();

        public List<Activity> GetActivities()
        {
            return activity_db.Db_Get_All_Activities();
        }

        public void Add_Activity(int ActivityID, string Name, string Date)
        {
            activity_db.Db_Add_Activity(ActivityID, Name, Date);
        }

        public void Delete_Activity(int ActivityID)
        {
            activity_db.Db_Delete_Activity(ActivityID);
        }
    }
}
