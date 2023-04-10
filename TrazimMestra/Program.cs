using Infrastructure.Data;
using Infrastructure.Data.SeedData;
using System.Data;
using TrazimMestra.Extensions;
using TrazimMestra.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

app.UseRequestToken();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<ApplicationContext>();
var logger = services.GetRequiredService<ILogger<Program>>();

try
{
    await SeedDb.SeedAsync(context);
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occured");
}

app.Run();
