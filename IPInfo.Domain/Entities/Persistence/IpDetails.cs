using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPInfo.Domain.Entities.Persistence
{
    public class IpDetails : IRepositoryEntity
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Continent { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Ip { get; set; }

    }
}
