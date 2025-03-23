using DotNetEnv;
using DriveX.API.Config;
using DriveX.API.Middlewares;
using DriveX.Infrastructure.Extensions;
using FastEndpoints;
using Scalar.AspNetCore;
using Serilog;

var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
if (env == "Development")
{
    Env.Load("../.env");
}

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.ConfigureAPIServices();
builder.Services.ConfigureInfrastructureServices();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler();

app.UseAuthentication();
app.UseAuthorization();

app.UseFastEndpoints(opt => { opt.Endpoints.RoutePrefix = "api"; });

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();

app.Run();
