using FastEndpoints;

namespace DriveX.API.Config;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureAPIServices(this IServiceCollection services)
    {
        services.AddOpenApi();
        services.ConfigureSerilog();
        services.ConfigureMetiatR();
        services.AddFastEndpoints();

        return services;
    }
}
