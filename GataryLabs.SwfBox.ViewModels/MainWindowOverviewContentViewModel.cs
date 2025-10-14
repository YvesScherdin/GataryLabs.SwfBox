using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GataryLabs.SwfBox.ViewModels.Abstractions;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using System.Diagnostics;
using System.Windows.Input;

namespace GataryLabs.SwfBox.ViewModels
{
    internal class MainWindowOverviewContentViewModel : ObservableObject, IMainWindowOverviewContentViewModel
    {
        private RelayCommand pickNewSwfCommand;
        private RelayCommand scanDirectoryCommand;
        private RelayCommand selectSwfFileCommand;
        private IRecentSwfFileLibraryDataModel recentSwfFiles;

        public MainWindowOverviewContentViewModel(IRecentSwfFileLibraryDataModel recentSwfFiles)
        {
            this.recentSwfFiles = recentSwfFiles;

            pickNewSwfCommand = new RelayCommand(() => Debug.WriteLine("Pick!"));
            scanDirectoryCommand = new RelayCommand(() => Debug.WriteLine("Scan!"));
            selectSwfFileCommand = new RelayCommand(() => Debug.WriteLine("Select swf!"));
        }

        public ICommand PickNewSwfCommand => pickNewSwfCommand;
        public ICommand ScanDirectoryCommand => scanDirectoryCommand;
        public ICommand SelectSwfFileCommand => selectSwfFileCommand;

        public IRecentSwfFileLibraryDataModel RecentSwfFiles
        {
            get => recentSwfFiles;
            private set => SetProperty(ref recentSwfFiles, value);
        }

        public void OnLoaded()
        {
        }

        public void OnUnloaded()
        {
        }
    }
}
