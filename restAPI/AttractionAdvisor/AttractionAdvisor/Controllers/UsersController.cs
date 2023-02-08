using Microsoft.AspNetCore.Mvc;
using AttractionAdvisor.Models;
using AttractionAdvisor.Interfaces;

namespace AttractionAdvisor.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost("login")]
    public async Task<ActionResult<int>> Login(User user)
    {
        try
        {
            var result = await _userRepository.LoginUser(
                user.Username,user.Password);
            if(result == null) 
                return Unauthorized();

            return Ok(result.Id);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                ex.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        try
        {
            return Ok(await _userRepository.GetUsers());
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                ex.Message);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<UserDto>> GetUser(int id)
    {
        if (id <= 0)
            return BadRequest();
            
        try
        {
            var result = await _userRepository.GetUser(id);
            if (result == null) 
                return NotFound();

            return Ok(result.Username);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateUser(User user)
    {
        try
        {
            var createdUser = await _userRepository.AddUser(user);
                
            return Ok(createdUser.Id);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                ex.Message);
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<int>> UpdateUser(User user, int id)
    {
        if (id <= 0)
            return BadRequest();

        try
        {
            var userExists = await _userRepository.GetUser(id);
            if (userExists == null)
                return NotFound();

            user.Id = id;

            var updatedUser = await _userRepository.UpdateUser(user);
            if (updatedUser == null)
                return BadRequest();

            return Ok(updatedUser.Id);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                ex.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteUser(int id)
    {
        try
        {
            if (!await _userRepository.DeleteUser(id))
                return NotFound();

            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                ex.Message);
        }
    }
}