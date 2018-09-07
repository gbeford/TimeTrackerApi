using System;
using TimeTrackerAPI.Models;

namespace TimeTrackerAPI.Services
{
    public interface IStudentService
    {
        Student SignInStudent(int StudentId);
        Student SignOutStudent(int StudentId, bool admin = false);
    }
}
