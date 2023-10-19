using IPinfo.ExternalServices.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPinfo.ExternalServices.ServiceProviderExtentions
{
    public static class ExternalServicesServiceRegistration
    {
        public static IServiceCollection ConfigureExternalServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.Configure<IpInfoApiSettings>(configuration.GetSection("IpInfoApiSettings"));
            var IpInfoSettings = configuration?.GetSection(nameof(IpInfoApiSettings)).Get<IpInfoApiSettings>();
            services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(IpInfoSettings.BaseAddress) });
            return services;
        }
    }
}
