using GataryLabs.SwfBox.Domain.Abstractions.Models;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using GataryLabs.SwfBox.ViewModels.Constants;
using GataryLabs.SwfBox.ViewModels.DataModel;
using Mapster;

namespace GataryLabs.SwfBox.ViewModels.Utils
{
    internal static class ViewModelMappingProfile
    {
        internal static void Register()
        {
            TypeAdapterConfig<SwfMetaDataInfo, ISwfMetaDataModel>.NewConfig()
                .ConstructUsing(() => new SwfMetaDataModel())
                .Map(d => d.Description, s => s.Description)
                .Map(d => d.Developer, s => s.Developer)
                .Map(d => d.DeveloperLogo, s => s.DeveloperLogo)
                .Map(d => d.Image, s => s.Image)
                .Map(d => d.Title, s => s.Title)
                .TwoWays();

            TypeAdapterConfig<SwfMetaDataInfo, SwfMetaDataModel>.NewConfig()
                .Inherits<SwfMetaDataInfo, ISwfMetaDataModel>();

            TypeAdapterConfig<SwfAnalysisInfo, ISwfAnalysisDataModel>.NewConfig()
                .ConstructUsing(() => new SwfAnalysisDataModel())
                .Map(d => d.FileLength, s => s.FileLength)
                .Map(d => d.Format, s => s.Format)
                .Map(d => d.Version, s => s.Version)
                .TwoWays();

            TypeAdapterConfig<SwfAnalysisInfo, SwfAnalysisDataModel>.NewConfig()
                .Inherits<SwfAnalysisInfo, ISwfAnalysisDataModel>();

            TypeAdapterConfig<SwfActivityInfo, ISwfActivityDataModel>.NewConfig()
                .ConstructUsing(() => new SwfActivityDataModel())
                .Map(d => d.AverageExecutionDuration, s => s.AverageExecutionDuration)
                .Map(d => d.LastExecutedAt, s => s.LastExecutedAt)
                .Map(d => d.LastExecutionDuration, s => s.LastExecutionDuration)
                .Map(d => d.RegisteredAt, s => s.RegisteredAt)
                .TwoWays();

            TypeAdapterConfig<SwfActivityInfo, SwfActivityDataModel>.NewConfig()
                .Inherits<SwfActivityInfo, ISwfActivityDataModel>();

            TypeAdapterConfig<SwfFileDetailsInfo, ISwfFileDetailsDataModel>.NewConfig()
                .ConstructUsing(() => new SwfFileDetailsDataModel())
                .Map(d => d.Id, s => s.Id)
                .Map(d => d.Path, s => s.Path)
                .Map(d => d.FileName, s => s.FileName)
                .Map(d => d.Activity, s => s.Activity)
                .Map(d => d.Analysis, s => s.Analysis)
                .Map(d => d.MetaData, s => s.MetaData)
                .TwoWays();

            TypeAdapterConfig<SwfFileDetailsInfo, SwfFileDetailsDataModel>.NewConfig()
                .Inherits<SwfFileDetailsInfo, ISwfFileDetailsDataModel>();

            TypeAdapterConfig<SwfFileDetailsInfo, ISwfFileBriefDataModel>.NewConfig()
                .ConstructUsing(() => new SwfFileBriefDataModel())
                .Map(d => d.Id, s => s.Id)
                .Map(d => d.Title, s => s.FileName)
                .Map(d => d.Image, s => ConvertMataDataToImage(s.MetaData))
                .Map(d => d.Description, s => s.MetaData != null ? s.MetaData.Description : null)
                .TwoWays();

            TypeAdapterConfig<SwfFileDetailsInfo, SwfFileBriefDataModel>.NewConfig()
                .Inherits<SwfFileDetailsInfo, ISwfFileBriefDataModel>();

        }

        private static object ConvertMataDataToImage(SwfMetaDataInfo metaData)
        {
            return metaData?.Image ?? FallbackFilePathes.SwfDefaultIconSmall;
        }
    }
}
