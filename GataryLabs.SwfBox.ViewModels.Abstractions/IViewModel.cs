using System.ComponentModel;

namespace GataryLabs.SwfBox.ViewModels.Abstractions
{
    public interface IViewModel : INotifyPropertyChanged, INotifyPropertyChanging
    {
        void OnLoaded();
        void OnUnloaded();
    }
}
