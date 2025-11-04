using GataryLabs.Mvvm.ViewModels.Abstractions.DataModels;
using System.Collections.ObjectModel;

namespace GataryLabs.SwfBox.ViewModels.Abstractions.DataModels
{
    public interface IAnalysisPropertyDataModel : IDataModel
    {
        string Name { get; set; }
        object RawValue { get; set; }
        string TooltipText { get; set; }

        ObservableCollection<IAnalysisPropertyDataModel> Children { get; set; }
    }
}
