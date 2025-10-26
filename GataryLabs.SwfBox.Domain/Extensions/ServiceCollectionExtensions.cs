using GataryLabs.SwfBox.Configuration.Abstractions;
using GataryLabs.SwfBox.Domain.Abstractions;
using GataryLabs.SwfBox.Domain.Abstractions.Models;
using GataryLabs.SwfBox.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GataryLabs.SwfBox.Domain.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            ArgumentValidator.ThrowIfNull(services, nameof(services));

            services.AddSingleton<ISessionContext, SessionContext>();

            services.AddScoped<ISwfFileLibraryService, SwfFileLibraryService>(CreateSwfFileLibraryServiceForDebugging);

            return services;
        }

        private static SwfFileLibraryService CreateSwfFileLibraryServiceForDebugging(IServiceProvider provider)
        {
            SwfFileLibraryService swfFileLibraryService = new SwfFileLibraryService();

            swfFileLibraryService.RegisterFile(new SwfFileDetailsInfo
            {
                Id = Guid.NewGuid(),
                FileName = "SomeFile.swf",
                Path = "path/to/SomeFile.swf"
            });
            swfFileLibraryService.RegisterFile(new SwfFileDetailsInfo
            {
                Id = Guid.NewGuid(),
                FileName = "SomeFile.swf",
                Path = "path/to/SomeFile.swf"
            });
            swfFileLibraryService.RegisterFile(new SwfFileDetailsInfo
            {
                Id = Guid.NewGuid(),
                FileName = "SomeFile.swf",
                Path = "path/to/SomeFile.swf"
            });

            return swfFileLibraryService;
        }
    }
}
