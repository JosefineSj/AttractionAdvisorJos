using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using AttractionAdvisor.DataAccess;
using Microsoft.EntityFrameworkCore;
using AttractionAdvisor.Models;

namespace AttractionAdvisor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly AttractionAdvisorDbContext _context;

        public UsersController(AttractionAdvisorDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
        /*private readonly IConfiguration _configuration;
        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        [HttpPost]
        
        public string registration(Models.User registration)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("AttractionAdvisorConnection").ToString());
            
            SqlCommand cmd = new SqlCommand("INSERT INTO Users(Id,UserName,Password)VALUES('"+registration.Id +"','" + registration.UserName + "','" + registration.Password +"' )", con);
            int i = cmd.ExecuteNonQuery();
            if(i> 0)
            {
                return "Data inserted";
            }
            else
            {
                return "Error";
            }
            
        }
    }*/

    }
}
