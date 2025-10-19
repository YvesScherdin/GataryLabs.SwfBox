using GataryLabs.SwfBox.ViewModels.Abstractions.Commands;
using GataryLabs.SwfBox.ViewModels.Extensions;
using GataryLabs.SwfBox.Views.Abstractions;
using GataryLabs.SwfBox.Views.Abstractions.Models;

namespace GataryLabs.SwfBox.ViewModels.Commands
{
    internal class PickNewSwfFileCommand : Command, IPickNewSwfFileCommand
    {
        private IDialogService dialogService;

        public PickNewSwfFileCommand(IDialogService dialogService)
        {
            this.dialogService = dialogService;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
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
                return;

            //result.FileName
        }
    }
}
