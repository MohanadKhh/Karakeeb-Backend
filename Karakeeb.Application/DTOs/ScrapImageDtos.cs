namespace Karakeeb.Application;

public class ScrapImageDto
{
    public int Id { get; set; }
    public string ImageUrl { get; set; } = null!;
    public bool IsPrimary { get; set; }
    public DateTime UploadedAt { get; set; }
    public int ScrapItemId { get; set; }
}

public class CreateScrapImageDto
{
    public string ImageUrl { get; set; } = null!;
    public bool IsPrimary { get; set; }
    public DateTime UploadedAt { get; set; }
    public int ScrapItemId { get; set; }
}

public class UpdateScrapImageDto
{
    public int Id { get; set; }
    public string ImageUrl { get; set; } = null!;
    public bool IsPrimary { get; set; }
    public DateTime UploadedAt { get; set; }
    public int ScrapItemId { get; set; }
}
