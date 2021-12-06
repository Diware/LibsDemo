using AutoMapper;
using Diware.SL.JsonNetModels.AutoMapper;
using Diware.StdLib.ModelsAutoMapper.UnitTests.DemoClasses;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;
using mdls = Diware.SL.JsonNetModels;
using sl = Diware.SL;

namespace Diware.StdLib.ModelsAutoMapper.UnitTests
{
    public class JsonNetModelsTests
    {
        private IMapper mapper;

        public JsonNetModelsTests()
        {
            mapper = new Mapper(new MapperConfiguration(c =>
            {
                c.AddProfile<JsonNetModelsProfile>();
                c.AddProfile<DemoClassesProfile>();
            }));
        }


        [Fact]
        public void ListPage_DirectConversionTest()
        {
            // ARRANGE
            var listPage = new sl.ListPage<Class1Real>(
                page: 10,
                itemsPerPage: 1,
                total: 100,
                new List<Class1Real> {
                    new Class1Real {
                        Name = "Demo"
                    }
                });

            var expected = new mdls.ListPage<Class1JsonObject>
            {
                Page = 10,
                ItemsPerPage = 1,
                Total = 100,
                Items = new List<Class1JsonObject> {
                    new Class1JsonObject{
                        Name = "Demo"
                    }
                }
            };

            // ACT
            var actual = mapper.Map<mdls.ListPage<Class1JsonObject>>(listPage);

            // ASSERT
            actual.ItemsPerPage.Should()
                .Be(expected.ItemsPerPage);
            actual.Page.Should()
                .Be(expected.Page);
            actual.Total.Should()
                .Be(expected.Total);
            actual.Items.Should()
                .Equal(expected.Items);
        }


        [Fact]
        public void ListPage_ReversedConversionTest()
        {
            // ARRANGE
            var listPage = new mdls.ListPage<Class1JsonObject>
            {
                Page = 10,
                ItemsPerPage = 1,
                Total = 100,
                Items = new List<Class1JsonObject> {
                    new Class1JsonObject{
                        Name = "Demo"
                    }
                }
            };

            var expected = new sl.ListPage<Class1Real>(
                page: 10,
                itemsPerPage: 1,
                total: 100,
                new List<Class1Real> {
                    new Class1Real {
                        Name = "Demo"
                    }
                });

            // ACT
            var actual = mapper.Map<sl.ListPage<Class1Real>>(listPage);

            // ASSERT
            actual.ItemsPerPage.Should()
                .Be(expected.ItemsPerPage);
            actual.Page.Should()
                .Be(expected.Page);
            actual.Total.Should()
                .Be(expected.Total);
            actual.Items.Should()
                .Equal(expected.Items);
        }
    }
}
