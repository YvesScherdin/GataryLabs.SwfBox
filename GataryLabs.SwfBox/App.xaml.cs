using GataryLabs.SwfBox.Domain.Extensions;
using GataryLabs.SwfBox.ViewModels.Extensions;
using GataryLabs.SwfBox.Views;
using GataryLabs.SwfBox.Views.Extensions;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace GataryLabs.SwfBox
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost host;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IHostBuilder hostBuilder = Host.CreateDefaultBuilder();
            
            hostBuilder.ConfigureAppConfiguration(configurationBulder =>
            {

            });

            hostBuilder.ConfigureServices(services =>
            {
                services.AddDomainServices();
                services.AddLocalization();
                services.AddViews();
                services.AddMvvm();

                services.AddMapster();
            });
            host = hostBuilder.Build();

            MainWindow mainWindow = host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}
