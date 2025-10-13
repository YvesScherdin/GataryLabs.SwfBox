namespace GataryLabs.SwfBox.ViewModels.Abstractions
{
    public interface IMainWindowViewModel : IViewModel
    {
        IMainWindowMenuBarViewModel MenuBarViewModel { get; }

        IMainWindowContentViewModel MainContentViewModel { get; }
    }
}
