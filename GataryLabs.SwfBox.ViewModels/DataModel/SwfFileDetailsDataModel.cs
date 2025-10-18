using CommunityToolkit.Mvvm.ComponentModel;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using System;

namespace GataryLabs.SwfBox.ViewModels.DataModel
{
    internal class SwfFileDetailsDataModel : ObservableObject, ISwfFileDetailsDataModel
    {
        private Guid id;
        private string fileName;
        private string path;
        private string description;
        private ISwfActivityDataModel activity;
        private ISwfMetaDataModel metaData;
        private ISwfAnalysisDataModel analysis;

        public Guid Id
        {
            get => id;
            init => id = value;
        }

        public string FileName
        {
            get => fileName;
            set => SetProperty(ref fileName, value);
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

        public ISwfActivityDataModel Activity
        {
            get => activity;
            set => SetProperty(ref activity, value);
        }

        public ISwfMetaDataModel MetaData
        {
            get => metaData;
            set => SetProperty(ref metaData, value);
        }

        public ISwfAnalysisDataModel Analysis
        {
            get => analysis;
            set => SetProperty(ref analysis, value);
        }
    }
}
