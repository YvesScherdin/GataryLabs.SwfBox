namespace GataryLabs.SwfBox.Configuration.Abstractions
{
    public class UserSettings
    {
        public AppRecentData Recent { get; set; }

        public ScanFolderOptions Scanning { get; set; }

        public FileAnalysisOptions Analysis { get; set; }

        public PlayerOptions Player { get; set; }
    }
}
