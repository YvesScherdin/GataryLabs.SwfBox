using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using System.Windows.Input;

namespace GataryLabs.SwfBox.ViewModels.Abstractions
{
    public interface IMainWindowSwfDetailsContentViewModel : IMainWindowContentViewModel
    {
        ISwfFileDetailsDataModel Details { get; set; }

        ICommand PlayCommand { get; }

        ICommand AnalyzeCommand { get; }
    }
}
