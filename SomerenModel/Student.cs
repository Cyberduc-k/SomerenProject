using System;

namespace SomerenModel
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set;  }

        public string Name
        {
            get { return $"{FirstName} {LastName}"; }
        }
    }
}