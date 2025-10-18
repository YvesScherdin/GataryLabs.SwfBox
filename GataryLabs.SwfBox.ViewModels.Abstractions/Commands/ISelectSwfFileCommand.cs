using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using System.Windows.Input;

namespace GataryLabs.SwfBox.ViewModels.Abstractions.Commands
{
    public interface ISelectSwfFileCommand : ICommand<ISwfFileBriefDataModel>
    {
    }
}
