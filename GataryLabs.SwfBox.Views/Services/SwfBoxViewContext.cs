using GataryLabs.Mvvm.Services.Abstractions;
using GataryLabs.SwfBox.ViewModels.Abstractions;
using System.IO;

namespace GataryLabs.SwfBox.Views.Services
{
    internal class SwfBoxViewContext
    {
        private IMainWindowContextDataModel contextData;
        private ILocalizationSource localizationSource;

        internal static SwfBoxViewContext Current { get; private set; }

        public SwfBoxViewContext(IMainWindowContextDataModel contextData, ILocalizationSource localizationSource)
        {
            this.contextData = contextData;
            this.localizationSource = localizationSource;

            Current = this;
        }

        public string LocalizeDisplayName(string name)
        {
            string id = "Loca.Main.SwfDetails.MetaData." + name;
            string result = localizationSource.GetText(id);
            return result ?? name;
        }

        public string CurrentSwfFileImagePath
        {
            get
            {
                string path = Path.GetDirectoryName(contextData.FileDetails?.MetaData?.Image
                                                    ?? contextData.FileDetails?.Path);

                return path;
            }
        }

        public string ImageFileFilter
        {
            get
            {
                return "Image files (*.jpeg;*.jpg;*.png;*.ico)|*.jpeg;*.jpg;*.png;*.ico";
            }
        }
    }
}
