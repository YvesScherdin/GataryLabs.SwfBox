using GataryLabs.SwfBox.Domain.Abstractions;
using SwfLib;
using System.Diagnostics;
using System.IO;

namespace GataryLabs.SwfBox.Domain
{
    internal class SwfFileAnalyzer : ISwfFileAnalyzer
    {
        public void TestFile(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                SwfFile swfFile = SwfFile.ReadFrom(reader.BaseStream);

                Debug.WriteLine(swfFile.FileInfo);
                Debug.WriteLine(swfFile.FileInfo.Version);
                Debug.WriteLine(swfFile.FileInfo.Format);
                Debug.WriteLine(swfFile.FileInfo.FileLength);
            }
        }
    }
}
