namespace Karakeeb.Domain;

public class ScrapItem
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Quantity { get; set; }
    public string Unit { get; set; } = null!; // Kg, Ton, Piece
    public decimal Price { get; set; }
    public string PriceUnit { get; set; } = null!; // Per Kg, Per Ton
    public string Location { get; set; } = null!;
    public bool IsAvailable { get; set; } = true;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // FK
    public int SellerId { get; set; }
    public int CategoryId { get; set; }

    // Navigation
    public ScrapCategory Category { get; set; } = null!;
    public ICollection<ScrapImage> Images { get; set; } = new HashSet<ScrapImage>();
    public ICollection<Offer> Offers { get; set; } = new HashSet<Offer>();
}
