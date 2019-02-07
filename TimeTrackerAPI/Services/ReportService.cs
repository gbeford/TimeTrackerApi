using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeTrackerAPI.Models;

namespace TimeTrackerAPI.Services
{
    public class ReportService : IReportService
    {
        private readonly TimeTrackerDbContext ctx;

        public ReportService(TimeTrackerDbContext Context)
        {
            ctx = Context;
        }

        public void GetAllStudentHoursByDay(DateTime StartDate, DateTime EndDate)
        {

            //             select distinct
            //    [LastName] +',' + [FirstName],

            //  CONVERT(date, [StudentTimes].[CreateDateTime]),
            //     sum([TotalHrs]) Hours
            // FROM[StudentTimes] join[Students]
            //     on[StudentTimes].StudentId = [Students].id
            // where CreateDateTime >= '2019/01/01' and CreateDateTime <= '2019/01/17'
            // group by[FirstName],[LastName],[StudentTimes].[CreateDateTime]
            //         order by[Students].[LastName] + ','  + [FirstName]
            //         Asc


            // var hours =
            // from Student in students
            // join StudentTime in times on Student.ID  equals StudentTime.StudentID
            // (w => w.CreateDateTime >= CreateDateTime && w.CreateDateTime <= CreateDateTime)
            // group Student by Student.FirstName, Student.LastName, StudentTime.CreateDateTime
            // orderby Student.LastName;

            throw new NotImplementedException();
        }

        public void GetStudentHoursByDay(int StudentId, DateTime StartDate, DateTime EndDate)
        {
            throw new NotImplementedException();
        }
    }
}