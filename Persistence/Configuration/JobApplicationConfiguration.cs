﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration;
public class JobApplicationConfiguration : IEntityTypeConfiguration<JobApplicationConfiguration>
{
    public void Configure(EntityTypeBuilder<JobApplicationConfiguration> builder)
    {
        throw new NotImplementedException();
    }
}
