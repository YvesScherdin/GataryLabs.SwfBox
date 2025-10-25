using GataryLabs.SwfBox.Configuration.Abstractions;
using GataryLabs.SwfBox.Domain.Abstractions;
using GataryLabs.SwfBox.Domain.Abstractions.Models;

namespace GataryLabs.SwfBox.Domain
{
    internal class SessionContext : ISessionContext
    {
        public SessionHistory History { get; set; }

        public ScanFolderOptions ScanFolderOptions { get; set; }
    }
}
