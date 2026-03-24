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
        private readonly ILeadRepository _repository;

        public LeadService(ILeadRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Lead>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Lead?> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task AddLeadAsync(Lead lead)
        {
            return _repository.AddAsync(lead);
        }
    }
}
