using GataryLabs.SwfBox.ViewModels.Abstractions;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using System;

namespace GataryLabs.SwfBox.ViewModels.Extensions
{
    internal static class MainWindowSwfDetailsContentViewModelExtensions
    {
        internal static bool DisplaysSwf(this IMainWindowSwfDetailsContentViewModel viewModel, ISwfFileBriefDataModel swfFileBriefData)
        {
            return viewModel.Details?.Id == swfFileBriefData.Id;
        }

        internal static bool DisplaysSwf(this IMainWindowSwfDetailsContentViewModel viewModel, Guid swfFileId)
        {
            return viewModel.Details?.Id == swfFileId;
        }
    }
}
