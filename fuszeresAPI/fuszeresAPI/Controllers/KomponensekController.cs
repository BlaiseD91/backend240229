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
    public class KomponensekController : ControllerBase
    {
        private readonly FuszeresAdatbazis _context;

        public KomponensekController(FuszeresAdatbazis context)
        {
            _context = context;
        }

        // GET: api/Komponensek
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Komponens>>> Getkomponensek()
        {
          if (_context.komponensek == null)
          {
              return NotFound();
          }
            return await _context.komponensek.ToListAsync();
        }

        // GET: api/Komponensek/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Komponens>> GetKomponens(string id)
        {
          if (_context.komponensek == null)
          {
              return NotFound();
          }
            var komponens = await _context.komponensek.FindAsync(id);

            if (komponens == null)
            {
                return NotFound();
            }

            return komponens;
        }

        // PUT: api/Komponensek/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKomponens(string id, Komponens komponens)
        {
            if (id != komponens.Fkod)
            {
                return BadRequest();
            }

            _context.Entry(komponens).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KomponensExists(id))
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

        // POST: api/Komponensek
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Komponens>> PostKomponens(Komponens komponens)
        {
          if (_context.komponensek == null)
          {
              return Problem("Entity set 'FuszeresAdatbazis.komponensek'  is null.");
          }
            _context.komponensek.Add(komponens);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KomponensExists(komponens.Fkod))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKomponens", new { id = komponens.Fkod }, komponens);
        }

        // DELETE: api/Komponensek/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKomponens(string id)
        {
            if (_context.komponensek == null)
            {
                return NotFound();
            }
            var komponens = await _context.komponensek.FindAsync(id);
            if (komponens == null)
            {
                return NotFound();
            }

            _context.komponensek.Remove(komponens);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KomponensExists(string id)
        {
            return (_context.komponensek?.Any(e => e.Fkod == id)).GetValueOrDefault();
        }
    }
}
