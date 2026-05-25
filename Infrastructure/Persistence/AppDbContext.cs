using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<BaseUser> Users { get; set; } = null!;
    public DbSet<Seller> Sellers { get; set; } = null!;
    public DbSet<Buyer> Buyers { get; set; } = null!;
    public DbSet<ScrapCategory> ScrapCategories { get; set; } = null!;
    public DbSet<ScrapListing> ScrapListings { get; set; } = null!;
    public DbSet<ListingImage> ListingImages { get; set; } = null!;
    public DbSet<Offer> Offers { get; set; } = null!;
    public DbSet<OfferCounter> OfferCounters { get; set; } = null!;
    public DbSet<Deal> Deals { get; set; } = null!;
    public DbSet<Review> Reviews { get; set; } = null!;
    public DbSet<Notification> Notifications { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}