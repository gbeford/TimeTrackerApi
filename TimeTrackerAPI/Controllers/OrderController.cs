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
    public class OrderController : Controller
    {

        private readonly TimeTrackerDbContext ctx;

        public OrderController(TimeTrackerDbContext context)
        {
            ctx = context;
        }

        // Get order 
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Order>> Get()
        {
            var order = ctx.Orders;
            return await order.ToListAsync();
        }

        // Get order 
        // GET api/values
        [HttpGet("{OrderId}")]
        public async Task<ActionResult<Order>> Get(int OrderId)
        {
            var order = await ctx.Orders.Include(i => i.Items).FirstOrDefaultAsync(o => o.OrderId == OrderId);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        // POST: api/Order
        [HttpPost]
        public async Task<IActionResult> Post(Order Order)
        {
            try
            {
                ctx.Orders.Add(Order);
                await ctx.SaveChangesAsync();

                return Ok(Order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}