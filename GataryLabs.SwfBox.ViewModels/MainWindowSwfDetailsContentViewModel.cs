using CommunityToolkit.Mvvm.ComponentModel;
using GataryLabs.SwfBox.ViewModels.Abstractions;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using GataryLabs.SwfBox.ViewModels.DataModel;

namespace GataryLabs.SwfBox.ViewModels
{
    internal class MainWindowSwfDetailsContentViewModel : ObservableObject, IMainWindowSwfDetailsContentViewModel
    {
        private ISwfFileDetailsDataModel details;

        public MainWindowSwfDetailsContentViewModel()
        {

        }

        public ISwfFileDetailsDataModel Details
        {
            get => details;
            set => SetProperty(ref details, value);
        }

        public void OnLoaded()
        {
            Details = new SwfFileDetailsDataModel
            {
                FileName = "SomeSWF.swf",
                Path = "a/b/c"
            };
        }

        public void OnUnloaded()
        {

        }
    }
}
