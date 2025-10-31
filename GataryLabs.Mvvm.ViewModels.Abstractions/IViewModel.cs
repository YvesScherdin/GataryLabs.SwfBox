using System.ComponentModel;

namespace GataryLabs.Mvvm.ViewModels.Abstractions
{
    public interface IViewModel : INotifyPropertyChanged, INotifyPropertyChanging
    {
        void OnLoaded();
        void OnUnloaded();
    }
}
