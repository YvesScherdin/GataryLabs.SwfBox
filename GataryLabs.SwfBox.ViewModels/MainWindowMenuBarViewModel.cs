using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GataryLabs.SwfBox.ViewModels.Abstractions;
using GataryLabs.SwfBox.ViewModels.Abstractions.Commands;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using GataryLabs.SwfBox.ViewModels.Utils;
using System.Diagnostics;
using System.Windows.Input;

namespace GataryLabs.SwfBox.ViewModels
{
    internal class MainWindowMenuBarViewModel : ObservableObject, IMainWindowMenuBarViewModel
    {
        private LazyInstance<IMainWindowViewModel> mainWindowViewModelLazy;

        private RelayCommand openOverviewCommand;
        private RelayCommand openSettingsCommand;
        private ISelectSwfFileCommand selectSwfFileCommand;

        private IRecentSwfFileLibraryDataModel recentSwfFiles;

        public MainWindowMenuBarViewModel(
            LazyInstance<IMainWindowViewModel> mainWindowViewModelLazy,
            ISelectSwfFileCommand selectSwfFileCommand,
            IRecentSwfFileLibraryDataModel recentSwfFiles)
        {
            this.mainWindowViewModelLazy = mainWindowViewModelLazy;
            this.selectSwfFileCommand = selectSwfFileCommand;
            this.recentSwfFiles = recentSwfFiles;

            openOverviewCommand = new RelayCommand(ExecuteOpenOverviewCommand);
            openSettingsCommand = new RelayCommand(() => Debug.WriteLine("Open settings!"), () => false);
        }

        public ICommand OpenOverviewCommand => openOverviewCommand;
        public ICommand OpenSettingsCommand => openSettingsCommand;
        public ISelectSwfFileCommand SelectSwfFileCommand => selectSwfFileCommand;

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

        private void ExecuteOpenOverviewCommand()
        {
            mainWindowViewModelLazy.Value.MainContentViewModel = mainWindowViewModelLazy.Value.MainWindowOverviewContentViewModel;
        }
    }
}
