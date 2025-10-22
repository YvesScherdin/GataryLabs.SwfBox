using CommunityToolkit.Mvvm.ComponentModel;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using System.Collections.ObjectModel;

namespace GataryLabs.SwfBox.ViewModels.DataModel
{
    internal class SwfFileLibraryDataModel : ObservableObject, ISwfFileLibraryDataModel
    {
        private ObservableCollection<ISwfFileBriefDataModel> files = new ObservableCollection<ISwfFileBriefDataModel>();

        public ObservableCollection<ISwfFileBriefDataModel> Files
        {
            get => files;
            set => SetProperty(ref files, value);
        }
    }
}
