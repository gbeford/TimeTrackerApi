using System;
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
    public class EventsController : Controller
    {

        private readonly TimeTrackerDbContext ctx;

        public EventsController(TimeTrackerDbContext context)
        {
            ctx = context;
        }

        // Get event list
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Event>> Get()
        {
            var events= ctx.Events;
            return await events.OrderBy(e => e.SortOrder).ToListAsync();
        }

    }
}

