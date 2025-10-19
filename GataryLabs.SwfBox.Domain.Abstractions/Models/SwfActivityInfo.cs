using System;

namespace GataryLabs.SwfBox.Domain.Abstractions.Models
{
    /// <summary>
    /// Describes tracked interaction.
    /// </summary>
    public class SwfActivityInfo
    {
        public DateTimeOffset? LastExecutedAt { get; set; }
        public DateTimeOffset? RegisteredAt { get; set; }
        public long LastExecutionDuration { get; set; }
        public long AverageExecutionDuration { get; set; }
    }
}
