namespace GataryLabs.SwfBox.Persistence.Abstractions.Models
{
    public class LibraryFileData
    {
        public SwfFileDetailsData[] FileDetails { get; set; }

        public SwfFileLibraryData[] Libraries { get; set; }
    }
}
