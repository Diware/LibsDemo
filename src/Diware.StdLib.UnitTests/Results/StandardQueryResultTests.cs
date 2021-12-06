using Diware.SL.Results;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Diware.SL.UnitTests.Results
{
    public class StandardQueryResultTests
    {
        public class SuperClass
        {
            public string Name { get; set; }
        }

        public class SubClass : SuperClass
        {
            public int Age { get; set; }
        }


        [Fact()]
        public void Tst()
        {
            var cls = new SubClass();
            IStandardQueryResult<SubClass> subSqr = StandardQueryResult.Success<SubClass>(cls);

            IStandardQueryResult<SuperClass> superSqr = subSqr;
        }

    }
}
