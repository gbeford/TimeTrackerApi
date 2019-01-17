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
            var events = ctx.Events;
            return await events.OrderBy(e => e.SortOrder).ToListAsync();
        }


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

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event theEvent)
        {

            var oldEvent = await ctx.Events.FindAsync(id);
            if (oldEvent == null)
                return BadRequest();
            if (oldEvent.EventID != id)
                return BadRequest();

            try
            {
                oldEvent.Description = theEvent.Description;
                ctx.Update(oldEvent);
                await ctx.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Events
        [HttpPost]
        public async Task<IActionResult> PostEvent(Event theEvent)
        {
            try
            {
                var nextSort = ctx.Events.OrderByDescending(o => o.SortOrder).FirstOrDefault();

                theEvent.SortOrder = nextSort.SortOrder + 1;

                ctx.Events.Add(theEvent);
                await ctx.SaveChangesAsync();

                return CreatedAtAction("Get", new { id = theEvent.EventID }, theEvent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var theEvent = await ctx.Events.FindAsync(id);
            if (theEvent == null)
                    {
                return NotFound();
            }

            ctx.Events.Remove(theEvent);
            await ctx.SaveChangesAsync();

            return Ok(theEvent);
        }

        private bool EventExists(int id)
        {
            return ctx.Events.Any(e => e.EventID == id);
        }

    }
}

