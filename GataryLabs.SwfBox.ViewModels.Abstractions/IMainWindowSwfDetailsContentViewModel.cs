using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;

namespace GataryLabs.SwfBox.ViewModels.Abstractions
{
    public interface IMainWindowSwfDetailsContentViewModel : IMainWindowContentViewModel
    {
        ISwfFileDetailsDataModel Details { get; set; }
    }
}
