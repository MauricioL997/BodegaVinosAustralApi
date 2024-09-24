using BodegaVinosAustral.Data;
using BodegaVinosAustral.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Registrar el repositorio en memoria como singleton
builder.Services.AddSingleton<InMemoryRepository>();

// Registrar los servicios de vinos y usuarios
builder.Services.AddScoped<WineService>();
builder.Services.AddScoped<UserService>();

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
