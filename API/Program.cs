using API.Data;
using API.Extensions;
using API.Interfaces;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AddDbConnection
builder.Services.AddDbConnection(builder.Configuration);

// Identity
builder.Services.AddIdentityServiceExtensions(builder.Configuration);

// Interfaces
builder.Services.AddScoped<IOffers, Offers>();
builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();

// DefaultData on program build
using (var scope = app.Services.CreateAsyncScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    db.Database.Migrate();
    await SeedData.AddDefaultData(db);
    await SeedData.AddDefaultUser(userManager);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
