// See https://aka.ms/new-console-template for more information

using AttractionAdvisor.data_access;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AttractionAdvisorDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AttractionAdvisorConnection")));

var app = builder.Build();

app.UseHttpsRedirection();

app.Run();
