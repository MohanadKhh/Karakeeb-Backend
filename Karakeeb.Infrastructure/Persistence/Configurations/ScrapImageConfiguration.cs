using Karakeeb.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Karakeeb.Infrastructure;

public class ScrapImageConfiguration : IEntityTypeConfiguration<ScrapImage>
{
    public void Configure(EntityTypeBuilder<ScrapImage> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.ImageUrl)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(i => i.UploadedAt)
            .HasDefaultValueSql("GETUTCDATE()");
    }
}
