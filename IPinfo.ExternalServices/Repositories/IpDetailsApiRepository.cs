using IPinfo.ExternalServices.Entities;
using IPInfo.Application.Contracts.ExternalServices;
using IPInfo.Application.DTOs.ExternalServices;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace IPinfo.ExternalServices.Repositories
{
    public class IpDetailsApiRepository : IIpDetailsExternalRepository
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<IpInfoApiSettings> _ipInfoSettings;

        public IpDetailsApiRepository(HttpClient httpClient, IOptions<IpInfoApiSettings> ipInfoSettings)
        {
            _ipInfoSettings = ipInfoSettings;
            _httpClient = httpClient;
        }

        public async Task<GetIpDetailsDto> GetDetailsAsync(string ip)
        {
            var apikey = _ipInfoSettings.Value.ApiKey;
            var response = await _httpClient.GetAsync($"{_httpClient.BaseAddress}/{ip}?access_key={apikey}");
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GetIpDetailsDto>(responseContent);

            return result;
        }
    }
}
