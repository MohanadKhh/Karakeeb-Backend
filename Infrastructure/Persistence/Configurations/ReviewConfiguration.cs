using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Rating).IsRequired();
        builder.ToTable(t => t.HasCheckConstraint("CK_Review_Rating", "Rating >= 1 AND Rating <= 5"));

        builder.Property(r => r.Comment).HasMaxLength(1000);
        builder.Property(r => r.CreatedAt).HasDefaultValueSql("GETUTCDATE()");

        builder.HasOne(r => r.Deal)
            .WithMany()
            .HasForeignKey(r => r.DealId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.ReviewerUser)
            .WithMany()
            .HasForeignKey(r => r.ReviewerUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.RevieweeUser)
            .WithMany()
            .HasForeignKey(r => r.RevieweeUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}