using DotNetEnv;
using TechStore.Errors.Global;
using TechStore.Extensions;
using TechStore.Interfaces;
using TechStore.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Cargar las variables de entorno desde el archivo .env
Env.Load();

// Add services to the container.
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddSwaggerServices(); // Agrega Swagger

// Configura Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Agregar el middleware de manejo de excepciones personalizado.
app.UseMiddleware<ExceptionMiddleware>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Asegúrate de que UseAuthentication está antes de UseAuthorization
app.UseAuthentication();
app.UseAuthorization();

app.UseSwaggerServices(); // Configura Swagger

app.MapControllers();

app.Run();
