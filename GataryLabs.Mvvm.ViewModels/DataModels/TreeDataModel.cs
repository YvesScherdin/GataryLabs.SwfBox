using GataryLabs.Mvvm.ViewModels.Abstractions.DataModels;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace GataryLabs.Mvvm.ViewModels.DataModels
{
    public class TreeDataModel<TData> : PropertyChangeNotifier, ITreeDataModel<TData>
        where TData : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public ObservableCollection<ITreeNodeDataModel<TData>> RootNodes { get; set; } // <--- turn into root nodes
    }
}
