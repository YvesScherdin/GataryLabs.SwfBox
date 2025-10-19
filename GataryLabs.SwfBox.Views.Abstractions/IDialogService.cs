using GataryLabs.SwfBox.Views.Abstractions.Models;

namespace GataryLabs.SwfBox.Views.Abstractions
{
    public interface IDialogService
    {
        OpenFileDialogResult OpenFile(OpenFileDialogOptions options);
    }
}
