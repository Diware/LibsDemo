using System;
using System.Collections.Generic;
using System.Text;

namespace Diware.SL.Results
{
    /// <summary>
    /// Result type for <see cref="StandardQueryResult" />.
    /// </summary>
    public enum StandardQueryResultType : int
    {
        /// <summary>
        /// Query is successfull.
        /// </summary>
        Success = 0,

        /// <summary>
        /// User's rights are insufficient to perform the query.
        /// </summary>
        InsufficientRigths = -100,

        /// <summary>
        /// The record not found
        /// </summary>
        RecordNotFound = -200
    }
}
