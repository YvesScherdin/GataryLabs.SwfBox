using System;

namespace GataryLabs.SwfBox.ViewModels.Abstractions.DataModels
{
    public interface ISwfFileBriefDataModel : IDataModel
    {
        public Guid Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
    }
}
