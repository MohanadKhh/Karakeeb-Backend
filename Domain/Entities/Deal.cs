using System;
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Deal : AuditableEntity
{
    public Guid OfferId { get; set; }
    public Offer Offer { get; set; } = null!;

    public Guid ListingId { get; set; }
    public ScrapListing Listing { get; set; } = null!;

    public Guid SellerId { get; set; }
    public Seller Seller { get; set; } = null!;

    public Guid BuyerId { get; set; }
    public Buyer Buyer { get; set; } = null!;

    public decimal FinalPrice { get; set; }
    public string? SellerPhone { get; set; }
    public string? SellerEmail { get; set; }
    public DealStatus Status { get; set; }
}