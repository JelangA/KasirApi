using AutoMapper;
using cashierAPI.database;
using cashierAPI.Models;
using cashierAPI.Models.dto;
using cashierAPI.src.util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cashierAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly DatabaseContext _context;
    private readonly IMapper _mapper;
    public UserController(DatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(Response<User>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErr), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Response<User>>> Getusers()
    {
        try
        {   
            var user = await _context.users.ToListAsync();
            var res = new Response<User>(user);
            return Ok(res);
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
    public async Task<ActionResult<User>> TambahUser([FromBody] UserDto user)
    {
        try
        {
            var usercreate = _mapper.Map<User>(user);
            _context.users.Add(usercreate);
            await _context.SaveChangesAsync();

            var newUser = await _context.users.FindAsync(usercreate.id_user);
            return CreatedAtAction(nameof(Getusers), new { id = usercreate.id_user }, newUser);
        }
        catch (Exception err)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErr(null, err.Message));
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseNotFound))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseErr))]
    public async Task<IActionResult> PutUser(int id, UserDto user)
    {
        if (id <= 0)
        {
            return BadRequest();
        }

        var existingUser = await _context.users.FindAsync(id);

        if (existingUser == null)
        {
            return NotFound();
        }

        // Menggunakan AutoMapper untuk memetakan data dari userDto ke existingUser
        _mapper.Map(user, existingUser);

        try
        {
            await _context.SaveChangesAsync();
            var newUser = await _context.users.FindAsync(id);
            return Ok(newUser);
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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseNotFound))]
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

        return Ok(user);
    }

    private bool userExists(int id)
    {
        return (_context.users?.Any(e => e.id_user == id)).GetValueOrDefault();
    }
}
