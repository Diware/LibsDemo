using System;
using System.Collections.Generic;

namespace Diware.SL.Results
{
    [Obsolete("Use QueryResult instead.")]
    public interface IResult
    {
        /// <summary>
        /// Indicates if operation has failed.
        /// </summary>
        bool Failed { get; }


        /// <summary>
        /// A dictionary of failure reasons failure with optional arguments 
        /// for each reason.
        /// </summary>
        IDictionary<int, object> FailReasons { get; }
    }
}
