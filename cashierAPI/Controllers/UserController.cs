using cashierAPI.database;
using cashierAPI.dto;
using cashierAPI.Models;
using cashierAPI.Repositories;
using cashierAPI.src.util;
using Microsoft.AspNetCore.Mvc;


namespace cashierAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserRepo _UserRepo;
    private readonly DatabaseContext _context;

    public UserController(DatabaseContext context)
    {
        _context = context;
        _UserRepo = new UserRepo(_context);
    }

    [HttpGet]
    [ProducesResponseType(typeof(Respons<UserDto>), 200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    // [ProducesResponseType(typeof(ErrorResponse), 500)]
    public IActionResult GetUsers()
    {
        try
        {
            var userList = _UserRepo.GetUser();

            if (userList == null || userList.Count == 0)
            {
                return NotFound();
            }

            var response = new Respons<UserDto>(userList);

            return Ok(response);
        }
        catch (Exception ex)
        {
            // Tangani kesalahan dan kirim respons yang sesuai
            return StatusCode(StatusCodes.Status500InternalServerError, "error : " + ex.Message);
        }
    }

    [HttpPost]
    [ProducesResponseType(typeof(UserDto), 201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public IActionResult CreateUser(UserDto userDto)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        try
        {
            var user = new User
            {
                nama_user = userDto.nama_user,
                email = userDto.email,
                password = userDto.password,
                gender = userDto.gender,
                no_telpon = userDto.no_telpon,
                alamat = userDto.alamat
            };

            var createUser = _UserRepo.CreateUser(user);

            return CreatedAtAction(nameof(GetUsers), new { id = createUser.id_user }, createUser);

        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "error : " + ex.Message);
        }
    }
}
