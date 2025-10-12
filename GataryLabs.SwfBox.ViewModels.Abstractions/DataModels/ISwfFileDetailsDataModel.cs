namespace GataryLabs.SwfBox.ViewModels.Abstractions.DataModels
{
    public interface ISwfFileDetailsDataModel : IDataModel
    {
        string FileName { get; }

        string Path { get; }

        ISwfMetaDataModel MetaData { get; }

        ISwfActivityDataModel Activity { get; }

        ISwfAnalysisDataModel Analysis { get; }
    }
}
