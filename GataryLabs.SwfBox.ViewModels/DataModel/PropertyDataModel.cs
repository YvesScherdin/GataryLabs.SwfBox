using CommunityToolkit.Mvvm.ComponentModel;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;

namespace GataryLabs.SwfBox.ViewModels.DataModel
{
    internal class PropertyDataModel : ObservableObject, IPropertyDataModel
    {
        private string label;
        private string displayValue;
        private object rawValue;
        private string tooltipText;

        public string Label { get => label; set => SetProperty(ref label, value); }
        public string DisplayValue { get => displayValue; set => SetProperty(ref displayValue, value); }
        public object RawValue { get => rawValue; set => SetProperty(ref rawValue, value); }
        public string TooltipText { get => tooltipText; set => SetProperty(ref tooltipText, value); }
    }
}
