using GataryLabs.SwfBox.Configuration.Abstractions;
using GataryLabs.SwfBox.Domain.Abstractions;
using GataryLabs.SwfBox.Domain.Extensions;
using GataryLabs.SwfBox.Extensions;
using GataryLabs.SwfBox.Persistence.Extensions;
using GataryLabs.SwfBox.ViewModels.Extensions;
using GataryLabs.SwfBox.Views;
using GataryLabs.SwfBox.Views.Extensions;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
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
                UserSettings defaultSettings = new UserSettings();
                hostBuilderContext.Configuration.GetSection("DefaultSettings").Bind(defaultSettings);

                string userDataPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "GataryLabs", "SwfBox");

                services.AddPersistence(userDataPath, defaultSettings);
                services.AddDomainServices();
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

            InitializeLogger();
            logger.LogInformation("OnStartup");
            await InitializeSessionAsync();
            InitializeUI();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            logger?.LogInformation("OnExit");

            await SaveDataOnExitAsync();

            await host.StopAsync(CancellationToken.None);

            base.OnExit(e);
        }

        private void InitializeLogger()
        {
            logger = host.Services.GetRequiredService<ILogger<App>>();
        }

        private async Task InitializeSessionAsync()
        {
            ISessionContext sessionContext = host.Services.GetRequiredService<ISessionContext>();
            await sessionContext.LoadUserData(CancellationToken.None);
            await sessionContext.LoadLibraryData(CancellationToken.None);
        }

        private void InitializeUI()
        {
            host.PrepareViewServices();
            MainWindow mainWindow = host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private async Task SaveDataOnExitAsync()
        {
            ISessionContext sessionContext = host?.Services.GetRequiredService<ISessionContext>();
            await sessionContext?.SaveUserData(CancellationToken.None);
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
