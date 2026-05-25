using Karakeeb.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Karakeeb.Infrastructure;

public class ScrapItemConfiguration : IEntityTypeConfiguration<ScrapItem>
{
    public void Configure(EntityTypeBuilder<ScrapItem> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(i => i.Description)
            .IsRequired()
            .HasMaxLength(2000);

        builder.Property(i => i.Unit)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(i => i.PriceUnit)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(i => i.Location)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(i => i.Quantity)
            .HasPrecision(18, 2);

        builder.Property(i => i.Price)
            .HasPrecision(18, 2);

        builder.Property(i => i.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(i => i.UpdatedAt)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.HasMany(i => i.Images)
            .WithOne(img => img.ScrapItem)
            .HasForeignKey(img => img.ScrapItemId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(i => i.Offers)
            .WithOne(o => o.ScrapItem)
            .HasForeignKey(o => o.ScrapItemId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(i => i.SellerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
