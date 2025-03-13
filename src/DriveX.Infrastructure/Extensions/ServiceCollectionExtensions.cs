using DriveX.Infrastructure.Config;
using Microsoft.Extensions.DependencyInjection;

namespace DriveX.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.ConfigureDbContext();

        return serviceCollection;
    }
}
