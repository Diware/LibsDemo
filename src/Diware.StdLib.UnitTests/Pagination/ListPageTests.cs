using FluentAssertions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Diware.SL.UnitTests.Pagination
{
    public class ListPageTests
    {

        [Theory]
        [InlineData(0, 100, 200, 0, 0)]
        [InlineData(2, 100, 1000, 200, 200)]
        [InlineData(int.MaxValue, 10, long.MaxValue, -1, 21474836470)]
        public void SkippedTest(int page, int itemsPerPage, long total, int skipped, long longSkipped)
        {
            IEnumerable<int> items = Enumerable.Empty<int>();

            var sut = new ListPage<int>(page, itemsPerPage, total, items);
            sut.Skipped.Should().Be(skipped);
            sut.LongSkipped.Should().Be(longSkipped);
        }


        [Theory]
        [InlineData(0, 10, 100)]
        public void ExtractPageRequestInfoTest(int page, int ipp, long total)
        {
            var sut = new ListPage<int>(page, ipp, total,
                Enumerable.Repeat(0, ipp));

            var pri = sut.ExtractPageRequestInfo();

            pri.Page.Should().Be(page);
            pri.ItemsPerPage.Should().Be(ipp);
        }


        [Theory]
        [InlineData(0, 10, 100, true, 1, 10)]
        [InlineData(int.MaxValue, 10, 100, false, 0, 0)]
        [InlineData(int.MaxValue, 10, long.MaxValue, false, 0, 0)]
        public void NextPageTest(int page, int ipp, long total,
            bool hasValue, int newPage, int newIPP)
        {
            var sut = new ListPage<int>(page, ipp, total,
                Enumerable.Repeat(0, ipp));

            var pri = sut.GetNextPageRequestInfo();
            pri.HasValue.Should().Be(hasValue);
            if (hasValue)
            {
                pri.Value.Page.Should().Be(newPage);
                pri.Value.ItemsPerPage.Should().Be(newIPP);
            }
        }


        [Theory]
        [InlineData(5, 10, 100, true, 4, 10)]
        [InlineData(0, 10, 100, false, 0, 0)]
        public void PrevPageTest(int page, int ipp, long total,
            bool hasValue, int newPage, int newIPP)
        {
            var sut = new ListPage<int>(page, ipp, total,
                Enumerable.Repeat(0, ipp));

            var pri = sut.GetPreviousPageRequestInfo();
            pri.HasValue.Should().Be(hasValue);
            if (hasValue)
            {
                pri.Value.Page.Should().Be(newPage);
                pri.Value.ItemsPerPage.Should().Be(newIPP);
            }
        }

    }
}
