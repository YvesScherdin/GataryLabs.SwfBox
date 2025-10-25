using GataryLabs.SwfBox.Configuration.Abstractions;
using GataryLabs.SwfBox.Domain.Abstractions.Models;
using System;
using System.Collections.Generic;

namespace GataryLabs.SwfBox.Domain.Abstractions
{
    /// <summary>
    /// A library that manages detailed information about SWF files.
    /// </summary>
    public interface ISwfFileLibraryService
    {
        bool HasFileWithPath(string path);
        SwfFileDetailsInfo Load(string path);
        SwfFileDetailsInfo[] ScanFolder(string path, ScanFolderOptions options);
        void RegisterFile(SwfFileDetailsInfo info);
        void UnregisterFile(SwfFileDetailsInfo info);
        SwfFileDetailsInfo GetSingleFileDetails(Guid id);
        IList<SwfFileDetailsInfo> GetManyFileDetails(IList<Guid> ids);
    }
}
