using AutoMapper;

namespace Diware.StdLib.ModelsAutoMapper.UnitTests.DemoClasses
{
    internal class DemoClassesProfile : Profile
    {
        public DemoClassesProfile()
        {
            CreateMap<Class1Real, Class1JsonObject>()
                .ReverseMap();
        }
    }
}
