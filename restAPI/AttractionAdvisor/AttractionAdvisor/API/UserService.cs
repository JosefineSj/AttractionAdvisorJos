using Newtonsoft.Json;

namespace AttractionAdvisor.API;
using DataAccess;

class UserService
{
    private readonly AttractionAdvisorDbContext _context;
    public UserService(AttractionAdvisorDbContext context)
    {
        _context = context;
    }
    
    public async Task<int> Register(HttpRequest request)
    {
        string json = await new StreamReader(request.Body).ReadToEndAsync();
        var user = JsonConvert.DeserializeObject<Models.User>(json);
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user.Id;
    }
}