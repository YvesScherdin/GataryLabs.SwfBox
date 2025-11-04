using CommunityToolkit.Mvvm.ComponentModel;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;

namespace GataryLabs.SwfBox.ViewModels.DataModel
{
    internal class PropertyTreeNodeDataModel : ObservableObject, IPropertyTreeNodeDataModel
    {
        private string name;
        private object rawValue;
        private string tooltipText;

        public string Name { get => name; set => SetProperty(ref name, value); }
        public object RawValue { get => rawValue; set => SetProperty(ref rawValue, value); }
        public string TooltipText { get => tooltipText; set => SetProperty(ref tooltipText, value); }
    }
}
