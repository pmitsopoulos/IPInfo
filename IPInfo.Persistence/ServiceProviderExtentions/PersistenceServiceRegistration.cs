using IPInfo.Application.Contracts;
using IPInfo.Application.Contracts.Persistence;
using IPInfo.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPInfo.Persistence.ServiceProviderExtentions
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("IpInfoDetailsDb"));
            });

            //services.AddTransient<IMemoryCache, MyMemoryCacheClass>();
            services.AddMemoryCache();
            services.AddTransient<IIpDetailsRepository, IpDetailsRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
