using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketingAPI.Core.Entities;

namespace MarketingAPI.Core.Interfaces
{
    public interface IMailingService
    {
        Task<List<EmailResult>> GenerateCampaignAsync(string language);
    }

    public record EmailResult(
        string To,
        string CompanyName,
        string Subject,
        string HtmlBody
    );
}
