using GataryLabs.Mvvm.Services.Abstractions;
using GataryLabs.Mvvm.ViewModels.Commands;
using GataryLabs.SwfBox.Domain.Abstractions;
using GataryLabs.SwfBox.ViewModels.Abstractions.Commands;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using MapsterMapper;

namespace GataryLabs.SwfBox.ViewModels.Commands
{
    internal class PlaySwfFileCommand : Command<ISwfFileDetailsDataModel>, IPlaySwfFileCommand
    {
        private ISwfFileAnalyzer swfFileAnalyzer;
        private IDialogService dialogService;
        private ILocalizationSource localizationSource;
        private IMapper mapper;

        public PlaySwfFileCommand(
            IDialogService dialogService,
            ILocalizationSource localizationSource,
            IMapper mapper)
        {
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
        }
    }
}
