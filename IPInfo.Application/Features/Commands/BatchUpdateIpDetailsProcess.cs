using IPInfo.Domain.Entities.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPInfo.Application.Features.Commands
{
    public class BatchUpdateIpDetailsProcess : IRequest<IEnumerable<IpDetails>>
    {
        public IEnumerable<IpDetails> IpDetailsTbU { get; set; }
    }
    public class BatchUpdateIpDetailsProcessHandler : IRequestHandler<BatchUpdateIpDetailsProcess, IEnumerable<IpDetails>>
    {
        public async Task<IEnumerable<IpDetails>> Handle(BatchUpdateIpDetailsProcess request, CancellationToken cancellationToken)
        {

            foreach (var ip in request.IpDetailsTbU)
            {
                //process
            }
            
            return Enumerable.Empty<IpDetails>();
        }
    }
}
