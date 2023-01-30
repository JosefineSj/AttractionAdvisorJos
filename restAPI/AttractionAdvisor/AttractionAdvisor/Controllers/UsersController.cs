using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using AttractionAdvisor.DataAccess;
using Microsoft.EntityFrameworkCore;
using AttractionAdvisor.Models;
using AttractionAdvisor.Interfaces;
using AttractionAdvisor.Repository;
using Microsoft.AspNetCore.Cors;

namespace AttractionAdvisor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("CorsPolicy")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("login")]

        public async Task<ActionResult<User>> Login([FromBody] LoginDto login)
        {
            try
            {
               var result = await _userRepository.LoginUser(
                   login.username,login.password);
                if(result == null) 
                    return Unauthorized();


                return Ok(result.Username + result.Id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
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
        public async Task<ActionResult<User>> GetUser(int id)
        {
            if (id <= 0)
                return BadRequest();
            
            try
            {
                var result = await _userRepository.GetUser(id);
                if (result == null) 
                    return NotFound();

                return Ok(result);
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
                
                return Ok(CreatedAtAction(nameof(GetUser),
                    new { id = createdUser.Id}, createdUser.Id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<User>> UpdateUser(User user)
        {
            if (user.Id <= 0)
                return BadRequest();

            try
            {
                var userToUpdate = await _userRepository.GetUser(user.Id);
                if (userToUpdate == null)
                    return NotFound();

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
        public async Task<ActionResult<bool>> DeleteUser(int id)
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
}
