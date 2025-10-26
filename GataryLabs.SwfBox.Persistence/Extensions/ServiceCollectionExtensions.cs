using GataryLabs.SwfBox.Configuration.Abstractions;
using GataryLabs.SwfBox.Persistence.Abstractions;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GataryLabs.SwfBox.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services,
            string userDataDirectory,
            UserSettings defaultUserSettings)
        {
            services.AddSingleton<IUserDataService, UserDataService>(serviceProvider =>
                CreateUserDataService(serviceProvider, userDataDirectory, defaultUserSettings));

            return services;
        }

        private static UserDataService CreateUserDataService(IServiceProvider serviceProvider, string userDataDirectory, UserSettings defaultUserSettings)
        {
            IMapper mapper = serviceProvider.GetRequiredService<IMapper>();

            return new UserDataService(userDataDirectory, defaultUserSettings, mapper);
        }
    }
}
