using DotNetEnv;
using DriveX.API.Config;
using DriveX.API.Extensions;
using DriveX.Infrastructure.Extensions;
using FluentValidation;
using Scalar.AspNetCore;
using Serilog;

var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
if (env == "Development")
{
    Env.Load("../.env");
}

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.ConfigureSerilog();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.ConfigureInfrastructureServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseMinimalApiEndpoints();

app.Run();
