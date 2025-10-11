using GataryLabs.SwfBox.ViewModels.Abstractions;

namespace GataryLabs.SwfBox.Views.Abstractions
{
    public interface IView
    {
        IViewModel ViewModel { get; }
    }
}
