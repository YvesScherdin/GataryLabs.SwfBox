using Microsoft.Extensions.Hosting;
using NLog;

namespace GataryLabs.SwfBox.Extensions
{
    internal static class HostBuilderExtensions
    {
        internal static IHostBuilder ConfigureAppLogging(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureLogging(loggingBuilder =>
            {
                var config = new NLog.Config.LoggingConfiguration();

                // Targets where to log to: File and Console
                var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "Log.SwfBox.txt" };
                var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

                // Rules for mapping loggers to targets            
                config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
                config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

                // Apply config           
                NLog.LogManager.Configuration = config;
            });

            return hostBuilder;
        }
    }
}
