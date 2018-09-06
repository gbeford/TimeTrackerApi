using System;

namespace TimeTrackerAPI.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Grade { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }


    }
}
