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
        private readonly IDataService _dataService;

        public SectorService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public Task<List<Sector>> GetAllAsync()
        {
            return _dataService.GetSectorsAsync();
        }

        public async Task<Sector?> GetByIdAsync(int id)
        {
            var sectors = await _dataService.GetSectorsAsync();
            return sectors.FirstOrDefault(s => s.SectorId == id);
        }

        public Task AddSectorAsync(Sector sector)
        {
            // Opcional o no soportado en excel:
            return Task.CompletedTask;
        }
    }
}
