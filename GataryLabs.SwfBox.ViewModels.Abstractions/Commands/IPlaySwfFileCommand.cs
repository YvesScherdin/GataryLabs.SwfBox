using GataryLabs.Mvvm.ViewModels.Abstractions.Commands;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;

namespace GataryLabs.SwfBox.ViewModels.Abstractions.Commands
{
    public interface IPlaySwfFileCommand : ICommand<ISwfFileDetailsDataModel>
    {
    }
}
