using GataryLabs.SwfBox.ViewModels.Abstractions;
using GataryLabs.SwfBox.ViewModels.DataModel;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GataryLabs.SwfBox.ViewModels.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            services.AddScoped<IMainWindowViewModel, MainWindowViewModel>();
            services.AddScoped<IMainWindowSwfDetailsContentViewModel, MainWindowSwfDetailsContentViewModel>(CreateSwfDetailsViewModel);
            services.AddScoped<IMainWindowErrorContentViewModel, MainWindowErrorContentViewModel>();
            services.AddScoped<IMainWindowMenuBarViewModel, MainWindowMenuBarViewModel>();

            return services;
        }

        private static MainWindowSwfDetailsContentViewModel CreateSwfDetailsViewModel(IServiceProvider provider)
        {
            return new MainWindowSwfDetailsContentViewModel
            {
                Details = new SwfFileDetailsDataModel
                {
                    Path = "path/to/somewhere",
                    FileName = "file.swf"
                }
            };
        }
    }
}
