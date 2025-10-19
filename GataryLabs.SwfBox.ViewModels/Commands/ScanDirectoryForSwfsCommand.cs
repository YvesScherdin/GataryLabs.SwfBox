using GataryLabs.SwfBox.ViewModels.Abstractions.Commands;
using GataryLabs.SwfBox.Views.Abstractions;

namespace GataryLabs.SwfBox.ViewModels.Commands
{
    internal class ScanDirectoryForSwfsCommand : Command, IScanDirectoryForSwfsCommand
    {
        private IDialogService dialogService;

        public ScanDirectoryForSwfsCommand(IDialogService dialogService)
        {
            this.dialogService = dialogService;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            //OpenFileDialogResult result = dialogService.OpenDirectory();
        }
    }
}
