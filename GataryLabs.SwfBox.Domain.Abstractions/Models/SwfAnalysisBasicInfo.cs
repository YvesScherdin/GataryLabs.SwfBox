using System.Drawing;

namespace GataryLabs.SwfBox.Domain.Abstractions.Models
{
    public class SwfAnalysisBasicInfo
    {
        public byte FlashPlayerVersion { get; set; }
        public string SwfFormat { get; set; }
        public uint FileLength { get; set; }
        public Rectangle FrameSize { get; set; }
        public double FrameRate { get; set; }
        public ushort FrameCount { get; set; }
    }
}
