﻿using ApplyBuddy.Domain.Enums;

namespace ApplyBuddy.Domain.Common;

public class BaseTask : AuditableEntity
{
    public Guid Id { get; init; }
    public string ShortDescription { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TaskState State { get; private set; }
    public TaskPriority Priority { get; set; }
    public bool IsActive { get; private protected set; }

    public List<string> Activites { get; private set; } = new List<string>();

}
