using System;

namespace Diware.SL
{
    /// <summary>
    /// Describes a desired list page.
    /// </summary>
    public struct PageRequestInfo
    {
        static PageRequestInfo()
        {
            All = new PageRequestInfo(0, int.MaxValue);
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="PageRequestInfo"/> class.
        /// </summary>
        /// <param name="page">Page number, zero-based.</param>
        /// <param name="itemsPerPage">Number of items per page.</param>
        public PageRequestInfo(
            int page,
            int itemsPerPage)
        {
            Page = Math.Max(0, page);
            ItemsPerPage = Math.Max(1, itemsPerPage);
        }


        /// <summary>
        /// Number of items per page.
        /// </summary>
        public int ItemsPerPage { get; }


        /// <summary>
        /// Page number, zero-based.
        /// </summary>
        public int Page { get; }


        /// <summary>
        /// Number of skipped items.
        /// </summary>
#pragma warning disable IDE0004
        //IDE0004: if at least one value is not converted to long, 
        // then the result of multiplication is int
        public long LongSkipped => (long)ItemsPerPage * Page;
#pragma warning restore IDE0004


        /// <summary>
        /// Number of skipped items.
        /// </summary>
        public int Skipped
        {
            get
            {
                var ls = LongSkipped;
                if (ls > int.MaxValue) return -1;
                else return (int)ls;
            }
        }



        /// <summary>
        /// Returns a <see cref="PageRequestInfo"/> which asks for all the items.
        /// </summary>
        public static PageRequestInfo All { get; private set; }
    }
}
