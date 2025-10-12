using System;

namespace GataryLabs.SwfBox.ViewModels.Abstractions.DataModels
{
    public interface ISwfActivityDataModel
    {
        DateTimeOffset? LastExecutedAt { get; }
        DateTimeOffset? RegisteredAt { get; }
        long LastExecutionDuration { get; }
        long AverageExecutionDuration { get; }
    }
}
