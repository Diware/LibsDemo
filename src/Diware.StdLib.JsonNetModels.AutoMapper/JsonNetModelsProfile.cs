using AutoMapper;
using sl = Diware.SL;

namespace Diware.SL.JsonNetModels.AutoMapper
{
    public class JsonNetModelsProfile : Profile
    {
        public JsonNetModelsProfile() : base(
            "Diware.SL.JsonModels.AutoMapper")
        {
            CreateMap(typeof(sl.ListPage<>), typeof(ListPage<>))
                .ReverseMap();
            CreateMap<sl.PageRequestInfo, PageRequestInfo>()
                .ReverseMap();
        }
    }
}
