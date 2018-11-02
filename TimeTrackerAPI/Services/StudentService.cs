using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<Student> SignInStudent(int StudentId)
        {
            var student = await ctx.Students.FindAsync(StudentId);
            if (student != null)
            {
                student.SignInTime = DateTime.Now;
                ctx.Update(student);
                await ctx.SaveChangesAsync();
            }

            return student;
        }

        public async Task<Student> SignOutStudent(int StudentId, bool admin = false)
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

                    await ctx.SaveChangesAsync();
                    return student;
                }
                else
                {
                    return null;
                }
            }

            return null;
        }

        public void AddMessagesToStudent(int StudentId, List<int> MessageIds)
        {
            var student = ctx.Students.First(w => w.StudentId == StudentId);
            foreach (var messageId in MessageIds)
            {
                var studentMessage = new StudentMessage()
                {
                    StudentId = StudentId,
                    MessageId = messageId
                };

                student.StudentMessages.Add(studentMessage);
            }
            ctx.SaveChanges();
        }

        public void RemoveMessageFromStudent(int StudentId, int MessageId)
        {
            var student = ctx.Students.Include(i => i.StudentMessages).First(w => w.StudentId == StudentId);
            if (student != null)
            {
                var message = student.StudentMessages.First(s => s.MessageId == MessageId);
                if (message != null)
                {
                    student.StudentMessages.Remove(message);
                    ctx.SaveChanges();
                }
            }
        }
    }
}
