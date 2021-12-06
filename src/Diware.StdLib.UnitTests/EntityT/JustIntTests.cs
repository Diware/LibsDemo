using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using xa = Xunit.Assert;

namespace Diware.SL.UnitTests.EntityT
{
	public class JustIntTests
	{

		[Theory]
		[InlineData(1, 1, 100, 200, true)]
		[InlineData(1, 1, 100, 100, true)]
		[InlineData(1, 2, 100, 100, false)]
		[InlineData(1, 2, 100, 200, false)]
		void X_Equals_Y(
			int idA, int idB,
			int payloadA, int payloadB,
			bool expected)
		{
			// payload must be ignored for entity
			var a = new JustEntity<int>();
			a.MyId = idA;
			a.Payload = payloadA;
			var b = new JustEntity<int>();
			b.MyId = idB;
			b.Payload = payloadB;

			xa.Equal(expected, a.Equals(b));
			//xa.Equal(expected, Equals(a, b));
		}


		[Theory]
		[InlineData(1, 1, 100, 200, true)]
		[InlineData(1, 1, 100, 100, true)]
		[InlineData(1, 2, 100, 100, false)]
		[InlineData(1, 2, 100, 200, false)]
		void Equals_X_Y(
			int idA, int idB,
			int payloadA, int payloadB,
			bool expected)
		{
			// payload must be ignored for entity
			var a = new JustEntity<int>();
			a.MyId = idA;
			a.Payload = payloadA;
			var b = new JustEntity<int>();
			b.MyId = idB;
			b.Payload = payloadB;

			xa.Equal(expected, Equals(a, b));
		}


		[Theory]
		[InlineData(1, 1, 100, 200, true)]
		[InlineData(1, 1, 100, 100, true)]
		[InlineData(1, 2, 100, 100, false)]
		[InlineData(1, 2, 100, 200, false)]
		void X_EqualsOp_Y(
			int idA, int idB,
			int payloadA, int payloadB,
			bool expected)
		{
			// payload must be ignored for entity
			var a = new JustEntity<int>();
			a.MyId = idA;
			a.Payload = payloadA;
			var b = new JustEntity<int>();
			b.MyId = idB;
			b.Payload = payloadB;

			xa.Equal(expected, a == b);
		}


		[Theory]
		[InlineData(null, 1, false)]
		[InlineData(1, null, false)]
		[InlineData(1, 1, true)]
		[InlineData(null, null, true)]
		void Equals_nulls(int? i1, int? i2, bool expected)
		{
			JustEntity<int> a = null;
			JustEntity<int> b = null;

			if (i1.HasValue)
			{
				a = new JustEntity<int>();
				a.MyId = i1.Value;
			}
			if (i2.HasValue)
			{
				b = new JustEntity<int>();
				b.MyId = i2.Value;
			}

			xa.Equal(expected, a == b);
			xa.Equal(expected, Equals(a, b));
			if (a != null) xa.Equal(expected, a.Equals(b));
			if (b != null) xa.Equal(expected, b.Equals(a));
		}

	}
}
