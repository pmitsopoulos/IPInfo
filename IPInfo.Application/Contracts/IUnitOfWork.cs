using IPInfo.Application.Contracts.ExternalServices;
using IPInfo.Application.Contracts.Persistence;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPInfo.Application.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IIpDetailsExternalRepository ipDetailsExternalRepository { get; }
        IIpDetailsRepository ipDetailsLocalRepository { get; }

        //IMemoryCache cache { get; }
        //Task Save();

    }
}
