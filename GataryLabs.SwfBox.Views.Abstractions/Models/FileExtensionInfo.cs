using System.Collections.Generic;

namespace GataryLabs.SwfBox.Views.Abstractions.Models
{
    public class FileExtensionInfo
    {
        public string Name { get; set; }
        public IList<string> Extensions { get; set; }
    }
}
