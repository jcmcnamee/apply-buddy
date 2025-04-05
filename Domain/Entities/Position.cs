using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyBuddy.Domain.Entities;
public class Position : AuditableEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime ListedDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Company { get; set; } = string.Empty;
}
