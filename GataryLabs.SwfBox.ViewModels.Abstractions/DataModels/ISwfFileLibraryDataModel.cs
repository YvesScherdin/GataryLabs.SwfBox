using GataryLabs.Mvvm.ViewModels.Abstractions.DataModels;
using System.Collections.ObjectModel;

namespace GataryLabs.SwfBox.ViewModels.Abstractions.DataModels
{
    public interface ISwfFileLibraryDataModel : IDataModel
    {
        ObservableCollection<ISwfFileBriefDataModel> Files { get; }
    }
}
