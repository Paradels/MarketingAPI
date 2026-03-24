using Microsoft.AspNetCore.Mvc;
using MarketingAPI.Core.Services;
using MarketingAPI.Core.Entities;

namespace MarketingAPI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SectorsController : ControllerBase
    {
        private readonly SectorService _sectorService;

        public SectorsController(SectorService sectorService)
        {
            _sectorService = sectorService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSector([FromBody] Sector sector)
        {
            await _sectorService.AddSectorAsync(sector);
            return Ok(sector);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sectors = await _sectorService.GetAllAsync();
            return Ok(sectors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sector = await _sectorService.GetByIdAsync(id);
            if (sector == null)
                return NotFound();

            return Ok(sector);
        }
    }
}
