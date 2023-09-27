using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ThreeTierLab.Filters;
using ThreeTierLab.Mappings;
using ThreeTierLab.Repository;
using ThreeTierLab.Repository.Models;
using ThreeTierLab.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(CustomExceptionFilter));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

// To prevent XSS, limit Cookie access.
builder.Services.AddAuthentication().AddCookie(c => c.Cookie.HttpOnly = true);

// DI DB
var config = builder.Configuration;
builder.Services.AddDbContext<LabDBContext>(options =>
{
    options.UseSqlServer(config.GetConnectionString("linkToDb"));
});

// DI custom services
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IUsersRepository,UserRepository>();

// Setup for TinyMapper
MapperConfig.Register();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
