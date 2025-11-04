using GataryLabs.SwfBox.Domain.Abstractions.Models;

namespace GataryLabs.SwfBox.Domain.Abstractions
{
    public interface ISwfFileAnalyzer
    {
        void TestFile(string swfFilePath);

        SwfAnalysisInfo AnalyzeSwfFile(string swfFilePath);
    }
}
