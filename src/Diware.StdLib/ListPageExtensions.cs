namespace Diware.SL
{
    /// <summary>
    /// Extensions for <see cref="ListPage{T}"/> class.
    /// </summary>
    public static class ListPageExtensions
    {

        /// <summary>
        /// Extracts the page request information.
        /// </summary>
        public static PageRequestInfo ExtractPageRequestInfo<T>(
            this ListPage<T> @this)
        {
            return new PageRequestInfo(@this.Page, @this.ItemsPerPage);
        }


        /// <summary>
        /// Create a <see cref="PageRequestInfo"/> for the next page.
        /// </summary>
        public static PageRequestInfo? GetNextPageRequestInfo<T>(
            this ListPage<T> @this)
        {
            if (@this.Page < int.MaxValue
                && @this.Total > @this.ItemsPerPage * ((long)@this.Page + 1))
            {
                return new PageRequestInfo(@this.Page + 1, @this.ItemsPerPage);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// Create a <see cref="PageRequestInfo"/> for the previous page.
        /// </summary>
        public static PageRequestInfo? GetPreviousPageRequestInfo<T>(
            this ListPage<T> @this)
        {
            if (@this.Page > 0)
            {
                return new PageRequestInfo(@this.Page - 1, @this.ItemsPerPage);
            }
            else
            {
                return null;
            }
        }
    }
}
