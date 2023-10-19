using IPInfo.Domain.Entities.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPInfo.Application.Contracts.Persistence
{
    public interface IIpDetailsRepository : IRepository<IpDetails>
    {
    }
}
