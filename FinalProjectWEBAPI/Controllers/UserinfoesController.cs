using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProjectWEBAPI.Models;

namespace FinalProjectWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserinfoesController : ControllerBase
    {
        private readonly SpaceTripContext _context;

        public UserinfoesController(SpaceTripContext context)
        {
            _context = context;
        }

        // GET: api/Userinfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Userinfo>>> GetUserinfos()
        {
            return await _context.Userinfos.ToListAsync();
        }

        // GET: api/Userinfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Userinfo>> GetUserinfo(string id)
        {
            var userinfo = await _context.Userinfos.FindAsync(id);

            if (userinfo == null)
            {
                return NotFound();
            }

            return userinfo;
        }

        // PUT: api/Userinfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserinfo(string id, Userinfo userinfo)
        {
            if (id != userinfo.Email)
            {
                return BadRequest();
            }

            _context.Entry(userinfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserinfoExists(id))
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

        // POST: api/Userinfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Userinfo>> PostUserinfo(Userinfo userinfo)
        {
            _context.Userinfos.Add(userinfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserinfoExists(userinfo.Email))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserinfo", new { id = userinfo.Email }, userinfo);
        }

        // DELETE: api/Userinfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserinfo(string id)
        {
            var userinfo = await _context.Userinfos.FindAsync(id);
            if (userinfo == null)
            {
                return NotFound();
            }

            _context.Userinfos.Remove(userinfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserinfoExists(string id)
        {
            return _context.Userinfos.Any(e => e.Email == id);
        }
    }
}
