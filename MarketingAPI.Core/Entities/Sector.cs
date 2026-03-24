using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketingAPI.Core.Entities
{
    public class Sector
    {
        public int SectorId { get; set; }
        public Dictionary<string, string> Names { get; set; }
        public Dictionary<string, string> Offers { get; set; }
    }
}
