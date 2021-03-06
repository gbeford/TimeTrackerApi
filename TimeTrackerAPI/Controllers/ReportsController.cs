﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeTrackerAPI.Models;

namespace TimeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : Controller
    {

        private readonly TimeTrackerDbContext ctx;

        public ReportsController(TimeTrackerDbContext context)
        {
            ctx = context;
        }

        // Get event list
        // GET api/values
        [HttpGet]
        // public async Task<IEnumerable<StudentHours>> GetStudentHours()
        // {
        //var studentHours = ctx.StudentHours;
        // return studentHours;
        //}


        // GET: api/Event/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var theEvent = await ctx.Events.FindAsync(id);

            if (theEvent == null)
            {
                return NotFound();
            }

            return Ok(theEvent);
        }

        [HttpGet("Attendance")]
        public IActionResult Attendance(DateTime startDate, DateTime endDate)
        {
            var results = ctx.Students

                .OrderBy(s => s.StudentId)
                .SelectMany(w => w.StudentTimes, (student, times) =>
                     new { student.StudentId, student.FirstName, student.LastName, times })
                      .Where(s => s.times.CreateDateTime >= startDate && s.times.CreateDateTime <= endDate);
            return Ok(results.ToList());
        }

        //     a.SelectMany(i => b, (i, j) => new { i = i, j = j
        // }).Where(anon => anon.i > anon.j).Select(anon => anon.i + anon.j)

    }
}

