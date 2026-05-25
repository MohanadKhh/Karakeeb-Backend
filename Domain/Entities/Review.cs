using System;
using Domain.Common;

namespace Domain.Entities;

public class Review : BaseEntity
{
    public Guid DealId { get; set; }
    public Deal Deal { get; set; } = null!;

    public Guid ReviewerUserId { get; set; }
    public BaseUser ReviewerUser { get; set; } = null!;

    public Guid RevieweeUserId { get; set; }
    public BaseUser RevieweeUser { get; set; } = null!;

    public int Rating { get; set; }
    public string? Comment { get; set; }
    public DateTime CreatedAt { get; set; }
}