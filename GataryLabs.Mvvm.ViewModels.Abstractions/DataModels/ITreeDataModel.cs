using System.Collections.ObjectModel;

namespace GataryLabs.Mvvm.ViewModels.Abstractions.DataModels
{
    public interface ITreeDataModel<TData>
    {
        ObservableCollection<ITreeNodeDataModel<TData>> RootNodes { get; set; }
    }
    
    public interface ITreeDataModel : ITreeDataModel<object>
    {
    }
}
