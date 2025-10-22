using AgileObjects.AgileMapper;
using GataryLabs.SwfBox.Domain.Extensions;
using GataryLabs.SwfBox.ViewModels.Extensions;
using GataryLabs.SwfBox.Views;
using GataryLabs.SwfBox.Views.Extensions;
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
                IMapper mapper = Mapper.CreateNew();

                services.AddDomainServices();
                services.AddViews();
                services.AddMvvm(mapper);

                services.AddSingleton(mapper);
            });

            this.host = hostBuilder.Build();

            MainWindow mainWindow = host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}
