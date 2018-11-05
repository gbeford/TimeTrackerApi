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

        public async Task<Student> SignInStudent(int Id, int eventId)
        {
            var student = await ctx.Students.FindAsync(Id);
            if (student != null)
            {
                student.SignInTime = DateTime.Now;
                student.SignInEventId = eventId;
                ctx.Update(student);
                await ctx.SaveChangesAsync();
            }

            return student;
        }

        public async Task<Student> SignOutStudent(int Id, bool admin = false)
        {
            var student = ctx.Students.Include(s => s.StudentTimes).SingleOrDefault(s => s.Id == Id);
            if (student != null)
            {
                if (student.SignInTime.HasValue)
                {
                    var signin = student.SignInTime.Value;
                    var eventId = student.SignInEventId.Value;
                    student.SignInTime = null;
                    student.SignInEventId = null;

                    var timeRecord = new StudentTime();
                    timeRecord.CheckIn = signin;
                    timeRecord.CheckOut = admin ? signin.AddMinutes(1) : DateTime.Now;
                    timeRecord.CreateDateTime = DateTime.Now;
                    timeRecord.TotalHrs = Convert.ToDecimal((timeRecord.CheckOut - signin).TotalHours);
                    timeRecord.EventId = eventId;
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

        public void AddMessagesToStudent(int Id, List<int> MessageIds)
        {
            var student = ctx.Students.First(w => w.Id == Id);
            foreach (var messageId in MessageIds)
            {
                var studentMessage = new StudentMessage()
                {
                    StudentId = Id,
                    MessageId = messageId
                };

                student.StudentMessages.Add(studentMessage);
            }
            ctx.SaveChanges();
        }

        public void RemoveMessageFromStudent(int Id, int MessageId)
        {
            var student = ctx.Students.Include(i => i.StudentMessages).First(w => w.Id == Id);
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
