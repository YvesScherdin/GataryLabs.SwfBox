using GataryLabs.SwfBox.ViewModels.Abstractions;
using System.Windows;
using System.Windows.Controls;

namespace GataryLabs.SwfBox.Views.Templates
{
    public class MainContentTemplateSelector : DataTemplateSelector
    {
        public DataTemplate SwfDetails { get; set; }
        public DataTemplate AppSettings { get; set; }
        public DataTemplate SwfFileScan { get; set; }
        public DataTemplate SwfFileLibrary { get; set; }
        public DataTemplate Error { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null) return null;
            if (container == null) return null;
            if (item is not IMainWindowContentViewModel) return null;

            switch (item)
            {
                case IMainWindowSwfDetailsContentViewModel: return SwfDetails;
                case IMainWindowErrorContentViewModel: return Error;
                default: return null;
            }
        }
    }
}
