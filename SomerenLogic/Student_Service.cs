using SomerenDAL;
using SomerenModel;
using System.Collections.Generic;

namespace SomerenLogic
{
    public class Student_Service
    {
        Student_DAO student_db = new Student_DAO();

        public List<Student> GetStudents()
        {
            return student_db.GetAll();
        }
    }
}
