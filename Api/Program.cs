using System.Text;
using Application.Exceptions;
using Application.Mappers;
using Application.Services;
using Application.Utils;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

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
builder.Services.AddScoped<IZoneService, ZoneService>();
builder.Services.AddScoped<IZoneRepository, ZoneRepository>();
builder.Services.AddScoped<ZoneMapper>();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<EmployeeMapper>();

builder.Services.AddScoped<ICostCenterRepository, CostCenterRepository>();
builder.Services.AddScoped<ICostCenterService, CostCenterService>();
builder.Services.AddScoped<CostCenterMapper>();

builder.Services.AddScoped<ICreditCardRepository, CreditCardRepository>();
builder.Services.AddScoped<ICreditCardService, CreditCardService>();
builder.Services.AddScoped<CreditCardMapper>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<CategoryMapper>();

builder.Services.AddScoped<ITokenRepository, TokenRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<TokenMapper>();


builder.Services.AddScoped<MyValidator>();
builder.Services.AddScoped<UtilsJwt>();



//Inyectamos la dependencia de la base de datos de Postgres
builder.Services.AddDbContext<SlgDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]!))
        };
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
