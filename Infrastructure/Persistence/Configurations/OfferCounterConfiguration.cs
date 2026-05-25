using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class OfferCounterConfiguration : IEntityTypeConfiguration<OfferCounter>
{
    public void Configure(EntityTypeBuilder<OfferCounter> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.ProposedPrice).HasPrecision(18, 2);
        builder.Property(c => c.Note).HasMaxLength(1000);
        builder.Property(c => c.CreatedAt).HasDefaultValueSql("GETUTCDATE()");

        builder.HasOne(c => c.SentByUser)
            .WithMany()
            .HasForeignKey(c => c.SentByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}