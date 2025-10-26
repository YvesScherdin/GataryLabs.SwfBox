using GataryLabs.SwfBox.Domain.Abstractions;
using GataryLabs.SwfBox.Domain.Abstractions.Models;
using GataryLabs.SwfBox.Infrastructure;
using GataryLabs.SwfBox.ViewModels.Abstractions;
using GataryLabs.SwfBox.ViewModels.Abstractions.Commands;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using GataryLabs.SwfBox.ViewModels.DataModel;
using GataryLabs.SwfBox.ViewModels.Extensions;
using GataryLabs.SwfBox.ViewModels.Utils;
using MapsterMapper;
using Microsoft.Extensions.Logging;

namespace GataryLabs.SwfBox.ViewModels.Commands
{
    internal class SelectSwfFileCommand : Command<ISwfFileBriefDataModel>, ISelectSwfFileCommand
    {
        private readonly LazyInstance<IMainWindowContentNavigator> mainContentNavigatorLazy;
        private readonly IMainWindowContextDataModel contextDataModel;
        private readonly ISwfFileLibraryService swfFileLibraryService;
        private readonly ILogger<SelectSwfFileCommand> logger;
        private readonly IMapper mapper;

        public SelectSwfFileCommand(
            LazyInstance<IMainWindowContentNavigator> mainContentNavigatorLazy,
            IMainWindowContextDataModel contextDataModel,
            ISwfFileLibraryService swfFileLibraryService,
            ILogger<SelectSwfFileCommand> logger,
            IMapper mapper
            )
        {
            this.mainContentNavigatorLazy = mainContentNavigatorLazy;
            this.contextDataModel = contextDataModel;
            this.swfFileLibraryService = swfFileLibraryService;
            this.logger = logger;
            this.mapper = mapper;
        }

        public override bool CanExecute(ISwfFileBriefDataModel parameter)
        {
            return mainContentNavigatorLazy.Value.ContentViewModel == mainContentNavigatorLazy.Value.SwfDetailsContentViewModel
                || !mainContentNavigatorLazy.Value.SwfDetailsContentViewModel.DisplaysSwf(parameter);
        }

        public override void Execute(ISwfFileBriefDataModel parameter)
        {
            logger.LogTrace("Execute {@fileTitle}", parameter?.Title);

            ArgumentValidator.ThrowIfNull(parameter, nameof(parameter));
            ArgumentValidator.ThrowIfGuidEmpty(parameter.Id, nameof(parameter.Id));

            SwfFileDetailsInfo detailsInfo = swfFileLibraryService.GetSingleFileDetails(parameter.Id);
            SwfFileDetailsDataModel detailsDataModel = mapper.Map<SwfFileDetailsDataModel>(detailsInfo);

            contextDataModel.FileDetails = detailsDataModel;
            mainContentNavigatorLazy.Value.ContentViewModel = mainContentNavigatorLazy.Value.SwfDetailsContentViewModel;
        }
    }
}
