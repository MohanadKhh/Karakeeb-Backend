namespace Karakeeb.Domain;

public class ScrapCategory
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? ImageUrl { get; set; }

    // Navigation
    public ICollection<ScrapItem> ScrapItems { get; set; } = new HashSet<ScrapItem>();
}
