namespace GataryLabs.SwfBox.Persistence.Abstractions.Models
{
    public class SwfAnalysisData
    {
        public byte FlashPlayerVersion { get; set; }
        public string SwfFormat { get; set; }
        public uint FileLength { get; set; }
        public string FrameSize { get; set; }
        public double FrameRate { get; set; }
        public ushort FrameCount { get; set; }
    }
}
