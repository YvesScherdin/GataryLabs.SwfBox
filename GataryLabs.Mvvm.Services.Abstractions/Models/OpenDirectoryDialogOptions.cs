using GataryLabs.Mvvm.Views.Abstractions;

namespace GataryLabs.Mvvm.Services.Abstractions.Models
{
    public class OpenDirectoryDialogOptions
    {
        public IView Owner { get; set; }

        public string Title { get; set; }
        public string InitialDirectory { get; set; }
        public string AcceptButtonText { get; set; }

        public bool AllowCreateNewFolder { get; set; } = true;
    }
}
