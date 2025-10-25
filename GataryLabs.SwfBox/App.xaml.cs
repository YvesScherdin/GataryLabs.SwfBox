using GataryLabs.SwfBox.Configuration.Abstractions;
using GataryLabs.SwfBox.Domain.Extensions;
using GataryLabs.SwfBox.Extensions;
using GataryLabs.SwfBox.ViewModels.Extensions;
using GataryLabs.SwfBox.Views;
using GataryLabs.SwfBox.Views.Extensions;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace GataryLabs.SwfBox
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost host;
        private ILogger<App> logger;

        public App()
        {
            DispatcherUnhandledException += App_DispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += AppDomainCurrentDomain_UnhandledException;

            SetupHost();
        }

        private void SetupHost()
        {
            IHostBuilder hostBuilder = Host.CreateDefaultBuilder();

            hostBuilder.UseDefaultServiceProvider(options =>
            {
                options.ValidateOnBuild = true;
                options.ValidateScopes = true;
            });

            hostBuilder.ConfigureAppConfiguration(configurationBulder =>
            {
                configurationBulder.AddEnvironmentVariables();
                configurationBulder.AddJsonFile("appsettings.json");
            });

            hostBuilder.ConfigureAppLogging();

            hostBuilder.ConfigureServices((hostBuilderContext, services) =>
            {
                ScanFolderOptions defaultScanFolderOptions = new ScanFolderOptions();
                hostBuilderContext.Configuration.GetSection("ScanFolderOptions").Bind(defaultScanFolderOptions);

                services.AddDomainServices(defaultScanFolderOptions);
                services.AddLocalization();
                services.AddViews();
                services.AddMvvm();

                services.AddMapster();
            });

            host = hostBuilder.Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            await host.StartAsync(CancellationToken.None);

            MainWindow mainWindow = host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await host.StopAsync(CancellationToken.None);

            base.OnExit(e);
        }

        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            host.LogUnhandledException(e.Exception);
            e.Handled = true;
        }

        private void AppDomainCurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            host.LogUnhandledException(e.ExceptionObject);
        }

    }
}
