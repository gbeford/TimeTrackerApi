using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TimeTrackerAPI.Models;

namespace TimeTrackerAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly TimeTrackerDbContext ctx;

        public StudentService(TimeTrackerDbContext Context)
        {
            ctx = Context;
        }

        public Student SignInStudent(int StudentId)
        {
            var student = ctx.Students.Find(StudentId);
            if (student != null)
            {
                student.SignInTime = DateTime.Now;
                ctx.Update(student);
                ctx.SaveChanges();
            }

            return student;
        }

        public Student SignOutStudent(int StudentId, bool admin = false)
        {
            var student = ctx.Students.Include(s => s.StudentTimes).SingleOrDefault(s => s.StudentId == StudentId);
            if (student != null)
            {
                if (student.SignInTime.HasValue)
                {
                    var signin = student.SignInTime.Value;
                    student.SignInTime = null;

                    var timeRecord = new StudentTime();
                    timeRecord.CheckIn = signin;
                    timeRecord.CheckOut = admin ? signin.AddMinutes(1) : DateTime.Now;
                    timeRecord.CreateDateTime = DateTime.Now;
                    timeRecord.TotalHrs = Convert.ToDecimal((timeRecord.CheckOut - signin).TotalHours);
                    student.StudentTimes.Add(timeRecord);

                    ctx.Update(student);

                    ctx.SaveChanges();
                    return student;
                }
                else
                {
                    return null;
                }
            }

            return null;
        }
    }
}
