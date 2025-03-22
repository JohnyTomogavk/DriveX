using DotNetEnv;
using DriveX.API.Config;
using DriveX.API.Extensions;
using DriveX.Domain.Entities;
using DriveX.Infrastructure.Extensions;
using Scalar.AspNetCore;
using Serilog;

var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
if (env == "Development")
{
    Env.Load("../.env");
}

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureAPIServices();
builder.Services.ConfigureInfrastructureServices();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseMinimalApiEndpoints();

app.Run();
