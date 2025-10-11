using CommunityToolkit.Mvvm.ComponentModel;
using GataryLabs.SwfBox.ViewModels.Abstractions;
using GataryLabs.SwfBox.ViewModels.DataModel;
using System.Diagnostics;

namespace GataryLabs.SwfBox.ViewModels
{
    internal class MainWindowViewModel : ObservableObject, IMainWindowViewModel
    {
        private IMainWindowContentViewModel mainContentViewModel;

        public IMainWindowContentViewModel MainContentViewModel
        {
            get => mainContentViewModel;
            set => SetProperty(ref mainContentViewModel, value);
        }

        public MainWindowViewModel()
        {
            
        }

        public void OnLoaded()
        {
            Debug.WriteLine("On loaded");

            mainContentViewModel = new MainWindowSwfDetailsContentViewModel
            {
                Details = new SwfFileDetailsDataModel
                {
                     Path = "path/to/somewhere",
                     FileName = "file.swf"
                }
            };
        }

        public void OnUnloaded()
        {
            Debug.WriteLine("On unloaded");
        }
    }
}
