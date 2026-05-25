using System;
using Domain.Common;

namespace Domain.Entities;

public class OfferCounter : BaseEntity
{
    public Guid OfferId { get; set; }
    public Offer Offer { get; set; } = null!;

    public Guid SentByUserId { get; set; }
    public BaseUser SentByUser { get; set; } = null!;

    public decimal ProposedPrice { get; set; }
    public string? Note { get; set; }
    public DateTime CreatedAt { get; set; }
}