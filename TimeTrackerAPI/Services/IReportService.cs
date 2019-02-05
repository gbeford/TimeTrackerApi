using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeTrackerAPI.Models;

namespace TimeTrackerAPI.Services
{
    public interface IReportService
    {
        void GetAllStudentHoursByDay(DateTime StartDate, DateTime EndDate );
        void GetStudentHoursByDay(int StudentId, DateTime StartDate, DateTime EndDate);

    }
}
