using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence;

internal interface IRoleRepository : IAsyncRepository<JobApplication>
{

}
