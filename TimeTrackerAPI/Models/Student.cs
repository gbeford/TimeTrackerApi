using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TimeTrackerAPI.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
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

        public ICollection<StudentMessage> StudentMessages { get; set; }

        public Student()
        {
            StudentTimes = new List<StudentTime>();
            StudentMessages = new List<StudentMessage>();
        }
    }
}
