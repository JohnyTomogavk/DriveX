using DriveX.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DriveX.Infrastructure.Data;

public class AppDbContext : DbContext, IApplicationDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}
