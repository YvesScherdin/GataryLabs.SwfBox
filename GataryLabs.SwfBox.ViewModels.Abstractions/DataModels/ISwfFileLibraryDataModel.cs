using System.Collections.ObjectModel;

namespace GataryLabs.SwfBox.ViewModels.Abstractions.DataModels
{
    public interface ISwfFileLibraryDataModel : IDataModel
    {
        ObservableCollection<ISwfFileBriefDataModel> Files { get; }
    }
}
