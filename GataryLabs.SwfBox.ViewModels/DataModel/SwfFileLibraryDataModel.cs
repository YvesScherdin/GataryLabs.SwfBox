using CommunityToolkit.Mvvm.ComponentModel;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using System.Collections.Generic;

namespace GataryLabs.SwfBox.ViewModels.DataModel
{
    internal class SwfFileLibraryDataModel : ObservableObject, ISwfFileLibraryDataModel
    {
        private IList<ISwfFileBriefDataModel> files;

        public IList<ISwfFileBriefDataModel> Files
        {
            get => files;
            set => SetProperty(ref files, value);
        }
    }
}
