using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using System.Windows.Input;

namespace GataryLabs.SwfBox.ViewModels.Abstractions
{
    public interface IMainWindowOverviewContentViewModel : IMainWindowContentViewModel
    {
        ICommand PickNewSwfFileCommand { get; }
        ICommand ScanDirectoryCommand { get; }
        ICommand SelectSwfFileCommand { get; }

        IRecentSwfFileLibraryDataModel RecentSwfFiles { get; }
    }
}
