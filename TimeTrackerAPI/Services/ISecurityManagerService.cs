using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeTrackerAPI.Models;

namespace TimeTrackerAPI.Services
{
    public interface IStudentService
    {
        Task<Student> SignInStudent(int StudentId, int EventId);
        Task<Student> SignOutStudent(int StudentId, bool admin = false);
        void AddMessagesToStudent(int StudentId, List<int> MessageIds);
        void RemoveMessageFromStudent(int studnetId, int messageId);
    }
}
