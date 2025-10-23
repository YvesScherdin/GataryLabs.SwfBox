using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GataryLabs.SwfBox.ViewModels.Abstractions;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;

namespace GataryLabs.SwfBox.ViewModels
{
    internal class MainWindowSwfDetailsContentViewModel : ObservableObject, IMainWindowSwfDetailsContentViewModel
    {
        private ISwfFileDetailsDataModel details;
        private IMainWindowContextDataModel contextData;
        private RelayCommand playCommand;
        private RelayCommand analyzeCommand;

        public MainWindowSwfDetailsContentViewModel(IMainWindowContextDataModel contextData)
        {
            this.contextData = contextData;

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
            Details = contextData.FileDetails;
            contextData.PropertyChanged += ContextData_PropertyChanged;
        }

        public void OnUnloaded()
        {
            contextData.SelectedSwfFileItem = null;
            Details = null;

            contextData.PropertyChanged -= ContextData_PropertyChanged;
        }

        private void ContextData_PropertyChanged(object sender, PropertyChangedEventArgs eventArguments)
        {
            switch (eventArguments.PropertyName)
            {
                case nameof(contextData.FileDetails):
                    Details = contextData.FileDetails;
                    break;
            }
        }
    }
}
