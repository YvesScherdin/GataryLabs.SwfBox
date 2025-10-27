using System;

namespace GataryLabs.SwfBox.Domain.Abstractions.Models
{
    public class SessionHistory
    {
        public string RecentScanDirectory { get; set; }

        public Guid RecentSwfFile { get; set; }
    }
}
