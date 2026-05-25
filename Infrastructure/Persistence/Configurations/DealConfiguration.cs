using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class DealConfiguration : IEntityTypeConfiguration<Deal>
{
    public void Configure(EntityTypeBuilder<Deal> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.FinalPrice).HasPrecision(18, 2);
        builder.Property(d => d.SellerPhone).HasMaxLength(20);
        builder.Property(d => d.SellerEmail).HasMaxLength(256);

        builder.Property(d => d.CreatedAt).HasDefaultValueSql("GETUTCDATE()");

        builder.HasIndex(d => d.OfferId).IsUnique();

        builder.HasOne(d => d.Offer)
            .WithOne()
            .HasForeignKey<Deal>(d => d.OfferId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.Listing)
            .WithMany()
            .HasForeignKey(d => d.ListingId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}