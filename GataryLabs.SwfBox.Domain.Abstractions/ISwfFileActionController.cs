using GataryLabs.SwfBox.Domain.Abstractions.Models;
using System;

namespace GataryLabs.SwfBox.Domain.Abstractions
{
    /// <summary>
    /// Provides actions with <see cref="SwfFileDetailsInfo"/>-typed objects.
    /// These actions may modify the details.
    /// </summary>
    public interface ISwfFileActionController
    {
        void Analyze(SwfFileDetailsInfo info);
        void EditMetaData(Guid id, SwfMetaDataInfo delta);
        void Play(Guid id);
    }
}
