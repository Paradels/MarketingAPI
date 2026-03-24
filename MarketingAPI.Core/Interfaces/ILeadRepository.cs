using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketingAPI.Core.Entities;

namespace MarketingAPI.Core.Interfaces
{
    public interface ILeadRepository
    {
        Task<List<Lead>> GetAllAsync();
        Task<Lead?> GetByIdAsync(int id);
        Task AddAsync(Lead lead);
    }
}
