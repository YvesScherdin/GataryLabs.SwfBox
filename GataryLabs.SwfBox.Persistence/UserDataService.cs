using GataryLabs.SwfBox.Configuration.Abstractions;
using GataryLabs.SwfBox.Persistence.Abstractions;
using MapsterMapper;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GataryLabs.SwfBox.Persistence
{
    internal class UserDataService : IUserDataService
    {
        private const string userSettingsFileName = "SwfBox.UserSettings.json";

        private readonly string userDataDirectory;
        private readonly UserSettings defaultSettings;
        private readonly IMapper mapper;
        private readonly LocalSettingsStorage<UserSettings> localUserSettings;

        public UserDataService(string userDataDirectory, UserSettings defaultSettings, IMapper mapper)
        {
            this.userDataDirectory = userDataDirectory;
            this.defaultSettings = defaultSettings;
            this.mapper = mapper;

            localUserSettings = new LocalSettingsStorage<UserSettings>();
        }

        public UserSettings Settings { get; set; }

        public async Task LoadAsync(CancellationToken cancellationToken)
        {
            UserSettings settings = await localUserSettings.LoadAsync(GetUserSettingsPath(), cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();

            if (settings == null)
            {
                settings = new UserSettings();
                ValidateSettings(settings);
                await localUserSettings.SaveAsync(settings, GetUserSettingsPath(), cancellationToken);
            }
            else
            {
                ValidateSettings(settings);
            }

            this.Settings = settings;
        }

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            ValidateSettings(Settings);

            await localUserSettings.SaveAsync(Settings, GetUserSettingsPath(), cancellationToken);
        }

        private void ValidateSettings(UserSettings settings)
        {
            if (settings == null)
                return;

            if (settings.Recent == null)
            {
                settings.Recent = new AppRecentData();
            }

            if (settings.Scanning == null)
            {
                settings.Scanning = new ScanFolderOptions();
                mapper.Map(defaultSettings.Scanning, settings.Scanning);
            }

            if (settings.Analysis == null)
            {
                settings.Analysis = new FileAnalysisOptions();
                mapper.Map(defaultSettings.Analysis, settings.Analysis);
            }

            ValidatePlayerSettings(settings);
        }

        private void ValidatePlayerSettings(UserSettings settings)
        {
            if (settings.Player == null)
            {
                settings.Player = new PlayerOptions();
                mapper.Map(defaultSettings.Player, settings.Player);
            }

            if (settings.Player.Players == null)
            {
                settings.Player = defaultSettings.Player;
            }

            if (!settings.Player.Players.Any(x => x.Mode == PlayerMode.IntegratedWebPlayer))
            {
                List<PlayerData> list = settings.Player.Players.ToList();
                list.Insert(0, new PlayerData { Mode = PlayerMode.IntegratedWebPlayer });
                settings.Player.Players = list.ToArray();
            }

            if (settings.Player.PlayerTypeIndex < 0 || settings.Player.PlayerTypeIndex >= settings.Player.Players.Length - 1)
            {
                settings.Player.PlayerTypeIndex = 0;
            }
        }

        private string GetUserSettingsPath()
        {
            return Path.Combine(userDataDirectory, userSettingsFileName);
        }
    }
}
