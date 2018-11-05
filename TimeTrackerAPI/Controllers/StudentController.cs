using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeTrackerAPI.Models;
using Newtonsoft.Json;
using TimeTrackerAPI.Services;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TimeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {

        private readonly TimeTrackerDbContext ctx;
        private readonly IStudentService svc;

        public StudentController(TimeTrackerDbContext context, IStudentService service)
        {
            ctx = context;
            svc = service;
        }

        // Get student list
        // GET api/values
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            //var teams = ctx.Teams.Where(t => t.TeamName.Contains("Shrewsbury")).OrderBy(t => t.TeamNumber).ToList();
            var students = ctx.Students.Include(s => s.StudentMessages).ThenInclude(m => m.Message).ToList();
            return students;
        }

        // Get a student
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Get(int id)
        {
            var student = await ctx.Students.SingleOrDefaultAsync(s => s.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }
            var messageLink = student.StudentMessages.ToList();
            foreach(var link in messageLink)
            {
                var text = link.Message.MessageText;
            }
            return Ok(student);
        }

        // Create a student
        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Student>> Post([FromBody] Student value)
        {
            value.Created = DateTime.Now;
            value.Updated = DateTime.Now;
            ctx.Students.Add(value);
            await ctx.SaveChangesAsync();
            return value;
        }

        // Update student
        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> Put(int id, [FromBody] Student value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var oldStudent = ctx.Students.Find(id);
            if (oldStudent != null)
            {
                oldStudent.FirstName = value.FirstName;
                oldStudent.LastName = value.LastName;
                oldStudent.Email = value.Email;
                oldStudent.Grade = value.Grade;
                oldStudent.Updated = DateTime.Now;
                ctx.Update(oldStudent);
                await ctx.SaveChangesAsync();
            }
            return Ok(oldStudent);
        }

        [HttpPost("SignIn/{studentId}")]
        public async Task<IActionResult> SignIn(int studentId, [FromBody] int eventId)
        {
            var student = await svc.SignInStudent(studentId, eventId);

            if (student != null) {
                return Ok(student);
            }
            return BadRequest("Student Not Found");
        }

        [HttpPost("SignOut")]
        public async Task<IActionResult> SignOut([FromBody] int studentId)
        {
            var student = await svc.SignOutStudent(studentId);

            if (student != null)
            {
                    return Ok(student);
            }
            else
            {
                return BadRequest("Student Not Signed In or Not Found");
            }

        }

        [HttpPost("SignOutAll")]
        public async Task<IActionResult> SignOutAll()
        {
            var signedIn = ctx.Students.Where(s => s.SignInTime.HasValue);
            foreach (var student in signedIn)
            {
                await svc.SignOutStudent(student.StudentId, admin: true);
            }

            return Ok();
        }

        [HttpPost("AddMessagesToStudent/{studentId}")]
        public IActionResult AddMessagesToStudent(int studentId, [FromBody] List<int> messageIds)
        {
            svc.AddMessagesToStudent(studentId, messageIds);

            return Ok();
        }

        [HttpPost("RemoveMessageFromStudent/{studentId}")]
        public IActionResult RemoveMessageFromStudent(int studentId, [FromBody] int messageId)
        {
            svc.RemoveMessageFromStudent(studentId, messageId);
            return Ok();
        }
    }
}
