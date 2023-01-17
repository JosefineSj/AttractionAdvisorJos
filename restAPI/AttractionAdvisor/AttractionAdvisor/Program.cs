using AttractionAdvisor.DataAccess;
using AttractionAdvisor.API;
using AttractionAdvisor.Utils;
using AttractionAdvisor.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<AttractionAdvisorDbContext>(
//    options => options.UseSqlServer(
//        builder.Configuration.GetConnectionString("AttractionAdvisorConnection")));

var app = builder.Build();

var serviceCollection = new ServiceCollection();
serviceCollection.AddDbContext<AttractionAdvisorDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("AttractionAdvisorConnection")));

var serviceProvider = serviceCollection.BuildServiceProvider();
var context = serviceProvider.GetService<AttractionAdvisorDbContext>();
var userHandler = new UserHandler(context);

app.UseHttpsRedirection();

app.MapPost("api/login", async (HttpRequest request, HttpResponse response) =>
{
    // Validate request.
    if (!Utils.ValidateRequest(request))
    {
        response.StatusCode = 400;
        await response.WriteAsJsonAsync(new { message = "Invalid request." });
    }

    // Deserialize request JSON to Models.User.
    var user = await Utils.Deserialize<User>(request);
    
    var loggedIn = await userHandler.Login(user);
    if (!loggedIn)
    {
        response.StatusCode = 401;
        await response.WriteAsJsonAsync(new { message = "Invalid username or password" });
    }
    else
    {
        response.StatusCode = 200;
        await response.WriteAsJsonAsync(new { message = "Logged in successfully" });
    }
});

app.Run("http://localhost:8080");