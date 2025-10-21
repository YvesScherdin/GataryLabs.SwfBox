using GataryLabs.SwfBox.Domain.Abstractions;
using GataryLabs.SwfBox.Domain.Abstractions.Models;
using GataryLabs.SwfBox.ViewModels.Abstractions.Commands;
using GataryLabs.SwfBox.ViewModels.Extensions;
using GataryLabs.SwfBox.Views.Abstractions;
using GataryLabs.SwfBox.Views.Abstractions.Models;
using System.Diagnostics;

namespace GataryLabs.SwfBox.ViewModels.Commands
{
    internal class PickNewSwfFileCommand : Command, IPickNewSwfFileCommand
    {
        private IDialogService dialogService;
        private ISwfFileLibraryService swfFileLibraryService;

        public PickNewSwfFileCommand(
            IDialogService dialogService,
            ISwfFileLibraryService swfFileLibraryService)
        {
            this.dialogService = dialogService;
            this.swfFileLibraryService = swfFileLibraryService;
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
            Debug.WriteLine(detailsInfo);

            swfFileLibraryService.RegisterFile(detailsInfo);
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
