using GataryLabs.Mvvm.ViewModels.Abstractions;

namespace GataryLabs.SwfBox.ViewModels.Abstractions
{
    public interface IMainWindowViewModel : IViewModel
    {
        IMainWindowMenuBarViewModel MenuBarViewModel { get; }

        IMainWindowContentNavigator ContentNavigator { get; }

        IMainWindowContextDataModel ContextDataModel { get; }
    }
}
