using Karakeeb.Domain;

namespace Karakeeb.Application;

public static class ScrapItemMapper
{
    public static ScrapItemDto ToScrapItemDto(this ScrapItem scrapItem)
    {
        return new ScrapItemDto
        {
            Id = scrapItem.Id,
            Title = scrapItem.Title,
            Description = scrapItem.Description,
            Quantity = scrapItem.Quantity,
            Unit = scrapItem.Unit,
            Price = scrapItem.Price,
            PriceUnit = scrapItem.PriceUnit,
            Location = scrapItem.Location,
            IsAvailable = scrapItem.IsAvailable,
            CreatedAt = scrapItem.CreatedAt,
            UpdatedAt = scrapItem.UpdatedAt,
            SellerId = scrapItem.SellerId,
            CategoryId = scrapItem.CategoryId
        };
    }
}
