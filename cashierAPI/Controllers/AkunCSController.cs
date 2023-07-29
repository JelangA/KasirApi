using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cashierAPI.Models;
using cashierAPI.database;
using AutoMapper;
using cashierAPI.src.util;
using cashierAPI.Models.dto;

namespace cashierAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AkunCSController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public AkunCSController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/AkunCS
        [HttpGet]
        [ProducesResponseType(typeof(Response<AkunCs>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErr), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<AkunCs>>> GetAkunCs()
        {
            try
            {
                var akunCs = await _context.AkunCs.Include(e => e.User).ToListAsync();
                var res = new Response<AkunCs>(akunCs);
                return Ok(res);
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErr(null, err.Message));
            }
        }

        // GET: api/AkunCS/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Response<AkunCs>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseNotFound), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseErr), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AkunCs>> GetAkunCs(int id)
        {
            var akunCs = await _context.AkunCs.Include(e => e.User).FirstOrDefaultAsync(e => e.id_akunCs == id);

            if (akunCs == null)
            {
                return NotFound();
            }

            return akunCs;
        }

        // PUT: api/AkunCS/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AkunCs))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseNotFound))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseErr))]
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
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AkunCs))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseErr))]
        public async Task<ActionResult<AkunCs>> PostAkunCs([FromBody] AkunCSDto akunCs)
        {
            if (await _context.AkunCs.AnyAsync(a => a.user_id == akunCs.user_id))
            {
                return BadRequest(new ResponseErr("error", "id user is already exist"));
            }
            try
            {
                var akuncreate = _mapper.Map<AkunCs>(akunCs);

                _context.AkunCs.Add(akuncreate);
                await _context.SaveChangesAsync();

                // Cari kembali entitas AkunCs yang baru saja disimpan berdasarkan ID user yang diberikan
                var newAkun = await _context.AkunCs
                    .Include(a => a.User) // Menyertakan properti User dalam entitas AkunCs
                    .FirstOrDefaultAsync(a => a.user_id == akunCs.user_id);

                // Jika entitas AkunCs ditemukan, kembalikan respons dengan kode status 201 Created
                // serta URI untuk lokasi objek yang baru saja dibuat
                return CreatedAtAction(nameof(GetAkunCs), new { id = akuncreate.id_akunCs }, newAkun);
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErr(null, err.Message));
            }

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
