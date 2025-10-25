namespace GataryLabs.SwfBox.Domain.Abstractions.Models
{
    public class ScanFolderOptions
    {
        /// <summary>
        /// The depth to scan.
        /// 0 meaning staying in the current folder;
        /// 1 meaning scan one level deeper (meaning the sub folders of the directory);
        /// x meaning scan x levels deeper; whereas x >= 0
        /// </summary>
        public byte Depth { get; set; } = 0;

        public string[] FileNamesToIgnore { get; set; }
    }
}
