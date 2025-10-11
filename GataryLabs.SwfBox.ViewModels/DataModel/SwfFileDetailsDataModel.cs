using CommunityToolkit.Mvvm.ComponentModel;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;

namespace GataryLabs.SwfBox.ViewModels.DataModel
{
    internal class SwfFileDetailsDataModel : ObservableObject, ISwfFileDetailsDataModel
    {
        private string fileName;
        private string path;
        private ISwfActivityDataModel activity;
        private ISwfMetaDataModel metaData;
        private ISwfAnalysisDataModel analysis;

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
