using GataryLabs.SwfBox.Configuration.Abstractions;
using GataryLabs.SwfBox.Domain.Abstractions;
using GataryLabs.SwfBox.Domain.Abstractions.Models;
using GataryLabs.SwfBox.Persistence.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace GataryLabs.SwfBox.Domain
{
    internal class SessionContext : ISessionContext
    {
        private readonly IUserDataService userDataService;

        public SessionContext(IUserDataService userDataService)
        {
            this.userDataService = userDataService;

            History = new SessionHistory();
        }

        public SessionHistory History { get; set; }
        public AppRecentData Recent => userDataService.Settings?.Recent;
        public ScanFolderOptions ScanFolderOptions => userDataService.Settings?.Scanning;
        public FileAnalysisOptions AnalysisOptions => userDataService.Settings?.Analysis;
        public PlayerOptions PlayerOptions => userDataService.Settings?.Player;

        public async Task LoadUserData()
        {
            await userDataService.LoadAsync(CancellationToken.None)
                .ConfigureAwait(false);

            History.RecentSwfFile = userDataService.Settings.Recent.LastFileInspected;
            History.RecentScanDirectory = userDataService.Settings.Recent.LastDirectory;
        }

        public async Task SaveUserData()
        {
            userDataService.Settings.Recent.LastFileInspected = History.RecentSwfFile;
            userDataService.Settings.Recent.LastDirectory = History.RecentScanDirectory;

            await userDataService.SaveAsync(CancellationToken.None)
                .ConfigureAwait(false);
        }
    }
}
