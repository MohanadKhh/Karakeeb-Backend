using Karakeeb.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Karakeeb.Infrastructure;

public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
{
    public AppDbContext() : base() { }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<ScrapItem> ScrapItems => Set<ScrapItem>();
    public DbSet<ScrapImage> ScrapImages => Set<ScrapImage>();
    public DbSet<ScrapCategory> ScrapCategories => Set<ScrapCategory>();
    public DbSet<Offer> Offers => Set<Offer>();
    public DbSet<Deal> Deals => Set<Deal>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
