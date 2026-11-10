using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Reporting.Infrastructure.Identity;          // ← needed now, to find ApplicationUser

namespace Reporting.Infrastructure.Persistence;   // ← changed from .Identity

public class AppIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
        : base(options)
    {
    }
}