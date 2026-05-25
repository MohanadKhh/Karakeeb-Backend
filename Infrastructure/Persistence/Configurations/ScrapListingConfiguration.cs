using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ScrapListingConfiguration : IEntityTypeConfiguration<ScrapListing>
{
    public void Configure(EntityTypeBuilder<ScrapListing> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Title).IsRequired().HasMaxLength(200);
        builder.Property(l => l.Description).HasMaxLength(2000);
        builder.Property(l => l.Unit).IsRequired().HasMaxLength(50);
        builder.Property(l => l.PriceUnit).IsRequired().HasMaxLength(50);
        builder.Property(l => l.Location).IsRequired().HasMaxLength(500);

        builder.Property(l => l.Quantity).HasPrecision(18, 2);
        builder.Property(l => l.AskingPrice).HasPrecision(18, 2);

        builder.Property(l => l.CreatedAt).HasDefaultValueSql("GETUTCDATE()");

        builder.HasMany(l => l.Images)
            .WithOne(i => i.Listing)
            .HasForeignKey(i => i.ListingId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(l => l.Offers)
            .WithOne(o => o.Listing)
            .HasForeignKey(o => o.ListingId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}