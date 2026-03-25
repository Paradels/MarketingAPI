using System.Collections.Generic;
using System.Threading.Tasks;
using MarketingAPI.Core.Entities;

namespace MarketingAPI.Core.Interfaces
{
    public interface IDataService
    {
        Task<List<Lead>> GetLeadsAsync();
        Task<List<Sector>> GetSectorsAsync();
        Task<Lead?> GetLeadByIdAsync(int id);
    }
}