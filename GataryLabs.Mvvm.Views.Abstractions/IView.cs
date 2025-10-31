using GataryLabs.Mvvm.ViewModels.Abstractions;

namespace GataryLabs.Mvvm.Views.Abstractions
{
    public interface IView
    {
        IViewModel ViewModel { get; }
    }
}
