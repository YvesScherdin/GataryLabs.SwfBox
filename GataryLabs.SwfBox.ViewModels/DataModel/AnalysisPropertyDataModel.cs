using CommunityToolkit.Mvvm.ComponentModel;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using System.Collections.ObjectModel;

namespace GataryLabs.SwfBox.ViewModels.DataModel
{
    internal class AnalysisPropertyDataModel : ObservableObject, IAnalysisPropertyDataModel
    {
        private string name;
        private object rawValue;
        private string tooltipText;
        private ObservableCollection<IAnalysisPropertyDataModel> children;

        public string Name { get => name; set => SetProperty(ref name, value); }
        public object RawValue { get => rawValue; set => SetProperty(ref rawValue, value); }
        public string TooltipText { get => tooltipText; set => SetProperty(ref tooltipText, value); }
        public ObservableCollection<IAnalysisPropertyDataModel> Children { get => children; set => SetProperty(ref children, value); }
    }
}
