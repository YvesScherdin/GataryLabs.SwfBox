using GataryLabs.SwfBox.Domain.Abstractions;
using GataryLabs.SwfBox.Domain.Abstractions.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GataryLabs.SwfBox.Domain
{
    internal class SwfFileActionController : ISwfFileActionController
    {
        private ISwfFileLibraryService libraryService;
        private ISessionContext sessionContext;

        public SwfFileActionController(ISwfFileLibraryService libraryService, ISessionContext sessionContext)
        {
            this.libraryService = libraryService;
            this.sessionContext = sessionContext;
        }

        public void Play(Guid id)
        {
        }

        public async Task UpdateMetaDataAsync(Guid id, SwfMetaDataInfo metaData, CancellationToken cancellationToken)
        {
            SwfFileDetailsInfo details = libraryService.GetSingleFileDetails(id);

            details.MetaData = metaData;

            await sessionContext.SaveLibraryData(cancellationToken);
        }
    }
}
