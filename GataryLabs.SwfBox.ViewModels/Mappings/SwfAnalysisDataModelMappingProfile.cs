using GataryLabs.SwfBox.Domain.Abstractions.Models;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using GataryLabs.SwfBox.ViewModels.DataModel;
using Mapster;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GataryLabs.SwfBox.ViewModels.Mappings
{
    internal static class SwfAnalysisDataModelMappingProfile
    {
        internal static void Register()
        {
            TypeAdapterConfig<SwfAnalysisBasicInfo, IAnalysisPropertyDataModel>.NewConfig()
                .ConstructUsing(() => new AnalysisPropertyDataModel())
                .MapWith((x) => ConvertSwfAnalysisBasicInfoToDataModel(x));
            
            TypeAdapterConfig<AnalysisPropertyInfo, IAnalysisPropertyDataModel>.NewConfig()
                .ConstructUsing(() => new AnalysisPropertyDataModel())
                .MapWith((x) => ConvertAnalysisPropertyInfoToDataModel(x));

            TypeAdapterConfig<SwfAnalysisInfo, ISwfAnalysisDataModel>.NewConfig()
                .ConstructUsing(() => new SwfAnalysisDataModel())
                .MapWith(info => ConvertSwfAnalysisInfoToDataModel(info));

            TypeAdapterConfig<SwfAnalysisInfo, SwfAnalysisDataModel>.NewConfig()
                .Inherits<SwfAnalysisInfo, ISwfAnalysisDataModel>();
        }

        private static IAnalysisPropertyDataModel ConvertAnalysisPropertyInfoToDataModel(AnalysisPropertyInfo info)
        {
            IAnalysisPropertyDataModel dataModel = new AnalysisPropertyDataModel();
            dataModel.Name = info.Name;
            dataModel.TooltipText = info.Description;
            dataModel.RawValue = info.RawValue;

            if (info.Properties != null)
            {
                List<IAnalysisPropertyDataModel> propertyDataModelList = info.Properties
                    .Select(x => ConvertAnalysisPropertyInfoToDataModel(x))
                    .ToList();

                dataModel.Children = new ObservableCollection<IAnalysisPropertyDataModel>(propertyDataModelList);
            }

            return dataModel;
        }

        private static IAnalysisPropertyDataModel ConvertSwfAnalysisBasicInfoToDataModel(SwfAnalysisBasicInfo info)
        {
            IAnalysisPropertyDataModel rootInfoProperty = new AnalysisPropertyDataModel();

            rootInfoProperty.Name = "Info";
            rootInfoProperty.RawValue = info;

            List<IAnalysisPropertyDataModel> infoPropertyList = new List<IAnalysisPropertyDataModel>
            {
                CreatePropertyDataModel("FlashPlayerVersion", info.FlashPlayerVersion),
                CreatePropertyDataModel("FrameRate", info.FrameRate),
                CreatePropertyDataModel("FrameCount", info.FrameCount),
                CreatePropertyDataModel("FrameSize", info.FrameSize),
                CreatePropertyDataModel("FileLength", info.FileLength),
                CreatePropertyDataModel("SwfFormat", info.SwfFormat)
            };

            rootInfoProperty.Children = new ObservableCollection<IAnalysisPropertyDataModel>(infoPropertyList);

            return rootInfoProperty;
        }

        private static AnalysisPropertyDataModel CreatePropertyDataModel(string name, object value)
        {
            return new AnalysisPropertyDataModel { Name = $"{name} = {value}" };
        }

        private static ISwfAnalysisDataModel ConvertSwfAnalysisInfoToDataModel(SwfAnalysisInfo info)
        {
            ISwfAnalysisDataModel dataModel = new SwfAnalysisDataModel();

            if (info?.Info != null)
            {
                IAnalysisPropertyDataModel infoProperty = info.Info.Adapt<IAnalysisPropertyDataModel>();
                dataModel.Properties.Add(infoProperty);
            }

            if (info?.Tags != null)
            {
                int count = info?.Tags?.Count ?? 0;
                IAnalysisPropertyDataModel tagsProperty = new AnalysisPropertyDataModel { Name = $"Tags ({count})" };
                dataModel.Properties.Add(tagsProperty);

                if (count != 0)
                {
                    tagsProperty.Children = new ObservableCollection<IAnalysisPropertyDataModel>();
                    List<IAnalysisPropertyDataModel> tagProperties = info.Tags.Adapt<List<IAnalysisPropertyDataModel>>();
                    tagProperties.ForEach(x => tagsProperty.Children.Add(x));
                }
            }

            return dataModel;
        }

    }
}
