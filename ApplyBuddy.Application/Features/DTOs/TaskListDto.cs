using ApplyBuddy.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyBuddy.Application.Features.DTOs;
public class TaskListDto
{
    public Guid Id { get; init; }
    public string ShortDescription { get; init; } = string.Empty;
    public TaskState State { get; init; }

}
