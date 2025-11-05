using GataryLabs.Mvvm.ViewModels.Utils;
using GataryLabs.SwfBox.ViewModels.Abstractions;
using GataryLabs.SwfBox.ViewModels.Abstractions.Commands;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using GataryLabs.SwfBox.ViewModels.Commands;
using GataryLabs.SwfBox.ViewModels.DataModel;
using GataryLabs.SwfBox.ViewModels.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace GataryLabs.SwfBox.ViewModels.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMvvm(this IServiceCollection services)
        {
            services.AddTransient(typeof(LazyInstance<>));
            
            services.AddDataModels();
            services.AddCommands();
            services.AddViewModels();

            ViewModelMappingProfile.Register();

            return services;
        }

        private static IServiceCollection AddDataModels(this IServiceCollection services)
        {
            services.AddSingleton<IRecentSwfFileLibraryDataModel, RecentSwfFileLibraryDataModel>();
            services.AddSingleton<IMainWindowContextDataModel, MainWindowContextDataModel>();

            return services;
        }
        
        private static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddTransient<ISelectSwfFileCommand, SelectSwfFileCommand>();
            services.AddTransient<IPickNewSwfFileCommand, PickNewSwfFileCommand>();
            services.AddTransient<IScanDirectoryForSwfsCommand, ScanDirectoryForSwfsCommand>();
            services.AddTransient<IAnalyzeSwfFileCommand, AnalyzeSwfFileCommand>();
            services.AddTransient<IPlaySwfFileCommand, PlaySwfFileCommand>();
            services.AddTransient<IExploreCommand, ExploreCommand>();
            services.AddTransient<ISaveMetaDataCommand, SaveMetaDataCommand>();

            return services;
        }
        
        private static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            services.AddScoped<IMainWindowViewModel, MainWindowViewModel>();
            services.AddScoped<IMainWindowContentNavigator, MainWindowContentNavigator>();
            services.AddScoped<IMainWindowSwfDetailsContentViewModel, MainWindowSwfDetailsContentViewModel>();
            services.AddScoped<IMainWindowOverviewContentViewModel, MainWindowOverviewContentViewModel>();
            services.AddScoped<IMainWindowErrorContentViewModel, MainWindowErrorContentViewModel>();
            services.AddScoped<IMainWindowMenuBarViewModel, MainWindowMenuBarViewModel>();

            return services;
        }
    }
}
