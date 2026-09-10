using Microsoft.EntityFrameworkCore;
using VehiculoRest.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Agregar soporte para controladores
builder.Services.AddControllers();
builder.Services.AddCors(options => options.AddPolicy("AllowAngular", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

// 2. Configuración de la conexión a SQL Server
builder.Services.AddDbContext<VehiculoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VehiculosConnection")));

// COMENTADO para evitar el error de compilación CS0200:
// builder.Services.AddOpenApi(); 

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // COMENTADO para evitar el error de compilación CS0200:
    // app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("AllowAngular");
// 3. Mapear las rutas de los controladores
app.MapControllers();

app.Run();