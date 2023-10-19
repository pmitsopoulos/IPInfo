using IPInfo.Application.Contracts;
using IPInfo.Domain.Entities.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IPInfo.Application.Features.Commands
{
    public class BatchUpdateIpDetails : IRequest<Guid>
    {
        public IEnumerable<IpDetails> IpDetails { get; set; }
    }
    public class BatchUpdateIpDetailsHandler : IRequestHandler<BatchUpdateIpDetails, Guid>
    {
        public async Task<Guid> Handle(BatchUpdateIpDetails request, CancellationToken cancellationToken)
        {
            return Guid.NewGuid();      
        }
    }
}
