using GataryLabs.Mvvm.Services.Abstractions;
using GataryLabs.Mvvm.ViewModels.Commands;
using GataryLabs.SwfBox.Domain.Abstractions;
using GataryLabs.SwfBox.Domain.Abstractions.Models;
using GataryLabs.SwfBox.ViewModels.Abstractions;
using GataryLabs.SwfBox.ViewModels.Abstractions.Commands;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using MapsterMapper;
using System;
using System.Threading;

namespace GataryLabs.SwfBox.ViewModels.Commands
{
    internal class SaveMetaDataCommand : Command, ISaveMetaDataCommand
    {
        private IMainWindowSwfDetailsContentViewModel swfDetailsContentViewModel;
        private ISwfFileActionController actionController;
        private IDialogService dialogService;
        private ILocalizationSource localizationSource;
        private IMapper mapper;

        public SaveMetaDataCommand(
            IMainWindowSwfDetailsContentViewModel swfDetailsContentViewModel,
            ISwfFileActionController actionController,
            IDialogService dialogService,
            ILocalizationSource localizationSource,
            IMapper mapper)
        {
            this.swfDetailsContentViewModel = swfDetailsContentViewModel;
            this.actionController = actionController;
            this.dialogService = dialogService;
            this.localizationSource = localizationSource;
            this.mapper = mapper;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            Guid guid = swfDetailsContentViewModel.Details.Id;
            ISwfMetaDataModel currentDataModel = swfDetailsContentViewModel.Details.MetaData;

            mapper.Map(swfDetailsContentViewModel.EditableMetaData, currentDataModel);

            SwfMetaDataInfo metaDataInfo = mapper.Map<SwfMetaDataInfo>(currentDataModel);

            actionController.UpdateMetaDataAsync(guid, metaDataInfo, CancellationToken.None)
                .GetAwaiter()
                .GetResult();
        }
    }
}
