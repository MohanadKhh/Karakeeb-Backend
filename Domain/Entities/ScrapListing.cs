using System.Collections.Generic;
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class ScrapListing : AuditableEntity
{
    public Guid SellerId { get; set; }
    public Seller Seller { get; set; } = null!;

    public Guid CategoryId { get; set; }
    public ScrapCategory Category { get; set; } = null!;

    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Quantity { get; set; }
    public string Unit { get; set; } = null!;
    public decimal AskingPrice { get; set; }
    public string PriceUnit { get; set; } = null!;
    public string Location { get; set; } = null!;
    public ListingStatus Status { get; set; }

    public ICollection<ListingImage> Images { get; set; } = new List<ListingImage>();
    public ICollection<Offer> Offers { get; set; } = new List<Offer>();
}