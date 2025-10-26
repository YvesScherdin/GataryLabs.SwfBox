namespace GataryLabs.SwfBox.Configuration.Abstractions
{
    public class PlayerOptions
    {
        public int PlayerTypeIndex { get; set; } = 0;

        public bool OverlayMenuEnabled { get; set; } = false;

        public PlayerData[] Players { get; set; }
    }
}
