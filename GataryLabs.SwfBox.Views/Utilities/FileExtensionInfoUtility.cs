using GataryLabs.SwfBox.Views.Abstractions.Models;
using System.Collections.Generic;
using System.Linq;

namespace GataryLabs.SwfBox.Views.Utilities
{
    internal static class FileExtensionInfoUtility
    {
        internal static string StringifyExtension(FileExtensionInfo info)
        {
            string namePart = string.IsNullOrWhiteSpace(info.Name) ? "" : $"{info.Name} ";
            bool extensionsAreSpecified = (info.Extensions == null || info.Extensions.Count == 0);

            string extensionDescriptionPart = extensionsAreSpecified ? "" : $"({string.Join(";", info.Extensions.Select(extension => $"*.{extension}"))})";
            string extensionDefinitionPart = extensionsAreSpecified ? "" : $"|{string.Join(";", info.Extensions.Select(extension => $"*.{extension}"))}";

            return $"{namePart}{extensionDescriptionPart}{extensionDefinitionPart}";
        }

        internal static string StringifyExtensionList(IList<FileExtensionInfo> infoList)
        {
            if (infoList == null || infoList.Count == 0)
                return null;

            string result = string.Join("|", infoList.Select(StringifyExtension).ToList());
            return result;
        }
    }
}
