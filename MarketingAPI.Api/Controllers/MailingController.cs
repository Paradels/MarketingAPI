using Microsoft.AspNetCore.Mvc;
using MarketingAPI.Core.Interfaces;

namespace MarketingAPI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MailingController : ControllerBase
    {
        private readonly IMailingService _mailingService;

        public MailingController(IMailingService mailingService)
        {
            _mailingService = mailingService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendCampaign([FromQuery] string language = "ES")
        {
            var results = await _mailingService.GenerateCampaignAsync(language);
            return Ok(results);
        }
    }
}
