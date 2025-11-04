using GataryLabs.Mvvm.ViewModels.Abstractions.DataModels;
using System.Collections.ObjectModel;

namespace GataryLabs.Mvvm.ViewModels.DataModels
{
    public class TreeNodeDataModel<TData> : PropertyChangeNotifier, ITreeNodeDataModel<TData>
    {
        private TData data;
        private ObservableCollection<ITreeNodeDataModel<TData>> children;

        public TData Data
        {
            get => data;
            set => SetPropertyValue(ref data, value);
        }

        public ObservableCollection<ITreeNodeDataModel<TData>> Children
        {
            get => children;
            set => SetPropertyValue(ref children, value);
        }
    }
}
