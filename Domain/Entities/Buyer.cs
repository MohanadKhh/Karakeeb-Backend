using System.Collections.Generic;

namespace Domain.Entities;

public class Buyer : BaseUser
{
    public ICollection<Offer> Offers { get; set; } = new List<Offer>();
    public ICollection<Deal> Deals { get; set; } = new List<Deal>();
}