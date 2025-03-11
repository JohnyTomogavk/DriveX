using System.Reflection;
using DriveX.API.Endpoints.Base;
using FluentValidation;

namespace DriveX.API.Extensions;

public static class WebApplicationExtension
{
    public static void UseMinimalApiEndpoints(this WebApplication app)
    {
        var currentAssembly = Assembly.GetEntryAssembly();
        var endpointTypes = currentAssembly!.GetTypes()
            .Where(type => !type.IsAbstract && type.IsSubclassOf(typeof(ApiEndpointBase)))
            .ToList();

        using var serviceScope = app.Services.CreateScope();
        var serviceProvider = serviceScope.ServiceProvider;
        var logger = serviceProvider.GetRequiredService<ILogger<WebApplication>>();

        foreach (var endpointType in endpointTypes)
        {
            var endpointConfigValidator =
                serviceProvider.GetService(typeof(IValidator<ApiEndpointBase>)) as IValidator<ApiEndpointBase>;
            if (endpointConfigValidator == null)
            {
                var error = $"Endpoint type {endpointType.FullName} has no Validator defined";
                logger.LogError(error);
                throw new InvalidOperationException(error);
            }

            var endpointConfig = serviceProvider.GetRequiredService(endpointType) as ApiEndpointBase;
            if (endpointConfig == null)
            {
                var error = $"Failed to resolve endpoint type {endpointType.FullName}";
                logger.LogError(error);
                throw new InvalidOperationException(error);
            }

            var configValidationResult = endpointConfigValidator.Validate(endpointConfig);
            if (!configValidationResult.IsValid)
            {
                var errorMessage = string.Join('\n', configValidationResult.Errors.Select(x => x.ErrorMessage));
                var errorToLog = $"Endpoint config {endpointType.FullName} is not valid.\n {errorMessage}";
                logger.LogError(errorToLog);
                throw new InvalidOperationException(errorToLog);
            }

            var routeHandlerBuilder = app.MapMethods(
                endpointConfig.RequestPath,
                [endpointConfig.MapMethod.ToString()],
                endpointConfig.RequestHandler);

            endpointConfig.Configure(routeHandlerBuilder);
        }
    }
}
