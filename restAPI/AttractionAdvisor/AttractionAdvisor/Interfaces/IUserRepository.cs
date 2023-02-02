using AttractionAdvisor.Models;

namespace AttractionAdvisor.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers(); 
        Task<User?> GetUser(int id); 
        Task<User> AddUser(User user);
        Task<User?> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
        Task<User?> LoginUser(string username, string password);
    }
}
