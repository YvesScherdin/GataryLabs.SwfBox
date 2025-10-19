using GataryLabs.SwfBox.ViewModels.Abstractions.Commands;
using System.Windows.Input;

namespace GataryLabs.SwfBox.ViewModels.Abstractions
{
    public interface IMainWindowMenuBarViewModel : IViewModel
    {
        ICommand OpenOverviewCommand { get; }
        ICommand OpenSettingsCommand { get; }
        ISelectSwfFileCommand SelectSwfFileCommand { get; }

        IMainWindowContextDataModel ContextData { get; }
    }
}
