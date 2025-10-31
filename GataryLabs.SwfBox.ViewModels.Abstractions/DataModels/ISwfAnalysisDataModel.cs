using GataryLabs.Mvvm.ViewModels.Abstractions.DataModels;

namespace GataryLabs.SwfBox.ViewModels.Abstractions.DataModels
{
    public interface ISwfAnalysisDataModel : IDataModel
    {
        string Format { get; }

        string Version { get; }

        uint FileLength { get; }
    }
}
