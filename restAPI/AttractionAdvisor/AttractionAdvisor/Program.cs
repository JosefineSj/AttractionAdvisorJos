using AttractionAdvisor.DataAccess;
using AttractionAdvisor.API;
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

app.UseHttpsRedirection();
var serviceProvider = serviceCollection.BuildServiceProvider();
var context = serviceProvider.GetService<AttractionAdvisorDbContext>();
var userService = new UserService(context);

app.MapPost("register", async (HttpRequest request, HttpResponse response) =>
{
    var resp = await userService.Register(request);
    await response.WriteAsJsonAsync(resp);
});


// a sample endpoint for testing. works!
app.MapPost("lmao", async (HttpRequest request, HttpResponse response) =>
{
    var resp = await userService.Lmao(request);
    await response.WriteAsJsonAsync(resp);
});

app.Run("http://localhost:8080");


