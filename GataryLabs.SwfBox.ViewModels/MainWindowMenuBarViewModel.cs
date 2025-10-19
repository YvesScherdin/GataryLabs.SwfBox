using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GataryLabs.SwfBox.ViewModels.Abstractions;
using GataryLabs.SwfBox.ViewModels.Abstractions.Commands;
using GataryLabs.SwfBox.ViewModels.Utils;
using System.ComponentModel;
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
        private IMainWindowContextDataModel contextData;

        public MainWindowMenuBarViewModel(
            LazyInstance<IMainWindowViewModel> mainWindowViewModelLazy,
            ISelectSwfFileCommand selectSwfFileCommand,
            IMainWindowContextDataModel contextData)
        {
            this.mainWindowViewModelLazy = mainWindowViewModelLazy;
            this.selectSwfFileCommand = selectSwfFileCommand;
            this.contextData = contextData;

            openOverviewCommand = new RelayCommand(ExecuteOpenOverviewCommand);
            openSettingsCommand = new RelayCommand(() => Debug.WriteLine("Open settings!"), () => false);
        }

        public ICommand OpenOverviewCommand => openOverviewCommand;
        public ICommand OpenSettingsCommand => openSettingsCommand;
        public ISelectSwfFileCommand SelectSwfFileCommand => selectSwfFileCommand;
        public IMainWindowContextDataModel ContextData => contextData;

        public void OnLoaded()
        {
            contextData.PropertyChanged += ContextData_PropertyChanged;
        }

        public void OnUnloaded()
        {
            contextData.PropertyChanged -= ContextData_PropertyChanged;
        }

        private void ExecuteOpenOverviewCommand()
        {
            mainWindowViewModelLazy.Value.MainContentViewModel = mainWindowViewModelLazy.Value.MainWindowOverviewContentViewModel;
        }

        private void ContextData_PropertyChanged(object sender, PropertyChangedEventArgs arguments)
        {
            switch (arguments.PropertyName)
            {
                case nameof(ContextData.SelectedSwfFileItem):
                    if (ContextData.SelectedSwfFileItem == null)
                        return;

                    if (selectSwfFileCommand.CanExecute(ContextData.SelectedSwfFileItem))
                        selectSwfFileCommand.Execute(ContextData.SelectedSwfFileItem);
                    break;
            }
        }
    }
}
