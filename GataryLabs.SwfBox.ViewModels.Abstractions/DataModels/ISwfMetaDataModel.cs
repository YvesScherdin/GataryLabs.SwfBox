namespace GataryLabs.SwfBox.ViewModels.Abstractions.DataModels
{
    public interface ISwfMetaDataModel : IDataModel
    {
        string Format { get; }

        string Version { get; }

        uint FileLength { get; }
    }
}
