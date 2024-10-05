using DotNetEnv;
using TechStore.Errors.Global;
using TechStore.Extensions;
using TechStore.Interfaces;
using TechStore.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Cargar las variables de entorno desde el archivo .env
Env.Load();

// Llamar a tu extensión para añadir servicios de identidad
builder.Services.AddIdentityServices(builder.Configuration);

// Llama al método de extensión para configurar la base de datos
builder.Services.AddDatabaseConfiguration(builder.Configuration);
// Add services to the container.

builder.Services.AddControllers(options => {
    options.Filters.Add<GlobalExceptionFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthorization();

app.MapControllers();

app.Run();
