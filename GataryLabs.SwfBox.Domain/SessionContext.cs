using GataryLabs.SwfBox.Configuration.Abstractions;
using GataryLabs.SwfBox.Domain.Abstractions;
using GataryLabs.SwfBox.Domain.Abstractions.Models;
using GataryLabs.SwfBox.Persistence.Abstractions;
using GataryLabs.SwfBox.Persistence.Abstractions.Models;
using MapsterMapper;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GataryLabs.SwfBox.Domain
{
    internal class SessionContext : ISessionContext
    {
        private readonly IUserDataService userDataService;
        private readonly ILibraryDataService libraryDataService;
        private ISwfFileLibraryService libraryService;
        private IMapper mapper;

        public SessionContext(
            IUserDataService userDataService,
            ILibraryDataService libraryDataService,
            ISwfFileLibraryService libraryService,
            IMapper mapper)
        {
            this.userDataService = userDataService;
            this.libraryDataService = libraryDataService;
            this.libraryService = libraryService;
            this.mapper = mapper;

            History = new SessionHistory();
        }

        public SessionHistory History { get; set; }
        public AppRecentData Recent => userDataService.Settings?.Recent;
        public ScanFolderOptions ScanFolderOptions => userDataService.Settings?.Scanning;
        public FileAnalysisOptions AnalysisOptions => userDataService.Settings?.Analysis;
        public PlayerOptions PlayerOptions => userDataService.Settings?.Player;
        public ISwfFileLibraryService LibraryService => libraryService;

        public async Task LoadUserData(CancellationToken cancellationToken)
        {
            await userDataService.LoadAsync(cancellationToken)
                .ConfigureAwait(false);

            History.RecentSwfFile = userDataService.Settings.Recent.LastFileInspected;
            History.RecentScanDirectory = userDataService.Settings.Recent.LastDirectory;
        }

        public async Task SaveUserData(CancellationToken cancellationToken)
        {
            userDataService.Settings.Recent.LastFileInspected = History.RecentSwfFile;
            userDataService.Settings.Recent.LastDirectory = History.RecentScanDirectory;

            await userDataService.SaveAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task LoadLibraryData(CancellationToken cancellationToken)
        {
            await libraryDataService.LoadAsync(cancellationToken)
                .ConfigureAwait(false);

            LibraryFileData libraryData = libraryDataService.LibraryData;

            foreach (SwfFileDetailsData details in libraryData.FileDetails)
            {
                SwfFileDetailsInfo fileInfo = mapper.Map<SwfFileDetailsInfo>(details);
                libraryService.RegisterFile(fileInfo);
            }
        }

        public async Task SaveLibraryData(CancellationToken cancellationToken)
        {
            LibraryFileData libraryData = libraryDataService.LibraryData;
            List<SwfFileDetailsInfo> allFileDetails = libraryService.GetFiles(x => true);

            List<SwfFileDetailsData> detailsDataList = new List<SwfFileDetailsData>();
            foreach (SwfFileDetailsInfo details in allFileDetails)
            {
                SwfFileDetailsData detailsData = mapper.Map<SwfFileDetailsData>(details);
                detailsDataList.Add(detailsData);
            }
            libraryData.FileDetails = detailsDataList.ToArray();

            await libraryDataService.SaveAsync(cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
