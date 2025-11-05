using GataryLabs.SwfBox.Views.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GataryLabs.SwfBox.Views.Extensions
{
    public static class HostExtensions
    {
        public static IHost PrepareViewServices(this IHost host)
        {
            _ = host.Services.GetRequiredService<SwfBoxViewContext>();

            return host;
        }
    }
}
