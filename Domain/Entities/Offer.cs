using System;
using System.Collections.Generic;
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Offer : AuditableEntity
{
    public Guid ListingId { get; set; }
    public ScrapListing Listing { get; set; } = null!;

    public Guid BuyerId { get; set; }
    public Buyer Buyer { get; set; } = null!;

    public decimal OfferedPrice { get; set; }
    public string? Note { get; set; }
    public OfferStatus Status { get; set; }

    public ICollection<OfferCounter> Counters { get; set; } = new List<OfferCounter>();
}