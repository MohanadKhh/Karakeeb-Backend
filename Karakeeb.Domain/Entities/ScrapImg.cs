namespace Karakeeb.Domain;
public class ScrapImage
{
    public int Id { get; set; }
    public string ImageUrl { get; set; } = null!;
    public bool IsPrimary { get; set; }
    public DateTime UploadedAt { get; set; }

    // FK
    public int ScrapItemId { get; set; }

    // Navigation
    public ScrapItem ScrapItem { get; set; } = null!;
}
