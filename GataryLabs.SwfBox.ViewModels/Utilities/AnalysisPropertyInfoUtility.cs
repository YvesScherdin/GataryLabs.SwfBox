using GataryLabs.SwfBox.Domain.Abstractions.Models;
using System.Collections.Generic;

namespace GataryLabs.SwfBox.ViewModels.Utilities
{
    internal static class AnalysisPropertyInfoUtility
    {
        internal static void Clusterize(List<AnalysisPropertyInfo> tags)
        {
            const int minGroupSize = 3;
            int index = 0;
            int groupStartIndex = -1;
            string lastName = null;

            while (index < tags.Count)
            {
                AnalysisPropertyInfo currentTagProperty = tags[index];

                if (currentTagProperty.Name == lastName && !string.IsNullOrEmpty(lastName))
                {
                    if (groupStartIndex == -1)
                        groupStartIndex = index - 1;
                }
                else if (groupStartIndex != -1)
                {
                    if ((index - groupStartIndex) >= minGroupSize)
                    {
                        int count = index - groupStartIndex;

                        List<AnalysisPropertyInfo> newSubNodes = tags.GetRange(groupStartIndex, count);
                        tags.RemoveRange(groupStartIndex, count);
                        index -= count;

                        AnalysisPropertyInfo groupNode = new AnalysisPropertyInfo
                        {
                            Name = $"{lastName} ({newSubNodes.Count})",
                            Description = "Aggregated content",
                            Properties = newSubNodes
                        };

                        tags.Insert(groupStartIndex, groupNode);
                        currentTagProperty = groupNode;
                    }

                    groupStartIndex = -1;
                }

                index++;
                lastName = currentTagProperty.Name;
            }
        }
    }
}
