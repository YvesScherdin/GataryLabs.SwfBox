using GataryLabs.SwfBox.ViewModels.Abstractions;
using GataryLabs.SwfBox.ViewModels.Abstractions.Commands;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using GataryLabs.SwfBox.ViewModels.Extensions;
using GataryLabs.SwfBox.ViewModels.Utils;

namespace GataryLabs.SwfBox.ViewModels.Commands
{
    internal class SelectSwfFileCommand : Command<ISwfFileBriefDataModel>, ISelectSwfFileCommand
    {
        private readonly LazyInstance<IMainWindowViewModel> mainWindowViewModelLazy;

        public SelectSwfFileCommand(LazyInstance<IMainWindowViewModel> mainWindowViewModelLazy)
        {
            this.mainWindowViewModelLazy = mainWindowViewModelLazy;
        }

        public override bool CanExecute(ISwfFileBriefDataModel parameter)
        {
            return mainWindowViewModelLazy.Value.MainContentViewModel == mainWindowViewModelLazy.Value.MainWindowSwfDetailsContentViewModel
                || !mainWindowViewModelLazy.Value.MainWindowSwfDetailsContentViewModel.DisplaysSwf(parameter);
        }

        public override void Execute(ISwfFileBriefDataModel parameter)
        {
            IMainWindowSwfDetailsContentViewModel viewModel = mainWindowViewModelLazy.Value.MainWindowSwfDetailsContentViewModel;
            viewModel.Details = null; // <--- D:

            mainWindowViewModelLazy.Value.MainContentViewModel = viewModel;
        }
    }
}
