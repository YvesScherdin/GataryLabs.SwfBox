using CommunityToolkit.Mvvm.ComponentModel;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using System.Diagnostics;

namespace GataryLabs.SwfBox.ViewModels.DataModel
{
    internal class SwfMetaDataModel : ObservableObject, ISwfMetaDataModel
    {
        private string image;
        private string title;
        private string description;
        private string developer;
        private string developerLogo;

        public string Image
        {
            get => image;
            set => SetProperty(ref image, value);
        }

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
        
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        
        public string Developer
        {
            get => developer;
            set => SetProperty(ref developer, value);
        }
        
        public string DeveloperLogo
        {
            get => developerLogo;
            set => SetProperty(ref developerLogo, value);
        }
    }
}
