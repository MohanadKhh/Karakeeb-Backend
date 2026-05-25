using Karakeeb.Domain;

namespace Karakeeb.Application;

public class DealDto
{
    public int Id { get; set; }
    public decimal FinalPrice { get; set; }
    public DealStatus Status { get; set; }
    public string? SellerPhone { get; set; }
    public string? SellerEmail { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int OfferId { get; set; }
    public int ScrapItemId { get; set; }
    public int SellerId { get; set; }
    public int BuyerId { get; set; }
}

public class CreateDealDto
{
    public decimal FinalPrice { get; set; }
    public DealStatus Status { get; set; }
    public string? SellerPhone { get; set; }
    public string? SellerEmail { get; set; }
    public int OfferId { get; set; }
    public int ScrapItemId { get; set; }
    public int SellerId { get; set; }
    public int BuyerId { get; set; }
}

public class UpdateDealDto
{
    public int Id { get; set; }
    public decimal FinalPrice { get; set; }
    public DealStatus Status { get; set; }
    public string? SellerPhone { get; set; }
    public string? SellerEmail { get; set; }
    public int OfferId { get; set; }
    public int ScrapItemId { get; set; }
    public int SellerId { get; set; }
    public int BuyerId { get; set; }
}
