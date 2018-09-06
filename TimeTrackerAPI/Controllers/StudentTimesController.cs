using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeTrackerAPI.Models;

namespace TimeTrackerAPI.Controllers
{
    public class StudentTimesController : Controller
    {
        private readonly TimeTrackerDbContext ctx;

        public StudentTimesController(TimeTrackerDbContext context)
        {
            ctx = context;
        }

        // Get student time list
        // GET api/values
        [HttpGet]
        public IEnumerable<StudentTime> Get()
        {
            //var teams = ctx.Teams.Where(t => t.TeamName.Contains("Shrewsbury")).OrderBy(t => t.TeamNumber).ToList();
            var times = ctx.StudentTimes;
            return times.ToList();
        }

        // Get a student
        // GET api/values/5
        [HttpGet("{id}")]
        public StudentTime Get(int id)
        {
            var times = ctx.StudentTimes.Find(id);
            return times;
        }

        // Create a student time
        // POST api/values
        [HttpPost]
        public StudentTime Post([FromBody]StudentTime value)
        {
            value.CreateDateTime = DateTime.Now;
            ctx.StudentTimes.Add(value);
            ctx.SaveChanges();
            return value;
        }

         //Update student time
         //PUT api/values/5
        [HttpPut("{id}")]
        public StudentTime Put(int id, [FromBody]StudentTime value)
        {
          var oldTime = ctx.StudentTimes.Find(id);

            if (oldTime != null)
            {
               //oldTime.CheckIn = value.CheckIn;
                oldTime.CheckOut = value.CheckOut;
                //oldTime.CreateDate = value.CreateDate;
               //oldTime.CreateDateTime = value.CreateDateTime;
                oldTime.TotalHrs = value.TotalHrs;
               // oldTime.Updated = DateTime.Now;
                ctx.Update(oldTime);
                ctx.SaveChanges();
            }
           return oldTime;
        }



    }
}

