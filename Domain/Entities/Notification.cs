using System;
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Notification : BaseEntity
{
    public Guid UserId { get; set; }
    public BaseUser User { get; set; } = null!;

    public string Title { get; set; } = null!;
    public string Message { get; set; } = null!;
    public NotificationType Type { get; set; }

    public Guid? ReferenceId { get; set; }
    public ReferenceType ReferenceType { get; set; }

    public bool IsRead { get; set; }
    public DateTime CreatedAt { get; set; }
}