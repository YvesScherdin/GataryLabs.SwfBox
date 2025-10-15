using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GataryLabs.SwfBox.ViewModels.Abstractions;
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
        private RelayCommand selectSwfFileCommand;
        private IRecentSwfFileLibraryDataModel recentSwfFiles;

        public MainWindowMenuBarViewModel(
            LazyInstance<IMainWindowViewModel> mainWindowViewModelLazy,
            IRecentSwfFileLibraryDataModel recentSwfFiles)
        {
            this.mainWindowViewModelLazy = mainWindowViewModelLazy;
            this.recentSwfFiles = recentSwfFiles;

            openOverviewCommand = new RelayCommand(ExecuteOpenOverviewCommand);
            openSettingsCommand = new RelayCommand(() => Debug.WriteLine("Open settings!"), () => false);
            selectSwfFileCommand = new RelayCommand(() => Debug.WriteLine("Select swf!"));
        }

        public ICommand OpenOverviewCommand => openOverviewCommand;
        public ICommand OpenSettingsCommand => openSettingsCommand;
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

        private void ExecuteOpenOverviewCommand()
        {
            mainWindowViewModelLazy.Value.MainContentViewModel = mainWindowViewModelLazy.Value.MainWindowOverviewContentViewModel;
        }
    }
}
