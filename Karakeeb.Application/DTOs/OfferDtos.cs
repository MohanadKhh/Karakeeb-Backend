using Karakeeb.Domain;

namespace Karakeeb.Application;

public class OfferDto
{
    public int Id { get; set; }
    public decimal OfferedPrice { get; set; }
    public string? Note { get; set; }
    public OfferStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int ScrapItemId { get; set; }
    public int BuyerId { get; set; }
}

public class CreateOfferDto
{
    public decimal OfferedPrice { get; set; }
    public string? Note { get; set; }
    public OfferStatus Status { get; set; }
    public int ScrapItemId { get; set; }
    public int BuyerId { get; set; }
}

public class UpdateOfferDto
{
    public int Id { get; set; }
    public decimal OfferedPrice { get; set; }
    public string? Note { get; set; }
    public OfferStatus Status { get; set; }
    public int ScrapItemId { get; set; }
    public int BuyerId { get; set; }
}
