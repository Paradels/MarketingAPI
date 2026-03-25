using Microsoft.AspNetCore.Mvc;
using MarketingAPI.Core.Interfaces;

namespace MarketingAPI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DossierController : ControllerBase
    {
        private readonly IPdfGeneratorService _pdfService;

        public DossierController(IPdfGeneratorService pdfService)
        {
            _pdfService = pdfService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GenerateDossier(int id, [FromQuery] string language = "ES")
        {
            try
            {
                var pdfBytes = await _pdfService.GenerateDossierAsync(id, language);
                return File(pdfBytes, "application/pdf", $"dossier_{id}.pdf");
            }
            catch (Exception ex) when (ex.Message == "Lead not found")
            {
                return NotFound(new { message = "El cliente especificado no existe." });
            }
        }
    }
}
