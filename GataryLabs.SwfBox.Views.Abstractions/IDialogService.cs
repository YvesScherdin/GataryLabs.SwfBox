using GataryLabs.SwfBox.Views.Abstractions.Models;

namespace GataryLabs.SwfBox.Views.Abstractions
{
    public interface IDialogService
    {
        void Alert(AlertOptions options);

        OpenFileDialogResult OpenFile(OpenFileDialogOptions options);
    }
}
