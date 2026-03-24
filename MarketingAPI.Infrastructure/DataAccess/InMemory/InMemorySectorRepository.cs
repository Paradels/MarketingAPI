using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketingAPI.Core.Entities;
using MarketingAPI.Core.Interfaces;

namespace MarketingAPI.Infrastructure.DataAccess.InMemory
{
    public class InMemorySectorRepository : ISectorRepository
    {
        private readonly List<Sector> _sectors = new();

        public Task<List<Sector>> GetAllAsync()
        {
            return Task.FromResult(_sectors);
        }

        public Task<Sector?> GetByIdAsync(int id)
        {
            return Task.FromResult(_sectors.FirstOrDefault(x => x.SectorId == id));
        }

        public Task AddAsync(Sector sector)
        {
            _sectors.Add(sector);
            return Task.CompletedTask;
        }
    }
}

