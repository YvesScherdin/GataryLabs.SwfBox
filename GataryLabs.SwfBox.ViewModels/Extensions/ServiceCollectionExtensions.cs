using GataryLabs.SwfBox.ViewModels.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace GataryLabs.SwfBox.ViewModels.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            services.AddScoped<IMainWindowViewModel, MainWindowViewModel>();
            services.AddScoped<IMainWindowSwfDetailsContentViewModel, MainWindowSwfDetailsContentViewModel>();
            services.AddScoped<IMainWindowErrorContentViewModel, MainWindowErrorContentViewModel>();

            return services;
        }
    }
}
