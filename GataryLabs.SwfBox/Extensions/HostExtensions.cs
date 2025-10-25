using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Windows;

namespace GataryLabs.SwfBox.Extensions
{
    internal static class HostExtensions
    {
        internal static void LogUnhandledException(this IHost host, object exceptionObject)
        {
            if (host != null)
            {
                using (IServiceScope scope = host.Services.CreateScope())
                {
                    ILogger<App> logger = scope.ServiceProvider.GetService<ILogger<App>>();

                    if (exceptionObject is Exception exception)
                        logger?.LogError(exception, null);
                    else
                        logger?.LogError("" + exceptionObject, null);
                }
            }

            MessageBox.Show($"Unhandled exception:{Environment.NewLine}{exceptionObject}");
        }
    }
}
