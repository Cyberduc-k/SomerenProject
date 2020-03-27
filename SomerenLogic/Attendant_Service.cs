using SomerenDAL;
using SomerenModel;

namespace SomerenLogic
{
    public class Attendant_Service
    {
        private Attendant_DAO attendantDao = new Attendant_DAO();

        public void AddAttendant(Teacher teacher)
        {
            attendantDao.AddAttendant(teacher);
        }

        public void RemoveAttendant(Teacher teacher)
        {
            attendantDao.RemoveAttendant(teacher);
        }
    }
}
