using GataryLabs.SwfBox.Domain.Abstractions;
using GataryLabs.SwfBox.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace GataryLabs.SwfBox.Domain.Extensions
{
    public static class SwfFileLibraryServiceExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            ArgumentValidator.ThrowIfNull(services, nameof(services));

            services.AddScoped<ISwfFileLibraryService, SwfFileLibraryService>();

            return services;
        }
    }
}
