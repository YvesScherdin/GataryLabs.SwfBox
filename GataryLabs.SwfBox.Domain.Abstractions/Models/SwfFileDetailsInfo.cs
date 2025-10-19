using System;

namespace GataryLabs.SwfBox.Domain.Abstractions.Models
{
    public class SwfFileDetailsInfo
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public SwfMetaDataInfo MetaData { get; set; }
        public SwfActivityInfo Activity { get; set; }
        public SwfAnalysisInfo Analysis { get; set; }
    }
}
