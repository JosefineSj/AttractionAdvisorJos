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

        public async Task<User?> GetUser(int id)
        {
            var result = await _context.Users.FirstOrDefaultAsync(
                e => e.Id == id);
            
            return result ?? null;
        }

        public async Task<User> AddUser(User user)
        {
            var userExists = await _context.Users.AnyAsync(
             x => x.UserName == user.UserName);
             if (userExists)
                throw new Exception("user already exists");

            user.SetPassword(user.PasswordHash);
            var result = await _context.Users.AddAsync(user);
           
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<User?> UpdateUser(User user)
        {
            var result = await _context.Users
                .FirstOrDefaultAsync(e => e.Id == user.Id);

            if (result == null)
                return null;

            result.UserName = user.UserName;
            result.PasswordHash = user.PasswordHash;
            
            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var result = await _context.Users
                .FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
                return false;
            
            _context.Users.Remove(result);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<User?> LoginUser(string userName, string password)
        {
            var user = await _context.Users
            .FirstOrDefaultAsync(u => u.UserName == userName);

            if (user == null) 
                return null;

            if (!user.ValidatePassword(password))
                return null;

            return user;
        }       
    }
}

