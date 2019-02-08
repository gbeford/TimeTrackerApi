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
    public class ApparelController : Controller
    {

        private readonly TimeTrackerDbContext ctx;

        public ApparelController(TimeTrackerDbContext context)
        {
            ctx = context;
        }

        // Get event list
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Apparel>> Get()
        {
            var apparel = ctx.Apparels;
            return apparel.ToList();
        }


        // GET: api/Event/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var apparel = await ctx.Apparels.FindAsync(id);

            if (apparel == null)
            {
                return NotFound();
            }

            return Ok(apparel);
        }

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Apparel Apparel)
        {

            var oldApparel = await ctx.Apparels.FindAsync(id);
            if (oldApparel == null)
                return BadRequest();
            if (oldApparel.ApparelId != id)
                return BadRequest();

            try
            {
                oldApparel.Description = Apparel.Description;
                ctx.Update(oldApparel);
                await ctx.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApparelExists(id))
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
        public async Task<IActionResult> PostEvent(Apparel Apparel)
        {
            try
            {
                // var nextSort = ctx.Apparels.OrderByDescending(o => o.SortOrder).FirstOrDefault();

                // Apparel.SortOrder = nextSort.SortOrder + 1;

                ctx.Apparels.Add(Apparel);
                await ctx.SaveChangesAsync();

                return CreatedAtAction("Get", new { id = Apparel.ApparelId }, Apparel);
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

            var apparel = await ctx.Events.FindAsync(id);
            if (apparel == null)
                    {
                return NotFound();
            }

            ctx.Events.Remove(apparel);
            await ctx.SaveChangesAsync();

            return Ok(apparel);
        }

        private bool ApparelExists(int id)
        {
            return ctx.Apparels.Any(e => e.ApparelId == id);
        }

    }
}

