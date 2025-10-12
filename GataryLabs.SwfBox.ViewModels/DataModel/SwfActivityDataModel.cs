using CommunityToolkit.Mvvm.ComponentModel;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using System;

namespace GataryLabs.SwfBox.ViewModels.DataModel
{
    internal class SwfActivityDataModel : ObservableObject, ISwfActivityDataModel
    {
        private DateTimeOffset? lastExecutedAt;
        private DateTimeOffset? registeredAt;
        private long lastExecutionDuration;
        private long averageExecutionDuration;

        public DateTimeOffset? LastExecutedAt
        {
            get => lastExecutedAt;
            set => SetProperty(ref lastExecutedAt, value);
        }

        public DateTimeOffset? RegisteredAt
        {
            get => registeredAt;
            set => SetProperty(ref registeredAt, value);
        }

        public long LastExecutionDuration
        {
            get => lastExecutionDuration;
            set => SetProperty(ref lastExecutionDuration, value);
        }

        public long AverageExecutionDuration
        {
            get => averageExecutionDuration;
            set => SetProperty(ref averageExecutionDuration, value);
        }
    }
}
