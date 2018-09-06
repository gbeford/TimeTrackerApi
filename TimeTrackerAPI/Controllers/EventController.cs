using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeTrackerAPI.Models;

namespace TimeTrackerAPI.Controllers
{
    [Route("api/[controller]")]


    public class EventController : Controller
    {

        private readonly TimeTrackerDbContext ctx;

        public EventController(TimeTrackerDbContext context)
        {
            ctx = context;
        }

        // Get event list
        // GET api/values
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            var events= ctx.Events;
            return events.ToList();
        }

    }
}

