using System;
using System.Collections.Generic;
using System.Text;

namespace Diware.SL.Results
{
    /// <summary>
    /// A query result which has only outcomes, defined in 
    /// <see cref="StandardQueryResultType"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StandardQueryResult<T>
        : QueryResult<T, StandardQueryResultType>
        , IStandardQueryResult<T>
    {
        private StandardQueryResult() { }


        internal static IStandardQueryResult<T> Success(T result)
        {
            return new StandardQueryResult<T>()
            {
                ResultType = StandardQueryResultType.Success,
                Result = result
            };
        }


        internal static IStandardQueryResult<T> InsufficientRights()
        {
            return new StandardQueryResult<T>
            {
                ResultType = StandardQueryResultType.InsufficientRigths
            };
        }


        internal static IStandardQueryResult<T> RecordNotFound()
        {
            return new StandardQueryResult<T>
            {
                ResultType = StandardQueryResultType.RecordNotFound
            };
        }
    }


    /// <summary>
    /// Static factory for <see cref="StandardQueryResult"/>.
    /// </summary>
    public static class StandardQueryResult
    {
        /// <summary>
        /// Creates a <see cref="StandardQueryResultType.Success"/> result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The result.</param>
        /// <returns></returns>
        public static IStandardQueryResult<T> Success<T>(T result)
        {
            return StandardQueryResult<T>.Success(result);
        }


        /// <summary>
        /// Creates an <see cref="StandardQueryResultType.InsufficientRigths"/> 
        /// result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IStandardQueryResult<T> InsufficientRights<T>()
        {
            return StandardQueryResult<T>.InsufficientRights();
        }


        /// <summary>
        /// Creates an <see cref="StandardQueryResultType.RecordNotFound"/> 
        /// result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IStandardQueryResult<T> RecordNotFound<T>()
        {
            return StandardQueryResult<T>.RecordNotFound();
        }
    }
}
