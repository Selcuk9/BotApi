using BotApi.DiContainer;
using BotApi.MapperProfiles;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;
// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
services.AddCors();
services.AddControllers();
services.AddAutoMapper(typeof(ServiceProfile));
services.AddGrpc();
services.AddGrpcDbClients(new Uri(configuration["DataBaseService:Address"]));
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Description = "Docs for my API", Version = "v1" });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

app.UseCors();
app.UseRouting();
app.UseEndpoints(endpoints => { endpoints.MapControllers();});

app.Run();
