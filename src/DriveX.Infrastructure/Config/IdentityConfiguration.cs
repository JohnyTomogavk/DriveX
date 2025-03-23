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
        services.AddIdentity<AppUser, IdentityRole>(
                options =>
                {
                    options.Password.RequireDigit = true;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;

                    options.User.RequireUniqueEmail = true;
                })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders()
            .AddErrorDescriber<AppIdentityErrorDescriber>();
    }
}
