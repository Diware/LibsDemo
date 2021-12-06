using System;
using System.Collections;
using System.Collections.Generic;

namespace Diware.SL
{
    /// <summary>
    /// Represents items of a single page of paged list.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ListPage<T>
        : IEnumerable<T>
    {

        private List<T> items = new List<T>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ListPage{T}"/> class.
        /// </summary>
        [Obsolete("Use overload with parameters instead.")]
        public ListPage()
        {

        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ListPage{T}"/> class.
        /// </summary>
        /// <param name="page">The page number.</param>
        /// <param name="itemsPerPage">The items per page.</param>
        /// <param name="total">Total number of items in the source list.</param>
        /// <param name="items">The items on page.</param>
        /// <exception cref="ArgumentNullException">items</exception>
        public ListPage(
            int page,
            int itemsPerPage,
            long total,
            IEnumerable<T> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            Page = page;
            ItemsPerPage = itemsPerPage;
            Total = total;
            this.items.AddRange(items);
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ListPage{T}"/> class.
        /// </summary>
        /// <param name="pageRequestInfo">Page description.</param>
        /// <param name="total">Total number of items in the source list.</param>
        /// <param name="items">The items on page.</param>
        /// <exception cref="ArgumentNullException">items</exception>
        public ListPage(
            PageRequestInfo pageRequestInfo,
            long total,
            IEnumerable<T> items)
            : this(pageRequestInfo.Page, pageRequestInfo.ItemsPerPage, total, items)
        {
        }


        /// <summary>
        /// Total amount of items.
        /// </summary>
        public long Total { get; set; }


        /// <summary>
        /// Page number, zero-based.
        /// </summary>
        public int Page { get; set; }


        /// <summary>
        /// Number of items per page.
        /// </summary>
        public int ItemsPerPage { get; set; }


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
        /// Number of skipped items.
        /// </summary>
        public long LongSkipped => (long)ItemsPerPage * Page;


        /// <summary>
        /// Items on page.
        /// </summary>
        public IEnumerable<T> Items => items;

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)items).GetEnumerator();
        }
    }
}
