using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fuszeresAPI.Models;

namespace fuszeresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuszerekController : ControllerBase
    {
        private readonly FuszeresAdatbazis _context;

        public FuszerekController(FuszeresAdatbazis context)
        {
            _context = context;
        }

        // GET: api/Fuszerek
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fuszer>>> Getfuszerek()
        {
          if (_context.fuszerek == null)
          {
              return NotFound();
          }
            return await _context.fuszerek.ToListAsync();
        }

        // GET: api/Fuszerek/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fuszer>> GetFuszer(string id)
        {
          if (_context.fuszerek == null)
          {
              return NotFound();
          }
            var fuszer = await _context.fuszerek.FindAsync(id);

            if (fuszer == null)
            {
                return NotFound();
            }

            return fuszer;
        }

        // PUT: api/Fuszerek/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuszer(string id, Fuszer fuszer)
        {
            if (id != fuszer.Fkod)
            {
                return BadRequest();
            }

            _context.Entry(fuszer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuszerExists(id))
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

        // POST: api/Fuszerek
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fuszer>> PostFuszer(Fuszer fuszer)
        {
          if (_context.fuszerek == null)
          {
              return Problem("Entity set 'FuszeresAdatbazis.fuszerek'  is null.");
          }
            _context.fuszerek.Add(fuszer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FuszerExists(fuszer.Fkod))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFuszer", new { id = fuszer.Fkod }, fuszer);
        }

        // DELETE: api/Fuszerek/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuszer(string id)
        {
            if (_context.fuszerek == null)
            {
                return NotFound();
            }
            var fuszer = await _context.fuszerek.FindAsync(id);
            if (fuszer == null)
            {
                return NotFound();
            }

            _context.fuszerek.Remove(fuszer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FuszerExists(string id)
        {
            return (_context.fuszerek?.Any(e => e.Fkod == id)).GetValueOrDefault();
        }
    }
}
