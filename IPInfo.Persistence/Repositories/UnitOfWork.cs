using IPinfo.ExternalServices.Entities;
using IPinfo.ExternalServices.Repositories;
using IPInfo.Application.Contracts;
using IPInfo.Application.Contracts.ExternalServices;
using IPInfo.Application.Contracts.Persistence;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IPInfo.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private  IIpDetailsExternalRepository _ipDetailsExternalRep ;

        private  IIpDetailsRepository _ipDetailsLocalRepo;

        //private  CacheService _cache;

        private readonly AppDbContext _context;
        private readonly HttpClient _httpClient;
        private readonly IOptions<IpInfoApiSettings> _ipApiSettings;
        //private readonly IMemoryCache _memoryCache;
        //private readonly IOptions<MemoryCacheOptions> _memoryCacheOptions;

        
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
        public UnitOfWork(AppDbContext context, HttpClient httpClient,IOptions<IpInfoApiSettings> ipApiSettings)
        {
            _context = context;
            _httpClient = httpClient;
            _ipApiSettings = ipApiSettings;
           // _memoryCache = memoryCache;
           // _memoryCacheOptions = memoryCacheOptions;
        }

        public IIpDetailsExternalRepository ipDetailsExternalRepository => _ipDetailsExternalRep ??= new IpDetailsApiRepository(_httpClient, _ipApiSettings);

        public IIpDetailsRepository ipDetailsLocalRepository => _ipDetailsLocalRepo ??= new IpDetailsRepository(_context);


    }
}
