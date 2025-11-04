using CommunityToolkit.Mvvm.ComponentModel;
using GataryLabs.SwfBox.ViewModels.Abstractions;
using GataryLabs.SwfBox.ViewModels.Abstractions.Commands;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using GataryLabs.SwfBox.ViewModels.DataModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace GataryLabs.SwfBox.ViewModels
{
    internal class MainWindowSwfDetailsContentViewModel : ObservableObject, IMainWindowSwfDetailsContentViewModel
    {
        private ISwfFileDetailsDataModel details;
        private IMainWindowContextDataModel contextData;
        private IPlaySwfFileCommand playCommand;
        private IAnalyzeSwfFileCommand analyzeCommand;

        public MainWindowSwfDetailsContentViewModel(
            IMainWindowContextDataModel contextData,
            IAnalyzeSwfFileCommand analyzeCommand,
            IPlaySwfFileCommand playCommand)
        {
            this.contextData = contextData;
            this.analyzeCommand = analyzeCommand;
            this.playCommand = playCommand;
        }

        public ISwfFileDetailsDataModel Details
        {
            get => details;
            set => SetProperty(ref details, value);
        }

        public IPlaySwfFileCommand PlayCommand => playCommand;

        public IAnalyzeSwfFileCommand AnalyzeCommand => analyzeCommand;
        
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

        private ObservableCollection<IAnalysisPropertyDataModel> CreateAnalysisResultPropertiesForTesting()
        {
            ObservableCollection<IAnalysisPropertyDataModel> resultProperties = new ObservableCollection<IAnalysisPropertyDataModel>
            (
                new List<IAnalysisPropertyDataModel>
                {
                    new AnalysisPropertyDataModel
                    {
                        Name="Okato", RawValue=42, TooltipText="???",
                        Children = new ObservableCollection<IAnalysisPropertyDataModel>(new List<IAnalysisPropertyDataModel>
                        {
                            new AnalysisPropertyDataModel
                            {
                                Name="Okato's 1st son", RawValue=23, TooltipText="??? ???"
                            },
                            new AnalysisPropertyDataModel
                            {
                                Name="Okato's 2nd son", RawValue=14, TooltipText="??? ???"
                            }
                        })
                    }

                }
            );

            return resultProperties;
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
