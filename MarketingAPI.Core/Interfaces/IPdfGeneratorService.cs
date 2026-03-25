using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketingAPI.Core.Interfaces
{
    public interface IPdfGeneratorService
    {
        Task<byte[]> GenerateDossierAsync(int leadId, string language);
    }
}
