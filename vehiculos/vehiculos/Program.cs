using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;
using Microsoft.EntityFrameworkCore;
using VehiculosSOAPB.Data;
using VehiculosSOAPB.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options => options.AddPolicy("AllowAngular", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

builder.Services.AddDbContext<VehiculosDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VehiculosConnection")));

builder.Services.AddTransient<VehiculoService>();

builder.Services.AddServiceModelServices();
builder.Services.AddServiceModelMetadata();
builder.Services.AddSingleton<IServiceBehavior>(new ServiceDebugBehavior
{
    IncludeExceptionDetailInFaults = true
});

var app = builder.Build();

app.UseServiceModel(serviceBuilder =>
{
    serviceBuilder.AddService<VehiculoService>();
    serviceBuilder.AddServiceEndpoint<VehiculoService, IVehiculoService>(
        new BasicHttpBinding(),
        "/VehiculoService.svc"
    );
});

var metadataBehavior = app.Services.GetRequiredService<ServiceMetadataBehavior>();
metadataBehavior.HttpGetEnabled = true;

app.UseCors("AllowAngular");
app.Run();