using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using System.Windows.Input;

namespace GataryLabs.SwfBox.ViewModels.Abstractions
{
    public interface IMainWindowOverviewContentViewModel : IMainWindowContentViewModel
    {
        ICommand PickNewSwfCommand { get; }
        ICommand ScanDirectoryCommand { get; }

        ISwfFileLibraryDataModel RecentlyAddedSwfFiles { get; }
    }
}
