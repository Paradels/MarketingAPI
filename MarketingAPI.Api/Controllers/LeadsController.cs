using Microsoft.AspNetCore.Mvc;
using MarketingAPI.Core.Services;
using MarketingAPI.Core.Entities;

namespace MarketingAPI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeadsController : ControllerBase
    {
        private readonly LeadService _leadService;

        public LeadsController(LeadService leadService)
        {
            _leadService = leadService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLead([FromBody] Lead lead)
        {
            await _leadService.AddLeadAsync(lead);
            return Ok(lead);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var leads = await _leadService.GetAllAsync();
            return Ok(leads);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var lead = await _leadService.GetByIdAsync(id);
            if (lead == null)
                return NotFound();

            return Ok(lead);
        }
    }
}

