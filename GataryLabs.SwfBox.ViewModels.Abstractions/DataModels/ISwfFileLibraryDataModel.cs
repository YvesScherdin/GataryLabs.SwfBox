using System.Collections.Generic;

namespace GataryLabs.SwfBox.ViewModels.Abstractions.DataModels
{
    public interface ISwfFileLibraryDataModel : IDataModel
    {
        IList<ISwfFileBriefDataModel> Files { get; }
    }
}
