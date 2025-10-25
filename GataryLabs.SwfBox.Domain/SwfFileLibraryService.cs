using GataryLabs.SwfBox.Domain.Abstractions.Models;
using GataryLabs.SwfBox.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace GataryLabs.SwfBox.Domain.Abstractions
{
    /// <inheritdoc cref="ISwfFileLibraryService"/>
    public class SwfFileLibraryService : ISwfFileLibraryService
    {
        private Dictionary<Guid, SwfFileDetailsInfo> allDetails;

        public SwfFileLibraryService()
        {
            allDetails = new Dictionary<Guid, SwfFileDetailsInfo>();
        }

        public IList<SwfFileDetailsInfo> GetManyFileDetails(IList<Guid> ids)
        {
            List<SwfFileDetailsInfo> result = ids
                .Select(id =>
                {
                    try
                    {
                        return GetSingleFileDetails(id);
                    }
                    catch (Exception exception)
                    {
                        Debug.WriteLine($"Had exception when retrieving details from {id}");
                        Debug.WriteLine(exception);
                        return null;
                    }
                })
                .Where(details => details != null)
                .ToList();

            return result;
        }

        public SwfFileDetailsInfo GetSingleFileDetails(Guid id)
        {
            ArgumentValidator.ThrowIfGuidEmpty(id, nameof(id));

            if (!allDetails.ContainsKey(id))
                return null;

            SwfFileDetailsInfo details = allDetails[id];
            return details;
        }

        public bool HasFileWithPath(string path)
        {
            ArgumentValidator.ThrowIfNullOrWhitespace(path, nameof(path));

            bool result = allDetails.Values
                .Any(details => details.Path?.Equals(path, StringComparison.InvariantCultureIgnoreCase) ?? false);

            return result;
        }

        public SwfFileDetailsInfo Load(string path)
        {
            ArgumentValidator.ThrowIfNullOrWhitespace(path, nameof(path));

            string fileName = Path.GetFileName(path);

            SwfFileDetailsInfo info = new SwfFileDetailsInfo
            {
                Path = path,
                FileName = fileName,
                Id = Guid.NewGuid(),

                MetaData = new SwfMetaDataInfo
                {
                    Title = fileName
                }
            };

            return info;
        }

        public SwfFileDetailsInfo[] ScanFolder(string path, ScanFolderOptions options)
        {
            ArgumentValidator.ThrowIfNull(options, nameof(options));

            List<string> swfFilePathes = new List<string>();
            AccumulateSwfFilesFromDirectory(path, options.Depth, swfFilePathes, options);

            List<SwfFileDetailsInfo> result = swfFilePathes
                .ConvertAll(Load)
                .ToList();

            return result.ToArray();
        }

        private void AccumulateSwfFilesFromDirectory(string path, int folderDepth, List<string> result, ScanFolderOptions options)
        {
            List<string> list = Directory.GetFiles(path, "*.swf").ToList();

            foreach(string possiblePath in list)
            {
                if (!options.FileNamesToIgnore.Any(possiblePath.Contains))
                    result.Add(possiblePath);
            }

            if (folderDepth > 0)
            {
                string[] subDirectories = Directory.GetDirectories(path);

                for (int i = 0; i < subDirectories.Length; i++)
                {
                    AccumulateSwfFilesFromDirectory(subDirectories[i], folderDepth - 1, result, options);
                }
            }
        }

        public void RegisterFile(SwfFileDetailsInfo info)
        {
            ArgumentValidator.ThrowIfNull(info, nameof(info));
            ArgumentValidator.ThrowIfGuidEmpty(info.Id, nameof(info.Id));

            allDetails[info.Id] = info;
        }

        public void UnregisterFile(SwfFileDetailsInfo info)
        {
            ArgumentValidator.ThrowIfNull(info, nameof(info));
            ArgumentValidator.ThrowIfGuidEmpty(info.Id, nameof(info.Id));

            allDetails.Remove(info.Id);
        }
    }
}
