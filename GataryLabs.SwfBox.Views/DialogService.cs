using GataryLabs.SwfBox.Views.Abstractions;
using GataryLabs.SwfBox.Views.Abstractions.Models;
using GataryLabs.SwfBox.Views.Utilities;
using Microsoft.Win32;
using System.Windows;

namespace GataryLabs.SwfBox.Views
{
    internal class DialogService : IDialogService
    {
        public void Alert(AlertOptions options)
        {
            Window ownerWindow = (options.Owner as Window) ?? WindowUtility.GetFocusedWindow();

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

            Window ownerWindow = (options.Owner as Window) ?? WindowUtility.GetFocusedWindow();

            bool? result = (ownerWindow != null)
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
    }
}
