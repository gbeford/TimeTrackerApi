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

        [HttpGet("{searchBy}/{searchValue}")]
        public async Task<IEnumerable<Order>> Get(string searchBy, string searchValue)
        {
            var results = ctx.Orders.Where(o => !o.Paid);

            switch (searchBy.ToLower())
            {
                // case "all":
                //     results = ctx.Orders.Where(o => !o.Paid);
                //     break;
                case "name":
                    searchValue = searchValue.ToLower();
                    results = results.Where(o => o.StudentName.ToLower().Contains(searchValue));
                    break;
                case "oid":
                    results = results.Where(o => o.OrderId == Convert.ToInt32(searchValue));
                    break;
                case "sid":
                    results = results.Where(o => o.StudentId == Convert.ToInt32(searchValue));
                    break;
            }
            return await results.ToListAsync();
        }

        // Get order
        // GET api/values
        [HttpGet("{OrderId}")]
        public async Task<ActionResult<Order>> Get(int OrderId)
        {
            var order = await ctx.Orders.Include(i => i.Items).ThenInclude(i => i.Apparel).FirstOrDefaultAsync(o => o.OrderId == OrderId);
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
                Order.Items.ForEach(s => s.Apparel = ctx.Apparels.Single(a => a.ApparelId == s.ApparelId));

                ctx.Orders.Add(Order);
                await ctx.SaveChangesAsync();

                return Ok(Order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

         // // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var theOrder= await ctx.Orders.Include(i => i.Items).FirstAsync(f => f.OrderId == id);
            if (theOrder == null)
                    {
                return NotFound();
            }

            ctx.Orders.Remove(theOrder);
            await ctx.SaveChangesAsync();

            return Ok(true);
        }

        private bool OrderExists(int id)
        {
            return ctx.Orders.Any(e => e.OrderId == id);
        }

    

        [HttpPost("MarkPaid")]
        public async Task<IActionResult> MarkPaid([FromBody] int OrderId)
        {
            try
            {
                var order = await ctx.Orders.FirstOrDefaultAsync(o => o.OrderId == OrderId);
                if (order != null)
                {
                    order.Paid = true;
                    ctx.Update(order);
                    await ctx.SaveChangesAsync();
                    return Ok(true);
                }
                return Ok(false);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



    }
}
