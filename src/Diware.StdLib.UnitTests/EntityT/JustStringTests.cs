using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Diware.SL.UnitTests.EntityT
{
	public class JustStringTests
	{

		[Theory()]
		[InlineData("x", "x", 1, 1, true)]
		[InlineData(null, null, 1, 1, true)]
		[InlineData("x", null, 1, 1, false)]
		[InlineData(null, "x", 1, 1, false)]
		public void EqualsTest(
			string idA, string idB,
			int payloadA, int payloadB,
			bool expected)
		{
			var a = new JustEntity<string>()
			{
				MyId = idA,
				Payload = payloadA
			};
			var b = new JustEntity<string>()
			{
				MyId = idB,
				Payload = payloadB
			};

			Equals(a, b).Should().Be(expected);
		}


		[Theory()]
		[InlineData("x", "x", 1, 1, true)]
		[InlineData(null, null, 1, 1, true)]
		[InlineData("x", null, 1, 1, false)]
		[InlineData(null, "x", 1, 1, false)]
		public void GetHashCodeTest(
			string idA, string idB,
			int payloadA, int payloadB,
			bool expected)
		{
			var a = new JustEntity<string>()
			{
				MyId = idA,
				Payload = payloadA
			};
			var b = new JustEntity<string>()
			{
				MyId = idB,
				Payload = payloadB
			};

			var hashA = a.GetHashCode();
			var hashB = b.GetHashCode();

			(hashA == hashB).Should().Be(expected);
		}
	}
}
