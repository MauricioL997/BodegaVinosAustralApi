using BodegaVinosAustral.Data;
using BodegaVinosAustral.Services;
using Data;
using Microsoft.EntityFrameworkCore;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Registrar el repositorio en memoria como singleton
builder.Services.AddScoped<WineRepository>();
builder.Services.AddScoped<UserRepository>();


// Registrar los servicios de vinos y usuarios
builder.Services.AddScoped<WineService>();
builder.Services.AddScoped<UserService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlite(
        builder.Configuration["ConnectionStrings:DBConnectionString"],
        b => b.MigrationsAssembly("BodegaVinosAustral")));

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
