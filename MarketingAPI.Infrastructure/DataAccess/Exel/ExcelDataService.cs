using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using MarketingAPI.Core.Entities;
using MarketingAPI.Core.Interfaces;

namespace MarketingAPI.Infrastructure.DataAccess.Exel
{
    public class ExcelDataService : IDataService
    {
        private readonly string _leadsPath;
        private readonly string _sectorsPath;

        public ExcelDataService(string leadsPath, string sectorsPath)
        {
            OfficeOpenXml.ExcelPackage.License.SetNonCommercialOrganization("MarketingAPI");
            _leadsPath = leadsPath;
            _sectorsPath = sectorsPath;

            // Fallback for relative paths depending on Execution Context
            if (!File.Exists(_leadsPath))
            {
               var alternativePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, leadsPath);
               if (File.Exists(alternativePath)) _leadsPath = alternativePath;
            }

            if (!File.Exists(_sectorsPath))
            {
               var alternativePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, sectorsPath);
               if (File.Exists(alternativePath)) _sectorsPath = alternativePath;
            }
        }

        public async Task<List<Lead>> GetLeadsAsync()
        {
            if (!File.Exists(_leadsPath))
                return new List<Lead>();

            using var package = new ExcelPackage(new FileInfo(_leadsPath));
            var worksheet = package.Workbook.Worksheets[0];

            var leads = new List<Lead>();

            for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                try
                {
                    var idStr = CleanValue(worksheet.Cells[row, 1].Text);
                    if (string.IsNullOrEmpty(idStr)) continue;

                    var lead = new Lead
                    {
                        Id = int.TryParse(idStr, out var id) ? id : 0,
                        CompanyName = CleanValue(worksheet.Cells[row, 2].Text),
                        ContactPerson = CleanValue(worksheet.Cells[row, 3].Text),
                        Email = CleanEmail(worksheet.Cells[row, 4].Text),
                        SectorId = int.TryParse(CleanValue(worksheet.Cells[row, 5].Text), out var sId) ? sId : 0,
                        Budget = decimal.TryParse(CleanValue(worksheet.Cells[row, 6].Text).Replace("$","").Replace("€",""), out var b) ? b : 0,
                        IsActive = ParseBool(worksheet.Cells[row, 7].Text)
                    };

                    leads.Add(lead);
                }
                catch
                {
                    // Log y continuar
                }
            }

            return leads;
        }

        public async Task<List<Sector>> GetSectorsAsync()
        {
            if (!File.Exists(_sectorsPath))
                return new List<Sector>();

            using var package = new ExcelPackage(new FileInfo(_sectorsPath));
            var worksheet = package.Workbook.Worksheets[0];

            var sectors = new List<Sector>();

            for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                try
                {
                    var sector = new Sector
                    {
                        SectorId = int.Parse(CleanValue(worksheet.Cells[row, 1].Text)),
                        Names = new Dictionary<string, string>
                        {
                            { "ES", CleanValue(worksheet.Cells[row, 2].Text) },
                            { "EN", CleanValue(worksheet.Cells[row, 3].Text) },
                            { "AR", CleanValue(worksheet.Cells[row, 4].Text) }
                        },
                        Offers = new Dictionary<string, string>
                        {
                            { "ES", CleanValue(worksheet.Cells[row, 5].Text) },
                            { "EN", CleanValue(worksheet.Cells[row, 6].Text) },
                            { "AR", CleanValue(worksheet.Cells[row, 7].Text) }
                        }
                    };

                    sectors.Add(sector);
                }
                catch
                {
                    // Log y continuar
                }
            }

            return sectors;
        }

        public async Task<Lead?> GetLeadByIdAsync(int id)
        {
            var leads = await GetLeadsAsync();
            return leads.FirstOrDefault(l => l.Id == id);
        }

        private string CleanValue(string value)
            => value?.Trim() ?? "";

        private bool ParseBool(string value)
            => value.Trim().ToLower() is "true" or "1" or "yes" or "sí" or "active";

        private string CleanEmail(string email)
            => email?.Trim().ToLower() ?? "";
    }
}
