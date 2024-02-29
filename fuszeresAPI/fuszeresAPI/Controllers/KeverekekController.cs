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
    public class KeverekekController : ControllerBase
    {
        private readonly FuszeresAdatbazis _context;

        public KeverekekController(FuszeresAdatbazis context)
        {
            _context = context;
        }

        // GET: api/Keverekek
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Keverek>>> Getkeverekek()
        {
          if (_context.keverekek == null)
          {
              return NotFound();
          }
            return await _context.keverekek.ToListAsync();
        }

        // GET: api/Keverekek/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Keverek>> GetKeverek(string id)
        {
          if (_context.keverekek == null)
          {
              return NotFound();
          }
            var keverek = await _context.keverekek.FindAsync(id);

            if (keverek == null)
            {
                return NotFound();
            }

            return keverek;
        }

        // PUT: api/Keverekek/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKeverek(string id, Keverek keverek)
        {
            if (id != keverek.Kkod)
            {
                return BadRequest();
            }

            _context.Entry(keverek).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KeverekExists(id))
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

        // POST: api/Keverekek
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Keverek>> PostKeverek(Keverek keverek)
        {
          if (_context.keverekek == null)
          {
              return Problem("Entity set 'FuszeresAdatbazis.keverekek'  is null.");
          }
            _context.keverekek.Add(keverek);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KeverekExists(keverek.Kkod))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKeverek", new { id = keverek.Kkod }, keverek);
        }

        // DELETE: api/Keverekek/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKeverek(string id)
        {
            if (_context.keverekek == null)
            {
                return NotFound();
            }
            var keverek = await _context.keverekek.FindAsync(id);
            if (keverek == null)
            {
                return NotFound();
            }

            _context.keverekek.Remove(keverek);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KeverekExists(string id)
        {
            return (_context.keverekek?.Any(e => e.Kkod == id)).GetValueOrDefault();
        }
    }
}
