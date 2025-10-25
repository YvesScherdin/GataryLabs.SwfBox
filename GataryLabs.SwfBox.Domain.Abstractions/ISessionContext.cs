using GataryLabs.SwfBox.Domain.Abstractions.Models;

namespace GataryLabs.SwfBox.Domain.Abstractions
{
    public interface ISessionContext
    {
        SessionHistory History { get; set; }

        ScanFolderOptions ScanFolderOptions { get; set; }
    }
}
