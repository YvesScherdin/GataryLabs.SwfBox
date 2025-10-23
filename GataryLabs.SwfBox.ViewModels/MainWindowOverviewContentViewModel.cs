using CommunityToolkit.Mvvm.ComponentModel;
using GataryLabs.SwfBox.ViewModels.Abstractions;
using GataryLabs.SwfBox.ViewModels.Abstractions.Commands;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using System.Windows.Input;

namespace GataryLabs.SwfBox.ViewModels
{
    internal class MainWindowOverviewContentViewModel : ObservableObject, IMainWindowOverviewContentViewModel
    {
        private IPickNewSwfFileCommand pickNewSwfFileCommand;
        private IScanDirectoryForSwfsCommand scanDirectoryCommand;
        private ISelectSwfFileCommand selectSwfFileCommand;
        private IRecentSwfFileLibraryDataModel recentSwfFiles;

        public MainWindowOverviewContentViewModel(
            IRecentSwfFileLibraryDataModel recentSwfFiles,
            IPickNewSwfFileCommand pickNewSwfFileCommand,
            IScanDirectoryForSwfsCommand scanDirectoryForSwfsCommand,
            ISelectSwfFileCommand selectSwfFileCommand)
        {
            this.recentSwfFiles = recentSwfFiles;
            this.scanDirectoryCommand = scanDirectoryForSwfsCommand;
            this.pickNewSwfFileCommand = pickNewSwfFileCommand;
            this.selectSwfFileCommand = selectSwfFileCommand;
        }

        public ICommand PickNewSwfFileCommand => pickNewSwfFileCommand;
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
