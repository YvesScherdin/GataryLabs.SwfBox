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

namespace GataryLabs.SwfBox.ViewModels.Commands
{
    internal class PickNewSwfFileCommand : Command, IPickNewSwfFileCommand
    {
        private IDialogService dialogService;
        private ISwfFileLibraryService swfFileLibraryService;
        private IRecentSwfFileLibraryDataModel recentSwfFileLibraryDataModel;
        private IMainWindowContextDataModel mainWindowContextDataModel;
        private IMapper mapper;

        public PickNewSwfFileCommand(
            IDialogService dialogService,
            ISwfFileLibraryService swfFileLibraryService,
            IRecentSwfFileLibraryDataModel recentSwfFileLibraryDataModel,
            IMainWindowContextDataModel mainWindowContextDataModel,
            IMapper mapper)
        {
            this.dialogService = dialogService;
            this.swfFileLibraryService = swfFileLibraryService;
            this.recentSwfFileLibraryDataModel = recentSwfFileLibraryDataModel;
            this.mainWindowContextDataModel = mainWindowContextDataModel;
            this.mapper = mapper;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            string selectedFilePath = PromptFileSelection();

            if (selectedFilePath == null)
                return;
            
            if (swfFileLibraryService.HasFileWithPath(selectedFilePath))
            {
                dialogService.Alert(new AlertOptions
                {
                    Title = "Already added",
                    Message = "A file with that path does already exist."
                });
                return;
            }

            SwfFileDetailsInfo detailsInfo = swfFileLibraryService.Load(selectedFilePath);
            swfFileLibraryService.RegisterFile(detailsInfo);

            SwfFileDetailsDataModel detailsDataModel = mapper.Map<SwfFileDetailsDataModel>(detailsInfo);
            SwfFileBriefDataModel brieftDataModel = mapper.Map<SwfFileBriefDataModel>(detailsDataModel);

            mainWindowContextDataModel.RecentSwfFiles.Files.Add(brieftDataModel);
            mainWindowContextDataModel.SelectedSwfFileItem = brieftDataModel;
        }

        private string PromptFileSelection()
        {
            OpenFileDialogResult result = dialogService.OpenFile(
                new OpenFileDialogOptions
                {
                    Multiselect = false,
                    Title = "Select an SWF file"
                }
                .AddFilter("SWF Files", "swf")
            );

            if (!result.Accepted)
                return null;

            return result.FileName;
        }
    }
}
