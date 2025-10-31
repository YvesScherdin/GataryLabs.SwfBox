using GataryLabs.Mvvm.Views.Abstractions;
using System.Collections.Generic;

namespace GataryLabs.Mvvm.Services.Abstractions.Models
{
    public class OpenFileDialogOptions
    {
        public IView Owner { get; set; }

        public string Title { get; set; }
        public string DefaultExt { get; set; }
        public IList<FileExtensionInfo> FileFilters { get; set; }
        public string InitialDirectory { get; set; }
        public bool Multiselect { get; set; }
        public bool ReadOnlyChecked { get; set; }
        public bool ShowReadOnly { get; set; }
    }
}
