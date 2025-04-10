using ApplyBuddy.Domain.Aggregates.JobApplication;
using ApplyBuddy.Domain.Aggregates.Position;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyBuddy.Persistence.Utilities;
public static class PersistenceUtilities
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Position>().HasData(new Position
        {
            Id = Guid.Parse("{7b439417-169b-4382-b8cd-1755d2b55183}"),
            Name = "Associate Software Engineer",
            Description = "Essential and Desirable Criteria:\r\n\r\n\r\n\r\nExperience in C# .Net or JavaScript\r\nAdaptability\r\nBe team oriented\r\nHave good time management skills\r\nHigh attention to detail\r\nHave an interest in the latest technology\r\nBe highly organised\r\nProactive\r\nCollaborative, problem solving attitude and a commitment to producing a high quality product",
            ListedDate = new DateTime(2025, 3, 27),
            Company = "Resolver",
            EmploymentType = EmploymentType.Permanent,
            Level = PositionLevel.Associate,
            Salary = new(
                SalaryType.PerAnnum,
                40_000m,
                Currency.GBP
                )
        });


        modelBuilder.Entity<JobApplication>().HasData(new JobApplication
        {
            Id = Guid.Parse("{aef4aa75-5e42-44f0-abc2-b72a7c384c5c}"),
            Name = "Resolver associate developer",
            Description = "Entry level, required C# and JavaScript",
            Position = Guid.Parse("{7b439417-169b-4382-b8cd-1755d2b55183}")
        });
    }
}
