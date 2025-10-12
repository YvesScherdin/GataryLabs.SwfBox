using System;

namespace GataryLabs.SwfBox.ViewModels.Abstractions.DataModels
{
    public interface ISwfMetaDataModel : IDataModel
    {
        Uri Image { get; set; }

        string Title { get; set; }

        string Description { get; set; }

        string Developer { get; set; }

        Uri DeveloperLogo { get; set; }
    }
}
