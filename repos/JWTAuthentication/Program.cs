using JWTAuthentication.Data;
using JWTAuthentication.Service;
using JWTAuthentication.repo;
using Microsoft.EntityFrameworkCore;
using JWTAuthentication.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Register the LoginService and TokenService to the DI container
builder.Services.AddScoped<ILoginService, Loginrepo>(); // Register ILoginService to Loginrepo
builder.Services.AddScoped<TokenService>();

// Configure the DbContext with the connection string from appsettings.json
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConn"))
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
