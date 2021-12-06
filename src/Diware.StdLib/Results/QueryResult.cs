using System;
using System.Collections.Generic;
using System.Text;

namespace Diware.SL.Results
{

    /// <summary>
    /// A base result for query.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResultType">The type of the result type.</typeparam>
    public class QueryResult<T, TResultType>
        : IQueryResult<T, TResultType>
    {
        /// <summary>
        /// Gets or sets the enum type for the result type.
        /// </summary>
        /// <value>
        /// The type of the enum for the result type.
        /// </value>
        /// <remarks>
        /// Result type is used to determine if query has been successfull
        /// or has failed for some reason (i.e. entity not found, insufficient
        /// right, etc.).
        /// </remarks>
        public TResultType ResultType { get; set; }

        /// <summary>
        /// Gets or sets the result of query.
        /// </summary>
        /// <value>
        /// The result of query.
        /// </value>
        public T Result { get; set; }
    }
}
