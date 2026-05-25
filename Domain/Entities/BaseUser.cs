using System;
using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities;

public abstract class BaseUser : AuditableEntity
{
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public bool IsVerified { get; set; }
    public bool IsActive { get; set; }

    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}