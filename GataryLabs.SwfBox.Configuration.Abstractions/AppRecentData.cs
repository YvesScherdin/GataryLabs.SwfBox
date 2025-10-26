using System;

namespace GataryLabs.SwfBox.Configuration.Abstractions
{
    public class AppRecentData
    {
        public Guid LastFileInspected { get; set; }

        public string LastDirectory { get; set; }
    }
}
