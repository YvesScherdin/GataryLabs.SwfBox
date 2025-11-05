using System.Diagnostics;
using System.IO;

namespace GataryLabs.SwfBox.ViewModels.Utilities
{
    internal static class ExternalProcessUtility
    {
        internal static void OpenInExplorer(string fileOrDirectoryPathf)
        {
            string folderPath = Path.GetDirectoryName(fileOrDirectoryPathf);

            ProcessStartInfo processStartInfo = new ProcessStartInfo(
                "Explorer.exe", folderPath
            );

            Process.Start(processStartInfo);
        }
    }
}
