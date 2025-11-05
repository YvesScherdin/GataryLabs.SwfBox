using CommunityToolkit.Mvvm.ComponentModel;
using GataryLabs.SwfBox.ViewModels.Abstractions;
using GataryLabs.SwfBox.ViewModels.Abstractions.Commands;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using System.ComponentModel;

namespace GataryLabs.SwfBox.ViewModels
{
    internal class MainWindowSwfDetailsContentViewModel : ObservableObject, IMainWindowSwfDetailsContentViewModel
    {
        private ISwfFileDetailsDataModel details;
        private readonly IMainWindowContextDataModel contextData;
        private readonly IPlaySwfFileCommand playCommand;
        private readonly IAnalyzeSwfFileCommand analyzeCommand;
        private readonly IExploreCommand exploreCommand;

        private string selectedAnalysisDataPath;

        public MainWindowSwfDetailsContentViewModel(
            IMainWindowContextDataModel contextData,
            IAnalyzeSwfFileCommand analyzeCommand,
            IExploreCommand exploreCommand,
            IPlaySwfFileCommand playCommand)
        {
            this.contextData = contextData;
            this.analyzeCommand = analyzeCommand;
            this.exploreCommand = exploreCommand;
            this.playCommand = playCommand;
        }

        public ISwfFileDetailsDataModel Details
        {
            get => details;
            set => SetProperty(ref details, value);
        }
        
        public string SelectedAnalysisDataPath
        {
            get => selectedAnalysisDataPath;
            set => SetProperty(ref selectedAnalysisDataPath, value);
        }

        public IPlaySwfFileCommand PlayCommand => playCommand;

        public IAnalyzeSwfFileCommand AnalyzeCommand => analyzeCommand;

        public IExploreCommand ExploreCommand => exploreCommand;
        
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
