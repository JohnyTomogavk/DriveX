using DriveX.Application.Interfaces;
using DriveX.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DriveX.Infrastructure.Config;

public static class DbContextConfiguration
{
    public static void ConfigureDbContext(this IServiceCollection serviceCollection)
    {
        var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        ArgumentNullException.ThrowIfNull(connectionString);

        serviceCollection.AddDbContext<AppDbContext>(options => { options.UseNpgsql(connectionString); });
        serviceCollection.AddScoped<IAppDbContext, AppDbContext>();
    }
}
