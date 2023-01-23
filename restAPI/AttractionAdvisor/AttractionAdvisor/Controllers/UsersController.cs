using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using AttractionAdvisor.DataAccess;
using Microsoft.EntityFrameworkCore;
using AttractionAdvisor.Models;
using AttractionAdvisor.Interfaces;
using AttractionAdvisor.Repository;

namespace AttractionAdvisor.Controllers
{
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

        public async Task<ActionResult<User>> Login(string userName, string password)
        {
            try
            {
               var result = await _userRepository.LoginUser(userName,password);

                if(result == null) 
                return Unauthorized("Wrong username or password");

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Failed to log in!");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            try
            {
                return Ok(await _userRepository.GetUsers());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            try
            {
                var result = await _userRepository.GetUserById(id);

                if (result == null) 
                    return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateUser(User user)
        {
            if (user == null)
                return BadRequest();

            try
            {
                var createdUser = await _userRepository.AddUser(user);
                
                return CreatedAtAction(nameof(GetUserById),
                    new { id = createdUser.Id}, createdUser.Id;);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new user record");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(User user)
        {
            if (user == null)
                return BadRequest();

            if (user.Id == 0)
                return BadRequest();

            try
            {
                var userToUpdate = await _userRepository.GetUserById(user.Id);

                if (userToUpdate == null)
                    return NotFound($"User with Id = {id} not found");

                return await _userRepository.UpdateUser(user);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            try
            {
                var userToDelete = await _userRepository.GetUserById(id);

                if (userToDelete == null)
                {
                    return NotFound($"User with Id = {id} not found");
                }

                return await _userRepository.DeleteUser(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
