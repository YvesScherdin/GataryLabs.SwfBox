using GataryLabs.Mvvm.Services.Abstractions;
using GataryLabs.Mvvm.Services.Abstractions.Models;
using GataryLabs.Mvvm.Services.Utilities;
using Microsoft.Win32;
using PropertyTools.Wpf.Shell32;
using System.Windows;
using static PropertyTools.Wpf.Shell32.BrowseForFolderDialog;

namespace GataryLabs.Mvvm.Services
{
    public class DialogService : IDialogService
    {
        public void Alert(AlertOptions options)
        {
            Window ownerWindow = options.Owner as Window ?? WindowUtility.GetFocusedWindow();

            if (string.IsNullOrEmpty(options.Title))
                MessageBox.Show(ownerWindow, options.Message, "", MessageBoxButton.OK);
            else
                MessageBox.Show(ownerWindow, options.Message, options.Title, MessageBoxButton.OK);
        }

        public OpenFileDialogResult OpenFile(OpenFileDialogOptions options)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Title = options.Title;
            dialog.DefaultExt = options.DefaultExt;
            dialog.Filter = FileExtensionInfoUtility.StringifyExtensionList(options.FileFilters);
            dialog.InitialDirectory = options.InitialDirectory;
            dialog.Multiselect = options.Multiselect;
            dialog.ReadOnlyChecked = options.ReadOnlyChecked;
            dialog.ShowReadOnly = options.ShowReadOnly;

            Window ownerWindow = options.Owner as Window ?? WindowUtility.GetFocusedWindow();

            bool? result = ownerWindow != null
                ? dialog.ShowDialog(ownerWindow)
                : dialog.ShowDialog();

            if (!result.GetValueOrDefault())
                return new OpenFileDialogResult { Accepted = false };

            return new OpenFileDialogResult
            {
                Accepted = true,
                FileName = dialog.FileName
            };
        }

        public OpenDirectoryDialogResult OpenDirectory(OpenDirectoryDialogOptions options)
        {
            BrowseForFolderDialog dialog = new BrowseForFolderDialog();

            if (options.AllowCreateNewFolder)
                dialog.BrowserDialogFlags |= BrowseInfoFlags.BIF_NONEWFOLDERBUTTON;
            else
                dialog.BrowserDialogFlags &= ~BrowseInfoFlags.BIF_NONEWFOLDERBUTTON;

            if (!string.IsNullOrWhiteSpace(options.Title))
                dialog.Title = options.Title;

            if (!string.IsNullOrWhiteSpace(options.InitialDirectory))
                dialog.InitialFolder = options.InitialDirectory;

            if (!string.IsNullOrWhiteSpace(options.AcceptButtonText))
                dialog.OKButtonText = options.AcceptButtonText;

            Window ownerWindow = options.Owner as Window ?? WindowUtility.GetFocusedWindow();

            bool? result = ownerWindow != null
                ? dialog.ShowDialog(ownerWindow)
                : dialog.ShowDialog();

            if (!result.GetValueOrDefault())
                return new OpenDirectoryDialogResult { Accepted = false };

            return new OpenDirectoryDialogResult
            {
                Accepted = true,
                DirectoryPath = dialog.SelectedFolder
            };
        }
    }
}
