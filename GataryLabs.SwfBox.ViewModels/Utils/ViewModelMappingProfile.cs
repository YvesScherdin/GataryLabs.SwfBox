using AgileObjects.AgileMapper;
using GataryLabs.SwfBox.Domain.Abstractions.Models;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using GataryLabs.SwfBox.ViewModels.DataModel;

namespace GataryLabs.SwfBox.ViewModels.Utils
{
    internal static class ViewModelMappingProfile
    {
        internal static void Register(IMapper mapper)
        {
            mapper.WhenMapping.From<SwfMetaDataInfo>().To<ISwfMetaDataModel>().MapTo<SwfMetaDataModel>();
            mapper.WhenMapping.From<SwfFileDetailsInfo>().To<ISwfFileBriefDataModel>().MapTo<SwfFileBriefDataModel>();

            mapper.WhenMapping.From<SwfFileDetailsInfo>().To<SwfFileBriefDataModel>()
                .IgnoreSource(source => new object[] { source.Activity, source.Analysis, source.MetaData })
                .And.Map(ctx => ctx.Source.FileName).To(trg => trg.Title)
                .And.If(ctx => ctx.Source.MetaData != null)
                    .Map(ctx => ctx.Source.MetaData.Image).To(trg => trg.Image);
        }
    }
}
