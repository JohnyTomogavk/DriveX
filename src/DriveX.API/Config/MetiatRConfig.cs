namespace DriveX.API.Config;

public static class MetiatRConfig
{
    public static IServiceCollection ConfigureMetiatR(this IServiceCollection services)
    {
        services.AddMediatR(options => { options.RegisterServicesFromAssemblies(typeof(Program).Assembly); });

        return services;
    }
}
