using AttractionAdvisor.DataAccess;
using AttractionAdvisor.Interfaces;
using AttractionAdvisor.Models;
using Microsoft.EntityFrameworkCore;
using AttractionAdvisor.Utils;

namespace AttractionAdvisor.Repository
{
    public class UserRepository : IUserRepository

    {

        private readonly AttractionAdvisorDbContext _context;

        public UserRepository(AttractionAdvisorDbContext context)
        {
            _context = context;
        }

      

        public async Task<IEnumerable<User>> GetUsers()
        {
            //Get users from datbase:
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(e => e.Id == id);

        }

        public async Task<User> AddUser(User user)
        {
           
         
            var result = await _context.Users.AddAsync(user);
           
            var _user = new User();
            _user.SetPassword(user.Password);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<User> UpdateUser(User user)
        {
          
            var result = await _context.Users
                .FirstOrDefaultAsync(e => e.Id == user.Id);

            if (result != null)
            {
                result.UserName = user.UserName;
                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<User> DeleteUser(int id)
        {
            var result = await _context.Users.FindAsync(id);
            _context.Users.Remove(result);

            int affected = await _context.SaveChangesAsync();
            if (affected != 0)
                return result;
            else
                return null;

        }

        public Task<User> LoginUser(int id)
        {
            throw new NotImplementedException();
        }
    }

        
    }

