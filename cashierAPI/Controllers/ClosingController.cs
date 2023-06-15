using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cashierAPI.Models;
using cashierAPI.data;

namespace cashierAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClosingController : ControllerBase
    {
        private readonly databaseContext _context;

        public ClosingController(databaseContext context)
        {
            _context = context;
        }

        // GET: api/Closing
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Closing>>> GetClosing()
        {
          if (_context.Closing == null)
          {
              return NotFound();
          }
            return await _context.Closing.ToListAsync();
        }

        // GET: api/Closing/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Closing>> GetClosing(int id)
        {
          if (_context.Closing == null)
          {
              return NotFound();
          }
            var closing = await _context.Closing.FindAsync(id);

            if (closing == null)
            {
                return NotFound();
            }

            return closing;
        }

        // PUT: api/Closing/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClosing(int id, Closing closing)
        {
            if (id != closing.id_closing)
            {
                return BadRequest();
            }

            _context.Entry(closing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClosingExists(id))
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

        // POST: api/Closing
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Closing>> PostClosing(Closing closing)
        {
          if (_context.Closing == null)
          {
              return Problem("Entity set 'databaseContext.Closing'  is null.");
          }
            _context.Closing.Add(closing);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClosing", new { id = closing.id_closing }, closing);
        }

        // DELETE: api/Closing/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClosing(int id)
        {
            if (_context.Closing == null)
            {
                return NotFound();
            }
            var closing = await _context.Closing.FindAsync(id);
            if (closing == null)
            {
                return NotFound();
            }

            _context.Closing.Remove(closing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClosingExists(int id)
        {
            return (_context.Closing?.Any(e => e.id_closing == id)).GetValueOrDefault();
        }
    }
}
