using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketingAPI.Core.Entities
{
    public class Lead
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public int SectorId { get; set; }
        public decimal Budget { get; set; }
        public bool IsActive { get; set; }
    }
}
