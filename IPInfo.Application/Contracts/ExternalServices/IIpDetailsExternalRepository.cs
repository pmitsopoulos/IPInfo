using IPInfo.Application.DTOs.ExternalServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPInfo.Application.Contracts.ExternalServices
{
    public interface IIpDetailsExternalRepository : IExternalRepository<GetIpDetailsDto>
    {
    }
}
