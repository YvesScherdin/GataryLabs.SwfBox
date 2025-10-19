using GataryLabs.SwfBox.Views.Abstractions.Models;
using System.Collections.Generic;

namespace GataryLabs.SwfBox.ViewModels.Extensions
{
    internal static class OpenFileDialogOptionsExtensions
    {
        internal static OpenFileDialogOptions AddFilter(this OpenFileDialogOptions options, string name, params string[] extensions)
        {
            return options.AddFilter(new FileExtensionInfo { Name = name, Extensions = extensions });
        }

        internal static OpenFileDialogOptions AddFilter(this OpenFileDialogOptions options, string name, IList<string> extensions)
        {
            return options.AddFilter(new FileExtensionInfo { Name = name, Extensions = extensions });
        }

        internal static OpenFileDialogOptions AddFilter(this OpenFileDialogOptions options, FileExtensionInfo extensionInfo)
        {
            options.FileFilters ??= new List<FileExtensionInfo>();
            options.FileFilters.Add(extensionInfo);

            return options;
        }
    }
}
