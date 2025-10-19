using System;

namespace GataryLabs.SwfBox.Domain.Abstractions.Models
{
    public class SwfMetaDataInfo
    {
        public Uri Image { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Developer { get; set; }

        public Uri DeveloperLogo { get; set; }
    }
}
