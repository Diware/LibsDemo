using FluentAssertions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace Diware.SL.UnitTests.ValueObjectT
{
    public class ValueObjectTests
    {
        public class Sut1
            : ValueObject<Sut1>
        {
            public string A { get; set; }
        }


        class Sut1_Equals : IEnumerable<object[]>
        {
            IEnumerator<object[]> IEnumerable<object[]>.GetEnumerator()
            {
                yield return new object[] {
                    new Sut1() { A = "a" },
                    new Sut1() { A = "a" },
                    true
                };

                yield return new object[] {
                    new Sut1() { A = "x"},
                    new Sut1() { A = "y"},
                    false
                };

                yield return new object[] {
                    null,
                    new Sut1() { A = "a" },
                    false
                };

                yield return new object[] {
                    new Sut1() { A = "a" },
                    null,
                    false
                };
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable<object[]>)this).GetEnumerator();
            }
        }


        [Theory()]
        [ClassData(typeof(Sut1_Equals))]
        public void Sut1_X_EqualsOp_Y(Sut1 a, Sut1 b, bool expected)
        {
            (a == b).Should().Be(expected);
        }


        [Theory()]
        [ClassData(typeof(Sut1_Equals))]
        public void Sut1_X_NotEqualsOp_Y(Sut1 a, Sut1 b, bool expected)
        {
            (a != b).Should().Be(!expected);
        }


        [Theory()]
        [ClassData(typeof(Sut1_Equals))]
        public void Sut1_X_Equals_Y(Sut1 a, Sut1 b, bool expected)
        {
            Equals(a, b).Should().Be(expected);
        }
    }
}
