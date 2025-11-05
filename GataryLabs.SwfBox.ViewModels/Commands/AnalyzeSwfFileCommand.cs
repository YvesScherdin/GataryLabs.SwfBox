using GataryLabs.Mvvm.Services.Abstractions;
using GataryLabs.Mvvm.ViewModels.Commands;
using GataryLabs.SwfBox.Domain.Abstractions;
using GataryLabs.SwfBox.Domain.Abstractions.Models;
using GataryLabs.SwfBox.ViewModels.Abstractions;
using GataryLabs.SwfBox.ViewModels.Abstractions.Commands;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using GataryLabs.SwfBox.ViewModels.Utilities;
using MapsterMapper;
using System;
using System.Threading;

namespace GataryLabs.SwfBox.ViewModels.Commands
{
    internal class AnalyzeSwfFileCommand : Command<ISwfFileDetailsDataModel>, IAnalyzeSwfFileCommand
    {
        private ISwfFileAnalyzer swfFileAnalyzer;
        private IMainWindowContextDataModel contextDataModel;
        private ISessionContext sessionContext;
        private IDialogService dialogService;
        private ILocalizationSource localizationSource;
        private IMapper mapper;

        public AnalyzeSwfFileCommand(
            ISwfFileAnalyzer swfFileAnalyzer,
            IMainWindowContextDataModel contextDataModel,
            ISessionContext sessionContext,
            IDialogService dialogService,
            ILocalizationSource localizationSource,
            IMapper mapper)
        {
            this.swfFileAnalyzer = swfFileAnalyzer;
            this.contextDataModel = contextDataModel;
            this.sessionContext = sessionContext;
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
            SwfAnalysisInfo analysis = Analyze(parameter.Path);
            UpdateLibrary(parameter.Id, analysis);
            UpdateUI(analysis);
        }

        private SwfAnalysisInfo Analyze(string filePath)
        {
            SwfAnalysisInfo analysisInfo = swfFileAnalyzer.AnalyzeSwfFile(filePath);
            AnalysisPropertyInfoUtility.Clusterize(analysisInfo.Tags);
            return analysisInfo;
        }

        private void UpdateLibrary(Guid id, SwfAnalysisInfo analysis)
        {
            SwfFileDetailsInfo detailsInfo = sessionContext.LibraryService.GetSingleFileDetails(id);
            detailsInfo.Analysis = analysis;
            sessionContext.SaveLibraryData(CancellationToken.None);
        }

        private void UpdateUI(SwfAnalysisInfo analysis)
        {
            ISwfAnalysisDataModel analysisDataModel = mapper.Map<ISwfAnalysisDataModel>(analysis);
            contextDataModel.FileDetails.Analysis = analysisDataModel;
        }
    }
}
