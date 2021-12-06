namespace Diware.SL
{
    /// <summary>
    /// Extensions for <see cref="PageRequestInfo"/> class.
    /// </summary>
    public static class PageRequestInfoExtensions
    {

        /// <summary>
        /// Creates a <see cref="PageRequestInfo"/> for a next page.
        /// </summary>
        public static PageRequestInfo? NextPage(
            this PageRequestInfo @this)
        {
            if (@this.Page < int.MaxValue)
            {
                return new PageRequestInfo(@this.Page + 1, @this.ItemsPerPage);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Creates a <see cref="PageRequestInfo"/> for a previous page.
        /// </summary>
        public static PageRequestInfo? PreviousPage(
            this PageRequestInfo @this)
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
