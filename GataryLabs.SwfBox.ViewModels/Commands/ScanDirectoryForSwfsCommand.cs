using GataryLabs.SwfBox.Configuration.Abstractions;
using GataryLabs.SwfBox.Domain.Abstractions;
using GataryLabs.SwfBox.Domain.Abstractions.Models;
using GataryLabs.SwfBox.ViewModels.Abstractions;
using GataryLabs.SwfBox.ViewModels.Abstractions.Commands;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using GataryLabs.SwfBox.ViewModels.DataModel;
using GataryLabs.SwfBox.Views.Abstractions;
using GataryLabs.SwfBox.Views.Abstractions.Models;
using MapsterMapper;
using System.IO;
using System.Linq;

namespace GataryLabs.SwfBox.ViewModels.Commands
{
    internal class ScanDirectoryForSwfsCommand : Command, IScanDirectoryForSwfsCommand
    {
        private IDialogService dialogService;
        private ISwfFileLibraryService swfFileLibraryService;
        private IMainWindowContextDataModel mainWindowContextDataModel;
        private ISessionContext sessionContext;
        private ILocalizationSource localizationSource;
        private INotificationService notificationService;
        private IMapper mapper;

        public ScanDirectoryForSwfsCommand(
            IDialogService dialogService,
            ISwfFileLibraryService swfFileLibraryService,
            IMainWindowContextDataModel mainWindowContextDataModel,
            ISessionContext sessionContext,
            INotificationService notificationService,
            ILocalizationSource localizationSource,
            IMapper mapper)
        {
            this.dialogService = dialogService;
            this.swfFileLibraryService = swfFileLibraryService;
            this.mainWindowContextDataModel = mainWindowContextDataModel;
            this.sessionContext = sessionContext;
            this.notificationService = notificationService;
            this.localizationSource = localizationSource;
            this.mapper = mapper;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            if (!PromptFileSelection(out string selectedDirectoryPath))
                return;

            SwfFileDetailsInfo[] files = ScanForSwfFiles(selectedDirectoryPath);

            if (!ValidateSelection(ref files))
                return;

            ProcessSelection(files);
        }

        private bool PromptFileSelection(out string directoryPath)
        {
            string recentFolder = sessionContext.History.RecentScanDirectory;

            if (string.IsNullOrWhiteSpace(recentFolder))
                recentFolder = Directory.GetCurrentDirectory();

            OpenDirectoryDialogResult result = dialogService.OpenDirectory(
                new OpenDirectoryDialogOptions
                {
                    InitialDirectory = recentFolder,
                    AcceptButtonText = localizationSource.GetText("Loca.Main.Overview.Dialog.ScanDirectoryForSwfs.Accept"),
                    Title = localizationSource.GetText("Loca.Main.Overview.Dialog.ScanDirectoryForSwfs.Title"),
                    AllowCreateNewFolder = false
                }
            );

            if (!result.Accepted)
            {
                directoryPath = null;
                return false;
            }

            sessionContext.Recent.LastDirectory = result.DirectoryPath;
            sessionContext.History.RecentScanDirectory = result.DirectoryPath;
            directoryPath = result.DirectoryPath;
            return true;
        }

        private SwfFileDetailsInfo[] ScanForSwfFiles(string selectedFolderPath)
        {
            ScanFolderOptions scanOptions = sessionContext.ScanFolderOptions;

            SwfFileDetailsInfo[] allNewDetails = swfFileLibraryService.ScanFolder(
                selectedFolderPath, scanOptions);

            return allNewDetails;
        }

        private bool ValidateSelection(ref SwfFileDetailsInfo[] scannedDetails)
        {
            if (scannedDetails == null)
                return false;

            if (scannedDetails.Length == 0)
            {
                dialogService.Alert(new AlertOptions
                {
                    Title = localizationSource.GetText("Loca.Main.Overview.Dialog.NoSwfFilesFound.Title"),
                    Message = localizationSource.GetText("Loca.Main.Overview.Dialog.NoSwfFilesFound.Message"),
                });

                return false;
            }

            string[] negativeFilters = sessionContext.ScanFolderOptions.FileNamesToIgnore;

            scannedDetails = scannedDetails
                .Where(detailsInfo => !swfFileLibraryService.HasFileWithPath(detailsInfo.Path))
                .ToArray();

            if (scannedDetails.Length == 0)
            {
                dialogService.Alert(new AlertOptions
                {
                    Title = localizationSource.GetText("Loca.Main.Overview.Dialog.NoNewSwfFilesFound.Title"),
                    Message = localizationSource.GetText("Loca.Main.Overview.Dialog.NoNewSwfFilesFound.Message"),
                });

                return false;
            }

            return true;
        }

        private void ProcessSelection(SwfFileDetailsInfo[] scannedDetails)
        {
            foreach (SwfFileDetailsInfo details in scannedDetails)
            {
                swfFileLibraryService.RegisterFile(details);
            }

            ISwfFileBriefDataModel[] newBriefDataModelsToAdd = scannedDetails
                .Select(x => mapper.Map<SwfFileBriefDataModel>(x))
                .Reverse()
                .ToArray();

            foreach (ISwfFileBriefDataModel newBriefDataModel in newBriefDataModelsToAdd)
            {
                mainWindowContextDataModel.RecentSwfFiles.Files.Insert(0, newBriefDataModel);
            }

            mainWindowContextDataModel.SelectedSwfFileItem = newBriefDataModelsToAdd.LastOrDefault();

            string notificationMessage = string.Format(localizationSource.GetText("Loca.Notification.ScanDirectoryForSwfs.Result"), newBriefDataModelsToAdd.Length);
            notificationService.ShowAsToast(notificationMessage);
        }
    }
}
