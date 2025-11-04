using GataryLabs.Mvvm.Services.Abstractions;
using GataryLabs.Mvvm.ViewModels.Commands;
using GataryLabs.SwfBox.Domain.Abstractions;
using GataryLabs.SwfBox.Domain.Abstractions.Models;
using GataryLabs.SwfBox.ViewModels.Abstractions;
using GataryLabs.SwfBox.ViewModels.Abstractions.Commands;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using MapsterMapper;
using System.Collections.Generic;

namespace GataryLabs.SwfBox.ViewModels.Commands
{
    internal class AnalyzeSwfFileCommand : Command<ISwfFileDetailsDataModel>, IAnalyzeSwfFileCommand
    {
        private ISwfFileAnalyzer swfFileAnalyzer;
        private IMainWindowContextDataModel contextDataModel;
        private IDialogService dialogService;
        private ILocalizationSource localizationSource;
        private IMapper mapper;

        public AnalyzeSwfFileCommand(
            ISwfFileAnalyzer swfFileAnalyzer,
            IMainWindowContextDataModel contextDataModel,
            IDialogService dialogService,
            ILocalizationSource localizationSource,
            IMapper mapper)
        {
            this.swfFileAnalyzer = swfFileAnalyzer;
            this.contextDataModel = contextDataModel;
            this.dialogService = dialogService;
            this.localizationSource = localizationSource;
            this.mapper = mapper;
        }

        public override bool CanExecute(ISwfFileDetailsDataModel parameter)
        {
            return true;
        }

        public override void Execute(ISwfFileDetailsDataModel parameter)
        {
            SwfAnalysisInfo result = swfFileAnalyzer.AnalyzeSwfFile(parameter.Path);

            Clusterize(result.Tags);

            ISwfAnalysisDataModel analysisDataModel = mapper.Map<ISwfAnalysisDataModel>(result);

            contextDataModel.FileDetails.Analysis = analysisDataModel;
        }

        private void Clusterize(List<AnalysisPropertyInfo> tags)
        {
            const int minGroupSize = 3;
            int index = 0;
            int groupStartIndex = -1;
            string lastName = null;

            while (index < tags.Count)
            {
                AnalysisPropertyInfo currentTagProperty = tags[index];

                if (currentTagProperty.Name == lastName && !string.IsNullOrEmpty(lastName))
                {
                    if (groupStartIndex == -1)
                        groupStartIndex = index - 1;
                }
                else if (groupStartIndex != -1)
                {
                    if ((index - groupStartIndex) >= minGroupSize)
                    {
                        int count = index - groupStartIndex;

                        List<AnalysisPropertyInfo> newSubNodes = tags.GetRange(groupStartIndex, count);
                        tags.RemoveRange(groupStartIndex, count);
                        index -= count;

                        AnalysisPropertyInfo groupNode = new AnalysisPropertyInfo
                        {
                            Name = $"{lastName} ({newSubNodes.Count})",
                            Description = "Aggregated content",
                            Properties = newSubNodes
                        };

                        tags.Insert(groupStartIndex, groupNode);
                        currentTagProperty = groupNode;
                    }

                    groupStartIndex = -1;
                }

                index++;
                lastName = currentTagProperty.Name;
            }
        }
    }
}
