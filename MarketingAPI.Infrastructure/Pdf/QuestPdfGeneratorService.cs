using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MarketingAPI.Core.Interfaces;
using MarketingAPI.Core.Entities;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace MarketingAPI.Infrastructure.Pdf
{
    public class QuestPdfGeneratorService : IPdfGeneratorService
    {
        private readonly IDataService _dataService;

        public QuestPdfGeneratorService(IDataService dataService)
        {
            QuestPDF.Settings.License = LicenseType.Community;
            _dataService = dataService;
        }

        public async Task<byte[]> GenerateDossierAsync(int leadId, string language)
        {
            var lead = await _dataService.GetLeadByIdAsync(leadId)
                ?? throw new Exception("Lead not found");

            var sectors = await _dataService.GetSectorsAsync();
            var sector = sectors.First(s => s.SectorId == lead.SectorId);

            var pdf = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30);

                    // Portada
                    page.Header().Column(col => 
                    {
                        col.Item().Text(lead.CompanyName).FontSize(36).Bold().FontColor(Colors.Blue.Darken2);
                        col.Item().Text($"Fecha: {DateTime.Now:dd/MM/yyyy}").FontSize(14).FontColor(Colors.Grey.Medium);
                        col.Item().PaddingBottom(20);
                    });

                    page.Content().Column(col =>
                    {
                        col.Item().Text("Detalles del Sector").FontSize(18).Bold().Underline();
                        col.Item().PaddingTop(5).Text(sector.Names[language]).FontSize(16).SemiBold();
                        col.Item().PaddingTop(5).Text(sector.Offers[language]).FontSize(12);

                        col.Item().PaddingTop(30).Text("Resumen de Contacto").FontSize(18).Bold().Underline();

                        col.Item().PaddingTop(10).Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text("Contacto").SemiBold();
                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(lead.ContactPerson);

                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text("Email").SemiBold();
                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(lead.Email);

                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text("Presupuesto Estimado").SemiBold();
                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text($"{lead.Budget}€");
                        });
                    });
                });
            });

            return pdf.GeneratePdf();
        }
    }
}
