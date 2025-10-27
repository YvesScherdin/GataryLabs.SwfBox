using GataryLabs.SwfBox.Domain.Abstractions;
using GataryLabs.SwfBox.Domain.Abstractions.Models;
using GataryLabs.SwfBox.ViewModels.Abstractions;
using GataryLabs.SwfBox.ViewModels.Abstractions.Commands;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using GataryLabs.SwfBox.ViewModels.DataModel;
using GataryLabs.SwfBox.ViewModels.Extensions;
using GataryLabs.SwfBox.Views.Abstractions;
using GataryLabs.SwfBox.Views.Abstractions.Models;
using MapsterMapper;
using System.Threading;

namespace GataryLabs.SwfBox.ViewModels.Commands
{
    internal class PickNewSwfFileCommand : Command, IPickNewSwfFileCommand
    {
        private IDialogService dialogService;
        private ISwfFileLibraryService swfFileLibraryService;
        private IMainWindowContextDataModel mainWindowContextDataModel;
        private ISessionContext sessionContext;
        private ILocalizationSource localizationSource;
        private IMapper mapper;

        public PickNewSwfFileCommand(
            IDialogService dialogService,
            ISwfFileLibraryService swfFileLibraryService,
            IMainWindowContextDataModel mainWindowContextDataModel,
            ISessionContext sessionContext,
            ILocalizationSource localizationSource,
            IMapper mapper)
        {
            this.dialogService = dialogService;
            this.swfFileLibraryService = swfFileLibraryService;
            this.mainWindowContextDataModel = mainWindowContextDataModel;
            this.sessionContext = sessionContext;
            this.localizationSource = localizationSource;
            this.mapper = mapper;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            string selectedFilePath = PromptFileSelection();

            if (!ValidateSelection(selectedFilePath))
                return;

            ProcessSelection(selectedFilePath);
        }

        private string PromptFileSelection()
        {
            OpenFileDialogResult result = dialogService.OpenFile(
                new OpenFileDialogOptions
                {
                    Multiselect = false,
                    Title = localizationSource.GetText("Loca.Main.Overview.Dialog.SelectAnSwfFile.Title")
                }
                .AddFilter(localizationSource.GetText("Loca.Misc.Extensions.SwfFiles"), "swf")
            );

            if (!result.Accepted)
                return null;

            return result.FileName;
        }

        private bool ValidateSelection(string selectedFilePath)
        {
            if (selectedFilePath == null)
                return false;

            if (swfFileLibraryService.HasFileWithPath(selectedFilePath))
            {
                dialogService.Alert(new AlertOptions
                {
                    Title = localizationSource.GetText("Loca.Main.Overview.Dialog.SwfFileAlreadyAdded.Title"),
                    Message = localizationSource.GetText("Loca.Main.Overview.Dialog.SwfFileAlreadyAdded.Message"),
                });
                return false;
            }

            return true;
        }

        private void ProcessSelection(string selectedFilePath)
        {
            SwfFileDetailsInfo detailsInfo = swfFileLibraryService.Load(selectedFilePath);
            swfFileLibraryService.RegisterFile(detailsInfo);

            ISwfFileBriefDataModel brieftDataModel = mapper.Map<SwfFileBriefDataModel>(detailsInfo);

            sessionContext.History.RecentSwfFile = detailsInfo.Id;
            mainWindowContextDataModel.RecentSwfFiles.Files.Insert(0, brieftDataModel);
            mainWindowContextDataModel.SelectedSwfFileItem = brieftDataModel;

            sessionContext.SaveLibraryData(CancellationToken.None);
        }
    }
}
