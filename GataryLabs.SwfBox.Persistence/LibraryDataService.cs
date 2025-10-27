using GataryLabs.SwfBox.Persistence.Abstractions;
using GataryLabs.SwfBox.Persistence.Abstractions.Models;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace GataryLabs.SwfBox.Persistence
{
    internal class LibraryDataService : ILibraryDataService
    {
        private const string libraryFileName = "SwfBox.Libraries.json";

        private readonly string userDataDirectory;
        private readonly LocalSettingsStorage<LibraryFileData> settingsStorage;

        public LibraryDataService(string userDataDirectory)
        {
            this.userDataDirectory = userDataDirectory;

            settingsStorage = new LocalSettingsStorage<LibraryFileData>();
        }

        public LibraryFileData LibraryData { get; set; }

        public async Task LoadAsync(CancellationToken cancellationToken)
        {
            LibraryFileData loadedLibraryData = await settingsStorage.LoadAsync(GetLibraryFileDataPath(), cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();

            if (loadedLibraryData == null)
            {
                loadedLibraryData = new LibraryFileData
                {
                    FileDetails = new SwfFileDetailsData[0],
                    Libraries = new SwfFileLibraryData[0]
                };
                ValidateSettings(loadedLibraryData);
                await settingsStorage.SaveAsync(loadedLibraryData, GetLibraryFileDataPath(), cancellationToken);
            }
            else
            {
                ValidateSettings(loadedLibraryData);
            }

            this.LibraryData = loadedLibraryData;
        }

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            ValidateSettings(LibraryData);

            await settingsStorage.SaveAsync(LibraryData, GetLibraryFileDataPath(), cancellationToken);
        }

        private void ValidateSettings(LibraryFileData settings)
        {
            if (settings == null)
                return;
        }

        private string GetLibraryFileDataPath()
        {
            return Path.Combine(userDataDirectory, libraryFileName);
        }
    }
}
