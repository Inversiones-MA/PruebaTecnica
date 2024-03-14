using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Services;
using Infrastructure.Mappers;
using Infrastructure.Repositories;
using Infrastructure.SqlServerContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(ApplicationProfile));
builder.Services.AddAutoMapper(typeof(SqlServerProfile));

builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

builder.Services.AddScoped<IRegionService, RegionService>();
builder.Services.AddScoped<IRegionRepository, RegionRepository>();

builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ICityRepository, CityRepository>();

builder.Services.AddScoped<ICommuneService, CommuneService>();
builder.Services.AddScoped<ICommuneRepository, CommuneRepository>();

builder.Services.AddDbContext<PruebaTecnicaContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Define CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder
            .WithOrigins("http://localhost:5173")
            .AllowAnyMethod() // Permitir todos los métodos HTTP
            .AllowAnyHeader() // Permitir todos los encabezados HTTP
            .AllowCredentials()); // Permitir credenciales (si es necesario)
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
