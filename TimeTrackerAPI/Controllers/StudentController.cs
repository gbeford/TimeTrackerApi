using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeTrackerAPI.Models;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TimeTrackerAPI.Controllers
{
    [Route("api/[controller]")]

    public class StudentController : Controller
    {

        private readonly TimeTrackerDbContext ctx;

        public StudentController(TimeTrackerDbContext context)
        {
            ctx = context;
        }

        // Get student list
        // GET api/values
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            //var teams = ctx.Teams.Where(t => t.TeamName.Contains("Shrewsbury")).OrderBy(t => t.TeamNumber).ToList();
            var student = ctx.Students;
            return student.ToList();
        }

        // Get a student
        // GET api/values/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            var student = ctx.Students.Find(id);
            return student;
        }

        // Create a student
        // POST api/values
        [HttpPost]
        public Student Post([FromBody]Student value)
        {
            value.Created = DateTime.Now;
            ctx.Students.Add(value);
            ctx.SaveChanges();
            return value;
        }

        // Update student
        // PUT api/values/5
        [HttpPut("{id}")]
        public Student Put(int id, [FromBody]Student value)
        {
            var oldStudent = ctx.Students.Find(id);
            if (oldStudent != null)
            {
                oldStudent.FirstName = value.FirstName;
                oldStudent.LastName = value.LastName;
                oldStudent.Email = value.Email;
                oldStudent.Grade = value.Grade;
                oldStudent.Updated = DateTime.Now;
                ctx.Update(oldStudent);
                ctx.SaveChanges();
            }
            return oldStudent;
        }



    }
}
