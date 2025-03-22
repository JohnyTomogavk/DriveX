using DriveX.Domain.Entities;
using DriveX.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace DriveX.Infrastructure.Config;

public static class IdentityConfiguration
{
    public static void ConfigureAuthentication(this IServiceCollection services)
    {
        services.AddIdentityCore<AppUser>();
        services.AddIdentity<AppUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
    }
}
