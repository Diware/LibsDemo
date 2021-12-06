using System;

namespace Diware.SL.Results
{

    [Obsolete("Use QueryResult instead.")]
    public static class ResultExtensions
    {
        public static bool HasFailReason(this IResult result, int failReason)
        {
            return result.FailReasons.ContainsKey(failReason);
        }


        public static object GetFailReasonValue(this IResult result, int failReason)
        {
            if (result.FailReasons.ContainsKey(failReason))
            {
                return result.FailReasons[failReason];
            }

            return null;
        }
    }

}
