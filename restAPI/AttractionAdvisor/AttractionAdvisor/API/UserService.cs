using System.Text.Json;

namespace AttractionAdvisor.API;
using DataAccess;

class UserService
{
    private readonly AttractionAdvisorDbContext _context;
    public UserService(AttractionAdvisorDbContext context)
    {
        _context = context;
    }

    public async Task<Models.User> Lmao(HttpRequest request)
    {
        var json = await new StreamReader(request.Body).ReadToEndAsync();
        var optionsD = new JsonSerializerOptions {PropertyNameCaseInsensitive = true};
        var user = JsonSerializer.Deserialize<Models.User>(json, optionsD);

        var newUser = user;
        newUser.Name += "Gasimov";

        return newUser;
    }
    
    public async Task<int> Register(HttpRequest request)
    {
        string json = await new StreamReader(request.Body).ReadToEndAsync();
        var options = new JsonSerializerOptions {PropertyNameCaseInsensitive = true};
        var user = JsonSerializer.Deserialize<Models.User>(json, options);
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user.Id;
    }
}