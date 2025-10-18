using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GataryLabs.SwfBox.ViewModels.Abstractions;
using GataryLabs.SwfBox.ViewModels.Abstractions.Commands;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using System.Diagnostics;
using System.Windows.Input;

namespace GataryLabs.SwfBox.ViewModels
{
    internal class MainWindowOverviewContentViewModel : ObservableObject, IMainWindowOverviewContentViewModel
    {
        private RelayCommand pickNewSwfCommand;
        private RelayCommand scanDirectoryCommand;
        private ISelectSwfFileCommand selectSwfFileCommand;
        private IRecentSwfFileLibraryDataModel recentSwfFiles;

        public MainWindowOverviewContentViewModel(
            IRecentSwfFileLibraryDataModel recentSwfFiles,
            ISelectSwfFileCommand selectSwfFileCommand)
        {
            this.recentSwfFiles = recentSwfFiles;
            this.selectSwfFileCommand = selectSwfFileCommand;

            pickNewSwfCommand = new RelayCommand(() => Debug.WriteLine("Pick!"));
            scanDirectoryCommand = new RelayCommand(() => Debug.WriteLine("Scan!"));
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
