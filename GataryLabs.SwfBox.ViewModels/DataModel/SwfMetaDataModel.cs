using CommunityToolkit.Mvvm.ComponentModel;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;

namespace GataryLabs.SwfBox.ViewModels.DataModel
{
    internal class SwfMetaDataModel : ObservableObject, ISwfMetaDataModel
    {
        private string format;
        private string version;
        private uint fileLength;

        public string Format
        {
            get => format;
            set => SetProperty(ref format, value);
        }

        public string Version
        {
            get => version;
            set => SetProperty(ref version, value);
        }

        public uint FileLength
        {
            get => fileLength;
            set => SetProperty(ref fileLength, value);
        }
    }
}
