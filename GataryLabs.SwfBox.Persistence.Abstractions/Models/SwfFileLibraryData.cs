using System;

namespace GataryLabs.SwfBox.Persistence.Abstractions.Models
{
    public class SwfFileLibraryData
    {
        public Guid Id { get; set; }
        public Guid[] SwfFileDetails { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
    }
}
