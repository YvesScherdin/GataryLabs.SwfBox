using GataryLabs.Mvvm.Services;
using GataryLabs.Mvvm.Services.Abstractions;
using GataryLabs.Mvvm.ViewModels.Abstractions;
using GataryLabs.SwfBox.ViewModels.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Notification.Wpf;
using System;
using System.Windows.Controls;

namespace GataryLabs.SwfBox.Views.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddLocalization(this IServiceCollection services)
        {
            services.AddSingleton<ILocalizationSource, LocalizationSource>();
            services.AddSingleton<INotificationManager, NotificationManager>();
            services.AddSingleton<INotificationService, NotificationService>();

            return services;
        }

        public static IServiceCollection AddViews(this IServiceCollection services)
        {
            services.AddUIElements();
            services.AddMvvmUtilityServices();

            return services;
        }

        private static IServiceCollection AddUIElements(this IServiceCollection services)
        {
            services.AddViewWithItsOwnScope<MainWindow, IMainWindowViewModel>();

            return services;
        }
        
        private static IServiceCollection AddMvvmUtilityServices(this IServiceCollection services)
        {
            services.AddSingleton<IDialogService, DialogService>();

            return services;
        }

        private static IServiceCollection AddViewWithItsOwnScope<TView, TViewModel>(this IServiceCollection serviceCollection)
            where TView : Control, new()
            where TViewModel : IViewModel
        {
            serviceCollection.AddTransient(CreateViewWithScope<TView, TViewModel>);

            return serviceCollection;
        }

        private static TView CreateViewWithScope<TView, TViewModel>(IServiceProvider serviceProvider)
            where TView : Control, new()
            where TViewModel : IViewModel
        {
            TView view = new TView();
            IServiceScope viewScope = serviceProvider.CreateScope();
            IViewModel viewModel = viewScope.ServiceProvider.GetRequiredService<TViewModel>();

            view.DataContext = viewModel;

            return view;
        }
    }
}
