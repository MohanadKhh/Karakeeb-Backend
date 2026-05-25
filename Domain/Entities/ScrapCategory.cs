using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities;

public class ScrapCategory : AuditableEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public bool IsActive { get; set; }

    public ICollection<ScrapListing> ScrapListings { get; set; } = new List<ScrapListing>();
}