using Microsoft.EntityFrameworkCore;
using SmartMedsAPI.Data;
using SmartMedsAPI.Repositories.Interfaces;
using SmartMedsAPI.Repositories.Repos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Connect to SQL Lite through Entity Framework
builder.Services.AddDbContext<SmartMedsDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Default")));

// Register Repositories
builder.Services.AddScoped<IMedicationRepos, SQLiteMedicationRepos>();

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
