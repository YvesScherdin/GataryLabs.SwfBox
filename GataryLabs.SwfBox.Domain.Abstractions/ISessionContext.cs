using GataryLabs.SwfBox.Configuration.Abstractions;
using GataryLabs.SwfBox.Domain.Abstractions.Models;
using System.Threading.Tasks;

namespace GataryLabs.SwfBox.Domain.Abstractions
{
    public interface ISessionContext
    {
        SessionHistory History { get; set; }

        AppRecentData Recent { get; }
        ScanFolderOptions ScanFolderOptions { get; }
        FileAnalysisOptions AnalysisOptions { get; }
        PlayerOptions PlayerOptions { get; }

        Task LoadUserData();

        Task SaveUserData();
    }
}
