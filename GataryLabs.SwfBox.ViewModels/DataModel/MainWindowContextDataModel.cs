using CommunityToolkit.Mvvm.ComponentModel;
using GataryLabs.SwfBox.ViewModels.Abstractions;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;

namespace GataryLabs.SwfBox.ViewModels.DataModel
{
    internal class MainWindowContextDataModel : ObservableObject, IMainWindowContextDataModel
    {
        private ISwfFileBriefDataModel selectedSwfFileItem;
        private IRecentSwfFileLibraryDataModel recentSwfFiles;
        private ISwfFileDetailsDataModel fileDetails;

        public MainWindowContextDataModel(IRecentSwfFileLibraryDataModel recentSwfFiles)
        {
            this.recentSwfFiles = recentSwfFiles;
        }

        public IRecentSwfFileLibraryDataModel RecentSwfFiles
        {
            get => recentSwfFiles;
            set => SetProperty(ref recentSwfFiles, value);
        }

        public ISwfFileBriefDataModel SelectedSwfFileItem
        {
            get => selectedSwfFileItem;
            set => SetProperty(ref selectedSwfFileItem, value);
        }

        public ISwfFileDetailsDataModel FileDetails
        {
            get => fileDetails;
            set => SetProperty(ref fileDetails, value);
        }
    }
}
