using System.Collections.ObjectModel;

namespace GataryLabs.Mvvm.ViewModels.Abstractions.DataModels
{
    public interface ITreeNodeDataModel<TData>
    {
        TData Data { get; set; }

        ObservableCollection<ITreeNodeDataModel<TData>> Children { get; set; }
    }
    
    public interface ITreeNodeDataModel : ITreeNodeDataModel<object>
    {
    }
}
