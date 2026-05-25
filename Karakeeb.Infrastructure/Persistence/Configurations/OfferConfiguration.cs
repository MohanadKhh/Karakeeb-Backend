using Karakeeb.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Karakeeb.Infrastructure;

public class OfferConfiguration : IEntityTypeConfiguration<Offer>
{
    public void Configure(EntityTypeBuilder<Offer> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.OfferedPrice)
            .HasPrecision(18, 2);

        builder.Property(o => o.Note)
            .HasMaxLength(1000);

        builder.Property(o => o.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(o => o.UpdatedAt)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.HasOne(o => o.ScrapItem)
            .WithMany(i => i.Offers)
            .HasForeignKey(o => o.ScrapItemId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(o => o.Deal)
            .WithOne(d => d.Offer)
            .HasForeignKey<Deal>(d => d.OfferId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(o => o.BuyerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
