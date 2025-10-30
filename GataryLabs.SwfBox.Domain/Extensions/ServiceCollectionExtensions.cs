﻿using GataryLabs.SwfBox.Domain.Abstractions;
using GataryLabs.SwfBox.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace GataryLabs.SwfBox.Domain.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            ArgumentValidator.ThrowIfNull(services, nameof(services));

            services.AddSingleton<ISessionContext, SessionContext>();

            services.AddSingleton<ISwfFileLibraryService, SwfFileLibraryService>();

            return services;
        }
    }
}
