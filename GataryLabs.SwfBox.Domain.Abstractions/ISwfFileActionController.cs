using GataryLabs.SwfBox.Domain.Abstractions.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GataryLabs.SwfBox.Domain.Abstractions
{
    /// <summary>
    /// Provides actions with <see cref="SwfFileDetailsInfo"/>-typed objects.
    /// These actions may modify the details.
    /// </summary>
    public interface ISwfFileActionController
    {
        //void Analyze(SwfFileDetailsInfo info);

        Task UpdateMetaDataAsync(Guid id, SwfMetaDataInfo metaData, CancellationToken cancellationToken);
        void Play(Guid id);
    }
}
