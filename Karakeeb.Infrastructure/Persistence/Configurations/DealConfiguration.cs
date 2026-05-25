using Karakeeb.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Karakeeb.Infrastructure;

public class DealConfiguration : IEntityTypeConfiguration<Deal>
{
    public void Configure(EntityTypeBuilder<Deal> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.FinalPrice)
            .HasPrecision(18, 2);

        builder.Property(d => d.SellerPhone)
            .HasMaxLength(20);

        builder.Property(d => d.SellerEmail)
            .HasMaxLength(256);

        builder.Property(d => d.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(d => d.UpdatedAt)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.HasOne(d => d.Offer)
            .WithOne(o => o.Deal)
            .HasForeignKey<Deal>(d => d.OfferId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.ScrapItem)
            .WithMany()
            .HasForeignKey(d => d.ScrapItemId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(d => d.SellerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(d => d.BuyerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
