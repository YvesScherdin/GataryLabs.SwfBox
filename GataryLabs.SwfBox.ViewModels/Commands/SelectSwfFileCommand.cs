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

namespace GataryLabs.SwfBox.ViewModels.Commands
{
    internal class SelectSwfFileCommand : Command<ISwfFileBriefDataModel>, ISelectSwfFileCommand
    {
        private readonly LazyInstance<IMainWindowViewModel> mainWindowViewModelLazy;
        private readonly ISwfFileLibraryService swfFileLibraryService;
        private readonly IMapper mapper;

        public SelectSwfFileCommand(
            LazyInstance<IMainWindowViewModel> mainWindowViewModelLazy,
            ISwfFileLibraryService swfFileLibraryService,
            IMapper mapper)
        {
            this.mainWindowViewModelLazy = mainWindowViewModelLazy;
            this.swfFileLibraryService = swfFileLibraryService;
            this.mapper = mapper;
        }

        public override bool CanExecute(ISwfFileBriefDataModel parameter)
        {
            return mainWindowViewModelLazy.Value.MainContentViewModel == mainWindowViewModelLazy.Value.MainWindowSwfDetailsContentViewModel
                || !mainWindowViewModelLazy.Value.MainWindowSwfDetailsContentViewModel.DisplaysSwf(parameter);
        }

        public override void Execute(ISwfFileBriefDataModel parameter)
        {
            ArgumentValidator.ThrowIfNull(parameter, nameof(parameter));
            ArgumentValidator.ThrowIfGuidEmpty(parameter.Id, nameof(parameter.Id));

            SwfFileDetailsInfo detailsInfo = swfFileLibraryService.GetSingleFileDetails(parameter.Id);
            SwfFileDetailsDataModel detailsDataModel = mapper.Map<SwfFileDetailsDataModel>(detailsInfo);

            IMainWindowSwfDetailsContentViewModel viewModel = mainWindowViewModelLazy.Value.MainWindowSwfDetailsContentViewModel;
            viewModel.Details = detailsDataModel;

            mainWindowViewModelLazy.Value.MainContentViewModel = viewModel;
        }
    }
}
