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
    public class AkunCSController : ControllerBase
    {
        private readonly databaseContext _context;

        public AkunCSController(databaseContext context)
        {
            _context = context;
        }

        // GET: api/AkunCS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AkunCS>>> GetAkunCS()
        {
          if (_context.AkunCS == null)
          {
              return NotFound();
          }
            return await _context.AkunCS.ToListAsync();
        }

        // GET: api/AkunCS/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AkunCS>> GetAkunCS(int id)
        {
          if (_context.AkunCS == null)
          {
              return NotFound();
          }
            var akunCS = await _context.AkunCS.FindAsync(id);

            if (akunCS == null)
            {
                return NotFound();
            }

            return akunCS;
        }

        // PUT: api/AkunCS/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAkunCS(int id, AkunCS akunCS)
        {
            if (id != akunCS.id_akun)
            {
                return BadRequest();
            }

            _context.Entry(akunCS).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AkunCSExists(id))
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
        public async Task<ActionResult<AkunCS>> PostAkunCS(AkunCS akunCS)
        {
          if (_context.AkunCS == null)
          {
              return Problem("Entity set 'databaseContext.AkunCS'  is null.");
          }
            _context.AkunCS.Add(akunCS);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAkunCS", new { id = akunCS.id_akun }, akunCS);
        }

        // DELETE: api/AkunCS/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAkunCS(int id)
        {
            if (_context.AkunCS == null)
            {
                return NotFound();
            }
            var akunCS = await _context.AkunCS.FindAsync(id);
            if (akunCS == null)
            {
                return NotFound();
            }

            _context.AkunCS.Remove(akunCS);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AkunCSExists(int id)
        {
            return (_context.AkunCS?.Any(e => e.id_akun == id)).GetValueOrDefault();
        }
    }
}
