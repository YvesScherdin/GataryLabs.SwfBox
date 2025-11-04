using GataryLabs.SwfBox.ViewModels.Abstractions.Commands;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;

namespace GataryLabs.SwfBox.ViewModels.Abstractions
{
    public interface IMainWindowSwfDetailsContentViewModel : IMainWindowContentViewModel
    {
        ISwfFileDetailsDataModel Details { get; set; }

        IPlaySwfFileCommand PlayCommand { get; }

        IAnalyzeSwfFileCommand AnalyzeCommand { get; }

        IExploreCommand ExploreCommand { get; }
    }
}
