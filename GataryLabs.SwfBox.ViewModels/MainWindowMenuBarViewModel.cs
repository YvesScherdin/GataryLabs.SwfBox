using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GataryLabs.SwfBox.ViewModels.Abstractions;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using GataryLabs.SwfBox.ViewModels.DataModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;

namespace GataryLabs.SwfBox.ViewModels
{
    internal class MainWindowMenuBarViewModel : ObservableObject, IMainWindowMenuBarViewModel
    {
        private RelayCommand openOverviewCommand;
        private RelayCommand openSettingsCommand;
        private RelayCommand selectSwfFileCommand;
        private IList<ISwfFileBriefDataModel> recentSwfFiles;

        public MainWindowMenuBarViewModel()
        {
            openOverviewCommand = new RelayCommand(() => Debug.WriteLine("Open overview!"));
            openSettingsCommand = new RelayCommand(() => Debug.WriteLine("Open settings!"), () => false);
            selectSwfFileCommand = new RelayCommand(() => Debug.WriteLine("Select swf!"));
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
                    Image = null,
                    Path = "path/to/SomeFile.swf"
                }
            };
        }

        public void OnUnloaded()
        {

        }
    }
}
