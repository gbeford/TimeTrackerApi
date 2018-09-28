using System;
using System.Threading.Tasks;
using TimeTrackerAPI.Models;

namespace TimeTrackerAPI.Services
{
    public interface IStudentService
    {
        Task<Student> SignInStudent(int StudentId);
        Task<Student> SignOutStudent(int StudentId, bool admin = false);
        void AddMessageToStudent(int StudentId, int MessageId);
    }
}
