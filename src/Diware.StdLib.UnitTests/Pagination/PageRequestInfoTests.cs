using FluentAssertions;
using Xunit;

namespace Diware.SL.UnitTests.Pagination
{
    public class PageRequestInfoTests
    {

        [Theory]
        [InlineData(0, 100, 0, 0)]
        [InlineData(2, 100, 200, 200)]
        [InlineData(int.MaxValue, 10, -1, 21474836470)]
        public void SkippedTest(int page, int itemsPerPage, int skipped, long longSkipped)
        {
            var sut = new PageRequestInfo(page, itemsPerPage);
            sut.Skipped.Should().Be(skipped);
            sut.LongSkipped.Should().Be(longSkipped);
        }


        [Theory]
        [InlineData(0, 100, true, 1, 100)]
        [InlineData(2, 20, true, 3, 20)]
        [InlineData(int.MaxValue, 1, false, 0, 0)]
        public void NextPageTest(int page, int itemsPerPage,
            bool hasValue, int newPage, int newIPP)
        {
            var sut = new PageRequestInfo(page, itemsPerPage);
            var r = sut.NextPage();

            r.HasValue.Should().Be(hasValue);
            if (hasValue)
            {
                r.Value.Page.Should().Be(newPage);
                r.Value.ItemsPerPage.Should().Be(newIPP);
            }
        }


        [Theory]
        [InlineData(2, 20, true, 1, 20)]
        [InlineData(int.MaxValue, 30, true, int.MaxValue - 1, 30)]
        [InlineData(0, 100, false, 0, 0)]
        public void PrevPageTest(int page, int itemsPerPage,
            bool hasValue, int newPage, int newIPP)
        {
            var sut = new PageRequestInfo(page, itemsPerPage);
            var r = sut.PreviousPage();

            r.HasValue.Should().Be(hasValue);
            if (hasValue)
            {
                r.Value.Page.Should().Be(newPage);
                r.Value.ItemsPerPage.Should().Be(newIPP);
            }
        }
    }
}
