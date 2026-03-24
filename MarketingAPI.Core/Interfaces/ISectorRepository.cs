using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketingAPI.Core.Entities;

namespace MarketingAPI.Core.Interfaces
{
    public interface ISectorRepository
    {
        Task<List<Sector>> GetAllAsync();
        Task<Sector?> GetByIdAsync(int id);
        Task AddAsync(Sector sector);
    }
}
