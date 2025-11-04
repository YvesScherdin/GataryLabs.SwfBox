using GataryLabs.Mvvm.ViewModels.Commands;
using GataryLabs.SwfBox.ViewModels.Abstractions.Commands;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using System.Diagnostics;
using System.IO;

namespace GataryLabs.SwfBox.ViewModels.Commands
{
    internal class ExploreCommand : Command<ISwfFileDetailsDataModel>, IExploreCommand
    {
        public override bool CanExecute(ISwfFileDetailsDataModel parameter)
        {
            return true;
        }

        public override void Execute(ISwfFileDetailsDataModel parameter)
        {
            string folderPath = Path.GetDirectoryName(parameter.Path);

            ProcessStartInfo processStartInfo = new ProcessStartInfo(
                "Explorer.exe", folderPath
            );

            Process.Start(processStartInfo);
        }
    }
}
