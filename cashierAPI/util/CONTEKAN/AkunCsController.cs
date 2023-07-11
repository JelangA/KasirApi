using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cashierAPI.Models;
using cashierAPI.database;

namespace cashierAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AkunCsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AkunCsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/AkunCs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AkunCs>>> GetAkunCs()
        {
            if (_context.AkunCs == null)
            {
                return NotFound();
            }

            var AkunCs = await _context.AkunCs.Include(e => e.User).ToListAsync();
            return AkunCs;
        }

        // GET: api/AkunCs/5
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

        // PUT: api/AkunCs/5
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

        // POST: api/AkunCs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(typeof(AkunCsPostResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AkunCsPostResponse>> PostAkunCs(AkunCsPostResponse req)
        {
            if (_context.AkunCs == null)
            {
                return Problem("Entity set 'DatabaseContext.AkunCs' is null.");
            }

            var akunCs = new AkunCs
            {
                id_akunCs = req.id_akunCs,
                user_id = req.user_id,
                status = req.status
            };

            _context.AkunCs.Add(akunCs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAkunCs", new { id = akunCs.id_akunCs }, akunCs);
        }

        // DELETE: api/AkunCs/5
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
