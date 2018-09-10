﻿using System;
using System.Collections.Generic;

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

        public ICollection<StudentTime> StudentTimes { get; set; }}
    }
}
