using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketingAPI.Core.Entities;
using MarketingAPI.Core.Interfaces;

namespace MarketingAPI.Core.Services
{
    public class MailingService : IMailingService
    {
        private readonly IDataService _dataService;

        public MailingService(IDataService dataService)
        {
            _dataService = dataService;
        }

        private string GetGreeting(string language, string contactPerson)
        {
            return language.ToUpper() switch
            {
                "EN" => $"Hello {contactPerson}",
                "AR" => $"مرحبا {contactPerson}",
                _ => $"Hola {contactPerson}"
            };
        }

        public async Task<List<EmailResult>> GenerateCampaignAsync(string language)
        {
            var leads = await _dataService.GetLeadsAsync();
            var sectors = await _dataService.GetSectorsAsync();

            var filtered = leads
                .Where(l => l.IsActive && l.Budget > 10000)
                .ToList();

            var results = new List<EmailResult>();

            foreach (var lead in filtered)
            {
                var sector = sectors.First(s => s.SectorId == lead.SectorId);
                var greeting = GetGreeting(language, lead.ContactPerson);

                var html = $@"
                    <html>
                        <body>
                            <h2>{greeting}</h2>
                            <p><b>Empresa:</b> {lead.CompanyName}</p>
                            <p>Sector: {sector.Names[language]}</p>
                            <p>{sector.Offers[language]}</p>
                        </body>
                    </html>";

                results.Add(new EmailResult(
                    lead.Email,
                    lead.CompanyName,
                    $"Oferta para {lead.CompanyName}",
                    html
                ));
            }

            return results;
        }
    }
}
