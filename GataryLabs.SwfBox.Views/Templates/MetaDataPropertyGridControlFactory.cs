using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using GataryLabs.SwfBox.Views.Services;
using PropertyTools.Wpf;
using System.Windows;
using System.Windows.Data;

namespace GataryLabs.SwfBox.Views.Templates
{
    public class MetaDataPropertyGridControlFactory : PropertyGridControlFactory
    {
        public override FrameworkElement CreateControl(PropertyItem property, PropertyControlFactoryOptions options)
        {
            string displayName = SwfBoxViewContext.Current.LocalizeDisplayName(property.DisplayName);
            property.DisplayName = displayName;

            switch (property.PropertyName)
            {
                case nameof(ISwfMetaDataModel.Image):
                case nameof(ISwfMetaDataModel.DeveloperLogo):
                    FilePicker filePicker = new FilePicker();
                    filePicker.FilePath = SwfBoxViewContext.Current.CurrentSwfFileImagePath;
                    filePicker.Filter = SwfBoxViewContext.Current.ImageFileFilter;
                    filePicker.Multiselect = false;
                    filePicker.SetBinding(FilePicker.FilePathProperty, new Binding(property.Descriptor.DisplayName));

                    return filePicker;
            }

            return base.CreateControl(property, options);
        }
    }
}
