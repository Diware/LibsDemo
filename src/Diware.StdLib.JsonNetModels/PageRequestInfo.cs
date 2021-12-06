using Newtonsoft.Json;
using System.ComponentModel;

namespace Diware.SL.JsonNetModels
{
    [JsonObject]
    public class PageRequestInfo
    {
        /// <summary>
        /// Number of items per page.
        /// </summary>
        [JsonProperty("i")]
        public int ItemsPerPage { get; set; }

        /// <summary>
        /// Page number, zero-based.
        /// </summary>
        [JsonProperty("p",
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(0)]
        public int Page { get; set; }
    }
}
