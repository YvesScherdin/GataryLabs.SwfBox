using GataryLabs.Mvvm.ViewModels.Abstractions.DataModels;

namespace GataryLabs.SwfBox.ViewModels.Abstractions.DataModels
{
    public interface IPropertyTreeNodeDataModel : IDataModel
    {
        string Name { get; set; }
        object RawValue { get; set; }
        string TooltipText { get; set; }
    }
}
