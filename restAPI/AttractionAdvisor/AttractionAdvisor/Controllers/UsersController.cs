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
            _userRepository = userRepository;   //Bättre än att använda this.
        }
        private readonly User _password;
      

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

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            try
            {
                if (user == null)
                    return BadRequest();

                var createdUser = await _userRepository.AddUser(user);
               
                
                return CreatedAtAction(nameof(GetUserById),
                    new { id = createdUser.Id, userName = createdUser.UserName}, createdUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new user record");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, User user)
        {
            try
            {
                if (id != user.Id)
                    return BadRequest("User ID mismatch");

                var userToUpdate = await _userRepository.GetUserById(id);

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

