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
    public class VariantController : ControllerBase
    {
        private readonly databaseContext _context;

        public VariantController(databaseContext context)
        {
            _context = context;
        }

        // GET: api/Variant
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Variant>>> GetVariant()
        {
          if (_context.Variant == null)
          {
              return NotFound();
          }
            return await _context.Variant.ToListAsync();
        }

        // GET: api/Variant/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Variant>> GetVariant(int id)
        {
          if (_context.Variant == null)
          {
              return NotFound();
          }
            var variant = await _context.Variant.FindAsync(id);

            if (variant == null)
            {
                return NotFound();
            }

            return variant;
        }

        // PUT: api/Variant/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVariant(int id, Variant variant)
        {
            if (id != variant.id_variant)
            {
                return BadRequest();
            }

            _context.Entry(variant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VariantExists(id))
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

        // POST: api/Variant
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Variant>> PostVariant(Variant variant)
        {
          if (_context.Variant == null)
          {
              return Problem("Entity set 'databaseContext.Variant'  is null.");
          }
            _context.Variant.Add(variant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVariant", new { id = variant.id_variant }, variant);
        }

        // DELETE: api/Variant/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVariant(int id)
        {
            if (_context.Variant == null)
            {
                return NotFound();
            }
            var variant = await _context.Variant.FindAsync(id);
            if (variant == null)
            {
                return NotFound();
            }

            _context.Variant.Remove(variant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VariantExists(int id)
        {
            return (_context.Variant?.Any(e => e.id_variant == id)).GetValueOrDefault();
        }
    }
}
