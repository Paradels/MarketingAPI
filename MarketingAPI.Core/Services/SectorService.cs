using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketingAPI.Core.Entities;
using MarketingAPI.Core.Interfaces;

namespace MarketingAPI.Core.Services
{
    public class SectorService
    {
        private readonly ISectorRepository _repository;

        public SectorService(ISectorRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Sector>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Sector?> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task AddSectorAsync(Sector sector)
        {
            return _repository.AddAsync(sector);
        }
    }
}
