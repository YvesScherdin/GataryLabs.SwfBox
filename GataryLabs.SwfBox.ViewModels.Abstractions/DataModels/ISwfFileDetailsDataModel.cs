namespace GataryLabs.SwfBox.ViewModels.Abstractions.DataModels
{
    public interface ISwfFileDetailsDataModel : IDataModel
    {
        string FileName { get; }

        string Path { get; }

        ISwfActivityDataModel Activity { get; }

        ISwfMetaDataModel MetaData { get; }

        ISwfAnalysisDataModel Analysis { get; }
    }
}
