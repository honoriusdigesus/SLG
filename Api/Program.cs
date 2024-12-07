using Application.Exceptions;
using Application.Mappers;
using Application.Services;
using Application.Utils;
using Domain.Interfaces;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Agregar el filtro de excepciones personalizado
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ErrorHandler>(); 
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyectamos la dependencia 
builder.Services.AddScoped<IZoneServices, ZoneService>();
builder.Services.AddScoped<IZoneRepository, ZoneRepository>();
builder.Services.AddScoped<ZoneMapper>();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<EmployeeMapper>();


builder.Services.AddScoped<MyValidator>();
builder.Services.AddScoped<UtilsJwt>();

//Inyectamos la dependencia de la base de datos de Postgres
builder.Services.AddDbContext<SlgDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

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
