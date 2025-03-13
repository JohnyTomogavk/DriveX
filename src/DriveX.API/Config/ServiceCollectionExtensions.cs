using FluentValidation;

namespace DriveX.API.Config;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureAPIServices(this IServiceCollection services)
    {
        services.AddOpenApi();
        services.ConfigureSerilog();
        services.AddValidatorsFromAssemblyContaining<Program>();
        services.ConfigureMetiatR();

        return services;
    }
}
