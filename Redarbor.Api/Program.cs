using Redarbor.Application.DependencyInjection;
using Redarbor.Infrastructure.DependencyInjection;
using Redarbor.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Agregar variables de entorno
builder.Configuration.AddEnvironmentVariables();
// Configuración y servicios de infraestructura
builder.Services.AddInfrastructure(builder.Configuration);

// Servicios de Application (MediaTr, FluentValidation, etc.)
builder.Services.AddApplication();

// Controllers 
builder.Services.AddControllers();

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

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
