using GataryLabs.Mvvm.ViewModels.Abstractions.DataModels;
using System;

namespace GataryLabs.SwfBox.ViewModels.Abstractions.DataModels
{
    public interface ISwfFileDetailsDataModel : IDataModel
    {
        Guid Id { get; }

        string FileName { get; }

        string Path { get; }

        ISwfMetaDataModel MetaData { get; }

        ISwfActivityDataModel Activity { get; }

        ISwfAnalysisDataModel Analysis { get; }
    }
}
