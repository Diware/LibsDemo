using System;
using System.Collections.Generic;

namespace Diware.SL.Results
{
    [Obsolete("Use QueryResult instead.")]
    public abstract class ResultBase : IResult
    {
        protected bool _Failed;
        protected Dictionary<int, object> _FailReasons = new Dictionary<int, object>();

        protected ResultBase() { }


        public ResultBase(IDictionary<int, object> failReasons) : this()
        {
            _Failed = true;
            foreach (var kv in failReasons)
            {
                _FailReasons.Add(kv.Key, kv.Value);
            }
        }


        /// <inheritdoc />
        public bool Failed => _Failed;

        /// <inheritdoc />
        public IDictionary<int, object> FailReasons => _FailReasons;
    }
}
