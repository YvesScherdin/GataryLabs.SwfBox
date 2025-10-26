using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;

namespace GataryLabs.SwfBox.Extensions
{
    internal static class HostBuilderExtensions
    {
        internal static IHostBuilder ConfigureAppLogging(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddNLog(new NLogProviderOptions
                {
                    AutoShutdown = true,
                    IncludeScopes = true
                });
            });
            
            return hostBuilder;
        }
    }
}
