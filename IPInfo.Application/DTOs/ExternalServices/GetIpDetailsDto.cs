using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPInfo.Application.DTOs.ExternalServices
{
    public class GetIpDetailsDto
    {
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("country_name")]
        public string Country { get; set; }
        [JsonProperty("continent_name")]
        public string Continent { get; set; }
        [JsonProperty("latitude")]
        public double Latitude { get; set; }
        [JsonProperty("longitude")]
        public double Longitude { get; set; }
        
        [JsonProperty("ip")]
        public string Ip { get; set; }
    }
}
