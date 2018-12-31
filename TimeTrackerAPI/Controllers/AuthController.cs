using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeTrackerAPI.Models;

namespace TimeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TimeTrackerDbContext _context;

        public AuthController(TimeTrackerDbContext context)
        {
            _context = context;
        }

        // POST: api/Auth
        // [HttpPost("Login")]
        // public async Task<IActionResult> Login([FromBody] Auth auth)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     var User = await _context.Users.Where(w => w.Email == auth.Email && w.Password == auth.Password).FirstOrDefaultAsync();

        //     if (User == null)
        //         return BadRequest("Invalid login.");
        //     User.LastLogin = DateTime.Now;
        //     _context.Update(User);
        //     await _context.SaveChangesAsync();
        //     return new OkObjectResult(User.Role);
        // }
    }
}
