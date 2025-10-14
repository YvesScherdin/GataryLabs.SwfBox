using System;

namespace GataryLabs.SwfBox.ViewModels.Abstractions.DataModels
{
    public interface ISwfFileBriefDataModel : IDataModel
    {
        Guid Id { get; set; }
        string Image { get; set; }
        string Title { get; set; }
        string Path { get; set; }
        string Description { get; set; }
    }
}
