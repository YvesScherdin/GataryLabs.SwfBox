using GataryLabs.Mvvm.Services.Abstractions.Models;

namespace GataryLabs.Mvvm.Services.Abstractions
{
    public interface IDialogService
    {
        void Alert(AlertOptions options);

        OpenFileDialogResult OpenFile(OpenFileDialogOptions options);

        OpenDirectoryDialogResult OpenDirectory(OpenDirectoryDialogOptions options);
    }
}
