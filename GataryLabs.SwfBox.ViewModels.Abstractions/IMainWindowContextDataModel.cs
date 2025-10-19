using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;

namespace GataryLabs.SwfBox.ViewModels.Abstractions
{
    public interface IMainWindowContextDataModel : IDataModel
    {
        ISwfFileBriefDataModel SelectedSwfFileItem { get; set; }
        IRecentSwfFileLibraryDataModel RecentSwfFiles { get; set; }
        ISwfFileDetailsDataModel FileDetails { get; set; }
    }
}
