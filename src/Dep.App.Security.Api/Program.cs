using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Tokens;

using Dep.App.Security.Entities;
using Dep.App.Security.Logic.Implementations;
using Dep.App.Security.Logic.Interfaces;
using Dep.App.Security.Persistence;

using Serilog;
using System.Text;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSqlServer<DepSecurityDB_DEVDBContext>(builder.Configuration.GetConnectionString("Default"));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.MapGet("/api/genre", async (DepSecurityDB_DEVDBContext db) => { return db.Genres.ToListAsync(); });

app.MapGet("/api/genre", async (DepSecurityDB_DEVDBContext db) => await db.Genres.ToListAsync());

app.MapPost("/api/genre", async (DtoGenre request, DepSecurityDB_DEVDBContext db, HttpContext context) =>
{
    var entity = new Genre
    {
        Description = request.Description,
        Status = true
    };

    db.Genres.Add(entity);
    await db.SaveChangesAsync();

    context.Response.Headers.Add("location",$"/api/genre/{entity.Id}");
});

app.Run();

public record DtoGenre (string Description);