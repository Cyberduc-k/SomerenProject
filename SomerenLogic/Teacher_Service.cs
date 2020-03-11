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
    public class Teacher_Service
    {
            Teacher_DAO teacher_db = new Teacher_DAO();

            public List<Teacher> GetTeacher()
            {
                return teacher_db.Db_Get_All_Teachers();
            }
        
    }
}
