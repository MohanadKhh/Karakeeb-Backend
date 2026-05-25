using Karakeeb.Domain;
using Microsoft.AspNetCore.Identity;

namespace Karakeeb.Infrastructure;

public class ApplicationUser : IdentityUser<int>
{
    public string FullName { get; set; } = null!;
    public string? ProfileImageUrl { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public bool IsVerified { get; set; }
    public decimal Rating { get; set; }
    public DateTime CreatedAt { get; set; }

    // Navigation
    public ICollection<ScrapItem> ScrapItems { get; set; } = new HashSet<ScrapItem>();
    public ICollection<Offer> Offers { get; set; } = new HashSet<Offer>();
}
