using AttractionAdvisor.Models;

namespace AttractionAdvisor.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers(); //IEnumerable är en lista. 
        Task<User> GetUserById(int id); //Behöver ingen IEunerable precis vill bara ha en användare.
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);

        Task<User> DeleteUser(int id);

        Task<User> LoginUser(int id);




    }
    
}
