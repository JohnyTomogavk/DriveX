using System.ComponentModel.DataAnnotations;
using DriveX.Domain.Exceptions;
using DriveX.Domain.Exceptions.Users;
using FastEndpoints;
using Microsoft.AspNetCore.Diagnostics;

namespace DriveX.API.Middlewares;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError(exception, exception.Message);

        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Detail = exception.Message,
        };

        problemDetails.Status = exception switch
        {
            AppValidationException => StatusCodes.Status400BadRequest,
            UserRegistrationException => StatusCodes.Status409Conflict,
            AppEntityDuplicateException => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError
        };

        if (problemDetails.Status == StatusCodes.Status500InternalServerError)
        {
            problemDetails.Detail = "Internal Server Error";
        }

        httpContext.Response.StatusCode = problemDetails.Status;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}
