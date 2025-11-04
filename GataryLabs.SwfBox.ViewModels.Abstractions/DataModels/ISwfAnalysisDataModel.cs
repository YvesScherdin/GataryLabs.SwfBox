using GataryLabs.Mvvm.ViewModels.Abstractions.DataModels;
using System.Collections.ObjectModel;

namespace GataryLabs.SwfBox.ViewModels.Abstractions.DataModels
{
    public interface ISwfAnalysisDataModel : IDataModel
    {
        ObservableCollection<IAnalysisPropertyDataModel> Properties { get; set; }
    }
}
