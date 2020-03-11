using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoomNumber { get; set; }

        public string Name
        {
            get { return $"{FirstName} {LastName}"; }
        }

    }
}
      


