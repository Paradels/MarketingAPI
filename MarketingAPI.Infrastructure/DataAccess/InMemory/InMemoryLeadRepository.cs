using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketingAPI.Core.Entities;
using MarketingAPI.Core.Interfaces;

namespace MarketingAPI.Infrastructure.DataAccess.InMemory
{
    public class InMemoryLeadRepository : ILeadRepository
    {
        private readonly List<Lead> _leads = new();

        public Task<List<Lead>> GetAllAsync()
        {
            return Task.FromResult(_leads);
        }

        public Task<Lead?> GetByIdAsync(int id)
        {
            return Task.FromResult(_leads.FirstOrDefault(x => x.Id == id));
        }

        public Task AddAsync(Lead lead)
        {
            lead.Id = _leads.Count + 1;
            _leads.Add(lead);
            return Task.CompletedTask;
        }
    }
}
