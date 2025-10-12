namespace GataryLabs.SwfBox.ViewModels.Abstractions.DataModels
{
    public interface IPropertyDataModel : IDataModel
    {
        public string Label { get; set; }
        public string DisplayValue { get; set; }
        public object RawValue { get; set; }
        public string TooltipText { get; set; }
    }
}
