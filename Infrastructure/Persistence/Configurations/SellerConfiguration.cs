using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class SellerConfiguration : IEntityTypeConfiguration<Seller>
{
    public void Configure(EntityTypeBuilder<Seller> builder)
    {
        builder.HasMany(s => s.ScrapListings)
            .WithOne(sl => sl.Seller)
            .HasForeignKey(sl => sl.SellerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(s => s.Deals)
            .WithOne(d => d.Seller)
            .HasForeignKey(d => d.SellerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}