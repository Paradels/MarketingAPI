using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MarketingAPI.Core.Interfaces;
using MarketingAPI.Core.Services;
using MarketingAPI.Infrastructure.DataAccess.Exel;

namespace MarketingAPI.Infrastructure.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // Rutas de Excel
            var leadsPath = configuration["DataSources:LeadsPath"];
            var sectorsPath = configuration["DataSources:SectorsPath"];

            // Servicio de Excel
            services.AddSingleton<IDataService>(sp =>
                new ExcelDataService(leadsPath, sectorsPath));

            // Servicios que SÍ existen en tu proyecto
            services.AddScoped<LeadService>();
            services.AddScoped<SectorService>();

            // Servicio de PDF
            services.AddScoped<IPdfGeneratorService, MarketingAPI.Infrastructure.Pdf.QuestPdfGeneratorService>();

            // Servicio de Mailing
            services.AddScoped<IMailingService, MailingService>();

            return services;
        }
    }
}
