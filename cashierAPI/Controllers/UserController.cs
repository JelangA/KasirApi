using cashierAPI.database;
using cashierAPI.Models;
using cashierAPI.src.util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cashierAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly DatabaseContext _context;

    public UserController(DatabaseContext context)
    {
        _context = context;
    }

    [HttpGet]
    [ProducesResponseType(typeof(Response<User>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErr), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Response<User>>> Getusers()
    {
        try
        {
            var user = await _context.users.Include(u => u.AkunCs).ToListAsync();
            return new Response<User>(user);
        }
        catch (Exception err)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErr(null, err.Message));
        }
    }

    // GET: api/User/5
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseNotFound), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseErr), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var User = await _context.users.FindAsync(id);

        if (User == null)
        {
            return NotFound();
        }

        return User;
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(User))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseErr))]
    public async Task<ActionResult<User>> TambahUser([FromBody] User user)
    {
        try
        {
            _context.users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Getusers), new { id = user.id_user }, user);
        }
        catch (Exception err)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErr(null, err.Message));
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(User))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseErr))]
    public async Task<IActionResult> PutUser(int id, User user)
    {
        if (id != user.id_user)
        {
            return BadRequest();
        }

        _context.Entry(user).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
            return Ok(user);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!userExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(User))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseErr))]
    public async Task<IActionResult> DeleteUser(int id)
    {
        if (_context.users == null)
        {
            return NotFound();
        }
        var user = await _context.users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        _context.users.Remove(user);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool userExists(int id)
    {
        return (_context.users?.Any(e => e.id_user == id)).GetValueOrDefault();
    }
}
