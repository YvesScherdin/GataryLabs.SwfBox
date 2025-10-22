namespace GataryLabs.SwfBox.ViewModels.Abstractions.DataModels
{
    public interface ISwfMetaDataModel : IDataModel
    {
        string Image { get; set; }

        string Title { get; set; }

        string Description { get; set; }

        string Developer { get; set; }

        string DeveloperLogo { get; set; }
    }
}
