using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class OfferConfiguration : IEntityTypeConfiguration<Offer>
{
    public void Configure(EntityTypeBuilder<Offer> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.OfferedPrice).HasPrecision(18, 2);
        builder.Property(o => o.Note).HasMaxLength(1000);

        builder.Property(o => o.CreatedAt).HasDefaultValueSql("GETUTCDATE()");

        builder.HasMany(o => o.Counters)
            .WithOne(c => c.Offer)
            .HasForeignKey(c => c.OfferId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}