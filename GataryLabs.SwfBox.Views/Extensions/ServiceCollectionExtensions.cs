using GataryLabs.SwfBox.ViewModels.Abstractions;
using GataryLabs.SwfBox.Views.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Controls;

namespace GataryLabs.SwfBox.Views.Extensions
{
    public static class ServiceCollectionExtensions
    {
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
