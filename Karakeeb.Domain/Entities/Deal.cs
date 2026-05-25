namespace Karakeeb.Domain;

public class Deal
{
    public int Id { get; set; }
    public decimal FinalPrice { get; set; }
    public DealStatus Status { get; set; } = DealStatus.Pending;
    public string? SellerPhone { get; set; }
    public string? SellerEmail { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // FK
    public int OfferId { get; set; }
    public int ScrapItemId { get; set; }
    public int SellerId { get; set; }
    public int BuyerId { get; set; }

    // Navigation
    public Offer Offer { get; set; } = null!;
    public ScrapItem ScrapItem { get; set; } = null!;
}