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

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event event)
        {

            var oldEvent = await ctx.Events.FindAsync(id);
            if (oldEvent == null)
                return BadRequest();
            if (oldEvent.EventID != id)
                return BadRequest();

            try
            {
                oldEvent.Description = event.Description;
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

        // POST: api/Messages
        [HttpPost]
        public async Task<IActionResult> PostEvent(Event event)
        {
            try
            {
                // if (!ModelState.IsValid)
                // {
                //     return BadRequest(ModelState);
                // }

                ctx.Messages.Add(event);
                await ctx.SaveChangesAsync();

                return CreatedAtAction("GetMessage", new { id = event.EventID }, event);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE: api/Messages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var event = await ctx.Events.FindAsync(id);
            if (event == null)
            {
                return NotFound();
            }

            ctx.Messages.Remove(event);
            await ctx.SaveChangesAsync();

            return Ok(event);
        }
private bool EventExists(int id)
{
    return ctx.Events.Any(e => e.EventID == id);
}

    }
}

