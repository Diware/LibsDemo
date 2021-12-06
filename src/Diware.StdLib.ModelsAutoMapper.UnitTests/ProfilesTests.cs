using AutoMapper;
using Diware.SL.JsonNetModels.AutoMapper;
using Xunit;

namespace Diware.StdLib.ModelsAutoMapper.UnitTests
{
    public class ProfilesTests
    {
        [Fact]
        public void JsonNetModelsProfileTest()
        {
            var cfg = new MapperConfiguration(c
                => c.AddProfile<JsonNetModelsProfile>());
            cfg.AssertConfigurationIsValid();
        }
    }
}