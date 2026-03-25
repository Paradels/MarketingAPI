using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketingAPI.Core.Entities;
using MarketingAPI.Core.Interfaces;

namespace MarketingAPI.Core.Services
{
    public class LeadService
    {
        private readonly IDataService _dataService;

        public LeadService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public Task<List<Lead>> GetAllAsync()
        {
            return _dataService.GetLeadsAsync();
        }

        public Task<Lead?> GetByIdAsync(int id)
        {
            return _dataService.GetLeadByIdAsync(id);
        }

        public Task AddAsync(Lead lead)
        {
            // Opcional o no soportado en excel:
            return Task.CompletedTask;
        }

        public Task AddLeadAsync(Lead lead)
        {
            // TODO: Falta implementar el guardado en el origen de datos.
            return Task.CompletedTask;
        }
    }
}
