using System;

namespace GataryLabs.SwfBox.Domain.Abstractions.Models
{
    public class SwfFileLibraryInfo
    {
        public Guid Id { get; set; }
        public Guid[] SwfFileDetails { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
    }
}
