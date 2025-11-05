using GataryLabs.Mvvm.ViewModels.Commands;
using GataryLabs.SwfBox.ViewModels.Abstractions.Commands;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using GataryLabs.SwfBox.ViewModels.Utilities;

namespace GataryLabs.SwfBox.ViewModels.Commands
{
    internal class ExploreCommand : Command<ISwfFileDetailsDataModel>, IExploreCommand
    {
        public override bool CanExecute(ISwfFileDetailsDataModel parameter)
        {
            return true;
        }

        public override void Execute(ISwfFileDetailsDataModel parameter)
        {
            ExternalProcessUtility.OpenInExplorer(parameter.Path);
        }
    }
}
