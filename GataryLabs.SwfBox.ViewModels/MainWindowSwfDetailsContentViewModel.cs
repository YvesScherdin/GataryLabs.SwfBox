using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GataryLabs.SwfBox.ViewModels.Abstractions;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using GataryLabs.SwfBox.ViewModels.DataModel;
using System.Diagnostics;
using System.Windows.Input;

namespace GataryLabs.SwfBox.ViewModels
{
    internal class MainWindowSwfDetailsContentViewModel : ObservableObject, IMainWindowSwfDetailsContentViewModel
    {
        private ISwfFileDetailsDataModel details;
        private RelayCommand playCommand;
        private RelayCommand analyzeCommand;

        public MainWindowSwfDetailsContentViewModel()
        {
            playCommand = new RelayCommand(() => Debug.WriteLine("File is played!"));
            analyzeCommand = new RelayCommand(() => Debug.WriteLine("File gets analyzed!"));
        }

        public ISwfFileDetailsDataModel Details
        {
            get => details;
            set => SetProperty(ref details, value);
        }

        public ICommand PlayCommand => playCommand;
        public ICommand AnalyzeCommand => analyzeCommand;
        
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
