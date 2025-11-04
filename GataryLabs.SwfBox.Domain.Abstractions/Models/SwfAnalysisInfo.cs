using System.Collections.Generic;

namespace GataryLabs.SwfBox.Domain.Abstractions.Models
{
    public class SwfAnalysisInfo
    {
        public SwfAnalysisBasicInfo Info { get; set; }
        public List<AnalysisPropertyInfo> Tags { get; set; }
    }
}
