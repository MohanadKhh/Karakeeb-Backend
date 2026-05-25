namespace Karakeeb.Domain;

public class Offer
{
    public int Id { get; set; }
    public decimal OfferedPrice { get; set; }
    public string? Note { get; set; }
    public OfferStatus Status { get; set; } = OfferStatus.Pending;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // FK
    public int ScrapItemId { get; set; }
    public int BuyerId { get; set; }

    // Navigation
    public ScrapItem ScrapItem { get; set; } = null!;
    public Deal? Deal { get; set; }
}