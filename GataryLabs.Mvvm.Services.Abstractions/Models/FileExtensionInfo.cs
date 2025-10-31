using System.Collections.Generic;

namespace GataryLabs.Mvvm.Services.Abstractions.Models
{
    public class FileExtensionInfo
    {
        public string Name { get; set; }
        public IList<string> Extensions { get; set; }
    }
}
