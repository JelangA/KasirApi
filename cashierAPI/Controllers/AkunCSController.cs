using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cashierAPI.Models;
using cashierAPI.database;

namespace cashierAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AkunCSController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AkunCSController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/AkunCS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AkunCs>>> GetAkunCs()
        {
          if (_context.AkunCs == null)
          {
              return NotFound();
          }
            return await _context.AkunCs.ToListAsync();
        }

        // GET: api/AkunCS/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AkunCs>> GetAkunCs(int id)
        {
          if (_context.AkunCs == null)
          {
              return NotFound();
          }
            var akunCs = await _context.AkunCs.FindAsync(id);

            if (akunCs == null)
            {
                return NotFound();
            }

            return akunCs;
        }

        // PUT: api/AkunCS/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAkunCs(int id, AkunCs akunCs)
        {
            if (id != akunCs.id_akunCs)
            {
                return BadRequest();
            }

            _context.Entry(akunCs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AkunCsExists(id))
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

        // POST: api/AkunCS
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AkunCs>> PostAkunCs(AkunCs akunCs)
        {
          if (_context.AkunCs == null)
          {
              return Problem("Entity set 'DatabaseContext.AkunCs'  is null.");
          }
            _context.AkunCs.Add(akunCs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAkunCs", new { id = akunCs.id_akunCs }, akunCs);
        }

        // DELETE: api/AkunCS/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAkunCs(int id)
        {
            if (_context.AkunCs == null)
            {
                return NotFound();
            }
            var akunCs = await _context.AkunCs.FindAsync(id);
            if (akunCs == null)
            {
                return NotFound();
            }

            _context.AkunCs.Remove(akunCs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AkunCsExists(int id)
        {
            return (_context.AkunCs?.Any(e => e.id_akunCs == id)).GetValueOrDefault();
        }
    }
}
