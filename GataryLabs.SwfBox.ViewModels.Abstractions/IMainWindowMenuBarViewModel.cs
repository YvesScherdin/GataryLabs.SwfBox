using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using System.Collections.Generic;
using System.Windows.Input;

namespace GataryLabs.SwfBox.ViewModels.Abstractions
{
    public interface IMainWindowMenuBarViewModel : IViewModel
    {
        ICommand OpenOverviewCommand { get; }
        ICommand OpenSettingsCommand { get; }
        ICommand SelectSwfFileCommand { get; }

        IList<ISwfFileBriefDataModel> RecentSwfFiles { get; }
    }
}
