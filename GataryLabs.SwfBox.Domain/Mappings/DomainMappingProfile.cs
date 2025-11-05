using GataryLabs.SwfBox.Domain.Abstractions.Models;
using GataryLabs.SwfBox.Persistence.Abstractions.Models;
using Mapster;

namespace GataryLabs.SwfBox.Domain.Mappings
{
    internal static class DomainMappingProfile
    {
        internal static void Register()
        {
            TypeAdapterConfig<SwfAnalysisData, SwfAnalysisInfo>.NewConfig()
                .Map(d => d.Info, s => s)
                .TwoWays();
        }
    }
}
