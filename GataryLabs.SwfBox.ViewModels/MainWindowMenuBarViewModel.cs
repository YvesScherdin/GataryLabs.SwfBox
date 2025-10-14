using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GataryLabs.SwfBox.ViewModels.Abstractions;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using GataryLabs.SwfBox.ViewModels.Constants;
using GataryLabs.SwfBox.ViewModels.DataModel;
using GataryLabs.SwfBox.ViewModels.Utils;
using System;
using System.Collections.Generic;
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
        private IList<ISwfFileBriefDataModel> recentSwfFiles;

        public MainWindowMenuBarViewModel(
            LazyInstance<IMainWindowViewModel> mainWindowViewModelLazy)
        {
            this.mainWindowViewModelLazy = mainWindowViewModelLazy;

            openOverviewCommand = new RelayCommand(ExecuteOpenOverviewCommand);
            openSettingsCommand = new RelayCommand(() => Debug.WriteLine("Open settings!"), () => false);
            selectSwfFileCommand = new RelayCommand(() => Debug.WriteLine("Select swf!"));
        }

        private void ExecuteOpenOverviewCommand()
        {
            mainWindowViewModelLazy.Value.MainContentViewModel = mainWindowViewModelLazy.Value.MainWindowSwfDetailsContentViewModel;
        }

        public ICommand OpenOverviewCommand => openOverviewCommand;
        public ICommand OpenSettingsCommand => openSettingsCommand;
        public ICommand SelectSwfFileCommand => selectSwfFileCommand;

        public IList<ISwfFileBriefDataModel> RecentSwfFiles
        {
            get => recentSwfFiles;
            private set => SetProperty(ref recentSwfFiles, value);
        }

        public void OnLoaded()
        {
            RecentSwfFiles = new List<ISwfFileBriefDataModel>
            {
                new SwfFileBriefDataModel
                {
                    Id = Guid.NewGuid(),
                    Title = "SomeFile.swf",
                    Description = "Blah",
                    Image = FallbackFilePathes.SwfDefaultIconSmall,
                    Path = "path/to/SomeFile.swf"
                },
                new SwfFileBriefDataModel
                {
                    Id = Guid.NewGuid(),
                    Title = "SomeFile1.swf",
                    Description = "Blah",
                    Image = FallbackFilePathes.SwfDefaultIconSmall,
                    Path = "path/to/SomeFile1.swf"
                },
                new SwfFileBriefDataModel
                {
                    Id = Guid.NewGuid(),
                    Title = "SomeFile1.swf",
                    Description = "Blah",
                    Image = FallbackFilePathes.SwfDefaultIconSmall,
                    Path = "path/to/SomeFile1.swf"
                },
                new SwfFileBriefDataModel
                {
                    Id = Guid.NewGuid(),
                    Title = "SomeFile1.swf",
                    Description = "Blah",
                    Image = FallbackFilePathes.SwfDefaultIconSmall,
                    Path = "path/to/SomeFile1.swf"
                },
                new SwfFileBriefDataModel
                {
                    Id = Guid.NewGuid(),
                    Title = "SomeFile1.swf",
                    Description = "Blah",
                    Image = FallbackFilePathes.SwfDefaultIconSmall,
                    Path = "path/to/SomeFile1.swf"
                },
                new SwfFileBriefDataModel
                {
                    Id = Guid.NewGuid(),
                    Title = "SomeFile1.swf",
                    Description = "Blah",
                    Image = FallbackFilePathes.SwfDefaultIconSmall,
                    Path = "path/to/SomeFile1.swf"
                },
                new SwfFileBriefDataModel
                {
                    Id = Guid.NewGuid(),
                    Title = "SomeFile1.swf",
                    Description = "Blah",
                    Image = FallbackFilePathes.SwfDefaultIconSmall,
                    Path = "path/to/SomeFile1.swf"
                },
                new SwfFileBriefDataModel
                {
                    Id = Guid.NewGuid(),
                    Title = "SomeFile1.swf",
                    Description = "Blah",
                    Image = FallbackFilePathes.SwfDefaultIconSmall,
                    Path = "path/to/SomeFile1.swf"
                }
            };
        }

        public void OnUnloaded()
        {

        }
    }
}
