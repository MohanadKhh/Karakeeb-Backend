using System;
using Domain.Common;

namespace Domain.Entities;

public class ListingImage : BaseEntity
{
    public Guid ListingId { get; set; }
    public ScrapListing Listing { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;
    public bool IsPrimary { get; set; }
    public DateTime UploadedAt { get; set; }
}