using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeTrackerAPI.Models;

// https://code.msdn.microsoft.com/How-to-save-Image-to-978a7b0b

namespace TimeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApparelImageController : Controller
    {

        private readonly TimeTrackerDbContext ctx;

        public ApparelImageController(TimeTrackerDbContext context)
        {
            ctx = context;
        }

        // Get Apparel Images
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<ApparelImage>> Get()
        {
            var image = ctx.ApparelImages;
            return await image.ToListAsync();
        }

        // GET api/ApparelImage/GetImageNames
        [HttpGet ("GetImageNames")]
        public async Task<IEnumerable<ApparelImageName>> GetImageNames()
        {
            var images = ctx.ApparelImages
             .Select(res => new ApparelImageName()
              {
                 ApparelImageId = res.ApparelImageId,
                 ImageName = res.ImageName
              });

            return await images.ToListAsync();
        }


        // GET: api/ApparelImage/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var apparel = await ctx.ApparelImages.FindAsync(id);

            if (apparel == null)
            {
                return NotFound();
            }

            return Ok(apparel);
        }


        // POST: api/ApparelImage
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            try
            {
                //file coming in from angular
                var file = Request.Form.Files[0];

                MemoryStream ms = new MemoryStream();
                file.OpenReadStream().CopyTo(ms);

                Models.ApparelImage apparelImage = new Models.ApparelImage()
                {
                    // gets info from the file
                    ImageName = file.Name,
                    FileName = file.FileName,
                    Image = ms.ToArray(),
                    ContentType = file.ContentType
                };

                ctx.ApparelImages.Add(apparelImage);

                await ctx.SaveChangesAsync();

                return CreatedAtAction("Get", new { id = apparelImage.ApparelImageId }, apparelImage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }





        // PUT: api/ApparelImage/5
        [HttpPut("{id}")]
        // public async Task<IActionResult> PutEvent(int id, Apparel Apparel)
        // {

        //     var oldApparel = await ctx.ApparelImages.FindAsync(id);
        //     if (oldApparel == null)
        //         return BadRequest();
        //     if (oldApparel.ApparelId != id)
        //         return BadRequest();

        //     try
        //     {
        //         oldApparel.Description = Apparel.Description;
        //         ctx.Update(oldApparel);
        //         await ctx.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!ApparelImageExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }

        // // DELETE: api/ApparelImage/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var image = await ctx.ApparelImages.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }

            ctx.ApparelImages.Remove(image);
            await ctx.SaveChangesAsync();

            return Ok(image);
        }

        private bool ApparelImageExists(int id)
        {
            return ctx.ApparelImages.Any(e => e.ApparelImageId == id);
        }

    }
}

