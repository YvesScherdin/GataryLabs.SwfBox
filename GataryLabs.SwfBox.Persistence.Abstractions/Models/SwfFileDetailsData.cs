using System;

namespace GataryLabs.SwfBox.Persistence.Abstractions.Models
{
    public class SwfFileDetailsData
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public SwfMetaData MetaData { get; set; }
        public SwfActivityData Activity { get; set; }
        public SwfAnalysisData Analysis { get; set; }
    }
}
