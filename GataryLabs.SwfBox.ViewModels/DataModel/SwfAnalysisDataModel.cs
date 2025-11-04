using CommunityToolkit.Mvvm.ComponentModel;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using System.Collections.ObjectModel;

namespace GataryLabs.SwfBox.ViewModels.DataModel
{
    internal class SwfAnalysisDataModel : ObservableObject, ISwfAnalysisDataModel
    {
        private ObservableCollection<IAnalysisPropertyDataModel> properties = new ObservableCollection<IAnalysisPropertyDataModel>();

        public ObservableCollection<IAnalysisPropertyDataModel> Properties
        {
            get => properties;
            set => SetProperty(ref properties, value);
        }
    }
}
