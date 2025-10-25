using GataryLabs.SwfBox.Domain.Abstractions;
using GataryLabs.SwfBox.Domain.Abstractions.Models;

namespace GataryLabs.SwfBox.Domain
{
    internal class SessionContext : ISessionContext
    {
        public SessionHistory History { get; set; }

        public ScanFolderOptions ScanFolderOptions { get; set; }

        public SessionContext()
        {
            History = new SessionHistory();

            ScanFolderOptions = new ScanFolderOptions
            {
                Depth = 1,
                FileNamesToIgnore = new string[]
                {
                    "expressInstall.swf"
                }
            };
        }
    }
}
