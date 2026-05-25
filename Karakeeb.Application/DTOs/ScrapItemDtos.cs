namespace Karakeeb.Application;

public class ScrapItemDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Quantity { get; set; }
    public string Unit { get; set; } = null!;
    public decimal Price { get; set; }
    public string PriceUnit { get; set; } = null!;
    public string Location { get; set; } = null!;
    public bool IsAvailable { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int SellerId { get; set; }
    public int CategoryId { get; set; }
}

public class CreateScrapItemDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Quantity { get; set; }
    public string Unit { get; set; } = null!;
    public decimal Price { get; set; }
    public string PriceUnit { get; set; } = null!;
    public string Location { get; set; } = null!;
    public bool IsAvailable { get; set; }
    public int SellerId { get; set; }
    public int CategoryId { get; set; }
}

public class UpdateScrapItemDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Quantity { get; set; }
    public string Unit { get; set; } = null!;
    public decimal Price { get; set; }
    public string PriceUnit { get; set; } = null!;
    public string Location { get; set; } = null!;
    public bool IsAvailable { get; set; }
    public int SellerId { get; set; }
    public int CategoryId { get; set; }
}
