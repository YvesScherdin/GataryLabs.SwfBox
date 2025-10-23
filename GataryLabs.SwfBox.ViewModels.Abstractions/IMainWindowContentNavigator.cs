using System.ComponentModel;

namespace GataryLabs.SwfBox.ViewModels.Abstractions
{
    public interface IMainWindowContentNavigator : INotifyPropertyChanged, INotifyPropertyChanging
    {
        IMainWindowContentViewModel ContentViewModel { get; set; }
        IMainWindowSwfDetailsContentViewModel SwfDetailsContentViewModel { get; }
        IMainWindowOverviewContentViewModel OverviewContentViewModel { get; }
    }
}
