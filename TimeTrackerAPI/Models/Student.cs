using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TimeTrackerAPI.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Grade { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? SignInTime { get; set; }
        public bool IsSignedIn
        {
            get
            {
                return SignInTime.HasValue;
            }
        }

        public ICollection<StudentTime> StudentTimes { get; set; }

        private ICollection<StudentMessage> StudentMessages { get; set; }

        [NotMapped]
        public IEnumerable<Message> Messages => StudentMessages.Select(m => m.Message);

        public Student()
        {
            StudentTimes = new List<StudentTime>();
            StudentMessages = new List<StudentMessage>();
        }
    }
}
