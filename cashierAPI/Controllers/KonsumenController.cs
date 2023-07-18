using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cashierAPI.Models;
using cashierAPI.database;

namespace cashierAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KonsumenController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public KonsumenController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Konsumen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Konsumen>>> Getkonsumens()
        {
          if (_context.konsumens == null)
          {
              return NotFound();
          }
            return await _context.konsumens.ToListAsync();
        }

        // GET: api/Konsumen/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Konsumen>> GetKonsumen(int id)
        {
          if (_context.konsumens == null)
          {
              return NotFound();
          }
            var konsumen = await _context.konsumens.FindAsync(id);

            if (konsumen == null)
            {
                return NotFound();
            }

            return konsumen;
        }

        // PUT: api/Konsumen/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKonsumen(int id, Konsumen konsumen)
        {
            if (id != konsumen.id_Konsumen)
            {
                return BadRequest();
            }

            _context.Entry(konsumen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KonsumenExists(id))
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

        // POST: api/Konsumen
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Konsumen>> PostKonsumen(Konsumen konsumen)
        {
          if (_context.konsumens == null)
          {
              return Problem("Entity set 'DatabaseContext.konsumens'  is null.");
          }
            _context.konsumens.Add(konsumen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKonsumen", new { id = konsumen.id_Konsumen }, konsumen);
        }

        // DELETE: api/Konsumen/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKonsumen(int id)
        {
            if (_context.konsumens == null)
            {
                return NotFound();
            }
            var konsumen = await _context.konsumens.FindAsync(id);
            if (konsumen == null)
            {
                return NotFound();
            }

            _context.konsumens.Remove(konsumen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KonsumenExists(int id)
        {
            return (_context.konsumens?.Any(e => e.id_Konsumen == id)).GetValueOrDefault();
        }
    }
}
