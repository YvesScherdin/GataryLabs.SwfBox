using CommunityToolkit.Mvvm.ComponentModel;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using System;

namespace GataryLabs.SwfBox.ViewModels.DataModel
{
    internal class SwfFileBriefDataModel : ObservableObject, ISwfFileBriefDataModel
    {
        private Guid id;
        private string image;
        private string title;
        private string path;
        private string description;

        public Guid Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }
        
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
        
        public string Path
        {
            get => path;
            set => SetProperty(ref path, value);
        }
        
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
    }
}
