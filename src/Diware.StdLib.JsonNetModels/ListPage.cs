using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Diware.SL.JsonNetModels
{
    [JsonObject]
    public class ListPage<T>
    {
        /// <summary>
        /// Total amount of items.
        /// </summary>
        [JsonProperty("t",
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(0)]
        public long Total { get; set; }

        /// <summary>
        /// Page number, zero-based.
        /// </summary>
        [JsonProperty("p",
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(0)]
        public int Page { get; set; }

        /// <summary>
        /// Number of items per page.
        /// </summary>
        [JsonProperty("i")]
        public int ItemsPerPage { get; set; }

        /// <summary>
        /// Items on page.
        /// </summary>
        [JsonProperty("m")]
        public IEnumerable<T> Items { get; set; }

    }
}
