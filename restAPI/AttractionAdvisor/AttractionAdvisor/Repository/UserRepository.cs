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
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<int> AddUser(User user)
        {
            var userExists = await _context.Users.AnyAsync(
             x => x.UserName == user.UserName);

             if (userExists)
             throw new Exception("User already exists");

            var result = await _context.Users.AddAsync(user);
           
            result.SetPassword(user.Password);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task<User> UpdateUser(User user)
        {
          
            var result = await _context.Users
                .FirstOrDefaultAsync(e => e.Id == user.Id);

            if (result != null)
            {
                result.UserName = user.UserName;
                result.Password = user.Password;
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

        public async Task<User> LoginUser(string userName, string password)
        {
            var user = await _context.Users
            .SingleOrDefaultAsync(u => u.UserName == userName);

            if (user == null) 
                return null;

            if (!user.ValidatePassword(password))
                return null;

            return user;
          
        }       
    }
    }

