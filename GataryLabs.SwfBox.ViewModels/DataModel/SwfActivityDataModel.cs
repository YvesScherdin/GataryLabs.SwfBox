using CommunityToolkit.Mvvm.ComponentModel;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using System;

namespace GataryLabs.SwfBox.ViewModels.DataModel
{
    internal class SwfActivityDataModel : ObservableObject, ISwfActivityDataModel
    {
        private DateTimeOffset? lastExecutedAt;

        public DateTimeOffset? LastExecutedAt
        {
            get => lastExecutedAt;
            set => SetProperty(ref lastExecutedAt, value);
        }
    }
}
