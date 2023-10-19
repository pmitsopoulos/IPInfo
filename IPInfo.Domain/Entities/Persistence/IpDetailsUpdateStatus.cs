using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPInfo.Domain.Entities.Persistence
{
    public class IpDetailsUpdateStatus
    {
        public string Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid BatchId { get; set; }
        public string Ip { get; set; }
    }
}
