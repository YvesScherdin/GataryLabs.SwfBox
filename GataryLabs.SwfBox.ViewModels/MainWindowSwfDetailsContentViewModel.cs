using CommunityToolkit.Mvvm.ComponentModel;
using GataryLabs.Mvvm.ViewModels.Utils;
using GataryLabs.SwfBox.ViewModels.Abstractions;
using GataryLabs.SwfBox.ViewModels.Abstractions.Commands;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using GataryLabs.SwfBox.ViewModels.DataModel;
using Mapster;
using System.ComponentModel;

namespace GataryLabs.SwfBox.ViewModels
{
    internal class MainWindowSwfDetailsContentViewModel : ObservableObject, IMainWindowSwfDetailsContentViewModel
    {
        private readonly IMainWindowContextDataModel contextData;
        private readonly IPlaySwfFileCommand playCommand;
        private readonly IAnalyzeSwfFileCommand analyzeCommand;
        private readonly LazyInstance<ISaveMetaDataCommand> saveMetaDataCommandLazy;
        private readonly IExploreCommand exploreCommand;

        private ISwfFileDetailsDataModel details;
        private ISwfMetaDataModel editableMetaData;
        private string selectedAnalysisDataPath;

        public MainWindowSwfDetailsContentViewModel(
            IMainWindowContextDataModel contextData,
            IAnalyzeSwfFileCommand analyzeCommand,
            LazyInstance<ISaveMetaDataCommand> saveMetaDataCommandLazy,
            IExploreCommand exploreCommand,
            IPlaySwfFileCommand playCommand)
        {
            this.contextData = contextData;
            this.analyzeCommand = analyzeCommand;
            this.saveMetaDataCommandLazy = saveMetaDataCommandLazy;
            this.exploreCommand = exploreCommand;
            this.playCommand = playCommand;
        }

        public ISwfFileDetailsDataModel Details
        {
            get => details;
            set => SetProperty(ref details, value);
        }
        
        public ISwfMetaDataModel EditableMetaData
        {
            get => editableMetaData;
            set => SetProperty(ref editableMetaData, value);
        }
        
        public string SelectedAnalysisDataPath
        {
            get => selectedAnalysisDataPath;
            set => SetProperty(ref selectedAnalysisDataPath, value);
        }

        public IPlaySwfFileCommand PlayCommand => playCommand;
        public IAnalyzeSwfFileCommand AnalyzeCommand => analyzeCommand;
        public ISaveMetaDataCommand SaveMetaDataCommand => saveMetaDataCommandLazy.Value;
        public IExploreCommand ExploreCommand => exploreCommand;
        
        public void OnLoaded()
        {
            AdjustDetails();
            
            contextData.PropertyChanged += ContextData_PropertyChanged;
            editableMetaData.PropertyChanged += EditableMetaData_PropertyChanged;
        }

        public void OnUnloaded()
        {
            contextData.SelectedSwfFileItem = null;
            Details = null;

            contextData.PropertyChanged -= ContextData_PropertyChanged;
            editableMetaData.PropertyChanged -= EditableMetaData_PropertyChanged;
        }

        private void AdjustDetails()
        {
            Details = contextData.FileDetails;

            ISwfMetaDataModel newEditableMetaData = new SwfMetaDataModel();
            contextData?.FileDetails?.MetaData?.Adapt(newEditableMetaData);

            EditableMetaData = newEditableMetaData;
            UpdateBackgroundImage();
        }

        private void UpdateBackgroundImage()
        {
            contextData.BackgroundImage = contextData.FileDetails.MetaData.Image;
        }

        private void ContextData_PropertyChanged(object sender, PropertyChangedEventArgs eventArguments)
        {
            switch (eventArguments.PropertyName)
            {
                case nameof(contextData.FileDetails):
                    AdjustDetails();
                    break;
            }
        }

        private void EditableMetaData_PropertyChanged(object sender, PropertyChangedEventArgs eventArguments)
        {
            switch (eventArguments.PropertyName)
            {
                case nameof(editableMetaData.Image):
                    UpdateBackgroundImage();
                    break;
            }
        }
    }
}
