using System.Collections.Generic;

namespace Domain.Entities;

public class Seller : BaseUser
{
    public ICollection<ScrapListing> ScrapListings { get; set; } = new List<ScrapListing>();
    public ICollection<Deal> Deals { get; set; } = new List<Deal>();
}