using System.Collections.Generic;

namespace GataryLabs.SwfBox.Domain.Abstractions.Models
{
    public class AnalysisPropertyInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public object RawValue { get; set; }

        public List<AnalysisPropertyInfo> Properties;
    }
}
