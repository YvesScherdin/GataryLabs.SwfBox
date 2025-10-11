using GataryLabs.SwfBox.ViewModels.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Controls;

namespace GataryLabs.SwfBox.Views.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddViews(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddViewWithItsOwnScope<MainWindow, IMainWindowViewModel>();

            return serviceCollection;
        }

        private static IServiceCollection AddViewWithItsOwnScope<TView, TViewModel>(this IServiceCollection serviceCollection)
            where TView : Control, new()
            where TViewModel : IViewModel
        {
            serviceCollection.AddTransient(
                serviceProvider => CreateViewWithScope<TView, TViewModel>(serviceProvider));

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
